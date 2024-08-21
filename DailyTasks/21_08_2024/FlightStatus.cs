using System;
using System.Collections.Generic;

public class Program
{
    static Dictionary<string, DateTime> flightSchedules = new Dictionary<string, DateTime>()
    {
        { "Ar456", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0) },
        { "Hq457", new DateTime(DateTime.Now.Year, DateTime.Now.Month, 23, 22, 30, 0) },
        { "Tg458", new DateTime(DateTime.Now.Year, DateTime.Now.Month, 22, 20, 15, 0) },
        { "Rs459", new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28, 9, 15, 0) },
        { "Dy460", new DateTime(DateTime.Now.Year, DateTime.Now.Month, 24, 8, 23, 0) },
        { "Zi454", new DateTime(DateTime.Now.Year, DateTime.Now.Month, 23, 5, 40, 0) },
        { "Bm487", new DateTime(DateTime.Now.Year, DateTime.Now.Month, 22, 9, 19, 0) },
    };

    public static string FlightStatus(string flightNo)
    {
        if (flightSchedules.TryGetValue(flightNo, out DateTime departureTime))
        {
            TimeSpan timeLeft = departureTime - DateTime.Now;
            if (timeLeft.TotalSeconds > 0)
            {
                int days = timeLeft.Days;
                TimeSpan time = timeLeft - TimeSpan.FromDays(days);
                //return $"Time To Flight {days} days {time.ToString(@"hh\:mm\:ss\.ffffff")}";
                //Output
                //Enter the Flight Number: Rs459
                //Time To Flight 6 days 19:58:48.952218
                return $"Time To Flight {timeLeft}";
                //Output
                //Enter the Flight Number: Rs459
                //Time To Flight 6.19:55:58.7112418
            }
            else
            {
                return "Flight Already Left";
            }
        }
        else
        {
            return "Flight Not Found";
        }
    }

    public static void Main()
    {
        Console.Write("Enter the Flight Number: ");
        string flightNo = Console.ReadLine();
        Console.WriteLine(FlightStatus(flightNo));
    }


}




