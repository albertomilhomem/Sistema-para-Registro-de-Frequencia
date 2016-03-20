using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Negocio.DAO
{
    public class Conexao
    {
        public static SqlConnection Conectar()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["bd_sisfreq"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }


        public static void CRUD(SqlCommand cmd)
        {
            cmd.Connection = Conectar();
            cmd.ExecuteNonQuery();
        }

        public static int CRUDRETORNO(SqlCommand cmd)
        {
            cmd.Connection = Conectar();
            return (int)cmd.ExecuteScalar();
        }

        public static SqlDataReader Selecionar(SqlCommand cmd)
        {
            cmd.Connection = Conectar();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
    }
}
