using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MonsterMove : MonoBehaviour
{
    Rigidbody2D rig;

    float Speed;
    float HP;
    int Dmg;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Speed = MobManager.Instance.myMob.mob_Speed;
        HP = MobManager.Instance.myMob.mob_HP;
        //Dmg = MobManager.Instance.mob.mob_Dmg;

        MoveToCastle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MoveToCastle()
    {
        rig.velocity = Vector3.left * Speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "castle")
        {
            Debug.Log("성과 충돌");
            Debug.Log(MobManager.Instance.myMob.mob_Dmg);
            GM.Instance.HitedEnemy();
            Destroy(gameObject);
        }
    }
}
