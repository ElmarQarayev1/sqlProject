

using SqlProject;

BrandServices bs = new BrandServices();

string opt;
do
{

    Console.WriteLine("1.Brand create");
    Console.WriteLine("2.Brand delete");
    Console.WriteLine("3.Brand get by id");
    Console.WriteLine("4.Get all brands");
    Console.WriteLine("5.Uptade brands");
    Console.WriteLine("0.Exit");
    Console.WriteLine("secim edin:");
    opt = Console.ReadLine();

    switch (opt)
    {
        case "1":
            bs.BrandCreate();
            break;
        case "2":
            bs.DeleteOneBrand();
            break;
        case "3":
            bs.ShowOneBrand();
            break;
        case "4":
            bs.ShowALlBrands();
            break;
        case "5":
            bs.UptadeOneBrand();
            break;
        case "0":
            Console.WriteLine("Program bitdi!");
            break;
        default:
            Console.WriteLine("yanlis secim!");
            break;
    }

} while (opt!="0");




