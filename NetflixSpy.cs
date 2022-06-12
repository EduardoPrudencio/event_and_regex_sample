using System.Text.RegularExpressions;

public class NetflixSpy  {

public NetflixSpy()
{
    NetiflixSeries = new List<string>();
}

public event EventHandler? LoadCompleted;

private List<string> NetiflixSeries { get; set; }

    public void Load()
    {
        using var httpClient = new HttpClient();
        string pattern = "<span class=\"nm-collections-title-name\">\\w*</span>";
        var content = httpClient.GetStringAsync("https://www.netflix.com/br/browse/genre/83").Result;

        MatchCollection series = Regex.Matches(content, pattern, RegexOptions.IgnoreCase);

        foreach (Match serie in series)
        {
            string serieName = Regex.Replace(serie.Value, "<[^>]*>", "");
            NetiflixSeries.Add(serieName);
        }

        if(LoadCompleted != null) LoadCompleted?.Invoke(NetiflixSeries, EventArgs.Empty);
    }
}