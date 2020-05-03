namespace Shop.Web.Data.Entities
{ 
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

	public class Order : IEntity
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Fecha de Orden")]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
		public DateTime OrderDate { get; set; }

		[Display(Name = "Fecha de Orden")]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
		public DateTime? OrderDateLocal
		{
			get
			{
				if (this.OrderDate == null)
				{
					return null;
				}

				return this.OrderDate.ToLocalTime();
			}
		}


		[Display(Name = "Fecha de Entrega")]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
		public DateTime? DeliveryDate { get; set; }

		[Required]
		public Usuarios User { get; set; }

		public IEnumerable<OrderDetail> Items { get; set; }

		[Display(Name = "Cantidad")]
		[DisplayFormat(DataFormatString = "{0:N2}")]
		[Column(TypeName = "decimal(18,2)")]
		public double Quantity { get { return this.Items == null ? 0 : this.Items.Sum(i => i.Quantity); } }


		[DisplayFormat(DataFormatString = "{0:N0}")]
		public int Lines { get { return this.Items == null ? 0 : this.Items.Count(); } }


		[Column(TypeName = "decimal(18,2)")]
		[Display(Name = "Precio Total")]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		public double Value { get { return this.Items == null ? 0 : (double)this.Items.Sum(i => i.Value); } }
	}

}
