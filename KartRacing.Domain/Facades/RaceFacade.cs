using KartRacing.Domain.Entities;
using KartRacing.Domain.Services;

namespace KartRacing.Domain.Facades
{
    public class RaceFacade : IRaceFacade
    {
        private readonly ILogService _service;
        private Race _race;
        public RaceFacade()
        {
            _service = new LogService();
        }
        public Race StartRace(string textFile)
        {
            var fileLines = _service.ReadLogFile(textFile);
            _race = _service.ConvertLinesToObjects(fileLines);

            _race.SetPositions();

            return _race;
        }
    }
}
