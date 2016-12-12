using System;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Core
    {
//        http://api.openweathermap.org/data/2.5/weather?lat=55.676098&lon=12.5683&appid=e7de5f21f7e48a34cabd482680b17a73
//http://api.openweathermap.org/data/2.5/weather?q=oslo&appid=e7de5f21f7e48a34cabd482680b17a73
//http://api.openweathermap.org/data/2.5/weather?zip=90210,us&appid=e7de5f21f7e48a34cabd482680b17a73

        public static async Task<Weather> GetWeather(string zipCode)
        {
            //Sign up for a free API key at http://openweathermap.org/appid
            string key = "e7de5f21f7e48a34cabd482680b17a73";
            
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip="
                + zipCode + "&appid=" + key;

            var results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];

                //string s = (string)results["main"]["temp"];
                //weather.Temperature = ConvertFahrenheitToCelsius(Convert.ToDouble(s)).ToString() + " C";
                weather.Temperature = (string)results["main"]["temp"] + " F";
                
                weather.Wind = (string)results["wind"]["speed"] + " mph";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";
                return weather;
            }
            else
            {
                return null;
            }
        }

        public static async Task<Weather> GetWeatherByCity(string city)
        {
            //Sign up for a free API key at http://openweathermap.org/appid
            string key = "e7de5f21f7e48a34cabd482680b17a73";
            string queryStringByCity = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + key;

            var results = await DataService.getDataFromService(queryStringByCity).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];

                //string s = (string)results["main"]["temp"];
                //weather.Temperature = ConvertFahrenheitToCelsius(Convert.ToDouble(s)).ToString() + " C";
                weather.Temperature = (string)results["main"]["temp"] + " F";
                
                weather.Wind = (string)results["wind"]["speed"] + " mph";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";
                return weather;
            }
            else
            {
                return null;
            }
        }

        private static double ConvertFahrenheitToCelsius(double f)
        {
            return (5.0 / 9.0) * (f - 32);
        }
    }
}