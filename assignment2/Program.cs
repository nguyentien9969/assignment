using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> memList = new List<Member>();
            memList.Add(new Member("Tien", "Nguyen", "male", new DateTime(1999, 10, 5), 0827844271, "BacGiang", "True"));
            memList.Add(new Member("Hung", "Pham", "male", new DateTime(1999, 10, 5), 0804085622, "NinhBinh", "false"));
            memList.Add(new Member("Hieu", "Luu", "male", new DateTime(1998, 10, 5), 0804060801, "CaMau", "false"));
            memList.Add(new Member("My", "Trinh", "female", new DateTime(2006, 10, 5), 0824040681, "Hanoi", "false"));
            memList.Add(new Member("Trung", "Luu", "male", new DateTime(2005, 10, 5), 0804743821, "Hanoi", "false"));
            memList.Add(new Member("Ha", "Nguyen", "female", new DateTime(1998, 10, 5), 0834467801, "Hue", "false"));
            memList.Add(new Member("Meo", "Con", "uknown", new DateTime(2020, 10, 5), 020, "a", "false"));

            
            var anoymus = new Member();

            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine("Chọn List danh sách : ");

            int getList = System.Int32.Parse(Console.ReadLine());
            
            switch (getList)
            {
                case 1:
                    anoymus.GetMaleMember(memList);
                    break;

                case 2:
                    anoymus.GetOldestMember(memList);
                    break;

                case 3:
                    anoymus.GetFullnameList(memList);
                    break;

                case 4:
                    anoymus.GetAgeList(memList);
                    break;

                case 5:
                    anoymus.GetfirstBorn(memList);
                    break;
                    
                default:
                    Console.WriteLine("không có danh sách bạn muốn tìm");
                    break;
            }
        }
    }
}