using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblReviewAnswerStatus
{
    public int ReviewerAnswerStatusId { get; set; }

    public string? ReviewerAnswerStatus { get; set; }

    public int? AnswerTypeId { get; set; }

    public virtual ICollection<TblReviewAreaQuestionDetailAnswer> TblReviewAreaQuestionDetailAnswers { get; set; } = new List<TblReviewAreaQuestionDetailAnswer>();
}
