using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {

        string folderDetails = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Delivery.json");
        private readonly ILogger<DeliveryController> _logger;
        public DeliveryController(ILogger<DeliveryController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]")]
        ///api/Delivery/GetDelivery
        public List<Delivery> GetDelivery()
        {

            var json = System.IO.File.ReadAllText(folderDetails);
            List<Delivery> deliveries = JsonConvert.DeserializeObject<List<Delivery>>(json);

            return deliveries;
        }





        [HttpPost("[action]")]

        ///api/Delivery/CreateDelivery
        public IActionResult CreateDelivery([FromBody] object jsonString)
        {
            List<Delivery> deliveries = GetDelivery();

            using (StreamWriter file = System.IO.File.CreateText(folderDetails))
            {
                string del = jsonString.ToString();
                Delivery delivery = JsonConvert.DeserializeObject<Delivery>(del);

                if (!ModelState.IsValid)
                {
                    BadRequest("Invalid Delivery data");
                }
                else
                {
                    delivery.GenerateId(deliveries);
                    deliveries.Add(delivery);
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, deliveries);

                }

                return Ok(deliveries);

            }

        }
    }
}
