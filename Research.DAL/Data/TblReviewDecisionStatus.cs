using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblReviewDecisionStatus
{
    public int ReviewerDecisionId { get; set; }

    public string? ReviewDecision { get; set; }
}
