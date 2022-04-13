using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // J : ���� ���� �߿��� ������ ������
    public static Animal encounterAnimal;

    private void Awake()
    {
        // J : GameData ������Ʈ�� �ߺ� ���� ����
        var obj = FindObjectsOfType<GameData>();
        if (obj.Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
}
