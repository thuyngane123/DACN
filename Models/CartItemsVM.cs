namespace DACN.Models
{
    public class CartItemsVM
    {
        public int CartId { get; set; }
        public string CarName { get; set; }
        public string Image { get; set; }
        public DateTime pickupDate { get; set; }
        public DateTime returnDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

}
