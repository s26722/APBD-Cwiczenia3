


using APBD_Zadanie3.Interface;

using APBD_Zadanie3.Models;

//TEST KONTENERY 

ContainerL Kontener1 = new ContainerL(20,100,80,100,"Oil");
Console.WriteLine(Kontener1);
Kontener1.LoadCargo(70,"Oil");
Console.WriteLine(Kontener1);
Kontener1.LoadCargo(50,"Oil");
Console.WriteLine(Kontener1);

try
{
    Kontener1.LoadCargo(120, "Oil");
}
catch (Exception e)
{
    Console.WriteLine(e);
}




ContainerG Kontener2 = new ContainerG(20,120,90,300,"Gas");
Console.WriteLine(Kontener2);
Kontener2.LoadCargo(120);
Console.WriteLine(Kontener2);
Kontener2.UnloadCargo();
Console.WriteLine(Kontener2);




ContainerC Kontener3 = new ContainerC(20,120,90,100,"Meat");
Console.WriteLine(Kontener3);
Kontener3.LoadCargo(10, "cos");
Console.WriteLine(Kontener3);
Kontener3.LoadCargo(80,"Meat");
Console.WriteLine(Kontener3);
//Statek
List<Container> kontnery = new List<Container>();
kontnery.Add(Kontener1);
kontnery.Add(Kontener2);
kontnery.Add(Kontener3); 
Ship statek1 = new Ship(30, 8, 1000);
statek1.LoadContainerList(kontnery);
Console.WriteLine(statek1);

ContainerG Kontener4 = new ContainerG(200,120,90,30000,"Gas");
Kontener4.LoadCargo(2000);

try
{
    statek1.LoadContainer(Kontener4);
    
}catch(Exception e ) {
    Console.WriteLine(e);
}

Ship statek2 = new Ship(30, 2, 8000);
statek2.LoadContainer(Kontener4);
Console.WriteLine(statek2);
statek1.ChangeContainerShip("KON-L-2",statek2);
Console.WriteLine(statek1);
Console.WriteLine(statek2);
statek1.ChangeContainerShip("KON-G-3",statek2);
Console.WriteLine(statek1);

statek2.ContainerUnloadAll();
Console.WriteLine(statek2);

statek1.SwapContainer("KON-G-3",Kontener1);
Console.WriteLine(statek1);