using System;
using System.Collections.Generic;
using System.Linq;

namespace Acronymizer
{
	/*
	 * I would do the extension for user defined symbols either like this with static method and configuration or with functional approach.
	 * My createAcronym would have function as parameter. This function would be called on every split string so that user can replace symbols on his own.
	 */
	public static class AcronymParser
	{
		public static string CreateAcronym(string input, IEnumerable<char> splitOpts = null,
			IEnumerable<(string ReplaceWord, string ReplaceWith)> replaceOpts = null)

		{
			if (string.IsNullOrEmpty(input))
			{
				return input;
			}

			replaceOpts = replaceOpts ?? new List<(string ReplaceWord, string ReplaceWith)>();
			splitOpts = splitOpts ?? new[] {' ', '-'};

			return input.Split(splitOpts.ToArray(), StringSplitOptions.RemoveEmptyEntries)
				.Select(str =>
					replaceOpts.Aggregate(str, (acc, opt) =>
						acc.Replace(opt.ReplaceWord, opt.ReplaceWith))
				)
				.Aggregate("", (acc, word) => acc + char.ToUpper(word[0]));
		}
	}
}