using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uygulama3
{
    public class LedTv:Urun
    {
        //Led Tvnin özellikleri:
        public string EkranBoyutu = "65 inc";
        public string EkranCozunurlugu = "UHD";

        public LedTv(string _Ad, string _Marka, string _Model, string _Ozellik, double _HamFiyat, int _SecilenAdet)
        {
            Ad = _Ad;
            Marka = _Marka;
            Model = _Model;
            Ozellik = _Ozellik;
            HamFiyat = _HamFiyat;
            SecilenAdet = _SecilenAdet;
        }

        //Led TVnin kdvli fiyatını bulmaya yarayan fonksiyon.
        public double KdvUygula()
        {
            return HamFiyat * 1.18 * SecilenAdet;
        }
    }
}
