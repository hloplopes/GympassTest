using KartRacing.Domain.Entities;
using KartRacing.Domain.Facades;
using System;
using System.IO;
using System.Linq;

namespace KartRacing.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var facade = new RaceFacade();

            try
            {
                Console.WriteLine("Informe o path do arquivo:");
                string txtFile = Console.ReadLine();

                var race = facade.StartRace(txtFile);

                GenerateResults(race);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Arquivo não encontrado.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato dos dados são inválidos.");
            }
            catch (Exception)
            {
                Console.WriteLine("Ocorreu um erro inesperado, por favor contate o desenvolvedor do sistema.");
            }

            Console.WriteLine("Digite algo para sair:");
            Console.ReadKey();
        }

        public static void GenerateResults(Race race)
        {
            var bestLap = race.BestLap;

            Console.WriteLine($"Tempo da melhor volta da corrida: {bestLap}");

            var pilots = race.Pilots
                              .OrderBy(p => p.Position)
                              .ToList();

            pilots.ForEach(p =>
            {
                Console.WriteLine("========================================");
                Console.WriteLine($"Posição Chegada: {p.Position}");
                Console.WriteLine($"Código Piloto: {p.Code}");
                Console.WriteLine($"Nome Piloto: {p.Name}");
                Console.WriteLine($"Qtde Voltas Completadas: {p.TotalLaps}");
                Console.WriteLine($"Tempo Total de Prova: {p.TotalTime}");
                Console.WriteLine($"Tempo da Melhor Volta: {p.BestLap}");
                Console.WriteLine($"Velocidade Média: {p.AverageSpeed}");
                Console.WriteLine($"tempo de chegada após o vencedor: {p.TimeAfterWinner}");
            });
        }
    }
}
