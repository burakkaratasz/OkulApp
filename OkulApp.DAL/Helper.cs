using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace OkulApp.DAL
{
    public class Helper : IDisposable
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;

        string cstr = ConfigurationManager.ConnectionStrings["cstr"].ConnectionString;
        bool disposed = false;

        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p = null)
        {
            try
            {
                using (cn = new SqlConnection(cstr))
                {
                    using (cmd = new SqlCommand(cmdtext, cn))
                    {
                        if (p != null)
                        {
                            cmd.Parameters.AddRange(p);
                        }
                        cn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
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
            finally
            {
                Dispose();
            }
        }

        public SqlDataReader ExecuteReader(string cmdtext, SqlParameter[] p = null)
        {
            cn = new SqlConnection(cstr);
            cmd = new SqlCommand(cmdtext, cn);
            if (p != null)
            {
                cmd.Parameters.AddRange(p);
            }
            cn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed) //daha önce dispose edilip edilmediğini kontrol eder
            {
                if (disposing) //true dönerse cn ve cmd nesnelerini dispose eder
                {
                    
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }

                    if (cn != null)
                    {
                        if (cn.State != ConnectionState.Closed)
                        {
                            cn.Close();
                        }
                        cn.Dispose();
                    }
                }

                disposed = true; //nesneler dispose edildikten sonra tekrar dispose edilmemesi için true değerine döndürülür. bellekten atıldığını belli eder.
            }
        }

        public void Dispose()
        {
            Dispose(true); 
            GC.SuppressFinalize(this); //finalizer metodunun çağrılmasını durdurur
        }
        
    }
}
