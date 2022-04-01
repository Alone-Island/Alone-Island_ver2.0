using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // J : Button
using TMPro;    // J : TextMeshPro

public class HuntingDialogManager : MonoBehaviour
{
    [SerializeField]
    private GameObject SelectPanel;     // J : ������ â
    [SerializeField]
    private List<Button> selectButtons; // J : ������ ��ư ����Ʈ
    [SerializeField]
    Color light;    // J : ���õ��� ���� ��ư ����
    [SerializeField]
    Color dark; // J : ���õ� ��ư ����
    ColorBlock cb;
    
    private bool isSelectActivated = false; // J : ������ Ȱ��ȭ ����
    private int idx = 0;

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
            SelectPanel.SetActive(true);    // J : ������ â Ȱ��ȭ
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
                cb.normalColor = light;
                selectButtons[idx--].colors = cb;

                if (idx < 0)
                    idx += selectButtons.Count;

                // J : ��ư ��Ӱ�
                cb = selectButtons[idx].colors;
                cb.normalColor = dark;
                selectButtons[idx].colors = cb;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // J : ��ư ���
                cb = selectButtons[idx].colors;
                cb.normalColor = light;
                selectButtons[idx++].colors = cb;

                if (idx == selectButtons.Count)
                    idx = 0;

                // J : ��ư ��Ӱ�
                cb = selectButtons[idx].colors;
                cb.normalColor = dark;
                selectButtons[idx].colors = cb;
            }
        }      
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                // J : ��ư ��Ӱ�
                cb = selectButtons[idx].colors;
                cb.normalColor = dark;
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
}
