using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://jjong-ga.tistory.com/m/103
public class MainCameraController : MonoBehaviour
{
    private Transform player;   // J : �÷��̾� ������Ʈ�� transform

    [SerializeField] float smoothing = 0.2f;
    [SerializeField] private Vector2 minCameraBoundary;
    [SerializeField] private Vector2 maxCameraBoundary;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    // J : �÷��̾� �̵��� FixedUpdate�� �����Ǿ� �����Ƿ� ī�޶� FixedUpdate���� �̵�
    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);

        targetPos.x = Mathf.Clamp(targetPos.x, minCameraBoundary.x, maxCameraBoundary.x);
        targetPos.y = Mathf.Clamp(targetPos.y, minCameraBoundary.y, maxCameraBoundary.y);

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
    }
}
