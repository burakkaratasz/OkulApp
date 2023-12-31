﻿using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OkulApp.BLL;

namespace OkulAppSube2BIL
{
    public partial class frmOgrKayit : Form
    {
        public int Ogrenciid { get; set; }
        public frmOgrKayit()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                bool sonuc = obl.OgrenciKaydet(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim() });
                MessageBox.Show(sonuc ? "Ekleme Başarılı" : "Ekleme Başarısız!!");
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu numara daha önce kaydedilmiş");
                        break;
                    default:
                        MessageBox.Show("Veritabanı Hatası!");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw;
                MessageBox.Show("Bilinmeyen Hata!!");
            }

            txtAd.Text = "";
            txtSoyad.Text = "";
            txtNumara.Text = "";

        }

        private void frmOgrKayit_Load(object sender, EventArgs e)
        {

        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmOgrBul(this);
                frm.Show();
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Veritabanı Hatası: " + sqlEx.Message);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bilinmeyen Hata: " + ex.Message);
                
            }
        }

        public void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                MessageBox.Show(obl.OgrenciSil(Ogrenciid) ? "Silme Başarılı" : "Silme Başarısız!");

                txtAd.Text = "";
                txtSoyad.Text = "";
                txtNumara.Text = "";
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Veritabanı Hatası: " + sqlEx.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Bilinmeyen Hata: " + ex.Message);

            }

        }

        public void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                MessageBox.Show(obl.OgrenciGuncelle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim(), Ogrenciid = Ogrenciid })
                ? "Güncelleme Başarılı" : "Güncelleme Başarısız!");

                txtAd.Text = "";
                txtSoyad.Text = "";
                txtNumara.Text = "";
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Veritabanı Hatası: " + sqlEx.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Bilinmeyen Hata: " + ex.Message);

            }

        }
    }


    


}
