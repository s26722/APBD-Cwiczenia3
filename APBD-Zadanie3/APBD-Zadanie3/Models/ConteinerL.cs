namespace APBD_Zadanie3.Models;
using Interface;
using System;

public class ContainerL : Container, IHazardNotifier
{

    protected string currentLiquid { get; set; }

    public ContainerL(double tareWeight, double height, double depth, double maxLoad, string Liquid)
        : base("L", tareWeight, height, depth, maxLoad)
    {
        currentLiquid = Liquid;


    }



    public enum DangerousL
    {
        Oil,
        Acid,
        Radioacitve
    }




    public void NotifyDangerousSituation(string containerNumber)
    {
        Console.WriteLine($"Zgłoszono niebezpieczną sytuację dla kontenera: {containerNumber}");
    }


    public void LoadCargo(double weight, string liquid)
    {
        if (CurrentLoad + weight > MaxLoad)
        {
            throw new OverfillException($"Przekroczono maksymalną ładowność kontenera {ContainerNumber}");
        }

        bool isDangerous = false;

        foreach (DangerousL value in Enum.GetValues(typeof(DangerousL)))
        {
            if (liquid.Equals(value.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                isDangerous = true;
                break;
            }
        }

        if(isDangerous)
        {
            if ((CurrentLoad + weight) <= MaxLoad*0.5)
            {
                CurrentLoad += weight;
            }
            else
            {
                NotifyDangerousSituation(ContainerNumber);
            }
        }
        else
        {
            if ((CurrentLoad + weight) <= MaxLoad*0.9)
            {
                CurrentLoad += weight;
            }
            else
            {
                NotifyDangerousSituation(ContainerNumber);
            }
            
        }
        
    }

   

    public override string ToString()
    {
        return "Kontenr typu L nr:"+ ContainerNumber + " o wysokość-" + Height + ",głębkokości-" + Height
               + ",przewożący " + currentLiquid+ " o wadze " + CurrentLoad + " i wadze maksymalnej " + MaxLoad;
    }
 

}