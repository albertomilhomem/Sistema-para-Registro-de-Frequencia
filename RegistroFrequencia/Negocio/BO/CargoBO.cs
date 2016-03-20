using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Model;
using Negocio.DAO;

namespace Negocio.BO
{
    public class CargoBO
    {
        private void ValidarCampos(Cargo objCargo)
        {
            if (String.IsNullOrEmpty(objCargo.CargaHoraria.ToString()) || String.IsNullOrEmpty(objCargo.Nome))
            {
                throw new Exception("Preencha todos os campos!");
            }
        }

        public void Alterar(Cargo objCargo)
        {
            ValidarCampos(objCargo);

            CargoDAO objCargoDAO = new CargoDAO();
            objCargoDAO.Alterar(objCargo);
        }

        public Cargo BuscarID(int id)
        {
            CargoDAO objCargoDAO = new CargoDAO();
            Cargo objCargo = objCargoDAO.BuscarPorId(id);

            return objCargo;
        }

        public IList<Cargo> BuscarTodos(Funcionario objFuncionario)
        {
            IList<Cargo> listaCargo = new List<Cargo>();
            if (objFuncionario.Administrador == true)
            {
                CargoDAO objCargoDAO = new CargoDAO();
                listaCargo = objCargoDAO.BuscarTodos();         
            }
            else
            {
                CargoDAO objCargoDAO = new CargoDAO();
                listaCargo = objCargoDAO.BuscarTodosTecnicos();
            }

            return listaCargo;
        }

        public void Salvar(Cargo objCargo)
        {
            ValidarCampos(objCargo);

            CargoDAO objCargoDAO = new CargoDAO();
            objCargoDAO.Salvar(objCargo);
        }
        public IList<Cargo> Filtrar(string atributo, string valor)
        {
            CargoDAO objCargoDAO = new CargoDAO();
            IList<Cargo> listaCargo = objCargoDAO.Filtrar(atributo, valor);

            return listaCargo;
        }
    }
}