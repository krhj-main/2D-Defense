using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// 무기 타입별 데미지 설정
/// </summary>
/// 기본 무기들에 스플래쉬, 체인(튕기는) 무기 타입
public class Weapon
{
    public int price;
    public int damage;
    public int attackSpeed;
}

public class Splash : Weapon
{
    public int splashDecreaseDamage;
}
public class Chain : Weapon
{
    public int chainDecreaseDamage;
}
public class GM : MonoBehaviour
{
    //게임매니저 스크립트, @ 오브젝트에 붙임

    static GM instance;

    public static GM Instance
    {
        get
        {
            return instance;
        }
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

    ///<summary>
    ///사용자 함수 및 변수 선언
    ///</summary>
    /// 클릭 시 데미지, 주둔지 체력, 소지 골드, 무기 타입별 데미지
    /// 업그레이드시 증가 클릭데미지, 증가 체력, 증가 무기 데미지, 증가 가격

    public int clickDmg;
    public int postHP;
    public long haveGold;

}
