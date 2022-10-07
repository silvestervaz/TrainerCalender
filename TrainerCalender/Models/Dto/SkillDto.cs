namespace TrainerCalender.Models.Dto
{
    public class SkillDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public  ICollection<Course>? Courses { get; set; }
        //public  List<Course>? CourseList { get; set; }
    }
}
