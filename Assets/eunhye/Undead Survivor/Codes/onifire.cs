using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onifire : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;
    public float stoppingDistance = 5f;  // 플레이어와 적 사이에 유지할 거리

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Vector2 dirVec = target.position - rigid.position;
        float distance = dirVec.magnitude;  // 현재 거리 계산

        // 만약 플레이어와의 거리가 stoppingDistance보다 크면 이동
        if (distance > stoppingDistance)
        {
            Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + nextVec);
        }

        // 이동 후 속도는 0으로 설정
        rigid.velocity = Vector2.zero;
    }
}
