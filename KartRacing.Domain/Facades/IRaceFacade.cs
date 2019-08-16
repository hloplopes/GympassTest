using KartRacing.Domain.Entities;

namespace KartRacing.Domain.Facades
{
    public interface IRaceFacade
    {
        Race StartRace(string textFile);
    }
}
