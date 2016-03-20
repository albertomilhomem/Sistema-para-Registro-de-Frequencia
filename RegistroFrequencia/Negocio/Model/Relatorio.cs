using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.Model
{
    public class Relatorio
    {
        private int diasUteis;
        private TimeSpan horasTrabalhar;
        private Nullable<TimeSpan> horasTrabalhadas;
        private Nullable<TimeSpan> horasTrabalhadasSabado;
        private Nullable<TimeSpan> horasTrabalhadasDomingo;
        private int faltas;
        private int faltasJustificadas;
        private int justificativas;
        private int incompletosJustificadas;
        private int incompletos;

        public int Incompletos
        {
            get { return incompletos; }
            set { incompletos = value; }
        }


        public int IncompletosJustificadas
        {
            get { return incompletosJustificadas; }
            set { incompletosJustificadas = value; }
        }

        public int Justificativas
        {
            get { return justificativas; }
            set { justificativas = value; }
        }



        public int FaltasJustificadas
        {
            get { return faltasJustificadas; }
            set { faltasJustificadas = value; }
        }


        public int Faltas
        {
            get { return faltas; }
            set { faltas = value; }
        }



        public Nullable<TimeSpan> HorasTrabalhadasDomingo
        {
            get { return horasTrabalhadasDomingo; }
            set { horasTrabalhadasDomingo = value; }
        }



        public Nullable<TimeSpan> HorasTrabalhadasSabado
        {
            get { return horasTrabalhadasSabado; }
            set { horasTrabalhadasSabado = value; }
        }


        public Nullable<TimeSpan> HorasTrabalhadas
        {
            get { return horasTrabalhadas; }
            set { horasTrabalhadas = value; }
        }


        public TimeSpan HorasTrabalhar
        {
            get { return horasTrabalhar; }
            set { horasTrabalhar = value; }
        }


        public int DiasUteis
        {
            get { return diasUteis; }
            set { diasUteis = value; }
        }
    }
}
