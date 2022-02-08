using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float dayLength;  // N : 하루가 몇초인지

    private int day = 0;                        // N : 현재 날짜 (1일 = day_length)
    private float dayTime = 0;                  // N : 하루 중 현재 시간 (초)

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (true) dayTime += Time.deltaTime;    // N : 특정 조건에서 시간 정지
        if (dayTime >= dayLength)
        {
            dayTime = 0;
            dayAfter();
        }
    }

    // N : 날짜 변화
    public void dayAfter()
    {
        day++;

        // N : 날짜에 따른 스탯 변화 등 작성
    }
}
