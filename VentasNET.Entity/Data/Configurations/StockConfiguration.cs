﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using VentasNET.Entity.Data;
using VentasNET.Entity.Models;

namespace VentasNET.Entity.Data.Configurations
{
    public partial class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> entity)
        {
            entity.Property(e => e.FechaEgreso).HasColumnType("datetime");
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.FechaMovimiento)
            .IsRequired()
            .IsRowVersion()
            .IsConcurrencyToken();

            entity.HasOne(d => d.IdComprobanteNavigation).WithMany(p => p.Stock)
            .HasForeignKey(d => d.IdComprobante)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Stock_Comprobante");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Stock)
            .HasForeignKey(d => d.IdProducto)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Stock_Producto");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Stock> entity);
    }
}
