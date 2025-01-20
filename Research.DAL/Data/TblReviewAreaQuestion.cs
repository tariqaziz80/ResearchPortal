using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblReviewAreaQuestion
{
    public long AreaOfQuestionId { get; set; }

    public string? AreaOfQuestion { get; set; }

    public string? AreaOfComment { get; set; }

    public int? DisplayOrder { get; set; }

    public int? StageOfArea { get; set; }

    public int? PaperTypeId { get; set; }

    public virtual ICollection<TblReviewAreaQuestionCommentAn> TblReviewAreaQuestionCommentAns { get; set; } = new List<TblReviewAreaQuestionCommentAn>();

    public virtual ICollection<TblReviewAreaQuestionDetail> TblReviewAreaQuestionDetails { get; set; } = new List<TblReviewAreaQuestionDetail>();
}
