using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocio.Model;
using System.Data.SqlClient;

namespace Negocio.DAO
{
    public class PontoDAO
    {
        public void Salvar(Ponto objPonto, Frequencia objFrequencia)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "insert into Pontos(hora, idFrequencia, entrada) values(@hora, @idFrequencia, @entrada)";
            comando.Parameters.AddWithValue("@hora", objPonto.Hora);
            comando.Parameters.AddWithValue("@idFrequencia", objFrequencia.Id);
            comando.Parameters.AddWithValue("@entrada", objPonto.Entrada);

            Conexao.CRUD(comando);
        }
        public IList<Ponto> BuscarTodosFrequencia(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from Pontos where idFrequencia=@idFrequencia order by hora";
            comando.Parameters.AddWithValue("@idFrequencia", id);

            IList<Ponto> listaPontos = new List<Ponto>();
            SqlDataReader dr = Conexao.Selecionar(comando);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Ponto objPonto = new Ponto();
                    objPonto.Id = (int)dr["idPonto"];
                    objPonto.Hora = Convert.ToDateTime(Convert.ToString(dr["hora"]));
                    objPonto.Entrada = (bool)dr["entrada"];

                    listaPontos.Add(objPonto);
                }
            }
            else
            {
                listaPontos = null;
            }

            return listaPontos;
        
        }
        public IList<Ponto> BuscarFrequencia(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from Pontos where idFrequencia=@idFrequencia order by hora";
            comando.Parameters.AddWithValue("@idFrequencia", id);

            IList<Ponto> listaPontos = new List<Ponto>();
            SqlDataReader dr = Conexao.Selecionar(comando);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Ponto objPonto = new Ponto();
                    objPonto.Id = (int)dr["idPonto"];
                    objPonto.Hora = Convert.ToDateTime(Convert.ToString(dr["hora"]));
                    objPonto.Entrada = (bool)dr["entrada"];

                    listaPontos.Add(objPonto);
                }

                if (listaPontos.Count < 6)
                {
                    while (listaPontos.Count < 6)
                    {
                        listaPontos.Add(null);
                    }
                }
            }
            else
            {
                listaPontos = null;
            }

            return listaPontos;

        }

    }
}
