using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblFilesAuthor
{
    public long ManuscriptFileId { get; set; }

    public string? AuthorFileNew { get; set; }

    public string? AuthorFileResubmitted { get; set; }

    public string? AuthorFileNewExt { get; set; }

    public string? AuthorFileResubmittedExt { get; set; }

    public long? ManuscriptId { get; set; }

    public long? AuthorId { get; set; }

    public DateTime? FileNewDate { get; set; }

    public DateTime? FileResubmittedDate { get; set; }

    public virtual TblManuscript? Manuscript { get; set; }
}
