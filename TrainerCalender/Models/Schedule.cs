using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrainerCalender.Models;

public partial class Schedule
{
    public int Id { get; set; }

    public string SessionName { get; set; } 

    public DateTime Date { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Location { get; set; } 

    public string Mode { get; set; } 

    public int TrainerCourseId { get; set; }

    [JsonIgnore]
    public virtual TrainerCourse TrainerCourse { get; set; }
    
    
}
