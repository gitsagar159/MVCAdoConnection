using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCAdoConnection.Models
{
    public class clsBaseClass
    {
        private bool connection_open;
        protected SqlConnection connection;

        protected SqlConnection Get_Connection()
        {
            connection_open = false;
            connection = new SqlConnection();

            connection.ConnectionString = ConfigurationManager.ConnectionStrings["ado_donnect"].ConnectionString;

            if(IsConnection_Open())
            {
                connection_open = true;
                return connection;
            }
            else
            {
                throw new Exception("Error in connection");
            }
        }


        private bool IsConnection_Open()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}