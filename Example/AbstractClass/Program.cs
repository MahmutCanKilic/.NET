using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
 
    private static void Main(string[] args)
    {

    }

}
public abstract class Parent
{
    public abstract void Fonk();
}
public abstract class TestClass
{
    Program programNesne = new Program();/*
    Parent parentNesne = new Parent();*/ // Abstract Classlar tamamen kalıtım amaçlı oluşturulduğu için nesne oluşturulamaz.
}
