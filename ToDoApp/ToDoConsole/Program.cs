using Business;
using Data;
using System;

namespace ToDoConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToDoBusiness doBusiness = new ToDoBusiness();
            Console.WriteLine("Komutlar: ekle, sil, hepsini getir, detaylı ara, güncelle");

            do
            {

                Console.WriteLine("islem tipini giriniz");
                string islemTemp = Console.ReadLine();
                switch (islemTemp)
                {
                    case "ekle":
                        Console.WriteLine("id ve açıklama giriniz");
                        doBusiness.Add(int.Parse(Console.ReadLine()), Console.ReadLine());
                        break;
                    case "sil":
                        Console.WriteLine("silinecek üyenin id");
                        doBusiness.Delete(int.Parse(Console.ReadLine()));
                        break;
                    case "id getir":
                        {
                            int id = int.Parse(Console.ReadLine());
                            ToDo toDo = doBusiness.FindId(id);
                            if (toDo != null)
                            {
                                Console.WriteLine("kayıt bulundu: " + toDo.Id + "  " + toDo.Description + "  " + toDo.CreatedTime);
                            }
                            else
                            {
                                Console.WriteLine("kayıt bulunamadı");
                            }
                            break;
                        }

                    case "hepsini getir":
                        foreach (var toDo in doBusiness.All())
                        {
                            if (doBusiness.All() != null)
                            {

                                Console.WriteLine(toDo.Id + " " + toDo.Description + " " + toDo.CreatedTime);
                            }
                            else
                            {
                                Console.WriteLine("0 üye bulunmaktadır");
                            }
                        }
                        break;
                    case "detaylı ara":

                        {

                            ToDo toDo = doBusiness.FindDetailed(int.Parse(Console.ReadLine()), Console.ReadLine());
                            DateTime dateTime = toDo.CreatedTime;
                            if (toDo != null)
                            {
                                Console.WriteLine("kayıt bulundu: " + toDo.Id + "  " + toDo.Description + "  " + dateTime);

                            }
                            else
                            {
                                Console.WriteLine("kayıt bulunamadı");
                            }
                        }




                        break;
                    case "güncelle":

                        foreach (var toDo in doBusiness.All())
                        {
                            Console.WriteLine("güncellemek istediğiniz kaydın id'sini giriniz");
                            if (toDo.Id == int.Parse(Console.ReadLine()))
                            {
                                Console.WriteLine("kayıt bulundu. Yeni Id giriniz.");
                                doBusiness.Update(int.Parse(Console.ReadLine()), toDo.Description);
                                Console.WriteLine("yeni kayıt: " + toDo.Id + " " + toDo.Description + " " + toDo.CreatedTime);
                            }
                            else
                            {
                                Console.WriteLine("kayıt bulunamadı");
                            }
                            break;
                        }
                        break;
                }
            } while (true);



        }

    }
}