using System;
using System.Collections.Generic;

namespace RecursividadAnalizadorLexico
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //string str = "num+id*num";
            string[] str = new string[] { "num", "+", "id","*","+","num"  };
            //List<(string, List<List<string>>)> lista = a.getProducciones();
            bool re = recorrer("E", str);
            Console.WriteLine($"la cadena es valida?: [{re}]");


        }

        static public bool isUpper(string a)
        {
            bool valido = true;
            foreach (char letra in a)
            {
                if (!char.IsUpper(letra))
                {
                    valido = false;
                }
            
            }
            return valido;
        
        }

        static int k = 0;
        static List<bool> listaValidacion = new List<bool>();
        static public bool recorrer(string from,string[] cadena ) 
        {
            List<(string, string[][])> array = Producciones.getProducciones();
            (string, string[][]) res = array.Find(res=> res.Item1 == from);

            string[][] sublista = res.Item2;

            bool validado = false;

            
            
            //Going through all de chain to analize
            //for (int k =0; k< cadena.Length; k ++)
            //{
                
            bool encontrado = false;
            bool val = true;

            Console.WriteLine($" ============ DENTRO DE METODO =============");

            if (k+1 == cadena.Length) 
            {

                return true;
            
            
            }


            //This goes between or |, +AB|b|..
            for (int i = 0; i < sublista.Length; i++)
            {
                Console.WriteLine($" ====FOR 1 == i :[{i}]  : [{String.Join('-',sublista[i])}]");
                val = true;
                    //This goes inside each or ,like  "+","A","B"
                for (int j = 0; j < sublista[i].Length; j++)
                {

                    Console.WriteLine($" ====FOR 2 == j:[{j}]  : [{sublista[i][j]}]");

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    //when it is lambda
                    if (sublista[i][j] == null | sublista[i][j] == "")
                    {

                        Console.WriteLine($"-> LAMBDA");
                        return val;

                    }
                    else 
                    {
                           
                        if (isUpper(sublista[i][j]))
                        {
                            Console.WriteLine($"-> ES NO TERMINAL/ MAYUSCULA");
                            Console.ForegroundColor = ConsoleColor.White;
                            val = val && recorrer(sublista[i][j], cadena);
                            encontrado = val;
                            if (!val )                            
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"-> ES TERMINAL");
                            Console.WriteLine($" valor cadena : [{cadena[k]}]");
                            if (sublista[i][j] == cadena[k])
                            {
                                
                                Console.WriteLine($"-> SON IGUALES A LA CADENA");
                                k = k + 1;
                                listaValidacion.Add(true);
                                // if it is the only one
                                if (j + 1 == sublista[i].Length)
                                {
                                    return true;
                                }
                                    
                            }
                            else
                            {
                                Console.WriteLine($"->NOO SON IGUALES A LA CADENA");
                                break;
                            }

                        }

                    }

                    Console.ForegroundColor = ConsoleColor.White;

                }

                if (encontrado)
                {
                    Console.WriteLine($"->encontrado es true");
                    return encontrado;
                }


            }

            Console.WriteLine($"->es faaalse");
            return false;

                


           // }

            ///aca los return 
        }

    }
}
