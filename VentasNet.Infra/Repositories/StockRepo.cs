using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNET.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;

namespace VentasNet.Infra.Repositories
{
    public class StockRepo : IStockRepo
    {
        public StockResponse AddStock(StockReq stock)
        {
            throw new NotImplementedException();
        }

        public StockResponse DeleteStock(StockReq stock)
        {
            throw new NotImplementedException();
        }

        public List<StockReq> GetStock()
        {
            throw new NotImplementedException();
        }

        public Stock MapeoStock(StockReq stock)
        {
            throw new NotImplementedException();
        }

        public StockResponse UpdateStock(StockReq stock)
        {
            throw new NotImplementedException();
        }
    }
}
