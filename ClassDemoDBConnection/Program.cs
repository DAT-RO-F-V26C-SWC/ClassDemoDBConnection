// See https://aka.ms/new-console-template for more information
using ClassDemoDBConnection;

Console.WriteLine("Hello, World!");

DBWorker dbWorker = new DBWorker();

if (dbWorker.CheckUser("Peter", "nonsen' OR '1'='1"))
{
    Console.WriteLine("Fint du er inde");
}
else
{
    Console.WriteLine("Prøv igen");
}

if (dbWorker.CheckUser2("Peter", "nonsen' OR '1'='1"))
{
    Console.WriteLine("Fint du er inde");
}
else
{
    Console.WriteLine("Prøv igen");
}

