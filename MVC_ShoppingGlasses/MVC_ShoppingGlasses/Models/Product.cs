namespace MVC_ShoppingGlasses.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDatails = new HashSet<OrderDatail>();
        }

        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImgURL { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int Unitinstock { get; set; }

        [Required]
        public string Original { get; set; }

        public string State { get; set; }

        [Required][ForeignKey("Category")]
        public int CategoryID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDatail> OrderDatails { get; set; }
        public virtual Category Category { get; set; }
    }
}
