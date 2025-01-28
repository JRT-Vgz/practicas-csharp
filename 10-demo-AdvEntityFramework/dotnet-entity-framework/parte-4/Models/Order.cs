namespace Cf.Dotnet.EntityFramework.Parte4.Models;

/// <summary>
///     Representa una orden en el contexto del negocio.
///     Las entidades parciales permiten extender la funcionalidad de una clase generada por Entity Framework.
/// </summary>
public class Order
{
    /// <summary>
    ///     Obtiene el total de la orden.
    /// </summary>
    public decimal GetOrderTotal()
    {
        return this.CatalogItem.Price * this.Quantity;
    }
}