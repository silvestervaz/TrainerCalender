using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrainerCalender.Models;

public partial class TrainerCourse
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CourseId { get; set; }
    
   
    public virtual Course Course { get; set; }
    
    public  virtual User User { get; set; }

    
    public virtual ICollection<Schedule> Schedules { get; } = new List<Schedule>(); 

   
    
   
}
