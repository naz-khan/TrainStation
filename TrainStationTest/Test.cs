using System;
using TrainStation;
using Autofac.Extras.Moq;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace TrainStationTest
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void GetSuggestions_Success()
        {
            using(var mock = AutoMock.GetLoose())
            {
                mock.Mock<IStationFinder>()
                    .Setup(x => x.GetSuggestions("Dart"))
                    .Returns(SampleData());

                var cls = mock.Create<StationFinder>();
                var expected = SampleData();
                var actual = cls.GetSuggestions("Dart");

                Assert.True(actual != null);
                Assert.AreEqual(expected.NextLetters.Count, actual.NextLetters.Count);
                Assert.AreEqual(expected.Stations.Count(), actual.Stations.Count());

                for (int i = 0; i < expected.NextLetters.Count; i++)
                {
                    Assert.AreEqual(expected.NextLetters[i], actual.NextLetters[i]);
                }
                List<string> stations = (List<string>)expected.Stations;
                List<string> actualStations = (List<string>)actual.Stations;

                for (int i = 0; i < stations.Count; i++)
                {
                    Assert.AreEqual(stations[i], actualStations[i]);
                }
                
            }        
        }

        [Test]
        public void GetSuggestionsSpecialChars_Success()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IStationFinder>()
                    .Setup(x => x.GetSuggestions("Burley"))
                    .Returns(SpecialCharSampleData());

                var cls = mock.Create<StationFinder>();
                var expected = SpecialCharSampleData();
                var actual = cls.GetSuggestions("Burley");

                Assert.True(actual != null);
                Assert.AreEqual(expected.NextLetters.Count, actual.NextLetters.Count);
                Assert.AreEqual(expected.Stations.Count(), actual.Stations.Count());

                for (int i = 0; i < expected.NextLetters.Count; i++)
                {
                    Assert.AreEqual(expected.NextLetters[i], actual.NextLetters[i]);
                }
                List<string> stations = (List<string>)expected.Stations;
                List<string> actualStations = (List<string>)actual.Stations;

                for (int i = 0; i < stations.Count; i++)
                {
                    Assert.AreEqual(stations[i], actualStations[i]);
                }

            }
        }

        public Suggestions SampleData()
        {
            Suggestions suggestions = new Suggestions()
            {
                NextLetters = new List<char> { 'f','m','o' },
                Stations = new List<string> { "Dartford", "Dartmouth", "Darton" }
            };

            return suggestions;
        }
        public Suggestions SpecialCharSampleData()
        {
            Suggestions suggestions = new Suggestions()
            {
                NextLetters = new List<char> { 'P', 'I' },
                Stations = new List<string> { "Burley Park", "Burley-In-Wharfedale" }
            };

            return suggestions;
        }
    }
}
