using KartRacing.Domain.Entities;

namespace KartRacing.Domain.Services
{
    public interface ILogService
    {
        string[] ReadLogFile(string textFile);
        Race ConvertLinesToObjects(string[] lines);
    }
}
