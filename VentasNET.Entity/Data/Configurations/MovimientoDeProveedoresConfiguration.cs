﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using VentasNET.Entity.Data;
using VentasNET.Entity.Models;

namespace VentasNET.Entity.Data.Configurations
{
    public partial class MovimientoDeProveedoresConfiguration : IEntityTypeConfiguration<MovimientoDeProveedores>
    {
        public void Configure(EntityTypeBuilder<MovimientoDeProveedores> entity)
        {
            entity.Property(e => e.Comprobante)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.Descuentos).HasColumnType("decimal(16, 0)");
            entity.Property(e => e.FechaComprobante).HasColumnType("date");
            entity.Property(e => e.FechaMovimiento)
            .IsRequired()
            .IsRowVersion()
            .IsConcurrencyToken();
            entity.Property(e => e.ImporteTotal).HasColumnType("decimal(16, 2)");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<MovimientoDeProveedores> entity);
    }
}
