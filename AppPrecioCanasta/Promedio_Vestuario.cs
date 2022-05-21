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
    class Promedio_Vestuario : BaseAdapter
    {
        Activity context;
        List<Anios> vlista;

        public Promedio_Vestuario(Activity context, List<Anios> vlista)
        {
            this.context = context;
            this.vlista = vlista;
        }

        public override int Count => vlista.Count;

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
            var item = vlista[position];
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = "C$" + ClassGlobal.Meses.Where(x => x.Id_anio == item.Id).Average(x => x.Vestuario).ToString("0");
            return view;
        }
    }
}