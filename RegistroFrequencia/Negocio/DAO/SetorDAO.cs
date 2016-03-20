using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Model;
using System.Data.SqlClient;

namespace Negocio.DAO
{
    public class SetorDAO
    {
        public void Salvar(Setor objSetor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "insert into setores(nome, telefone, idFuncionario) values(@nome, @telefone, @idFuncionario)";
            comando.Parameters.AddWithValue("@nome", objSetor.Nome);
            comando.Parameters.AddWithValue("@telefone", objSetor.Telefone);
            comando.Parameters.AddWithValue("@idFuncionario", objSetor.Funcionario.Id);

            Conexao.CRUD(comando);
        }
        public void Alterar(Setor objSetor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "update setores set nome=@nome, telefone=@telefone, idFuncionario=@idFuncionario where idSetor=@idSetor";
            comando.Parameters.AddWithValue("@nome", objSetor.Nome);
            comando.Parameters.AddWithValue("@telefone", objSetor.Telefone);
            comando.Parameters.AddWithValue("@idSetor", objSetor.Id);
            comando.Parameters.AddWithValue("@idFuncionario", objSetor.Funcionario.Id);

            Conexao.CRUD(comando);
        }
        public IList<Setor> BuscarTodos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from setores order by nome";

            SqlDataReader dr = Conexao.Selecionar(comando);
            IList<Setor> listaSetor = new List<Setor>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Setor objSetor = new Setor();

                    objSetor.Id = (int)dr["idSetor"];
                    objSetor.Nome = (string)dr["nome"];
                    objSetor.Telefone = (string)dr["telefone"];
                    if (dr["idFuncionario"] != DBNull.Value)
                    {
                        objSetor.Funcionario = new FuncionarioDAO().BuscarPorId((int)dr["idFuncionario"], objSetor);
                    }

                    listaSetor.Add(objSetor);
                }
            }

            return listaSetor;
        }
        public Setor BuscarPorId(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from setores where idSetor=@id";
            comando.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = Conexao.Selecionar(comando);
            Setor objSetor = new Setor();
            if (dr.Read())
            {
                objSetor.Id = (int)dr["idSetor"];
                objSetor.Nome = (string)dr["nome"];
                objSetor.Telefone = (string)dr["telefone"];

                if (dr["idFuncionario"] != DBNull.Value)
                {
                    objSetor.Funcionario = new FuncionarioDAO().BuscarPorId((int)dr["idFuncionario"], objSetor);                   
                }
            }

            return objSetor;

        }
        public IList<Setor> Filtrar(string atributo, string valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = String.Format("select * from setores where {0} like '%{1}%' order by nome", atributo, valor);

            SqlDataReader dr = Conexao.Selecionar(comando);
            IList<Setor> listaSetor = new List<Setor>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Setor objSetor = new Setor();

                    objSetor.Id = (int)dr["idSetor"];
                    objSetor.Nome = (string)dr["nome"];
                    objSetor.Telefone = (string)dr["telefone"];
                    if (dr["idFuncionario"] != DBNull.Value)
                    {
                        objSetor.Funcionario = new FuncionarioDAO().BuscarPorId((int)dr["idFuncionario"], objSetor);
                    }

                    listaSetor.Add(objSetor);
                }
            }

            return listaSetor;
        }

    }
}
