using System;

namespace DeepFreeze.Packages.Extensions.Runtime
{
    public static class DateTimeExtensions
    {
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1);
        
        public static double ToEpoch(this DateTime dateTime)
        {
            return (dateTime - Epoch).TotalSeconds;
        }

        public static DateTime ToDateTime(this double epoch)
        {
            return Epoch.AddSeconds(epoch);
        }

        public static DateTime ToDateTime(this int epoch)
        {
            return Epoch.AddSeconds(epoch);
        }

        public static double ToTimestamp(this DateTime dateTime)
        {
            return (dateTime - Epoch).TotalMilliseconds;
        }

        public static DateTime FromTimestamp(this double timestamp)
        {
            return Epoch.AddMilliseconds(timestamp);
        }
        
        public static string ToCountDown(this DateTime dateTime, string delimiter = "", bool clipIfLong = false)
        {
            return ToCountDown((dateTime - DateTime.Now).TotalSeconds, delimiter, clipIfLong);
        }

        public static string ToCountDown(this double totalSeconds, string delimiter = "", bool clipIfLong = false)
        {
            var time = TimeSpan.FromSeconds(totalSeconds);

            var format = "";
            
            if (time.Days > 0)
            {
                //4d
                format = $"d\\d";
                
                //4d23:h12m
                if(time.Hours > 0 || time.Minutes > 0 )
                {
                    format += $"%h\\h{delimiter}m\\m";
                }
            }
            else if (time.Hours > 0)
            {
                //12h
                format = $"%h\\h";
                
                //12h:20m:23s
                if(time.Minutes > 0 || time.Seconds > 0)
                {
                    if(clipIfLong)
                    {
                        if(time.Hours < 10 && time.Days == 0)
                        {
                            format += $"m\\m{delimiter}s\\s";
                        }
                        else
                        {
                            format += $"m\\m";
                        }
                    }
                    else
                    {
                        format += $"m\\m{delimiter}s\\s";
                    }
                }
            }
            else if (time.Minutes > 0)
            {
                //20m:0s
                format = $"m\\m{delimiter}s\\s";
            }

            else if(clipIfLong)
            {
                if (time.Seconds > 1 && time.Hours < 10 && time.Days == 0)
                {
                    //2.2s
                    format = "s\\s";
                }
                else if (time.Hours < 10 && time.Days == 0)
                {
                    //0.25s
                    format = "s\\s";
                }
            }
            else
            {
                format = "s\\s";
            }

            return time.ToString(format);
        }
    }
}