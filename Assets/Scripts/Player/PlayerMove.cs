using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D playerRigid;    // C : player�� ����������� ����
    private Animator playerAnim;        // C : player�� �ִϸ�����
    private float h;                    // C : player�� �����̵� ���� �ޱ� ���� ����
    private float v;                    // C : player�� �����̵� ���� �ޱ� ���� ����
    private bool isHorizonMove;         // C : player�� �����̵��� ���� bool���� �����ϱ� ���� ����
    public Vector2 dirVec;              // J : player�� �ٶ󺸴� ����

    [SerializeField]
    private float speed = 5;            // C : player�� �̵� �ӷ� ���� �����ϱ� ���� ����


    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();      // C : player 2D �������� component instance ��������
        playerAnim = GetComponent<Animator>();          // C : player �ִϸ��̼� ��Ʈ�� component instance ��������
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

        // J : player�� �ٶ󺸴� ����
        if (v == 1)
            dirVec = Vector3.up;
        else if (v == -1)
            dirVec = Vector3.down;
        else if (h == -1)
            dirVec = Vector3.left;
        else if (h == 1)
            dirVec = Vector3.right;

        // C : isHorizontalMove �� ����
        // C : �����̵� ���� - ���� ����Ű ���� �� true, ���� ����Ű �� �� true
        //     (���� ����Ű ���� ��, ���� ����Ű�� �Բ� �����ٰ� ���� ����Ű�� ���� �� ���
        //      ������ �ִ� ���� ����Ű ����� �����̱� ���� vUp�� ����ؾ� ��)
        if (hDown || vUp)               // C : �����̵� ���
            isHorizonMove = true;
        else if (vDown || hUp)          // C : �����̵� ���
            isHorizonMove = false;


        // C : �ִϸ��̼� ����
        // C : ���� ��� ���� �̵� ���� ������ ��, �ڵ� ���� ����
        if (playerAnim.GetInteger("hAxisRaw") != h)
        {
            playerAnim.SetBool("isChange", true);
            playerAnim.SetInteger("hAxisRaw", (int)h);
        }
        else if (playerAnim.GetInteger("vAixsRaw") != v)
        {
            playerAnim.SetBool("isChange", true);
            playerAnim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            playerAnim.SetBool("isChange", false);
        }
    }

    void FixedUpdate()
    {
        // C : playerRigid�� ���� �̵� �� ����
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);    // C : ����/���� �̵��� �����ϵ��� moveVec ����
        playerRigid.velocity = moveVec * speed;                                     // C : playerRigid�� �ӵ�(�ӷ� + ����) ����
    }
}
