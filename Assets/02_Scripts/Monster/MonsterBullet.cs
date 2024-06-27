using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    /// <summary>
    /// 원거리 몬스터가 발사하는 Bullet 오브젝트에 붙어있음
    /// </summary>


    Rigidbody2D rg;
    // 리지드바디를 가리킬 변수

    Transform castleT;
    // 성을 향해 날라가기위한 성 트랜스폼 변수

    [HideInInspector]
    public float dmg;
    // 원거리 투사체의 데미지 변수

    // Start is called before the first frame update
    void Start()
    {
        dmg = GetComponentInParent<Monster>().MM.monster_Dmg;
        // 원거리 데미지는, 원거리 공격을 하고있는 몬스터의 데미지값을 가져와 적용
        rg = GetComponent<Rigidbody2D>();
        // 화살의 리지드바디 객체 받아오기
        castleT = GameObject.Find("target").transform;
        // 성을 가리키는 target 오브젝트의 트랜스폼 가져오기
        // 성 target은 프리팹이 아니기때문에 게임오브젝트를 찾아서 저장

        Vector3 dir = (castleT.position - transform.position).normalized;
        // 성의 위치에서 화살의 생성위치를 빼주어 방향을 구함


        rg.AddForce(dir * 800f, ForceMode2D.Impulse);
        // 성의 방향으로 투사체 발사
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
