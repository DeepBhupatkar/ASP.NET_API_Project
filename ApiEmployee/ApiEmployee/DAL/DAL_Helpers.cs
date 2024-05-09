using System;
namespace ApiEmployee.DAL
{
    public class DAL_Helpers
    {
        public static string ConnString = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").
            Build().GetConnectionString("ConnectionString");
    }
}

