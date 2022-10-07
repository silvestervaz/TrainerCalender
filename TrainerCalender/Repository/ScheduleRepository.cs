using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrainerCalender.Models;
using TrainerCalender.Models.Dto;

namespace TrainerCalender.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly TrainerCalenderDbContext _context;
        private IMapper _mapper;
        public ScheduleRepository(TrainerCalenderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ScheduleDto> CreateUpdateSchedule(ScheduleDto scheduleDto)
        {
            Schedule schedule = _mapper.Map<ScheduleDto, Schedule>(scheduleDto);
            if (schedule.Id > 0)
            {
                _context.Schedules.Update(schedule);
            }
            else
            {
                var course = await _context.Courses.Where(x => x.Name == scheduleDto.CourseName).FirstOrDefaultAsync();
                var trainerCourse = _context.TrainerCourses.Where(x => x.CourseId == course.Id).FirstOrDefault();
                if (trainerCourse == null)
                    return null;

                schedule.TrainerCourseId=trainerCourse.Id;
                _context.Schedules.Add(schedule);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Schedule, ScheduleDto>(schedule);
        }

        public async Task<bool> DeleteSchedule(int id)
        {
            try
            {
                Schedule schedule = await _context.Schedules.FindAsync(id);
                if (schedule == null)
                {
                    return false;
                }

                _context.Schedules.Remove(schedule);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ScheduleDto> GetScheduleById(int id)
        {
            Schedule schedule = await _context.Schedules.Where(y => y.Id == id).SingleOrDefaultAsync();
            return _mapper.Map<ScheduleDto>(schedule);
        }

        public async Task<IEnumerable<ScheduleDto>> GetSchedules()
        {
            List<Schedule> ScheduleList = await _context.Schedules.Include(x=>x.TrainerCourse).ToListAsync();
            return _mapper.Map<List<ScheduleDto>>(ScheduleList);
        }
    }
}
