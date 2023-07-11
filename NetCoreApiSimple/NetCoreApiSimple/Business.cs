namespace NetCoreApiSimple
{
    public class Business : Data
    {
        Data data = new Data();

        public bool FindId(int id)
        {
            foreach (int item in data.productId)
            {
                if (item == id)
                {
                    return true;
                    break;
                }
            }
            return false;
        }
        public List<int> All()
        {
            //return data.productId.Select(x => x.ToString()).ToList();
            return data.productId;
        }
    }
}
