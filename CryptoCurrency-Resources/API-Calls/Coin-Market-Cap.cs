using System.Net;
using System.Web;

// Fetches all active cryptocurrencies by market cap and returns market values in USD

class AllActiveCurrenciesMarketValuesInUSD
{
  private static string API_KEY = "d560b425-b17a-4cba-8f05-8fd111a19be0";

  public static void Main(string[] args)
  {
    try
    {
    Console.WriteLine(makeAPICall());
    }
    catch (WebException e)
    {
    Console.WriteLine(e.Message);
    }
  }

  static string makeAPICall()
  {
    var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

    var queryString = HttpUtility.ParseQueryString(string.Empty);
    queryString["start"] = "1";
    queryString["limit"] = "5000";
    queryString["convert"] = "USD";

    URL.Query = queryString.ToString();

    var client = new WebClient();
    client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
    client.Headers.Add("Accepts", "application/json");
    return client.DownloadString(URL.ToString());

  }

}