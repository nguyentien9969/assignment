using System;
using System.Collections.Generic;


namespace Assignment1
{
    class Member 
    {
        private string _FirstName;
        private string _LastName;
        private string _Gender;
        private DateTime _DateOfBirth;
        private int _PhoneNumber;
        private string _BirthPlace;
        private int _Age;
        private bool _IsGraduated;

        public Member()
        {
        }

        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public string Gender { get => _Gender; set => _Gender = value; }
        public int PhoneNumber { get => _PhoneNumber; set => _PhoneNumber = value; }
        public DateTime DateOfBirth { get => _DateOfBirth; set => _DateOfBirth = value; }
        public string BirthPlace { get => _BirthPlace; set => _BirthPlace = value; }
        public int Age { get => _Age; set => _Age = value; }
        public bool IsGraduated { get => _IsGraduated; set => _IsGraduated = value; }

        public string FullName { 
                  get { return $"Firstname is: {FirstName}, Lastname is {LastName}"; } 
              }

        public override string ToString()
        {
            return  " ( " +FirstName +  " , " + LastName + " ,  " + Age  + " , " + Gender + " , " + DateOfBirth + " , " + BirthPlace + " , " +PhoneNumber + " , " + Age + " , " + IsGraduated + " )";
        }
        public Member(string firstName, string lastName, string gender, DateTime dateOfBirth, int phoneNumber, string birthPlace, int age, bool isGraduated)
        {
            FirstName = firstName ;
            LastName = lastName ;
            Gender = gender ;
            DateOfBirth = dateOfBirth ;
            PhoneNumber = phoneNumber ;
            BirthPlace = birthPlace ;
            Age = age ;
            IsGraduated = isGraduated ;
        }   
        // public string GetGender (string Gender){
        //     switch (Gender.Contains) 
        //     {
        //         case "m":
        //         return "Male";
        //         case 1:
        //         return "Female";
        //         case 2:
        //         return "Other";
        //         case 3:
        //         return "Unknown";
        //         default:
        //         return "wrong input type Gender";
        //     }
        // }
    }

    internal class Program 
    {
        static void Main(string[] args)
        {
            List<Member> MemList = new List<Member>();
            MemList.Add(new Member("Tien", "Nguyen", "male", new DateTime(2001, 10, 5), 0827844271, "BacGiang", 21, false));
            MemList.Add(new Member("Hung", "Pham", "male", new DateTime(1999, 10, 5), 0804085622, "NinhBinh", 23, false));
            MemList.Add(new Member("Hieu", "Luu", "male", new DateTime(1998, 10, 5), 0804060801, "CaMau", 23, false));
            MemList.Add(new Member("My", "Trinh", "female", new DateTime(2000, 10, 5), 0824040681, "Hanoi", 22, false));
            MemList.Add(new Member("Trung", "Luu", "male", new DateTime(2000, 10, 5), 0804743821, "Hanoi", 22, false));
            MemList.Add(new Member("Ha", "Nguyen", "female", new DateTime(1998, 10, 5), 0834467801, "Hue", 23, false));
            MemList.Add(new Member("Meo", "Con", "uknown", new DateTime(2020, 10, 5), 020, "a", 2, false));
            

            // 1. Return a list of members who isMale
            Console.WriteLine("1. Return a list of members who is Male");

            foreach (Member mem in MemList)
            {

                if(mem.Gender == "male")
                {
                    Console.WriteLine(mem.ToString());
                }   
            }
            Console.WriteLine(("------------------------------------------------------------------------------------------------------------------------------------------------"));

            //2. Return the oldest one based on “Age”
            //chưa làm được 2 ý (firstperson and datetime)
            Console.WriteLine("2. Return the oldest one based on “Age”");
           
            var oldestMemberAge = new Member() ;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    if (MemList[i].Age > MemList[j].Age)
                    {
                       oldestMemberAge = MemList[i] ;
                    }
                }
            }          
            Console.WriteLine(oldestMemberAge.ToString());
                   
            Console.WriteLine(("-----------------------------------------------------------------------------------------------------------------------------------------------"));

           // 3. Return a new listthat contains Full Name only ( Full Name =Last Name + FirstName)
           
            Console.WriteLine("3. Return a new list that contains Full Name only ( Full Name =Last Name + FirstName)");
            
            foreach(Member mem in MemList)
            {
                Console.WriteLine(mem.LastName + " " + mem.FirstName);
            }

            
            Console.WriteLine(("----------------------------------------------------------------------------------------------------------------------------------------"));

            //4. Return 3 lists 

            Console.WriteLine("4. Return 3 lists:");
            foreach (Member mem in MemList)
            {
                switch (mem.DateOfBirth.Year)
                {
                    case 2000:
                    Console.WriteLine(mem.ToString() + " was born in 2000 .");
                    break;

                    case >2000:
                    Console.WriteLine(mem.ToString() + " was born after 2000 .");
                    break;

                    case < 2000:
                    Console.WriteLine(mem.ToString() + " was born before 2000 .");
                    break;
                }
            }

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");

            //5. Return the first person who was born in Ha Noi.
            Console.WriteLine("5. Return the first person who was born in Ha Noi.");

            var firstHanoi = 0;

            while ( MemList[firstHanoi].BirthPlace != "Hanoi")
            {
                firstHanoi++;
            } 
            Console.WriteLine(MemList[firstHanoi].ToString());
        }
    }
}