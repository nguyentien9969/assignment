using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataAccess
{
    public class StaticMemberDataAccess : IMemberDataAccess
    {
        private static List<Member> memberList = new List<Member>()
           {
                new Member("Tien", "Nguyen", "male", new DateTime(2000, 10, 5), 0827844271, "BacGiang", "True",0),
                new Member("Hung", "Pham", "male", new DateTime(1999, 10, 5), 0804085622, "NinhBinh", "false",1),
                new Member("Hieu", "Luu", "male", new DateTime(1998, 10, 5), 0804060801, "CaMau", "false",2),
                new Member("Dinh", "Trinh", "female", new DateTime(2006, 10, 5), 0824040681, "Hanoi", "false",3),
                new Member("Dam", "Hang", "female", new DateTime(2006, 10, 5), 0824040681, "Hanoi", "false",4),
                new Member("My", "Nguyen", "female", new DateTime(2006, 10, 5), 0824040681, "Hanoi", "false",5),
                new Member("Vi", "Trinh", "female", new DateTime(2006, 10, 5), 0824040681, "Hanoi", "false",6),
                new Member("Minh", "Tuan", "Male", new DateTime(2006, 10, 5), 0824040681, "Hanoi", "false",7),
                new Member("Huong", "Lan", "female", new DateTime(2006, 10, 5), 0824040681, "Hanoi", "false",8),


           };

        public StaticMemberDataAccess()
        {
        }
        public List<Member> GetListMember()
        {
            return memberList;
        }

        public void AddMember(Member member)
        {
            memberList.Add(member);
        }
    }
}