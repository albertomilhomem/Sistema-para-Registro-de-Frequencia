using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Model;
using Negocio.DAO;

namespace Negocio.BO
{
    public class FrequenciaBO
    {
        public void ValidarData(DateTime dataInicial, DateTime dataFinal)
        {
            if (dataInicial > dataFinal)
            {
                throw new Exception("Data final inválida, data final deve ser maior que a data inicial.");
            }
        }
        public void Salvar(Funcionario objFuncionario)
        {
            for (int dia = DateTime.Now.Day; dia <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); dia++)
            {
                Frequencia objFrequencia = new Frequencia();
                objFrequencia.Dia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dia);

                FeriadoBO objFeriadoBO = new FeriadoBO();
                FrequenciaDAO objFrequenciaDAO = new FrequenciaDAO();
                Feriado objFeriado = new Feriado();
                objFeriado = objFeriadoBO.BuscarDia(objFrequencia.Dia);

                if (objFeriado != null)
                {
                    objFrequencia.Feriado = objFeriadoBO.BuscarId(objFeriado.Id);
                    objFrequenciaDAO.SalvarFrequenciacFeriado(objFrequencia, objFuncionario);
                }
                else
                {
                    objFrequenciaDAO.SalvarFrequencia(objFrequencia, objFuncionario);
                }
            }

        }

        public string RegistrarFrequencia(Funcionario objFuncionario)
        {
            FrequenciaDAO objFrequenciaDAO = new FrequenciaDAO();
            string tipo = null;

            Frequencia objFrequencia = new Frequencia();
            objFrequencia = objFrequenciaDAO.BuscarFrequenciaDia(objFuncionario, DateTime.Now);

            Ponto objPonto = new Ponto();

            if (objFrequencia.ListaPonto != null)
            {
                if (objFrequencia.ListaPonto.Count % 2 == 1)
                {
                    objPonto.Entrada = false;
                    tipo = "SAÍDA";
                }
                else
                {
                    objPonto.Entrada = true;
                    tipo = "ENTRADA";
                }
            }
            else
            {
                objPonto.Entrada = true;
                tipo = "ENTRADA";
            }

            objPonto.Hora = DateTime.Now;

            PontoBO objPontoBo = new PontoBO();
            objPontoBo.Salvar(objPonto, objFrequencia);

            objFrequencia = objFrequenciaDAO.BuscarFrequenciaDia(objFuncionario, DateTime.Now);

            IList<TimeSpan> listaTimeSpan = new List<TimeSpan>(1);
            TimeSpan timeSpan = new TimeSpan(1);

            for (int count = 1; count < objFrequencia.ListaPonto.Count; count = count + 2)
            {
                timeSpan = objFrequencia.ListaPonto[count].Hora - objFrequencia.ListaPonto[count - 1].Hora;
                listaTimeSpan.Add(timeSpan);
            }

            timeSpan = new TimeSpan(1);

            for (int count = 0; count < listaTimeSpan.Count; count++)
            {
                timeSpan = timeSpan + listaTimeSpan[count];
            }

            if (objFrequencia.ListaPonto != null)
            {
                if (objFrequencia.ListaPonto.Count >= 2 && (objFrequencia.Dia.DayOfWeek.ToString() == "Saturday" || objFrequencia.Dia.DayOfWeek.ToString() == "Sunday"))
                {

                    objFrequencia.EnumEstado = (Estado)Enum.Parse((typeof(Estado)), "Presente");

                }
                else if (objFrequencia.ListaPonto.Count > 3)
                {
                    if (TimeSpan.Compare(timeSpan, objFuncionario.Cargo.CargaHoraria) == 0 || TimeSpan.Compare(timeSpan, objFuncionario.Cargo.CargaHoraria) == 1)
                    {
                        objFrequencia.EnumEstado = (Estado)Enum.Parse((typeof(Estado)), "Presente");
                    }

                    else
                    {
                        objFrequencia.EnumEstado = (Estado)Enum.Parse((typeof(Estado)), "Incompleto");
                    }
                }
                else
                {
                    objFrequencia.EnumEstado = (Estado)Enum.Parse((typeof(Estado)), "Incompleto");
                }
            }
            else
            {
                objFrequencia.EnumEstado = (Estado)Enum.Parse((typeof(Estado)), "Incompleto");
            }

            objFrequencia.HorasTrabalhadas = timeSpan;
            objFrequenciaDAO.AlterarEstado(objFrequencia);

            return tipo;
        }

        public IList<Frequencia> BuscarPeriodo(Funcionario objFuncionario, DateTime datainicial, DateTime dataFinal)
        {
            FrequenciaDAO objFrequenciaDAO = new FrequenciaDAO();
            IList<Frequencia> listaFrequencia = objFrequenciaDAO.BuscarPeriodo(objFuncionario, datainicial, dataFinal);
            return listaFrequencia;
        }

        public Frequencia BuscarFrequenciaDia(Funcionario objFuncionario, DateTime data)
        {
            FrequenciaDAO objFrequenciaDAO = new FrequenciaDAO();
            Frequencia objFrequencia = objFrequenciaDAO.BuscarFrequenciaDia(objFuncionario, data);
            return objFrequencia;
        }

        public void AlterarJustificativa(Justificativa objJustificativa)
        {
            FrequenciaDAO objFrequenciaDAO = new FrequenciaDAO();
            objFrequenciaDAO.AlterarJustificativa(objJustificativa);
        }

        public Frequencia BuscarId(int id)
        {
            FrequenciaDAO objFrequenciaDAO = new FrequenciaDAO();
            Frequencia objFrequencia = new Frequencia();
            objFrequencia = objFrequenciaDAO.BuscarId(id);

            return objFrequencia;
        }
    }
}