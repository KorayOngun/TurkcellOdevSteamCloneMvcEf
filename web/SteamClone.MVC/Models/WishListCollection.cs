namespace SteamClone.MVC.Models
{
    public class WishListCollection
    {
        public List<WishListItem> WishList { get; set; } = new List<WishListItem>();
        public void Clear() => WishList.Clear();
      
        public int AddOrIncrease(WishListItem item)
        {
            if (!WishList.Any(i=>i.Id == item.Id))
            {
                
                WishList.Add(item);
                return 0; 
            }
            else
            {
                var listItem = WishList.FirstOrDefault(i=>i.Id == item.Id);
                listItem.Quantity++;
                return 1;
            }
        }
    }
    public class WishListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } 
        
        public int Quantity { get; set; } = 1;
    }
}
