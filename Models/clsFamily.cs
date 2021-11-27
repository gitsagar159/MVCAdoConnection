using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVCAdoConnection.ViewModels;

namespace MVCAdoConnection.Models
{
    public class clsFamily : clsBaseClass
    {
        string strQuery = "";
        public void InsertFamliyMemberDetail()
        {
            clsFamilyMember objMemberEntity = new clsFamilyMember();
            objMemberEntity.membername = "Sagar";

            using (connection = Get_Connection())
            {
                strQuery = "INSERT INTO family(membername) VALUES(@membername) ;";
                strQuery += " SELECT SCOPE_IDENTITY()";

                using (SqlCommand cmd = new SqlCommand(strQuery))
                {
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@membername", objMemberEntity.membername);
                    objMemberEntity.memberid = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public List<clsFamilyMember> GetFamilyDetails()
        {
            List<clsFamilyMember> objMemberEntity = new List<clsFamilyMember>();

            using (connection = Get_Connection())
            {
                strQuery = "Select memberid, membername from family;";

                using (SqlCommand cmd = new SqlCommand(strQuery))
                {
                    cmd.Connection = connection;

                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        objMemberEntity.Add(
                            new clsFamilyMember
                            {
                                memberid = Convert.ToInt32(dr["memberid"]),
                                membername = Convert.ToString(dr["membername"])
                            }
                            );
                    }
                }

                return objMemberEntity;
            }

        }
    }
}