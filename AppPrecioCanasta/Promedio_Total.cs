﻿using Android.App;
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
    class Promedio_Total : BaseAdapter
    {
        Activity context;
        List<Anios> lista;

        public Promedio_Total(Activity context, List<Anios> lista)
        {
            this.context = context;
            this.lista = lista;
        }

        public override int Count => lista.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = lista[position];
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = "C$" + ClassGlobal.Meses.Where(x => x.Id_anio == item.Id).Average(x => x.Total).ToString("0");
            return view;
        }
    }
}