using System;

namespace function_analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            double R = 0;

            Console.WriteLine("Введите параметр R:");

            R = double.Parse(Console.ReadLine()); //считываем R

            if (R < 0) //Так как R - радиус, то он не может быть меньше нуля (но может быть ему равен)
            {
                while (R < 0)
                {
                    Console.WriteLine("R не может быть меньше 0, введите ещё раз:"); //Запрашиваем пока R не будет больше 0
                    R = double.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Значения функции для всех x от -8 до 10:");

            for (double x = -8.0; x < 10; x = x + 0.1) //запускаем основной код для значений от -8 до 10 с шагом 0.1
            {
                sector_detection(R, x);
            }

            Console.WriteLine("\r\n---------------------------------\r\n");

            double in_value = 0; //вторая часть программы для значений x с клавиатуры

            while (in_value != 420)
            {
                Console.WriteLine("Введите значение x, для которого хотите получить значение функции (или 420 если хотите завершить работу):");
                in_value = double.Parse(Console.ReadLine());
                if (in_value != 420) sector_detection(R, in_value); //x = 420 будет критерием останова
            }

            Console.WriteLine("До свидания!"); //завершаем
        }

        static void sector_detection(double R, double i)
        {
            i = Math.Round(i, 1);
            if (i < -8)
            {
                Console.WriteLine("Функция не определена!"); //если тока левее первого сектора
            }
            else if (i < -5)
            {
                Console.WriteLine($"y({i}) = {sector_1()}"); //первый сектор
            }
            else if (i == -5)
            {
                double le, ri;
                sector_gappoint(out le, out ri); //точка разрыва между первым в вторым секторами
                Console.WriteLine($"y({i}) = {le} (точка разрыва, слева)");
                Console.WriteLine($"y({i}) = {ri} (точка разрыва, справа)");
            }
            else if (i < -3)
            {
                Console.WriteLine($"y({i}) = {sector_2(i)}"); //второй сектор
            }
            else if (i < 0)
            {
                if (R < 3) //когда радиус меньше 3, образуются точки разрыва (мы считаем, что четверть-окружности сдвигаются к нулю)
                {
                    if ((i >= -3) && (i <= 0 - R))
                    {
                        if (i == -3)
                        {
                            Console.WriteLine($"y({i}) = {0} (точка разрыва, слева)");
                        }
                        else if (i == 0 - R)
                        {
                            Console.WriteLine($"y({i}) = {0} (точка разрыва, справа)"); //образуются разрывы
                        }
                        else
                        {
                            //ЭТУ СТРОЧКУ МОЖНО УДАЛИТЬ ПО ЖЕЛАНИЮ
                            Console.WriteLine($"Функция y({i}) не определена!"); //между разрывами нет значений
                        }
                    }
                    else
                    {
                        Console.WriteLine($"y({i}) = {sector_3(i, R)}"); //когда четверть-окружность начинается, то её значения уже можно считать по основной формуле
                    }

                }
                else if (R > 3)
                {
                    Console.WriteLine($"y({i}) = {sector_unknownarc(i, R)}"); //для случая, когда радиус больше 3 отдельная функция (описание в её комментариях)
                }
                else
                {
                    Console.WriteLine($"y({i}) = {sector_3(i, R)}"); //если всё нормально, то считаем по обычной формуле
                }
            }
            else if (i <= 3) //аналогичные действия выполняются для правой части полуокружности, комментарии не требуются
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
                            //ЭТУ СТРОЧКУ МОЖНО УДАЛИТЬ ПО ЖЕЛАНИЮ
                            Console.WriteLine($"Функция y({i}) не определена!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"y({i}) = {sector_4(i, R)}"); // но здесь мы пользуемся функцией для четвёртого сектора...
                    }
                }
                else if (R > 3)
                {
                    Console.WriteLine($"y({i}) = {sector_unknownarc(i, R)}");
                }
                else
                {
                    Console.WriteLine($"y({i}) = {sector_4(i, R)}"); //...как и здесь
                }
            }
            else if (i < 8)
            {
                Console.WriteLine($"y({i}) = {sector_5(i)}"); //с пятым сектором всё просто...
            }
            else if (i <= 10)
            {
                Console.WriteLine($"y({i}) = {sector_6()}"); //... как и с шестым
            }
            else if (i > 10)
            {
                Console.WriteLine("Функция не определена!"); //если точка правее шестого сектора
            }
        }

        static double sector_1()
        {
            return -3; //первый сектор - просто прямая y = -3
        }

        static void sector_gappoint(out double left, out double right)
        {
            left = -3; //в точке разрыва мы возвращаем два значения - правое и левое
            right = -2; 
        }
        static double sector_2(double x)
        {
            return Math.Round (x+3, 5); //простая функция вида y=kx+b
        }
        static double sector_3(double x, double r)
        {
            return Math.Round(Math.Sqrt(r * r - x * x),5); //используем известную формулу, основанную на теореме Пифагора
        }
        static double sector_4(double x, double r)
        {
            return Math.Round(Math.Sqrt(r * r - x * x), 5); //точно такая же формула, как и для треего сектора, в отдельную функция выненсена для красоты
        }
        static double sector_5(double x)
        {
            return Math.Round((x - 3) * 3/5 ,5); //простая функция вида kx+b
        }
        static double sector_6()
        {
            return 3; //прямая y = 3
        }
        static void sector_unknowngap(double x, double r, out double left, out double right)
        {
            if (x < 0) //если радиус меньше трёх, то мы мысленно переносим четверть окружности в право до нуля, и слева получается разрыв
            {
                left = 0; //если это левая часть окружности, то левый разрыв заканчивается на 0
                right = -Math.Abs(r); //а правый - на радиусе (в отрицательной области x) 
            }
            else
            {
                left = 3; //если это правая часть, то левый рарыв в 3
                right = Math.Abs(r); //а првый на радиусе (получилась "перевёрнутая" картина - из-за того, что мы как бы "смотрим со стороны правой части графика")
            }
  
        }
        static double sector_unknownarc(double x, double r) //так как радиус больше, то он будет располагаться выше, а нам по условию надо сохранить "касание" дуги и прямой
        {
            double delta = Math.Round(Math.Sqrt(r * r - 9), 5); //для этого мы вычисляем дельту (которая получилась из идеи о том, что левая часть дуги должна касаться нуля), а потом отнимаем её от всех значений
            return Math.Round(Math.Sqrt(r * r - x * x) - delta, 5);
        }
    }
}