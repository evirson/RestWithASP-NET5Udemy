using EstudoRest.Data.VO;
using EstudoRest.Model;

namespace EstudoRest.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        
        User RefreshUserInfo(User user);

    }
}
