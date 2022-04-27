using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryData : MonoBehaviour
{
    // J : 게임 실행 중에만 유지할 데이터
    public static Animal encounterAnimal;

    private void Awake()
    {
        // J : TemporaryData 오브젝트의 중복 생성 방지
        var obj = FindObjectsOfType<TemporaryData>();
        if (obj.Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
}
