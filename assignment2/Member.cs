using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2
{
     public class Member
    {

        private string _FirstName;
        private string _LastName;
        private string _Gender;
        private DateTime _DateOfBirth;
        private int _PhoneNumber;
        private string _BirthPlace;
        private uint _Age;
        private string _IsGraduated;

        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public string Gender { get => _Gender; set => _Gender = value; }
        public int PhoneNumber { get => _PhoneNumber; set => _PhoneNumber = value; }
        public DateTime DateOfBirth { get => _DateOfBirth; set => _DateOfBirth = value; }
        public string BirthPlace { get => _BirthPlace; set => _BirthPlace = value; }
        public uint Age { get => _Age; set => _Age = value; }
        public string IsGraduated { get => _IsGraduated; set => _IsGraduated = value; }
       
        public Member()
        {
        }

        public Member(string firstName, string lastName, string gender, DateTime dateOfBirth, int phoneNumber, string birthPlace, string isGraduated)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            BirthPlace = birthPlace;
            IsGraduated = this.GetIsGraduated(isGraduated);
            Age = this.GetAge();
        }

        public string Info { get => 
                             " ( " + FirstName + " , " + LastName + " ,  " + Age + " , " + Gender + " , " + DateOfBirth +
                             " , " + BirthPlace + " , " + PhoneNumber + " , " + Age + " , " + IsGraduated + " )";
                            }
        public string FullName {get => 
                                FirstName + " " + LastName ;
                                }
        
         public uint GetAge()
        {
            uint today = (uint)DateTime.Today.Year;
            return today - (uint)DateOfBirth.Year;
        }

        public string GetIsGraduated(string isGraduated) 
        {
            if (string.Equals(isGraduated,"true",StringComparison.OrdinalIgnoreCase))
            {
                return "ĐÃ TỐT NGHIỆP";
            }
            else
            {
                return "CHƯA TỐT NGHIỆP";
            }
        }

        public void GetMaleMember(List<Member> memList)
        {

            Console.WriteLine("1. Return a list of members who is Male");
                
                var ketqua = from mem1 in memList
                            where mem1.Gender.Contains("male")
                            select mem1;

                foreach (var mem1 in ketqua)
                {
                    Console.WriteLine(mem1.FullName);
                }
        }
       
       public void GetOldestMember (List<Member> memList)
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

       public void GetFullnameList(List<Member> memList)
       {
            Console.WriteLine("3. Return a new list that contains Full Name only ( Full Name =Last Name + FirstName)");

            foreach (Member mem in memList)
            {
                Console.WriteLine(mem.FullName);
            }
       }

       public void GetAgeList(List<Member> memList)
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
                            if(mem.DateOfBirth.Year == 2000)
                            {
                                Console.WriteLine(mem.Info + " was born in 2000 .");
                            }
                        }
                    break;
                    case 2:
                    
                       foreach (var mem in memList)
                        {
                            if(mem.DateOfBirth.Year > 2000)
                            {
                                Console.WriteLine(mem.Info + " was born before 2000 .");
                            }
                        }
                        break;
                  
                    case 3:
                       foreach (var mem in memList)
                        {
                            if(mem.DateOfBirth.Year < 2000)
                            {
                                Console.WriteLine(mem.Info + " was born after 2000 .");
                            }
                        }
                    break;  
                }
       }

       public void GetfirstBorn(List<Member> memList)
       {
            Console.WriteLine("5. Return the first person who was born in Ha Noi.");

            var firstHanoi = 0;

            while (memList[firstHanoi].BirthPlace != "Hanoi")
            {
                firstHanoi++;
            }
            Console.WriteLine(memList[firstHanoi].Info);
       }
            

        //  public enum Genders
        //  {
        //     male,
        //     female,
        //     unknown
        // }

        // Genders gender = Genders.male;

        // public string GetGender (Genders gender){
        //     switch (gender) 
        //     {
        //         case Genders.male:
        //         return "Male";
        //         case Genders.female:
        //         return "Female";
        //         case Genders.unknown:
        //         return "Other";
        //         default:
        //         return "wrong input type Gender";
        //     }
        // }
    }
}