﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VentasNET.Entity.Models;

public partial class FormasDePago
{
    public int Id { get; set; }

    public int IdTipoPago { get; set; }

    public string Entidad { get; set; }

    public int IdFinanciacion { get; set; }

    public string Descripcion { get; set; }
}