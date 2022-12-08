using System;

namespace MTP_Sem3_Lab3_Class_Date
{
    class Date
    {
        int day, month, year;

        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public int DaysInMonth(int month, int year)
        {
            int count = -1;

            //Если февраль, то проверяем високосность
            if (month == 2)
            {
                if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0)) count = 29;
                else count = 28;
            }
            //До июля (включительно) чётные - 30 дней, нечётные - 31
            else if (month < 8)
            { 
                if (month % 2 == 0) count = 30;
                else count = 31;
            }
            //После августа (включительно) нечётные - 30 дней, чётные - 31
            else if (month >= 8)
            {
                if (month % 2 == 0) count = 31;
                else count = 30;
            }

            return count;
        }

        public bool DateCheck(int day, int month,int year)
        {
            //Проверяем год
            if (year <= 0) return false;

            //Проверяем кол-во месяцев
            if (month <= 0 || month > 12) return false;

            //Проверяем кол-во дней
            if (day > 0 && day <= DaysInMonth(month, year)) return true;
            else return false;
        }

        public int DaysFromAge1(int day, int month, int year)
        {
            int count;
            
            //Прибавляем дни на основе кол-ва лет
            count = 365 * (year - 1);

            //Учитываем високосные года
            count -= year / 100;
            count += year / 400;
            count += year / 4;

            //Прибавляем дни текущего года
            int i;
            for (i = 1; i < month; i++)
            {
                count += DaysInMonth(i, year);
            }

            //Прибавляем дни текущего месяца
            count += day;

            return count;
        }

        public int DayOfWeek(int day, int month, int year)
        {
            int d;
            //Расчёт дня недели на основе знания кол-ва дней с начала времён
            d = DaysFromAge1(day, month, year) % 7;
            //Сдвигаем, если год високосный
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                if (d == 0) d = 6;
                else d--;
            }
            //Сдвигаем, чтобы 0,1,...,6 соответсвовали mn,td,...,st
            if (d == 0) d = 6;
            else d--;

            return d;
        }
    }
}