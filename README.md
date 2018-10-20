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

1. Download the dotnet command line tool
2. Run the server mentioned above.
3. Type the command below into command line

```
dotnet run --project APITest <http|restsharp|refit> <num-of-byte>
```
## Analysis
### Note that:
1. Each testing runs for 1000 times 
2. The result may differs depends on the server's reponse time




##### Statistical Analysis
![](plot.png?raw=true)

| API Tool \bytes | 5 | 10 | 20 | 100 | 500 | 1024 | 2048 | 4096  |
| -------- | -------- | -------- | -------- | -------- | -------- | -------- | -------- |-------- |
| HTTP   | 0.063   | 0.002    | 0.002   | 0    | 0   | 0.001     | 0    | 0.001   |
| Restsharp    | 0.103     | 0.002     | 0     |0.008     | 0.004    | 0   |0.003  | 0.001|
| Refit     | 0.079 | 0.001 | 0 | 0 | 0.003 | 0.011 | 0.003 | 0.001|