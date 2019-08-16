using KartRacing.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KartRacing.Tests.Entities
{
    [TestClass]
    public class PilotTests
    {
        private Pilot _pilot;

        [TestInitialize]
        public void Initialize()
        {
            _pilot = new Pilot(1, "Ayrton Senna");

            _pilot.AddLap(new Lap(1, 42.20, new TimeSpan(0, 0, 05, 00, 00), new TimeSpan(18, 00, 00)));
            _pilot.AddLap(new Lap(2, 52.60, new TimeSpan(0, 0, 04, 00, 00), new TimeSpan(18, 05, 00)));
            _pilot.AddLap(new Lap(3, 31.20, new TimeSpan(0, 0, 03, 20, 10), new TimeSpan(18, 09, 00)));
        }

        [TestMethod]
        public void ShouldReturnAverageSpeed()
        {
            double average = (42.20 + 52.60 + 31.20) / 3;
            Assert.AreEqual(average, _pilot.AverageSpeed);
        }

        [TestMethod]
        public void ShouldReturnBestLap()
        {
            Assert.AreEqual(new TimeSpan(0, 0, 03, 20, 10), _pilot.BestLap);
        }

        [TestMethod]
        public void ShouldReturnTotalLaps()
        {
            Assert.AreEqual(3, _pilot.TotalLaps);
        }


        [TestMethod]
        public void ShouldReturnTotalTime()
        {
            Assert.AreEqual(new TimeSpan(0, 0, 12, 20, 10), _pilot.TotalTime);
        }

        [TestMethod]
        public void ShouldReturnTimeAfterWinner()
        {
            _pilot.SetTimeAfterWinner(new TimeSpan(0, 0, 12, 20, 05));
            Assert.AreEqual(new TimeSpan(0, 0, 00, 00, 05), _pilot.TimeAfterWinner);
        }


    }
}
