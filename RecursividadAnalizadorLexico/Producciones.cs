using System;
using System.Collections.Generic;
using System.Text;

namespace RecursividadAnalizadorLexico
{
    public static class Producciones
    {

         
        public static List<(string, string[][])> getProducciones()
        {
            (string, string[][])[] array = new (string, string[][])[5];
            array[0] = ("E", new string[][]
            {
                new string[] {"T","D"}
            });
            array[1] = ("D", new string[][]
            {
                new string[] {"+","T","D"},
                new string[] {"-","T","D"},
                new string[] { ""}
            });
            array[2] = ("T", new string[][]
            {
                new string[] {"F","P"}
            });
            array[3] = ("P", new string[][]
            {
                new string[] {"*","F","P"},
                new string[] { "/","F","P"},
                new string[] { ""}
            });
            array[4] = ("F", new string[][]
            {
                new string[] {"(","E",")"},
                new string[] {"num"},
                new string[] {"id"}

            });


            List<(string, string[][])> array2 = new List<(string, string[][])>() ;
            array2.Add(array[0]);
            array2.Add(array[1]);
            array2.Add(array[2]);
            array2.Add(array[3]);
            array2.Add(array[4]);


            return array2;

        }






    }
}
