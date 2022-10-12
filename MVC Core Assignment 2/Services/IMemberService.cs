using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dataAccess;

namespace Services
{
    public interface IMemberService
    {
        List<ViewModel> GetListMember();

        void  AddMember(MemberCreateModel request);
    }
}