using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private int stateHash;

    [SerializeField] private float speed = 5;            // C : player의 이동 속력 값을 설정하기 위한 변수

    private Vector2 moveDir;            // J : 이동 방향
    public Vector2 dirVec;              // J : player가 바라보는 방향

    [SerializeField] private Rigidbody2D playerRigid;    // C : player의 물리제어관련 변수
    [SerializeField] private Animator playerAnim;        // C : player의 애니메이터'

    //private string prevState = "horizon";
    //private List<bool> prevState = new List<bool>() { false, false, false, false };
    //private List<bool> currentState = new List<bool>() { false, false, false, false };

    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();      // C : player 2D 물리제어 component instance 가져오기
        playerAnim = GetComponent<Animator>();          // C : player 애니메이션 컨트롤 component instance 가져오기

        stateHash = Animator.StringToHash("state");
    }

    void FixedUpdate()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        moveDir.Normalize();

        playerRigid.velocity = moveDir * speed;                       // C : playerRigid의 속도(속력 + 방향) 설정

        SetAnimation();
    }

    private void SetAnimation()
    {
        if (moveDir != Vector2.zero)
        {
            if (Math.Abs(moveDir.x) > Math.Abs(moveDir.y))
            {
                if (moveDir.x > 0)
                {
                    playerAnim.SetInteger(stateHash, 1);
                    Debug.Log("Right");
                }
                else 
                {
                    playerAnim.SetInteger(stateHash, 2);
                    Debug.Log("Left"); }
                }
            else
            {
                if (moveDir.y > 0)
                {
                    playerAnim.SetInteger(stateHash, 3);
                    Debug.Log("back");
                }
                else 
                {
                    playerAnim.SetInteger(stateHash, 4);
                    Debug.Log("front"); }
                }
        }
        else
            playerAnim.SetInteger(stateHash, 0);
    }
}