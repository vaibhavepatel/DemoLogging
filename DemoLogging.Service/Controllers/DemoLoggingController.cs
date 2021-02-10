
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Sinks.Http;

namespace DemoLogging.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoLoggingController : Controller
    {
        ILogger<DemoLoggingController> _logger;

        public DemoLoggingController(ILogger<DemoLoggingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("KBPayload")]
        public IActionResult KBPayload(int size)
        {
            var payloadSize = ByteSize.KB * size;
            _logger.LogInformation($"PayloadSize: {size}KB; {CreatePayload(payloadSize)}");

            return Ok("Successfully Logged");
        }

        [HttpGet("MBPayload")]
        public IActionResult MBPayload(int size)
        {
            var payloadSize = ByteSize.MB * size;
            _logger.LogInformation($"PayloadSize: {size} MB; {CreatePayload(payloadSize)}");

            return Ok("Successfully Logged");
        }

        private string CreatePayload(long size)
        {
            return new string('0', (int)size);
        }
    }
}
