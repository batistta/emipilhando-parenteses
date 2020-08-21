using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verifica_parenteses_pilha
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "";
            bool valida = true;
            Console.WriteLine("digite math:");
            x = Console.ReadLine();
            //Verifica_Pilha_Din(x);
            valida = Verifica_Pilha_est(x);
            if(!valida)
                Console.WriteLine("ERRADO");
            else
                Console.WriteLine("certo");
                    
            Console.ReadKey();
        }
        static bool Verifica_Pilha_est(string x)
        {
            Pilha_est p = new Pilha_est(x.Length);
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == '(')
                {
                    p.Empilhar(1);
                }
                else if (x[i] == ')')
                {
                    if (p.Vazia())
                        return false;

                    p.Desempilhar();
                }
            }

            if (p.Vazia())
                return true;
            else
                return false;
        }
        //static void Verifica_Pilha_Din(string x)
        //{
        //    PilhaDinamica P1 = new PilhaDinamica();
        //    for (int i = 0; i < x.Length; i++)
        //    {
        //        if (x[i] == '(')
        //            P1.Empilhar(1);
        //        else if (x[i] == ')')
        //        {
        //            if (P1.Vazia())
        //            {
        //                Console.WriteLine("Fórmula incorreta!!!");
        //                Console.ReadKey();
        //                Environment.Exit(1);
        //            }
        //            else
        //                P1.Desempilhar();

        //        }
        //    }
        //    if (P1.Vazia())
        //        Console.WriteLine("formula correta!");
        //    else
        //        Console.WriteLine("fórmula incorreta!");
        //}
        class Pilha_est
        {
            private int[] dados;
            private int topo;
            private int MAX;

            public Pilha_est(int n)
            {
                dados = new int[n];
                MAX = n;
                topo = 0;
            }

            public void Empilhar(int dado)
            {
                if (topo < MAX)
                {
                    dados[topo] = dado;
                    topo++;
                }
                else
                {
                    Console.WriteLine("Pilha Cheia!!!");
                }
            }

            public int Desempilhar()
            {
                if (Vazia())
                {
                    Console.WriteLine("Pilha Vazia!");
                    return -1;
                }
                else
                {
                    topo--;
                    return dados[topo];

                }
            }

            public int Tamanho()
            {
                return topo;
            }

            public bool Vazia()
            {
                return topo == 0;
            }

            public void Imprimir()
            {
                for (int i = topo - 1; i >= 0; i--)
                    Console.WriteLine(dados[i]);
            }
        }

        class Celula
        {
            public int dado { get; set; }
            public Celula prox { get; set; }
        }

        class PilhaDinamica
        {
            private Celula topo;
            private int tam;

            public PilhaDinamica()
            {
                topo = null;
                tam = 0;
            }

            public void Empilhar(int dado)
            {
                Celula temp = new Celula();
                temp.dado = dado;
                temp.prox = topo;
                topo = temp;
                tam++;
            }
            public int Tamanho()
            {
                return tam;
            }

            public bool Vazia()
            {
                return topo == null;
            }

            public int Desempilhar()
            {
                if (Vazia())
                {
                    Console.WriteLine("Pilha Vazia!");
                    return -1;
                }

                int dado = topo.dado;
                topo = topo.prox;
                tam--;
                return dado;
            }
        }
    }
}
