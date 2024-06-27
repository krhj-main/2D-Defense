using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    /// <summary>
    /// ���Ÿ� ���Ͱ� �߻��ϴ� Bullet ������Ʈ�� �پ�����
    /// </summary>


    Rigidbody2D rg;
    // ������ٵ� ����ų ����

    Transform castleT;
    // ���� ���� ���󰡱����� �� Ʈ������ ����

    [HideInInspector]
    public float dmg;
    // ���Ÿ� ����ü�� ������ ����

    // Start is called before the first frame update
    void Start()
    {
        dmg = GetComponentInParent<Monster>().MM.monster_Dmg;
        // ���Ÿ� ��������, ���Ÿ� ������ �ϰ��ִ� ������ ���������� ������ ����
        rg = GetComponent<Rigidbody2D>();
        // ȭ���� ������ٵ� ��ü �޾ƿ���
        castleT = GameObject.Find("target").transform;
        // ���� ����Ű�� target ������Ʈ�� Ʈ������ ��������
        // �� target�� �������� �ƴϱ⶧���� ���ӿ�����Ʈ�� ã�Ƽ� ����

        Vector3 dir = (castleT.position - transform.position).normalized;
        // ���� ��ġ���� ȭ���� ������ġ�� ���־� ������ ����


        rg.AddForce(dir * 800f, ForceMode2D.Impulse);
        // ���� �������� ����ü �߻�
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
