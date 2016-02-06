using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace WebApplication5
{
    // Use "Namespace" attribute with an unique name,to make service uniquely         discoverable  
    [WebService(Namespace = "http://tempuri.org/")]
    // To indicate service confirms to "WsiProfiles.BasicProfile1_1" standard,   
    // if not, it will throw compile time error.  
    //[WebServiceBinding(ConformsTo = WsiProfiles.None)]
    // To restrict this service from getting added as a custom tool to toolbox  
    [System.ComponentModel.ToolboxItem(false)]
    //As, WsiProfiles.BasicProfile1_1 doesn't support method overloading we are getting this exception.
    //Now, either remove this “[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]” attribute or
    //make it “[WebServiceBinding(ConformsTo = WsiProfiles.None)]”. 
    // To allow this Web Service to be called from script, using ASP.NET AJAX  
    [System.Web.Script.Services.ScriptService]
    public class MyService : WebService
    {
        [WebMethod]
        public int SumOfNums(int First, int Second)
        {
            return First + Second;
        }


        [WebMethod(MessageName = "SumOfFloats")]
        public float SumOfNums(float First, float Second)
        {
            return First + Second;
        }
    }
}
