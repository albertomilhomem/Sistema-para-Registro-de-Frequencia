using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Model;
using Negocio.DAO;
using System.Text.RegularExpressions;

namespace Negocio.BO
{
    public class FuncionarioBO
    {
        private void ValidarCampos(Funcionario objFuncionario)
        {
            if (objFuncionario.Cargo == null || String.IsNullOrEmpty(objFuncionario.Cpf) || String.IsNullOrEmpty(objFuncionario.DataAdmissao.ToString()) || String.IsNullOrEmpty(objFuncionario.DataNascimento.ToString()) || String.IsNullOrEmpty(objFuncionario.Email) || String.IsNullOrEmpty(objFuncionario.Matricula) || String.IsNullOrEmpty(objFuncionario.Nome) || objFuncionario.Setor == null)
            {
                throw new Exception("Preencha todos os campos!");            
            }
            else if (objFuncionario.Cpf.Length != 14 || Regex.IsMatch(objFuncionario.Cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$") != true)
            {
                throw new Exception("CPF inválido!");                
            }
            else if (Regex.IsMatch(objFuncionario.Email, "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$") != true)
            {
                throw new Exception("E-mail inválido!");           
            }
            else if(objFuncionario.DataAdmissao > DateTime.Now)
            {
                throw new Exception("Data de Nascimento inválida!");
            }
            else if (objFuncionario.DataAdmissao > DateTime.Now)
            {
                throw new Exception("Data de Admissão inválida!");      
            }
        }

        public IList<Funcionario> BuscarTodosGerentes()
        {
            FuncionarioDAO objFuncionarioDAO = new FuncionarioDAO();
            IList<Funcionario> listaFuncionario = objFuncionarioDAO.BuscarTodosGerentes();

            return listaFuncionario;
        }

        public void Alterar(Funcionario objFuncionario)
        {

            ValidarCampos(objFuncionario);

            FuncionarioDAO objFuncionarioDAO = new FuncionarioDAO();

            objFuncionarioDAO.Alterar(objFuncionario);
        }


        public Funcionario BuscarID(int id)
        {
            FuncionarioDAO objFuncionarioDAO = new FuncionarioDAO();
            Funcionario objFuncionario = objFuncionarioDAO.BuscarPorId(id);

            return objFuncionario;
        }

        public Funcionario BuscarMatricula(int matricula)
        {
            FuncionarioDAO objFuncionarioDAO = new FuncionarioDAO();
            Funcionario objFuncionario = objFuncionarioDAO.BuscarMatricula(matricula);

            return objFuncionario;
        }

        public IList<Funcionario> BuscarTodos(Funcionario objFuncionario)
        {
            FuncionarioDAO objFuncionarioDAO = new FuncionarioDAO();
            IList<Funcionario> listaFuncionario = new List<Funcionario>();
            if (objFuncionario.Administrador == true)
            {
                listaFuncionario = objFuncionarioDAO.BuscarTodos();                
            }
            else if (objFuncionario.Cargo.Nome == "Gerente")
            {
                listaFuncionario = objFuncionarioDAO.BuscarTodosRegionalSemGerente(objFuncionario);        
            }
            else
            {

                    listaFuncionario = objFuncionarioDAO.BuscarTodosRegional(objFuncionario);
                
            }

            return listaFuncionario;
        }
        public void Salvar(Funcionario objFuncionario)
        {
            ValidarCampos(objFuncionario);

            FuncionarioDAO objFuncionarioDAO = new FuncionarioDAO();
            objFuncionarioDAO.Salvar(objFuncionario);


            objFuncionario = objFuncionarioDAO.BuscarMatricula(Convert.ToInt32(objFuncionario.Matricula));
            FrequenciaBO objFrequenciaBO = new FrequenciaBO();
            objFrequenciaBO.Salvar(objFuncionario);
        }

        public IList<Funcionario> Filtrar(string atributo, string valor)
        {
            FuncionarioDAO objFuncionarioDAO = new FuncionarioDAO();
            IList<Funcionario> listaFuncionario = objFuncionarioDAO.Filtrar(atributo, valor);

            return listaFuncionario;
        }

        public void AlterarSenha(Funcionario objFuncionario, string senhaAntiga, string senhaNova)
        {
            if (objFuncionario.Senha == senhaAntiga)
            {
                objFuncionario.Senha = senhaNova;

                FuncionarioDAO objFuncionarioDAO = new FuncionarioDAO();
                objFuncionarioDAO.AlterarSenha(objFuncionario);
            }
            else
            {
                throw new Exception("A senha digitada não confere com a senha antiga");
            }
        }

        public IList<Funcionario> BuscarTodosRegional(Funcionario objFuncionario)
        {
            FuncionarioDAO objFuncionarioDAO = new FuncionarioDAO();
            IList<Funcionario> listaFuncionario = objFuncionarioDAO.BuscarTodosRegional(objFuncionario);

            return listaFuncionario;
        }

        public void ConfirmarSenha(Funcionario objFuncionario, string senha)
        {
            if (objFuncionario.Senha != senha)
            {
                throw new Exception("Senha inválida, tente novamente!");                                
            }
        }
    }

}