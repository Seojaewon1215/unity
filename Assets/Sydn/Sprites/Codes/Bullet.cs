using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;

    public Animator animator; // 애니메이션 컨트롤러
    public KeyCode key = KeyCode.Space; // 실행할 키
    private bool isAttacking = false;

    public Transform player; // 플레이어 오브젝트
    public float dis = 1f; // 플레이어와 무기 사이의 거리

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    public Camera mainCamera; // 메인 카메라
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
        /// 플레이어의 이동 속도 가져오기 (Rigidbody를 사용하는 경우)
        float horizontalSpeed = player.GetComponent<Rigidbody2D>().velocity.x;

        // 플레이어의 이동 방향 판단
        Vector3 newPosition = player.position;

        if (horizontalSpeed > 0) // 오른쪽으로 이동
        {
            newPosition.x = player.position.x + player.GetComponent<SpriteRenderer>().bounds.extents.x + dis;
            spriter.flipX = true;
        }
        else if (horizontalSpeed < 0) // 왼쪽으로 이동
        {
            newPosition.x= player.position.x - player.GetComponent<SpriteRenderer>().bounds.extents.x - dis;
            spriter.flipX = false;
        }

        // 무기의 위치 업데이트
        transform.position = newPosition;


        // 마우스 위치를 월드 좌표로 변환
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // 2D 공간이므로 z 좌표는 0으로 고정

        // 무기 오브젝트와 마우스 위치 사이의 벡터 계산
        Vector3 direction = mousePos - transform.position;

        // 회전 각도 계산 (라디안)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 무기 오브젝트 회전
        transform.rotation = Quaternion.Euler(0, 0, angle+ang);
    }
    /*if (Input.GetKeyDown(key)) // 지정한 키가 눌리면
    {
        if (!isAttacking) // 현재 공격 중이 아닐 때만 공격
        {
            isAttacking = true;
            animator.SetBool("isattack", true);
        }
    }

    // 애니메이션 상태를 체크하여 공격이 끝났는지 확인
    if (isAttacking && !animator.GetCurrentAnimatorStateInfo(0).IsName("fire"))
    {
        isAttacking = false; // 애니메이션이 끝나면 공격 상태 초기화
        animator.SetBool("isattack", false);
    }*/

}
