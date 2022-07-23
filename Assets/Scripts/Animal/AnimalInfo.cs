using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalInfo
{
    public string species;      // J : ���� ������ �̸�
    public int satiety;         // J : ������
    public Level growth;        // N : ���嵵
    public Level intimacy;      // N : ģ�е�

    public AnimalInfo(string _species)
    {
        species = _species;
        satiety = 0;
        growth = new Level(1, 5, 10f, 1f);
        intimacy = new Level(1, 5, 10f, 1f);
    }

    public AnimalInfo(IDictionary animal, IDictionary _growth, IDictionary _intimacy)
    {
        species = (string)animal["species"];
        satiety = Convert.ToInt32(animal["satiety"]);
        growth = new Level(Convert.ToInt32(_growth["CurrLv"]), Convert.ToInt32(_growth["CurrExp"]), 5, 10f, 1f);
        intimacy = new Level(Convert.ToInt32(_intimacy["CurrLv"]), Convert.ToInt32(_intimacy["CurrExp"]), 5, 10f, 1f);
    }
}
