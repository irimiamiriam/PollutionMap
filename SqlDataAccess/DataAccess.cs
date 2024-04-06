using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollutionMap.SqlDataAccess
{
    public class DataAccess
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
        public static string GetHartiPath() 
        {
            return ConfigurationManager.AppSettings["HartiPath"];

        }
        public static string GetMasurariPath()
        {
            return ConfigurationManager.AppSettings["MasurariPath"];

        }
    }

}
