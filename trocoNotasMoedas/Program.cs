using System;
using System.Globalization;

namespace trocoNotasMoedas
{
    internal class Program
    {
        public static void TrocoDeNotas(int[] notas,int valorNota)
        {
            int[] trocosNota = new int[] { 100, 50, 20, 10, 5, 2, 1 };

            for (int i = 0; i < 7; i++)
            {
                notas[i] = valorNota / trocosNota[i];
                valorNota = valorNota % trocosNota[i] ;
            }
        }
        public static void TrocoDeMoedas(int[] moedas, int valorMoeda,int[] notas)
        {
            int[] trocosMoeda = new int[] { 50, 25, 10, 5, 1, 1 };
            moedas[0] = notas[6];

            for (int i = 1; i < 6; i++)
            {
                moedas[i] = valorMoeda / trocosMoeda[i-1];
                valorMoeda = valorMoeda % trocosMoeda[i-1];
            }
        }
        public static void TrocosPossiveis(int valorMoeda, int[] notas, int[] moedas, string valores)
        {
            double[] trocosMoeda = new double[] { 1.00, 0.50, 0.25, 0.10, 0.05, 0.01 };
            int[] trocosNota = new int[] { 100, 50, 20, 10, 5, 2, 1 };

            Console.WriteLine($"Troco total de {valores} reais");

            Console.WriteLine("NOTAS:");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{notas[i]} nota(s) de R$ {trocosNota[i].ToString("F2", CultureInfo.InvariantCulture)}");
            }
            if (valorMoeda == 0)
            {
                Console.WriteLine($"{moedas[0]} moeda(s) de R$ {trocosMoeda[0].ToString("F2", CultureInfo.InvariantCulture)}");
            }

            if (valorMoeda > 0)
            {
                Console.WriteLine("MOEDAS:");
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine($"{moedas[i]} moeda(s) de R$ {trocosMoeda[i].ToString("F2", CultureInfo.InvariantCulture)}");
                }
            }
        }
        public static void letreiro()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("   T R O C O   N O T A S   E   M O E D A S   ");
            Console.WriteLine("---------------------------------------------");
        }
        static void Main(string[] args)
        {
            int[] notas = new int[7];
            int[] moedas = new int[6];

            string escolha;

            do
            {
                letreiro();
                Console.Write("Digite o valor que gostaria de saber o troco: R$ ");
                string valores = Console.ReadLine();

                string[] totalValor = valores.Split('.');

                int tamanho = totalValor.Length;
                int valorNota = 0;
                int valorMoeda = 0;

                if (tamanho > 1)
                {
                    valorNota = int.Parse(totalValor[0]);
                    valorMoeda = int.Parse(totalValor[1]);
                }
                else
                {
                    valorNota = int.Parse(totalValor[0]);
                }

                Console.Clear();

                TrocoDeNotas(notas, valorNota);
                TrocoDeMoedas(moedas, valorMoeda, notas);
                letreiro();
                TrocosPossiveis(valorMoeda, notas, moedas,valores);

                Console.WriteLine();
                Console.Write("Quer usar novamente [S/N]: ");
                escolha = Console.ReadLine();

                while (escolha != "N" && escolha != "S")
                {
                    Console.WriteLine("ERRO!! escolha novamente");
                    Console.Write("Quer usar novamente [S/N]: ");
                    escolha = Console.ReadLine();
                }

                Console.Clear();

            } while (escolha == "S" || escolha == "s");
            Console.ReadKey();
        }
    }
}
