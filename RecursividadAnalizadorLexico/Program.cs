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
            string[] str = new string[] { "num", "+", "id", "*", "num" };
            //List<(string, List<List<string>>)> lista = a.getProducciones();
            recorrer("T'", str);

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
        static public bool recorrer(string from,string[] cadena ) 
        {
            List<(string, string[][])> array = Producciones.getProducciones();
            (string, string[][]) res = array.Find(res=> res.Item1 == from);

            string[][] sublista = res.Item2;

            bool validado = false;

            Console.WriteLine($"length : [{sublista.Length}]");
            Console.WriteLine($"get length 0 : [{sublista.GetLength(0)}]");
            Console.WriteLine($"get length 1 : [{sublista[0].GetLength(0)}]");
            
            //Going through all de chain to analize
            //for (int k =0; k< cadena.Length; k ++)
            //{
                
            bool encontrado = false;
            bool val = true;

            //This goes between or |, +AB|b|..
            for (int i = 0; i < sublista.Length; i++)
            {
                    val = true;
                    //This goes inside each or ,like  "+","A","B"
                    for (int j = 0; j < sublista[i].Length; j++)
                    {
                        //when it is lambda
                        if (sublista[i][j] == null | sublista[i][j] == "")
                        {
                            return val;

                        }
                        else 
                        {
                            
                            if (isUpper(sublista[i][j]))
                            {
                                val = val & recorrer(sublista[i][j], cadena);

                            }
                            else
                            {
                                if (sublista[i][j] == cadena[k])
                                {
                                    encontrado = true;
                                    k = k + 1;
                                    return encontrado;
                                }
                                else
                                {
                                    break;
                                }

                            }

                        }
               
                     }


            }


            

            return val;

                


           // }

            ///aca los return 
        }

    }
}
