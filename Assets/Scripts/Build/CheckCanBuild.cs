using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCanBuild : MonoBehaviour
{

    private bool checkCanBuild = false;             // C : ������ �� �ִ� ����(�ڸ�)���� üũ�ϴ� ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        // C : ������ �ǹ� ��ġ�� ������ ���
        checkCanBuild = false;              // C : ���� ���� ���θ� false��

        // C : �ǹ��� ���� �� ���� ��Ȳ�̸� buildNo�� SetActive true
        coll.gameObject.transform.Find("BuildNo").gameObject.SetActive(true);
        coll.gameObject.transform.Find("BuildYes").gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        // C : �̹� ������ �ǹ� ��ġ�� ���ִ� ���
        checkCanBuild = false;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        // C : ������ �ǹ� ��ġ�� ������ ���
        checkCanBuild = true;              // C : ���� ���� ���θ� false��

        // C : �ǹ��� ���� �� �ִ� ��Ȳ�̸� buildYes�� SetActive true
        coll.gameObject.transform.Find("BuildNo").gameObject.SetActive(false);
        coll.gameObject.transform.Find("BuildYes").gameObject.SetActive(true);
    }
}
