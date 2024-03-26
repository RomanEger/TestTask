using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using TestTask;
using System.Text;
using System.Globalization;
namespace TestTask;

class Program
{
    static void Main()
    {
        double a, b, c;
        Console.WriteLine("Выберите тип ввода:\n1. С клавиатуры\n2. Из файла");
        var readType = Console.ReadLine();
        if (readType == "1")
        {

            Console.WriteLine("Для решения квадратного уравнения введите:");

            Read("a", out a);
            Read("b", out b);
            Read("c", out c);

            try
            {
                var xList = Solver.QuadraticEquation(a, b, c).ToList();
                for (int i = 0; i < xList.Count(); i++)
                {
                    Console.WriteLine($"x{i + 1}={xList[i]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else if (readType == "2")
        {
            Console.WriteLine("Введите путь к файлу");
            var path = Console.ReadLine();
            if (File.Exists(path))
            {
                var arr = ReadFromFile(path);
                for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
                {
                    a = arr[i, 0];
                    b = arr[i, 1];
                    c = arr[i, 2];
                    try
                    {
                        var xList = Solver.QuadraticEquation(a, b, c).ToList();

                    Console.WriteLine($"Решение для a={a}, b={b}, c={c}");

                    for (int j = 0; j < xList.Count(); j++)
                    {
                        Console.WriteLine($"x{i + 1}={xList[j]}");
                    }

                }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Решения для a={a}, b={b}, c={c} нет\n" + ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл не найден");
            }
        }
        else
        {
            Console.WriteLine("Неккоректный ответ");
        }

    }

    static void Read(string xName, out double x)
    {
        while (true)
        {
            Console.Write($"{xName} = ");
            var r = Console.ReadLine();
            r = r.FormatToDouble();
            if (!double.TryParse(r, CultureInfo.InvariantCulture, out x))
            {
                Console.WriteLine("Ошибка! Ожидается число.");
                continue;
            }
            break;
        }
    }

    static double[,] ReadFromFile(string path)
    {
        using StreamReader reader = new StreamReader(path);
        var text = new StringBuilder();
        while (true)
        {
            var temp = reader.ReadLine();

            if (temp == null)
                break;

            text.Append(temp + " ");
        }
        IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
        var listStr = text.ToString().Trim().Split(' ');

        var list = new List<double>();
        foreach (var item in listStr)
        {
            list.Add(double.Parse(item, formatter));
        }
        double[,] arr = new double[list.Count / 3, 3];
        int index = 0;
        for (int i = 0; i < list.Count / 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                arr[i, j] = list[index++];
            }
        }
        return arr;
    }

}