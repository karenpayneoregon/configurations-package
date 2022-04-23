using System;
using System.Threading.Tasks;
using ConfigurationLibrary.Classes;
using Microsoft.Data.SqlClient;

namespace ShadowPropertiesUnitTestProject.Base
{
    public class DataProviderOperations
    {
        public static async Task<bool> CanConnect()
        {
            await using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
            await using var cmd = new SqlCommand(){Connection = cn};
            cmd.CommandText = "SELECT ContactId, FirstName, LastName FROM dbo.Contact1;";
            try
            {
                await cn.OpenAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
