using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 성이 공격받았을 때 사용되는 함수, Castle 오브젝트에 붙어있음
/// </summary>
public class CastleHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {

        // 성과 부딪힌것이 Monster 태그라면
        if (col.gameObject.CompareTag("Monster"))
        {
            Destroy(col.gameObject);
            // 몬스터 삭제하고
            GM.Instance.postHP -= col.gameObject.GetComponent<Monster>().MM.monster_Dmg;
            // 몬스터가 가진 데미지를 가져와 성의 체력 하락
            UIManager.Instance.TopUIUpdate();
            // 하락된 체력 반영
        }
        // 성과 부딪힌것이 MonsterBullet 태그라면 -> 원거리공격 투사체
        if (col.gameObject.CompareTag("MonsterBullet"))
        {
            Destroy(col.gameObject);
            // 투사체를 지우고
            GM.Instance.postHP -= col.gameObject.GetComponent<MonsterBullet>().dmg;
            // 투사체가 가진 데미지 값만큼 성의 체력 하락
            UIManager.Instance.TopUIUpdate();
            // 하락된 체력 반영
        }
    }
}
