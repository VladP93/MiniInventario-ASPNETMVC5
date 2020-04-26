using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using db = InventarioDataBase;
using entidades = InventarioEntidades;

namespace InventarioDominio
{
    public class MapearDB : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "MapearDB";
            }
        }

        public MapearDB()
        {
            CreateMap<db.categoria, entidades.Categorias>();
            CreateMap<db.cliente, entidades.Clientes>();
            CreateMap<db.detalle, entidades.Detalles>();
            CreateMap<db.factura, entidades.Facturas>();
            CreateMap<db.modo_pago, entidades.Modo_pagos>();
            CreateMap<db.producto, entidades.Productos>();

            CreateMap<entidades.Categorias, db.categoria>();
            CreateMap<entidades.Clientes, db.cliente>();
            CreateMap<entidades.Detalles, db.detalle>();
            CreateMap<entidades.Facturas, db.factura>();
            CreateMap<entidades.Modo_pagos, db.modo_pago>();
            CreateMap<entidades.Productos, db.producto>();
        }

    }
}
