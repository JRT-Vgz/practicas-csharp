namespace Cf.Dotnet.EntityFramework.Parte3.Models;

/// <summary>
///     Representa una orden realizada por un cliente.
/// </summary>
public class Order
{
    /// <summary>
    ///     Obtiene o establece el identificador único de la orden.
    /// </summary>
    /// <value>
    ///     El identificador de la orden.
    /// </value>
    public int Id { get; set; }

    /// <summary>
    ///     Obtiene o establece el identificador del cliente asociado a la orden.
    /// </summary>
    /// <value>
    ///     El identificador del cliente. Es un campo obligatorio.
    /// </value>
    public required int CustomerId { get; set; } // 'required' indica que el CustomerId no puede ser nulo.

    /// <summary>
    ///     Obtiene o establece el identificador del artículo del catálogo asociado a la orden.
    /// </summary>
    /// <value>
    ///     El identificador del artículo del catálogo. Es un campo obligatorio.
    /// </value>
    public required int CatalogItemId { get; set; } // 'required' asegura que el CatalogItemId no sea nulo.

    /// <summary>
    ///     Obtiene o establece la cantidad del artículo solicitado en la orden.
    /// </summary>
    /// <value>
    ///     La cantidad del artículo. Es un campo obligatorio.
    /// </value>
    public required int Quantity { get; set; } // 'required' señala que la cantidad no puede ser nula.

    /// <summary>
    ///     Obtiene o establece la información del cliente asociado a la orden.
    /// </summary>
    /// <value>
    ///     El cliente asociado a la orden.
    /// </value>
    public Customer Customer { get; set; } = null!; // Propiedad de navegación para el cliente.

    /// <summary>
    ///     Obtiene o establece la información del artículo del catálogo asociado a la orden.
    /// </summary>
    /// <value>
    ///     El artículo del catálogo asociado a la orden.
    /// </value>
    public CatalogItem CatalogItem { get; set; } = null!; // Propiedad de navegación para el artículo del catálogo.
}