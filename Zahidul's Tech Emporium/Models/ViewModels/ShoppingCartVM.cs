namespace Zahidul_s_Tech_Emporium.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> shoppingCarts { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
