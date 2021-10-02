using System;

namespace function_analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            double R = 0;

            Console.WriteLine("Введите параметр R:");

            R = double.Parse(Console.ReadLine());

            if (R < 0)
            {
                while (R < 0)
                {
                    Console.WriteLine("R не может быть меньше 0, введите ещё раз:");
                    R = double.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Значения функции для всех x от -8 до 10:");

            for (double x = -8.0; x < 10; x = x + 0.1)
            {
                sector_detection(R, x);
            }

            Console.WriteLine("\r\n---------------------------------\r\n");

            double in_value = 0;

            while (in_value != 420)
            {
                Console.WriteLine("Введите значение x, для которого хотите получить значение функции (или 420 если хотите завершить работу):");
                in_value = double.Parse(Console.ReadLine());
                if (in_value != 420) sector_detection(R, in_value);
            }

            Console.WriteLine("До свидания!");
        }

        static void sector_detection(double R, double i)
        {
            i = Math.Round(i, 1);
            if (i < -8)
            {
                Console.WriteLine("Функция не определена!");
            }
            else if (i < -5)
            {
                Console.WriteLine($"y({i}) = {sector_1()}");
            }
            else if (i == -5)
            {
                double le, ri;
                sector_gappoint(out le, out ri);
                Console.WriteLine($"y({i}) = {le} (точка разрыва, слева)");
                Console.WriteLine($"y({i}) = {ri} (точка разрыва, справа)");
            }
            else if (i < -3)
            {
                Console.WriteLine($"y({i}) = {sector_2(i)}");
            }
            else if (i < 0)
            {
                if (R < 3)
                {
                    if ((i >= -3) && (i <= 0 - R))
                    {
                        if (i == -3)
                        {
                            Console.WriteLine($"y({i}) = {0} (точка разрыва, слева)");
                        }
                        else if (i == 0 - R)
                        {
                            Console.WriteLine($"y({i}) = {0} (точка разрыва, справа)");
                        }
                        else
                        {
                            Console.WriteLine($"Функция y({i}) не определена!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"y({i}) = {sector_3(i, R)}");
                    }

                }
                else if (R > 3)
                {
                    Console.WriteLine($"y({i}) = {sector_unknownarc(i, R)}");
                }
                else
                {
                    Console.WriteLine($"y({i}) = {sector_3(i, R)}");
                }
            }
            else if (i <= 3)
            {
                if (R < 3)
                {
                    if ((i >= R) && (i <= 3))
                    {
                        if (i == R)
                        {
                            Console.WriteLine($"y({i}) = {0} (точка разрыва, слева)");
                        }
                        else if (i == 3)
                        {
                            Console.WriteLine($"y({i}) = {0} (точка разрыва, справа)");
                        }
                        else
                        {
                            Console.WriteLine($"Функция y({i}) не определена!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"y({i}) = {sector_4(i, R)}");
                    }
                }
                else if (R > 3)
                {
                    Console.WriteLine($"y({i}) = {sector_unknownarc(i, R)}");
                }
                else
                {
                    Console.WriteLine($"y({i}) = {sector_4(i, R)}");
                }
            }
            else if (i < 8)
            {
                Console.WriteLine($"y({i}) = {sector_5(i)}");
            }
            else if (i <= 10)
            {
                Console.WriteLine($"y({i}) = {sector_6()}");
            }
            else if (i > 10)
            {
                Console.WriteLine("Функция не определена!");
            }
        }

        static double sector_1()
        {
            return -3;
        }

        static void sector_gappoint(out double left, out double right)
        {
            left = -3;
            right = -2;
        }
        static double sector_2(double x)
        {
            return Math.Round (x+3, 5);
        }
        static double sector_3(double x, double r)
        {
            return Math.Round(Math.Sqrt(r * r - x * x),5);
        }
        static double sector_4(double x, double r)
        {
            return Math.Round(Math.Sqrt(r * r - x * x), 5);  
        }
        static double sector_5(double x)
        {
            return Math.Round((x - 3) * 3/5 ,5);
        }
        static double sector_6()
        {
            return 3;
        }
        static void sector_unknowngap(double x, double r, out double left, out double right)
        {
            if (x < 0)
            {
                left = 0;
                right = -Math.Abs(r);
            }
            else
            {
                left = 3;
                right = Math.Abs(r);
            }
  
        }
        static double sector_unknownarc(double x, double r)
        {
            double delta = Math.Round(Math.Sqrt(r * r - 9), 5);
            return Math.Round(Math.Sqrt(r * r - x * x) - delta, 5);
        }
    }
}
