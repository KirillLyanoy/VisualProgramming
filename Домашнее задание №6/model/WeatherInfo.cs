using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz6.model
{
    internal class WeatherInfo
    {
        public List[]? List {  get; set; }
        public City? City { get; set; }

        public static implicit operator Task<object>(WeatherInfo v)
        {
            throw new NotImplementedException();
        }
    }
}
