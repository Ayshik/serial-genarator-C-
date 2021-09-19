using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serialdr
{
   public class DataAccess
    {
        SqlConnection con;
        public DataAccess()
        {
            con = new SqlConnection(@"Data Source=desktop-k8o6se7\mssqlserver02;Initial Catalog=Drserial;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public DataTable Drdetailsall(prop u)
        {
            string query = string.Format("Select * from info");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            // con.Close();
            return dt;
        }


        public int Drupdate(prop u)
        {
            int i = 0;
            string query = String.Format("UPDATE info SET Name='" + u.Name + "',Roomno='" + u.Room + "',Department='" + u.Catagory + "',Phone='" + u.PhoneNumber + "' WHERE Roomno='" + u.Room + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            return i;
        }
        public int DocReg(prop u)
        {
            int i = 0;
            string query = "INSERT INTO info(Name,Roomno,Department,Phone,Patient,Date) VALUES ('" + u.Name + "','" + u.Room + "','" + u.Catagory + "','" + u.PhoneNumber + "','" + u.Patient + "','" + DateTime.Now + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            //con.Close();
            return i;

        }
        public int Patientupdate(prop u)
        {
            int i = 0;
            string query = String.Format("UPDATE info SET Patient='" + u.Patient + "' WHERE Roomno='" + u.Room + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            return i;
        }
        public int Delete(prop u)
        {
            int i = 0;
            string query = String.Format("Delete from info where Roomno='" + u.Room + "'");
            SqlCommand cmd = new SqlCommand(query, con);
            i = cmd.ExecuteNonQuery();
            return i;
        }
    }
}
