using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNET.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;

namespace VentasNet.Infra.Interfaces
{
    public interface IStockRepo
    {
        public StockResponse AddStock(StockReq stock);
        public Stock MapeoStock(StockReq stock);
        public StockResponse UpdateStock(StockReq stock);
        public StockResponse DeleteStock(StockReq stock);
        public List<StockReq> GetStock();
    }
}
