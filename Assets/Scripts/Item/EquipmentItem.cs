using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/equipment")]
public class EquipmentItem : Item
{
    public enum EquipmentType
    {
        Spear,
        Arrow,
        Shovel,
    }
    public EquipmentType weaponType;
}
