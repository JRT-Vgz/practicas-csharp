
using Consola;
using System.Numerics;
using System.Threading.Channels;

Console.WriteLine("Ingrese un numero");
int num1 = int.Parse(Console.ReadLine());

Console.WriteLine("Ingrese un numero");
int num2 = int.Parse(Console.ReadLine());

var calculator = new Calculator();

Console.WriteLine($"Total: {calculator.Sum(num1, num2)}");