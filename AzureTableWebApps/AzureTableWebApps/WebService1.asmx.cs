using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using AzureTableWebApps;
using Newtonsoft.Json;

namespace AzureTableWebApps
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string RetrnRefusePCode(string pcode)
        {
            //create the storage account
            //maybe move the code to a controller based class and call the method from there

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference("Refuse");
            
            TableQuery<Models.RefuseEntity> query = new TableQuery<Models.RefuseEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, pcode));

            List<Models.RefuseEntity> refuse = query.ToList();

            var json = JsonConvert.SerializeObject(refuse);

            return json;
        }
    }
}
