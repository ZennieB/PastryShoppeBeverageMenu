using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary.DataAccess
{
    //public static class SqlDataAccess
    //{
    //    public static string GetConnectionString()
    //    {
    //        return ConfigurationManager.ConnectionStrings["AllMadDB"].ConnectionString;
    //    }

    //    public static List<T> LoadData<T>(string sql)
    //    {
    //        using(IDbConnection conn = new SqlConnection(GetConnectionString()))
    //        {
    //            return conn.Query<T>(sql).ToList();
    //        }
    //    }

    //    public static int SaveData<T>(string sql, T data)
    //    {
    //        using (IDbConnection conn = new SqlConnection(GetConnectionString()))
    //        {
    //            return conn.Execute(sql, data);
    //        }
    //    }
    //}
}
