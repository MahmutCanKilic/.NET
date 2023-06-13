namespace EnumAndTypes
{
    internal class Program
    {
        enum Gun { Pazartesi, Salı, Carsamba, Persembe, Cuma, Cumartesi, Pazar };

        static void Main(string[] args)
        {
            Gun secilenGun = Gun.Carsamba;

            if (secilenGun == Gun.Cumartesi || secilenGun == Gun.Pazar)
            {
                Console.WriteLine("Hafta sonu seçtiniz.");
            }
            else
            {
                Console.WriteLine("Hafta içi seçtiniz.");
            }
        }
    }
}
