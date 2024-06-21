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
    /// �� ���潺 ���ӿ� ���� ������
    /// </summary>
    /// �� ü��, Ŭ�� �� ������, ���ھ� ������
    /// ���� : ������ �̵��ӵ�, ü��, ������, �����ӵ�

    float hpCastle;
    // ���� ü�°�
    public float maxHPCastle;
    // ���� �ִ�ü�� ��
    public Slider hpBarCastle;
    // ü�� �� �ݿ��� �����̴�

    public int dmgCastle;
    // ������ �÷����ϸ� Ŭ������ �� ���Ϳ��� �־��� ������


    // Start is called before the first frame update
    void Start()
    {
        hpBarCastle = GameObject.Find("Castle_HPBar").GetComponent<Slider>();
        // �ִ�ü�� ��Ÿ���� ü�¹� �����̴� ������Ʈ ��������
        hpCastle = maxHPCastle;
        // ���� ü���� �ִ�ü������ �ʱ�ȭ
        hpBarCastle.value = hpCastle / maxHPCastle;
        // �����̴��� ����ü�� / �ִ�ü�� ������ ����
    }

    // Update is called once per frame
    void Update()
    {
        hpBarCastle.value = Mathf.Lerp(hpBarCastle.value, hpCastle / maxHPCastle, 5f*Time.deltaTime);
        // ü�¹ٰ� �ε巴�� ���ҵǰ� �ϱ� ���� , ������Ʈ�� �����ϰ�
        // Mathf.Lerp �Լ��� ���. ���� ü�¹� ������� ����ü�� / �ִ�ü�� ������ �ٲ۴�. 5f * Time��ŭ
    }

    public void HitedEnemy()
    {
        // ���Ͱ� ���� �ε������� MonsterMove���� ȣ��

        hpCastle -= MobManager.Instance.myMob.mob_Dmg;
        // ���� ü���� ������ ���ݷ¸�ŭ ����
        //hpBarCastle.value = Mathf.Lerp(hpBarCastle.value, hpCastle/maxHPCastle, MobManager.Instance.myMob.mob_Dmg);
        // ���ҵ� ü�� / �ִ�ü�� ������ ü�¹� ����
    }
}
