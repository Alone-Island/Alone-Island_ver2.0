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
    private GameObject cards;           // J : ������ ī�� ����
    private List<Button> cardList;      // J : ������ ī�� ��ư ������Ʈ ����Ʈ
    private List<Image> cardImageList;  // J : ������ ī�� �̹��� ������Ʈ ����Ʈ
    [SerializeField]
    private List<Sprite> selectCardImageList; // J : ��ư ���� �� �̹��� ����Ʈ
    [SerializeField]
    private List<Sprite> nonSelectCardImageList; // J : ��ư �������� ���� �� �̹��� ����Ʈ
    
    private bool isSelectActivated = false; // J : ������ Ȱ��ȭ ����
    private int idx = 0;

    void Start()
    {
        talkText.text = DataController.Instance.gameData.encounterAnimal.koreanName + "(��)�� �����ƴ�!";    // J : ����ģ ������ ���� �ؽ�Ʈ ����
        cardList = new List<Button>(cards.GetComponentsInChildren<Button>());
        cardImageList = new List<Image>(cards.GetComponentsInChildren<Image>());
    }

    // Update is called once per frame
    void Update()
    {
        TrySelect();        // J : ����
        TrySelectActive();  // J : ������ â Ȱ��ȭ
        TrySelectOther();   // J : ������ ����
    }

    // J : ������ â Ȱ��ȭ �õ�
    private void TrySelectActive()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cards.SetActive(true);    // J : ������ â Ȱ��ȭ
        }
    }

    // J : ������ ���� �õ�
    private void TrySelectOther()
    {
        if (isSelectActivated)  // J : ������ Ȱ��ȭ ����
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
                cardImageList[idx].sprite = selectCardImageList[idx];   // J : ī�� �̹��� ����
                isSelectActivated = true;
            }
        }
    }

    // J : ���� �õ�
    private void TrySelect()
    {
        // J : ������ â Ȱ��ȭ ������ �� �����̽��ٸ� ������
        if (Input.GetKeyDown(KeyCode.Space) && isSelectActivated)
        {
            cardList[idx].onClick.Invoke();    // J : ���� �������� ��ư�� onclick �Լ� ȣ��
        }
    }

    // J : ����ϱ� ���� �� ȣ��
    public void Hunt()
    {
        Debug.Log("�������!");
        SceneManager.LoadScene("Hunting");
    }

    // J : ����̱� ���� �� ȣ��
    public void Rear()
    {
        Debug.Log("�������!");
        SceneManager.LoadScene("Rear");
    }

    // J : �������� ���� �� ȣ��
    public void Run()
    {
        Debug.Log("��������!");
        SceneManager.LoadScene("TestJ_hunt");
    }
}
