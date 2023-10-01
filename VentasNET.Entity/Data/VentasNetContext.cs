﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using VentasNET.Entity.Data.Configurations;
using VentasNET.Entity.Models;
#nullable disable

namespace VentasNET.Entity.Data;

public partial class VentasNetContext : DbContext
{
    public VentasNetContext(DbContextOptions<VentasNetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Proveedor> Proveedor { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<VwUsuario> VwUsuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.ApplyConfiguration(new Configurations.ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ProductoConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ProveedorConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.VwUsuarioConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
