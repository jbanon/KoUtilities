using KoUtilities.Database;
using KoUtilities.Database.Model;
using KoUtilities.ZIP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoUtilities
{
    public partial class Form1 : Form
    {
        DBFacade dbFacade;

        public Form1()
        {
            InitializeComponent();

            // Rellenar campos
            populateCB1();

            

        }

        private void populateCB1()
        {
            List<string> pafKeys = new List<string>();
            dbFacade = new DBFacade();
            Dictionary<string, ZZ_Rolap_DatosPAF> dModels = dbFacade.GetCompleteInfoModels(-1, 1, true);

            foreach (var item in dModels)
            {              
                string key = item.Value.numero;
                if (item.Value.cliente != "XX") 
                    key = key + " - " + item.Value.cliente;
                if (!pafKeys.Contains(key))
                {
                    pafKeys.Add(key);
                }
            }

            var bindingSource = new BindingSource();
            bindingSource.DataSource = pafKeys;

            Rola_Pres_cb1.DataSource = bindingSource.DataSource;
        }

        private void populateCB2(int n)
        {
            List<string> pafKeys = new List<string>();
            dbFacade = new DBFacade();
            List<string> lVersions = dbFacade.GetVersionsByNumber(n);

            var bindingSource = new BindingSource();
            bindingSource.DataSource = lVersions;

            Rola_version_cb2.DataSource = bindingSource.DataSource;

            //Rola_version_cb2.DisplayMember = "numero";
            // Rola_version_cb2.ValueMember = "nombreVersion";
        }


        private void buttonAceptar_Click(object sender, EventArgs e)
        {            
            string s = Rola_Pres_cb1.SelectedItem.ToString();
            
            int n;
            if (s.Contains(" - "))                                       // Numero
            {
                n = int.Parse(s.Substring(0, s.IndexOf(" - ")));
            } 
            else
            {
                n = int.Parse(s);
            }
            
            int v;                                                       // Version
            s = Rola_version_cb2.SelectedItem.ToString();
            if (s.Contains(" - "))
            {
                v = int.Parse(s.Substring(0, s.IndexOf(" - ")));
            }
            else
            {
                v = int.Parse(s);
            }

            dbFacade = new DBFacade();
            Dictionary<string, ZZ_Rolap_DatosPAF> dModels = dbFacade.GetCompleteInfoModels(n, v, false);
            ZipFacade.createPackage(n, v, dModels);
        }

        private void Rola_Pres_cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = Rola_Pres_cb1.SelectedItem.ToString();
            int n;
            if (s.Contains(" - "))
            {
                n = int.Parse(s.Substring(0, s.IndexOf(" - ")));
            }
            else
            {
                n = int.Parse(s);
            }
            populateCB2(n);
        }

    }
}
