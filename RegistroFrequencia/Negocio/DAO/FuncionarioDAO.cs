using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Negocio.Model;

namespace Negocio.DAO
{
    public class FuncionarioDAO
    {
        public void Salvar(Funcionario objFuncionario)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "insert into Funcionarios(cpf, dataAdmissao, dataNascimento, email, matricula, nome, senha, idSetor, idCargo, administrador) values(@cpf,@dataAdmissao,@dataNascimento,@email,@matricula,@nome,@senha, @idSetor, @idCargo, @administrador)";
            comando.Parameters.AddWithValue("@cpf", objFuncionario.Cpf);
            comando.Parameters.AddWithValue("@dataAdmissao", objFuncionario.DataAdmissao);
            comando.Parameters.AddWithValue("@dataNascimento", objFuncionario.DataNascimento);
            comando.Parameters.AddWithValue("@email", objFuncionario.Email);
            comando.Parameters.AddWithValue("@matricula", objFuncionario.Matricula);
            comando.Parameters.AddWithValue("@nome", objFuncionario.Nome);
            comando.Parameters.AddWithValue("@senha", objFuncionario.Senha);
            comando.Parameters.AddWithValue("@idSetor", objFuncionario.Setor.Id);
            comando.Parameters.AddWithValue("@idCargo", objFuncionario.Cargo.Id);
            comando.Parameters.AddWithValue("@administrador", objFuncionario.Administrador);

            Conexao.CRUD(comando);
        }
        public void Alterar(Funcionario objFuncionario)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "update Funcionarios set cpf=@cpf, dataAdmissao=@dataAdmissao, dataNascimento=@dataNascimento, email=@email, matricula=@matricula, nome=@nome, idSetor=@idSetor, idCargo=@idCargo, administrador=@administrador where idFuncionario=@id";
            comando.Parameters.AddWithValue("@cpf", objFuncionario.Cpf);
            comando.Parameters.AddWithValue("@dataAdmissao", objFuncionario.DataAdmissao);
            comando.Parameters.AddWithValue("@dataNascimento", objFuncionario.DataNascimento);
            comando.Parameters.AddWithValue("@email", objFuncionario.Email);
            comando.Parameters.AddWithValue("@matricula", objFuncionario.Matricula);
            comando.Parameters.AddWithValue("@nome", objFuncionario.Nome);
            comando.Parameters.AddWithValue("@idSetor", objFuncionario.Setor.Id);
            comando.Parameters.AddWithValue("@idCargo", objFuncionario.Cargo.Id);
            comando.Parameters.AddWithValue("@id", objFuncionario.Id);
            comando.Parameters.AddWithValue("@administrador", objFuncionario.Administrador);

            Conexao.CRUD(comando);
        }
        public IList<Funcionario> BuscarTodos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from Funcionarios order by nome";
            SqlDataReader dr = Conexao.Selecionar(comando);
            IList<Funcionario> listaFuncionarios = new List<Funcionario>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Funcionario objFuncionario = new Funcionario(null);
                    objFuncionario.Id = (int)dr["idFuncionario"];
                    objFuncionario.Cpf = dr["cpf"].ToString();
                    objFuncionario.DataAdmissao = (DateTime)(dr["dataAdmissao"]);
                    objFuncionario.DataNascimento = (DateTime)(dr["dataNascimento"]);
                    objFuncionario.Email = dr["email"].ToString();
                    objFuncionario.Nome = dr["nome"].ToString();
                    objFuncionario.Matricula = dr["matricula"].ToString();
                    objFuncionario.Senha = dr["senha"].ToString();
                    objFuncionario.Administrador = (bool)dr["administrador"];

                    if (dr["idSetor"] != DBNull.Value)
                    {
                        objFuncionario.Setor = new SetorDAO().BuscarPorId((int)dr["idSetor"]);
                    }

                    if (dr["idCargo"] != DBNull.Value)
                    {
                        objFuncionario.Cargo = new CargoDAO().BuscarPorId((int)dr["idCargo"]);
                    }


                    listaFuncionarios.Add(objFuncionario);
                }
            }

            return listaFuncionarios;
        }
        public IList<Funcionario> BuscarTodosGerentes()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select f.idFuncionario, f.nome, f.cpf, f.dataAdmissao, f.dataNascimento, f.email, f.matricula, f.senha, f.idSetor, f.idCargo, f.administrador from funcionarios f, cargos c where f.idCargo = c.idCargo AND c.nome = 'GERENTE' order by f.nome";
            SqlDataReader dr = Conexao.Selecionar(comando);
            IList<Funcionario> listaFuncionarios = new List<Funcionario>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Funcionario objFuncionario = new Funcionario(null);
                    objFuncionario.Id = (int)dr["idFuncionario"];
                    objFuncionario.Cpf = dr["cpf"].ToString();
                    objFuncionario.DataAdmissao = (DateTime)(dr["dataAdmissao"]);
                    objFuncionario.DataNascimento = (DateTime)(dr["dataNascimento"]);
                    objFuncionario.Email = dr["email"].ToString();
                    objFuncionario.Nome = dr["nome"].ToString();
                    objFuncionario.Matricula = dr["matricula"].ToString();
                    objFuncionario.Senha = dr["senha"].ToString();
                    objFuncionario.ListaDeFrequencia = new FrequenciaDAO().BuscarTodasFuncionario((int)dr["idFuncionario"]);

                    objFuncionario.Administrador = (bool)dr["administrador"];

                    if (dr["idSetor"] != DBNull.Value)
                    {
                        objFuncionario.Setor = new SetorDAO().BuscarPorId((int)dr["idSetor"]);
                    }

                    if (dr["idCargo"] != DBNull.Value)
                    {
                        objFuncionario.Cargo = new CargoDAO().BuscarPorId((int)dr["idCargo"]);
                    }

                    listaFuncionarios.Add(objFuncionario);
                }
            }

            return listaFuncionarios;
        }
        public Funcionario BuscarPorId(int id, Setor objSetor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from funcionarios where idFuncionario=@id";
            comando.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = Conexao.Selecionar(comando);
            Funcionario objFuncionario = new Funcionario(null);

            if (dr.Read())
            {
                objFuncionario.Id = (int)dr["idFuncionario"];
                objFuncionario.Cpf = dr["cpf"].ToString();
                objFuncionario.DataAdmissao = (DateTime)(dr["dataAdmissao"]);
                objFuncionario.DataNascimento = (DateTime)(dr["dataNascimento"]);
                objFuncionario.Email = dr["email"].ToString();
                objFuncionario.Nome = dr["nome"].ToString();
                objFuncionario.Matricula = dr["matricula"].ToString();
                objFuncionario.Senha = dr["senha"].ToString();

                objFuncionario.Administrador = (bool)dr["administrador"];
                objFuncionario.Setor = objSetor;

                if (dr["idCargo"] != DBNull.Value)
                {
                    objFuncionario.Cargo = new CargoDAO().BuscarPorId((int)dr["idCargo"]);
                }
            }
            return objFuncionario;
        }
        public Funcionario BuscarPorId(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from funcionarios where idFuncionario=@idFuncionario";
            comando.Parameters.AddWithValue("@idFuncionario", id);

            SqlDataReader dr = Conexao.Selecionar(comando);
            Funcionario objFuncionario = new Funcionario(null);

            if (dr.Read())
            {
                objFuncionario.Id = (int)dr["idFuncionario"];
                objFuncionario.Cpf = dr["cpf"].ToString();
                objFuncionario.DataAdmissao = (DateTime)(dr["dataAdmissao"]);
                objFuncionario.DataNascimento = (DateTime)(dr["dataNascimento"]);
                objFuncionario.Email = dr["email"].ToString();
                objFuncionario.Nome = dr["nome"].ToString();
                objFuncionario.Matricula = dr["matricula"].ToString();
                objFuncionario.Administrador = (bool)dr["administrador"];
                objFuncionario.Senha = dr["senha"].ToString();

                if (dr["idSetor"] != DBNull.Value)
                {
                    objFuncionario.Setor = new SetorDAO().BuscarPorId((int)dr["idSetor"]);
                }

                if (dr["idCargo"] != DBNull.Value)
                {
                    objFuncionario.Cargo = new CargoDAO().BuscarPorId((int)dr["idCargo"]);
                }
            }
            return objFuncionario;
        }
        public Funcionario BuscarMatricula(int matricula)
        {

            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from funcionarios where matricula=@matricula";
            comando.Parameters.AddWithValue("@matricula", matricula);

            SqlDataReader dr = Conexao.Selecionar(comando);
            Funcionario objFuncionario = new Funcionario(null);
            if (dr.Read())
            {
                objFuncionario.Id = (int)dr["idFuncionario"];
                objFuncionario.Cpf = dr["cpf"].ToString();
                objFuncionario.DataAdmissao = (DateTime)(dr["dataAdmissao"]);
                objFuncionario.DataNascimento = (DateTime)(dr["dataNascimento"]);
                objFuncionario.Email = dr["email"].ToString();
                objFuncionario.Nome = dr["nome"].ToString();
                objFuncionario.Matricula = dr["matricula"].ToString();
                objFuncionario.Senha = dr["senha"].ToString();
                objFuncionario.Administrador = (bool)dr["administrador"];

                if (dr["idSetor"] != DBNull.Value)
                {
                    objFuncionario.Setor = new SetorDAO().BuscarPorId((int)dr["idSetor"]);
                }

                if (dr["idCargo"] != DBNull.Value)
                {
                    objFuncionario.Cargo = new CargoDAO().BuscarPorId((int)dr["idCargo"]);
                }
            }
            else
            {
                objFuncionario = null;
            }

            return objFuncionario;
        }
        public IList<Funcionario> Filtrar(string atributo, string valor)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = String.Format("select * from Funcionarios where {0} like '%{1}%' order by nome", atributo, valor);

            SqlDataReader dr = Conexao.Selecionar(comando);
            IList<Funcionario> listaFuncionarios = new List<Funcionario>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Funcionario objFuncionario = new Funcionario(null);
                    objFuncionario.Id = (int)dr["idFuncionario"];
                    objFuncionario.Cpf = dr["cpf"].ToString();
                    objFuncionario.DataAdmissao = (DateTime)(dr["dataAdmissao"]);
                    objFuncionario.DataNascimento = (DateTime)(dr["dataNascimento"]);
                    objFuncionario.Email = dr["email"].ToString();
                    objFuncionario.Nome = dr["nome"].ToString();
                    objFuncionario.Matricula = dr["matricula"].ToString();
                    objFuncionario.Senha = dr["senha"].ToString();
                    objFuncionario.Administrador = (bool) dr["administrador"];

                    if (dr["idSetor"] != DBNull.Value)
                    {
                        objFuncionario.Setor = new SetorDAO().BuscarPorId((int)dr["idSetor"]);
                    }

                    if (dr["idCargo"] != DBNull.Value)
                    {
                        objFuncionario.Cargo = new CargoDAO().BuscarPorId((int)dr["idCargo"]);
                    }

                    listaFuncionarios.Add(objFuncionario);
                }
            }

            return listaFuncionarios;

        }
        public void AlterarSenha(Funcionario objFuncionario)
        {

            SqlCommand comando = new SqlCommand();
            comando.CommandText = "update Funcionarios set senha=@senha where idFuncionario=@id";
            comando.Parameters.AddWithValue("@senha", objFuncionario.Senha);
            comando.Parameters.AddWithValue("@id", objFuncionario.Id);

            Conexao.CRUD(comando);
        }

        public IList<Funcionario> BuscarTodosRegional(Funcionario objFuncionario)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select f.idFuncionario, f.nome, f.cpf, f.dataAdmissao, f.dataNascimento, f.email, f.matricula, f.senha, f.idSetor, f.administrador, f.idCargo from funcionarios f, cargos c where f.idCargo = c.idCargo AND f.idSetor = @id order by f.nome";
            comando.Parameters.AddWithValue("@id", objFuncionario.Setor.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            IList<Funcionario> listaFuncionarios = new List<Funcionario>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    objFuncionario = new Funcionario(null);
                    objFuncionario.Id = (int)dr["idFuncionario"];
                    objFuncionario.Cpf = dr["cpf"].ToString();
                    objFuncionario.DataAdmissao = (DateTime)(dr["dataAdmissao"]);
                    objFuncionario.DataNascimento = (DateTime)(dr["dataNascimento"]);
                    objFuncionario.Email = dr["email"].ToString();
                    objFuncionario.Nome = dr["nome"].ToString();
                    objFuncionario.Matricula = dr["matricula"].ToString();
                    objFuncionario.Senha = dr["senha"].ToString();
                    objFuncionario.ListaDeFrequencia = new FrequenciaDAO().BuscarTodasFuncionario((int)dr["idFuncionario"]);
                    objFuncionario.Administrador = (bool)dr["administrador"];

                    if (dr["idSetor"] != DBNull.Value)
                    {
                        objFuncionario.Setor = new SetorDAO().BuscarPorId((int)dr["idSetor"]);
                    }

                    if (dr["idCargo"] != DBNull.Value)
                    {
                        objFuncionario.Cargo = new CargoDAO().BuscarPorId((int)dr["idCargo"]);
                    }

                    listaFuncionarios.Add(objFuncionario);
                }
            }

            return listaFuncionarios;

        }
        public IList<Funcionario> BuscarTodosRegionalSemGerente(Funcionario objFuncionario)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select f.idFuncionario, f.nome, f.cpf, f.dataAdmissao, f.dataNascimento, f.email, f.matricula, f.senha, f.idSetor, f.administrador, f.idCargo from funcionarios f, cargos c where f.idCargo = c.idCargo AND f.idSetor = @id AND c.nome <> 'GERENTE' order by f.nome";
            comando.Parameters.AddWithValue("@id", objFuncionario.Setor.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);
            IList<Funcionario> listaFuncionarios = new List<Funcionario>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    objFuncionario = new Funcionario(null);
                    objFuncionario.Id = (int)dr["idFuncionario"];
                    objFuncionario.Cpf = dr["cpf"].ToString();
                    objFuncionario.DataAdmissao = (DateTime)(dr["dataAdmissao"]);
                    objFuncionario.DataNascimento = (DateTime)(dr["dataNascimento"]);
                    objFuncionario.Email = dr["email"].ToString();
                    objFuncionario.Nome = dr["nome"].ToString();
                    objFuncionario.Matricula = dr["matricula"].ToString();
                    objFuncionario.Senha = dr["senha"].ToString();
                    objFuncionario.ListaDeFrequencia = new FrequenciaDAO().BuscarTodasFuncionario((int)dr["idFuncionario"]);
                    objFuncionario.Administrador = (bool)dr["administrador"];

                    if (dr["idSetor"] != DBNull.Value)
                    {
                        objFuncionario.Setor = new SetorDAO().BuscarPorId((int)dr["idSetor"]);
                    }

                    if (dr["idCargo"] != DBNull.Value)
                    {
                        objFuncionario.Cargo = new CargoDAO().BuscarPorId((int)dr["idCargo"]);
                    }

                    listaFuncionarios.Add(objFuncionario);
                }
            }

            return listaFuncionarios;

        }
    }
}
