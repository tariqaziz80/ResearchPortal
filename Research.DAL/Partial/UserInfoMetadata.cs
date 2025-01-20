using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.DAL.Partial
{
    [MetadataType(typeof(UserInfoMetadata))]
    public class UserInfoMetadata
    {
        public class mvLoginUser
        {
            public long UserId { get; set; }

            public string? EmailId { get; set; }

            public string? FirstName { get; set; }

            public string? LastName { get; set; }

            public string? SPassword { get; set; }

            public string? TitleName { get; set; }

            public int? DegreeId { get; set; }

            public string? OrganizationName { get; set; }

            public string? SMobile { get; set; }

            public string? EmailSecondary { get; set; }

            public string? SAddress { get; set; }

            public int? CountryId { get; set; }

            public bool? IsActive { get; set; }

            public bool? IsVerified { get; set; }

            public DateTime? CreatedDate { get; set; }

            public string? SGender { get; set; }

            public string? SUserimage { get; set; }

        }
    }
}
