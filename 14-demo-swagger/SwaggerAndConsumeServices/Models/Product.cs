using System.ComponentModel.DataAnnotations;

namespace SwaggerAndConsumeServices.Models
{
    /// <summary>
    /// Clase que representa un producto
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Clave primaria del producto
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Nombre del producto
        /// </summary>
        [Required]
        public required string Name { get; set; }
        /// <summary>
        /// Precio del producto
        /// </summary>
        public decimal Price { get; set; }
    }
}
