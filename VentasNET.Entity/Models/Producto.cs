﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VentasNET.Entity.Models;

public partial class Producto
{
    public int Id { get; set; }

    public int IdProveedor { get; set; }

    public string NombreProducto { get; set; }

    public string Descripcion { get; set; }

    public int ImporteProducto { get; set; }

    public bool Estado { get; set; }
}