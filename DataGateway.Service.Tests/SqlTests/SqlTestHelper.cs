using System;
using System.IO;
using System.Threading.Tasks;
using Azure.DataGateway.Service.configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Azure.DataGateway.Service.Tests.SqlTests
{
    public class SqlTestHelper
    {
        public static IOptions<DataGatewayConfig> LoadConfig(string environment)
        {

            DataGatewayConfig datagatewayConfig = new();
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{environment}.json")
                .AddJsonFile($"appsettings.{environment}.overrides.json", optional: true)
                .Build();

            config.Bind(nameof(DataGatewayConfig), datagatewayConfig);

            return Options.Create(datagatewayConfig);
        }

        /// <summary>
        /// Converts strings to JSON objects and does a deep compare
        /// </summary>
        /// <remarks>
        /// This method of comparing JSON-s provides:
        /// <list type="number">
        /// <item> Insesitivity to spaces in the JSON formatting </item>
        /// <item> Insesitivity to order for elements in dictionaries. E.g. {"a": 1, "b": 2} = {"b": 2, "a": 1} </item>
        /// <item> Sensitivity to order for elements in lists. E.g. [{"a": 1}, {"b": 2}] ~= [{"b": 2}, {"a": 1}] </item>
        /// </list>
        /// In contrast, string comparing does not provide 1 and 2.
        /// </remarks>
        /// <param name="jsonString1"></param>
        /// <param name="jsonString2"></param>
        /// <returns>True if JSON objects are the same</returns>
        public static bool JsonStringsDeepEqual(string jsonString1, string jsonString2)
        {
            return JToken.DeepEquals(JToken.Parse(jsonString1), JToken.Parse(jsonString2));
        }

        /// <summary>
        /// Adds a useful failure message around the excpeted == actual operation
        /// <summary>
        public static void PerformTestEqualJsonStrings(string expected, string actual)
        {
            Assert.IsTrue(JsonStringsDeepEqual(expected, actual),
            $"\nExpected:<{expected}>\nActual:<{actual}>");
        }

        /// <summary>
        /// Tests for different aspects of the error in a GraphQL response
        /// </summary>
        public static void TestForErrorInGraphQLResponse(string response, string message = null, string statusCode = null)
        {
            Console.WriteLine(response);

            Assert.IsTrue(response.Contains("\"errors\""), "No error was found where error is expected.");

            if (message != null)
            {
                Assert.IsTrue(response.Contains(message), $"Message \"{message}\" not found in error");
            }

            if (statusCode != null)
            {
                Assert.IsTrue(response.Contains($"\"code\":\"{statusCode}\""), $"Status code \"{statusCode}\" not found in error");
            }
        }

        /// <summary>
        /// Performs the test by calling the given api, on the entity name,
        /// primaryKeyRoute and queryString. Uses the sql query string to get the result
        /// from database and asserts the results match.
        /// </summary>
        /// <param name="api">The REST api to be invoked.</param>
        /// <param name="entityName">The entity name.</param>
        /// <param name="primaryKeyRoute">The primary key portion of the route.</param>
        /// <param name="expected">string represents the expected result.</param>
        /// <param name="expectedStatusCode">int represents the returned http status code</param>
        public static async Task PerformApiTest(
            Func<string, string, Task<IActionResult>> api,
            string entityName,
            string primaryKeyRoute,
            string expected,
            int expectedStatusCode)

        {
            string actual;
            IActionResult actionResult = await api(entityName, primaryKeyRoute);
            // OkObjectResult will throw exception if we attempt cast to JsonResult
            if (actionResult is OkObjectResult)
            {
                OkObjectResult actualResult = (OkObjectResult)actionResult;
                Assert.AreEqual(expectedStatusCode, actualResult.StatusCode);
                actual = actualResult.Value.ToString();
            }
            else
            {
                JsonResult actualResult = (JsonResult)actionResult;
                actual = actualResult.Value.ToString();
            }

            // if whitespaces are not consistent JsonStringDeepEquals should be used
            // this will require deserializing and then serializing the strings for JSON
            Assert.AreEqual(expected, actual);
        }
    }
}