using Microsoft.AspNetCore.Mvc;

namespace Zahidul_s_Tech_Emporium.Models.ViewModels
{
    
    public class OrderVM
    {
        public OrderHeader OrderHeader { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
