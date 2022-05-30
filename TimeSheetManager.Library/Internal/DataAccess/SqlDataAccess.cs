using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace TimeSheetManager.Library.Internal.DataAccess
{
    public class SqlDataAccess
    {

        public string GetConnectionString(string name)
        {
          return ConfigurationManager.ConnectionStrings[name].ConnectionString;
          

         }
        public List<T> LoadData<T, U>(string storeProcedure, U parameters, string connectStringName)
        {
            string connectionString = GetConnectionString(connectStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> row= connection.Query<T>(storeProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
                return row;
            }
        
        }


        public void SaveData<T>(string storeProcedure, T parameters, string connectStringName)
        { 
           string connectionString= GetConnectionString(connectStringName);
           using (IDbConnection connection= new SqlConnection(connectionString))
           {
                connection.Execute(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
            
            }
        
        }

    }
}





//public void CommitTransaction();
//public void Dispose();


//public List<T> LoadDataInTransaction<T, U>(string storeProcedure, U parameters);
//public void RollbackTransaction();
//
//public void SaveDataInTransaction<T>(string storeProcedure, T parameters);
//public int SaveDataScalar<T>(string storedProcedure, T parameters, string connectionStringName);
//public int SaveDataScalarInTransaction<T>(string storedProcedure, T parameters);
//public void StartTransaction(string connectionStringName);