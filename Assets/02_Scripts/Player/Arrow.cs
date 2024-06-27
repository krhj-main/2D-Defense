using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 화살 오브젝트의 포물선 운동에 관한 함수
/// </summary>

public class Arrow : MonoBehaviour
{
    Vector2 velocity;
    // 화살의 속도값
    Vector2 gravity;
    // 화살의 중력값
    ArrowShot arrowScript;
    // 화살공격을 발사하는 ArrowShot 스크립트 변수 선언
    [SerializeField] Weapon Weapon_Type;
    // 무기 타입에 관한 설정하기위해 Weapon 클래스 변수 선언

    public void Initialize(Vector2 dir)
    {
        // ArrowShot 에서 호출해 방향값을 받아오기위한 함수

        this.velocity = dir * Weapon_Type.attackSpeed;
        // 화살의 속도에 방향값을 곱해, 화살오브젝트의 velocity 값에 저장
        this.gravity = Weapon_Type.gravity;
        // 중력값은 설정된값 그대로 적용

        Destroy(this.gameObject, 2f);
        // 몬스터를 맞추지못헀을때는 2초뒤에 자동으로 사라짐
    }
    private void Start()
    {
        arrowScript = GameObject.Find("@").GetComponent<ArrowShot>();    
        // ArrowShot 스크립트가 @ 오브젝트에 붙어있으므로 접근해 저장
    }

    // Update is called once per frame
    void Update()
    {
        velocity += gravity * Time.deltaTime;
        // 화살의 속도를 중력값 * p/s 만큼 증가
        // 중력값은 음수이므로 결과적으로는 속도가 감소함

        transform.Translate(velocity * Time.deltaTime,Space.World);
        // 화살의 이동
        // 계속해서 변하는 속도값만큼 이동한다

        Vector2 norVelo = velocity.normalized;
        // 속도값을 정규화
        float angle = Mathf.Atan2(norVelo.y, norVelo.x) * Mathf.Rad2Deg;
        // 화살의 각도가 점점 꺾어지게 만들어 떨어지게 하는 것
        // 검색을 통해 찾아본 내용이지만 완벽히 이해하지 못했음

        angle -= 90;
        // 90을 감소시켜주는 이유는 발사의 각도를 조절하기 위함
        // -90도를 꺾어 가로방향으로 만들어준다
        transform.rotation = Quaternion.Euler(0,0,angle);
        // 계산된 angle 값을 화살 z축 값에 적용
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            // 화살 오브젝트가 몬스터 태그를 가진 오브젝트에 닿으면
            Destroy(gameObject);
            // 화살을 삭제하고
            arrowScript.OnHitted(collision.gameObject, Weapon_Type.damage);          
            // ArrowScript 에서 몬스터에게 데미지를 처리한다.
        }
    }
}
