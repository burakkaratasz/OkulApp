using OkulApp.MODEL;
using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using OkulApp.DAL;

namespace OkulApp.BLL
{
    public class OgrenciBL
    {
        public bool OgrenciKaydet(Ogrenci ogr)
        {
            var hlp = new Helper();
            var p = new SqlParameter[] {
                new SqlParameter("@Ad",ogr.Ad),
                new SqlParameter("@Soyad",ogr.Soyad),
                new SqlParameter("@Numara",ogr.Numara)
            };
            return hlp.ExecuteNonQuery("Insert into tblOgrenciler values(@Ad,@Soyad,@Numara)", p) > 0;
        }

        public Ogrenci OgrenciBul(string numara)
        {
            var hlp = new Helper();
            SqlParameter[] p = { new SqlParameter("@Numara", numara)};
            var dr = hlp.ExecuteReader("Select Ogrenciid, Ad, Soyad, Numara from tblOgrenciler where Numara=@Numara", p);

            Ogrenci ogr = null;
            if (dr.Read())
            {
                ogr = new Ogrenci();
                ogr.Ad = dr["Ad"].ToString();
                ogr.Soyad = dr["Soyad"].ToString();
                ogr.Numara = dr["Numara"].ToString();
                ogr.Ogrenciid = Convert.ToInt32(dr["Ogrenciid"]);
            }
            dr.Close();
            return ogr;

        }

        public bool OgrenciSil(int id)
        {
            SqlParameter[] p = { new SqlParameter("@Id", id) };
            Helper hlp = new Helper();
            return hlp.ExecuteNonQuery("Delete from tblOgrenciler where Ogrenciid=@Id", p) > 0;
        }

        public bool OgrenciGuncelle(Ogrenci ogr)
        {
            SqlParameter[] p = {new SqlParameter("Ad", ogr.Ad),
            new SqlParameter("Soyad", ogr.Soyad),
            new SqlParameter("Numara", ogr.Numara),
            new SqlParameter("Ogrenciid", ogr.Ogrenciid)};

            Helper hlp = new Helper();
            return hlp.ExecuteNonQuery("Update tblOgrenciler set Ad=@Ad, Soyad=@Soyad, Numara=@Numara where Ogrenciid=@Ogrenciid", p) > 0;
        }
    }
}
