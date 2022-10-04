using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Program
    {
        static void GetMaleMember(List<Member> memList)
        {

            Console.WriteLine("1. Return a list of members who is Male");

            foreach (Member mem in memList)
            {
                if (string.Equals(mem.Gender , "male" , StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(mem.Info);
                }
            }
        }

        static void GetOldestMember(List<Member> memList)
        {

            uint oldestMemberAge = 0;

            Console.WriteLine("2. Return the oldest one based on “Age”");

            foreach (Member mem in memList)
            {
                if (mem.Age > oldestMemberAge)
                {
                    oldestMemberAge = mem.Age;
                }
            }

            foreach (Member mem in memList)
            {
                if (mem.Age == oldestMemberAge)
                {
                    Console.WriteLine(mem.Info);
                    break;
                }
            }
        }

        static void GetFullnameList(List<Member> memList)
        {
            Console.WriteLine("3. Return a new list that contains Full Name only ( Full Name =Last Name + FirstName)");

            foreach (Member mem in memList)
            {
                Console.WriteLine(mem.FullName);
            }
        }

        static void GetAgeList(List<Member> memList)
        {
            Console.WriteLine("4. Return 3 lists:");

            Console.WriteLine("Nhập list bạn muốn chọn : ");
            Console.WriteLine("List người sinh năm 2000 ");
            Console.WriteLine("List người sinh trước 2000");
            Console.WriteLine("List người sinh sau 2000 ");

            int option = System.Int32.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    foreach (var mem in memList)
                    {
                        if (mem.DateOfBirth.Year == 2000)
                        {
                            Console.WriteLine(mem.Info + " was born in 2000 .");
                        }
                    }
                    break;
                case 2:

                    foreach (var mem in memList)
                    {
                        if (mem.DateOfBirth.Year > 2000)
                        {
                            Console.WriteLine(mem.Info + " was born before 2000 .");
                        }
                    }
                    break;

                case 3:
                    foreach (var mem in memList)
                    {
                        if (mem.DateOfBirth.Year < 2000)
                        {
                            Console.WriteLine(mem.Info + " was born after 2000 .");
                        }
                    }
                    break;
            }
        }

        static void GetfirstBorn(List<Member> memList)
        {
            Console.WriteLine("5. Return the first person who was born in Ha Noi.");

            var firstHanoi = 0;

            while (!(string.Equals(memList[firstHanoi].BirthPlace, "Hanoi", StringComparison.OrdinalIgnoreCase)))
            {
                firstHanoi++;
            }
            Console.WriteLine(memList[firstHanoi].Info);
        }

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

            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            
            Console.WriteLine("Chọn List danh sách : ");

            int getList = System.Int32.Parse(Console.ReadLine());

            switch (getList)
            {
                case 1:
                    GetMaleMember(memList);
                    break;
                case 2:
                    GetOldestMember(memList);
                    break;
                case 3:
                    GetFullnameList(memList);
                    break;
                case 4:
                    GetAgeList(memList);
                    break;
                case 5:
                    GetfirstBorn(memList);
                    break;
                default:
                    Console.WriteLine("không có danh sách bạn muốn tìm");
                    break;
            }
        }
    }
}
