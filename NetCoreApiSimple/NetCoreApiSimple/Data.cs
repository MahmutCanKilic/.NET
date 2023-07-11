namespace NetCoreApiSimple
{
    public class Data
    {
        public List<int> productId;
        
        public int id1 = 1;
        public int id2 = 2;
        public int id3 = 3;
        public int id4 = 4;

        public Data()
        {
            productId = new List<int>();
            AddProductsId();
        }

        public void AddProductsId()
        {
            productId.Add(id1);
            productId.Add(id2);
            productId.Add(id3);
            productId.Add(id4);
        }
    }
}
