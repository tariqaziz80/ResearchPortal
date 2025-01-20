using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblManuscript
{
    public long ManuscriptId { get; set; }

    public string? ManuscriptMainId { get; set; }

    public int? PaperTypeid { get; set; }

    public string? PaperTitle { get; set; }

    public string? PaperAbstract { get; set; }

    public string? FundingInfo { get; set; }

    public string? DeclarationInfo { get; set; }

    public string? AcknowledgeInfo { get; set; }

    public long? AuthorId { get; set; }

    public int? StatusId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual TblUser? Author { get; set; }

    public virtual TblPaperType? PaperType { get; set; }

    public virtual ICollection<TblFilesAuthor> TblFilesAuthors { get; set; } = new List<TblFilesAuthor>();

    public virtual ICollection<TblKeyword> TblKeywords { get; set; } = new List<TblKeyword>();
}
