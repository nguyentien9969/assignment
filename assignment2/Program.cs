using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;

namespace Assignment2
{
    public class program
    {
        static void GetMaleMember(List<Member> memList)
        {

            var data = from item in memList
                       where item.Gender == "male"
                       select item;

            foreach (var item in data)
            {
                Console.WriteLine(item.Info);
            }
        }

        static void GetOldestMember(List<Member> memList)
        {
            Console.WriteLine("2. Return the oldest one based on “Age”");

            var data = from item in memList
                       orderby item.Age
                       select item;

            foreach (var item in data)
            {
                Console.WriteLine(item.Info);
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

            var option = System.Int32.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    var data = from item in memList
                               where item.DateOfBirth.Year == 2000
                               select item;

                    foreach (var item in data)
                    {
                        Console.WriteLine(item.Info);
                    }
                    break;
                case 2:
                    var data2 = from item in memList
                                where item.DateOfBirth.Year < 2000
                                select item;

                    foreach (var item in data2)
                    {
                        Console.WriteLine(item.Info);
                    }
                    break;

                case 3:
                    var data3 = from item in memList
                                where item.DateOfBirth.Year > 2000
                                select item;

                    foreach (var item in data3)
                    {
                        Console.WriteLine(item.Info);
                    }
                    break;
            }
        }

        static void GetFirstBorn(List<Member> memList)
        {
            Console.WriteLine("5. Return the first person who was born in Ha Noi.");

            var data = from item in memList
                       where item.BirthPlace.Contains("Hanoi")
                       select item;

            foreach (var item in data)
            {
                Console.WriteLine(item.Info);
                break;
            }
        }

        static void Main(string[] args)
        {
            List<Member> memList = new List<Member>();
            memList.Add(new Member("Tien", "Nguyen", "male", new DateTime(2000, 10, 5), 0827844271, "BacGiang", "True"));
            memList.Add(new Member("Hung", "Pham", "male", new DateTime(1999, 10, 5), 0804085622, "NinhBinh", "false"));
            memList.Add(new Member("Hieu", "Luu", "male", new DateTime(1998, 10, 5), 0804060801, "CaMau", "false"));
            memList.Add(new Member("My", "Trinh", "female", new DateTime(2006, 10, 5), 0824040681, "Hanoi", "false"));
            memList.Add(new Member("Trung", "Luu", "male", new DateTime(2000, 10, 5), 0804743821, "Hanoi", "false"));
            memList.Add(new Member("Ha", "Nguyen", "female", new DateTime(1998, 10, 5), 0834467801, "Hue", "false"));
            memList.Add(new Member("Meo", "Con", "uknown", new DateTime(2020, 10, 5), 020, "a", "false"));

            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.WriteLine("Chọn List danh sách : ");

            var getList = System.Int32.Parse(Console.ReadLine());

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
                    GetFirstBorn(memList);
                    break;

                default:
                    Console.WriteLine("không có danh sách bạn muốn tìm");
                    break;
            }
        }
    }
}