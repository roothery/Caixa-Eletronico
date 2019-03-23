using System;
using System.Collections.Generic;
using App;
using Xunit;

namespace AppTeste
{
    public class CaixaTeste
    {

        [Fact]
        public void Deve_ter_o_valor_do_saque_disponivel_no_caixa()
        {
            var saldoDoCaixa = new Dictionary<int, int>
            {
            { 100, 3 },
            { 50, 2 },
            { 20, 0 },
            { 10, 0 }
            };

            var caixaEletronico = new CaixaEletronico(saldoDoCaixa);

            var resultado = caixaEletronico.TemDisponivel(200);

            Assert.True(resultado);
        }
    }
}
