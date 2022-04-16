using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/food")]
public class FoodItem : Item
{
    public enum FoodType
    {
        Vegetable,
        Meat,
    }
    public FoodType foodType;
}