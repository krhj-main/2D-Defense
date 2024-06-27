using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 플레이어가 마우스 클릭으로 화살을 발사하는 스크립트 @ 오브젝트에 붙어있음
/// </summary>

public class ArrowShot : MonoBehaviour
{
    [Header ("화살 프리팹")]
    [SerializeField] GameObject arrow;
    // 화살 프리팹
    [Header("화살 발사 위치")]
    [SerializeField] Transform muzzle;
    // 화살 발사 포인트 

    




    // Update is called once per frame
    void Update()
    {
        // UI가 아닌 부분을 마우스 좌클릭 했을 때 실행
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            ShootArrow();
        }
    }
    void ShootArrow()
    {
        // 화살 발사 함수
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 클릭했을때의 마우스 스크린위치값을 월드포인트 값으로 변환해 Vector3 변수에 저장
        mousePos.z = 0;
        // z 값은 사용하지않으므로 0으로 초기화

        GameObject arrows = Instantiate(arrow, muzzle.position, Quaternion.Euler(muzzle.transform.eulerAngles));
        // 화살 오브젝트 생성, muzzle 위치에서 muzzle 의 각도로 생성

        Vector2 dir = (mousePos - muzzle.position).normalized;
        // 화살의 각도를 정해주기 위한 방향값을 계산

        Arrow arrowScript = arrows.GetComponent<Arrow>();
        arrowScript.Initialize(dir);
        // 화살 스크립트에 접근해 화살에 방향값을 전달
    }


    /// <summary>
    /// 몬스터에게 데미지 처리
    /// </summary>
    /// <param name="화살 오브젝트"></param>
    /// <param name="몬스터 오브젝트"></param>
    /// <param name="몬스터에게 가할 데미지"></param>
    public void OnHitted(GameObject monster, float damage)
    {
        monster.GetComponent<Monster>().state = State.Back;
        // 화살에 맞았으므로 몬스터의 상태를 넉백상태로 바꿔줌
        monster.GetComponent<Monster>().MM.monster_HP -= damage;
        // 몬스터의 체력을 화살의 데미지 만큼 감소
        if(monster.GetComponent<Monster>().MM.monster_HP <= 0)
        {
            Destroy(monster.gameObject);
            // 화살에 맞은 몬스터의 체력이 0이하가 된다면 몬스터 오브젝트를 삭제
        }
    }
}
