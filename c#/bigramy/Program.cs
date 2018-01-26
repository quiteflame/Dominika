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

		static List<KeyValuePair<string, float>> Frequency(string text, List<string> substr, int count)
		{
			List<KeyValuePair<string, float>> frequency = new List<KeyValuePair<string, float>> ();
			foreach (string b in substr) {
				float c = Regex.Matches (text, b).Count / (float)count * 100;
				frequency.Add (new KeyValuePair<string, float>(b, c));
			}

			return frequency.OrderByDescending(o => o.Value).ToList();
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

		static List<KeyValuePair<string, float>> PrepareLanguageFrequency(string path)
		{
			List<KeyValuePair<string, float>> list = new List<KeyValuePair<string, float>> ();
			foreach (string line in File.ReadLines(path)) 
			{
				string[] component = line.Split (';');
				string letter = component[0].ToLower().Trim();
				float freq = float.Parse(component[1].Trim());

				list.Add (new KeyValuePair<string, float>(letter, freq));
			}

			return list.OrderByDescending(o => o.Value).ToList();
		}

		static List<KeyValuePair<string, float>> PrepareLanguageMonoFrequency(string prefix)
		{
			return PrepareLanguageFrequency(prefix + "_mono.txt");
		}

		static List<KeyValuePair<string, float>> PrepareLanguageBiFrequency(string prefix)
		{
			return PrepareLanguageFrequency(prefix + "_bi.txt");
		}

		static float Find(List<KeyValuePair<string, float>> source, string value)
		{
			foreach (KeyValuePair<string, float> pair in source) {
				if (pair.Key == value) {
					return pair.Value;
				}
			}

			return 0;
		}

		static float DegreeOfDiff(List<KeyValuePair<string, float>> source, List<KeyValuePair<string, float>> target)
		{
			List<float> diff = new List<float>();

			foreach (KeyValuePair<string, float> pair in source) {
				diff.Add ((float)Math.Abs(pair.Value - Find(target, pair.Key)));
			}

			return diff.Sum () / source.Count * 100;
		}

		public static void Main (string[] args)
		{
			string prefix = "ang";
			string text = ReadFile (prefix + ".txt").ToLower();
			string cleanText = RemoveDiacritics (text);
			int numberOfLetters = cleanText.Count (char.IsLetter);
			int numberOfBigrams = numberOfLetters / 2;
			List<string> bigrams = GenerateBigrams ();
			List<KeyValuePair<string, float>> textFreqBigrams = Frequency (cleanText, bigrams, numberOfBigrams);
			List<KeyValuePair<string, float>> textFreqMono = Frequency (cleanText, alphabet, numberOfLetters);
			List<KeyValuePair<string, float>> languageFreqBigrams = PrepareLanguageBiFrequency (prefix);
			List<KeyValuePair<string, float>> languageFreqMono = PrepareLanguageMonoFrequency (prefix);

			float degreeOfDiffLetters = DegreeOfDiff (languageFreqMono, textFreqMono);
			Console.WriteLine ("Dla liter na " + (100 - degreeOfDiffLetters) + "% jezyk zgadza sie z przewidywaniami");

			float degreeOfDiffBigrams = DegreeOfDiff (languageFreqBigrams, textFreqBigrams);
			Console.WriteLine ("Dla bigramów na " + (100 - degreeOfDiffBigrams) + "% jezyk zgadza sie z przewidywaniami");
		}
	}
}
