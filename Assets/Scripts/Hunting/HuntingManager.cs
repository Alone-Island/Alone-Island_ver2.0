using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // J : TextMeshPro

public class HuntingManager : MonoBehaviour
{
    [SerializeField]
    private TimingBar theTimingBar;

    [SerializeField]
    private TextMeshProUGUI judgementText;  // J : SUCCESS / FAIL 텍스트
    [SerializeField]
    private Vector4 successTextColor;   // J : 성공 시 텍스트 색상
    [SerializeField]
    private Vector4 failTextColor;  // J : 실패 시 텍스트 색상

    private bool isSuccess; // J : 타이밍바 적중 여부

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // J : 화살표가 움직이는 중에 스페이스바를 누른 경우
        if (theTimingBar.moveActivated && Input.GetKeyDown(KeyCode.Space))
        {
            isSuccess = theTimingBar.Stop();    // J : 화살표를 멈춰 적중 여부를 받아옴
            SetText();
        }
    }

    // J : 적중 여부에 따른 결과 텍스트 설정
    private void SetText()
    {
        if (judgementText != null)
        {
            if (isSuccess)  // J : SUCCESS 텍스트
            {
                judgementText.text = "SUCCESS";
                judgementText.color = successTextColor;
            }
            else    // J : FAIL 텍스트
            {
                judgementText.text = "FAIL";
                judgementText.color = failTextColor;
            }
        }
        StartCoroutine("ShowText");
    }

    // J : https://hyunity3d.tistory.com/410
    // J : 결과 텍스트가 커지다가 사라짐
    IEnumerator ShowText()
    {
        // J : 글자 크기 변경
        for (int i = 0; i <= 50; i++)
        {
            judgementText.fontSize = i;
            yield return new WaitForFixedUpdate();
        }

        // J : 글자 투명도 변경
        for (float a = 1; a >= 0; a -= 0.01f)
        {
            judgementText.color = new Vector4(judgementText.color.r, judgementText.color.g, judgementText.color.b, a);
            yield return new WaitForFixedUpdate();
        }
    }
}
