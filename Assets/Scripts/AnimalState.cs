using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalState : MonoBehaviour
{
    // 동물 속성
    private Level growth = new(1, 1, 100, 1);   // N : 성장
    private Level intimacy = new(1, 1, 100, 1); // N : 친밀

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
