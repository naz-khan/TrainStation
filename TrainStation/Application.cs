using System;
namespace TrainStation
{
    public class Application : IApplication
    {
        IStationFinder _stationFinder;

        public Application(IStationFinder stationFinder)
        {
            _stationFinder = stationFinder;
        }

        public void Run(string userInput)
        {
            _stationFinder.GetSuggestions(userInput);
        }
    }
}
