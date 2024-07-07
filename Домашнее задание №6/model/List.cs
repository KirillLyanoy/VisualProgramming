using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz6.model
{
    internal class List
    {
        public Main? Main { get; set; }
        public Weather[] Weather { get; set; }  
        public Wind? Wind { get; set; }
        public string? Dt_txt { get; set; }
    }
}
