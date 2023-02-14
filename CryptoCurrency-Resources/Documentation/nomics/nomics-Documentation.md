# API Server URL
The Nomics API runs at **https://api.nomics.com/v1**. All requests should be prefixed by the server URL.

# Authentication
## Key
You must include your API Key as a query parameter in every request you make. For example:

``` https://api.nomics.com/v1/markets?key=your-key-here ```

# Currencies Ticker

Price, volume, market cap, rank, and more for all currencies across 1 hour, 1 day, 7 day, 30 day, 365 day, and year to date intervals.

**id**
Example: ```ids=BTC,ETH,XRP```
Comma separated list of Nomics Currency IDs to filter result rows

**convert**
Example: ```convert=EUR```
Currency to quote ticker price, market cap, and volume values. May be a Fiat Currency or Cryptocurrency. Default is **USD**.

## Request Sample
### Javascript
``` Javascript
fetch("https://api.nomics.com/v1/supplies/history?key=your-key-here&currency=BTC&start=2018-04-14T00%3A00%3A00Z&end=2018-05-14T00%3A00%3A00Z")
  .then(response => response.json())
  .then(data => console.log(data))
```

## Response sample
**Content type:** application/json
``` JSON
[
  {
    "timestamp": "2018-05-14T00:04:31Z",
    "available": "17052037.0",
    "max": "21000000.0"
  }
]
```