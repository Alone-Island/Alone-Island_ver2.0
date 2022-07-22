using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// J : 게임 실행 중에만 유지할 데이터
[Serializable]  // J : 직렬화된 Data
public class TemporaryData : SaveData
{
    public int test2 = 0;
    public Animal encounterAnimal;

    public List<AnimalInfo> animalInfoList = new List<AnimalInfo>();

    private void Awake()
    {
        /*
        // J : TemporaryData 오브젝트의 중복 생성 방지
        var obj = FindObjectsOfType<TemporaryData>();
        if (obj.Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
        */
    }
}
