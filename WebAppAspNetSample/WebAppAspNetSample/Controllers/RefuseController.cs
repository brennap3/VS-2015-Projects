using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Configuration;



namespace WebAppAspNetSample.Controllers
{
    public class ProductsController : ApiController
    {
        

        //public IEnumerable<Product> GetAllProducts()
        //{
          //  return products;
        //}

        public IHttpActionResult GetRefuse(string pcode)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference("Refuse");

            TableQuery<Models.RefuseEntity> query = new TableQuery<Models.RefuseEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, pcode));


            var results = table.ExecuteQuery(query).ToList();
            if (results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }
    }
}