﻿using APBD_Zadanie_6.Models;
using Microsoft.AspNetCore.Mvc;
using Zadanie5.Services;

namespace APBD_Zadanie_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehousesController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpPost]
        public ActionResult AddProduct(ProductWarehouse product)
        {
            _warehouseService.AddProduct(product);
            return Ok();
        }
    }
}
