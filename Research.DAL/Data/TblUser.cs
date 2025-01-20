using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblUser
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

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<TblManuscript> TblManuscripts { get; set; } = new List<TblManuscript>();

    public virtual ICollection<TblUserRole> TblUserRoles { get; set; } = new List<TblUserRole>();
}
