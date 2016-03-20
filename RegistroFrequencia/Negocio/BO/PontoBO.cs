using Negocio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocio.DAO;

namespace Negocio.BO
{
    public class PontoBO
    {
        public void Salvar(Ponto objPonto, Frequencia objFrequencia)
        {
            PontoDAO objPontoDAO = new PontoDAO();
            objPontoDAO.Salvar(objPonto, objFrequencia);
        }
    }
}
