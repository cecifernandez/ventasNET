﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VentasNet.Infra.Data;

public partial class MetodosPago
{
    public int IdMetodoPago { get; set; }

    public string MetodoPago { get; set; }

    public bool Estado { get; set; }

    public DateTime? FechaAlta { get; set; }

    public DateTime? FechaBaja { get; set; }
}