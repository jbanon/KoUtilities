using KoUtilities.Database.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace KoUtilities.ZIP
{
    class ZipFacade
    {

        static string path = @"C:\RolaTemp\zip\";

        public static void decompress(string zipPath, string extractPath)
        {
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }

        public static void compress(string startPath, string zipPath)
        {
            ZipFile.CreateFromDirectory(startPath, zipPath);
        }

        public static void test()
        {
            string extractPath = @"C:\RolaTemp\zip\extract";
            string newFile = @"C:\RolaTemp\zip\NewFile.txt";

            using (ZipArchive archive = ZipFile.Open(path, ZipArchiveMode.Update))
            {
                archive.CreateEntryFromFile(newFile, "NewEntry.txt");
                archive.ExtractToDirectory(extractPath);
            }
        }

        public static void test2()
        {
            string extractPath = @"C:\RolaTemp\zip\extract";

            using (ZipArchive archive = ZipFile.Open(path, ZipArchiveMode.Update))
            {
                archive.ExtractToDirectory(extractPath);
                
            }
        }

        public static void createPackage(int numero, int version, Dictionary<string, ZZ_Rolap_DatosPAF> dModels)
        {
            try
            {
                // Creamos temporales en un directorio
                string dirPath = path + "PAF" + numero + "_v" + version;

                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);

                DirectoryInfo di = Directory.CreateDirectory(dirPath);

                foreach (var model in dModels)
                {
                    StreamWriter myFile = new StreamWriter(dirPath + "\\" + model.Key);
                    myFile.WriteLine(model.Value.XMLDescriptive);
                    myFile.Close();
                }

                // Comprimimos
                if (File.Exists(dirPath + ".zip"))
                    File.Delete(dirPath + ".zip");
                ZipFile.CreateFromDirectory(dirPath, dirPath + ".zip");

                // Borramos temporales
                di.Delete(true);
  
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
