using MVC.Models;

namespace MVC.Service
{
    public interface IMemberService
    {
        List<MemberModel> GetAll();
        MemberModel? Create(MemberModel model);
        MemberModel? GetOne(int index);
        MemberModel? Update(int index, MemberModel model);
        MemberModel? Delete(int index);
    }
}