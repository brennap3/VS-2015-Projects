using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;


namespace AzureTableStorage
{
    public class RefuseEntity : TableEntity
    {
        public RefuseEntity()
        {
        }
        public RefuseEntity(string partitionkey, string rowkey, double latitude, double longitude, DateTime timereported, bool hasbeencollected, DateTime timecollected)
        {
            PartitonKey = partitionkey;
            Rowkey = rowkey;
            Latitude = latitude;
            Longitude = longitude;
            TimeReported = timereported;
            HasBeen_Collected = hasbeencollected;
            TimeCollected = timecollected;
            RowKey = name;
        }
        public string PartitonKey { get; set; }
        public string Rowkey { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime TimeReported { get; set; }
        public DateTime TimeCollected { get; set; }
        public bool HasBeen_Collected{ get; set; }
    }
}
