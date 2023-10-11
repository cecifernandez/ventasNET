using VentasNET.Entity.Data;
using VentaNET.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNET.Entity.Models;
using VentasNet.Infra.Interfaces;

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
            Apellido = proveedor.Apellido != null ? proveedor.Apellido : string.Empty,
            Nombre = proveedor.Nombre != null ? proveedor.Nombre : string.Empty,
            Cuit = proveedor.Cuit != null ? proveedor.Cuit : string.Empty,
            Domicilio =proveedor.Domicilio != null ? proveedor.Domicilio : string.Empty,
            Telefeno = proveedor.Telefeno != null ? proveedor.Telefeno : string.Empty,
            
            RazonSocial = proveedor.RazonSocial != null ? proveedor.RazonSocial : string.Empty,
            Localidad = proveedor.Localidad != null ? proveedor.Localidad : string.Empty,
            Provincia = proveedor.Provincia != null ? proveedor.Provincia : string.Empty,
            Estado = true,
            FechaAlta = proveedor.FechaAlta != null ? proveedor.FechaAlta : DateTime.Now,
            FechaBaja = proveedor.FechaBaja != null ? proveedor.FechaBaja : DateTime.Now,
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
                existeProv.RazonSocial = proveedor.RazonSocial != null ? proveedor.RazonSocial : existeProv.RazonSocial;
                existeProv.Apellido = proveedor.Apellido != null ? proveedor.Apellido : existeProv.Apellido;
                existeProv.Nombre = proveedor.Nombre != null ? proveedor.Nombre : existeProv.Nombre;
                existeProv.Cuit = proveedor.Cuit != null ? proveedor.Cuit : existeProv.Cuit;
                existeProv.Domicilio = proveedor.Domicilio != null ? proveedor.Domicilio : existeProv.Domicilio;
                existeProv.Telefeno = proveedor.Telefeno != null ? proveedor.Telefeno : existeProv.Telefeno;
                existeProv.Localidad = proveedor.Localidad != null ? proveedor.Localidad : existeProv.Localidad;
                existeProv.Provincia = proveedor.Provincia != null ? proveedor.Provincia : existeProv.Provincia;
                existeProv.Estado = true;
                existeProv.IdUsuario = proveedor.IdUsuario != null ? proveedor.IdUsuario : existeProv.IdUsuario;


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
            provReq.Provincia = item.Provincia;
            provReq.Estado = item.Estado;
            provReq.FechaAlta = item.FechaAlta;
            provReq.FechaBaja = item.FechaBaja;

            listadoProv.Add(provReq);
        }
        return listadoProv;
    }
}
