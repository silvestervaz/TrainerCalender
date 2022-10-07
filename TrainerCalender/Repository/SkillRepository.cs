using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrainerCalender.Models;
using TrainerCalender.Models.Dto;

namespace TrainerCalender.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly TrainerCalenderDbContext _context;
        private IMapper _mapper;

        public SkillRepository(TrainerCalenderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SkillDto> CreateUpdateSkill(SkillDto skilldto)
        {
            Skill skill = _mapper.Map<SkillDto, Skill>(skilldto);
            if (skill.Id > 0)
            {
                _context.Skills.Update(skill);
            }
            else
            {
                _context.Skills.Add(skill);
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Skill, SkillDto>(skill);
        }

        public async Task<bool> DeleteSkill(int id)
        {
            try
            {
                Skill skill = await _context.Skills.FindAsync(id);
                if (skill == null)
                {
                    return false;
                }

                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<SkillDto> GetSkillById(int id)
        {
            Skill skill = await _context.Skills.Include(x=>x.Courses).Where(y=>y.Id== id).SingleOrDefaultAsync();
            return _mapper.Map<SkillDto>(skill);
        }

        public async Task<IEnumerable<SkillDto>> GetSkills()
        {
            List<Skill> SkillList = await _context.Skills.Include(x=>x.Courses).ToListAsync();
            return _mapper.Map<List<SkillDto>>(SkillList);
            //return await _context.Skills.ToListAsync();
        }
    }
}
