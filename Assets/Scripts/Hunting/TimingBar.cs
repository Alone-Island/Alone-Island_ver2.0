using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://namwhis.tistory.com/entry/Unity%EC%9C%A0%EB%8B%88%ED%8B%B0-%EC%A0%95%EB%A6%AC-04-%EC%A2%8C%EC%9A%B0%EC%9D%B4%EB%8F%99-%EB%AC%B4%ED%95%9C%EB%B0%98%EB%B3%B5-TimedeltaTime-Timetime-MathfSin
public class TimingBar : MonoBehaviour
{
    Vector3 pos; //������ġ
    float delta; // �¿�� �̵� ������ x�� �ִ밪

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
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);    // J : x�� ���� : [-delta, delta]
        Arrow.position = v;
    }
}
