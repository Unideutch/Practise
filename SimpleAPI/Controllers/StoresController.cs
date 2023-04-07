using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Domain;
using SimpleAPI.Dto.Stores;

namespace SimpleAPI.Controllers;

[Route( "api/[controller]" )]
[ApiController]
public class StoresController : Controller
{
    public static readonly List<Store> Stores = new List<Store>();

    /// <summary>
    /// Создаёт Store
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Create( [FromBody] CreateStoreDto createDto )
    {
        int id = Stores.Count() + 1;
        Store store = new()
        {
            Id = id,
            Name = createDto.Name
        };

        Stores.Add( store );

        return Ok();
    }

    /// <summary>
    /// Возвращает всех Stores
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get()
    {
        // Анонимный тип
        var result = Stores.Select( t => new { t.Id, t.Name, t.Products } )
                           .ToList();

        return Ok( result );
    }

    /// <summary>
    /// Возвращает Store по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet( "{id}" )]
    public IActionResult GetById( int id )
    {
        var store = Stores.FirstOrDefault( t => t.Id == id );

        if ( store == null )
        {
            return NotFound();
        }

        return Ok( new { store.Id, store.Name, store.Products } );
    }

    /// <summary>
    /// Изменяет Store по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut( "{id}" )]
    public IActionResult ChangeById( int id, [FromBody] ChangeStoreDto createDto )
    {
        var store = Stores.FirstOrDefault( t => t.Id == id );

        if ( store == null )
        {
            return NotFound();
        }

        if ( createDto.Name != null )
        {
            store.Name = createDto.Name;
        }

        return Ok();
    }

    /// <summary>
    /// Удаляет Store по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete( "{id}" )]
    public IActionResult DeleteById( int id )
    {
        var result = Stores.FirstOrDefault( t => t.Id == id );

        if ( result == null )
        {
            return NotFound();
        }

        Stores.Remove( result );

        return Ok();
    }
}
