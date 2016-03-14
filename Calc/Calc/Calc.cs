using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

//http://www.c-sharpcorner.com/UploadFile/mahakgupta/a-simple-example-of-wcf-service/

namespace Calc
{
    [DataContract]
    public class Calc
    {
        [DataMember]
        public double n1;
        [DataMember]
        public double n2;
    }
}

