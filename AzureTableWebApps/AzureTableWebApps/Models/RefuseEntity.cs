using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;


namespace AzureTableWebApps.Models
{
    public class RefuseEntity : TableEntity
    {
        public RefuseEntity()
        {
        }
        public RefuseEntity(string areaname, string areaid, double latitude, double longitude, DateTime timereported, bool hasbeencollected, DateTime timecollected)
        {
            this.PartitionKey = areaname;
            this.RowKey = areaid;
            Latitude = latitude;
            Longitude = longitude;
            TimeReported = timereported;
            HasBeen_Collected = hasbeencollected;
            TimeCollected = timecollected;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime TimeReported { get; set; }
        public DateTime TimeCollected { get; set; }
        public bool HasBeen_Collected { get; set; }
    }
}
