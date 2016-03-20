using Negocio.DAO;
using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.BO
{
    public class FeriadoBO
    {
        public void Validar(Feriado objFeriado) { }

        public Feriado BuscarDia(DateTime dia)
        {
            FeriadoDAO objFeriadoDAO = new FeriadoDAO();
            Feriado objFeriado = new Feriado();

            objFeriado = objFeriadoDAO.BuscarDia(dia);

            return objFeriado;

        }

        public void Salvar(Feriado objFeriado)
        {
            Validar(objFeriado);

            FeriadoDAO objFeriadoDAO = new FeriadoDAO();
            objFeriadoDAO.Salvar(objFeriado);
        }

        public void Alterar(Feriado objFeriado)
        {
            Validar(objFeriado);

            FeriadoDAO objFeriadoDAO = new FeriadoDAO();
            objFeriadoDAO.Alterar(objFeriado);
        }

        public Feriado BuscarId(int id)
        {
            Feriado objFeriado = new Feriado();
            FeriadoDAO objFeriadoDAO = new FeriadoDAO();

            objFeriado = objFeriadoDAO.BuscarId(id);

            return objFeriado;
        }
        public IList<Feriado> BuscarTodos()
        {
            IList<Feriado> listaFeriado = new List<Feriado>();
            FeriadoDAO objFeriadoDAO = new FeriadoDAO();

            listaFeriado = objFeriadoDAO.BuscarTodos();

            return listaFeriado;
        }
        public IList<Feriado> Filtrar(string atributo, string valor)
        {
            IList<Feriado> listaFeriado = new List<Feriado>();
            FeriadoDAO objFeriadoDAO = new FeriadoDAO();

            if (atributo == "nome")
            {
                listaFeriado = objFeriadoDAO.FiltrarNome(valor);
            }
            else
            {
                listaFeriado = objFeriadoDAO.FiltrarData(valor);
            }

            return listaFeriado;
        }

    }
}
