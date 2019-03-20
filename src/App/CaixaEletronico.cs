
using System.Collections.Generic;

namespace App
{
    public class CaixaEletronico
    {
        Dictionary<int, int> notasDisponiveis = new Dictionary<int, int> { { 10, 10 } };
        Dictionary<int, int> resultadoEsperado = new Dictionary<int, int>();
        public Dictionary<int, int> saqueDe(int valorDoSaque)
        {
            while (valorDoSaque > 0)
            {
                if (valorDoSaque == 10)
                {
                    SacarNota(10);
                    valorDoSaque -=  10;
                }
            }
            return resultadoEsperado;
        }

        private void SacarNota(int valorDaNota)
        {
            if (resultadoEsperado.ContainsKey(valorDaNota))
            {
                resultadoEsperado[valorDaNota]++;
            }
            else
            {
                resultadoEsperado.Add(notasDisponiveis[valorDaNota], 1);
            }
        }
    }
}