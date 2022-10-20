using Enitity_Framework.DTOs;
using Enitity_Framework.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Enitity_Framework.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    public readonly IStudentServices _studentServices;

     public StudentsController(IStudentServices studentServices)
    {
        _studentServices = studentServices;
    }

    [HttpPost]
    public AddStudentRespone Add([FromBody] AddStudentRequest request)
    {
        return _studentServices.Create(request);
    }

    [HttpGet("{id}")]
    public GetStudent GetById(int id)
    {
        return _studentServices.GetById(id);
    }

    [HttpPut]
    public UpdateStudentRespone Update(int id, [FromBody] UpdateStudentRequest updateRequest)
    {
        return _studentServices.Update(id, updateRequest);
    }

    [HttpDelete]
    public bool Delete(int id)
    {
        return _studentServices.Delete(id);
    }

    [HttpGet]
    public IEnumerable<GetStudent> GetAll()
    {
        return _studentServices.GetAll();
    }
}
