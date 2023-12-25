using OkulApp.DAL;
using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OkulApp.BLL
{
    public class OgretmenBL
    {
        public bool OgretmenKaydet(Ogretmen ogrt)
        {
            var hlp = new Helper();
            var p = new SqlParameter[] {
                new SqlParameter("@Ad",ogrt.Ad),
                new SqlParameter("@Soyad",ogrt.Soyad),
                new SqlParameter("@TcNo",ogrt.TcNo)
            };
            return hlp.ExecuteNonQuery("Insert into tblOgretmenler values(@Ad,@Soyad,@TcNo)", p) > 0;
        }

        public bool OgretmenSil(Ogretmen OgretmenId)
        {
            var hlp = new Helper();
            var p = new SqlParameter[]
            {
                new SqlParameter("@OgretmenId", OgretmenId)
            };
            return hlp.ExecuteNonQuery("Delete FROM tblOgretmenler WHERE OgretmenId = @OgretmenId", p) > 0;
        }
    }
}
