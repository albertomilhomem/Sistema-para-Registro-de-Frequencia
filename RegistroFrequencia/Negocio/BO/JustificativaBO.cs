using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Model;
using Negocio.DAO;

namespace Negocio.BO
{
    public class JustificativaBO
    {
        private void ValidarCampos(Justificativa objJustificativa)
        {
            if (String.IsNullOrEmpty(objJustificativa.Motivo.ToString()) || String.IsNullOrEmpty(objJustificativa.Complemento.ToString()) || String.IsNullOrEmpty(objJustificativa.Complemento.ToString()))
            {
                throw new Exception("Preencha todos os campos corretamente!");                
            }
            else if (objJustificativa.InicioPeriodo > objJustificativa.FimPeriodo)
            {
                throw new Exception("Datas inválidas, a data inicial não pode ser maior que a da data final.");
            }
            else if (objJustificativa.Comprovante == null)
            {
                throw new Exception("Não é possivel criar uma justificativa sem um comprovante.");
            }
            else if (VerificarFrequencia(objJustificativa) == false)
            {
                throw new Exception("O período selecionado possui frequência como PRESENTE, só é aceito FALTA e INCOMPLETO");
            }
            else if (VerificarPeriodo(objJustificativa))
            {
                throw new Exception("Você já possui uma justificativa para esse periodo");
            }
            
        }

        private bool VerificarFrequencia(Justificativa objJustificativa)
        {
            IList<Frequencia> listaFrequencia = new FrequenciaBO().BuscarPeriodo(objJustificativa.Funcionario, objJustificativa.InicioPeriodo, objJustificativa.FimPeriodo);

            for (int i = 0; i < listaFrequencia.Count; i++)
            {
                if (Convert.ToString(listaFrequencia[i].EnumEstado) == "Presente")
                {
                    return false;
                }
            }

            return true;
        }

        public void Alterar(Justificativa objJustificativa)
        {
            JustificativaDAO objJustificativaDAO = new JustificativaDAO();
            objJustificativaDAO.Alterar(objJustificativa);
        }

        public void AlterarEstado(Justificativa objJustificativa)
        {
            JustificativaDAO objJustificativaDAO = new JustificativaDAO();
            objJustificativaDAO.AlterarEstado(objJustificativa);

            FrequenciaBO objFrequenciaBO = new FrequenciaBO();
            objFrequenciaBO.AlterarJustificativa(objJustificativa);
        }
        public Justificativa BuscarID(int id)
        {
            JustificativaDAO objJustificativaDAO = new JustificativaDAO();
            Justificativa objJustificativa = objJustificativaDAO.BuscarPorId(id);

            return objJustificativa;
        }

        public IList<Justificativa> BuscarTodosPendentes(Funcionario objFuncionario)
        {
            JustificativaDAO objJustificativaDAO = new JustificativaDAO();
            IList<Justificativa> listaJustificativa = objJustificativaDAO.BuscarTodosPendentes(objFuncionario);

            return listaJustificativa;
        }

        public IList<Justificativa> BuscarTodosAutorizados(Funcionario objFuncionario)
        {
            JustificativaDAO objJustificativaDAO = new JustificativaDAO();
            IList<Justificativa> listaJustificativa = objJustificativaDAO.BuscarTodosAutorizados(objFuncionario);

            return listaJustificativa;
        }

        public IList<Justificativa> BuscarTodosFuncionario(Funcionario objFuncionario)
        {
            JustificativaDAO objJustificativaDAO = new JustificativaDAO();
            IList<Justificativa> listaJustificativa = objJustificativaDAO.BuscarTodosFuncionario(objFuncionario);

            return listaJustificativa;
        }

        public void Salvar(Justificativa objJustificativa)
        {
            JustificativaDAO objJustificativaDAO = new JustificativaDAO();
            ValidarCampos(objJustificativa);
            objJustificativaDAO.Salvar(objJustificativa);
        }

        public bool VerificarPeriodo(Justificativa objJustificativa)
        {
            JustificativaDAO objJustificativaDAO = new JustificativaDAO();
            IList<Justificativa> listaJustificativa = objJustificativaDAO.BuscarPeriodo(objJustificativa);

            if (listaJustificativa == null)
            {
                return false;                
            }

            return true;
        }
    }

}