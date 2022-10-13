using System;
using System.Collections.Generic;
using MVC.Models;

namespace MVC.Service
{
    public class MemberServiceExtended : IMemberService
    {
        private static List<MemberModel> _member = new List<MemberModel>{
             new MemberModel()
            {
                FirstName = "Vinh",
                LastName = "Nguyen",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 3, 13),
                PhoneNumber = 0964083300,
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new MemberModel()
            {
                FirstName = "Duc",
                LastName = "Bui",
                Gender = "Female",
                DateOfBirth = new DateTime(2002, 9, 30),
                PhoneNumber = 0985483300,
                BirthPlace = "ha noi",
                IsGraduated = false
            },
            new MemberModel()
            {
                FirstName = "Ngai",
                LastName = "Nguyen",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 5, 30),
                PhoneNumber = 0875463300,
                BirthPlace = "Thai Binh",
                IsGraduated = true
            },
            new MemberModel()
            {
                FirstName = "Chuoi",
                LastName = "Le",
                Gender = "Female",
                DateOfBirth = new DateTime(2001, 4, 24),
                PhoneNumber = 0185683001,
                BirthPlace = "Quang Ngai",
                IsGraduated = true
            },
            new MemberModel()
            {
                FirstName = "Than",
                LastName = "Dang",
                Gender = "Female",
                DateOfBirth = new DateTime(2000, 10, 10),
                PhoneNumber = 0285483780,
                BirthPlace = "Thai Nguyen",
                IsGraduated = true
            }
        };

        List<MemberModel> IMemberService.GetAll()
        {
            return _member;
        }

        MemberModel? IMemberService.Create(MemberModel model)
        {
            _member.Add(model);
            return model;
        }

        MemberModel? IMemberService.GetOne(int index)
        {
            throw new NotImplementedException();
        }

        MemberModel? IMemberService.Update(int index, MemberModel model)
        {
            if (index >= 0 && index < _member.Count)
            {
                _member[index] = model;
                return model;
            }
            return null;
        }

        MemberModel? IMemberService.Delete(int index)
        {
            if (index >= 0 && index < _member.Count)
            {
                var member = _member[index];
                _member.RemoveAt(index);
                return member;
            }
            return null;
        }
    }

}