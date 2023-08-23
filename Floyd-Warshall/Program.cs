using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floyd_Warshall
{
    class Program
    {
        public static int[,] Floyd(int[,] Ady) //funcion que devuelve la matriz del algoritmo de floyd warshall
        {
            int i, j, k;
            for (i = 0; i < Ady.GetLength(0); i++)
                for (j = 0; j < Ady.GetLength(0); j++)
                    for (k = 0; k < Ady.GetLength(1); k++)
                        if ((Ady[j, i] + Ady[i, k]) < Ady[j, k])
                            Ady[j, k] = Ady[j, i] + Ady[i, k];
            return Ady;
        }

        public static void Imprimir(int[,] arr) //Funcion para imprimir un arreglo bidimensional
        {
            int i, j;

            for (i = 0; i < arr.GetLength(0); i++)
            {
                for (j = 0; j < arr.GetLength(1); j++)
                    Console.Write("[{0}]  ", arr[i, j]);

                Console.WriteLine();
            }
        }
        
        static void Main(string[] args)
        {
            int inf = 9999999; //variable que actua como infinito

            int[,] prueba = new int[,] {
                    {0,3,5,1,inf,inf,4,inf},
                    {3,0,inf,inf,9,inf,7,inf},
                    {5,inf,0,7,7,1,inf,2},
                    {1,inf,7,0,inf,4,3,5},
                    {inf,9,7,inf,0,inf,9,1},
                    {inf,inf,1,4,inf,0,3,5},
                    {inf,inf,1,4,inf,8,0,inf},
                    {inf,inf,1,4,inf,3,7,0} };   //Matriz de prueba

            int[,] Matriz; //matriz que almacena la matriz ingresada por el usuario y tambien la respuesta
            int i,j,x;
            string valor;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Cuántos vértices?: ");
            x = int.Parse(Console.ReadLine());
            Matriz = new int[x, x];

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingrese los valores (\"inf\" para infinito)");

            for(i=0;i<Matriz.GetLength(0);i++)  //Se llena la matriz con datos ingresados por el usuario
                for(j=0;j<Matriz.GetLength(1);j++)
                {
                    Console.Write("[{0},{1}]---> ",i,j);
                    valor = Console.ReadLine().ToLower();

                    if (valor == "inf")
                        Matriz[i, j] = inf;
                    else
                        Matriz[i, j] = int.Parse(valor);
                }

            Matriz = Floyd(prueba); //Se llama a la funcion Floyd para que devuelva la respuesta

            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Imprimir(Matriz);

            Console.ReadKey();
        }
    }
}
