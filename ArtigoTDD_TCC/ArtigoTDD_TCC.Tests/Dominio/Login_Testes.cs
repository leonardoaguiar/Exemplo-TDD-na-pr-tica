using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ArtigoTDD_TCC.Tests.Dominio
{
    [TestClass]
    public class Login_Testes
    {

        /*
         * 
         * 1 - OK - Informar usuário e senha válidos e efetuar o login.
         * 2 - OK - Informar usuário e ou senha inválida e retornar falha no login.
         * 3 - OK - Efetuar logoff.
         * 4 - OK - Informar usuário e ou senha em branco ou null e retornar Exception.
         * 
        */

        [TestMethod]
        public void Informar_Usuario_E_Efetuar_Logoff()
        {
            // Variavel.
            // Mais uma variavel.
            // Terceira variavel.
            // Agora vai.
            var usuario = "administrador";

            Mock<IWebServiceLogin> webService = new Mock<IWebServiceLogin>(MockBehavior.Loose);
            webService.Setup(w => w.LogOff(usuario));

            var login = new Login(webService.Object);
            login.Desconectar(usuario);

            webService.VerifyAll();
        }

        [TestMethod]
        public void Informar_usuario_e_senha_validos_e_efetuar_o_login()
        {
            var usuario = "administrador";
            var senha = "senhaforte";

            Mock<IWebServiceLogin> webService = new Mock<IWebServiceLogin>(MockBehavior.Loose);
            webService.Setup(w => w.LogIn(usuario, senha)).Returns(true);

            var login = new Login(webService.Object);
            bool valido = login.Validar(usuario, senha);

            webService.VerifyAll();

            Assert.AreEqual(true, valido);
        }

        [TestMethod]
        public void Informar_usuario_e_ou_senha_invalidos_e_efetuar_falha_no_login()
        {
            var usuario = "administrador";
            var senha = "senhaforte";

            Mock<IWebServiceLogin> webService = new Mock<IWebServiceLogin>(MockBehavior.Loose);
            webService.Setup(w => w.LogIn(usuario, senha)).Returns(false);

            var login = new Login(webService.Object);
            bool valido = login.Validar(usuario, senha);

            webService.VerifyAll();

            Assert.AreEqual(false, valido);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Informar_usuario_e_ou_senha_em_branco_ou_null_e_retornar_exception()
        {
            var usuario = String.Empty;
            var senha = String.Empty;

            Mock<IWebServiceLogin> webService = new Mock<IWebServiceLogin>(MockBehavior.Loose);
            webService.Setup(w => w.LogIn(usuario, senha));

            var login = new Login(webService.Object);
            login.Validar(usuario, senha);
        }
    }
}
