namespace SUServer.DTO
{
    public class TaobaoProductResponse
    {
        public string Result { get; set; }
        public Status Status { get; set; }
        public Item Item { get; set; }
    }

    public class Status
    {
        public string Msg { get; set; }
        public int Code { get; set; }
        public string Action { get; set; }
        public double ExecutionTime { get; set; }
    }

    public class Item
    {
        public string Num_iid { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Total_sales { get; set; }
        public int Fav_count { get; set; }
        public string Cat_id { get; set; }
        public string Root_cat_id { get; set; }
        public string Cat_name { get; set; }
        public string Root_cat_name { get; set; }
        public string Brand_id { get; set; }
        public string Detail_url { get; set; }
        public List<string> Images { get; set; }
        public string Video_thumbnail { get; set; }
        public string Video { get; set; }
        public string Properties_cut { get; set; }
        public List<Property> Properties { get; set; }
        public string Desc_url { get; set; }
        public List<string> Desc_imgs { get; set; }
        public string Desc_text { get; set; }
        public List<Sku> Skus { get; set; }
        public Delivery Delivery { get; set; }
        public Seller Seller { get; set; }
    }

    public class Property
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Sku
    {
        public string Price { get; set; }
        public string Promotion_price { get; set; }
        public int Quantity { get; set; }
        public List<SkuBase> Sku_base { get; set; }
        public List<SkuProp> Sku_props { get; set; }
    }

    public class SkuBase
    {
        public string PropPath { get; set; }
        public string SkuId { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
    }

    public class SkuProp
    {
        public List<Value> Values { get; set; }
        public string Name { get; set; }
        public string Pid { get; set; }
    }

    public class Value
    {
        public string Name { get; set; }
        public string Vid { get; set; }
        public string Image { get; set; }
    }

    public class Delivery
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Delivery_fee { get; set; }
        public string Area_id { get; set; }
        public List<Protection> Protection { get; set; }
    }

    public class Protection
    {
        public string Title { get; set; }
        public string Desc { get; set; }
    }

    public class Seller
    {
        public string Seller_id { get; set; }
        public string Seller_nick { get; set; }
        public string Shop_id { get; set; }
        public string Shop_title { get; set; }
        public string Shop_url { get; set; }
        public string Shop_icon { get; set; }
        public string Total_items { get; set; }
        public string User_type { get; set; }
        public string Starts { get; set; }
        public string Rating { get; set; }
        public List<Evaluate> Evaluates { get; set; }
    }

    public class Evaluate
    {
        public string Title { get; set; }
        public string Score { get; set; }
        public string Level { get; set; }
        public string LevelText { get; set; }
    }
}
