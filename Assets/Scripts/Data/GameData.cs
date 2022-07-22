using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]  // J : 직렬화된 Data
public class GameData
{
    // J : 게임 실행 중에만 유지할 데이터
    public Animal encounterAnimal;

    // J : 저장할 데이터
    public List<AnimalInfo> animalInfoList = new List<AnimalInfo>();
}
