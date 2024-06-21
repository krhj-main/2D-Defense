using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GM : MonoBehaviour
{
    static GM instance;

    public static GM Instance
    {
        get => instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }


    /// <summary>
    /// 성 디펜스 게임에 사용될 변수들
    /// </summary>
    /// 성 체력, 클릭 시 데미지, 스코어 증가량
    /// 몬스터 : 몬스터의 이동속도, 체력, 데미지, 생성속도

    float hpCastle;
    // 성의 체력값
    public float maxHPCastle;
    // 성의 최대체력 값
    public Slider hpBarCastle;
    // 체력 값 반영할 슬라이더

    public int dmgCastle;
    // 유저가 플레이하며 클릭했을 때 몬스터에게 주어질 데미지


    // Start is called before the first frame update
    void Start()
    {
        hpBarCastle = GameObject.Find("Castle_HPBar").GetComponent<Slider>();
        // 최대체력 나타내는 체력바 슬라이더 컴포넌트 가져오기
        hpCastle = maxHPCastle;
        // 성의 체력을 최대체력으로 초기화
        hpBarCastle.value = hpCastle / maxHPCastle;
        // 슬라이더를 현재체력 / 최대체력 비율로 설정
    }

    // Update is called once per frame
    void Update()
    {
        hpBarCastle.value = Mathf.Lerp(hpBarCastle.value, hpCastle / maxHPCastle, 5f*Time.deltaTime);
        // 체력바가 부드럽게 감소되게 하기 위해 , 업데이트에 선언하고
        // Mathf.Lerp 함수를 사용. 현재 체력바 밸류값을 현재체력 / 최대체력 비율로 바꾼다. 5f * Time만큼
    }

    public void HitedEnemy()
    {
        // 몬스터가 성에 부딪혔을때 MonsterMove에서 호출

        hpCastle -= MobManager.Instance.myMob.mob_Dmg;
        // 현재 체력을 몬스터의 공격력만큼 감소
        //hpBarCastle.value = Mathf.Lerp(hpBarCastle.value, hpCastle/maxHPCastle, MobManager.Instance.myMob.mob_Dmg);
        // 감소된 체력 / 최대체력 비율로 체력바 조절
    }
}
