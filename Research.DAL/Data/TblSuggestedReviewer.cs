using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblSuggestedReviewer
{
    public long SuggestedReviwerId { get; set; }

    public long? ReviwerId { get; set; }

    public long? ManuscriptId { get; set; }
}
