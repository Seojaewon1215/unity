using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    void Start()
    {
        Init();
    }


    // Update is called once per frame
    void Update()
    {
        switch (id)
        {
            case 0:

                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;

            default:
                break;
        }
    }
    public void Init()
    {
        switch (id)
        {
            case 0:

                speed = -150;
                Batch();
                break;

            default:
                break;
        }
    }
    void Batch()
    {
        for(int index=0; index < count; index++)
        {
            Transform bullet=GameManager.Instance.pool.Get(prefabId).transform;
            bullet.parent = transform;
            bullet.GetComponent<Bullet>().Init(damage, -1);//-1 관통하는 무기
        }
    }

}
