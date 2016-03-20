using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Setor
    {
        private string nome;
        private string telefone;
        private Funcionario funcionario;
        private int id;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Funcionario Funcionario
        {
            get { return funcionario; }
            set { funcionario = value; }
        }

        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }

        public string Telefone
        {
            get
            {
                return telefone;
            }
            set
            {
                telefone = value;
            }
        }

    }//end Setor

}//end namespace Model