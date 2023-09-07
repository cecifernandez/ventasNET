using Microsoft.EntityFrameworkCore;
using VentaNET.Models;
using VentasNET.Entity.Data;

namespace VentasNet.Infra.Repositories;

public class ProveedorRepo
{
    VentasNetContext _context = new VentasNetContext();


    public void ModificarProveedor(Proveedor proveedor)
    {
        int index = Listados.ListaProveedor.FindIndex(x => x.Id == x.Id);

        Listados.ListaProveedor[index].RazonSocial = proveedor.RazonSocial;
        Listados.ListaProveedor[index].Cuit = proveedor.Cuit;
        Listados.ListaProveedor[index].Provincia = proveedor.Provincia;
        Listados.ListaProveedor[index].Domicilio = proveedor.Domicilio;


    }

    public void DeleteProveedor(Proveedor proveedor)
    {
        

        var index = Listados.ListaProveedor.FindIndex(x => x.Id == proveedor.Id);
        Listados.ListaProveedor[index].Estado = false;

    }

    public bool VerificarProv(Proveedor proveedor)
    {
        bool existe = false;

        Proveedor existeProv = new Proveedor();

        existeProv = Listados.ListaProveedor.Find(x => x.Id == proveedor.Id);
        if (existeProv != null)
        {
            existe = true;
        }

        return existe;
    }
    public bool AgregarProv(Proveedor proveedor)
    {
        var existeProv = _context.Proveedor.Where(x => x.Cuit == proveedor.Cuit).FirstOrDefault();

        if (existeProv == null)
        {
            try
            {
                _context.Add(proveedor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }

        return false;

    }

    public bool UpdateProveedor(Proveedor proveedor)
    {


        var existeProv = _context.Proveedor.Where(x => x.Cuit == proveedor.Cuit).FirstOrDefault();

        if (existeProv != null)
        {
            try
            {
                existeProv.Telefeno = proveedor.Telefono;
                existeProv.RazonSocial = proveedor.RazonSocial;


                _context.Update(existeProv);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }

        return false;

    }
}
