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
each testing runs for 1000 times 

##### Case 1: 20 byte


| API tool | Avg_time(ms) |
| -------- | -------- | 
| HTTP     |  0.071 ms    | 
| Restsharp    |  0.075 ms   | 
| Refit     | 0.084 ms     | 


##### Case 1: 100 byte

| API tool | Avg_time(ms) | 
| -------- | -------- |
| HTTP     |  0.076 ms    | 
| Restsharp    |  0.164 ms  | 
| Refit     | 0.108 ms  |   

##### Case 1: 500 byte

| API tool | Avg_time(ms) | 
| -------- | -------- |
| HTTP     |  0.147 ms    | 
| Restsharp    |  0.49 ms  | 
| Refit     | 0.15 ms  |   


##### Case 1: 1024 byte

| API tool | Avg_time(ms) | 
| -------- | -------- |
| HTTP     |  0.13 ms    | 
| Restsharp    |  0.178 ms  | 
| Refit     | 0.135 ms  |   


##### Case 1: 2048 byte

| API tool | Avg_time(ms) | 
| -------- | -------- |
| HTTP     |  0.115 ms    | 
| Restsharp    |  0.273 ms  | 
| Refit     | 0.153 ms  |  

##### Case 1: 3072 byte
| API tool | Avg_time(ms) | 
| -------- | -------- |
| HTTP     |  0.119 ms    | 
| Restsharp    | 0.323 ms  | 
| Refit     |  0.141 ms  |  

##### Case 1: 4096 byte

| API tool | Avg_time(ms) | 
| -------- | -------- |
| HTTP     |  0.179 ms    | 
| Restsharp    |  0.119 ms  | 
| Refit     | 0.14 ms  |  


##### Statistical Analysis

