using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using SampleTableStorages;

namespace SampleTableStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("foo:");
            
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            Console.WriteLine("tableClient:"+ tableClient.Credentials);
            Console.WriteLine("tableClient:" + tableClient.StorageUri);
            //
            CloudTable table = tableClient.GetTableReference("Refuse");
            Console.WriteLine("Table_Name: "+table.Name);
            
           TableQuery<RefuseEntity> query = new TableQuery<RefuseEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Dublin 6"));
            Console.WriteLine("query_count: " + query.TakeCount);
            foreach (RefuseEntity entity in table.ExecuteQuery(query))
            {
                
                Console.WriteLine("{0}, {1}", entity.PartitionKey, entity.RowKey);
            }

            Console.WriteLine("end:");


        }

        //private static RefuseEntity RetrieveRefuse()
        //{
           // string connStr = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
           // CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connStr);
           // CloudTableClient client = storageAccount.CreateCloudTableClient();
           // CloudTable table = client.GetTableReference("employee");
           // table.CreateIfNotExists();
           // TableOperation retOp = TableOperation.Retrieve<RefuseEntity>("Dublin 6", "2");
           // TableResult tr = table.Execute(retOp);
           // return tr.Result as RefuseEntity;
        //}

    }
}
