using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://luv-n-interest.tistory.com/794
public class GameData : MonoBehaviour
{
    public static GameData data;

    public Animal encounterAnimal;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (data == null)
        {
            data = this;
        }
        else if (data != this)
        {
            Destroy(gameObject);
        }
    }
}
