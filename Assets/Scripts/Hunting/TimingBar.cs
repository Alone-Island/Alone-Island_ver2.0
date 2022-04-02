using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://namwhis.tistory.com/entry/Unity%EC%9C%A0%EB%8B%88%ED%8B%B0-%EC%A0%95%EB%A6%AC-04-%EC%A2%8C%EC%9A%B0%EC%9D%B4%EB%8F%99-%EB%AC%B4%ED%95%9C%EB%B0%98%EB%B3%B5-TimedeltaTime-Timetime-MathfSin
public class TimingBar : MonoBehaviour
{
    Vector3 pos; //현재위치
    float delta; // 좌우로 이동 가능한 x의 최대값

    [SerializeField]
    float speed; // 이동속도
    [SerializeField]
    private Transform Arrow;    // J : 화살표
    [SerializeField]
    private GameObject Bar;    // J : 바

    // Start is called before the first frame update
    void Start()
    {
        pos = Arrow.position;   // J : 화살표의 위치 가져옴
        delta = Bar.GetComponent<RectTransform>().rect.width / 2;   // J : 바 너비의 반이 이동 가능한 x의 최대값
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);    // J : x의 범위 : [-delta, delta]
        Arrow.position = v;
    }
}
