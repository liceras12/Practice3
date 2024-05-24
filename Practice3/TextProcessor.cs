using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
     class TextProcessor
    {
        public event EventHandler ProcessingCompleted;

        public void ProcessText(string filePath)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                OnProcessingCompleted(EventArgs.Empty, content);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file was not found");
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while processing the file");
            }
        }

        private int CountWords(string text)
        {
            var words = text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        private Dictionary<char, int> CalculateCharFrequency(string text)
        {
            return text.Where(char.IsLetter)
                .GroupBy(char.ToLower)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        private string FindLongestWord(string text)
        {
            var words = text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return words.OrderByDescending(w => w.Length).First();
        }

        protected virtual void OnProcessingCompleted(EventArgs e, string content)
        {
            ProcessingCompleted?.Invoke(this, e);
        }

    }

    public class ResultDisplayer
    {
        public void Subscribe(TextProcessor textProcessor)
        {
            textProcessor.ProcessingCompleted += TextProcessor_ProcessingCompleted;
        }
        private void TextProcessor_TextProcessingCompleted(object sender, EventArgs e)
        {
            if(sender is TextProcessor processor && e is EventArgs args)
            {
                string text = 
            }

            Console.WriteLine($"Word count: {e.CountWords}");
            Console.WriteLine("Character frequency:");
            foreach (var pair in e.CharFrequency)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
            Console.WriteLine($"Longest word: {e.LongestWord}");
        }
    }
}
