﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAndTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime myValue = DateTime.Now;
            //Console.WriteLine(myValue.ToString());
            //Console.WriteLine(myValue.ToShortDateString());
            //Console.WriteLine(myValue.ToShortTimeString());
            //Console.WriteLine(myValue.ToLongDateString());
            //Console.WriteLine(myValue.ToLongTimeString());
            //Console.WriteLine(myValue.AddDays(3).ToLongDateString());
            //Console.WriteLine(myValue.AddHours(3).ToShortTimeString());
            //Console.WriteLine(myValue.AddDays(-3).ToShortDateString());
            //Console.WriteLine(myValue.Month.ToString());
            //DateTime myBirthday = new DateTime(1996 , 08, 28);
            //Console.WriteLine(myBirthday.ToShortDateString());
            DateTime myBirthday = DateTime.Parse("28/08/1996");
            TimeSpan myAge = DateTime.Now.Subtract(myBirthday);
            Console.WriteLine(myAge.TotalDays);


            Console.ReadKey();
        }
    }
}
