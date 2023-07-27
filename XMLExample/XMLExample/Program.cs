using System.Xml.Linq;
using System.Xml.Serialization;
using XMLProps;

namespace XMLExample
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Transactions transactions = new Transactions();
            transactions.XmlRead();
            transactions.XmlInsert();
            transactions.XmlUpdate();
            transactions.XmlDelete();
        }
    }
    public class Transactions
    {
        #region Members
        XDocument document = XDocument.Load(@"C:\Users\P2635\Desktop\XML.xml");
        #endregion
        #region Methods
        public void XmlRead()
        {

            XElement rootElement = document.Root;


            foreach (XElement item in rootElement.Elements())
            {
                Book book = new Book();
                book.Id = item.Attribute("id").Value;
                book.Author = item.Element("Author").Value;
                book.Title = item.Element("Title").Value;
                book.Genre = item.Element("Price").Value;
                book.Price = item.Element("Price").Value;
                book.PublishDate = item.Element("PublishDate").Value;
                book.Description = item.Element("Description").Value;
                Console.WriteLine("Id: " + book.Id + " Author:" + book.Author + " Title: " + book.Title +
                    " Genre: " + book.Genre + " Price: " + book.Price + " PublishDate: " +
                    book.PublishDate + " Description: " + book.Description);
                Console.WriteLine();

            }
            Console.WriteLine("********************************************");
            Console.ReadLine();
        }
        public void XmlInsert()
        {
            Book book = new Book();

            XElement rootElement = document.Root;

            XElement newElement = new XElement("Book");
            XAttribute xAttributeId = new XAttribute("id", "bk505");
            XElement xElementAuthor = new XElement("Author", "Detaysoft");
            XElement xElementTitle = new XElement("Title", ".Net");
            XElement xElementGenre = new XElement("Genre", "Horror");
            XElement xElementPrice = new XElement("Price", "9999");
            XElement xElementPublishDate = new XElement("PublishDate", "01-01-2023");
            XElement xElementDescription = new XElement("Description", "Software");

            newElement.Add(xAttributeId, xElementAuthor, xElementTitle, xElementGenre,
                            xElementPrice, xElementPublishDate, xElementDescription);
            rootElement.Add(newElement);

            document.Save(@"C:\Users\P2635\Desktop\XMLAdded.xml");

            foreach (XElement books in rootElement.Elements())
            {

                book.Id = books.Attribute("id").Value;
                book.Author = books.Element("Author").Value;
                book.Title = books.Element("Title").Value;
                book.Genre = books.Element("Genre").Value;
                book.Price = books.Element("Price").Value;
                book.PublishDate = books.Element("PublishDate").Value;
                book.Description = books.Element("Description").Value;
                Console.WriteLine("Id: " + book.Id + " Author:" + book.Author + " Title: " + book.Title +
                    " Genre: " + book.Genre + " Price: " + book.Price + " PublishDate: " +
                    book.PublishDate + " Description: " + book.Description);
                Console.WriteLine();
                Console.ReadLine();
                Console.WriteLine("********************************************");
            }
        }

        public void XmlUpdate()
        {
            document = XDocument.Load(@"C:\Users\P2635\Desktop\XMLAdded.xml");
            XElement rootDocumnet = document.Root;
            foreach (XElement element in rootDocumnet.Elements())
            {
                if (element.Attribute("id").Value == "bk101")
                {
                    element.Element("Author").Value = "Can Kilic";
                    element.Element("PublishDate").Value = "18-07-2023";
                    break;
                }
            }
            document.Save(@"C:\Users\P2635\Desktop\XMLUpdated.xml");
            Console.ReadLine();
            Console.WriteLine("********************************************");
        }

        public void XmlDelete()
        {
            document = XDocument.Load(@"C:\Users\P2635\Desktop\XMLUpdated.xml");
            XElement rootElement_ = document.Root;

            foreach (XElement element in rootElement_.Elements())
            {
                if (element.Attribute("id").Value == "bk102")
                {
                    element.Remove();
                    break;
                }
            }
            document.Save(@"C:\Users\P2635\Desktop\XMLDeleted.xml");
            Console.ReadLine();
            Console.WriteLine("********************************************");
            
        }
        #endregion

    }



}
