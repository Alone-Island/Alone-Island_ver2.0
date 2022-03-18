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
        Debug.Log(animalName + "�� ���� : -" + offensivePower);
    }

    public abstract void MakeSound();
}
