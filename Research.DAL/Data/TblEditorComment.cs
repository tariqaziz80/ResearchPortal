using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblEditorComment
{
    public long EditorCommentId { get; set; }

    public string? EditorComment { get; set; }

    public DateTime? EditorCommentDate { get; set; }

    public int? EditorCommentstatusId { get; set; }

    public long? ManuscriptId { get; set; }

    public long? AuthorId { get; set; }

    public long? EditorId { get; set; }

    public int? EditorCommentStatusid { get; set; }

    public long? ReviewerId { get; set; }

    public int? ReviewerIntvitetypeId { get; set; }
}
