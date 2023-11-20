using System;
using System.Collections.Generic;

namespace OnlineSchool.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Price { get; set; } = null!;

    public string Duration { get; set; } = null!;
}
