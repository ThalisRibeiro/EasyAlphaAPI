# EasyAlphaAPI
C# Library made to help getting info from AlphaVantage

For this version you can get stocks info 
first you need to get your credencial at https://www.alphavantage.co and search for free key

On your project using AlphaAPi insert your key 
```
Api.SetKey("YourKeyHere") 
```

Now you only have one method QuoteEndpoint(string stock, string suffix=("")) that return a object with converted data from the site, if the stock is on nadax, you don't need suffix
but if isn't, you need to put one, for example brazilian stocks uses .SA suffix

the object returned has the open, high, low and price, you can use all of it or if you only need one you can use the QuoteEndPoint(stock).InfoYouNeed
example: IBMPrice = Api.QuoteEndpoint("IBM").Price
