using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalState : MonoBehaviour
{
    // N: 동물 속성
    private Level growth = new Level(1, 1, 100f, 1f);   // N : 성장
    private Level intimacy = new Level(1, 1, 100f, 1f); // N : 친밀

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
