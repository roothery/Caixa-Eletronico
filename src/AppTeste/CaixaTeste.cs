using System;
using System.Collections.Generic;
using App;
using Xunit;

namespace AppTeste
{
    public class CaixaTeste
    {

        [Fact]
        public void Não_deve_realizar_saque_de_valores_que_nao_atendam_as_notas_disponiveis()
        {
            var saldoDoCaixa = new Dictionary<int, int>
            {
            { 100, 3 },
            { 50, 1 },
            { 20, 0 },
            { 10, 0 }
            };

            var caixaEletronico = new CaixaEletronico(saldoDoCaixa);

            Action act = () => caixaEletronico.SaqueDe(47);

            Exception ex = Assert.Throws<Exception>(act);
            Assert.Equal("Valor informado não corresponde as notas disponíveis no caixa", ex.Message);
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

        [Fact]
        public void Não_deve_realizar_saque_de_notas_abaixo_de_10()
        {
            var saldoDoCaixa = new Dictionary<int, int>
            {
            { 100, 3 },
            { 50, 1 },
            { 20, 0 },
            { 10, 1 }
            };

            var caixaEletronico = new CaixaEletronico(saldoDoCaixa);

            Action act = () => caixaEletronico.SaqueDe(9);

            Exception ex = Assert.Throws<Exception>(act);
            Assert.Equal("Saque mínimo é de 10", ex.Message);
        }

        [Fact]
        public void Não_deve_realizar_saque_sem_ter_saldo_suficiente()
        {
            var saldoDoCaixa = new Dictionary<int, int>
            {
            { 100, 3 },
            { 50, 1 },
            { 20, 0 },
            { 10, 0 }
            };

            var caixaEletronico = new CaixaEletronico(saldoDoCaixa);

            Action act = () => caixaEletronico.SaqueDe(400);

            Exception ex = Assert.Throws<Exception>(act);
            Assert.Equal("Não tem saldo suficiente para o saque", ex.Message);
        }

        [Fact]
        public void Deve_sacar_quantidade_minima_de_notas_para_o_valor_digitado()
        {
            var saldoDoCaixa = new Dictionary<int, int>
            {
            { 100, 2 },
            { 50, 3 },
            { 20, 1 },
            { 10, 2 }
            };

            var valorEsperado = new Dictionary<int, int>() { { 100, 1 }, { 50, 1 }, {20, 1} };
            var resultado = new CaixaEletronico(saldoDoCaixa).SaqueDe(170);

            Assert.Equal(valorEsperado, resultado);
        }
    }
}