using System;
using System.Data.Odbc;

namespace KoUtilities.Database
{
    class DBConnection
    {
        private static OdbcConnection DbConnection;

        public static OdbcConnection getConnection()
        {
            if (DbConnection == null)
            {
                DbConnection = new OdbcConnection("DSN=PrefSuite");
            }
            return DbConnection;
        }

        public static void close()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DbConnection.Close();
            }
        }
    }
}
