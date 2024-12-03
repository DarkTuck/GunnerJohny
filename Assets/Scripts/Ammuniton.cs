using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ammuniton", menuName = "Scriptable Objects/Ammuniton")]
public class Ammuniton : ScriptableObject
{
    public enum AmmunitonType
    {
        Bullets,
        Shells,
        Rockets,
        EnergyCell
    };
    [SerializeField]int bullets, shells, rockets, energyCell;

    public Dictionary<AmmunitonType, int> ammunitons;
    public void InitializeAmmunitons()
    {
        ammunitons = new Dictionary<AmmunitonType, int>()
        {
            { AmmunitonType.Bullets, bullets },
            { AmmunitonType.Shells, shells },
            { AmmunitonType.Rockets, rockets },
            { AmmunitonType.EnergyCell, energyCell }
        };
    }

}
