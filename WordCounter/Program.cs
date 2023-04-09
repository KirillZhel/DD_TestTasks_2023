namespace WordCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static void Task()
        {
            char[] buffer = new char[104857600];
            string text = "";
            FileStream fstream = new FileStream("document.txt", FileMode.Open, FileAccess.Read);
            using (var sr = new StreamReader(fstream))
            {
                int bytesRead = 0;
                while ((bytesRead = sr.Read(buffer, 0, buffer.Length)) > 0)
                {
                    text = new string(buffer);
                    // обработка текста
                }
            }
        }
    }
}