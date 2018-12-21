using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FlightSchedule.Config.SimpleInjector
{
    public static class DbConnectionFactory
    {
        public static DbConnection Create()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

#if TEST
            connectionString = ReplaceSandbox(connectionString); 
#endif

            return new SqlConnection(connectionString);
        }

        private static string ReplaceSandbox(string connectionString)
        {
            if (HttpContext.Current.Request.Headers.AllKeys.Contains("SANDBOX_DB_NAME"))
            {
                connectionString = "X";
            }

            return connectionString;
        }
    }
}
