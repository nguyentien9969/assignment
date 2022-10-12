using dataAccess;

namespace Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberDataAccess _dataAccess;

        public MemberService(IMemberDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<ViewModel> GetListMember()
        {
            var applicationList = _dataAccess.GetListMember();
            var ViewModelList = new List<ViewModel>();
            foreach (var item in applicationList)
            {
                ViewModelList.Add(
                    new ViewModel()
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        FullName = item.FullName,
                        Address = item.BirthPlace,
                        Gender = item.Gender,
                        DateOfBirth = item.DateOfBirth,
                        BirthPlace = item.BirthPlace,
                        Id = item.Id ,
                    }
                );
            }
            return ViewModelList;
        }

        public void AddMember(MemberCreateModel model)
        {
            Member member = new Member()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthPlace = model.Address,
                Gender = model.Gender
            };
            _dataAccess.AddMember(member);
        }

        public void Update(MemberUpdateModel model,int index)
        {
            if (index >= 0 && index <_dataAccess.GetListMember().Count)
            {
                var member = _dataAccess.GetListMember()[index];
                member.FirstName = model.FirstName;
                member.LastName = model.LastName;
                member.PhoneNumber = model.PhoneNumber;
                member.BirthPlace = model.BirthPlace;
            }
        }

    }
}