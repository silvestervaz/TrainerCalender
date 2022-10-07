using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrainerCalender.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } 
   
    public string LastName { get; set; }
    
    public string Emailid { get; set; }
   
    public string Password { get; set; }
   
    public byte? IsAdmin { get; set; }
    [JsonIgnore]
    public virtual ICollection<TrainerCourse> TrainerCourses { get; } = new List<TrainerCourse>();
}
