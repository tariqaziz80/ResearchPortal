using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblReviewAreaQuestionCommentAn
{
    public long AreaOfQuestionCommentId { get; set; }

    public string? AreaOfCommentAns { get; set; }

    public long? AreaOfQuestionId { get; set; }

    public long? ManuscriptId { get; set; }

    public long? ReviwerId { get; set; }

    public virtual TblReviewAreaQuestion? AreaOfQuestion { get; set; }
}
