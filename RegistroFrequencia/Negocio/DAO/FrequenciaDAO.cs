using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Model;
using System.Data.SqlClient;

namespace Negocio.DAO
{
    public class FrequenciaDAO
    {
        public void SalvarFrequencia(Frequencia objFrequencia, Funcionario objFuncionario)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "insert into Frequencias(dia, idFuncionario) values(@dia, @idFuncionario)";
            comando.Parameters.AddWithValue("@dia", objFrequencia.Dia);
            comando.Parameters.AddWithValue("@idFuncionario", objFuncionario.Id);

            Conexao.CRUD(comando);
        }

        public void AlterarEstado(Frequencia objFrequencia)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "update frequencias set estado=@estado, horasTrabalhadas=@horasTrabalhadas where idFrequencia=@id";
            comando.Parameters.AddWithValue("@estado", objFrequencia.EnumEstado);
            comando.Parameters.AddWithValue("@id", objFrequencia.Id);
            comando.Parameters.AddWithValue("@horasTrabalhadas", objFrequencia.HorasTrabalhadas);

            Conexao.CRUD(comando);
        }
        public Frequencia BuscarFrequenciaDia(Funcionario objFuncionario, DateTime data)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from Frequencias where idFuncionario=@idFuncionario and dia=@data";
            comando.Parameters.AddWithValue("@idFuncionario", objFuncionario.Id);
            comando.Parameters.AddWithValue("@data", data.ToShortDateString());

            SqlDataReader dr = Conexao.Selecionar(comando);

            Frequencia objFrequencia = new Frequencia();

            if (dr.Read())
            {
                objFrequencia.Id = (int)dr["idFrequencia"];
                objFrequencia.Dia = (DateTime)dr["dia"];
                objFrequencia.ListaPonto = new PontoDAO().BuscarTodosFrequencia((int)dr["idFrequencia"]);


                if (dr["horasTrabalhadas"] != DBNull.Value)
                {
                    objFrequencia.HorasTrabalhadas = TimeSpan.Parse(Convert.ToString(dr["horasTrabalhadas"]));
                }
                else
                {
                    objFrequencia.HorasTrabalhadas = null;
                }



                if (dr["estado"] != DBNull.Value)
                {
                    objFrequencia.EnumEstado = (Estado)Enum.Parse((typeof(Estado)), dr["estado"].ToString());
                }

                if (dr["idJustificativa"] != DBNull.Value)
                {
                    objFrequencia.Justificativa = new JustificativaDAO().BuscarPorId((int)dr["idJustificativa"]);
                }

            }
            else
            {
                objFrequencia = null;
            }

            return objFrequencia;
        }
        public IList<Frequencia> BuscarPeriodo(Funcionario objFuncionario, DateTime dataInicial, DateTime dataFinal)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from Frequencias where idFuncionario=@idFuncionario and dia between @dataInicial and @dataFinal order by dia";
            comando.Parameters.AddWithValue("@idFuncionario", objFuncionario.Id);
            comando.Parameters.AddWithValue("@dataInicial", dataInicial.ToShortDateString());
            comando.Parameters.AddWithValue("@dataFinal", dataFinal.ToShortDateString());

            SqlDataReader dr = Conexao.Selecionar(comando);
            IList<Frequencia> listaFrequencia = new List<Frequencia>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Frequencia objFrequencia = new Frequencia();
                    objFrequencia.Id = (int)dr["idFrequencia"];
                    objFrequencia.Dia = (DateTime)dr["dia"];
                    objFrequencia.ListaPonto = new PontoDAO().BuscarFrequencia((int) dr["idFrequencia"]);



                    if (dr["horasTrabalhadas"] != DBNull.Value)
                    {
                        objFrequencia.HorasTrabalhadas = TimeSpan.Parse(Convert.ToString(dr["horasTrabalhadas"]));                       
                    }
                    else
                    {
                        objFrequencia.HorasTrabalhadas = null;
                    }

                    if (dr["estado"] != DBNull.Value)
                    {
                        objFrequencia.EnumEstado = (Estado)Enum.Parse((typeof(Estado)), dr["estado"].ToString());
                    }
                    

                    if (dr["idFeriado"] != DBNull.Value)
                    {
                        objFrequencia.Feriado = new FeriadoDAO().BuscarId((int)dr["idFeriado"]);
                    }

                    if (dr["idJustificativa"] != DBNull.Value)
                    {
                        objFrequencia.Justificativa = new JustificativaDAO().BuscarPorId((int)dr["idJustificativa"]);
                    }

                    listaFrequencia.Add(objFrequencia);
                }
            }

            return listaFrequencia;
        }
        public void AlterarJustificativa(Justificativa objJustificativa)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "update Frequencias set idJustificativa=@idJustificativa, estado=3 where idFuncionario=@idFuncionario and (estado = 1 or estado = 2) and dia between @InicioPeriodo and @FimPeriodo ";
            comando.Parameters.AddWithValue("@idJustificativa", objJustificativa.Id);
            comando.Parameters.AddWithValue("@idFuncionario", objJustificativa.Funcionario.Id);
            comando.Parameters.AddWithValue("@InicioPeriodo", objJustificativa.InicioPeriodo);
            comando.Parameters.AddWithValue("@FimPeriodo", objJustificativa.FimPeriodo);

            Conexao.CRUD(comando);            
        }
        public Frequencia BuscarId(int id)
        {

            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from Frequencias where idFrequencia=@idFrequencia";
            comando.Parameters.AddWithValue("@idFrequencia", id);

            SqlDataReader dr = Conexao.Selecionar(comando);

            Frequencia objFrequencia = new Frequencia();

            if (dr.Read())
            {
                objFrequencia.Id = (int)dr["idFrequencia"];
                objFrequencia.Dia = (DateTime)dr["dia"];
                objFrequencia.ListaPonto = new PontoDAO().BuscarTodosFrequencia((int)dr["idFrequencia"]);


                if (dr["horasTrabalhadas"] != DBNull.Value)
                {
                    objFrequencia.HorasTrabalhadas = TimeSpan.Parse(Convert.ToString(dr["horasTrabalhadas"]));
                }
                else
                {
                    objFrequencia.HorasTrabalhadas = null;
                }



                if (dr["estado"] != DBNull.Value)
                {
                    objFrequencia.EnumEstado = (Estado)Enum.Parse((typeof(Estado)), dr["estado"].ToString());
                }

                if (dr["idJustificativa"] != DBNull.Value)
                {
                    objFrequencia.Justificativa = new JustificativaDAO().BuscarPorId((int)dr["idJustificativa"]);
                }

            }
            else
            {
                objFrequencia = null;
            }

            return objFrequencia;
        }
        public IList<Frequencia> BuscarTodasFuncionario(int id)
        {            
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select top(7) * from Frequencias where idFuncionario=@idFuncionario and dia < @data order by dia asc";
            comando.Parameters.AddWithValue("@idFuncionario", id);
            comando.Parameters.AddWithValue("@data", DateTime.Now.ToShortDateString());

            SqlDataReader dr = Conexao.Selecionar(comando);
            IList<Frequencia> listaFrequencia = new List<Frequencia>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Frequencia objFrequencia = new Frequencia();
                    objFrequencia.Id = (int)dr["idFrequencia"];
                    objFrequencia.Dia = (DateTime)dr["dia"];
                    objFrequencia.ListaPonto = new PontoDAO().BuscarFrequencia((int)dr["idFrequencia"]);



                    if (dr["horasTrabalhadas"] != DBNull.Value)
                    {
                        objFrequencia.HorasTrabalhadas = TimeSpan.Parse(Convert.ToString(dr["horasTrabalhadas"]));
                    }
                    else
                    {
                        objFrequencia.HorasTrabalhadas = null;
                    }

                    if (dr["estado"] != DBNull.Value)
                    {
                        objFrequencia.EnumEstado = (Estado)Enum.Parse((typeof(Estado)), dr["estado"].ToString());
                    }


                    if (dr["idFeriado"] != DBNull.Value)
                    {
                        objFrequencia.Feriado = new FeriadoDAO().BuscarId((int)dr["idFeriado"]);
                    }

                    if (dr["idJustificativa"] != DBNull.Value)
                    {
                        objFrequencia.Justificativa = new JustificativaDAO().BuscarPorId((int)dr["idJustificativa"]);
                    }

                    listaFrequencia.Add(objFrequencia);
                }
            }
            else
            {
                listaFrequencia = null;
            }

            return listaFrequencia;
        }
        public void SalvarFrequenciacFeriado(Frequencia objFrequencia, Funcionario objFuncionario)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "insert into Frequencias(dia, idFuncionario, idFeriado) values(@dia, @idFuncionario, @idFeriado)";
            comando.Parameters.AddWithValue("@dia", objFrequencia.Dia);
            comando.Parameters.AddWithValue("@idFuncionario", objFuncionario.Id);
            comando.Parameters.AddWithValue("@idFeriado", objFrequencia.Feriado.Id);

            Conexao.CRUD(comando);
        }
    }
}