using TrainerCalender.Models.Dto;

namespace TrainerCalender.Repository
{
    public interface ITrainerCourseRepository
    {
        Task<IEnumerable<TrainerCourseDto>> GetTrainerCourses();
        Task<TrainerCourseDto> GetTrainerCourseById(int id);
        Task<TrainerCourseDto> CreateUpdateTrainerCourse(TrainerCourseDto trainerCourseDto);
        Task<bool> DeleteTrainerCourse(int id);
    }
}
