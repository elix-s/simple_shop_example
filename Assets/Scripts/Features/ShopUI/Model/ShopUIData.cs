using System.Collections.Generic;

public class ShopUIData 
{
    public string TitleText { get; }
    public string DescriptionText { get; }
    public List<string> CreatedItems;
    public float Price { get; }
    public int Discount { get; }
    public string MainIconAddress { get; }

    public ShopUIData(string title, string description, List<string> createdItems, float price, 
        int discount, string mainIcon)
    {
        TitleText = title;
        DescriptionText = description;
        CreatedItems = createdItems;
        Price = price;
        Discount = discount;
        MainIconAddress = mainIcon;
    }
}
