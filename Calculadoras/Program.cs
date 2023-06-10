using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadoras
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int resultado, num2;
            char operacion;
            resultado = 0;
            bool continuar = false;  // PERMITE SALIDA DE BUCLES
            int num1 = 0;
            operacion = ' ';
            //*-----------------BUCLE - EXTERIOR - TERMINARÁ CUANDO SE ESCRIBA 's'
            while ((operacion != 's'))
            {

                //--- BUCLE-INTERMEDIO DE EXCEPCIONES: PARA NÚMERO N1 - CON TRY & CATCH
                while (continuar == false)
                {
                    try
                    {
                        Console.Write("Introduce un número:");
                        num1 = Convert.ToInt32(Console.ReadLine()); // N1_SOLO SE USARÁ UNA VEZ, LUEGO SE REEMPLAZA POR EL RESULTADO EN BUCLE INTERIOR
                        continuar = true;                   // si el numero ingresado es correcto, continuar será true y saldrá del bucle.          
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("--> Número incorrecto");
                    }
                };
                continuar = false; // Cuando sale del bucle debe volver a ser falso para los bucles while intermedios de excepciones en N1 Y N2.
                operacion = ' ';
                //*-----------------BUCLE interior
                while ((operacion != 's') && (operacion != '='))
                { // AQUI SE HARÁN LAS OPERACIONES ITERATIVAS, HASTA QUE SE ESCRIBA operacion sea dif a 's' y a 'o'
                    Console.Write("Introduce una operación:"); //PIDE OPERACIÓN
                    operacion = Convert.ToChar(Console.ReadLine().ToLower());

                    //--- BUCLE-INTERMEDIO DE EXCEPCIONES PARA OPERACIÓN: "default - iterativo"  SOLO PARA LA OPERACIÓN, PEDIRÁ HASTA QUE INGRESE UNO CORRECTO.
                    while ((operacion != '/') && (operacion != '*') && (operacion != '+') && (operacion != '-') && (operacion != '=') && (operacion != 's'))
                    {
                        Console.WriteLine("--> Operacion Incorrecta");
                        Console.Write("Introduce una operación:");
                        operacion = Convert.ToChar(Console.ReadLine());
                    };

                    // SI AL INTRODUCIR UNA OPERACION, ESTA ES IGUAL A '=' Ó 'S'
                    if ((operacion == '=') || (operacion == 's'))
                    {
                        break;
                    } // saldrá del bucle interior y continuará en el exterior

                    //--- BUCLE-INTERMEDIO DE EXCEPCIONES: PARA NÚMEROS N2 - CON TRY & CATCH
                    while (continuar == false)
                    {
                        try
                        { // EXCEPCION DE FORMATO PARA NÚMEROS
                            Console.Write("Introduce un número: "); //PIDE NUMERO
                            num2 = Convert.ToInt32(Console.ReadLine());
                            continuar = true; // si el numero ingresado es correcto, continuar será true y saldrá del bucle.
                                              // CUANDO SE INGRESE LA OPERACIÓN Y N2 CORRECTAMENTE,SE REALIZA LA OPERACIÓN
                            switch (operacion)
                            {
                                case '/':
                                    resultado = num1 / num2; break;
                                case '*':
                                    resultado = num1 * num2; break;
                                case '+':
                                    resultado = num1 + num2; break;
                                case '-':
                                    resultado = num1 - num2; break;
                            };
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("--> Número incorrecto");
                        }
                        catch (DivideByZeroException)
                        { // EXCEPCION PARA DIVISION ERRONEA DE CEROS
                            operacion = '='; // esto hará que vuelva a iniciar la calculadora                    
                            Console.WriteLine("--> No se puede dividir entre cero");
                        };
                    };
                    num1 = resultado; // Proxima iteración, el num1 tendrá el valor del resultado.
                    continuar = false; // Cuando sale del bucle debe volver a ser falso para los bucles while intermedios de excepciones en N1 Y N2.

                }; //*-----------------cierre bucle interior

                Console.Write("El resultado es {0}\n\n", resultado);
                resultado = 0;


            }; //*-----------------cierre bucle- exterior
            Console.Write("FIN DEL PROGRAMA");
        }
    }
}
