using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://namwhis.tistory.com/entry/Unity%EC%9C%A0%EB%8B%88%ED%8B%B0-%EC%A0%95%EB%A6%AC-04-%EC%A2%8C%EC%9A%B0%EC%9D%B4%EB%8F%99-%EB%AC%B4%ED%95%9C%EB%B0%98%EB%B3%B5-TimedeltaTime-Timetime-MathfSin
public class TimingBar : MonoBehaviour
{
    Vector3 pos; //������ġ
    float delta; // �¿�� �̵� ������ x�� �ִ밪
    float[] successRange; // J : ���� ����

    public bool moveActivated = true;  // J : ȭ��ǥ�� �����̴� ������

    [SerializeField]
    float speed; // �̵��ӵ�
    [SerializeField]
    private Transform Arrow;    // J : ȭ��ǥ
    [SerializeField]
    private GameObject Bar;    // J : ��

    // Start is called before the first frame update
    void Start()
    {
        pos = Arrow.position;   // J : ȭ��ǥ�� ��ġ ������
        delta = Bar.GetComponent<RectTransform>().rect.width / 2;   // J : �� �ʺ��� ���� �̵� ������ x�� �ִ밪
        DecideSuccessRange();   // J : Ÿ�̹� ���� ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        if (moveActivated)
            Move();
    }

    // J : Ÿ�̹� ���� ���� ����
    void DecideSuccessRange()
    {
        Transform successBar = Bar.transform.Find("Success Bar").transform;

        // J : ���� ���� �������� ����
        float div = Random.Range(3, 6);
        float position = Random.Range(delta / div - delta, delta - delta / div);    // J : ���� ���� �߾Ӱ�
        successRange = new float[] { position - delta / div, position + delta / div };  // J : ���� ���� ����

        // J : ȭ�鿡 ǥ��
        successBar.localPosition = new Vector3(position, successBar.localPosition.y, successBar.localPosition.z);  // J : ���� ��ġ ����
        successBar.localScale = new Vector3(successBar.localScale.x / div, successBar.localScale.y, 0); // J : ���� ���� ����
    }

    private void Move()
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);    // J : x�� ���� : [-delta, delta]
        Arrow.position = v;
    }

    public void Stop()
    {
        moveActivated = false;  // J : ȭ��ǥ ���߱�

        // J : ���� ���� ������ ���߸�
        if (successRange[0] <= Arrow.localPosition.x && Arrow.localPosition.x <= successRange[1])
        {
            Debug.Log("Success");
        }
        else
        {
            Debug.Log("Fail");
        }
    }
}
