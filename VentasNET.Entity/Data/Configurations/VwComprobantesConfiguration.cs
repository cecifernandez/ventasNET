﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using VentasNET.Entity.Data;
using VentasNET.Entity.Models;

namespace VentasNET.Entity.Data.Configurations
{
    public partial class VwComprobantesConfiguration : IEntityTypeConfiguration<VwComprobantes>
    {
        public void Configure(EntityTypeBuilder<VwComprobantes> entity)
        {
            entity
            .HasNoKey()
            .ToView("vwComprobantes");

            entity.Property(e => e.Descripcion)
            .HasMaxLength(100)
            .IsUnicode(false);
            entity.Property(e => e.IdComprobante).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.NombreCorto)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.NroProximoCbte)
            .IsRequired()
            .HasMaxLength(35)
            .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<VwComprobantes> entity);
    }
}