using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Justificativa
    {
        private byte[] comprovante;

        private string complemento;


        private DateTime inicioPeriodo;


        private DateTime fimPeriodo;


        private Motivo motivo;

        private int id;


        private bool aprovacao;


        private Funcionario funcionario;


        private Funcionario responsavel;


        public Funcionario Responsavel
        {
            get { return responsavel; }
            set { responsavel = value; }
        }


        public Funcionario Funcionario
        {
            get { return funcionario; }
            set { funcionario = value; }
        }


        public bool Aprovacao
        {
            get { return aprovacao; }
            set { aprovacao = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public Motivo Motivo
        {
            get { return motivo; }
            set { motivo = value; }
        }


        public string Complemento
        {
            get
            {
                return complemento;
            }
            set
            {
                complemento = value;
            }
        }


        public byte[] Comprovante
        {
            get
            {
                return comprovante;
            }
            set
            {
                comprovante = value;
            }
        }


        public DateTime InicioPeriodo
        {
            get
            {
                return inicioPeriodo;
            }
            set
            {
                inicioPeriodo = value;
            }
        }


        public DateTime FimPeriodo
        {
            get
            {
                return fimPeriodo;
            }
            set
            {
                fimPeriodo = value;
            }
        }
    }
}
