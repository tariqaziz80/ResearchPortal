using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblPaperType
{
    public int PaperTypeId { get; set; }

    public string? PaperTypeName { get; set; }

    public virtual ICollection<TblManuscript> TblManuscripts { get; set; } = new List<TblManuscript>();
}
