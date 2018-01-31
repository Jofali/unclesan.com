using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace UncleSan.Models
{
    public class SqlHelper
    {
        private string server = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public int InsertUrl(string sName,string sLink,string sSlot)
        {
            int a;
            using (IDbConnection myconn = new SqlConnection(server))
            {
                myconn.Open();
                var result = myconn.Execute("INSERT INTO Url Values (@Name, @Link, @Slot)", new
                {
                    Name = sName,
                    Link = sLink,
                    Slot = sSlot
                });
                myconn.Close();
                a = result;
            }
            return a;
        }
        public IEnumerable<dynamic> GetUrl(string sort)
        {
            IEnumerable<dynamic> result;
            using (IDbConnection conn = new SqlConnection(server))
            {
                conn.Open();
                result = conn.Query("SELECT * FROM Url WHERE Slot=@Slot", new
                {
                    Slot = sort
                });
                conn.Close();
            }
            return result;
        }
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="Name">用户名</param>
        /// <returns></returns>
        public User GetLoginToken(string name)
        {
            using(IDbConnection conn = new SqlConnection(server))
            {
                conn.Open();
                var result = conn.Query<User>("SELECT * FROM Users WHERE Name=@Name", new
                {
                     Name = name
                });
                conn.Close();
                int a = result.Count();
                return result.FirstOrDefault();
            }
        }
    }
}