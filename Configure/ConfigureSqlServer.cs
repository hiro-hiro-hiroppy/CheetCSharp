using System.Text;

namespace Configure
{
    public class ConfigureSqlServer
    {

        public static string DefineConnectionInfo()
        {
            StringBuilder sbConfig = new StringBuilder();
            sbConfig.Append(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test123;Integrated Security=True");
            // sbConfig.Append("Port=5432;");
            // sbConfig.Append("Username=postgres_user;");
            // sbConfig.Append("Password=password;");
            // sbConfig.Append("Database=test;");

            return sbConfig.ToString();
        }
    }
}
