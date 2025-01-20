using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblKeyword
{
    public long KeywordsId { get; set; }

    public string? Keywords { get; set; }

    public long? ManuscriptId { get; set; }

    public virtual TblManuscript? Manuscript { get; set; }
}
