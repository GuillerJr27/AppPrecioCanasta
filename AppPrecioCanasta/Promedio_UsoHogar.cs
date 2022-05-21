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
    class Promedio_UsoHogar : BaseAdapter
    {
        Activity context;
        List<Anios> ulista;

        public Promedio_UsoHogar(Activity context, List<Anios> ulista)
        {
            this.context = context;
            this.ulista = ulista;
        }

        public override int Count => ulista.Count;

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
            var item = ulista[position];
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = "C$" + ClassGlobal.Meses.Where(x => x.Id_anio == item.Id).Average(x => x.Uso_hogar).ToString("0");
            return view;
        }
    }
}

