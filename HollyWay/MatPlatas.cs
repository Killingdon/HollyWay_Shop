using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollyWay
{
    internal class MatPlatas
    {
        public string FirmaName { get; set; }

        public int Price { get; set; }

        public int Cout {  get; set; }

        public MatPlatas(string _firmaname, int _price, int _cout)
        {
            FirmaName = _firmaname;
            Price = _price;
            Cout = _cout;
        }
        public MatPlatas()
        {
        }
    }
}
