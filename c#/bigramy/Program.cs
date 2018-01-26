using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace Zadania
{
	class MainClass
	{
		static List<string> alphabet = "abcdefghijklmnoprstuwxyz".Select(c => c.ToString()).ToList();

		static string RemoveDiacritics(string text) 
		{
			var normalizedString = text.Normalize(NormalizationForm.FormD);
			var stringBuilder = new StringBuilder();

			foreach (var c in normalizedString)
			{
				var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
				if (unicodeCategory != UnicodeCategory.NonSpacingMark)
				{
					stringBuilder.Append(c);
				}
			}

			return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
		}

		static List<string> GenerateBigrams() 
		{
			List<string> bigrams = new List<string>();

			foreach (string l1 in alphabet) {
				foreach (string l2 in alphabet) {
					bigrams.Add (l1 + l2);
				}
			}

			return bigrams;
		}

		static List<KeyValuePair<string, int>> Frequency(string text, List<string> substr)
		{
			List<KeyValuePair<string, int>> frequency = new List<KeyValuePair<string, int>> ();
			foreach (string b in substr) {
				int count = Regex.Matches (text, b).Count;
				frequency.Add (new KeyValuePair<string, int>(b, count));
			}

			return frequency;
		}

		static string ReadFile(string path)
		{
			try
			{   // Open the text file using a stream reader.
				using (StreamReader sr = new StreamReader(path))
				{
					// Read the stream to a string, and write the string to the console.
					return sr.ReadToEnd();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("The file could not be read:");
				Console.WriteLine(e.Message);
				return "";
			}
		}

		public static void Main (string[] args)
		{
			string text = ReadFile ("ang.txt").ToLower();
			string cleanText = RemoveDiacritics (text);
			List<string> bigrams = GenerateBigrams ();
			List<KeyValuePair<string, int>> freqBigrams = Frequency (cleanText, bigrams);
			List<KeyValuePair<string, int>> freqAlpha = Frequency (cleanText, alphabet);
		}
	}
}
