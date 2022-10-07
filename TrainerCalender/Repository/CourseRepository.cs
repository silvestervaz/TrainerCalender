using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrainerCalender.Models;
using TrainerCalender.Models.Dto;

namespace TrainerCalender.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly TrainerCalenderDbContext _context;
        private IMapper _mapper;

        public CourseRepository(TrainerCalenderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CourseDto> CreateUpdateCourse(CourseDto coursedto)
        {
            Course course = _mapper.Map<CourseDto, Course>(coursedto);
            if (course.Id > 0)
            {
                var skill = await _context.Skills.Where(x => x.Name.Equals(coursedto.SkillName)).FirstOrDefaultAsync();
                
                if (skill == null)
                    return null;


                course.SkillId = skill.Id;
                _context.Courses.Update(course);
            }
            else
            {
                var skill = await _context.Skills.Where(x => x.Name.Equals(coursedto.SkillName)).FirstOrDefaultAsync();
                if (skill == null)
                    return null;

               
                course.SkillId=skill.Id;
                _context.Courses.Add(course);
                
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Course, CourseDto>(course);
        }

        public  async Task<bool> DeleteCourse(int id)
        {
            try
            {
                Course course = await _context.Courses.FindAsync(id);
                if (course == null)
                {
                    return false;
                }

                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<CourseDto> GetCourseById(int id)
        {
            Course course = await _context.Courses.Include(x=>x.Skill).Where(x=>x.Id == id).SingleOrDefaultAsync();
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<IEnumerable<CourseDto>> GetCourses()
        {
            List<Course> CourseList = await _context.Courses.Include(x=>x.Skill).ToListAsync();
            return _mapper.Map<List<CourseDto>>(CourseList);
        }
    }
}
