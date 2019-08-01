using Newtonsoft.Json;
using NLog;
using NLogWithELK.Models;
using System;
using System.Net;
using System.Web.Http;

namespace NLogWithELK.Controllers
{
    /// <summary>
    /// message api
    /// </summary>
    [RoutePrefix("api/msg")]
    public class MessageController : ApiController
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        [HttpGet, Route("")]
        public string SayHello(string name)
        {
            logger.Info(name);
            return $"Hello, {name}";
        }

        [HttpPost, Route("")]
        public IHttpActionResult AddPerson(Person person)
        {
            logger.Info(JsonConvert.SerializeObject(person));
            return Ok(person);
        }

        [HttpPut, Route("")]
        public IHttpActionResult EditPerson(Person person)
        {
            try
            {
                int zero = 0;
                int result = person.Age / zero;
                logger.Info(JsonConvert.SerializeObject(person));
                return Ok(person);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                return StatusCode(HttpStatusCode.BadGateway);
            }
        }
    }
}
