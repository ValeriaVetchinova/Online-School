using System;
using System.Collections.Generic;

namespace OnlineSchool.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public string Experience { get; set; } = null!;

    public string Speciality { get; set; } = null!;
}
