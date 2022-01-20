using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GoldenToolKit
{
    public class SQLConnect
    {

        public SqlConnection Connection { get;  set; }
        public SqlCommand Command { get;  set; }
        public SqlDataReader Reader { get; set; }
        public SQLConnect()
        {
        }


        public void ConnectionDB(string BaseName, string Server, string Port = "1433", string User = null, string Password = null)
        {
            Connection = new SqlConnection(BuildConnection(BaseName, Server, Port, User, Password));
            try
            {
                Connection.Open();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.ToString());
            }

        }
        public void DesconnectionDB(string BaseName, string Server, string Port = null, string User = null, string Password = null)
        {
            Connection = new SqlConnection(BuildConnection(BaseName, Server, Port, User, Password));
            try
            {
                Connection.Close();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.ToString());
            }

        }
        public void ExecCommandSP(SqlConnection connection,string SP, params SqlParameter[] parameters)
        {
            Command = new SqlCommand(SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            foreach (SqlParameter param in parameters)
            {
                Command.Parameters.AddWithValue(param.ParameterName,param.Value);
            }
            Command.ExecuteNonQuery();
        }
        public List<string> Read(SqlConnection connection, string SP,params SqlParameter[] parameters)
        {
            List<string> values = new List<string>();
            Command = new SqlCommand(SP, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            foreach (SqlParameter param in parameters)
            {
                Command.Parameters.AddWithValue(param.ParameterName, param.Value);
            }
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    values.Add(Reader[i].ToString());
                }
               
            }
            return values;
        }
        private static string BuildConnection(string BaseName, string Server, string Port, string User, string Password)
        {
            string cadena="";
            cadena += "Data Source=";
            cadena += Server + "\\MSSQLSERVER";
            cadena += !string.IsNullOrEmpty(Port) ? "," + Port + ";" : ";";
            cadena += "Initial Catalog=" + BaseName;
            if (string.IsNullOrEmpty(User) && string.IsNullOrEmpty(Password))
            {
                cadena += ";Integrated Security=True;Trusted_Connection=True";
            }
            else
            {
                cadena += $";Integrated Security=false;Persist Security Info=True;User ID={User};Password={Password};";
            }

            return cadena;
        }
    }
}
