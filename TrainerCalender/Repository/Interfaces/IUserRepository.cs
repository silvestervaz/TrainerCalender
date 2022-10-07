using TrainerCalender.Models.Dto;

namespace TrainerCalender.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> CreateUpdateUser(UserDto userdto);
        //Task<SkillDto> UpdateSkill(SkillDto skill);
        Task<UserDto> GetUserById(int id);
        Task<bool> DeleteUser(int id);
    }
}
