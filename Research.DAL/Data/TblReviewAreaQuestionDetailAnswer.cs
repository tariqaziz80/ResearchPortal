using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblReviewAreaQuestionDetailAnswer
{
    public long AreaQuestionDetailAnsId { get; set; }

    public int? AnswerId { get; set; }

    public long? AreaQuestionDetailId { get; set; }

    public long? ManuscriptId { get; set; }

    public long? ReviwerId { get; set; }

    public virtual TblReviewAnswerStatus? Answer { get; set; }

    public virtual TblReviewAreaQuestionDetail? AreaQuestionDetail { get; set; }
}
