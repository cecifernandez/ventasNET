﻿namespace VentaNET.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? RazonSocial { get; set; }
        public string? Cuit { get; set; }  
        public string? Domicilio { get; set; }  
        public string? Provincia { get; set; }   
    }
}