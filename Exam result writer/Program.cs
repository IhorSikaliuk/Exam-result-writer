using System;
using System.IO;

namespace Exam_result_writer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.Write("Введіть назву екзамену: ");
            string path = Console.ReadLine();
            StreamWriter fileStream = new StreamWriter($"{path}.txt");
            fileStream.Write(path);

            bool Continue = true;
            string Name;
            int Mark = 0;
            const int minMark = 1, maxMark = 5;
            Console.Write("Вводіть парами по черзі прізвище студента, далі через Enter його оцінку.\nДля закінчення роботи нічого не вводячи ще раз натисніть Enter.");
            for(int i = 1; Continue; i++)
            {
                Console.WriteLine($"\n{i}:");
                Name = Console.ReadLine();
                if (Name == "")
                {
                    Console.WriteLine("Завершити роботу? т/н");
                    char key;
                    do
                    {
                        key = Console.ReadKey(true).KeyChar;
                    }
                    while (key != 'т' && key != 'Т' && key != 'н' && key != 'Н');
                    if (key == 'т' || key == 'Т')
                        break;
                    else
                    {
                        i--;
                        continue;
                    }
                }
                if (Name.Contains("-"))
                {
                    Console.WriteLine("Прізвище не може містити символу '-'.");
                    i--;
                    continue;
                }

                try
                {
                    Mark = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Оцінка має бути цілим числом у діапазоні від {minMark} до {maxMark}. Спробуйте ще раз.");
                    i--;
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                    continue;
                }
                if (Mark < minMark || Mark > maxMark)
                {
                    Console.WriteLine("Оцінка поза діапазоном, спробуйте знову.");
                    i--;
                    continue;
                }
                fileStream.Write($"\n{Name}-{Mark}");
            }

            fileStream.Close();
        }
    }
}
