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
    [Activity (Label="ActivityDetalleAnio")]
    public class ActivityDetalleAnio : Activity
    {
        Anios anios;
        TextView Nombre;
        ListView anioslista;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DetalleAnio);

            int id = Intent.GetIntExtra("id", 0);
            anios = ClassGlobal.Anios.Where(x => x.Id == id).FirstOrDefault();

            Nombre = FindViewById<TextView>(Resource.Id.textView1);
            anioslista = FindViewById<ListView>(Resource.Id.listView1);

            Nombre.Text = anios.Anio.ToString();
            anioslista.Adapter = new AdapterMeses(this, ClassGlobal.Meses.Where(x => x.Id_anio == anios.Id).ToList());
            anioslista.ItemClick += Anioslista_ItemClick;
        }

        private void Anioslista_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityDetalleMes));
            Meses meses = ClassGlobal.Meses[e.Position];
            i.PutExtra("id", meses.Id);
            StartActivity(i);
        }
    }
}