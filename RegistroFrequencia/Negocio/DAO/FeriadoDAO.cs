using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DAO
{
    public class FeriadoDAO
    {
        public void Salvar(Feriado objFeriado)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "insert into Feriados(nome, dia) values(@nome, @dia)";
            comando.Parameters.AddWithValue("@nome", objFeriado.Nome);
            comando.Parameters.AddWithValue("@dia", objFeriado.Dia.ToShortDateString());

            Conexao.CRUD(comando);
        }

        public void Alterar(Feriado objFeriado)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "update feriados set nome=@nome, dia=@dia where idFeriado=@id";
            comando.Parameters.AddWithValue("@nome", objFeriado.Nome);
            comando.Parameters.AddWithValue("@dia", objFeriado.Dia);
            comando.Parameters.AddWithValue("@id", objFeriado.Id);

            Conexao.CRUD(comando);
        }

        public Feriado BuscarId(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from feriados where idFeriado=@id";
            comando.Parameters.AddWithValue("@id", id);

            Feriado objFeriado = new Feriado();
            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.Read())
            {
                objFeriado.Dia = (DateTime)dr["dia"];
                objFeriado.Nome = (string)dr["nome"];
                objFeriado.Id = (int)dr["idFeriado"];
            }
            else
            {
                objFeriado = null;
            }

            return objFeriado;
        }

        public IList<Feriado> BuscarTodos()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from Feriados where dia > @dia order by dia";
            comando.Parameters.AddWithValue("@dia", DateTime.Now);

            IList<Feriado> listaFeriados = new List<Feriado>();
            SqlDataReader dr = Conexao.Selecionar(comando);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Feriado objFeriado = new Feriado();

                    objFeriado.Dia = (DateTime)dr["dia"];
                    objFeriado.Nome = (string)dr["nome"];
                    objFeriado.Id = (int)dr["idFeriado"];

                    listaFeriados.Add(objFeriado);
                }
            }
            else
            {
                listaFeriados = null;
            }

            return listaFeriados;
        }

        public IList<Feriado> FiltrarNome(string nome)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = String.Format("select * from Feriados where nome like '%{0}%' order by nome", nome);

            IList<Feriado> listaFeriados = new List<Feriado>();
            SqlDataReader dr = Conexao.Selecionar(comando);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Feriado objFeriado = new Feriado();

                    objFeriado.Dia = (DateTime)dr["dia"];
                    objFeriado.Nome = (string)dr["nome"];
                    objFeriado.Id = (int)dr["idFeriado"];

                    listaFeriados.Add(objFeriado);
                }
            }
            else
            {
                listaFeriados = null;
            }

            return listaFeriados;
        }

        public IList<Feriado> FiltrarData(string data)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from Feriados where dia=@data";
            comando.Parameters.AddWithValue("@data", data);

            IList<Feriado> listaFeriados = new List<Feriado>();
            SqlDataReader dr = Conexao.Selecionar(comando);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Feriado objFeriado = new Feriado();

                    objFeriado.Dia = (DateTime)dr["dia"];
                    objFeriado.Nome = (string)dr["nome"];
                    objFeriado.Id = (int)dr["idFeriado"];

                    listaFeriados.Add(objFeriado);
                }
            }
            else
            {
                listaFeriados = null;
            }

            return listaFeriados;
        }

        public Feriado BuscarDia(DateTime dia)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select * from feriados where dia=@dia";
            comando.Parameters.AddWithValue("@dia", dia);

            Feriado objFeriado = new Feriado();
            SqlDataReader dr = Conexao.Selecionar(comando);

            if (dr.Read())
            {
                objFeriado.Dia = (DateTime)dr["dia"];
                objFeriado.Nome = (string)dr["nome"];
                objFeriado.Id = (int)dr["idFeriado"];
            }
            else
            {
                objFeriado = null;
            }

            return objFeriado;
        }
    }
}
