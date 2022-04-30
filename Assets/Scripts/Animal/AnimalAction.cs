using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAction : MonoBehaviour
{
    public Animal animal;
    [SerializeField]
    private string sound;

    public void MakeSound()
    {
        Debug.Log(sound);
    }
}
