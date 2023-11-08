﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNET.Entity.Models;

namespace VentasNet.Infra.DTO.Request
{
    public class StockReq
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
}
