using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntingManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // J : 사냥하자! 선택 시 호출
    public void Hunt()
    {
        Debug.Log("사냥하자!");
    }

    // J : 길들이자! 선택 시 호출
    public void Rear()
    {
        Debug.Log("길들이자!");
    }

    // J : 도망가자! 선택 시 호출
    public void Run()
    {
        Debug.Log("도망가자!");
    }
}
