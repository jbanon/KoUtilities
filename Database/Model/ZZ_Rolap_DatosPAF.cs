using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoUtilities.Database.Model
{
    class ZZ_Rolap_DatosPAF
    {
        public string numero { get; set; }
        public string version { get; set; }
        public string orden { get; set; }
        public string cantidad { get; set; }
        public string nomenclatura { get; set; }
        public string XMLDescriptive { get; set; }
        public string cliente { get; set; }
        public string nombreVersion { get; set; }

        public string getIndice()
        {
            try
            {
                return string.Format("{0}_{1}_{2}_{3}_{4}_{5}.xml", numero, version, orden, cantidad, nomenclatura, cliente);
            }
            catch (Exception)
            {

            } 
            return null;            
        }
    }
}
