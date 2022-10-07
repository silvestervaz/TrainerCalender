namespace TrainerCalender.Models.Dto
{
    public class ScheduleDto
    {

        public string SessionName { get; set; }

        public string CourseName { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Location { get; set; }

        public string Mode { get; set; } 

        
    }
}
