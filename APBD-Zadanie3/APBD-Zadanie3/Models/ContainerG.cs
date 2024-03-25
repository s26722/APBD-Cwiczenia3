

namespace APBD_Zadanie3.Models;
using Interface;

public class ContainerG : Container,IHazardNotifier
{
    protected int pressure { get; }
    protected string gas { get; set; }
    

    public ContainerG(double tareWeight, double height, double depth, double maxLoad,string Gas )
        : base("G", tareWeight, height, depth, maxLoad)
    {
        gas = Gas;
    }
    
    
    
    
    public void NotifyDangerousSituation(string containerNumber)
    {
        Console.WriteLine($"Zgłoszono niebezpieczną sytuację dla kontenera: {containerNumber}");
    }
    
    public void UnloadCargo()
    {
        CurrentLoad = CurrentLoad * 0.05;
    }
    public override string ToString()
    {
        return "Kontenr typu G nr:"+ ContainerNumber +" o wysokość-" + Height + ",głębkokości-" + Height
               + ",przewożący " + gas+ " o wadze " + CurrentLoad + " i wadze maksymalnej " + MaxLoad;
    }
}
    
    

