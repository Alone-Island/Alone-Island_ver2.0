using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    public string animalName;

    public int hp;
    public int offensivePower;

    public void Attack()
    {
        Debug.Log(animalName + "ÀÇ °ø°Ý : -" + offensivePower);
    }

    public abstract void MakeSound();
}
