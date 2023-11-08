﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VentasNet.Infra.Data;

public partial class Stock
{
    public int Id { get; set; }

    public int IdComprobante { get; set; }

    public int IdProducto { get; set; }

    public int IdUsuario { get; set; }

    public int CantIngreso { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public int CantEgreso { get; set; }

    public DateTime? FechaEgreso { get; set; }

    public byte[] FechaMovimiento { get; set; }

    public virtual Comprobante IdComprobanteNavigation { get; set; }

    public virtual Producto IdProductoNavigation { get; set; }
}