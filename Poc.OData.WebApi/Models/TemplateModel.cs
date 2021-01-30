using System;
using System.Runtime.Serialization;


namespace Poc.OData.WebApi.Models
{
    [DataContract]
    public class TemplateModel
    {
        [DataMember(EmitDefaultValue = false)]
        public int Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int Score { get; set; }
    }
}
