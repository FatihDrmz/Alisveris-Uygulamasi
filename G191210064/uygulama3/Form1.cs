/****************************************************************************
**					      SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				      BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				     NESNEYE DAYALI PROGRAMLAMA DERSİ
**					     2019-2020 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........:3. ÖDEV
**				ÖĞRENCİ ADI............:FATİH DURMAZ
**				ÖĞRENCİ NUMARASI.......:G191210064
**              DERSİN ALINDIĞI GRUP...:2/B
****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uygulama3
{
    public partial class Form1 : Form
    {
        LedTv t1 = new LedTv("Samsung UE65RU7100UXTK 65 RU7100 4K UHD TV", "Samsung", "2019", "Pur color,HDR", 6000, 0);
        Buzdolabi b1 = new Buzdolabi("Beko 9630 Kex No-Frost Buz Dolabı", "Beko", "2018", "inox,No frost", 4500, 0);
        Laptop l1 = new Laptop("ASUS ROG Strix SCAR3 G531GW-ES010", "Asus", "2019", "9750H,2.6 GHz,Lithium-ion", 8000, 0);
        CepTel c1 = new CepTel("Huawei P Smart", "Huawei", "2019", "13 MP + 2 MP,160 g,IPS LCD", 2500, 0);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Bu kısımda eşyaların ham fiyat ve rastgele atanan stok adetlerinin ilgili labellara yazım işlemi gerçekleşir.

            Random rastgeleAdet = new Random();

            lblTvFiyat.Text = t1.HamFiyat.ToString();
            t1.StokAdedi = rastgeleAdet.Next(1, 100); 
            lblTvStok.Text = t1.StokAdedi.ToString();
            nudTvAdet.Maximum = t1.StokAdedi;
           
            lblBuzdolabiFiyat.Text = b1.HamFiyat.ToString(); 
            b1.StokAdedi = rastgeleAdet.Next(1, 100);
            lblBuzdolabiStok.Text = b1.StokAdedi.ToString();
            nudBuzdolabiAdet.Maximum = b1.StokAdedi;
            
            lblLaptopFiyat.Text = l1.HamFiyat.ToString();
            l1.StokAdedi = rastgeleAdet.Next(1, 100);
            lblLaptopStok.Text = l1.StokAdedi.ToString();
            nudLaptopAdet.Maximum = l1.StokAdedi;
            
            lblCeptelFiyat.Text = c1.HamFiyat.ToString();
            c1.StokAdedi = rastgeleAdet.Next(1, 100);
            lblCeptelStok.Text = c1.StokAdedi.ToString();  
            nudCepTelAdet.Maximum = c1.StokAdedi;
        }

        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            //Sepete ekle butonuna tıklayınca eğer sepet doluysa önce sepeti temizlenip sonrasında ürünleri sepete ekler.

            if (lstAdetListesi.Items.Count > 0) 
            {

                lstAdetListesi.Items.Clear();
                lstUrunListesi.Items.Clear();
                lstFiyatListesi.Items.Clear();
                lblKDVliToplam.Text = "0 TL";
 
                nudTvAdet.Value = 0;
                nudBuzdolabiAdet.Value = 0;
                nudLaptopAdet.Value = 0;
                nudCepTelAdet.Value = 0;

                MessageBox.Show("Siparişiniz başarıyla alınmıştır.", "Sipariş", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Seçilen adet sayısına göre eşyaların kendi kdvli fiyatlarını listboxa ve toplam kdvli fiyatı ilgili labela yazdırır.Ayrıca seçilen adedi stoktan düşer.

            if (nudTvAdet.Value > 0)
            {
                t1.SecilenAdet = Convert.ToInt32(nudTvAdet.Value);
                lstAdetListesi.Items.Add(t1.SecilenAdet);
                lstUrunListesi.Items.Add("Led TV");
                lstFiyatListesi.Items.Add(t1.KdvUygula());

                lblTvStok.Text = (Convert.ToInt32(lblTvStok.Text) - Convert.ToInt32(nudTvAdet.Value)).ToString();
            }
            if (nudBuzdolabiAdet.Value > 0)
            {
                b1.SecilenAdet = Convert.ToInt32(nudBuzdolabiAdet.Value);
                lstAdetListesi.Items.Add(b1.SecilenAdet);
                lstUrunListesi.Items.Add("Buzdolabı");
                lstFiyatListesi.Items.Add(b1.KdvUygula());

                lblBuzdolabiStok.Text = (Convert.ToInt32(lblBuzdolabiStok.Text) - Convert.ToInt32(nudBuzdolabiAdet.Value)).ToString();
            }
            if (nudLaptopAdet.Value > 0)
            {
                l1.SecilenAdet = Convert.ToInt32(nudLaptopAdet.Value);
                lstAdetListesi.Items.Add(l1.SecilenAdet);
                lstUrunListesi.Items.Add("Laptop");
                lstFiyatListesi.Items.Add(l1.KdvUygula());

                lblLaptopStok.Text = (Convert.ToInt32(lblLaptopStok.Text) - Convert.ToInt32(nudLaptopAdet.Value)).ToString();
            }
            if (nudCepTelAdet.Value > 0)
            {
                c1.SecilenAdet = Convert.ToInt32(nudCepTelAdet.Value);
                lstAdetListesi.Items.Add(c1.SecilenAdet);
                lstUrunListesi.Items.Add("Cep Telefonu");
                lstFiyatListesi.Items.Add(c1.KdvUygula());

                lblCeptelStok.Text = (Convert.ToInt32(lblCeptelStok.Text) - Convert.ToInt32(nudCepTelAdet.Value)).ToString();

                double sonuc = t1.KdvUygula() + b1.KdvUygula() + l1.KdvUygula() + c1.KdvUygula();
                lblKDVliToplam.Text = sonuc.ToString() + "TL";
            }
        }

        private void btnSepetiSil_Click(object sender, EventArgs e)
        {
            //Bu kısımda ise listboxtakiler temizlenir ve seçilen adedi stoğa geri ekler.

            lstAdetListesi.Items.Clear();
            lstUrunListesi.Items.Clear();
            lstFiyatListesi.Items.Clear();
            lblKDVliToplam.Text = "0 TL";

            lblTvStok.Text = (Convert.ToInt32(lblTvStok.Text) + Convert.ToInt32(nudTvAdet.Value)).ToString();
            lblBuzdolabiStok.Text = (Convert.ToInt32(lblBuzdolabiStok.Text) + Convert.ToInt32(nudBuzdolabiAdet.Value)).ToString();
            lblLaptopStok.Text = (Convert.ToInt32(lblLaptopStok.Text) + Convert.ToInt32(nudLaptopAdet.Value)).ToString();
            lblCeptelStok.Text = (Convert.ToInt32(lblCeptelStok.Text) + Convert.ToInt32(nudCepTelAdet.Value)).ToString();

            nudTvAdet.Value = 0;
            nudBuzdolabiAdet.Value = 0;
            nudLaptopAdet.Value = 0;
            nudCepTelAdet.Value = 0;
        }
    }
}
