using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onifire : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;
    public float stoppingDistance = 5f;  // �÷��̾�� �� ���̿� ������ �Ÿ�

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
        float distance = dirVec.magnitude;  // ���� �Ÿ� ���

        // ���� �÷��̾���� �Ÿ��� stoppingDistance���� ũ�� �̵�
        if (distance > stoppingDistance)
        {
            Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + nextVec);
        }

        // �̵� �� �ӵ��� 0���� ����
        rigid.velocity = Vector2.zero;
    }
}
