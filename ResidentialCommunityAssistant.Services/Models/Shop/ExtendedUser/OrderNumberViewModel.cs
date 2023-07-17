namespace ResidentialCommunityAssistant.Services.Models.Shop.ExtendedUser
{

    public class OrderNumberViewModel
    {
        private int orderId;

        public OrderNumberViewModel(int orderId)
        {
            this.orderId = orderId;
        }
        public int RegularId { get; set; }
        public string OrderName
        {
            get
            {
                return $"SuperHiddenOrderNumber_{orderId}";
            }

        }
    }
}
