using System.Collections.Generic;

namespace Domain.Models
{
    public class CommonModel
    {
        public IEnumerable<AccountModel> accountModel { get; set; }
        public LocationModel locationModel { get; set; }
    }
}