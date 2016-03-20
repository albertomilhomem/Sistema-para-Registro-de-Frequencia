using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Negocio.Model
{
    public class Feriado
    {
        private DateTime dia;

        private string nome;

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
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

    }//end Feriado

}//end namespace Model