using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInfo
{
    public string species;    // J : 동물 프리팹 이름
    public int satiety;   // J : 포만감
    public int happiness;  // J : 행복도

    public AnimalInfo(string _species, int _satiety, int _happiness)
    {
        species = _species;
        satiety = _satiety;
        happiness = _happiness;
    }

    public AnimalInfo(IDictionary dict)
    {
        species = (string)dict["species"];
        satiety = Convert.ToInt32(dict["satiety"]);
        happiness = Convert.ToInt32(dict["happiness"]);
    }
}
