﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Acronymizer
{
	public class AcronymParser
	{
		public List<(string ReplaceWord, string ReplaceWith)> ReplaceOpts { get; private set; }
		public List<char> SplitOps { get; private set; }

		public AcronymParser(List<char> splitOpts = null,
			List<(string ReplaceWord, string ReplaceWith)> opts = null)
		{
			SplitOps = splitOpts ?? new List<char> {' ', '-'};
			ReplaceOpts = opts ?? new List<(string , string )>();
		}


		private IEnumerable<string> ParseWords(string input) =>
			input.Split(SplitOps.ToArray()).Select(str =>
				ReplaceOpts.Aggregate(str, (acc, opt) =>
					acc.Replace(opt.ReplaceWord, opt.ReplaceWith))
			);


		public string CreateAcronym(string str) =>
			string.IsNullOrEmpty(str)
				? str
				: ParseWords(str)
					.Aggregate("", (acc, word) => acc + char.ToUpper(word[0]));
	}
}