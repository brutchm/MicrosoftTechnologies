﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Usuario : BaseEntity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
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
        [JsonPropertyName("codigo")]
        public string Token { get; set; }

        [JsonPropertyName("tipo")]
        public string Tipo { get; set; }

        public Usuario() { }
    }
}
