using System;
using System.IO;
using System.Linq;

namespace AlfaFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PriceFile.csv");

            var sumPrice = File
                 .ReadLines(path)
                 .Where(item => decimal.Parse(item) <= 10)
                 .Select(item => decimal.Parse(item))
                 .Sum();

            Console.WriteLine($"Сумма цен не превышающих 10.0 из csv файла составляет {sumPrice}.");

        }
    }
}
