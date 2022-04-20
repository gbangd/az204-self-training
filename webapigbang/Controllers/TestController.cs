using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Blobs;
using System.Threading.Tasks;

namespace webapigbang.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private const string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=gblearningsa;AccountKey=AABSA17mcA2Y9+Czeo77/fq/00DrKvvMhxL0fRNdXZ/KiJuQlGUdtuCisSZsn3qhonZQyOkw0b6B+AStaL6H2g==;EndpointSuffix=core.windows.net";
    private const string ContainerName = "container";

    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var blobClient = new BlobContainerClient(ConnectionString,ContainerName);
        var blobNames = blobClient.GetBlobs().Select(x => x.Name);
        return Ok(blobNames);
    } 

}
