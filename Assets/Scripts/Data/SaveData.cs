using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// J : ������ ������ ������ ������
[Serializable]  // J : ����ȭ�� Data
public class SaveData
{
    public int test;

    public SaveData() { }
    public SaveData(TemporaryData temporaryData)
    {
        test = temporaryData.test;
    }
}
