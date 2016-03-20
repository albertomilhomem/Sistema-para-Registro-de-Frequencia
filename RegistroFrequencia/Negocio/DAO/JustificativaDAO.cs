using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Model;
using System.Data.SqlClient;

namespace Negocio.DAO
{
    public class JustificativaDAO
    {
        public void Salvar(Justificativa objJustificativa)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "insert into Justificativas(complemento, comprovante, motivo, inicioPeriodo, fimPeriodo, idFuncionario) values(@complemento, @comprovante, @motivo, @inicioPeriodo, @fimPeriodo, @idFuncionario)";
            comando.Parameters.AddWithValue("@complemento", objJustificativa.Complemento);
            comando.Parameters.AddWithValue("@comprovante", objJustificativa.Comprovante);
            comando.Parameters.AddWithValue("@motivo", objJustificativa.Motivo);
            comando.Parameters.AddWithValue("@inicioPeriodo", objJustificativa.InicioPeriodo);
            comando.Parameters.AddWithValue("@fimPeriodo", objJustificativa.FimPeriodo);
            comando.Parameters.AddWithValue("@idFuncionario", objJustificativa.Funcionario.Id);

            Conexao.CRUD(comando);
        }
        public void Alterar(Justificativa objJustificativa)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "update Justificativas set complemento=@complemento, comprovante=@comprovante, motivo=@motivo, inicioPeriodo=@inicioPeriodo, fimPeriodo=@fimPeriodo, idFuncionario=@idFuncionario where idJustificativa=@id";
            comando.Parameters.AddWithValue("@complemento", objJustificativa.Complemento);
            comando.Parameters.AddWithValue("@comprovante", objJustificativa.Comprovante);
            comando.Parameters.AddWithValue("@motivo", objJustificativa.Motivo);
            comando.Parameters.AddWithValue("@inicioPeriodo", objJustificativa.InicioPeriodo);
            comando.Parameters.AddWithValue("@fimPeriodo", objJustificativa.FimPeriodo);
            comando.Parameters.AddWithValue("@id", objJustificativa.Id);
            comando.Parameters.AddWithValue("@idFuncionario", objJustificativa.Funcionario.Id);

            Conexao.CRUD(comando);
        }
        public void AlterarEstado(Justificativa objJustificativa)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "update Justificativas set autorizacao=@autorizacao, idResponsavel=@idResponsavel  where idJustificativa=@id";
            comando.Parameters.AddWithValue("@autorizacao", objJustificativa.Aprovacao);
            comando.Parameters.AddWithValue("@id", objJustificativa.Id);
            comando.Parameters.AddWithValue("@idResponsavel", objJustificativa.Responsavel.Id);

            Conexao.CRUD(comando);
        }
        public IList<Justificativa> BuscarTodosPendentes(Funcionario objFuncionario)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select idJustificativa, inicioPeriodo, fimPeriodo, complemento, comprovante, motivo, autorizacao, Justificativas.idFuncionario, Justificativas.idResponsavel from Justificativas, Funcionarios, Setores where autorizacao='false' and Justificativas.idFuncionario = Funcionarios.idFuncionario and Funcionarios.idSetor = Setores.idSetor and Setores.idSetor = @idSetor";
            comando.Parameters.AddWithValue("@idSetor", objFuncionario.Setor.Id);

            SqlDataReader dr = Conexao.Selecionar(comando);
            IList<Justificativa> listaJustificativa = new List<Justificativa>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Justificativa objJustificativa = new Justificativa();
                    objJustificativa.Id = (int)dr["idJustificativa"];
                    objJustificativa.Complemento = (string)dr["complemento"];
                    objJustificativa.Comprovante = (byte[])dr["comprovante"];
                    objJustificativa.InicioPeriodo = (DateTime)dr["inicioPeriodo"];
                    objJustificativa.FimPeriodo = (DateTime)dr["fimPeriodo"];
                    objJustificativa.Motivo = (Motivo)Enum.Parse((typeof(Motivo)), dr["motivo"].ToString());
                    objJustificativa.Aprovacao = (bool)dr["autorizacao"];
                    objJustificativa.Funcionario = new FuncionarioDAO().BuscarPorId((int)dr["idFuncionario"]);

                    if (dr["idResponsavel"] != DBNull.Value)
                    {
                        objJustificativa.Responsavel = new FuncionarioDAO().BuscarPorId((int)dr["idFuncionario"]);
                    }
                    else
                    {
                        objJustificativa.Responsavel = null;
                    }

                    listaJustificativa.Add(objJustificativa);
                }
            }

            return listaJustificativa;
        }
        public IList<Justificativa> BuscarTodosAutorizados(Funcionario objFuncionario)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select idJustificativa, inicioPeriodo, fimPeriodo, complemento, comprovante, motivo, autorizacao, Justificativas.idFuncionario, Justificativas.idResponsavel from Justificativas, Funcionarios, Setores where autorizacao='true' and Justificativas.idFuncionario = Funcionarios.idFuncionario and Funcionarios.idSetor = Setores.idSetor and Setores.idSetor = @idSetor";
            comando.Parameters.AddWithValue("@idSetor", objFuncionario.Setor.Id);

            SqlDataReader dr = Conexao.Selecionar(comando);
            IList<Justificativa> listaJustificativa = new List<Justificativa>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Justificativa objJustificativa = new Justificativa();
                    objJustificativa.Id = (int)dr["idJustificativa"];
                    objJustificativa.Complemento = (string)dr["complemento"];
                    objJustificativa.Comprovante = (byte[])dr["comprovante"];
                    objJustificativa.InicioPeriodo = (DateTime)dr["inicioPeriodo"];
                    objJustificativa.FimPeriodo = (DateTime)dr["fimPeriodo"];
                    objJustificativa.Motivo = (Motivo)Enum.Parse((typeof(Motivo)), dr["motivo"].ToString());
                    objJustificativa.Aprovacao = (bool)dr["autorizacao"];
                    objJustificativa.Funcionario = new FuncionarioDAO().BuscarPorId((int)dr["idFuncionario"]);

                    if (dr["idResponsavel"] != DBNull.Value)
                    {
                        objJustificativa.Responsavel = new FuncionarioDAO().BuscarPorId((int)dr["idResponsavel"]);
                    }
                    else
                    {
                        objJustificativa.Responsavel = null;
                    }

                    listaJustificativa.Add(objJustificativa);
                }
            }

            return listaJustificativa;
        }
        public IList<Justificativa> BuscarTodosFuncionario(Funcionario objFuncionario)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from Justificativas where idFuncionario=@idFuncionario order by inicioPeriodo";
            comando.Parameters.AddWithValue("@idFuncionario", objFuncionario.Id);

            SqlDataReader dr = Conexao.Selecionar(comando);
            IList<Justificativa> listaJustificativa = new List<Justificativa>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Justificativa objJustificativa = new Justificativa();
                    objJustificativa.Id = (int)dr["idJustificativa"];
                    objJustificativa.Complemento = (string)dr["complemento"];
                    objJustificativa.Comprovante = (byte[])dr["comprovante"];
                    objJustificativa.InicioPeriodo = (DateTime)dr["inicioPeriodo"];
                    objJustificativa.FimPeriodo = (DateTime)dr["fimPeriodo"];
                    objJustificativa.Motivo = (Motivo)Enum.Parse((typeof(Motivo)), dr["motivo"].ToString());
                    objJustificativa.Aprovacao = (bool)dr["autorizacao"];
                    objJustificativa.Funcionario = new FuncionarioDAO().BuscarPorId((int)dr["idFuncionario"]);

                    if (dr["idResponsavel"] != DBNull.Value)
                    {
                        objJustificativa.Responsavel = new FuncionarioDAO().BuscarPorId((int)dr["idResponsavel"]);
                    }
                    else
                    {
                        objJustificativa.Responsavel = null;
                    }

                    listaJustificativa.Add(objJustificativa);
                }
            }

            return listaJustificativa;
        }
        public Justificativa BuscarPorId(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from Justificativas where idJustificativa=@id";
            comando.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = Conexao.Selecionar(comando);
            Justificativa objJustificativa = new Justificativa();

            if (dr.Read())
            {
                objJustificativa.Id = (int)dr["idJustificativa"];
                objJustificativa.Complemento = (string)dr["complemento"];
                objJustificativa.Comprovante = (byte[])dr["comprovante"];
                objJustificativa.InicioPeriodo = (DateTime)dr["inicioPeriodo"];
                objJustificativa.FimPeriodo = (DateTime)dr["fimPeriodo"];
                objJustificativa.Motivo = (Motivo)Enum.Parse((typeof(Motivo)), dr["motivo"].ToString());
                objJustificativa.Aprovacao = (bool)dr["autorizacao"];
                objJustificativa.Funcionario = new FuncionarioDAO().BuscarPorId((int)dr["idFuncionario"]);

                if (dr["idResponsavel"] != DBNull.Value)
                {
                    objJustificativa.Responsavel = new FuncionarioDAO().BuscarPorId((int)dr["idFuncionario"]);
                }
                else
                {
                    objJustificativa.Responsavel = null;
                }
            }

            return objJustificativa;
        }
        public IList<Justificativa> BuscarPeriodo(Justificativa objJustificativa)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from Justificativas where inicioPeriodo=@inicioPeriodo and fimPeriodo=@fimPeriodo and idFuncionario=@idFuncionario";
            comando.Parameters.AddWithValue("@inicioPeriodo", objJustificativa.InicioPeriodo);
            comando.Parameters.AddWithValue("@fimPeriodo", objJustificativa.FimPeriodo);
            comando.Parameters.AddWithValue("@idFuncionario", objJustificativa.Funcionario.Id);
            SqlDataReader dr = Conexao.Selecionar(comando);

            IList<Justificativa> listaJustificativa = new List<Justificativa>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    objJustificativa = new Justificativa();
                    objJustificativa.Id = (int)dr["idJustificativa"];
                    objJustificativa.Complemento = (string)dr["complemento"];
                    objJustificativa.Comprovante = (byte[])dr["comprovante"];
                    objJustificativa.InicioPeriodo = (DateTime)dr["inicioPeriodo"];
                    objJustificativa.FimPeriodo = (DateTime)dr["fimPeriodo"];
                    objJustificativa.Motivo = (Motivo)Enum.Parse((typeof(Motivo)), dr["motivo"].ToString());
                    objJustificativa.Aprovacao = (bool)dr["autorizacao"];
                    objJustificativa.Funcionario = new FuncionarioDAO().BuscarPorId((int)dr["idFuncionario"]);

                    listaJustificativa.Add(objJustificativa);
                }
            }
            else
            {
                listaJustificativa = null;
            }

            return listaJustificativa;
        }
    }
}
