using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // J : ���� ���� �߿��� ������ ������
    public static Animal encounterAnimal;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
