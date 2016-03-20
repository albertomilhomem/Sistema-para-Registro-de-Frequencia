using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Model;
using System.Data.SqlClient;

namespace Negocio.DAO
{
    public class CargoDAO
    {
        public void Salvar(Cargo objCargo)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "insert into Cargos(nome, cargaHoraria) values (@nome, @cargaHoraria)";
            comando.Parameters.AddWithValue("@nome", objCargo.Nome);
            comando.Parameters.AddWithValue("@cargaHoraria", objCargo.CargaHoraria);

            Conexao.CRUD(comando);
        }

        public void Alterar(Cargo objCargo)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "update Cargos set nome=@nome, cargaHoraria=@cargaHoraria where idCargo=@id";
            comando.Parameters.AddWithValue("@nome", objCargo.Nome);
            comando.Parameters.AddWithValue("@cargaHoraria", objCargo.CargaHoraria);
            comando.Parameters.AddWithValue("@id", objCargo.Id);

            Conexao.CRUD(comando);

        }
        public IList<Cargo> BuscarTodos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from Cargos order by nome";

            SqlDataReader dr = Conexao.Selecionar(comando);
            IList<Cargo> listaCargo = new List<Cargo>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cargo objCargo = new Cargo();
                    objCargo.Id = (int)dr["idCargo"];
                    objCargo.Nome = (string)dr["nome"];
                    objCargo.CargaHoraria = (TimeSpan)dr["cargaHoraria"];

                    listaCargo.Add(objCargo);
                }
            }

            return listaCargo;
        }

        public Cargo BuscarPorId(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from Cargos where idCargo=@id";
            comando.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = Conexao.Selecionar(comando);
            Cargo objCargo = new Cargo();

            if (dr.Read())
            {
                objCargo.Id = (int)dr["idCargo"];
                objCargo.Nome = (string)dr["nome"];
                objCargo.CargaHoraria = (TimeSpan)dr["cargaHoraria"];
            }

            return objCargo;
        }

        public IList<Cargo> Filtrar(string atributo, string valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = String.Format("select * from cargos where {0} like '%{1}%' order by nome", atributo, valor);

            SqlDataReader dr = Conexao.Selecionar(comando);
            IList<Cargo> listaCargo = new List<Cargo>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    Cargo objCargo = new Cargo();
                    objCargo.Id = (int)dr["idCargo"];
                    objCargo.Nome = (string)dr["nome"];
                    objCargo.CargaHoraria = (TimeSpan)dr["cargaHoraria"];

                    listaCargo.Add(objCargo);                                        
                }                
            }
            return listaCargo;
        }

        public IList<Cargo> BuscarTodosTecnicos()
        {

            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from Cargos where nome <> 'Gerente' order by nome";

            SqlDataReader dr = Conexao.Selecionar(comando);
            IList<Cargo> listaCargo = new List<Cargo>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cargo objCargo = new Cargo();
                    objCargo.Id = (int)dr["idCargo"];
                    objCargo.Nome = (string)dr["nome"];
                    objCargo.CargaHoraria = (TimeSpan)dr["cargaHoraria"];

                    listaCargo.Add(objCargo);
                }
            }

            return listaCargo;
        
        }
    }
}
