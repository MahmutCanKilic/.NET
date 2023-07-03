using Business;

namespace Presentation
{
    public class Do
    {

        static void Main(string[] args)
        {
            ToDoBusiness doBusiness = new ToDoBusiness();
            doBusiness.Add((int)Console.ReadLine(), Console.ReadLine());
        }
    }
}