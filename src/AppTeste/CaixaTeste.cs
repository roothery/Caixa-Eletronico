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
            { 50, 1 },
            { 20, 0 },
            { 10, 0 }
            };

            var caixaEletronico = new CaixaEletronico(saldoDoCaixa);

            var resultado = caixaEletronico.TemDisponivel(60);

            Assert.True(resultado);
        }

        [Fact]
        public void Não_deve_realizar_saque_quando_não_possuir_notas_suficientes()
        {
            var saldoDoCaixa = new Dictionary<int, int>
            {
            { 100, 3 },
            { 50, 1 },
            { 20, 0 },
            { 10, 0 }
            };

            var caixaEletronico = new CaixaEletronico(saldoDoCaixa);

            Action act = () => caixaEletronico.SaqueDe(60);

            Exception ex = Assert.Throws<Exception>(act);
            Assert.Equal("Não tem nota suficiente para o saque", ex.Message);
        }
    }
}
