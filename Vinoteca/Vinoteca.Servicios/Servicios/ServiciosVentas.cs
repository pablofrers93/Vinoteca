using System;
using System.Collections.Generic;
using Vinoteca.Datos.Interfaces;
using Vinoteca.Datos;
using Vinoteca.Entidades.Dtos.Venta;
using Vinoteca.Entidades.Dtos.VentaProducto;
using Vinoteca.Entidades.Entidades;
using Vinoteca.Servicios.Interfaces;
using System.Transactions;
using Vinoteca.Entidades.Enum;

namespace Vinoteca.Servicios.Servicios
{
    public class ServiciosVentas : IServiciosVentas
    {
        private readonly IRepositorioVentas _repositorio;
        private readonly IRepositorioVentasProductos _repoVentasProductos;
        private readonly IRepositorioProductos _repoProductos;
        private readonly IRepositorioCarritos _repoCarritos;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosVentas(IRepositorioVentas repositorio,
           IRepositorioVentasProductos repoVentasProductos,
           IRepositorioProductos repoProductos,
           IRepositorioCarritos repoCarritos,
           IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _repoVentasProductos = repoVentasProductos;
            _repoProductos = repoProductos;
            _repoCarritos = repoCarritos;
            _unitOfWork = unitOfWork;
        }
        public int GetCantidad()
        {
            try
            {
                return _repositorio.GetCantidad();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<VentaProductoListDto> GetVentaProducto(int ventaId)
        {
            try
            {
                return _repoVentasProductos.GetVentaProductos(ventaId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<VentaListDto> GetVentas()
        {
            try
            {
                return _repositorio.GetVentas();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public VentaListDto GetVentasPorId(int id)
        {
            try
            {
                return _repositorio.GetVentaPorId(id);
            }
            catch (Exception)
            {
               throw;
            }
        }

        public void Guardar(Venta venta, string user)
        {
            try
            {
                using (var transaction = new TransactionScope())
                {

                    var ventaGuardar = new Venta()
                    {
                        UsuarioId = venta.UsuarioId,
                        Fecha = venta.Fecha,
                        TransaccionId = venta.TransaccionId,
                        Estado = Estado.Paga,
                        Importe = venta.Importe
                    };
                    _repositorio.Agregar(ventaGuardar);
                    _unitOfWork.SaveChanges();
                    foreach (var item in venta.Detalles)
                    {
                        item.VentaId = ventaGuardar.VentaId;
                        _repoVentasProductos.Agregar(item);
                        _repoProductos.ActualizarStock(item.ProductoId, item.Cantidad);
                        _repoCarritos.Borrar(user, item.ProductoId);
                    }
                    _unitOfWork.SaveChanges();
                    transaction.Complete();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
