using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Research.DAL.Data;

public partial class DbResearchPortalContext : DbContext
{
    public DbResearchPortalContext()
    {
    }

    public DbResearchPortalContext(DbContextOptions<DbResearchPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEditorComment> TblEditorComments { get; set; }

    public virtual DbSet<TblEditorCommentStatus> TblEditorCommentStatuses { get; set; }

    public virtual DbSet<TblEditorGeneralStatus> TblEditorGeneralStatuses { get; set; }

    public virtual DbSet<TblFilesAuthor> TblFilesAuthors { get; set; }

    public virtual DbSet<TblFilesReviewer> TblFilesReviewers { get; set; }

    public virtual DbSet<TblKeyword> TblKeywords { get; set; }

    public virtual DbSet<TblManuscript> TblManuscripts { get; set; }

    public virtual DbSet<TblPaperType> TblPaperTypes { get; set; }

    public virtual DbSet<TblReviewAnswerStatus> TblReviewAnswerStatuses { get; set; }

    public virtual DbSet<TblReviewAreaQuestion> TblReviewAreaQuestions { get; set; }

    public virtual DbSet<TblReviewAreaQuestionCommentAn> TblReviewAreaQuestionCommentAns { get; set; }

    public virtual DbSet<TblReviewAreaQuestionDetail> TblReviewAreaQuestionDetails { get; set; }

    public virtual DbSet<TblReviewAreaQuestionDetailAnswer> TblReviewAreaQuestionDetailAnswers { get; set; }

    public virtual DbSet<TblReviewDecisionStatus> TblReviewDecisionStatuses { get; set; }

    public virtual DbSet<TblReviewFinding> TblReviewFindings { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblSuggestedReviewer> TblSuggestedReviewers { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserRole> TblUserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SJC53GR;Initial Catalog=db_ResearchPortal;Persist Security Info=False;User ID=sa;Password=tariq123;Encrypt=false;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblEditorComment>(entity =>
        {
            entity.HasKey(e => e.EditorCommentId);

            entity.ToTable("tblEditorComment");

            entity.Property(e => e.EditorCommentId).HasColumnName("editor_comment_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.EditorComment)
                .HasMaxLength(1000)
                .HasColumnName("editor_comment");
            entity.Property(e => e.EditorCommentDate)
                .HasColumnType("datetime")
                .HasColumnName("editor_comment_date");
            entity.Property(e => e.EditorCommentStatusid).HasColumnName("editor_comment_statusid");
            entity.Property(e => e.EditorCommentstatusId).HasColumnName("editor_commentstatus_id");
            entity.Property(e => e.EditorId).HasColumnName("editor_id");
            entity.Property(e => e.ManuscriptId).HasColumnName("manuscript_id");
            entity.Property(e => e.ReviewerId).HasColumnName("reviewer_id");
            entity.Property(e => e.ReviewerIntvitetypeId).HasColumnName("reviewer_intvitetype_id");
        });

        modelBuilder.Entity<TblEditorCommentStatus>(entity =>
        {
            entity.HasKey(e => e.EditorCommentStatusid);

            entity.ToTable("tblEditorCommentStatus");

            entity.Property(e => e.EditorCommentStatusid)
                .ValueGeneratedNever()
                .HasColumnName("editor_comment_statusid");
            entity.Property(e => e.EditorComment)
                .HasMaxLength(200)
                .HasColumnName("editor_comment");
        });

        modelBuilder.Entity<TblEditorGeneralStatus>(entity =>
        {
            entity.HasKey(e => e.EditorGeneralStatusid);

            entity.ToTable("tblEditorGeneralStatus");

            entity.Property(e => e.EditorGeneralStatusid)
                .ValueGeneratedNever()
                .HasColumnName("editor_general_statusid");
            entity.Property(e => e.EditorGeneralStatus)
                .HasMaxLength(200)
                .HasColumnName("editor_general_status");
        });

        modelBuilder.Entity<TblFilesAuthor>(entity =>
        {
            entity.HasKey(e => e.ManuscriptFileId);

            entity.ToTable("tblFilesAuthor");

            entity.Property(e => e.ManuscriptFileId).HasColumnName("manuscript_file_id");
            entity.Property(e => e.AuthorFileNew)
                .HasMaxLength(200)
                .HasColumnName("author_file_new");
            entity.Property(e => e.AuthorFileNewExt)
                .HasMaxLength(200)
                .HasColumnName("author_file_new_ext");
            entity.Property(e => e.AuthorFileResubmitted)
                .HasMaxLength(200)
                .HasColumnName("author_file_resubmitted");
            entity.Property(e => e.AuthorFileResubmittedExt)
                .HasMaxLength(200)
                .HasColumnName("author_file_resubmitted_ext");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.FileNewDate)
                .HasColumnType("datetime")
                .HasColumnName("file_new_date");
            entity.Property(e => e.FileResubmittedDate)
                .HasColumnType("datetime")
                .HasColumnName("file_resubmitted_date");
            entity.Property(e => e.ManuscriptId).HasColumnName("manuscript_id");

            entity.HasOne(d => d.Manuscript).WithMany(p => p.TblFilesAuthors)
                .HasForeignKey(d => d.ManuscriptId)
                .HasConstraintName("FK_tblFilesAuthor_tblManuscript");
        });

        modelBuilder.Entity<TblFilesReviewer>(entity =>
        {
            entity.HasKey(e => e.ReviewerFileId);

            entity.ToTable("tblFilesReviewer");

            entity.Property(e => e.ReviewerFileId).HasColumnName("reviewer_file_id");
            entity.Property(e => e.FileNewDatetime)
                .HasColumnType("datetime")
                .HasColumnName("file_new_datetime");
            entity.Property(e => e.FileResubmittedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("file_resubmitted_datetime");
            entity.Property(e => e.ManuscriptFileId).HasColumnName("manuscript_file_id");
            entity.Property(e => e.ReviewerFileExt)
                .HasMaxLength(10)
                .HasColumnName("reviewer_file_ext");
            entity.Property(e => e.ReviewerFileResubmitted)
                .HasMaxLength(200)
                .HasColumnName("reviewer_file_resubmitted");
            entity.Property(e => e.ReviewerFileResubmittedExt)
                .HasMaxLength(10)
                .HasColumnName("reviewer_file_resubmitted_ext");
            entity.Property(e => e.ReviewerFileUrl)
                .HasMaxLength(200)
                .HasColumnName("reviewer_file_url");
            entity.Property(e => e.ReviewerId).HasColumnName("reviewer_id");
        });

        modelBuilder.Entity<TblKeyword>(entity =>
        {
            entity.HasKey(e => e.KeywordsId);

            entity.ToTable("tblKeywords");

            entity.Property(e => e.KeywordsId).HasColumnName("keywords_id");
            entity.Property(e => e.Keywords)
                .HasMaxLength(800)
                .HasColumnName("keywords");
            entity.Property(e => e.ManuscriptId).HasColumnName("manuscript_id");

            entity.HasOne(d => d.Manuscript).WithMany(p => p.TblKeywords)
                .HasForeignKey(d => d.ManuscriptId)
                .HasConstraintName("FK_tblKeywords_tblManuscript");
        });

        modelBuilder.Entity<TblManuscript>(entity =>
        {
            entity.HasKey(e => e.ManuscriptId);

            entity.ToTable("tblManuscript");

            entity.Property(e => e.ManuscriptId).HasColumnName("manuscript_id");
            entity.Property(e => e.AcknowledgeInfo)
                .HasMaxLength(200)
                .HasColumnName("acknowledge_info");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeclarationInfo)
                .HasMaxLength(200)
                .HasColumnName("declaration_info");
            entity.Property(e => e.FundingInfo)
                .HasMaxLength(500)
                .HasColumnName("funding_info");
            entity.Property(e => e.ManuscriptMainId)
                .HasMaxLength(200)
                .HasColumnName("manuscript_main_id");
            entity.Property(e => e.PaperAbstract)
                .HasMaxLength(1000)
                .HasColumnName("paper_abstract");
            entity.Property(e => e.PaperTitle)
                .HasMaxLength(1000)
                .HasColumnName("paper_title");
            entity.Property(e => e.PaperTypeid).HasColumnName("paper_typeid");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Author).WithMany(p => p.TblManuscripts)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_tblManuscript_tblUser");

            entity.HasOne(d => d.PaperType).WithMany(p => p.TblManuscripts)
                .HasForeignKey(d => d.PaperTypeid)
                .HasConstraintName("FK_tblManuscript_tblPaperType");
        });

        modelBuilder.Entity<TblPaperType>(entity =>
        {
            entity.HasKey(e => e.PaperTypeId);

            entity.ToTable("tblPaperType");

            entity.Property(e => e.PaperTypeId)
                .ValueGeneratedNever()
                .HasColumnName("paper_type_id");
            entity.Property(e => e.PaperTypeName)
                .HasMaxLength(200)
                .HasColumnName("paper_type_name");
        });

        modelBuilder.Entity<TblReviewAnswerStatus>(entity =>
        {
            entity.HasKey(e => e.ReviewerAnswerStatusId);

            entity.ToTable("tblReview_Answer_Status");

            entity.Property(e => e.ReviewerAnswerStatusId)
                .ValueGeneratedNever()
                .HasColumnName("reviewer_answer_status_id");
            entity.Property(e => e.AnswerTypeId).HasColumnName("answer_type_id");
            entity.Property(e => e.ReviewerAnswerStatus)
                .HasMaxLength(200)
                .HasColumnName("reviewer_answer_status");
        });

        modelBuilder.Entity<TblReviewAreaQuestion>(entity =>
        {
            entity.HasKey(e => e.AreaOfQuestionId);

            entity.ToTable("tblReview_Area_Question");

            entity.Property(e => e.AreaOfQuestionId).HasColumnName("area_of_question_id");
            entity.Property(e => e.AreaOfComment)
                .HasMaxLength(500)
                .HasColumnName("area_of_comment");
            entity.Property(e => e.AreaOfQuestion)
                .HasMaxLength(200)
                .HasColumnName("area_of_question");
            entity.Property(e => e.DisplayOrder).HasColumnName("display_order");
            entity.Property(e => e.PaperTypeId).HasColumnName("paper_type_id");
            entity.Property(e => e.StageOfArea).HasColumnName("stage_of_area");
        });

        modelBuilder.Entity<TblReviewAreaQuestionCommentAn>(entity =>
        {
            entity.HasKey(e => e.AreaOfQuestionCommentId);

            entity.ToTable("tblReview_Area_Question_CommentAns");

            entity.Property(e => e.AreaOfQuestionCommentId).HasColumnName("area_of_question_comment_id");
            entity.Property(e => e.AreaOfCommentAns)
                .HasMaxLength(500)
                .HasColumnName("area_of_comment_ans");
            entity.Property(e => e.AreaOfQuestionId).HasColumnName("area_of_question_id");
            entity.Property(e => e.ManuscriptId).HasColumnName("manuscript_id");
            entity.Property(e => e.ReviwerId).HasColumnName("reviwer_id");

            entity.HasOne(d => d.AreaOfQuestion).WithMany(p => p.TblReviewAreaQuestionCommentAns)
                .HasForeignKey(d => d.AreaOfQuestionId)
                .HasConstraintName("FK_tblReview_Area_Question_CommentAns_tblReview_Area_Question");
        });

        modelBuilder.Entity<TblReviewAreaQuestionDetail>(entity =>
        {
            entity.HasKey(e => e.AreaQuestionDetailId);

            entity.ToTable("tblReview_Area_Question_Detail");

            entity.Property(e => e.AreaQuestionDetailId).HasColumnName("area_question_detail_id");
            entity.Property(e => e.AreaOfQuestionId).HasColumnName("area_of_question_id");
            entity.Property(e => e.AreaQuestionText)
                .HasMaxLength(200)
                .HasColumnName("area_question_text");
            entity.Property(e => e.DisplayOrder).HasColumnName("display_order");

            entity.HasOne(d => d.AreaOfQuestion).WithMany(p => p.TblReviewAreaQuestionDetails)
                .HasForeignKey(d => d.AreaOfQuestionId)
                .HasConstraintName("FK_tblReview_Area_Question_Detail_tblReview_Area_Question");
        });

        modelBuilder.Entity<TblReviewAreaQuestionDetailAnswer>(entity =>
        {
            entity.HasKey(e => e.AreaQuestionDetailAnsId);

            entity.ToTable("tblReview_Area_Question_Detail_Answer");

            entity.Property(e => e.AreaQuestionDetailAnsId).HasColumnName("area_question_detail_ans_id");
            entity.Property(e => e.AnswerId).HasColumnName("answer_id");
            entity.Property(e => e.AreaQuestionDetailId).HasColumnName("area_question_detail_id");
            entity.Property(e => e.ManuscriptId).HasColumnName("manuscript_id");
            entity.Property(e => e.ReviwerId).HasColumnName("reviwer_id");

            entity.HasOne(d => d.Answer).WithMany(p => p.TblReviewAreaQuestionDetailAnswers)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK_tblReview_Area_Question_Detail_Answer_tblReview_Answer_Status");

            entity.HasOne(d => d.AreaQuestionDetail).WithMany(p => p.TblReviewAreaQuestionDetailAnswers)
                .HasForeignKey(d => d.AreaQuestionDetailId)
                .HasConstraintName("FK_tblReview_Area_Question_Detail_Answer_tblReview_Area_Question_Detail");
        });

        modelBuilder.Entity<TblReviewDecisionStatus>(entity =>
        {
            entity.HasKey(e => e.ReviewerDecisionId);

            entity.ToTable("tblReview_Decision_Status");

            entity.Property(e => e.ReviewerDecisionId)
                .ValueGeneratedNever()
                .HasColumnName("reviewer_decision_id");
            entity.Property(e => e.ReviewDecision)
                .HasMaxLength(200)
                .HasColumnName("review_decision");
        });

        modelBuilder.Entity<TblReviewFinding>(entity =>
        {
            entity.HasKey(e => e.ReviewerFindingId);

            entity.ToTable("tblReview_Findings");

            entity.Property(e => e.ReviewerFindingId).HasColumnName("reviewer_finding_id");
            entity.Property(e => e.ManuscriptId).HasColumnName("manuscript_id");
            entity.Property(e => e.ReviewerCommentForEditor)
                .HasMaxLength(1000)
                .HasColumnName("reviewer_comment_for_editor");
            entity.Property(e => e.ReviewerDecisionId).HasColumnName("reviewer_decision_id");
            entity.Property(e => e.ReviwerId).HasColumnName("reviwer_id");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("tblRole");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(200)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<TblSuggestedReviewer>(entity =>
        {
            entity.HasKey(e => e.SuggestedReviwerId);

            entity.ToTable("tblSuggestedReviewer");

            entity.Property(e => e.SuggestedReviwerId).HasColumnName("suggested_reviwer_id");
            entity.Property(e => e.ManuscriptId).HasColumnName("manuscript_id");
            entity.Property(e => e.ReviwerId).HasColumnName("reviwer_id");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("tblUser");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DegreeId).HasColumnName("degree_id");
            entity.Property(e => e.EmailId)
                .HasMaxLength(200)
                .HasColumnName("email_id");
            entity.Property(e => e.EmailSecondary)
                .HasMaxLength(200)
                .HasColumnName("email_secondary");
            entity.Property(e => e.FirstName)
                .HasMaxLength(200)
                .HasColumnName("first_name");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsVerified).HasColumnName("isVerified");
            entity.Property(e => e.LastName)
                .HasMaxLength(200)
                .HasColumnName("last_name");
            entity.Property(e => e.OrganizationName)
                .HasMaxLength(200)
                .HasColumnName("organization_name");
            entity.Property(e => e.SAddress)
                .HasMaxLength(500)
                .HasColumnName("sAddress");
            entity.Property(e => e.SGender)
                .HasMaxLength(200)
                .HasColumnName("sGender");
            entity.Property(e => e.SMobile)
                .HasMaxLength(20)
                .HasColumnName("sMobile");
            entity.Property(e => e.SPassword)
                .HasMaxLength(50)
                .HasColumnName("sPassword");
            entity.Property(e => e.SUserimage)
                .HasMaxLength(200)
                .HasColumnName("sUserimage");
            entity.Property(e => e.TitleName)
                .HasMaxLength(10)
                .HasColumnName("title_name");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
        });

        modelBuilder.Entity<TblUserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId);

            entity.ToTable("tblUserRole");

            entity.Property(e => e.UserRoleId).HasColumnName("user_role_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Role).WithMany(p => p.TblUserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_tblUserRole_tblRole");

            entity.HasOne(d => d.User).WithMany(p => p.TblUserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_tblUserRole_tblUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
