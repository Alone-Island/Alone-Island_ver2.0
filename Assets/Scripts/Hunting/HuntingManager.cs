using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // J : TextMeshPro

public class HuntingManager : MonoBehaviour
{
    [SerializeField]
    private TimingBar theTimingBar;

    [SerializeField]
    private TextMeshProUGUI judgementText;  // J : SUCCESS / FAIL �ؽ�Ʈ
    [SerializeField]
    private Vector4 successTextColor;   // J : ���� �� �ؽ�Ʈ ����
    [SerializeField]
    private Vector4 failTextColor;  // J : ���� �� �ؽ�Ʈ ����

    private bool isSuccess; // J : Ÿ�ֹ̹� ���� ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // J : ȭ��ǥ�� �����̴� �߿� �����̽��ٸ� ���� ���
        if (theTimingBar.moveActivated && Input.GetKeyDown(KeyCode.Space))
        {
            isSuccess = theTimingBar.Stop();    // J : ȭ��ǥ�� ���� ���� ���θ� �޾ƿ�
            SetText();
        }
    }

    // J : ���� ���ο� ���� ��� �ؽ�Ʈ ����
    private void SetText()
    {
        if (judgementText != null)
        {
            if (isSuccess)  // J : SUCCESS �ؽ�Ʈ
            {
                judgementText.text = "SUCCESS";
                judgementText.color = successTextColor;
            }
            else    // J : FAIL �ؽ�Ʈ
            {
                judgementText.text = "FAIL";
                judgementText.color = failTextColor;
            }
        }
        StartCoroutine("ShowText");
    }

    // J : https://hyunity3d.tistory.com/410
    // J : ��� �ؽ�Ʈ�� Ŀ���ٰ� �����
    IEnumerator ShowText()
    {
        // J : ���� ũ�� ����
        for (int i = 0; i <= 50; i++)
        {
            judgementText.fontSize = i;
            yield return new WaitForFixedUpdate();
        }

        // J : ���� ���� ����
        for (float a = 1; a >= 0; a -= 0.01f)
        {
            judgementText.color = new Vector4(judgementText.color.r, judgementText.color.g, judgementText.color.b, a);
            yield return new WaitForFixedUpdate();
        }
    }
}
