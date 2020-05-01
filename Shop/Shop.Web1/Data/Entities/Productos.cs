namespace Shop.Web1.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Productos : IEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} debe ser menos de {1} caracteres ")]
        [Required]
        public string Nombre { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        //Formato de campo  el cero indica a la variable que vamos a aplicarlo
        // y el c2 es el currency de moneda por defecto que tenga nuestra maquina,en mi caso
        // va a indicar colones, incluye separacion de miles y 2 decimales
        // el ApplyFormatInEditMode lo que hace es que a la hora de modifar el valor nos
        //desaparezca el formato anterior 
        public double Precio { get; set; }


        [Display(Name = "Imagen")]
        // El display solamente nos muestra una etiqueta
        public string ImageUrl { get; set; }

        [Display(Name = "Ultima Compra")]
        // El display solamente nos muestra una etiqueta
        public DateTime? UltComp { get; set; }

        [Display(Name = "Ultima Venta")]
        // El display solamente nos muestra una etiqueta
        public DateTime? UltVent { get; set; }

        [Display(Name = "Disponibilidad")]
        // El display solamente nos muestra una etiqueta
        public bool Disponi { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        //  el N2 es el formato Numerico  por defecto que tenga nuestra maquina
        //  incluye separacion de miles y 2 decimales
        // el ApplyFormatInEditMode lo que hace es que a la hora de modifar el valor nos
        //desaparezca el formato anterior 
        public double Stock { get; set; }

        public Usuarios Usuarios { get; set; } // Se crea la relacion uno a varios con la clase Usuarios

        public string ImageFullPath
        {

            get
            {
                if (string.IsNullOrEmpty(this.ImageUrl))
                {
                    return null;
                }

                return $"http://186.159.159.78:82/Xamarin{this.ImageUrl.Substring(1)}";
            }

        }

        // ; set; } // Se crea la relacion uno a varios con la clase Usuarios


    }
}
