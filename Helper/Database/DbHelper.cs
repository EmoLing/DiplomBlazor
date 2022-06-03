using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Database
{
    public static class DbHelper
    {
        public static string GetTrueConnectionString(string connectionString, string baseDirection)
        {
            var partPath = baseDirection.Split('\\').ToList();
            int indexProjectName = partPath.IndexOf("Diplom");
            var newConnectionString = String.Empty;

            for (int i = 0; i <= indexProjectName; i++)
                newConnectionString += partPath[i] + (i != indexProjectName ? '\\' : String.Empty);

            return connectionString.Replace("{AppDir}", newConnectionString);
        }
    }
}
