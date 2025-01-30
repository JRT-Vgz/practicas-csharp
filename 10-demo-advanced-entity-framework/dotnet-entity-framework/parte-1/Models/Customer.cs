namespace Cf.Dotnet.EntityFramework.Parte1.Models;

/// <summary>
///     Representa un cliente en el contexto del negocio.
/// </summary>
public class Customer
{
    /// <summary>
    ///     Obtiene o establece el identificador único del cliente.
    /// </summary>
    /// <value>
    ///     El identificador del cliente.
    /// </value>
    public int Id { get; set; }

    /// <summary>
    ///     Obtiene o establece el nombre del cliente.
    /// </summary>
    /// <value>
    ///     El nombre del cliente. Es un campo obligatorio y no puede ser nulo.
    /// </value>
    public required string Name { get; set; } // 'required' asegura que el nombre no sea nulo.

    /// <summary>
    ///     Obtiene o establece la colección de órdenes asociadas al cliente.
    /// </summary>
    /// <value>
    ///     Las órdenes del cliente. Esta colección puede estar vacía, pero no nula.
    /// </value>
    public ICollection<Order> Orders { get; set; } = null!;
}