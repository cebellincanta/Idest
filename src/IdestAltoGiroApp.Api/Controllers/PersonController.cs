using IdestAlgotGiroApp.Application.DTO;
using IdestAlgotGiroApp.Application.Interface;
using IdestAlgotGiroApp.Application.Notification;
using Microsoft.AspNetCore.Mvc;

namespace IdestAlgotGiroApp.Api.Controllers;

public class PersonController : MainController
{
    private readonly IPersonService _service;

    public PersonController(IPersonService service, INotificationService notification) : base(notification)
    {
        _service = service;
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetAllAsync()
    {
            
        var result = await _service.GetAllAsync();
        return CustomResponse(result);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateAsync([FromBody] PersonDTO personal)
     {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        try
        {
            await _service.AddAsync(personal);
            return CustomResponse();
        }
        catch(Exception)
        {
            return CustomResponse();
        }
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] PersonDTO personal)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);
            
        var model = await _service.UpdateAsync(personal);

        return CustomResponse(model);
    }

    [HttpGet("getByDocument")]
    public async Task<IActionResult> GetByDocumentAsync(string Id)
    {
        var result = await _service.GetByIdAsync(Id);

        return CustomResponse(result);
    }

    [HttpGet("getByName")]
    public async Task<IActionResult> GetByNameAsync(string Id)
    {
        var result = await _service.GetByIdAsync(Id);

        return CustomResponse(result);
    }

        

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> DeletAsync(PersonDTO personal)
    {
        try
        {
            await _service.DeleteAsync(personal);

            return CustomResponse();
        }
        catch (Exception)
        {
            return CustomResponse();
        }

    }
}
