using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Domain;
using SimpleAPI.Dto.Suppliers;

namespace SimpleAPI.Controllers;

[Route( "api/[controller]" )]
[ApiController]
public class SuppliersController : Controller
{
    public static readonly List<Supplier> Suppliers = new List<Supplier>();

    /// <summary>
    /// Создаёт Todo
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Create( [FromBody] CreateSupplierDto createDto )
    {
        int id = Suppliers.MaxBy(supplier => supplier.Id )?.Id ?? 0 + 1;
        Supplier supplier = new()
        {
            Id = id,
            Name = createDto.Name,
        };

        Suppliers.Add( supplier );

        return Ok();
    }

    /// <summary>
    /// Возвращает всех Supplier
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get()
    {
        // Анонимный тип
        var result = Suppliers.Select( t => new { t.Id, t.Name } )
                           .ToList();

        return Ok( result );
    }

    /// <summary>
    /// Возвращает Supplier по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet( "{id}" )]
    public IActionResult GetById( int id )
    {
        var supplier = Suppliers.FirstOrDefault( t => t.Id == id );

        if ( supplier == null )
        {
            return NotFound();
        }

        return Ok( new { supplier.Id, supplier.Name } );
    }

    /// <summary>
    /// Изменяет Supplier по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut( "{id}" )]
    public IActionResult ChangeById( int id, [FromBody] ChangeSupplierDto createDto )
    {
        var supplier = Suppliers.FirstOrDefault( t => t.Id == id );

        if ( supplier == null )
        {
            return NotFound();
        }

        supplier.Name = createDto.Name;

        return Ok();
    }

    /// <summary>
    /// Удаляет Supplier по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete( "{id}/delete" )]
    public IActionResult DeleteById( int id )
    {
        var result = Suppliers.FirstOrDefault( t => t.Id == id );

        if ( result == null )
        {
            return NotFound();
        }

        Suppliers.Remove( result );

        return Ok();
    }
}
