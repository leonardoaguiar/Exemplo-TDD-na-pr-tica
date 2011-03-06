using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtigoTDD_TCC.Tests.Dominio
{
    public class Login
    {
        private IWebServiceLogin servico;

        public Login(IWebServiceLogin servico)
        {
            this.servico = servico;
        }

        public bool Validar(string usuario, string senha)
        {
            if (String.IsNullOrEmpty(usuario) || String.IsNullOrEmpty(senha))
                throw new Exception("Campo usuário e ou senha está vazio.");

            return servico.LogIn(usuario, senha);
        }

        public void Desconectar(string usuario)
        {
            if (String.IsNullOrEmpty(usuario))
                throw new Exception("Campo usuário e ou senha está vazio.");

            servico.LogOff(usuario);
        }
    }
}
