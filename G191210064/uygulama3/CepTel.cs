using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uygulama3
{
    public class CepTel:Urun
    {
        //Cep telefonunun özellikleri:
        public string DahiliHafıza = "64 GB";
        public string RamKapasitesi = "3 GB";
        public string PilGucu = "3400 mAh";
       
        public CepTel(string _Ad, string _Marka, string _Model, string _Ozellik, double _HamFiyat, int _SecilenAdet)
        {
            Ad = _Ad;
            Marka = _Marka;
            Model = _Model;
            Ozellik = _Ozellik;
            HamFiyat = _HamFiyat;
            SecilenAdet = _SecilenAdet;
        }
        
        //Cep telefonun kdvli fiyatını bulmaya yarayan fonksiyon.
        public double KdvUygula()
        {
            return HamFiyat * 1.20 * SecilenAdet;
        }
    }
}
