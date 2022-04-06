using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using KoUtilities.Database.Model;
using Microsoft.Extensions.Logging;

namespace KoUtilities.Database
{
    class DBFacade
    {
        private readonly ILogger _logger;

        public void readVariables()
        {
            try
            {
                OdbcConnection dbConn = DBConnection.getConnection();
                _logger.LogInformation("");               
            }
            catch (Exception)
            {
            }
            finally
            {
                DBConnection.close();
            }
        }

        public string GetXMLModelfromDB(long Number, long Version, long orden, bool compress)
        {
            OdbcConnection dbConn = null;
            OdbcCommand cmd = null;
            string sql = null;

            if (compress)
            {
                sql = "SELECT XMlDescriptive from contenidopafblob where " +
                                "Numero = " + Number.ToString() + " AND Version = " + Version.ToString() + " AND Orden = " + orden.ToString();
            }
            else
            {
                sql = "SELECT Zlib.unzipxml(XMlDescriptive) from contenidopafblob where " +
                                "Numero = " + Number.ToString() + " AND Version = " + Version.ToString() + " AND Orden = " + orden.ToString();
            }

            try
            {
                dbConn = DBConnection.getConnection();
                cmd = new OdbcCommand(sql);

                string result = "";

                dbConn.Open();
                cmd.Connection = dbConn;
                System.Data.Odbc.OdbcDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    result = System.Convert.ToString(rd[0]);                    
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message + "," + ex.StackTrace);               
            }
            finally
            {
                DBConnection.close();
            }
            return null;
        }

        public Dictionary<string, string> GetXMLModelsfromDB(long Number, long Version, bool compress)
        {
            OdbcConnection dbConn = null;
            OdbcCommand cmd = null;
            string sql = null;

            if (compress)
            {
                sql = "SELECT XMlDescriptive, orden from contenidopafblob where " +
                                "Numero = " + Number.ToString() + " AND Version = " + Version.ToString() + " order by Orden";
            }
            else
            {
                sql = "SELECT Zlib.unzipxml(XMlDescriptive), orden from contenidopafblob where " +
                                "Numero = " + Number.ToString() + " AND Version = " + Version.ToString() + " order by Orden";
            }

            Dictionary<string, string> dModels = new Dictionary<string, string>();

            try
            {
                dbConn = DBConnection.getConnection();
                cmd = new OdbcCommand(sql);

                dbConn.Open();
                cmd.Connection = dbConn;
                System.Data.Odbc.OdbcDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    string result = rd.GetString(0);
                    int orden = rd.GetInt32(1);

                    string indice = string.Format("{0}_{1}_{2}.xml", Number, Version, orden);
                    dModels.Add(indice, result);
                }
                return dModels;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                DBConnection.close();
            }
            return null;
        }

        public Dictionary<string, ZZ_Rolap_DatosPAF> GetCompleteInfoModels(long Number, long Version, bool compress)
        {
            OdbcConnection dbConn = null;
            OdbcCommand cmd = null;
            string sql = null;
            if (Number > 0)
            {
                if (compress)
                {
                    sql = "SELECT Numero, Version, Orden, Cantidad, Nomenclatura, XMLDescriptive, cliente, NombreVersion from [ZZ-Rolap-DatosPAF] where " +
                                    "Numero = " + Number.ToString() + " AND Version = " + Version.ToString() + " order by Orden";
                }
                else
                {
                    sql = "SELECT Numero, Version, Orden, Cantidad, Nomenclatura, Zlib.unzipxml(XMLDescriptive), cliente, NombreVersion from [ZZ-Rolap-DatosPAF] where " +
                                    "Numero = " + Number.ToString() + " AND Version = " + Version.ToString() + " order by Orden";
                }
            } else
            {
                if (compress)
                {
                    sql = "SELECT Numero, Version, Orden, Cantidad, Nomenclatura, XMLDescriptive, cliente, NombreVersion from [ZZ-Rolap-DatosPAF] order by Orden";
                }
                else
                {
                    sql = "SELECT Numero, Version, Orden, Cantidad, Nomenclatura, Zlib.unzipxml(XMLDescriptive), cliente, NombreVersion from [ZZ-Rolap-DatosPAF] order by Orden";
                }
            }
 

            Dictionary<string, ZZ_Rolap_DatosPAF> dModels = new Dictionary<string, ZZ_Rolap_DatosPAF>();

            try
            {
                dbConn = DBConnection.getConnection();
                cmd = new OdbcCommand(sql);

                dbConn.Open();
                cmd.Connection = dbConn;
                System.Data.Odbc.OdbcDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    ZZ_Rolap_DatosPAF zz = new ZZ_Rolap_DatosPAF();
                    zz.numero = rd.IsDBNull(0) ? "NN" : rd[0].ToString();
                    zz.version = rd.IsDBNull(1) ? "NN" : rd[1].ToString();
                    zz.orden = rd.IsDBNull(2) ? "NN" : rd[2].ToString();
                    zz.cantidad = rd.IsDBNull(3) ? "NN" : rd[3].ToString();
                    zz.nomenclatura = rd.IsDBNull(4) ? "XX" : rd[4].ToString();
                    zz.XMLDescriptive = rd.IsDBNull(5) ? "XX" : rd[5].ToString();
                    zz.cliente = rd.IsDBNull(6) ? "XX" : rd[6].ToString();
                    zz.nombreVersion = rd.IsDBNull(7) ? "XX" : rd[7].ToString();

                    string indice = zz.getIndice();
                    dModels.Add(indice, zz);
                }
                return dModels;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                DBConnection.close();
            }
            return null;
        }


        public List<string> GetVersionsByNumber(long Number)
        {
            OdbcConnection dbConn = null;
            OdbcCommand cmd = null;
            string sql = null;
 
            sql = "SELECT Version,NombreVersion from [ZZ-Rolap-DatosPAF] where " +
                                    "Numero = " + Number.ToString() + " order by Version";

            List<string> lVersions = new List<string>();

            try
            {
                dbConn = DBConnection.getConnection();
                cmd = new OdbcCommand(sql);

                dbConn.Open();
                cmd.Connection = dbConn;
                System.Data.Odbc.OdbcDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    ZZ_Rolap_DatosPAF zz = new ZZ_Rolap_DatosPAF();
                    zz.version = rd.IsDBNull(0) ? "NN" : rd[0].ToString();
                    zz.nombreVersion = rd.IsDBNull(1) ? "XX" : rd[1].ToString();

                    string indice = zz.nombreVersion != "XX" ? zz.version + " - " + zz.nombreVersion : zz.version;
                    if (!lVersions.Contains(indice))
                        lVersions.Add(indice);
                }
                return lVersions;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                DBConnection.close();
            }
            return null;
        }


        public void saveToFile(int numero, int version, int orden, string dirPath, bool compress)
        {
            StreamWriter myFile = null;
            try
            {                
                string path = null;
                if (compress)
                {
                    path = string.Format(@"{0}\{1}_{2}_{3}.zip", dirPath, numero, version, orden);
                }
                else
                {
                    path = string.Format(@"{0}\{1}_{2}_{3}.xml", numero, version, orden);
                }

                myFile = new StreamWriter(path);
                myFile.WriteLine(GetXMLModelfromDB(numero, version, orden, compress));
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                myFile.Close();
            }
        }


        
    }
}
