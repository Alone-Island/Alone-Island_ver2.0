using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    public string animalName;
    public int hp;
    public List<Item> huntingItems;    // J : 사냥 시 플레이어가 얻는 아이템 리스트

    // J : 미사용
    public int offensivePower;
    protected float range = 2;    // J : 플레이어 인지 범위
    private RaycastHit2D hitInfo; // J : 충돌체의 정보
    [SerializeField]
    private LayerMask layerMask;    // J : 플레이어만 인지하기 위함
    private bool isAttack = false;  // J : 플레이어 공격 가능 여부

    // J : 미사용
    protected void CheckPlayer()
    {
        // J : 동물 앞 오브젝트의 정보를 hitInfo에 저장
        // J : 일단 방향은 왼쪽으로 고정
        hitInfo = Physics2D.Raycast(transform.position, Vector2.left, range, layerMask);
        if (hitInfo.collider != null)
        {
            Debug.Log("CheckPlayer");
            isAttack = true;
        }
    }

    // J : 미사용
    protected void CanAttack()
    {
        if (isAttack)
        {
            Debug.Log(animalName + "의 공격 데미지: " + offensivePower);
            isAttack = false;
        }
    }

    public abstract void MakeSound();
}
