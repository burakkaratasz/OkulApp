using OkulApp.BLL;
using OkulApp.MODEL;
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

namespace OkulAppSube2BIL
{
    public partial class frmOgretmenSil : Form
    {
        public frmOgretmenSil()
        {
            InitializeComponent();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {     
               var obl = new OgretmenBL();
               bool sonuc = obl.OgretmenSil(new Ogretmen { OgretmenId = int.Parse(tbId.Text) });
               MessageBox.Show(sonuc ? "Silme Başarılı" : "Silme Başarısız!!");
                 
        }
    }
}
