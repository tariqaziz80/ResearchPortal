using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblUserRole
{
    public long UserRoleId { get; set; }

    public int? RoleId { get; set; }

    public long? UserId { get; set; }

    public virtual TblRole? Role { get; set; }

    public virtual TblUser? User { get; set; }
}
