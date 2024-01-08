using OkulApp.MODEL;
using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using OkulApp.DAL;
using System.Security.Cryptography;

namespace OkulApp.BLL
{
    public class OgrenciBL
    {
        Helper helperInstance; //helper sınıfından örnek bir nesne tanımlanır
        static readonly object lockObject = new object(); //güvenli erişim sağlar

        // Singleton tasarım deseni ile bir sınıftan yalnızca bir nesne üretme ve diğer sınıfların erişimini sağlama.
        Helper HelperInstance //property 
        {
            get
            {
                if (helperInstance == null)
                {
                    lock (lockObject)
                    {
                        // Eşzamanlı erişime kapatılmış kod bloğu
                        // Sadece bir iş parçacığı bu bloğa girebilir.
                        // Diğer iş parçacıkları bu bloğa girene kadar bekler.
                        if (helperInstance == null)
                        {
                            helperInstance = new Helper();
                        }
                    }
                }
                return helperInstance;
            }
        }

        public bool OgrenciKaydet(Ogrenci ogr)
        {
            try
            {
                var p = new SqlParameter[] {
                new SqlParameter("@Ad",ogr.Ad),
                new SqlParameter("@Soyad",ogr.Soyad),
                new SqlParameter("@Numara",ogr.Numara)
                };
                return HelperInstance.ExecuteNonQuery("Insert into tblOgrenciler values(@Ad,@Soyad,@Numara)", p) > 0; //sorgu sonucu etkilenen satır sayısı 0 dan büyükse true döner
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Veritabanı Hatası: " + sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bilinmeyen Hata: " + ex.Message);
                throw;
            }

        }

        public Ogrenci OgrenciBul(string numara)
        {
            try
            {
                SqlParameter[] p = { new SqlParameter("@Numara", numara) };
                var dr = HelperInstance.ExecuteReader("Select Ogrenciid, Ad, Soyad, Numara from tblOgrenciler where Numara=@Numara", p);

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
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Veritabanı Hatası: " + sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bilinmeyen Hata: " + ex.Message);
                throw;
            }

        }

        public bool OgrenciSil(int id)
        {
            try
            {
                SqlParameter[] p = { new SqlParameter("@Id", id) };
                return HelperInstance.ExecuteNonQuery("Delete from tblOgrenciler where Ogrenciid=@Id", p) > 0;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Veritabanı Hatası: " + sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bilinmeyen Hata: " + ex.Message);
                throw;
            }

        }

        public bool OgrenciGuncelle(Ogrenci ogr)
        {
            try
            {
                SqlParameter[] p = {new SqlParameter("Ad", ogr.Ad),
                new SqlParameter("Soyad", ogr.Soyad),
                new SqlParameter("Numara", ogr.Numara),
                new SqlParameter("Ogrenciid", ogr.Ogrenciid)};

                return HelperInstance.ExecuteNonQuery("Update tblOgrenciler set Ad=@Ad, Soyad=@Soyad, Numara=@Numara where Ogrenciid=@Ogrenciid", p) > 0;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Veritabanı Hatası: " + sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bilinmeyen Hata: " + ex.Message);
                throw;
            }

        }
    }
}
