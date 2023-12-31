﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vinoteca.Entidades.Dtos.Producto;
using Vinoteca.Entidades.Entidades;

namespace Vinoteca.Datos.Interfaces
{
    public interface IRepositorioBodegas
    {
        List<Bodega> GetBodegas();
        void Agregar(Bodega bodega);
        void Editar(Bodega bodega);
        void Borrar(int id);
        bool Existe(Bodega bodega);
        Bodega GetBodegaPorId(int bodegaId);
        List<Bodega> Filtrar(Func<Bodega, bool> predicado, int cantidad, int pagina);
        bool EstaRelacionada(Bodega bodega);
        List<Bodega> GetBodegasPorPagina(int cantidad, int pagina);
        int GetCantidad();
        int GetCantidad(Func<Bodega, bool> predicado);
        List<SelectListItem> GetBodegasDropDownList();
    }
}
