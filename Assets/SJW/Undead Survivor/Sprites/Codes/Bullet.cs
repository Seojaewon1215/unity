using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;

    public Animator animator; // �ִϸ��̼� ��Ʈ�ѷ�
    public KeyCode key = KeyCode.Space; // ������ Ű
    private bool isAttacking = false;

    public Transform player; // �÷��̾� ������Ʈ
    public float dis = 1f; // �÷��̾�� ���� ������ �Ÿ�

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    public Camera mainCamera; // ���� ī�޶�
    public float ang;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }
    public void Init(float damage, int per)
    {
        this.damage = damage;
        this.per = per;

        
    }


    void Update()
    {
        /// �÷��̾��� �̵� �ӵ� �������� (Rigidbody�� ����ϴ� ���)
        float horizontalSpeed = player.GetComponent<Rigidbody2D>().velocity.x;

        // �÷��̾��� �̵� ���� �Ǵ�
        Vector3 newPosition = player.position;

        if (horizontalSpeed > 0) // ���������� �̵�
        {
            newPosition.x = player.position.x + player.GetComponent<SpriteRenderer>().bounds.extents.x + dis;
            spriter.flipX = true;
        }
        else if (horizontalSpeed < 0) // �������� �̵�
        {
            newPosition.x= player.position.x - player.GetComponent<SpriteRenderer>().bounds.extents.x - dis;
            spriter.flipX = false;
        }

        // ������ ��ġ ������Ʈ
        transform.position = newPosition;


        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // 2D �����̹Ƿ� z ��ǥ�� 0���� ����

        // ���� ������Ʈ�� ���콺 ��ġ ������ ���� ���
        Vector3 direction = mousePos - transform.position;

        // ȸ�� ���� ��� (����)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ���� ������Ʈ ȸ��
        transform.rotation = Quaternion.Euler(0, 0, angle+ang);
    }
    /*if (Input.GetKeyDown(key)) // ������ Ű�� ������
    {
        if (!isAttacking) // ���� ���� ���� �ƴ� ���� ����
        {
            isAttacking = true;
            animator.SetBool("isattack", true);
        }
    }

    // �ִϸ��̼� ���¸� üũ�Ͽ� ������ �������� Ȯ��
    if (isAttacking && !animator.GetCurrentAnimatorStateInfo(0).IsName("fire"))
    {
        isAttacking = false; // �ִϸ��̼��� ������ ���� ���� �ʱ�ȭ
        animator.SetBool("isattack", false);
    }*/

}
