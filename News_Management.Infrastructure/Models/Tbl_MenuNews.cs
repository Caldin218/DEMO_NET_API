using System;
using System.Collections.Generic;

namespace News_Management.Infrastructure.Models;
public partial class MenuNews
{
    public int MenusId { get; set; }

    public int NewsId { get; set; }

    public virtual Menu Menus { get; set; } = null!;

    public virtual News News { get; set; } = null!;
}
