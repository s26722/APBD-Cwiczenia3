namespace APBD_Zadanie3.Models;

public abstract class Container 


{
    private static int serialNumber  = 1;
    public string ContainerNumber { get; }
    public double MaxLoad { get; }
    public double CurrentLoad { get;  set; }
    public double TareWeight { get; }
    public double Height { get; }
    public double Depth { get; }

    protected Container(string containerType, double tareWeight, double height, double depth,double maxLoad)
    {
        ContainerNumber = GenerateContainerNumber(containerType);
        TareWeight = tareWeight;
        Height = height;
        Depth = depth;
        MaxLoad = maxLoad; 
    }

    private string GenerateContainerNumber(string containerType)
    {
        serialNumber++;
        return $"KON-{containerType}-{serialNumber}";
    }

    public void LoadCargo(double weight)
    {
        if (CurrentLoad + weight > MaxLoad)
        {
            throw new OverfillException($"Przekroczono maksymalną ładowność kontenera {ContainerNumber}");
        }

        CurrentLoad += weight;


    }

    public void UnloadCargo()
    {
        CurrentLoad = 0;
    }

   
}

