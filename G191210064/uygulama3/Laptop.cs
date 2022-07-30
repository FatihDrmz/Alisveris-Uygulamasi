using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uygulama3
{
    public class Laptop:Urun
    {
        //Laptopun özellikleri:
        public string EkranBoyutu = "15.6 inc";
        public string EkranCozunurlugu = "1920 x 1080";
        public string DahiliHafıza = "1 TB HDD + 256 GB SSD";
        public string RamKapasitesi = "16 GB";
        public string PilGucu ="5000 mAh";

        public Laptop(string _Ad, string _Marka, string _Model, string _Ozellik, double _HamFiyat, int _SecilenAdet)
        {
            Ad = _Ad;
            Marka = _Marka;
            Model = _Model;
            Ozellik = _Ozellik;
            HamFiyat = _HamFiyat;
            SecilenAdet = _SecilenAdet;
        }

        //Laptopun kdvli fiyatını bulmaya yarayan fonksiyon.
        public double KdvUygula()
        {
            return HamFiyat * 1.15 * SecilenAdet;
        }
    }
}
