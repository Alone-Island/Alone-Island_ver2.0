using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    public string animalName;

    public int hp;
    public int offensivePower;

    protected float range = 2;    // J : �÷��̾� ���� ����
    private RaycastHit2D hitInfo; // J : �浹ü�� ����
    [SerializeField]
    private LayerMask layerMask;    // J : �÷��̾ �����ϱ� ����

    private bool isAttack = false;  // J : �÷��̾� ���� ���� ����


    protected void CheckPlayer()
    {
        // J : ���� �� ������Ʈ�� ������ hitInfo�� ����
        // J : �ϴ� ������ �������� ����
        hitInfo = Physics2D.Raycast(transform.position, Vector2.left, range, layerMask);
        if (hitInfo.collider != null)
        {
            Debug.Log("CheckPlayer");
            isAttack = true;
        }
    }

    protected void CanAttack()
    {
        if (isAttack)
        {
            Debug.Log(animalName + "�� ���� ������: " + offensivePower);
            isAttack = false;
        }
    }

    public abstract void MakeSound();
}
