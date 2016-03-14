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


namespace WebApplication5
{
    // Use "Namespace" attribute with an unique name,to make service uniquely         discoverable  
    [WebService(Namespace = "http://tempuri.org/")]
    // To indicate service confirms to "WsiProfiles.BasicProfile1_1" standard,   
    // if not, it will throw compile time error.  
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    // To restrict this service from getting added as a custom tool to toolbox  
    [System.ComponentModel.ToolboxItem(false)]
    //As, WsiProfiles.BasicProfile1_1 doesn't support method overloading we are getting this exception.
    //Now, either remove this “[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]” attribute or
    //make it “[WebServiceBinding(ConformsTo = WsiProfiles.None)]”. 
    // To allow this Web Service to be called from script, using ASP.NET AJAX  
    [System.Web.Script.Services.ScriptService]
    public class MyService 
    {
        [WebMethod]
        public string RetrnRefusePCode(string pcode)
        {
            //create the storage account
            //maybe move the code to a controller based class and call the method from there

            //https://azure.microsoft.com/en-us/documentation/articles/web-sites-dotnet-rest-service-aspnet-api-sql-database/
            //see above very usefull resource


            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference("Refuse");

            TableQuery<RefuseEntity> query = new TableQuery<RefuseEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, pcode));

            var results = table.ExecuteQuery(query).ToList();

            var json = JsonConvert.SerializeObject(results);

            return json;
        }

        [WebMethod]
        public void InsertRefuse(string pareaname, string pareaid, double platitude, string plongitude)
        {
            //create the storage account
            //maybe move the code to a controller based class and call the method from there

            //

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference("Refuse");

            DateTime nowDate = DateTime.Now;

            DateTime collectionDate = nowDate.AddYears(1000);

            RefuseEntity refuse = new RefuseEntity(pareaname, pareaid, platitude, plongitude, nowDate, false, collectionDate);
           
            TableOperation insertOperation = TableOperation.Insert(refuse);

            table.Execute(insertOperation);

        }


    }






    public class RefuseEntity : TableEntity
    {
        public RefuseEntity()
        {
        }
        public RefuseEntity(string areaname, string areaid, double platitude, string plongitude, DateTime timereported, bool hasbeencollected, DateTime timecollected)
        {
            this.PartitionKey = areaname;
            this.RowKey = areaid;
            this.latitude = platitude;
            this.longitude = plongitude;
            this.Timereported = timereported;
            this.HasBeen_Collected = hasbeencollected;
            this.Timecollected = timecollected;
        }

        public double latitude { get; set; }
        public string longitude { get; set; }
        public DateTime Timereported { get; set; }
        public DateTime Timecollected { get; set; }
        public bool HasBeen_Collected { get; set; }
    }




}
