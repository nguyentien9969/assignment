using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataAccess
{
    public interface IMemberDataAccess
    {
    
        List<Member> GetListMember();

        void AddMember(Member member);
    
    }
}