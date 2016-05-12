using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Topspots.Models;

namespace Topspots.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TopSpotsController : ApiController
    {
        // GET: api/TopSpots
        public IEnumerable<Topspot> Get()
        {
            //Grabs(reads) json file
            string json = File.ReadAllText(@"C:\Users\Cherr\Documents\dev\11-TopSpotsAPI\Topspots\Topspots\topspots.json");
            var output = JsonConvert.DeserializeObject<List<Topspot>>(json);
            return output;
        }

        // GET: api/TopSpots/5
        public object Get(int id)
        {
            return "value";
        }

        // POST: api/TopSpots
        public Topspot Post(Topspot spot)
        {
            //Read the JSON file from the system
            string json = File.ReadAllText(@"C:\Users\Cherr\Documents\dev\11-TopSpotsAPI\Topspots\Topspots\topspots.json");
            var output = JsonConvert.DeserializeObject<List<Topspot>>(json);

            //Adds to list
            output.Add(spot);

            //Saves added list 
            string NewJson = Newtonsoft.Json.JsonConvert.SerializeObject(output);
            File.WriteAllText(@"C:\Users\Cherr\Documents\dev\11-TopSpotsAPI\Topspots\Topspots\topspots.json", NewJson);

            return spot;
        }

        // PUT: api/TopSpots/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TopSpots/5
        public void Delete(int id)
        {
        }
    }
}
