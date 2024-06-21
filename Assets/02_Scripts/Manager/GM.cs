using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// ���� Ÿ�Ժ� ������ ����
/// </summary>
/// �⺻ ����鿡 ���÷���, ü��(ƨ���) ���� Ÿ��
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
    //���ӸŴ��� ��ũ��Ʈ, @ ������Ʈ�� ����

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
    ///����� �Լ� �� ���� ����
    ///</summary>
    /// Ŭ�� �� ������, �ֵ��� ü��, ���� ���, ���� Ÿ�Ժ� ������
    /// ���׷��̵�� ���� Ŭ��������, ���� ü��, ���� ���� ������, ���� ����

    public int clickDmg;
    public int postHP;
    public long haveGold;

}
