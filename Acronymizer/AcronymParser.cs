using System;
using System.Collections.Generic;
using System.Linq;

namespace Acronymizer
{
	/*
	 * Functional method
	 */
	public static class AcronymParser
	{
		public static string CreateAcronym(string input, IEnumerable<char> splitOpts = null,
			Func<string, string> processString = null)

		{
			if (string.IsNullOrEmpty(input))
			{
				return input;
			}

			splitOpts = splitOpts ?? new[] {' ', '-'};
			processString = processString ?? (str => str);

			return input.Split(splitOpts.ToArray(), StringSplitOptions.RemoveEmptyEntries)
				.Select(str => processString(str))
				.Aggregate("", (acc, word) => acc + char.ToUpper(word[0]));
		}
	}
}