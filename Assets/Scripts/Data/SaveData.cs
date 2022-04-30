using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// J : 게임이 끝나면 저장할 데이터
[Serializable]  // J : 직렬화된 Data
public class SaveData
{
    public int test;

    public SaveData() { }
    public SaveData(TemporaryData temporaryData)
    {
        test = temporaryData.test;
    }
}
