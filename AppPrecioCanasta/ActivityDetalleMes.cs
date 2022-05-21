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
    [Activity(Label = "ActivityDetalleMes")]
    class ActivityDetalleMes : Activity
    {
        Meses meses;
        TextView Nombre;
        TextView Alimentos;
        TextView Uso_hogar;
        TextView Vestuario;
        TextView Total;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DetallesMes);
            int id = Intent.GetIntExtra("id", 0);
            meses = ClassGlobal.Meses.Where(x => x.Id == id).FirstOrDefault();

            Nombre = FindViewById<TextView>(Resource.Id.textView1);
            Alimentos = FindViewById<TextView>(Resource.Id.textView6);
            Uso_hogar = FindViewById<TextView>(Resource.Id.textView7);
            Vestuario = FindViewById<TextView>(Resource.Id.textView8);
            Total = FindViewById<TextView>(Resource.Id.textView9);

            Nombre.Text = meses.Nombre_mes;
            Alimentos.Text = meses.Vestuario.ToString();
            Uso_hogar.Text = meses.Alimentos.ToString();
            Vestuario.Text = meses.Uso_hogar.ToString();
            Total.Text = meses.Total.ToString();
        }

    }
}