using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleUpgrade : MonoBehaviour
{
    [SerializeField] Button[] upgradesBTN;
    // �� ���׷��̵� �޴��ǿ� �ִ� ���׷��̵� ��ư���� ����
    [SerializeField] Renderer[] castleImgs;
    // �� HP ���׷��̵�� �ٲ��� �̹��� ��� ����

    // Start is called before the first frame update
    void Start()
    {
        upgradesBTN[0].onClick.AddListener(Castle_HP_UP);
        // HP ���׷��̵��ϴ� ��ư�� �������� ȣ�� �� �Լ�
        upgradesBTN[1].onClick.AddListener(Castle_MP_UP);
        // MP ���׷��̵��ϴ� ��ư�� �������� ȣ�� �� �Լ�
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Castle_HP_UP()
    {
        // �� HP ���׷��̵� �Լ�
        // ���׷��̵忡 ���Ǵ� ���ݰ� 10000 ��ŭ ��尡 ���ٸ� �ٷ� �Լ� Ż��
        // ��ų�� �������ٸ� ��ų���� cost ���� ���� ������ ��ų�� cost���� �޾ƿ;���
        if (GM.Instance.haveGold < 10000)
        {
            return;
        }

        // ���� ���׷��̵� ������ �غ�� �� ���׷��̵� �̹������� ���ٸ�
        // �ִ���׷��̵忡 �����Ѱ����� �Ǵ��ϰ� ������ �ִ� ���׷��̵�� ����
        // ���׷��̵�� ��� ������ �����ʰ� �Լ� Ż��
        if (GM.Instance.upgrade_HP_Level >= castleImgs.Length)
        {
            GM.Instance.upgrade_HP_Level = castleImgs.Length;
            Debug.Log("�ִ� ���׷��̵� ����");
            return;
        }

        GM.Instance.haveGold -= 10000;
        GM.Instance.upgrade_HP_Level++;
        GM.Instance.postMaxHP += 5000;
        GM.Instance.postHP = GM.Instance.postMaxHP;

        // HP ���׷��̵� ���� ����, �ִ�ü�� ����, ���� ü���� ������ �ִ�ü������ ����
        // ��� �Ҹ�
        
        // �غ�� ���׷��̵� �̹��� ��ŭ �ݺ�
        for (int i = 0; i < castleImgs.Length; i++)
        {
            // �� �̹��� ��, ���� ���׷��̵� ������ �´� �̹��� �ε������ true , �ƴ϶�� false
            castleImgs[i].gameObject.SetActive(i == GM.Instance.upgrade_HP_Level);
        }
        UIManager.Instance.UpgradeUIUpdate();
        // ���׷��̵�ĭ�� UI ������Ʈ
    }
    void Castle_MP_UP()
    {
        // MP ���׷��̵� �ڽ�Ʈ�� 2000���� ������尡 ���ٸ� �ٷ� �Լ� Ż��
        if (GM.Instance.haveGold < 2000)
        {
            return;
        }
        GM.Instance.haveGold -= 2000;
        GM.Instance.upgrade_MP_Level++;
        GM.Instance.postMaxMP += 1000;
        GM.Instance.postMPRegen += 0.05f;

        // �ڽ�Ʈ ��ŭ ��� �Ҹ�, MP ���׷��̵� ���� ����, �ִ� MP����, MP�����ӵ� ����

        UIManager.Instance.UpgradeUIUpdate();
        // ���׷��̵�ĭ�� UI ������Ʈ
    }
}
