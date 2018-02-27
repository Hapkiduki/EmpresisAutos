namespace EmpresisAutos.Models
{
    using Newtonsoft.Json;
    using System;

    public class MovItem
    {
        [JsonProperty(PropertyName = "orden")]
        public int Orden { get; set; }

        [JsonProperty(PropertyName = "estado")]
        public string Estado { get; set; }

        [JsonProperty(PropertyName = "fecha")]
        public DateTime FechaEnt { get; set; }

        [JsonProperty(PropertyName = "numfactu")]
        public string Numfactu { get; set; }

        [JsonProperty(PropertyName = "observa")]
        public string Observa { get; set; }

        [JsonProperty(PropertyName = "valsubtot")]
        public int Valsubtot { get; set; }

        [JsonProperty(PropertyName = "valiva")]
        public int Valiva { get; set; }

        [JsonProperty(PropertyName = "valtotal")]
        public int Valtotal { get; set; }

        [JsonProperty(PropertyName = "dcto")]
        public int Dcto { get; set; }

        [JsonProperty(PropertyName = "referencia")]
        public string Referencia { get; set; }

        [JsonProperty(PropertyName = "nameref")]
        public string Nameref { get; set; }

        [JsonProperty(PropertyName = "tasaiva")]
        public int Tasaiva { get; set; }

        [JsonProperty(PropertyName = "cantidad")]
        public int Cantidad { get; set; }

        [JsonProperty(PropertyName = "valor")]
        public int Valor { get; set; }

        [JsonProperty(PropertyName = "iva")]
        public double Iva { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
        
        [JsonProperty(PropertyName = "tdes1")]
        public int Tdes1 { get; set; }

        [JsonProperty(PropertyName = "valdes")]
        public int Valdes { get; set; }
    }
}
