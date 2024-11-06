using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;

    Rigidbody2D rigid;

    public float speed;

    SpriteRenderer spriter;

    Animator anim;



    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();        
    }
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        // 애니메이터에 속도와 방향 정보 전달
        anim.SetFloat("Speed", inputVec.magnitude);
        anim.SetFloat("Horizontal", inputVec.x);
        anim.SetFloat("Vertical", inputVec.y);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized*speed*Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        

    }
}
