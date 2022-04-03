using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // J : TextMeshPro

// https://namwhis.tistory.com/entry/Unity%EC%9C%A0%EB%8B%88%ED%8B%B0-%EC%A0%95%EB%A6%AC-04-%EC%A2%8C%EC%9A%B0%EC%9D%B4%EB%8F%99-%EB%AC%B4%ED%95%9C%EB%B0%98%EB%B3%B5-TimedeltaTime-Timetime-MathfSin
public class TimingBar : MonoBehaviour
{
    private Vector3 pos; // J : 처음 화살표 위치
    private float delta; // J : 좌우로 이동 가능한 x의 최대값
    private float[] successRange; // J : 적중 간격
    [SerializeField]
    private float speed; // J : 화살표 이동 속도

    public bool isSuccess; // J : 적중 여부
    public bool moveActivated = true;  // J : 화살표가 움직이는 중인지

    // J : 필요한 컴포넌트
    [SerializeField]
    private Transform Arrow;    // J : 화살표
    [SerializeField]
    private GameObject Bar;    // J : 바
    [SerializeField]
    private TextMeshProUGUI judgementText;  // J : SUCCESS / FAIL 텍스트

    // Start is called before the first frame update
    void Start()
    {
        pos = Arrow.position;   // J : 화살표의 위치 가져옴
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
    void DecideSuccessRange()
    {
        Transform successBar = Bar.transform.Find("Success Bar").transform;

        // J : 적중 범위 랜덤으로 결정
        float div = Random.Range(3, 6);
        float position = Random.Range(delta / div - delta, delta - delta / div);    // J : 적중 범위 중앙값
        successRange = new float[] { position - delta / div, position + delta / div };  // J : 적중 범위 결정

        // J : 화면에 표시
        successBar.localPosition = new Vector3(position, successBar.localPosition.y, successBar.localPosition.z);  // J : 적중 위치 설정
        successBar.localScale = new Vector3(successBar.localScale.x / div, successBar.localScale.y, 0); // J : 적중 간격 설정
    }

    // J : 화살표가 좌우로 이동
    private void Move()
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);    // J : x의 범위 : [-delta, delta]
        Arrow.position = v;
    }

    public void Stop()
    {
        moveActivated = false;  // J : 화살표 멈추기

        // J : 적중 범위 내에서 멈추면 성공
        if (successRange[0] <= Arrow.localPosition.x && Arrow.localPosition.x <= successRange[1])
        {
            Debug.Log("Hit Success");
            isSuccess = true;

            // J : SUCCESS 텍스트 표시
            if (judgementText != null)
                StartCoroutine("ShowSuccess");
        }
        else // J : 실패
        {
            Debug.Log("Hit Fail");
            isSuccess = false;

            // J : FAIL 텍스트 표시
            if (judgementText != null) 
                StartCoroutine("ShowFail");
        }
    }

    // J : https://hyunity3d.tistory.com/410
    // J : SUCCESS 텍스트 표시
    IEnumerator ShowSuccess()
    {
        judgementText.text = "SUCCESS";
        judgementText.color = new Vector4(0, 1, 0.5f, 1);

        // J : 글자 크기 변경
        for (int i = 0; i <= 50; i++)
        {
            judgementText.fontSize = i;
            yield return new WaitForFixedUpdate();
        }

        // J : 글자 투명도 변경
        for (float a = 1; a >= 0; a-=0.01f)
        {
            judgementText.color = new Vector4(0, 1, 0.5f, a);
            yield return new WaitForFixedUpdate();
        }
    }

    // J : FAIL 텍스트 표시
    IEnumerator ShowFail()
    {
        judgementText.text = "FAIL";
        judgementText.color = new Vector4(1, 0, 0, 1);

        // J : 글자 크기 변경
        for (int i = 0; i <= 50; i++)
        {
            judgementText.fontSize = i;
            yield return new WaitForFixedUpdate();
        }

        // J : 글자 투명도 변경
        for (float a = 1; a >= 0; a -= 0.01f)
        {
            judgementText.color = new Vector4(1, 0, 0, a);
            yield return new WaitForFixedUpdate();
        }
    }
}
