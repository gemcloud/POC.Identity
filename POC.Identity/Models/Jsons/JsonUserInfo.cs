using System.Collections.Generic;

namespace POC.Identity.Models.Jsons
{
    public class JsonUserInfo
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Roles { get; set; }
    }
}
