namespace TrainStation
{
    public interface IStationFinder
    {
        Suggestions GetSuggestions(string userInput);
    }
}