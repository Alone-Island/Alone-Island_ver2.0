using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/building")]
public class BuildingItem : Item
{
    public enum BuildingType
    {
        Fence,
        Barn,
        RobotHouse,
    }
    public BuildingItem buildingType;
}
