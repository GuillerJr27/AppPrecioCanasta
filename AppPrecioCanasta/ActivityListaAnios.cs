using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppPrecioCanasta
{
    [Activity (Label = "ActivityListaAnios", MainLauncher = true)]
    class ActivityListaAnios : Activity
    {
        ListView Lista_Alimentos, Lista_Vestuario, Lista_Usohogar, Lista_Total, Lista_A;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListaAnios);
            Lista_A = FindViewById<ListView>(Resource.Id.listView1);
            Lista_Total = FindViewById<ListView>(Resource.Id.listView2);
            Lista_Alimentos = FindViewById<ListView>(Resource.Id.listView3);
            Lista_Vestuario = FindViewById<ListView>(Resource.Id.listView4);
            Lista_Usohogar = FindViewById<ListView>(Resource.Id.listView5);

            Lista_A.Adapter = new AdapterAnios(this, ClassGlobal.Anios);
            Lista_Total.Adapter = new Promedio_Total(this, ClassGlobal.Anios);
            Lista_Alimentos.Adapter = new Promedio_Alimentos(this, ClassGlobal.Anios);
            Lista_Vestuario.Adapter = new Promedio_Vestuario(this, ClassGlobal.Anios);
            Lista_Usohogar.Adapter = new Promedio_UsoHogar(this, ClassGlobal.Anios);

            Lista_A.ItemClick += Lista_A_ItemClick;
        }

        private void Lista_A_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityDetalleAnio));

            Anios anios = ClassGlobal.Anios[e.Position];
            i.PutExtra("id", anios.Id);
            StartActivity(i);
        }
    }
}