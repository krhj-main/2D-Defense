using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// ���� Ÿ�Ժ� ������ ����
/// </summary>
/// �⺻ ����鿡 ���÷���, ü��(ƨ���) ���� Ÿ��

[System.Serializable]
public class Weapon
{
    public int price;
    public int damage;
    public int attackSpeed;
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
    //���ӸŴ��� ��ũ��Ʈ, @ ������Ʈ�� ����

    ///<summary>
    ///����� �Լ� �� ���� ����
    ///</summary>
    /// Ŭ�� �� ������, �ֵ��� ü��, ���� ���, ���� Ÿ�Ժ� ������
    /// ���׷��̵�� ���� Ŭ��������, ���� ü��, ���� ���� ������, ���� ����

    public int clickDmg;
    public int postHP;
    public long haveGold;

}
