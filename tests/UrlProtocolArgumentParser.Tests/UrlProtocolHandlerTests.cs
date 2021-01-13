using System;
using System.Net;
using System.Text.Json;
using Xunit;

namespace UrlProtocolArgumentParser.Tests
{
    class TestType
    {
        public int Id { get; set; }
        
        public string Mode { get; set; }
        
        public string SomethingElse { get; set; }
    }
    public class UrlProtocolHandlerTests
    {
        [Fact]
        public void TestHandler()
        {
            var testUrl = "test-protocol://value=avalue&uploadUrl=somethingthatwillneedencoding";
            string handlerReturnValue = null;
            var protocolHandler = new UrlProtocolArgumentHandler(testUrl, (urlArg) =>
            {
                var argValue = (string)urlArg.Value;
                return urlArg.Name.ToLower() == "value" && argValue.ToLower() == "avalue";
            });

            protocolHandler.Add<string>("value");
            protocolHandler.Add<string>("uploadUrl");
            protocolHandler.Handler = UrlProtocolCommandHandler.CreateHandler<string>((string uploadUrl) =>
            {
                handlerReturnValue = uploadUrl;
            });
            protocolHandler.Run();

            Assert.NotNull(handlerReturnValue);
            Assert.Equal("somethingthatwillneedencoding", handlerReturnValue);
        }

        [Fact]
        public void TestProtocolUrlEnding()
        {
            var url = "test-protocol://arg1=val1/";
            string returnValue = null;
            var protocolHandler = new UrlProtocolArgumentHandler(url, (queryArg) => 
            {
                return true;
            });

            protocolHandler.Add<string>("arg1");
            protocolHandler.Handler = UrlProtocolCommandHandler.CreateHandler<string>((string arg1) =>
            {
                returnValue = arg1;
            });
            protocolHandler.Run();
            Assert.NotNull(returnValue);
            Assert.Equal("val1", returnValue);
        }

        [Fact]
        public void TestProtocolUrlWithEncodedString()
        {
            var url = "test-protocol://someUrl=https%3A%2F%2Fsome-domain.com%2Fsomeroute&isEnabled=true";
            string someUrlResult = null;
            var isEnabledResult = false;
            var protocolHandler = new UrlProtocolArgumentHandler(url, (queryParemeter) =>
            {
                return true;
            });
            protocolHandler.Add<string>("someUrl");
            protocolHandler.Add<bool>("isEnabled");
            protocolHandler.Handler = UrlProtocolCommandHandler.CreateHandler<string, bool>((string someUrl, bool isEnabled) =>
            {
                someUrlResult = someUrl;
                isEnabledResult = isEnabled;
            });
            protocolHandler.Run();
            Assert.NotNull(someUrlResult);
            Assert.Equal("https://some-domain.com/someroute", someUrlResult);
            Assert.True(isEnabledResult);
        }

        [Fact]
        public void TestFailedCondition()
        {
            var testUrl = "test-protocol://uploadUrl=somethingthatwillneedencoding";
            var handlerReturnVal = "";
            var protocolHandler = new UrlProtocolArgumentHandler(testUrl, (urlArg) => 
            {
                var argValue = (string)urlArg.Value;
                return urlArg.Name.ToLower() == "queryParam" && argValue == "somevalue";
            });
            protocolHandler.Add<string>("uploadUrl");
            protocolHandler.Handler = UrlProtocolCommandHandler.CreateHandler<string>((string uploadUrl) => 
            {
                handlerReturnVal = uploadUrl;
            });
            protocolHandler.Run();
            Assert.Equal("", handlerReturnVal);
        }

        [Fact]
        public void TestJsonObjectParam()
        {
            var newTestObj = new TestType
            {
                Id = 1,
                Mode = "jsonObj",
                SomethingElse = "hello world"
            };

            var jsonString = JsonSerializer.Serialize(newTestObj);
            var encodedJsonString = WebUtility.UrlEncode(jsonString);
            var url = $"test-protocol://encodedValue={encodedJsonString}";
            var protocolHandler = new UrlProtocolArgumentHandler(url, (urlArg) =>
            {
                return true;
            });
            // todo this string and the variable name in the handler need to match and that doesn't seem ideal
            protocolHandler.Add<TestType>("encodedValue");
            protocolHandler.Handler = UrlProtocolCommandHandler.CreateHandler<TestType>((encodedValue) => 
            {
                var outputVal = encodedValue;
                Assert.IsType<TestType>(encodedValue);
            });
            protocolHandler.Run();
        }
    }
}
