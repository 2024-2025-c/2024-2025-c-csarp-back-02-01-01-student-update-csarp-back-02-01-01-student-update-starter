using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Repos;
using Microsoft.AspNetCore.Mvc;
using Kreata.Backend.Datas.Responses;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private ITeacherRepo _teacherRepo;

    public TeacherController(ITeacherRepo teacherRepo)
    {
        _teacherRepo = teacherRepo;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBy(Guid id)
    {
        Teacher? entity = new();
        if (_teacherRepo is not null)
        {
            entity = await _teacherRepo.GetBy(id);
            if (entity != null)
                return Ok(entity);
        }
        return BadRequest("Az adatok elérhetetlenek!");
    }

    [HttpGet]
    public async Task<IActionResult> SelectAllRecordToListAsync()
    {
        List<Teacher>? users = new();

        if (_teacherRepo != null)
        {
            users = await _teacherRepo.GetAll();
            return Ok(users);
        }
        return BadRequest("Az adatok elérhetetlenek!");
    }
    [HttpPut()]
    public async Task<ActionResult> UpdateTeacherAsync(Teacher entity)
    {
        ControllerResponse response = new();
        if (_teacherRepo is not null)
        {
            response = await _teacherRepo.UpdateTeacherAsync(entity);
            if (response.HasError)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }
        response.ClearAndAddError("Az adatok frissítés nem lehetséges!");
        return BadRequest(response);
    }
}