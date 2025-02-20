using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static List<string> historico = new List<string>();
        
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Opções");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Divisão");
            Console.WriteLine("4 - Multiplicação");
            Console.WriteLine("5 - Raiz Quadrada");
            Console.WriteLine("6 - Módulo");
            Console.WriteLine("7 - Raiz Cúbica");
            Console.WriteLine("8 - Mostrar Histórico");
            Console.WriteLine("0 - Sair");
            
            Console.WriteLine("--------------");
            Console.Write("Selecione uma opção: ");
            
            if (short.TryParse(Console.ReadLine(), out short res))
            {
                switch (res)
                {
                    case 1: Soma(); break;
                    case 2: Subtracao(); break;
                    case 3: Divisao(); break;
                    case 4: Multiplicacao(); break;
                    case 5: RaizQuadrada(); break;
                    case 6: Modulo(); break;
                    case 7: RaizCubica(); break;
                    case 8: MostrarHistorico(); break;
                    case 0: Environment.Exit(0); break;
                    default: Menu(); break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida! Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Menu();
            }
        }

        static void Soma()
        {
            ExecutarOperacao("Soma", (a, b) => a + b);
        }

        static void Subtracao()
        {
            ExecutarOperacao("Subtração", (a, b) => a - b);
        }

        static void Divisao()
        {
            ExecutarOperacao("Divisão", (a, b) => b != 0 ? a / b : float.NaN, "Não é possível dividir por zero!");
        }

        static void Multiplicacao()
        {
            ExecutarOperacao("Multiplicação", (a, b) => a * b);
        }

        static void Modulo()
        {
            ExecutarOperacao("Módulo", (a, b) => a % b);
        }

        static void RaizQuadrada()
        {
            Console.Clear();
            Console.Write("Digite o número para calcular a raiz quadrada: ");
            if (float.TryParse(Console.ReadLine(), out float numero))
            {
                float resultado = (float)Math.Sqrt(numero);
                Console.WriteLine($"O resultado da raiz quadrada é: {resultado}");
                historico.Add($"Raiz Quadrada: √{numero} = {resultado}");
            }
            else
            {
                Console.WriteLine("Entrada inválida!");
            }
            Console.ReadKey();
            Menu();
        }

        static void RaizCubica()
        {
            Console.Clear();
            Console.Write("Digite o número para calcular a raiz cúbica: ");
            if (float.TryParse(Console.ReadLine(), out float numero))
            {
                double resultado = Math.Cbrt(numero);
                Console.WriteLine($"O resultado da raiz cúbica é: {resultado}");
                historico.Add($"Raiz Cúbica: ∛{numero} = {resultado}");
            }
            else
            {
                Console.WriteLine("Entrada inválida!");
            }
            Console.ReadKey();
            Menu();
        }

        static void MostrarHistorico()
        {
            Console.Clear();
            Console.WriteLine("📜 Histórico de Cálculos:");

            if (historico.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum cálculo foi realizado ainda.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var item in historico)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ResetColor();

            Console.ReadKey();
            Menu();
        }

        static void ExecutarOperacao(string nome, Func<float, float, float> operacao, string erroDivisao = "")
        {
            Console.Clear();
            Console.Write("Primeiro Valor: ");
            if (float.TryParse(Console.ReadLine(), out float v1))
            {
                Console.Write("Segundo Valor: ");
                if (float.TryParse(Console.ReadLine(), out float v2))
                {
                    float resultado = operacao(v1, v2);
                    if (float.IsNaN(resultado))
                    {
                        Console.WriteLine(erroDivisao);
                    }
                    else
                    {
                        Console.WriteLine($"Resultado da {nome}: {resultado}");
                        historico.Add($"{nome}: {v1} e {v2} = {resultado}");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida!");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida!");
            }
            Console.ReadKey();
            Menu();
        }
    }
}
