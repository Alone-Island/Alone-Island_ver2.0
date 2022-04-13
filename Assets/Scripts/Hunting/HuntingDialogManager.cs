using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // J : Button
using UnityEngine.SceneManagement;
using TMPro;    // J : TextMeshPro

public class HuntingDialogManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI talkText;
    [SerializeField]
    private GameObject SelectCards;     // J : 선택지 창
    [SerializeField]
    private List<Button> selectButtons; // J : 선택지 버튼 리스트
    [SerializeField]
    Color lightColor;    // J : 선택되지 않은 버튼 색상
    [SerializeField]
    Color darkColor; // J : 선택된 버튼 색상
    ColorBlock cb;
    
    private bool isSelectActivated = false; // J : 선택지 활성화 여부
    private int idx = 0;

    private void Start()
    {
        talkText.text = GameData.encounterAnimal.animalName + "(을)를 마주쳤다!";    // J : 마주친 동물에 따른 텍스트 변경
    }

    // Update is called once per frame
    void Update()
    {
        TrySelect();        // J : 선택
        TrySelectActive();  // J : 선택지 창 활성화
        TrySelectOther();   // J : 선택지 변경
    }

    // J : 선택지 창 활성화 시도
    private void TrySelectActive()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectCards.SetActive(true);    // J : 선택지 창 활성화
        }
    }

    // J : 선택지 변경 시도
    private void TrySelectOther()
    {
        if (isSelectActivated)  // J : 선택지 활성화 상태
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // J : 버튼 밝게
                cb = selectButtons[idx].colors;
                cb.normalColor = lightColor;
                selectButtons[idx--].colors = cb;

                if (idx < 0)
                    idx += selectButtons.Count;

                // J : 버튼 어둡게
                cb = selectButtons[idx].colors;
                cb.normalColor = darkColor;
                selectButtons[idx].colors = cb;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // J : 버튼 밝게
                cb = selectButtons[idx].colors;
                cb.normalColor = lightColor;
                selectButtons[idx++].colors = cb;

                if (idx == selectButtons.Count)
                    idx = 0;

                // J : 버튼 어둡게
                cb = selectButtons[idx].colors;
                cb.normalColor = darkColor;
                selectButtons[idx].colors = cb;
            }
        }      
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                // J : 버튼 어둡게
                cb = selectButtons[idx].colors;
                cb.normalColor = darkColor;
                selectButtons[idx].colors = cb;

                isSelectActivated = true;
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

    // J : 사냥하기 선택 시 호출
    public void Hunt()
    {
        Debug.Log("사냥하자!");
        SceneManager.LoadScene("Hunting");
    }

    // J : 길들이기 선택 시 호출
    public void Rear()
    {
        Debug.Log("길들이자!");
        SceneManager.LoadScene("Rear");
    }

    // J : 도망가기 선택 시 호출
    public void Run()
    {
        Debug.Log("도망가자!");
        SceneManager.LoadScene("TestJ_hunt");
    }
}
