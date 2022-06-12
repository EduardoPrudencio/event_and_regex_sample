using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        NetflixSpy netflixSpy = new NetflixSpy();
        netflixSpy.LoadCompleted += netflixSpy_LoadCompleted;
        netflixSpy.Load();
        Console.WriteLine("Iniciando consulta...");
    }

    static void netflixSpy_LoadCompleted(Object? sender, EventArgs e)
    {
        List<string>? listOfSeries = sender as List<string>;

        if(listOfSeries != null)
        {
            int count = 1;

            listOfSeries.Sort();
            Console.WriteLine($"A lista possui {listOfSeries.Count} séries");

            foreach (var serie in listOfSeries)
            {
                Console.WriteLine($"{count} - {serie}");
                count++;
            }

            Console.Read();
        }
    }
}