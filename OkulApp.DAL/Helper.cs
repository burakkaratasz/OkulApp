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
        bool disposed = false; //dispose metodunu birden fazla çağırmamak için kontrol nesnesi

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
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public SqlDataReader ExecuteReader(string cmdtext, SqlParameter[] p = null)
        {            
            try
            {
                cn = new SqlConnection(cstr);
                cmd = new SqlCommand(cmdtext, cn);
                if (p != null) //parametre olup olmadığını kontrol eder
                {
                    cmd.Parameters.AddRange(p);
                }
                cn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException sqlEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        protected virtual void Dispose(bool disposing) //miras alan sınıflar tarafından kullanılabilir ve override edilebilir.
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
            GC.SuppressFinalize(this); //finalizer metodunun çağrılmasını durdurur. garbage collector tarafından otomatik temizlenmesine gerek kalmaz.
        }
        
    }
}
