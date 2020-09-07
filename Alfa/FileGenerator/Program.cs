using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceList = RandomList(0.00001M, 100, 1000);

            SaveListIntoFile(priceList);
        }

        private static List<decimal> RandomList(decimal min, int max, int totalNumber)
        {
            return Enumerable.Range(0, totalNumber)
                     .Select(i => Math.Round(min + (max - min) * ((decimal)i / (totalNumber - 1)), 5))
                     .ToList();
        }

        public static void Shuffle<T>(IList<T> list)
        {
            Random random = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private static void SaveListIntoFile(List<decimal> priceList)
        {
            string path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PriceFile.csv");
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Shuffle<decimal>(priceList);

            File.AppendAllLines(path, priceList.Select(item => item.ToString()));
        }
    }
}
