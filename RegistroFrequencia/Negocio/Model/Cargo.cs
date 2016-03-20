using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Cargo
    {
        private string nome;

        private TimeSpan cargaHoraria;


        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public TimeSpan CargaHoraria
        {
            get
            {
                return cargaHoraria;
            }
            set
            {
                cargaHoraria = value;
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

    }//end Cargo

}//end namespace Model