using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poc.OData.WebApi.DataLayers.Entities
{
    public class StateProvince
    {
        public int ID { get; set; }
        public string CountryId { get; set; }
        public string Name { get; set; }
    }
}
