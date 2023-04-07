using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SimpleAPI.Domain;
using SimpleAPI.Dto.Products;

namespace SimpleAPI.Controllers;

[Route( "api/[controller]" )]
[ApiController]
public class ProductsController : Controller
{
    public static readonly List<Product> Products = new List<Product>();

    /// <summary>
    /// Создаёт Product
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Create( [FromBody] CreateProductDto createDto )
    {
        int id = Products.MaxBy( product => product.Id )?.Id ?? 0 + 1; ;
        Product product = new()
        {
            Id = id,
            Name = createDto.Name,
            Cost = createDto.Cost,
            Supplier = createDto.Supplier
        };

        Products.Add( product );

        return Ok();
    }

    /// <summary>
    /// Возвращает всех Product
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get()
    {
        // Анонимный тип
        var result = Products.Select( t => new { t.Id, t.Name, t.Cost, t.Supplier } )
                           .ToList();

        return Ok( result );
    }

    /// <summary>
    /// Возвращает Product по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet( "{id}" )]
    public IActionResult GetById( int id )
    {
        var product = Products.FirstOrDefault( t => t.Id == id );

        if ( product == null )
        {
            return NotFound();
        }

        return Ok( new { product.Id, product.Name, product.Cost, product.Supplier } );
    }

    /// <summary>
    /// Изменяет Product по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut( "{id}" )]
    public IActionResult ChangeById( int id, [FromBody] ChangeProductDto createDto )
    {
        var product = Products.FirstOrDefault( t => t.Id == id );

        if ( product == null )
        {
            return NotFound();
        }

        if ( createDto.Name != null )
        {
            product.Name = createDto.Name;
        }

        if ( createDto.Cost != 0 )
        {
            product.Cost = createDto.Cost;
        }

        return Ok();
    }

    /// <summary>
    /// Удаляет Product по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete( "{id}" )]
    public IActionResult DeleteById( int id )
    {
        var result = Products.FirstOrDefault( t => t.Id == id );

        if ( result == null )
        {
            return NotFound();
        }

        Products.Remove( result );

        return Ok();
    }
}
