using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cypos
{
    public class ActivationModel
    {
        public string CustName { get; set; }
        public string CustPhone { get; set; }
        public string CustAddress { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NOfDays { get; set; }
        public string Serial { get; set; }
    }
}
