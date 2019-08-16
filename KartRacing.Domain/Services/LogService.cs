using KartRacing.Domain.Entities;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace KartRacing.Domain.Services
{
    public class LogService : ILogService
    {
        public string[] ReadLogFile(string textFile)
        {
            if (File.Exists(textFile))
            {
                var lines = File.ReadAllLines(textFile)
                                .ToList();

                lines.RemoveAt(0);

                return lines.ToArray();
            }

            throw new FileNotFoundException();
        }
        public Race ConvertLinesToObjects(string[] lines)
        {
            var race = new Race();

            foreach (string line in lines)
            {
                string[] data = Regex.Split(line, @"\s{1,}");

                Pilot pilot = this.CreatePilot(race, data);
                Lap lap = this.CreateLap(data);
                pilot.AddLap(lap);
            }

            return race;
        }

        private Pilot CreatePilot(Race race, string[] data)
        {
            string pilotName = data[IndexType.pilotName];
            int pilotCode = int.Parse(data[IndexType.pilotCode]);

            var pilot = this.FindPilot(pilotCode, race);

            if (pilot == null)
            {
                pilot = new Pilot(pilotCode, pilotName);
                race.AddPilot(pilot);
            }

            return pilot;
        }

        private Pilot FindPilot(int code, Race race)
        {
            return race.Pilots
                       .Where(p => p.Code.Equals(code))
                       .FirstOrDefault();
        }

        private Lap CreateLap(string[] data)
        {
            int lapNumber = int.Parse(data[IndexType.lapNumber]);
            double lapAverageSpeed = double.Parse(data[IndexType.lapAverageSpeed].Replace(",", "."));
            TimeSpan lapDuration = TimeSpan.ParseExact(data[IndexType.lapDuration], @"m\:s\.fff", CultureInfo.InvariantCulture);
            TimeSpan lapHour = TimeSpan.Parse(data[IndexType.lapHour], CultureInfo.InvariantCulture);

            return new Lap(lapNumber, lapAverageSpeed, lapDuration, lapHour);
        }

    }
}
