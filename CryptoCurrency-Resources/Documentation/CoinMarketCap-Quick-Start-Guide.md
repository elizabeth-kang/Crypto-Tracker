# CoinMarketCap
Great **Quick Start Guide** -- not started
https://coinmarketcap.com/api/documentation/v1/#

## Sample 
``` C# Request
using System;
using System.Net;
using System.Web;

class CSharpExample
{
  private static string API_KEY = "b54bcf4d-1bca-4e8e-9a24-22ff2c3d462c";

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
    var URL = new UriBuilder("https://sandbox-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

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
```

## Using Your API Key
You may use any server side programming language that can make HTTP requests to target the CoinMarketCap API. All requests should target domain https://pro-api.coinmarketcap.com.

You can supply your API Key in REST API calls in one of two ways:

1. Preferred method: Via a custom header named X-CMC_PRO_API_KEY
2. Convenience method: Via a query string parameter named CMC_PRO_API_KEY

**Security Warning:** It's important to secure your API Key against public access. The custom header option is strongly recommended over the querystring option for passing your API Key in a production environment.

## API Key Usage Credits
Most API plans include a daily and monthly limit or "hard cap" to the number of data calls that can be made. This usage is tracked as API "call credits" which are incremented 1:1 against successful (HTTP Status 200) data calls made with your key with these exceptions:

- Account management endpoints, usage stats endpoints, and error responses are not included in this limit.
- **Paginated endpoints:** List-based endpoints track an additional call credit for every 100 data points returned (rounded up) beyond our 100 data point defaults. Our lightweight /map endpoints are not included in this limit and always count as 1 credit. See individual endpoint documentation for more details.

- **Bundled API calls:** Many endpoints support resource and currency conversion bundling. Bundled resources are also tracked as 1 call credit for every 100 resources returned (rounded up). Optional currency conversion bundling using the convert parameter also increment an additional API call credit for every conversion requested beyond the first.

You can log in to the Developer Portal to view live stats on your API Key usage and limits including the number of credits used for each call. You can also find call credit usage in the JSON response for each API call. See the status object for details. You may also use the /key/info endpoint to quickly review your usage and when daily/monthly credits reset directly from the API.

## Endpoint Overview
**Endpoint Category:** /cryptocurrency/*<br>
Endpoints that return data around cryptocurrencies such as ordered cryptocurrency lists or price and volume data.

# Standards and Conventions
Each HTTP request must contain the header **Accept: application/json**. You should also send an **Accept-Encoding: deflate, gzip** header to receive data fast and efficiently.

## Endpoint Response Payload Format
All endpoints return data in JSON format with the results of your query under data if the call is successful.

A **Status** object is always included for both successful calls and failures when possible. The **Status** object always includes the current time on the server when the call was executed as **timestamp**, the number of API call credits this call utilized as **credit_count**, and the number of milliseconds it took to process the request as **elapsed**. Any details about errors encountered can be found under the **error_code** and **error_message**. See Errors and Rate Limits for details on errors.
``` C#
{
  "data" : {
    ...
  },
  "status": {
    "timestamp": "2018-06-06T07:52:27.273Z",
    "error_code": 400,
    "error_message": "Invalid value for \"id\"",
    "elapsed": 0,
    "credit_count": 0
  }
}
```
## Cryptocurrency, Exchange, and Fiat currency identifiers
- Cryptocurrencies may be identified in endpoints using either the cryptocurrency's unique CoinMarketCap ID as **id** (eg. **id=1** for Bitcoin) or the cryptocurrency's symbol (eg. **symbol=BTC** for Bitcoin). For a current list of supported cryptocurrencies use our **/cryptocurrency/map** call.
- All fiat currency options use the standard ISO 8601 currency code (eg. **USD** for the US Dollar). USD CoinMarketCap ID **2781**

## Bundling API Calls
- Many endpoints support ID and crypto/fiat currency conversion bundling. This means you can pass multiple comma-separated values to an endpoint to query or convert several items at once. Check the **id**, **symbol**, **slug**, and **convert** query parameter descriptions in the endpoint documentation to see if this is supported for an endpoint.
- Endpoints that support bundling return data as an object map instead of an array. Each key-value pair will use the identifier you passed in as the key.

For example, if you passed **symbol=BTC,ETH** to **/v1/cryptocurrency/quotes/latest** you would receive:

``` JSON
"data" : {
    "BTC" : {
      ...
    },
    "ETH" : {
      ...
    }
}
```

## Date and Time Formats
- All endpoints that require date/time parameters allow timestamps to be passed in either ISO 8601 format (eg. **2018-06-06T01:46:40Z**) or in Unix time (eg. **1528249600**). Timestamps that are passed in ISO 8601 format support basic and extended notations; if a timezone is not included, UTC will be the default.
- All timestamps returned in JSON payloads are returned in UTC time using human-readable ISO 8601 format which follows this pattern: **yyyy-mm-ddThh:mm:ss.mmmZ**. The final **.mmm** designates milliseconds. Per the ISO 8601 spec the final **Z** is a constant that represents UTC time.
- Data is collected, recorded, and reported in UTC time unless otherwise specified.

# Best Practices
This section contains a few recommendations on how to efficiently utilize the CoinMarketCap API for your enterprise application, particularly if you already have a large base of users for your application.

## Use CoinMarketCap ID Instead of Cryptocurrency Symbol
Utilizing common cryptocurrency symbols to reference cryptocurrencies on the API is easy and convenient but brittle. You should know that many cryptocurrencies have the same symbol, for example, there are currently three cryptocurrencies that commonly refer to themselves by the symbol HOT. Cryptocurrency symbols also often change with cryptocurrency rebrands. When fetching cryptocurrency by a symbol that matches several active cryptocurrencies we return the one with the highest market cap at the time of the query. To ensure you always target the cryptocurrency you expect, use our permanent CoinMarketCap IDs. These IDs are used reliably by numerous mission critical platforms and never change.

We make fetching a map of all active cryptocurrencies' CoinMarketCap IDs very easy. Just call our **/cryptocurrency/map** endpoint to receive a list of all active currencies mapped to the unique id property. This map also includes other typical identifiying properties like **name**, **symbol** and platform **token_address** that can be cross referenced. In cryptocurrency calls you would then send, for example **id=1027**, instead of **symbol=ETH**. *It's strongly recommended that any production code utilize these IDs for cryptocurrencies, exchanges, and markets to future-proof your code.*

## Use the Right Endpoints for the Job
You may have noticed that **/cryptocurrency/listings/latest** and **/cryptocurrency/quotes/latest** return the same crypto data but in different formats. This is because the former is for requesting paginated and ordered lists of all cryptocurrencies while the latter is for selectively requesting only the specific cryptocurrencies you require. Many endpoints follow this pattern, allow the design of these endpoints to work for you!

## Implement a Caching Strategy If Needed
There are standard legal data safeguards built into the Commercial User Terms that application developers should keep in mind. These Terms help prevent unauthorized scraping and redistributing of CMC data but are intentionally worded to allow legitimate local caching of market data to support the operation of your application. If your application has a significant user base and you are concerned with staying within the call credit and API throttling limits of your subscription plan consider implementing a data caching strategy.

For example instead of making a **/cryptocurrency/quotes/latest** call every time one of your application's users needs to fetch market rates for specific cryptocurrencies, you could pre-fetch and cache the latest market data for every cryptocurrency in your application's local database every 60 seconds. This would only require 1 API call, **/cryptocurrency/listings/latest?limit=5000**, every 60 seconds. Then, anytime one of your application's users need to load a custom list of cryptocurrencies you could simply pull this latest market data from your local cache without the overhead of additional calls. This kind of optimization is practical for customers with large, demanding user bases.

## Code Defensively to Ensure a Robust REST API Integration
Whenever implementing any high availability REST API service for mission critical operations it's recommended to code defensively. Since the API is versioned, any breaking request or response format change would only be introduced through new versions of each endpoint, however existing endpoints may still introduce new convenience properties over time.

We suggest these best practices:

- You should parse the API response JSON as JSON and not through a regular expression or other means to avoid brittle parsing logic.