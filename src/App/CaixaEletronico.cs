
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
        Dictionary<int, int> ResultadoDoSaque = new Dictionary<int, int>();

        public CaixaEletronico(Dictionary<int, int> saldoDoCaixa)
        {
            NotasDisponiveisNoCaixa = saldoDoCaixa;
        }

        public Dictionary<int, int> saqueDe(int valorDoSaque)
        {
            while (TemDisponivel(valorDoSaque))
            {
                if (valorDoSaque > 0 && valorDoSaque % 10 == 0)
                {
                    if (valorDoSaque >= 100 &&
                     NotasDisponiveisNoCaixa.Any(x => x.Key == 100 && x.Value > 0))
                    {
                        ObterDoCaixaNota(100);
                        valorDoSaque -= 100;
                        SacarDoCaixaNota(100);
                    }

                    else if (valorDoSaque >= 50 &&
                     NotasDisponiveisNoCaixa.Any(x => x.Key == 50 && x.Value > 0))
                    {
                        ObterDoCaixaNota(50);
                        valorDoSaque -= 50;
                        SacarDoCaixaNota(50);
                    }

                    else if (valorDoSaque >= 20 &&
                     NotasDisponiveisNoCaixa.Any(x => x.Key == 20 && x.Value > 0))
                    {
                        ObterDoCaixaNota(20);
                        valorDoSaque -= 20;
                        SacarDoCaixaNota(20);
                    }

                    else if (valorDoSaque >= 10 &&
                     NotasDisponiveisNoCaixa.Any(x => x.Key == 10 && x.Value > 0))
                    {
                        ObterDoCaixaNota(10);
                        valorDoSaque -= 10;
                        SacarDoCaixaNota(10);
                    }
                }
            }

            return ResultadoDoSaque;
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
            return saldoDisponivel >= valorDoSaque;
        }
    }
}