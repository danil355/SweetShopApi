namespace Domain.Model
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public double Quantity { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}