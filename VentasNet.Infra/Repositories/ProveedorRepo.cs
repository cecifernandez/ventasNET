using Microsoft.EntityFrameworkCore;
using VentaNET.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;
using VentasNET.Entity.Data;
using VentasNET.Entity.Models;

namespace VentasNet.Infra.Repositories;

public class ProveedorRepo : IProveedorRepo
{
    private readonly VentasNetContext _context;

    public ProveedorRepo(VentasNetContext context)
    {
        _context = context;
    }

    public ProveedorResponse AddProveedor(ProveedorReq proveedor)
    {
        ProveedorResponse proveedorResponse = new ProveedorResponse();

        //verificar si existe
        if (proveedor.Cuit != null)
        {
            var existeProv = GetProveedorCuit(proveedor.Cuit);

            if (existeProv == null)
            {
                try
                {
                    var provNew = MapeoProveedor(proveedor);

                    provNew.Estado = true;
                    provNew.FechaAlta = DateTime.Now;
                    provNew.FechaBaja = DateTime.MinValue;


                    _context.Add(provNew);
                    _context.SaveChanges();
                    proveedorResponse.Guardar = true;
                    proveedorResponse.RazonSocial = provNew.RazonSocial;
                }
                catch (Exception ex)
                {
                    proveedorResponse.Mensaje = "Ocurrió un error al modificar cliente";
                    proveedorResponse.Guardar = false;
                }

            }
        }

        return proveedorResponse;
    }

    public Proveedor MapeoProveedor(ProveedorReq proveedor)
    {
        Proveedor prov = new Proveedor()
        {
            Apellido = proveedor.Apellido,
            Nombre = proveedor.Nombre,
            Cuit = proveedor.Cuit,
            Domicilio =proveedor.Domicilio,
            Telefeno = proveedor.Telefeno,
            IdProveedor = proveedor.IdProveedor,
            RazonSocial = proveedor.RazonSocial,
            Localidad = proveedor.Localidad,
            Provincia = proveedor.Provincia,
            Estado = proveedor.Estado,
            FechaAlta = proveedor.FechaAlta,
            FechaBaja = proveedor.FechaBaja,
            IdUsuario = proveedor.IdUsuario,
        };

        return prov;
    }

    public ProveedorResponse UpdateProveedor(ProveedorReq proveedor)
    {
        ProveedorResponse provResponse = new ProveedorResponse();

        var existeProv = _context.Proveedor.Where(x => x.Cuit == proveedor.Cuit).FirstOrDefault();

        if (existeProv != null)
        {
            try
            {
                //existeProv.Telefeno = proveedor.Telefono;
                existeProv.RazonSocial = proveedor.RazonSocial;


                _context.Update(existeProv);
                _context.SaveChanges();

                provResponse.Guardar = true;
                provResponse.RazonSocial = existeProv.RazonSocial;
            }
            catch (Exception ex)
            {
                provResponse.Mensaje = "Ocurrió un error al modificar proveedor";
                provResponse.Guardar = false;
            }

        }

        return provResponse;
    }

    public ProveedorResponse DeleteProveedor(ProveedorReq proveedor)
    {
        ProveedorResponse provResponse = new ProveedorResponse();

        var existeProv = _context.Proveedor.Where(x => x.Cuit == proveedor.Cuit).FirstOrDefault();

        if (existeProv != null)
        {
            try
            {
                existeProv.Estado = false;
                existeProv.FechaBaja = DateTime.Now;


                _context.Update(existeProv);
                _context.SaveChanges();

                provResponse.Guardar = true;
                provResponse.RazonSocial = existeProv.RazonSocial;
            }
            catch (Exception ex)
            {
                provResponse.Mensaje = "Ocurrió un error al modificar proveedor";
                provResponse.Guardar = false;
            }

        }

        return provResponse;
    }

    public Proveedor GetProveedorCuit(string cuit)
    {
        var proveedor = _context.Proveedor.Where(x => x.Cuit == cuit).FirstOrDefault();

        return proveedor;
    }

    public List<ProveedorReq> GetProveedores()
    {
        List<ProveedorReq> listadoProv = new List<ProveedorReq>();
        var lista = _context.Proveedor.Where(x => x.Estado != false).ToList();

        foreach (var item in lista)
        {
            ProveedorReq provReq = new ProveedorReq();
            provReq.Nombre = item.Nombre;
            provReq.Apellido = item.Apellido;
            provReq.IdProveedor = item.IdProveedor;
            provReq.Cuit = item.Cuit;
            provReq.RazonSocial = item.RazonSocial;
            provReq.Domicilio = item.Domicilio;
            provReq.Localidad = item.Localidad;
            provReq.Telefeno = item.Telefeno;
            provReq.Estado = item.Estado;
            provReq.FechaAlta = item.FechaAlta;
            provReq.FechaBaja = item.FechaBaja;

            listadoProv.Add(provReq);
        }
        return listadoProv;
    }
}
