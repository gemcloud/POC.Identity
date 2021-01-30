using System.ComponentModel.DataAnnotations;

namespace Poc.OData.WebApi.Models
{
    public partial class BaseApiEntityModel
    {
        [Key]
        public string Id { get; set; }
    }
}
