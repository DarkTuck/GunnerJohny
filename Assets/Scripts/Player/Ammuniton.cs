using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public enum AmmunitonType
{
    Bullets,
    Shells,
    Rockets,
    EnergyCell
};
[CreateAssetMenu(fileName = "Ammuniton", menuName = "Scriptable Objects/Ammuniton")]
public class Ammuniton : ScriptableObject
{

    [SerializeField][Foldout("StartingValues")]int bullets, shells, rockets, energyCell, maxBullets, maxShells, maxRockets, maxEnergyCells;
    [SerializeField][Foldout("Events")]IntEvent bulletsEvent, shellsEvent, rocketsEvent, energyCellEvent, maxBulletsEvent, maxShellsEvent, maxRocketsEvent, maxEnergyCell;

    public Dictionary<AmmunitonType, IntEvent> Ammunitons;
    public Dictionary<AmmunitonType, IntEvent> MaxAmmunitons;

    public void InitializeAmmunitons()
    {
        bulletsEvent.IntValue = bullets;
        shellsEvent.IntValue = shells;
        rocketsEvent.IntValue = rockets;
        energyCellEvent.IntValue = energyCell;
        maxBulletsEvent.IntValue = maxBullets;
        maxShellsEvent.IntValue = maxShells;
        maxRocketsEvent.IntValue = maxRockets;
        maxEnergyCell.IntValue = maxEnergyCells;
        Ammunitons = new Dictionary<AmmunitonType, IntEvent>()
        {
            { AmmunitonType.Bullets, bulletsEvent },
            { AmmunitonType.Shells, shellsEvent },
            { AmmunitonType.Rockets, rocketsEvent },
            { AmmunitonType.EnergyCell, energyCellEvent }
        };
        MaxAmmunitons = new Dictionary<AmmunitonType, IntEvent>()
        {
            { AmmunitonType.Bullets, maxBulletsEvent },
            { AmmunitonType.Shells, maxShellsEvent },
            { AmmunitonType.Rockets, maxRocketsEvent },
            { AmmunitonType.EnergyCell, maxEnergyCell }
        };
    }

    public void AddAmmuniton()
    {
        bulletsEvent.IntValue = maxBullets;
        shellsEvent.IntValue = maxShells;
        rocketsEvent.IntValue = maxRockets;
        energyCellEvent.IntValue = maxEnergyCells;
            
    }
}
