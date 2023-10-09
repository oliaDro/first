using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examen
{
	internal class Program
	{
		public static BlockingCollection<int> Numbers { get; set; } = new BlockingCollection<int>();

		public static Random Random { get; set; } = new Random();

		static void Main(string[] args)
		{
			Task.Run(() => { Console.WriteLine("test thread"); });
			Run();
		}

		public static async Task Run()
		{
			await Console.Out.WriteLineAsync($"Task run in {Task.CurrentId}, start program");
			await TestFill();
			Task.Run(() => FindMax());
			Task.Run(() => FindMin());
			Task.Run(() => FindAvg());
			Console.ReadLine();
		}

		public static async Task TestFill()
		{
			await Console.Out.WriteLineAsync($"Task run in {Task.CurrentId}");

			for (int i = 0; i <= 1000; i++)
			{
				Numbers.Add(Random.Next(0, 5000));
			}

			await Console.Out.WriteLineAsync($"Fill finished ");
		}

		public static void FindMax()
		{
			Console.WriteLine($"Task findmax is {Task.CurrentId}");
			var max = Numbers.Max();
			Console.WriteLine($"Max is {max}");
		}
		public static void FindMin()
		{
			Console.WriteLine($"Task findmin is {Task.CurrentId}");
			var min = Numbers.Min();
			Console.WriteLine($"Min is {min}");
		}

		public static void FindAvg()
		{
			Console.WriteLine($"Task findAvg is {Task.CurrentId}");
			var avg = Numbers.Average();
			Console.WriteLine($"Average is {avg}");
		}

	}
}
