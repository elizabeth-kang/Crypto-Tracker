# CoinAPI

## Market Data - Starter Guide

https://docs.coinapi.io/#md-docs

**API:** RESTful
**Communication:** Request-response
**Description:** Stateless API providing the widest range of data

## Market Data - REST API

https://docs.coinapi.io/#md-rest-api

**Endpoints**

Production  (encrypted)      https://rest.coinapi.io/
Production  (unencrypted)    http://rest.coinapi.io/
Sandbox     (encrypted)      https://rest-sandbox.coinapi.io/
Sandbox     (unencrypted)    http://rest-sandbox.coinapi.io/


# General
## Authorization
To use resources that require authorized access, you will need to provide an API key to us when making HTTP requests.

There are 2 methods for passing the API key to us, you only need to use one:

1. Custom authorization header named **X-CoinAPI-Key**
2. Query string parameter named **apikey**

### Custom authorization header
You can authorize by providing additional custom header named **X-CoinAPI-Key** and API key as its value.

Assuming that your API key is **73034021-THIS-IS-SAMPLE-KEY**, then the authorization header you should send to us will look like:

**X-CoinAPI-Key: 73034021-THIS-IS-SAMPLE-KEY**

THIS METHOD IS RECOMMENDED BY US AND YOU SHOULD USE IT IN PRODUCTION ENVIRONMENTS

### Query string authorization parameter
You can authorize by providing an additional parameter named **apikey** with a value equal to your API key in the query string of your HTTP request.

Assuming that your API key is **73034021-THIS-IS-SAMPLE-KEY** and that you want to request all exchange rates from **BTC** asset, then your query string should look like this:

**GET /v1/exchangerate/BTC?apikey=73034021-THIS-IS-SAMPLE-KEY**

QUERY STRING METHOD MAY BE MORE PRACTICAL FOR DEVELOPMENT ACTIVITIES

## HTTP Requests
Each HTTP request must contain the header **Accept: application/json** as all our responses are in JSON format.

We encourage you to use the HTTP request header **Accept-Encoding: deflate, gzip** for all requests. This will indicate to us that we can deliver compressed data to you which on your side should be decompressed transparently.

# Exchange rates
Exchange rate is defined as (VWAP-24H) last 24 hour (rolling window over time) Volume Weighted Average Price across multiple data sources listed on our platform. We are selecting and managing the data sources that are used in the calculation based on multiple factors to provide data of highest quality.

## Get specific rate

Get exchange rate between pair of requested assets at specific or current time.

**HTTP Request** 

``` GET /v1/exchangerate/{asset_id_base}/{asset_id_quote}?time={time} ```

The following C# code
``` C#
var client = new RestClient("https://rest.coinapi.io/v1/exchangerate/BTC/USD");
var request = new RestRequest(Method.GET);
request.AddHeader("X-CoinAPI-Key", "73034021-THIS-IS-SAMPLE-KEY");
IRestResponse response = client.Execute(request);
```

returns JSON structured like this:

``` JSON
{
  "time": "2017-08-09T14:31:18.3150000Z",
  "asset_id_base": "BTC",
  "asset_id_quote": "USD",
  "rate": 3260.3514321215056208129867667
}
```