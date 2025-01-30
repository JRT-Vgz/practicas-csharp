namespace Cf.Dotnet.EntityFramework.Parte3.Models;

/// <summary>
///     Representa un artículo en el catálogo.
/// </summary>
public class CatalogItem
{
    /// <summary>
    ///     Obtiene el identificador único del artículo del catálogo.
    /// </summary>
    /// <value>
    ///     El identificador del artículo.
    /// </value>
    public int Id { get; init; }

    /// <summary>
    ///     Obtiene el nombre del artículo del catálogo.
    /// </summary>
    /// <value>
    ///     El nombre del artículo. No puede ser nulo o vacío.
    /// </value>
    public required string Name { get; init; } // La directiva 'required' asegura que este campo no sea nulo.

    /// <summary>
    ///     Obtiene el precio del artículo del catálogo.
    /// </summary>
    /// <value>
    ///     El precio del artículo. Debe ser un valor positivo.
    /// </value>
    public required decimal Price { get; init; } // 'required' indica que el precio es un campo obligatorio.
}