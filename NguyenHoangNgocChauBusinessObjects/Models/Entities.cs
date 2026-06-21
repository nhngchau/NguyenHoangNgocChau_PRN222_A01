using System.ComponentModel.DataAnnotations;

namespace NguyenHoangNgocChauBusinessObjects.Models;

public class Category
{
    public short CategoryId { get; set; }
    [Required, StringLength(100)] public string CategoryName { get; set; } = string.Empty;
    [StringLength(250)] public string? CategoryDescription { get; set; }
    public short? ParentCategoryId { get; set; }
    public bool? IsActive { get; set; } = true;
    public Category? ParentCategory { get; set; }
    public ICollection<Category> InverseParentCategory { get; set; } = new List<Category>();
    public ICollection<NewsArticle> NewsArticles { get; set; } = new List<NewsArticle>();
}

public class SystemAccount
{
    public short AccountId { get; set; }
    [Required, StringLength(100)] public string AccountName { get; set; } = string.Empty;
    [Required, EmailAddress, StringLength(70)] public string AccountEmail { get; set; } = string.Empty;
    [Range(1, 2)] public int? AccountRole { get; set; }
    [StringLength(70)] public string AccountPassword { get; set; } = string.Empty;
    public ICollection<NewsArticle> CreatedNews { get; set; } = new List<NewsArticle>();
    public ICollection<NewsArticle> UpdatedNews { get; set; } = new List<NewsArticle>();
}

public class NewsArticle
{
    [Required, StringLength(20)] public string NewsArticleId { get; set; } = string.Empty;
    [Required, StringLength(400)] public string NewsTitle { get; set; } = string.Empty;
    [Required, StringLength(150)] public string Headline { get; set; } = string.Empty;
    public DateTime? CreatedDate { get; set; }
    [Required, StringLength(4000)] public string NewsContent { get; set; } = string.Empty;
    [Required, StringLength(400)] public string NewsSource { get; set; } = string.Empty;
    public short? CategoryId { get; set; }
    public bool? NewsStatus { get; set; } = true;
    public short? CreatedById { get; set; }
    public short? UpdatedById { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public Category? Category { get; set; }
    public SystemAccount? CreatedBy { get; set; }
    public SystemAccount? UpdatedBy { get; set; }
    public ICollection<NewsTag> NewsTags { get; set; } = new List<NewsTag>();
}

public class Tag
{
    public int TagId { get; set; }
    [Required, StringLength(50)] public string TagName { get; set; } = string.Empty;
    [StringLength(400)] public string? Note { get; set; }
    public ICollection<NewsTag> NewsTags { get; set; } = new List<NewsTag>();
}

public class NewsTag
{
    public string NewsArticleId { get; set; } = string.Empty;
    public int TagId { get; set; }
    public NewsArticle? NewsArticle { get; set; }
    public Tag? Tag { get; set; }
}
