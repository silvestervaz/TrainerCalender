using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrainerCalender.Models;
using TrainerCalender.Models.Dto;

namespace TrainerCalender.Repository
{
    public class TrainerCourseRepository : ITrainerCourseRepository
    {
        private readonly TrainerCalenderDbContext _context;
        private IMapper _mapper;

        public TrainerCourseRepository(TrainerCalenderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TrainerCourseDto> CreateUpdateTrainerCourse(TrainerCourseDto trainerCourseDto)
        {
            TrainerCourse trainerCourse = _mapper.Map<TrainerCourseDto, TrainerCourse>(trainerCourseDto);
            if (trainerCourse.Id > 0)
            {
                User user = await _context.Users.Where(x => x.FirstName == trainerCourseDto.TrainerName).FirstOrDefaultAsync();
                Course course = await _context.Courses.Where(x => x.Name == trainerCourseDto.CourseName).FirstOrDefaultAsync();

                if (course == null || user == null)
                    return null;

                trainerCourse.CourseId = course.Id;
                trainerCourse.UserId = user.Id;
                _context.TrainerCourses.Update(trainerCourse);
            }
            else
            {
                User user = await _context.Users.Where(x => x.FirstName == trainerCourseDto.TrainerName).FirstOrDefaultAsync();
                Course course = await _context.Courses.Where(x => x.Name == trainerCourseDto.CourseName).FirstOrDefaultAsync();
               
                if (course == null || user == null)
                    return null;

                trainerCourse.CourseId=course.Id;
                trainerCourse.UserId=user.Id;

                _context.TrainerCourses.Add(trainerCourse);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<TrainerCourse, TrainerCourseDto>(trainerCourse);
        }

        public async Task<bool> DeleteTrainerCourse(int id)
        {
            try
            {
                TrainerCourse trainerCourse = await _context.TrainerCourses.FindAsync(id);
                if (trainerCourse == null)
                {
                    return false;
                }

                _context.TrainerCourses.Remove(trainerCourse);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<TrainerCourseDto> GetTrainerCourseById(int id)
        {
            TrainerCourse trainerCourse = await _context.TrainerCourses.FindAsync(id);
            return _mapper.Map<TrainerCourseDto>(trainerCourse);
        }

        
        public async Task<IEnumerable<TrainerCourseDto>> GetTrainerCourses()
        {
            
            List<TrainerCourse> TrainerCourseList = await _context.TrainerCourses.Include(x=>x.Course).Include(y=>y.User).ToListAsync();
   
            
            return _mapper.Map<List<TrainerCourseDto>>(TrainerCourseList);
        }
    }
}
