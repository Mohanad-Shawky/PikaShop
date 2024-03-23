
namespace PikaShop.Services.Contracts
{
    public interface ICartItemServices : IServices
    {
        void ClearCartItemsForUser(string userId);

        public void ClearCartItemsForUser(int productId, string userId);

        public void DeleteCartItem(int id, int id1);
        
    }
}
