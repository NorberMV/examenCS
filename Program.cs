using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_bucles
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Presentación programa
            Console.WriteLine("Juego del Ahorcadito!");

            // lista  de palabras a adivinar
            String[] palabras =
                {
                "Argentina",
                "Colombia",
                "Londres",
                "Canada",
                "Lima",
                };

         
            Console.Write("Ingrese 1 para adivinar la primer palabra: ");
            int jugar = int.Parse(Console.ReadLine());

            if (jugar == 1)
            {
                // Escoger palabra
                string palabra = escogerPalabra(palabras);

                // primer loop: Concatenamos el caracter '_' tantas veces como
                // la longitud de la palabra a adivinar y la asignamos a la variable
                // 'palabraAsignada'
                char[] palabraAdivinada = new char[palabra.Length];

                for (int i = 0; i < palabraAdivinada.Length; i++)
                {
                    palabraAdivinada[i] = '_';
                }

                int intentosRestantes = 4;
                bool gameOver = false;

                // Segundo loop 
                while (!gameOver)
                {
                    // Limpiar la pantalla cada iteración del while
                    Console.Clear();
                    // imprimir palabra a adivinar y el score actualizados
                    palabraAdivinadaScore(palabraAdivinada, intentosRestantes);

                    Console.WriteLine("Ingresa una letra: ");
                   char letra;
                    if (Char.TryParse(Console.ReadLine(), out letra))
                    {
                        //*********************************************
                        if (char.IsLetter(letra))
                        {

                            if (palabra.Contains(letra))
                            {
                                // Iteramos sobre la longitud de la palabra, para sobreescribir
                                // la variable 'palabraAdivinada' cada vez que haga match con la
                                // letra ingresada en el indice actual.
                                for (int i = 0; i < palabra.Length; i++)
                                {

                                    if (palabra[i] == letra)
                                    {
                                        palabraAdivinada[i] = letra;

                                    }
                                }
                            }

                            else
                            {
                                intentosRestantes--;
                                //*********************************************
                                Console.WriteLine("Letra incorrecta. Intentos restantes: " + intentosRestantes);
                            }
                        }
                        //*********************************************
                        else
                        {
                            Console.WriteLine("Por favor, ingresa una letra válida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Por favor, ingresa una letra válida.");
                    }
                    string palabraFinal = new string(palabraAdivinada);

                    // Condicion de terminar juego
                    gameOver = intentosRestantes == 0 || palabraFinal == palabra;
                    Console.WriteLine(palabraFinal);
                }
                
                if (gameOver == true)
                {
                    Console.Clear();
                    //*********************************************
                    if (intentosRestantes > 0)
                    {
                        Console.WriteLine($"Ganaste!, la palabra adivinada es {palabra}");
                    }
                    //*********************************************
                    else
                    {
                        Console.WriteLine($"¡Perdiste! La palabra correcta era '{palabra}'.");
                    }

                }

                // Final del programa ...
                Console.WriteLine();
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
             // Funcion escogerNombre:Escoge una palabra aleatoriamente de la lista pasada
             // como argumento.
            string escogerPalabra(string[] palabra)
            {
                string palabraElegida = palabra[new Random().Next(palabra.Length)];
                return palabraElegida;
            }

            void palabraAdivinadaScore(char[] palabraAdivinada, int intentosRestantes)
            {
                Console.WriteLine($"Palabra a adivinar: " + new string(palabraAdivinada));
                Console.WriteLine($"Intentos restantes: {intentosRestantes}");
            }
        }
    }
}

