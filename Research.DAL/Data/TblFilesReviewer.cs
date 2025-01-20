using System;
using System.Collections.Generic;

namespace Research.DAL.Data;

public partial class TblFilesReviewer
{
    public long ReviewerFileId { get; set; }

    public string? ReviewerFileUrl { get; set; }

    public string? ReviewerFileExt { get; set; }

    public string? ReviewerFileResubmitted { get; set; }

    public string? ReviewerFileResubmittedExt { get; set; }

    public long? ManuscriptFileId { get; set; }

    public long? ReviewerId { get; set; }

    public DateTime? FileNewDatetime { get; set; }

    public DateTime? FileResubmittedDatetime { get; set; }
}
