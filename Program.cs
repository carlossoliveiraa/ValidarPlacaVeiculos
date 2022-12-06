using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace ValidaPlacaVeiculos
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            List<Garagem> listaGaragens = new List<Garagem>();

            var garagem1 = new Garagem { Id = 1, DataEntrada = DateTime.Now, Placa = "JQV-9141" };  // placa valida normal
            var garagem2 = new Garagem { Id = 2, DataEntrada = DateTime.Now, Placa = "000-9141" };  // invalida normal
            var garagem3 = new Garagem { Id = 3, DataEntrada = DateTime.Now, Placa = "AbC-921" };   // invalida normal
            var garagem4 = new Garagem { Id = 4, DataEntrada = DateTime.Now, Placa = "RUV6E13" };   // valida mercosul

            listaGaragens.Add(garagem1);
            listaGaragens.Add(garagem2);
            listaGaragens.Add(garagem3);
            listaGaragens.Add(garagem4);

            var listanova = (listaGaragens.Where(garagem => validadordePlacas(garagem.Placa))).ToList();

            Console.ReadKey();
        }

        public class Garagem
        {
            public int Id { get; set; }
            public DateTime DataEntrada { get; set; }
            public string Placa { get; set; }
        }

        private static bool validadordePlacas(string placa)     
        {
            if (string.IsNullOrWhiteSpace(placa)) { return false; }

            if (placa.Length > 8) { return false; }

            placa = placa.Replace("-", "").Trim();

          
            if (char.IsLetter(placa, 4))
            {                
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(placa);
            }
            else
            {               
                var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoNormal.IsMatch(placa);
            }
        }
    }
}
