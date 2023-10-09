using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
	class Program
	{
		static void Factorial(int x)
		{
			Console.WriteLine($"Star calculation faxtorial {x} ");
			int result = 1;
			for (int i = 1; i <= x; i++)
				result *= i;
			Thread.Sleep(3000);
			Console.WriteLine($"Finish calculation factorial {x}.");
			Thread.Sleep(3000);
			Console.WriteLine($"Result { result}");
		}

		static void Main(string[] args)
		{
			Parallel.Invoke(() => Factorial(10),
						 () => Console.WriteLine("_______________________________")
						 );
		}
	}
}
