using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D playerRigid;    // C : player의 물리제어관련 변수
    private Animator playerAnim;        // C : player의 애니메이터
    private float h;                    // C : player의 수평이동 값을 받기 위한 변수
    private float v;                    // C : player의 수직이동 값을 받기 위한 변수
    private bool isHorizonMove;         // C : player의 수평이동에 대한 bool값을 저장하기 위한 변수
    public Vector2 dirVec;              // J : player가 바라보는 방향

    [SerializeField]
    private float speed = 5;            // C : player의 이동 속력 값을 설정하기 위한 변수


    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();      // C : player 2D 물리제어 component instance 가져오기
        playerAnim = GetComponent<Animator>();          // C : player 애니메이션 컨트롤 component instance 가져오기
    }

    void Update()
    {
        // C : 키보드 방향키의 수평/수직 입력 값 받기
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // C : 각 키보드 방향키 up/down 시 수평/수직 확인해서 적절한 bool값 저장
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        // J : player가 바라보는 방향
        if (v == 1)
            dirVec = Vector3.up;
        else if (v == -1)
            dirVec = Vector3.down;
        else if (h == -1)
            dirVec = Vector3.left;
        else if (h == 1)
            dirVec = Vector3.right;

        // C : isHorizontalMove 값 설정
        // C : 수평이동 설명 - 수평 방향키 누를 시 true, 수직 방향키 뗄 시 true
        //     (수평 방향키 누른 후, 수직 방향키도 함께 누르다가 수직 방향키를 먼저 뗄 경우
        //      누르고 있는 수평 방향키 값대로 움직이기 위해 vUp도 고려해야 함)
        if (hDown || vUp)               // C : 수평이동 고려
            isHorizonMove = true;
        else if (vDown || hUp)          // C : 수직이동 고려
            isHorizonMove = false;


        // C : 애니메이션 설정
        // C : 추후 모든 방향 이동 에셋 제공될 시, 코드 수정 예정
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
        // C : playerRigid에 최종 이동 값 설정
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);    // C : 수평/수직 이동만 가능하도록 moveVec 설정
        playerRigid.velocity = moveVec * speed;                                     // C : playerRigid의 속도(속력 + 방향) 설정
    }
}
