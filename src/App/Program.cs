using System;
using System.Collections.Generic;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var saldoDoCaixa = new Dictionary<int, int>
            {
            { 100, 3 },
            { 50, 1 },
            { 20, 0 },
            { 10, 0 }
            };

            var caixaEletronico = new CaixaEletronico(saldoDoCaixa);

            var resultado = caixaEletronico.SaqueDe(Convert.ToInt32(args[0]));

            foreach (var item in resultado)
            {
                Console.WriteLine(item.Value + "x " + item.Key);
            }
            
        }
    }
}
