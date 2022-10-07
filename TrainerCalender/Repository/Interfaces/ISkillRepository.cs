using TrainerCalender.Models;
using TrainerCalender.Models.Dto;

namespace TrainerCalender.Repository
{
    public interface ISkillRepository
    {
        Task<IEnumerable<SkillDto>> GetSkills();
        Task<SkillDto> CreateUpdateSkill(SkillDto skilldto);
        //Task<SkillDto> UpdateSkill(SkillDto skill);
        Task<SkillDto> GetSkillById(int id);
        Task<bool> DeleteSkill(int id);

    }
}
