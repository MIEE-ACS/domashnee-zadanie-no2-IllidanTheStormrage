using System;

namespace function_analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            float R;

            Console.WriteLine("Введите параметр R:");

            R = int.Parse(Console.ReadLine());

            for (double i = -8.0; i < 10.1; i = i + 0.1)
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
                    sector_gappoint(out le , out ri);
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
                        Console.WriteLine($"y({i}) = {sector_unknownarc()}");
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
                        Console.WriteLine($"y({i}) = {sector_unknownarc()}");
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
        static double sector_unknownarc()
        {
            return 0;
        }
    }
}
