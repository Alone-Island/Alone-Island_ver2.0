using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // J : 게임 실행 중에만 유지할 데이터
    public static Animal encounterAnimal;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
