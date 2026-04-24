using System;
using System.Collections.Generic;

namespace News_Management.Infrastructure.Models;
public partial class News
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Images { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
