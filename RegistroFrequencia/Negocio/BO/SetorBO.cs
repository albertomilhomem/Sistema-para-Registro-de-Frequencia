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
    public class SetorBO
    {
        private void VerificarDados(Setor objSetor)
        {
            if (String.IsNullOrEmpty(objSetor.Nome) || String.IsNullOrEmpty(objSetor.Telefone) || objSetor.Funcionario == null)
            {
                throw new Exception("Preencha todos os dados");
            }
            else if (Regex.IsMatch(objSetor.Telefone, @"^\([1-9]{2}\) [2-9][0-9]{3,4}\-[0-9]{4}$") != true)
            {
                throw new Exception("Telefone inválido!");
            }
        }
        public void Alterar(Setor objSetor)
        {
            VerificarDados(objSetor);
            SetorDAO objSetorDAO = new SetorDAO();
            objSetorDAO.Alterar(objSetor);
        }
        public Setor BuscarID(int id)
        {
            SetorDAO objSetorDAO = new SetorDAO();
            Setor objSetor = objSetorDAO.BuscarPorId(id);

            return objSetor;
        }
        public IList<Setor> BuscarTodos()
        {
            SetorDAO objSetorDAO = new SetorDAO();
            IList<Setor> listaSetor = objSetorDAO.BuscarTodos();

            return listaSetor;
        }
        public void Salvar(Setor objSetor)
        {
            VerificarDados(objSetor);
            SetorDAO objSetorDAO = new SetorDAO();
            objSetorDAO.Salvar(objSetor);
        }
        public IList<Setor> Filtrar(string atributo, string valor)
        {
            SetorDAO objSetorDAO = new SetorDAO();
            IList<Setor> listaSetor = objSetorDAO.Filtrar(atributo, valor);

            return listaSetor;
        }

        public IList<Setor> Buscar(Funcionario objFuncionario)
        {
            IList<Setor> listaSetor = new List<Setor>();
            if (objFuncionario.Cargo.Nome == "Gerente" && objFuncionario.Administrador != true)
            {
                listaSetor.Add(BuscarID(objFuncionario.Setor.Id));
            }
            else
            {
                listaSetor = BuscarTodos();
            }

            return listaSetor;

        }
    }
}