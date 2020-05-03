namespace Shop.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderDetail : IEntity
    {
        public int Id { get; set; }

        [Required]
        public Productos Product { get; set; }

        [Display(Name = "Precio")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Price { get; set; }

        [Display(Name = "Cantidad")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Quantity { get; set; }

        [Display(Name = "Precio Total")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Value { get { return this.Price * this.Quantity; } }
    }
}