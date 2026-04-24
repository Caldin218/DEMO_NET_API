using System;
using System.Collections.Generic;

namespace News_Management.Infrastructure.Models;
public partial class Menu
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public int? DisplayOrder { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }




}
