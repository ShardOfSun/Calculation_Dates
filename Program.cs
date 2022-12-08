using System;

namespace MTP_Sem3_Lab3_Class_Date
{
    enum DayWeek { mn, td, wd, thd, fd, std, sd };

    class Program
    {
        static void Main(string[] args)
        {
            //Дату задаём рандомно (включая некорректные даты)
            Random r = new Random();
            int year = (r.Next() % 10000);
            int month = (r.Next() % 15);
            int day = (r.Next() % 36);
            
            //Объявляем объект класса
            Date d = new Date(day, month, year);
            
            //Выводим получившуюся дату
            Console.WriteLine("Date: " + day + "." + month + "." + year + "\n");

            //Проверяем, корректность даты
            if (d.DateCheck(day, month, year))
            {
                Console.WriteLine("Data is correct.\n");
                //Демонстрируем методы класса
                Console.WriteLine("Days in this month: " + d.DaysInMonth(month, year));
                Console.WriteLine("Days from 01.01.1: " + d.DaysFromAge1(day, month, year));
                //Выводим день недели, используя перечисление (по индексу, возвращаемому методом)
                DayWeek dw = (DayWeek)d.DayOfWeek(day, month, year);
                Console.WriteLine("Day of the week: " + dw + "\n");
            }
            //Если сгенерированная дата ошибочна, не можем демонстрировать методы
            else Console.WriteLine("Data is wrong.\n");

            //Задержка консоли
            Console.WriteLine("Press any key to close.\n");
            Console.ReadKey(true);
        }
    }
}
