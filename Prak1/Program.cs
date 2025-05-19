using System;
using System.IO;

namespace prak1
{
    public class PRAK1
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь к файлу: ");
            string path = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Путь не может быть пустым");
                return;
            }
            Console.Write("Введите слово, которое надо найти: ");

            string word = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(word))
            {
                Console.WriteLine("Это поле не может быть пустым");
                return;
            }

            word = word.ToLower();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    int count = 0;

                    while ((line = sr.ReadLine()!) != null)
                    {

                        string lowerline = line.ToLower();

                        string[] words = lowerline.Split(new char[] { ' ', ',', '.', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var w in words)
                        {
                            if (w == word)
                            {
                                count++;
                            }
                        }

                    }


                    Console.WriteLine($"Слово '{word}' найдено в файле {count} раз");
                }
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден");
            }

            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }

        }
    }
}