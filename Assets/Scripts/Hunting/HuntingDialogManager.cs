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
    private GameObject cards;           // J : 선택지 카드 모음
    private List<Button> cardList;      // J : 선택지 카드 버튼 컴포넌트 리스트
    private List<Image> cardImageList;  // J : 선택지 카드 이미지 컴포넌트 리스트
    [SerializeField]
    private List<Sprite> selectCardImageList; // J : 버튼 선택 시 이미지 리스트
    [SerializeField]
    private List<Sprite> nonSelectCardImageList; // J : 버튼 선택하지 않을 시 이미지 리스트
    
    private bool isSelectActivated = false; // J : 선택지 활성화 여부
    private int idx = 0;

    void Start()
    {
        talkText.text = DataController.Instance.gameData.encounterAnimal.koreanName + "(을)를 마주쳤다!";    // J : 마주친 동물에 따른 텍스트 변경
        cardList = new List<Button>(cards.GetComponentsInChildren<Button>());
        cardImageList = new List<Image>(cards.GetComponentsInChildren<Image>());
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
            cards.SetActive(true);    // J : 선택지 창 활성화
        }
    }

    // J : 선택지 변경 시도
    private void TrySelectOther()
    {
        if (isSelectActivated)  // J : 선택지 활성화 상태
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                cardImageList[idx].sprite = nonSelectCardImageList[idx];

                idx--;

                if (idx < 0)
                    idx += cardList.Count;

                cardImageList[idx].sprite = selectCardImageList[idx];
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                cardImageList[idx].sprite = nonSelectCardImageList[idx];

                idx++;

                if (idx == cardList.Count)
                    idx = 0;

                cardImageList[idx].sprite = selectCardImageList[idx];
            }
        }      
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {                
                cardImageList[idx].sprite = selectCardImageList[idx];   // J : 카드 이미지 변경
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
            cardList[idx].onClick.Invoke();    // J : 현재 선택중인 버튼의 onclick 함수 호출
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
