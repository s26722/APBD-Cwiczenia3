namespace APBD_Zadanie3.Models;
using System;
using System.Collections.Generic;
using System.Text;

public class Ship
{
    private static int seriesNum = 0;
    public string shipNum { get; }
    public List<Container> Containers { get; set; }
    public double maxSpeed { get; }
    public int maxContainerCount { get; }
    public double maxTotalWeight { get; }
    public double CurrentWeight { get; set; }

    public Ship(double speed, int MaxContainerCount, double MaxTotalWeight)
    {
        shipNum = GenerateShipNumber();
        maxSpeed = speed;
        maxContainerCount = MaxContainerCount;
        maxTotalWeight = MaxTotalWeight;
        Containers = new List<Container>();
        CurrentWeight = 0;
    }

    private string GenerateShipNumber()
    {
        seriesNum++;
        return $"Ship-{seriesNum}";
    }
    public void LoadContainer(Container container)
    {
        if (Containers.Count >= maxContainerCount)
        {
            throw new InvalidOperationException("Przekroczono maksymalną liczbę kontenerów.");
        }

        if (CurrentWeight + container.CurrentLoad + container.TareWeight > maxTotalWeight)
        {
            throw new InvalidOperationException("Przekroczono maksymalną wagę wszystkich kontenerów.");
        }





        Containers.Add(container);
        CurrentWeight += (container.CurrentLoad + container.TareWeight);
    }

    public void LoadContainerList(List<Container> containersList)
    {

        foreach (Container container in containersList)
        {


            if (Containers.Count >= maxContainerCount)
            {
                throw new InvalidOperationException("Przekroczono maksymalną liczbę kontenerów.");
            }

            if (CurrentWeight + container.CurrentLoad + container.TareWeight > maxTotalWeight)
            {
                throw new InvalidOperationException("Przekroczono maksymalną wagę wszystkich kontenerów.");
            }





            Containers.Add(container);
            CurrentWeight += (container.CurrentLoad + container.TareWeight);
        }
    }

    public void ContainerUnload(string containerNumber)
    {
        foreach (Container container in Containers)
        {
            if (container.ContainerNumber.Equals(containerNumber))
            {
                Containers.Remove(container);
                Console.WriteLine("Kontener " + container.ContainerNumber + " został usunięty z statku ");
            }

        }
    }

    public void ContainerUnloadAll()
    {
        Containers.Clear();
    }

    public void SwapContainer(string containerNumber, Container newContainer)
    {
        try
        {
            for (int i = 0; i < Containers.Count; i++)
            {
                if (Containers[i].ContainerNumber.Equals(containerNumber))
                {
                    Containers.Remove(Containers[i]);
                    Containers.Add(newContainer);
                    Console.WriteLine("Kontener " + Containers[i].ContainerNumber +
                                      " został usunięty z statku, w zamian za kontener "
                                      + newContainer.ContainerNumber);




                }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void ChangeContainerShip(string containerNumber, Ship newShip)
    {
        for (int i=0;i<Containers.Count;i++)
        {
            if (Containers[i].ContainerNumber.Equals(containerNumber))
            {
                try
                {
                    newShip.LoadContainer(Containers[i]);
                    Containers.Remove(Containers[i]);
                    Console.WriteLine("Kontener "+Containers[i].ContainerNumber+" został przeniesiony do statku " + newShip.shipNum);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

               

            }
        }



    }

    public override string ToString()
    {
        return "Statek nr " + shipNum + " osiąga prędkość " + maxSpeed + " i może przenosić maksymalnie " +
               maxContainerCount + " kontenerów o łącznej wadze " + maxTotalWeight + " na ten moment waga wynosi " + CurrentWeight
                + " a na statku znajdują się następujące kontnery: "+"\n"  + WypiszListe(Containers) ;
    }
    
    public static string WypiszListe<T>(List<T> lista)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (var element in lista)
        {
            stringBuilder.AppendLine(element.ToString());
        }

        return stringBuilder.ToString();
    }

}
    

