using TrainerCalender.Models.Dto;

namespace TrainerCalender.Repository
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseDto>> GetCourses();
        Task<CourseDto> GetCourseById(int id);
        Task<CourseDto> CreateUpdateCourse(CourseDto coursedto);

        Task<bool> DeleteCourse(int id);
    }
}
