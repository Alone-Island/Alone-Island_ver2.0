using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://luv-n-interest.tistory.com/794
public class DataManager : MonoBehaviour
{
    private Object gameDataRef;

    private void Awake()
    {
        gameDataRef = Resources.Load("Prefabs/GameData");

        if (GameData.data == null)
        {
            Instantiate(gameDataRef);
        }
        Destroy(gameObject);
    }
}
