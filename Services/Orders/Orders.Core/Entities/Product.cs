using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orders.Core.Entities
{
    public class Product : BaseEntity
    {
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Product Price
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime CreatedTime{ get; set; }
    }
}
