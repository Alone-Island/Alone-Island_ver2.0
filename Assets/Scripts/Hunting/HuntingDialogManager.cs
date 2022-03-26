using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // J : Button
using TMPro;    // J : TextMeshPro

public class HuntingDialogManager : MonoBehaviour
{
    [SerializeField]
    private GameObject SelectPanel;     // J : 선택지 창
    [SerializeField]
    private List<TextMeshProUGUI> selectTexts;  // J : 선택지 텍스트 리스트
    [SerializeField]
    private List<Button> selectButtons; // J : 선택지 버튼 리스트

    private bool isSelectActivated = false; // J : 선택지 활성화 여부
    private int idx = 0;

    // Update is called once per frame
    void Update()
    {
        TrySelectActive();  // J : 선택지 창 활성화
        TrySelectOther();   // J : 선택지 변경
        TrySelect();        // J : 선택
    }

    // J : 선택지 창 활성화 시도
    private void TrySelectActive()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectPanel.SetActive(true);    // J : 선택지 창 활성화
            isSelectActivated = true;
            selectTexts[idx].fontStyle = FontStyles.Underline;   // J : 첫번째 선택지 밑줄 적용
        }
    }

    // J : 선택지 변경 시도
    private void TrySelectOther()
    {
        if (isSelectActivated)  // J : 선택지 활성화 상태
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // J : 밑줄 해제
                selectTexts[idx--].fontStyle = FontStyles.Normal;

                if (idx < 0)
                    idx += selectTexts.Count;

                // J : 밑줄 적용
                selectTexts[idx].fontStyle = FontStyles.Underline;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // J : 밑줄 해제
                selectTexts[idx++].fontStyle = FontStyles.Normal;

                if (idx == selectTexts.Count)
                    idx = 0;

                // J : 밑줄 적용
                selectTexts[idx].fontStyle = FontStyles.Underline;
            }
        }        
    }

    // J : 선택 시도
    private void TrySelect()
    {
        // J : 선택지 창 활성화 상태일 때 스페이스바를 누르면
        if (Input.GetKeyDown(KeyCode.Space) && isSelectActivated)
        {
            selectButtons[idx].onClick.Invoke();    // J : 현재 선택중인 버튼의 onclick 함수 호출
        }
    }
}
