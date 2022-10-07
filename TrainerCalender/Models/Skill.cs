using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrainerCalender.Models;

public partial class Skill
{
    public int Id { get; set; }

    public string Name { get; set; } 

    [JsonIgnore]
    public  ICollection<Course> Courses { get; } = new List<Course>();

    //public virtual List<Course>? CourseList { get; set; }
}
