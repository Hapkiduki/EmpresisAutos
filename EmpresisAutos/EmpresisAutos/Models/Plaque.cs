namespace EmpresisAutos.Models
{
    using System;
    using System.Collections.Generic;

    public class Plaque
    {
        public string Nombrecli { get; set; }
        public string Codigocli { get; set; }
        public DateTime Fecha { get; set; }
        public string Vehiculo { get; set; }
        public string Colorv { get; set; }
        public int Cilindra { get; set; }
        public int Modelo { get; set; }
        public string Tipo { get; set; }
        public string Placa { get; set; }
        public string Servicio { get; set; }
        public string Nmotor { get; set; }
        public string Nchasis { get; set; }
        public int Kilometros { get; set; }
        public List<MovItem> MovItems { get; set; }
    }
}
