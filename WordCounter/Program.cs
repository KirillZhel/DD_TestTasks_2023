using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WordCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "input.txt";
            var dict = new Dictionary<string, int>();
            dict = Task(path);
            dict.Remove("");
            dict.Remove("'");
            foreach (var item in dict) 
            {
                Console.WriteLine($"{item.Value}\t{item.Key}");
            }

            //Console.WriteLine($"ПУСТАЯ СТРОКА ВСТРЕЧАЕТСЯ {dict[""]} РАЗ");
        }

        public static Dictionary<string, int> Task(string path)
        {
            var dict = new Dictionary<string, int>();

            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    ProcessString(line, dict);
                }
            }

            return dict;
        }

        private static void ProcessString(string line, Dictionary<string, int> dict)
        {
            line = line.Trim();
            string pattern = @"[\d\s,\.\)\(\[\]{}\-@~!#$%^&*_+=\\\/№;:\?<>\" + "\"]";
            RegexOptions options = RegexOptions.Multiline;
            Regex regex = new Regex(pattern, options);
            var matches = regex.Split(line);

            var tmpWord = "";
            foreach (var item in matches) 
            {
                tmpWord = item.ToLower();
                if(!dict.ContainsKey(tmpWord)) dict.Add(tmpWord, 0);
                dict[tmpWord] += 1;
            }
        }
    }
}