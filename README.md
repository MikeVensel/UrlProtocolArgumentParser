# UrlProtocolArgumentParser
This library was built to parse the argument string provided to an application when it is being used as a URL protocol handler. 

* Supports query parameters with values which are URL encoded JSON strings.
* Supports adding and running multiple handlers using a linq query to determine if they should run based on query parameters received.

## Usage
Implementing a protocol handler is pretty straight forward. One gotcha is that the name of the parameters in your handler method need to be the same as the query string parameter names they will be bound to when the handler runs. A few samples can be found below.

### Basic Usage
Below is a basic handler which will always run on the provided URL.

```csharp
var sampleUrl = "test-protocol://arg1=val1/";
var protocolHandler = new UrlProtocolArgumentHandler(sampleUrl, (queryArg) => 
{
    return true; // The handler always run
});

protocolHandler.Add<string>("arg1");
protocolHandler.Handler = UrlProtocolCommandHandler.CreateHandler<string>((string arg1) =>
{
    Console.WriteLine($"Arg1 value: {arg1}");
});

protocolHandler.Run();
```

### Conditionally run handler
Below is a handler that will only run if the url contained certain query parameters and values
```csharp
var sampleUrl = "test-protocol://queryParam=value";
var protocolHandler = new UrlProtocolArgumentHandler(sampleUrl, (urlArg) => 
{
    // The handler will be run only if there is a query string parameter called queryParam with a value of "value"
    var argValue = (string)urlArg.Value;
    return urlArg.Name.ToLower() == "queryParam" && argValue == "value";
});

protocolHandler.Add<string>("queryParam");
protocolHandler.Handler = UrlProtocolCommandHandler.CreateHandler<string>((string queryParam) => 
{
    Console.WriteLine($"queryParam value: {queryParam}");
});

protocolHandler.Run();
```

### Handler with URL encoded JSON string parameter
Below is an example of a URL which contains a URL encoded json string which can be deserialized to its type.
```csharp
// Create an encoded json string
var newTestObj = new TestType
{
    Id = 1,
    Mode = "jsonObj",
    SomethingElse = "hello world"
};

var jsonString = JsonSerializer.Serialize(newTestObj);
var encodedJsonString = WebUtility.UrlEncode(jsonString);
var url = $"test-protocol://queryParam=value&testType={encodedJsonString}";
var protocolHandler = new UrlProtocolArgumentHandler(url, (urlArg) =>
{
    return true; // The handler always run
});

protocolHandler.Add<string>("queryParam");
protocolHandler.Add<TestType>("testType");
protocolHandler.Handler = UrlProtocolCommandHandler.CreateHandler<string, TestType>((queryParam, testType) => 
{
    Console.WriteLine($"queryParam value: {queryParam}");
    Console.WriteLine($"TestType Id: {testType.Id}");
    Console.WriteLine($"testType Mode: {testType.Mode}");
    Console.WriteLine($"testType SomethingElse: {testType.SomethingElse}");
});

protocolHandler.Run();
```