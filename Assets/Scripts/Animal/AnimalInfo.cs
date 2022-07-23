using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInfo
{
    public string species;      // J : 동물 프리팹 이름
    public int satiety;         // J : 포만감
    public Level growth;        // N : 성장도
    public Level intimacy;      // N : 친밀도

    public AnimalInfo(string _species)
    {
        species = _species;
        satiety = 0;
        growth = new Level(1, 5, 10f, 1f);
        intimacy = new Level(1, 5, 10f, 1f);
    }

    public AnimalInfo(IDictionary dict, IDictionary _growth, IDictionary _intimacy)
    {
        species = (string)dict["species"];
        satiety = Convert.ToInt32(dict["satiety"]);
        growth = new Level(Convert.ToInt32(_growth["CurrLv"]), 5, 10f, 1f);
        intimacy = new Level(Convert.ToInt32(_intimacy["CurrLv"]), 5, 10f, 1f);
    }
}
