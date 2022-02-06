using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D playerRigid;    // C : player�� ����������� ����
    private float h;                    // C : player�� �����̵� ���� �ޱ� ���� ����
    private float v;                    // C : player�� �����̵� ���� �ޱ� ���� ����
    private bool isHorizonMove;         // C : player�� �����̵��� ���� bool���� �����ϱ� ���� ����

    [SerializeField]
    private float speed = 5;            // C : player�� �̵� �ӷ� ���� �����ϱ� ���� ����

    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();      // C : player 2D �������� component instance ����
    }

    void Update()
    {
        // C : Ű���� ����Ű�� ����/���� �Է� �� �ޱ�
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // C : �� Ű���� ����Ű up/down �� ����/���� Ȯ���ؼ� ������ bool�� ����
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        // C : isHorizontalMove �� ����
        // C : �����̵� ���� - ���� ����Ű ���� �� true, ���� ����Ű �� �� true
        //     (���� ����Ű ���� ��, ���� ����Ű�� �Բ� �����ٰ� ���� ����Ű�� ���� �� ���
        //      ������ �ִ� ���� ����Ű ����� �����̱� ���� vUp�� ����ؾ� ��)
        if (hDown || vUp)               // C : �����̵� ���
            isHorizonMove = true;
        else if (vDown || hUp)          // C : �����̵� ���
            isHorizonMove = false;
    }

    void FixedUpdate()
    {
        // C : playerRigid�� ���� �̵� �� ����
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);    // C : ����/���� �̵��� �����ϵ��� moveVec ����
        playerRigid.velocity = moveVec * speed;                                     // C : playerRigid�� �ӵ�(�ӷ� + ����) ����
    }
}
