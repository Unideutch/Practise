using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Domain;
using Sample.Dto;

namespace WebApi.Controllers;

// TODO: добавить методы получения по Id, изменения по Id, удаления по Id
[Route( "api/[controller]" )]
[ApiController]
public class TodosController : ControllerBase
{
    private static readonly List<Todo> _todos = new();

    /// <summary>
    /// Создаёт Todo
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Create( [FromBody] CreateTodoDto createDto )
    {
        int id = _todos.Count() + 1;
        Todo todo = new( id, createDto.Title );

        _todos.Add( todo );

        return Ok();
    }

    /// <summary>
    /// Возвращает все Todo
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get()
    {
        // Анонимный тип
        var result = _todos.Select( t => new { t.Id, t.Title, plannedDay = t.PlannedDay.ToString( "yyyy-MM-dd hh:mm:ss" ) } )
                           .ToList();

        return Ok( result );
    }

    /// <summary>
    /// Возвращает Todo по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet( "{id}" )]
    public IActionResult GetById( int id )
    {
        var result = _todos.FirstOrDefault( t => t.Id == id );
        if (result == null )
        {
            return NotFound();
        }

        return Ok(new {result.Id, result.Title, result.PlannedDay});
    }

    /// <summary>
    /// Change Todo by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut( "{id}" )]
    public IActionResult ChangeById( int id, [FromBody] ChangeTodoDto createDto ) 
    {
        var result = _todos.FirstOrDefault(t => t.Id == id );

        if ( result == null )
        {
            return NotFound();
        }

        if ( createDto.Title != null)
        {
            result.Title = createDto.Title;
        }

        return Ok( );
    }

    /// <summary>
    /// Удаляет Todo по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete( "{id}" )]
    public IActionResult DeleteById( int id )
    {
        var result = _todos.FirstOrDefault( t => t.Id == id );
        _todos.Remove( result );

        return Ok();
    }
}