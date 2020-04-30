namespace Shop.Common.Models
{
    using Newtonsoft.Json;
    using System;
    public class Productos
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("precio")]
        public long Precio { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("ultComp")]
        public object UltComp { get; set; }

        [JsonProperty("ultVent")]
        public object UltVent { get; set; }

        [JsonProperty("disponi")]
        public bool Disponi { get; set; }

        [JsonProperty("stock")]
        public long Stock { get; set; }

        [JsonProperty("usuarios")]
        public Usuarios Usuarios { get; set; }

        [JsonProperty("imageFullPath")]
        public Uri ImageFullPath { get; set; }

        public override string ToString()
        {
            return $"{this.Nombre}{this.Precio:C2}";
        }
    }
}
