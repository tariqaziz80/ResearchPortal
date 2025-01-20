using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblReviewFinding
{
    public long ReviewerFindingId { get; set; }

    public int? ReviewerDecisionId { get; set; }

    public string? ReviewerCommentForEditor { get; set; }

    public long? ManuscriptId { get; set; }

    public long? ReviwerId { get; set; }
}
