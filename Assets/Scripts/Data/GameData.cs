using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]  // J : ����ȭ�� Data
public class GameData
{
    // J : ���� ���� �߿��� ������ ������
    public Animal encounterAnimal;

    // J : ������ ������
    public List<AnimalInfo> animalInfoList = new List<AnimalInfo>();
}
