using System;
using System.Collections.Generic;
using App;
using Xunit;

namespace AppTeste
{
    public class CaixaTeste
    {

        CaixaEletronico caixaEletronico = new CaixaEletronico();

        [Fact]
        public void Deve_receber_10_reais_no_saque_de_10_reais()
        {
            Dictionary<int, int> nota = caixaEletronico.saqueDe(10);
            Dictionary<int, int> resultado = new Dictionary<int, int>();

            resultado.Add(10, 1);

            Assert.Equal(resultado, nota);
        }
    }
}
