using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.Model
{
    public class Ponto
    {        
        private int id;

        private DateTime hora;
        private bool entrada;

        public bool Entrada
        {
            get { return entrada; }
            set { entrada = value; }
        }

        public DateTime Hora
        {
            get { return hora; }
            set { hora = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
