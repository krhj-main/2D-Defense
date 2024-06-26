using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    Rigidbody2D rg;

    Transform castleT;


    Vector3 startPos;
    Vector3 endPos;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        castleT = GameObject.Find("target").transform;

        Vector3 dir = castleT.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Parabolla();
    }
    void Parabolla()
    {
        startPos = transform.position;
        endPos = castleT.position;
        Vector3 center = (castleT.position + transform.position) * 0.5f;

        center.y -= 3f;

        startPos -= center;
        endPos -= center;

        Vector3 point = Vector3.Slerp(startPos,endPos,0.01f);

        point += center;

        transform.position = point;
    }

}
