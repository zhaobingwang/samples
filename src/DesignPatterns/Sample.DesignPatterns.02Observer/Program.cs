////////////////////////////////////////////////////////////////////
//                          _ooOoo_                               //
//                         o8888888o                              //
//                         88" . "88                              //
//                         (| ^_^ |)                              //
//                         O\  =  /O                              //
//                      ____/`---'\____                           //
//                    .'  \\|     |//  `.                         //
//                   /  \\|||  :  |||//  \                        //
//                  /  _||||| -:- |||||-  \                       //
//                  |   | \\\  -  /// |   |                       //
//                  | \_|  ''\---/''  |   |                       //
//                  \  .-\__  `-`  ___/-. /                       //
//                ___`. .'  /--.--\  `. . ___                     //
//              ."" '<  `.___\_<|>_/___.'  >'"".                  //
//            | | :  `- \`.;`\ _ /`;.`/ - ` : | |                 //
//            \  \ `-.   \_ __\ /__ _/   .-` /  /                 //
//      ========`-.____`-.___\_____/___.-`____.-'========         //
//                           `=---='                              //
//      ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^        //
//               佛祖保佑       永不宕机     永无BUG                //
////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace Sample.DesignPatterns._02Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            CurrentConditionsDisplay currentConditionsDisplay = new CurrentConditionsDisplay(weatherData);
            weatherData.SetMeasurements(10, 50, 30.2f);
            weatherData.SetMeasurements(5, 45, 31.2f);
            weatherData.SetMeasurements(-1, 48, 32.2f);
        }
    }

    #region interface
    public interface Observer
    {
        void Update(float temp, float humidity, float pressure);
    }
    public interface Subject
    {
        void RegisterObserver(Observer observer);
        void RemoveObserver(Observer observer);
        void NodifyObserver();
    }
    public interface DisplayElement
    {
        void Display();
    }
    #endregion

    public class WeatherData : Subject
    {
        private List<Observer> observers;
        private float temperature;
        private float humidity;
        private float pressure;
        public WeatherData()
        {
            observers = new List<Observer>();
        }

        public void RegisterObserver(Observer observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(Observer observer)
        {
            observers.Remove(observer);
        }
        public void NodifyObserver()
        {
            foreach (var observer in observers)
            {
                observer.Update(temperature, humidity, pressure);
            }
        }

        public void MeasurementsChanged()
        {
            NodifyObserver();
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            MeasurementsChanged();
        }
    }

    public class CurrentConditionsDisplay : Observer, DisplayElement
    {
        private float temperature;
        private float humidity;
        public Subject _weatherData;

        public CurrentConditionsDisplay(Subject weatherData)
        {
            _weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }

        public void Display()
        {
            Console.WriteLine($"Current conditions:{temperature}℃ and {humidity}% humidity");
        }

        public void Update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            Display();
        }
    }
}
