using System;
using System.Data.SqlClient;
using Dapper;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TODO_MVC.Helpers
{
    public class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = TODO MVC;");
        }
    }
}
