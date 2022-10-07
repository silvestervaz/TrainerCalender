using TrainerCalender.Models.Dto;

namespace TrainerCalender.Repository
{
    public interface IScheduleRepository
    {
       Task<IEnumerable<ScheduleDto>> GetSchedules();
         Task<ScheduleDto> GetScheduleById(int id);
        Task<ScheduleDto> CreateUpdateSchedule(ScheduleDto scheduleDto);
         Task<bool> DeleteSchedule(int id);
    }
}
