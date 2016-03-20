using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.BO
{
    public class RelatorioBO
    {
        public void ValidarData(DateTime dataInicial, DateTime dataFinal)
        {
            if (dataInicial > dataFinal)
            {
                throw new Exception("Data final inválida, data final deve ser maior que a data inicial.");
            }
            else if (dataFinal > DateTime.Now)
            {
                throw new Exception("Você não pode gerar um relatorio com data final maior que a de hoje.");                
            }
        }

        public Relatorio GerarRelatorio(Funcionario objFuncionario, IList<Frequencia> listaFrequencia)
        {
            Relatorio objRelatorio = new Relatorio();

            objRelatorio.DiasUteis = CalcularDiasUteis(listaFrequencia);
            objRelatorio.HorasTrabalhar = TimeSpan.FromMinutes(objFuncionario.Cargo.CargaHoraria.TotalMinutes * objRelatorio.DiasUteis);
            objRelatorio.HorasTrabalhadas = HorasTrabalhadas(listaFrequencia);
            objRelatorio.Faltas = CalcularFaltas(listaFrequencia);
            objRelatorio.FaltasJustificadas = CalcularFaltasJustificadas(listaFrequencia);
            objRelatorio.Incompletos = CalcularIncompletos(listaFrequencia);
            objRelatorio.IncompletosJustificadas = CalcularIncompletosJustificados(listaFrequencia);
            objRelatorio.HorasTrabalhadasSabado = HorasTrabalhadasSabado(listaFrequencia);
            objRelatorio.HorasTrabalhadasDomingo = HorasTrabalhadasDomingo(listaFrequencia);

            return objRelatorio;
        }

        #region Métodos
        private int CalcularDiasUteis(IList<Frequencia> listaFrequencia)
        {
            int diasUteis = 0;

            for (int i = 0; i < listaFrequencia.Count; i++)
            {
                if ((Convert.ToString(listaFrequencia[i].Dia.DayOfWeek) != "Sunday" && Convert.ToString(listaFrequencia[i].Dia.DayOfWeek) != "Saturday" && listaFrequencia[i].Feriado == null))
                {
                    diasUteis++;
                }
            }

            return diasUteis;
        }

        private Nullable<TimeSpan> HorasTrabalhadas(IList<Frequencia> listaFrequencia)
        {
            Nullable<TimeSpan> horasTrabalhadas = new TimeSpan(1);

            for (int count = 0; count < listaFrequencia.Count; count++)
            {
                if (listaFrequencia[count].HorasTrabalhadas != null)
                {
                    horasTrabalhadas = horasTrabalhadas + (TimeSpan)listaFrequencia[count].HorasTrabalhadas;
                }
            }


            if (horasTrabalhadas == TimeSpan.Parse("00:00:00.0000001"))
            {
                horasTrabalhadas = null;
            }

            return horasTrabalhadas;
        }

        private Nullable<TimeSpan> HorasTrabalhadasSabado(IList<Frequencia> listaFrequencia)
        {
            Nullable<TimeSpan> horasTrabalhadasSabado = new TimeSpan(1);

            for (int count = 0; count < listaFrequencia.Count; count++)
            {
                if (listaFrequencia[count].HorasTrabalhadas != null && listaFrequencia[count].Dia.DayOfWeek.ToString() == "Saturday")
                {
                    horasTrabalhadasSabado = horasTrabalhadasSabado + (TimeSpan)listaFrequencia[count].HorasTrabalhadas;
                }
            }


            if (horasTrabalhadasSabado == TimeSpan.Parse("00:00:00.0000001"))
            {
                horasTrabalhadasSabado = null;
            }

            return horasTrabalhadasSabado;

        }

        private Nullable<TimeSpan> HorasTrabalhadasDomingo(IList<Frequencia> listaFrequencia)
        {
            Nullable<TimeSpan> horasTrabalhadasDomingo = new TimeSpan(1);

            for (int count = 0; count < listaFrequencia.Count; count++)
            {
                if (listaFrequencia[count].HorasTrabalhadas != null && listaFrequencia[count].Dia.DayOfWeek.ToString() == "Saturday")
                {
                    horasTrabalhadasDomingo = horasTrabalhadasDomingo + (TimeSpan)listaFrequencia[count].HorasTrabalhadas;
                }
            }

            if (horasTrabalhadasDomingo == TimeSpan.Parse("00:00:00.0000001"))
            {
                horasTrabalhadasDomingo = null;
            }

            return horasTrabalhadasDomingo;
        }

        private int CalcularFaltas(IList<Frequencia> listaFrequencia)
        {
            int faltas = 0;

            for (int count = 0; count < listaFrequencia.Count; count++)
            {
                if (listaFrequencia[count].EnumEstado.ToString() == "Faltou" || (listaFrequencia[count].EnumEstado.ToString() == "Justificado" && listaFrequencia[count].HorasTrabalhadas == null))
                {
                    faltas++;
                }
            }

            return faltas;
        }
        private int CalcularFaltasJustificadas(IList<Frequencia> listaFrequencia)
        {
            int faltasJustificadas = 0;
            for (int count = 0; count < listaFrequencia.Count; count++)
            {
                if ((listaFrequencia[count].EnumEstado.ToString() == "Justificado" && listaFrequencia[count].HorasTrabalhadas == null))
                {
                    faltasJustificadas++;
                }
            }

            return faltasJustificadas;
        }
        private int CalcularIncompletos(IList<Frequencia> listaFrequencia)
        {
            int incompletos = 0;

            for (int count = 0; count < listaFrequencia.Count; count++)
            {
                if (listaFrequencia[count].EnumEstado.ToString() == "Incompleto" || (listaFrequencia[count].EnumEstado.ToString() == "Justificado" && listaFrequencia[count].HorasTrabalhadas != null))
                {
                    incompletos++;
                }
            }

            return incompletos;
        }
        private int CalcularIncompletosJustificados(IList<Frequencia> listaFrequencia)
        {
            int incompletosJustificados = 0;
            for (int count = 0; count < listaFrequencia.Count; count++)
            {
                if ((listaFrequencia[count].EnumEstado.ToString() == "Justificado" && listaFrequencia[count].HorasTrabalhadas != null))
                {
                    incompletosJustificados++;
                }
            }

            return incompletosJustificados;
        }
        #endregion
    }
}
