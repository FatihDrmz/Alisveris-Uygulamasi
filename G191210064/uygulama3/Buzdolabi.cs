using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uygulama3
{
    public class Buzdolabi:Urun
    {
        //Buzdolabının özellikleri:
        public string IcHacim = "630 L";
        public string EnerjiSınıfı = "A++";

        public Buzdolabi(string _Ad, string _Marka, string _Model, string _Ozellik, double _HamFiyat, int _SecilenAdet)
        {
            Ad = _Ad;
            Marka = _Marka;
            Model = _Model;
            Ozellik = _Ozellik;
            HamFiyat = _HamFiyat;
            SecilenAdet = _SecilenAdet;
        }

        //Buzdolabının kdvli fiyatını bulmaya yarayan fonksiyon.
        public double KdvUygula()
        {
            return HamFiyat * 1.05 * SecilenAdet;
        }
    }
}
