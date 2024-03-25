using APBD_Zadanie3.Interface;

namespace APBD_Zadanie3.Models;

public class ContainerC : Container,IHazardNotifier
{

    protected string productType;
    protected double temperature;
    public ContainerC(double tareWeight, double height, double depth, double maxLoad,string type)
        : base("C", tareWeight, height, depth, maxLoad)
    {
        productType = type;
        temperature = productTemp.GetTemp(type);

    }
    
    public static class productTemp
    {
        private static Dictionary<string,double> products = new Dictionary<string, double>
        {
            {"Bananas",13.3},
            {"Chocolate",18},
            {"Fish",2},
            {"Meat",-15},
            {"Frozen Pizza",-30},
            {"Butter",20.5}
            
            
        };

        public static double GetTemp(string product)
        {
            return products[product];
        }
       
       

       
    }
    public void LoadCargo(double weight,string type)
    {
        if (CurrentLoad + weight > MaxLoad)
        {
            throw new OverfillException($"Przekroczono maksymalną ładowność kontenera {ContainerNumber}");
        }

        if (!type.Equals(productType))
        {
            NotifyDangerousSituation(ContainerNumber);
        }
        else
            CurrentLoad += weight;


    }
    public void NotifyDangerousSituation(string containerNumber)
    {
        Console.WriteLine($"Zgłoszono niebezpieczną sytuację dla kontenera: {containerNumber}");
    }
    
    public override string ToString()
    {
        return "Kontenr typu C nr:"+ ContainerNumber +" o wysokość-" + Height + ",głębkokości-" + Height
               + ",przewożący " + productType + " o wadze " + CurrentLoad + " i wadze maksymalnej " + MaxLoad;
    }
}