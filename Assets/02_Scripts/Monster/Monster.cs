using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]    MonsterStat MM;

    Rigidbody2D rig;
    Transform castleT;

    // Start is called before the first frame update
    void Start()
    {
        castleT = GameObject.Find("target").transform;
        rig = GetComponent<Rigidbody2D>();
        Debug.Log(MM.monster_HP);
        Debug.Log(MM.monster_Speed);

        MoveAxis();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveAxis()
    {
        Vector2 dir = (castleT.transform.position - transform.position).normalized;
        rig.velocity = dir * MM.monster_Speed;
    }
}
