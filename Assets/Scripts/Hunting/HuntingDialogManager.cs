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
    private List<TextMeshProUGUI> selectTexts;  // J : ������ �ؽ�Ʈ ����Ʈ
    [SerializeField]
    private List<Button> selectButtons; // J : ������ ��ư ����Ʈ

    private bool isSelectActivated = false; // J : ������ Ȱ��ȭ ����
    private int idx = 0;

    // Update is called once per frame
    void Update()
    {
        TrySelectActive();  // J : ������ â Ȱ��ȭ
        TrySelectOther();   // J : ������ ����
        TrySelect();        // J : ����
    }

    // J : ������ â Ȱ��ȭ �õ�
    private void TrySelectActive()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SelectPanel.SetActive(true);    // J : ������ â Ȱ��ȭ
            isSelectActivated = true;
            selectTexts[idx].fontStyle = FontStyles.Underline;   // J : ù��° ������ ���� ����
        }
    }

    // J : ������ ���� �õ�
    private void TrySelectOther()
    {
        if (isSelectActivated)  // J : ������ Ȱ��ȭ ����
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // J : ���� ����
                selectTexts[idx--].fontStyle = FontStyles.Normal;

                if (idx < 0)
                    idx += selectTexts.Count;

                // J : ���� ����
                selectTexts[idx].fontStyle = FontStyles.Underline;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // J : ���� ����
                selectTexts[idx++].fontStyle = FontStyles.Normal;

                if (idx == selectTexts.Count)
                    idx = 0;

                // J : ���� ����
                selectTexts[idx].fontStyle = FontStyles.Underline;
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
