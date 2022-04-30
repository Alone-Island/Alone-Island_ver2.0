using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://namwhis.tistory.com/entry/Unity%EC%9C%A0%EB%8B%88%ED%8B%B0-%EC%A0%95%EB%A6%AC-04-%EC%A2%8C%EC%9A%B0%EC%9D%B4%EB%8F%99-%EB%AC%B4%ED%95%9C%EB%B0%98%EB%B3%B5-TimedeltaTime-Timetime-MathfSin
public class TimingBar : MonoBehaviour
{
    private Vector3 pos; // J : 처음 화살표 위치
    private float width;  // J : 바의 너비
    private float delta; // J : 좌우로 이동 가능한 x의 최대값
    private float[] successRange; // J : 적중 간격
    [SerializeField]
    private float speed; // J : 화살표 이동 속도

    public bool moveActivated = true;  // J : 화살표가 움직이는 중인지

    // J : 필요한 컴포넌트
    [SerializeField]
    private Transform Arrow;    // J : 화살표
    [SerializeField]
    private GameObject Bar;    // J : 바

    // Start is called before the first frame update
    void Start()
    {
        pos = Arrow.localPosition;   // J : 화살표의 위치 가져옴
        width = Bar.transform.localScale.x;
        delta = Bar.GetComponent<RectTransform>().rect.width / 2;   // J : 바 너비의 반이 이동 가능한 x의 최대값
        DecideSuccessRange();   // J : 타이밍 적중 범위 결정
    }

    // Update is called once per frame
    void Update()
    {
        if (moveActivated)
            Move(); // J : 화살표가 좌우로 이동
    }

    // J : 타이밍 적중 범위 결정
    public void DecideSuccessRange()
    {
        Transform successBar = Bar.transform.Find("Success Bar").transform;

        // J : 적중 범위 랜덤으로 결정
        float div = Random.Range(3, 6);
        float position = Random.Range(delta / div - delta, delta - delta / div);    // J : 적중 범위 중앙값
        successRange = new float[] { position - delta / div, position + delta / div };  // J : 적중 범위 결정

        // J : 화면에 표시
        successBar.localPosition = new Vector3(position, successBar.localPosition.y, successBar.localPosition.z);  // J : 적중 위치 설정
        successBar.localScale = new Vector3(width / div, successBar.localScale.y, 0); // J : 적중 간격 설정
    }

    // J : 화살표가 좌우로 이동
    private void Move()
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);    // J : x의 범위 : [-delta, delta]
        Arrow.localPosition = v;
    }

    // J : 화살표의 움직임 중지, 적중 여부를 리턴
    public bool Stop()
    {
        moveActivated = false;  // J : 화살표 멈추기

        // J : 적중 범위 내에서 멈추면 성공
        if (successRange[0] <= Arrow.localPosition.x && Arrow.localPosition.x <= successRange[1])
        {
            Debug.Log("Hit Success");
            return true;
        }
        else // J : 실패
        {
            Debug.Log("Hit Fail");
            return false;
        }
    }
}
