
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsomeAPIBottle
{
    public class BottleResponse
    {
        public string Bottle_Status {  get; set; }
        public float Confidence { get; set; }

        public string ElapsedTime { get; set; }

        public string Error { get;set; }

        public List<float> BoxCap { get; set; }

    }
}
