using System;
using Acronymizer;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var parser = new AcronymParser();
			Console.WriteLine(parser.CreateAcronym("Asynchronous Javascript and XML"));
		}
	}
}