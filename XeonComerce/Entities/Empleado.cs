﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Empleado : BaseEntity
    {
        [JsonPropertyName("idUsuario")]
        public string IdUsuario { get; set; }
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("apellidoUno")]
        public string ApellidoUno { get; set; }
        [JsonPropertyName("apellidoDos")]
        public string ApellidoDos { get; set; }
        [JsonPropertyName("genero")]
        public string Genero { get; set; }
        [JsonPropertyName("fechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [JsonPropertyName("correoElectronico")]
        public string CorreoElectronico { get; set; }
        [JsonPropertyName("numeroTelefono")]
        public string NumeroTelefono { get; set; }
        [JsonPropertyName("idDireccion")]
        public int IdDireccion { get; set; }
        [JsonPropertyName("estado")]
        public string Estado { get; set; }
        [JsonPropertyName("idComercio")]
        public string IdComercio { get; set; }
        [JsonPropertyName("idSucursal")]
        public string IdSucursal { get; set; }

        [JsonPropertyName("idEmpleado")]
        public int IdEmpleado { get; set; }

        [JsonPropertyName("idRol")]
        public int IdRol { get; set; }


        public Empleado() { }
    }
}
