using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D playerRigid;    // C : player의 물리제어관련 변수
    private float h;                    // C : player의 수평이동 값을 받기 위한 변수
    private float v;                    // C : player의 수직이동 값을 받기 위한 변수
    private bool isHorizonMove;         // C : player의 수평이동에 대한 bool값을 저장하기 위한 변수

    [SerializeField]
    private float speed = 5;            // C : player의 이동 속력 값을 설정하기 위한 변수

    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();      // C : player 2D 물리제어 component instance 생성
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

        // C : isHorizontalMove 값 설정
        // C : 수평이동 설명 - 수평 방향키 누를 시 true, 수직 방향키 뗄 시 true
        //     (수평 방향키 누른 후, 수직 방향키도 함께 누르다가 수직 방향키를 먼저 뗄 경우
        //      누르고 있는 수평 방향키 값대로 움직이기 위해 vUp도 고려해야 함)
        if (hDown || vUp)               // C : 수평이동 고려
            isHorizonMove = true;
        else if (vDown || hUp)          // C : 수직이동 고려
            isHorizonMove = false;
    }

    void FixedUpdate()
    {
        // C : playerRigid에 최종 이동 값 설정
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);    // C : 수평/수직 이동만 가능하도록 moveVec 설정
        playerRigid.velocity = moveVec * speed;                                     // C : playerRigid의 속도(속력 + 방향) 설정
    }
}
