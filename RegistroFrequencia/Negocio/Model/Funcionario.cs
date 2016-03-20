using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Model
{
    public class Funcionario
    {
        private string cpf;

        private DateTime dataAdmissao;

        private DateTime dataNascimento;


        private string email;


        private string matricula;


        private string nome;


        private string senha;


        private int id;


        private Cargo cargo;


        private Setor setor;


        private IList<Frequencia> listaDeFrequencia;


        private bool administrador;

        public bool Administrador
        {
            get { return administrador; }
            set { administrador = value; }
        }

        public Funcionario(IList<Frequencia> listaFrequencia) 
        {
            ListaDeFrequencia = listaFrequencia;
        }

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public IList<Frequencia> ListaDeFrequencia
        {
            get { return listaDeFrequencia; }
            set { listaDeFrequencia = value; }
        }

        public Setor Setor
        {
            get { return setor; }
            set { setor = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public string Cpf
        {
            get
            {
                return cpf;
            }
            set
            {
                cpf = value;
            }
        }

        public DateTime DataAdmissao
        {
            get
            {
                return dataAdmissao;
            }
            set
            {
                dataAdmissao = value;
            }
        }

        public DateTime DataNascimento
        {
            get
            {
                return dataNascimento;
            }
            set
            {
                dataNascimento = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Matricula
        {
            get
            {
                return matricula;
            }
            set
            {
                matricula = value;
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

        public string Senha
        {
            get
            {
                return senha;
            }
            set
            {
                senha = value;
            }
        }

    }//end Funcionario

}//end namespace Model