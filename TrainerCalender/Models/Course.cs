using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrainerCalender.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } 
    public  virtual Skill Skill { get; set; }
    public virtual int SkillId { get; set; }

    //public List<Skill> Skills { get; set; }
    [JsonIgnore]
    public virtual ICollection<TrainerCourse> TrainerCourses { get; } = new List<TrainerCourse>();
}
