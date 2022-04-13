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
    private GameObject SelectCards;     // J : ������ â
    [SerializeField]
    private List<Button> selectButtons; // J : ������ ��ư ����Ʈ
    [SerializeField]
    Color lightColor;    // J : ���õ��� ���� ��ư ����
    [SerializeField]
    Color darkColor; // J : ���õ� ��ư ����
    ColorBlock cb;
    
    private bool isSelectActivated = false; // J : ������ Ȱ��ȭ ����
    private int idx = 0;

    private void Start()
    {
        talkText.text = GameData.encounterAnimal.animalName + "(��)�� �����ƴ�!";    // J : ����ģ ������ ���� �ؽ�Ʈ ����
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
            SelectCards.SetActive(true);    // J : ������ â Ȱ��ȭ
        }
    }

    // J : ������ ���� �õ�
    private void TrySelectOther()
    {
        if (isSelectActivated)  // J : ������ Ȱ��ȭ ����
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // J : ��ư ���
                cb = selectButtons[idx].colors;
                cb.normalColor = lightColor;
                selectButtons[idx--].colors = cb;

                if (idx < 0)
                    idx += selectButtons.Count;

                // J : ��ư ��Ӱ�
                cb = selectButtons[idx].colors;
                cb.normalColor = darkColor;
                selectButtons[idx].colors = cb;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // J : ��ư ���
                cb = selectButtons[idx].colors;
                cb.normalColor = lightColor;
                selectButtons[idx++].colors = cb;

                if (idx == selectButtons.Count)
                    idx = 0;

                // J : ��ư ��Ӱ�
                cb = selectButtons[idx].colors;
                cb.normalColor = darkColor;
                selectButtons[idx].colors = cb;
            }
        }      
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                // J : ��ư ��Ӱ�
                cb = selectButtons[idx].colors;
                cb.normalColor = darkColor;
                selectButtons[idx].colors = cb;

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
            selectButtons[idx].onClick.Invoke();    // J : ���� �������� ��ư�� onclick �Լ� ȣ��
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
