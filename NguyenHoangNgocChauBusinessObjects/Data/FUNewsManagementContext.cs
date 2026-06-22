using Microsoft.EntityFrameworkCore;
using NguyenHoangNgocChauBusinessObjects.Models;

namespace NguyenHoangNgocChauBusinessObjects.Data;

public class FUNewsManagementContext(DbContextOptions<FUNewsManagementContext> options) : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<SystemAccount> SystemAccounts => Set<SystemAccount>();
    public DbSet<NewsArticle> NewsArticles => Set<NewsArticle>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<NewsTag> NewsTags => Set<NewsTag>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Category>(e => { e.ToTable("Category"); e.HasKey(x => x.CategoryId); e.Property(x => x.CategoryId).HasColumnName("CategoryID"); e.Property(x => x.CategoryDescription).HasColumnName("CategoryDesciption"); e.Property(x => x.ParentCategoryId).HasColumnName("ParentCategoryID"); e.HasOne(x => x.ParentCategory).WithMany(x => x.InverseParentCategory).HasForeignKey(x => x.ParentCategoryId).OnDelete(DeleteBehavior.Restrict); });
        b.Entity<SystemAccount>(e => { e.ToTable("SystemAccount"); e.HasKey(x => x.AccountId); e.Property(x => x.AccountId).HasColumnName("AccountID").ValueGeneratedNever(); });
        b.Entity<NewsArticle>(e => { e.ToTable("NewsArticle"); e.HasKey(x => x.NewsArticleId); e.Property(x => x.NewsArticleId).HasColumnName("NewsArticleID"); e.Property(x => x.NewsTitle).IsRequired(false); e.Property(x => x.Headline).IsRequired(false); e.Property(x => x.NewsContent).IsRequired(false); e.Property(x => x.NewsSource).IsRequired(false); e.Property(x => x.CategoryId).HasColumnName("CategoryID"); e.Property(x => x.CreatedById).HasColumnName("CreatedByID"); e.Property(x => x.UpdatedById).HasColumnName("UpdatedByID"); e.HasOne(x => x.Category).WithMany(x => x.NewsArticles).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict); e.HasOne(x => x.CreatedBy).WithMany(x => x.CreatedNews).HasForeignKey(x => x.CreatedById).OnDelete(DeleteBehavior.Restrict); e.HasOne(x => x.UpdatedBy).WithMany(x => x.UpdatedNews).HasForeignKey(x => x.UpdatedById).OnDelete(DeleteBehavior.Restrict); });
        b.Entity<Tag>(e => { e.ToTable("Tag"); e.HasKey(x => x.TagId); e.Property(x => x.TagId).HasColumnName("TagID"); });
        b.Entity<NewsTag>(e => { e.ToTable("NewsTag"); e.HasKey(x => new { x.NewsArticleId, x.TagId }); e.Property(x => x.NewsArticleId).HasColumnName("NewsArticleID"); e.Property(x => x.TagId).HasColumnName("TagID"); e.HasOne(x => x.NewsArticle).WithMany(x => x.NewsTags).HasForeignKey(x => x.NewsArticleId); e.HasOne(x => x.Tag).WithMany(x => x.NewsTags).HasForeignKey(x => x.TagId); });
    }
}
