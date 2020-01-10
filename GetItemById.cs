using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace TrainingBinus
{
    public static class GetItemById
    {
        [FunctionName("GetItemById")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetItem/{id}")] HttpRequestMessage req,
            [CosmosDB(
                databaseName: "ToDoList",
                collectionName: "Items",
                ConnectionStringSetting = "CosmosDBConnection",
                Id = "{id}")
            ]ToDoItem toDoItem,
            ILogger log)
        {
            log.LogInformation($"Function triggered");

            if (toDoItem == null)
            {
                log.LogInformation($"Item not found");
                return new NotFoundObjectResult("Id not found in collection");
            }
            else
            {
                log.LogInformation($"Found ToDo item {toDoItem.Description}");
                return new OkObjectResult(toDoItem);
            }
        }
    }
}
