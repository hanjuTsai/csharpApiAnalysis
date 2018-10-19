# C# Api Analysis

## Api Tool in nuget packages

1. [HTTP Client](https://msdn.microsoft.com/en-us/library/system.net.http.httpclient(v=vs.118).aspx)
2. [Refit](https://github.com/reactiveui/refit)
1. [RestSharp](http://restsharp.org)


## APi Server
Execute the local server before running the csharp project 
```{shell}
./atir
```

## How to run the project

1. Download the dotnet commandline tool
2. Run the server mentioned above.
3. Type the command below into commandline
```
dotnet run --project APITest <http|restsharp|refit> <num-of-byte>
```



