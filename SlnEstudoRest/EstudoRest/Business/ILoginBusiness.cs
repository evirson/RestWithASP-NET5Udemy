using EstudoRest.Data.VO;

namespace EstudoRest.Business
{
    public interface ILoginBusiness
    {
        TokenVo ValidateCredentials(UserVO user);
                
    }
}
