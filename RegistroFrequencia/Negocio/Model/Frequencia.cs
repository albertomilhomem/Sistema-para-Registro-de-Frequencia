using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Frequencia
    {
        private int id;


        private DateTime dia;

        private Justificativa justificativa;


        private Feriado feriado;


        private IList<Ponto> listaPonto;


        private Nullable<Estado> enumEstado;


        private Nullable<TimeSpan> horasTrabalhadas;

        public Nullable<TimeSpan> HorasTrabalhadas
        {
            get { return horasTrabalhadas; }
            set { horasTrabalhadas = value; }
        }

        public Nullable<Estado> EnumEstado
        {
            get { return enumEstado; }
            set { enumEstado = value; }
        }

        public IList<Ponto> ListaPonto
        {
            get { return listaPonto; }
            set { listaPonto = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Feriado Feriado
        {
            get { return feriado; }
            set { feriado = value; }
        }


        public Justificativa Justificativa
        {
            get { return justificativa; }
            set { justificativa = value; }
        }

        public DateTime Dia
        {
            get
            {
                return dia;
            }
            set
            {
                dia = value;
            }
        }

    }//end Frequencia

}//end namespace Model