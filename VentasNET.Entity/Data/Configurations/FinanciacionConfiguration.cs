﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using VentasNET.Entity.Data;
using VentasNET.Entity.Models;

namespace VentasNET.Entity.Data.Configurations
{
    public partial class FinanciacionConfiguration : IEntityTypeConfiguration<Financiacion>
    {
        public void Configure(EntityTypeBuilder<Financiacion> entity)
        {
            entity.Property(e => e.Codigo)
            .IsRequired()
            .HasMaxLength(10)
            .IsFixedLength();
            entity.Property(e => e.Descripcion)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.Porcentaje)
            .HasMaxLength(10)
            .IsFixedLength();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Financiacion> entity);
    }
}
