using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtigoTDD_TCC.Tests.Dominio
{
    public interface IWebServiceLogin
    {
        bool LogIn(string usuario, string senha);
        void LogOff(string usuario);
    }
}
