using System;
using System.Collections.Generic;

namespace OnlineSchool.Models;

public partial class Teacher
{
    public int id { get; set; }

    public string fio { get; set; } = "ИМЯ";

    public string experience { get; set; } = "ИМЯ";

    public string speciality { get; set; } = "ИМЯ";
}
