
using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public class CaixaEletronico
    {
        Dictionary<int, int> NotasDisponiveisNoCaixa = new Dictionary<int, int> {
            { 100, 1 },
            { 50, 2 },
            { 20, 0 },
            { 10, 0 }
        };
        Dictionary<int, int> ResultadoDoSaque;
        public CaixaEletronico(Dictionary<int, int> saldoDoCaixa)
        {
            NotasDisponiveisNoCaixa = saldoDoCaixa;
            ResultadoDoSaque = new Dictionary<int, int>();
        }

        public Dictionary<int, int> SaqueDe(int valorDoSaque)
        {
            if (valorDoSaque < 10)
            {
                throw new Exception("Saque mínimo é de 10");
            }

            while (TemDisponivel(valorDoSaque))
            {
                if (valorDoSaque >= 100 && TemQuantidadeSuficienteDe(100))
                {
                    ObterDoCaixaNota(100);
                    valorDoSaque -= 100;
                    SacarDoCaixaNota(100);

                }

                else if (valorDoSaque >= 50 && TemQuantidadeSuficienteDe(50))
                {
                    ObterDoCaixaNota(50);
                    valorDoSaque -= 50;
                    SacarDoCaixaNota(50);
                }

                else if (valorDoSaque >= 20 && TemQuantidadeSuficienteDe(20))
                {
                    ObterDoCaixaNota(20);
                    valorDoSaque -= 20;
                    SacarDoCaixaNota(20);
                }

                else if (valorDoSaque >= 10 && TemQuantidadeSuficienteDe(10))
                {
                    ObterDoCaixaNota(10);
                    valorDoSaque -= 10;
                    SacarDoCaixaNota(10);
                }

                else
                {
                    throw new Exception("Não tem nota suficiente para o saque");
                }
            }
            if (!ResultadoDoSaque.Any())
            {
                throw new Exception("Não tem saldo suficiente para o saque");
            }
            return ResultadoDoSaque;
        }

        private bool TemQuantidadeSuficienteDe(int nota)
        {
            return NotasDisponiveisNoCaixa.Any(x => x.Key == nota && x.Value > 0);
        }

        public void ObterDoCaixaNota(int valorDaNota)
        {
            if (ResultadoDoSaque.ContainsKey(valorDaNota))
            {
                ResultadoDoSaque[valorDaNota]++;
            }
            else
            {
                ResultadoDoSaque.Add(valorDaNota, 1);
            }
        }

        public void SacarDoCaixaNota(int valorDaNota)
        {
            if (NotasDisponiveisNoCaixa.ContainsKey(valorDaNota))
            {
                NotasDisponiveisNoCaixa[valorDaNota]--;
            }
        }

        public bool TemDisponivel(int valorDoSaque)
        {
            int saldoDisponivel = NotasDisponiveisNoCaixa.Sum(x => x.Key * x.Value);

            return valorDoSaque > 0 && valorDoSaque <= saldoDisponivel;
        }
    }
}