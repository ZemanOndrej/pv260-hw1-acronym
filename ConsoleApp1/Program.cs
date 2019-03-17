using System;
using Acronymizer;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(AcronymParser.CreateAcronym("Asynchronous Javascript and XML"));
		}
	}
}