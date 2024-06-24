using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// 무기 타입별 데미지 설정
/// </summary>
/// 기본 무기들에 스플래쉬, 체인(튕기는) 무기 타입

[System.Serializable]
public class Weapon
{
    public int price;
    public int damage;
    public int attackSpeed;
    [Header("중력 가속도")]
    [Tooltip("기본값 -9.81")]
    public Vector2 gravity = new Vector2(0, -9.81f);
    // 중력가속도
}
[System.Serializable]
public class Splash : Weapon
{
    public int splashDecreaseDamage;
}
[System.Serializable]
public class Chain : Weapon
{
    public int chainDecreaseDamage;
}
public class GM : Singleton<GM>
{
    //게임매니저 스크립트, @ 오브젝트에 붙임

    ///<summary>
    ///사용자 함수 및 변수 선언
    ///</summary>
    /// 클릭 시 데미지, 주둔지 체력, 소지 골드, 무기 타입별 데미지
    /// 업그레이드시 증가 클릭데미지, 증가 체력, 증가 무기 데미지, 증가 가격

    [HideInInspector]
    public float postHP;
    public float postMaxHP;
    [HideInInspector]
    public float postMP;
    public float postMaxMP;
    public long haveGold;

}
