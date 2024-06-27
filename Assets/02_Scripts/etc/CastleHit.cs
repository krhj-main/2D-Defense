using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ���� ���ݹ޾��� �� ���Ǵ� �Լ�, Castle ������Ʈ�� �پ�����
/// </summary>
public class CastleHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {

        // ���� �ε������� Monster �±׶��
        if (col.gameObject.CompareTag("Monster"))
        {
            Destroy(col.gameObject);
            // ���� �����ϰ�
            GM.Instance.postHP -= col.gameObject.GetComponent<Monster>().MM.monster_Dmg;
            // ���Ͱ� ���� �������� ������ ���� ü�� �϶�
            UIManager.Instance.TopUIUpdate();
            // �϶��� ü�� �ݿ�
        }
        // ���� �ε������� MonsterBullet �±׶�� -> ���Ÿ����� ����ü
        if (col.gameObject.CompareTag("MonsterBullet"))
        {
            Destroy(col.gameObject);
            // ����ü�� �����
            GM.Instance.postHP -= col.gameObject.GetComponent<MonsterBullet>().dmg;
            // ����ü�� ���� ������ ����ŭ ���� ü�� �϶�
            UIManager.Instance.TopUIUpdate();
            // �϶��� ü�� �ݿ�
        }
    }
}
