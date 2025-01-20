using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblReviewAreaQuestionDetail
{
    public long AreaQuestionDetailId { get; set; }

    public string? AreaQuestionText { get; set; }

    public long? AreaOfQuestionId { get; set; }

    public int? DisplayOrder { get; set; }

    public virtual TblReviewAreaQuestion? AreaOfQuestion { get; set; }

    public virtual ICollection<TblReviewAreaQuestionDetailAnswer> TblReviewAreaQuestionDetailAnswers { get; set; } = new List<TblReviewAreaQuestionDetailAnswer>();
}
