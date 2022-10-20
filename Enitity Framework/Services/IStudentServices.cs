using Enitity_Framework.DTOs;
namespace Enitity_Framework.Services.Interfaces;

    public interface IStudentServices 
    {
    AddStudentRespone Create(AddStudentRequest addRequest);
    IEnumerable<GetStudent> GetAll();
    GetStudent GetById(int id);
    UpdateStudentRespone Update(int id, UpdateStudentRequest updateRequest);
    bool Delete(int id);
    }
