using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUse : MonoBehaviour
{
    /// <summary>
    /// Managers �� UIControl�� �پ�����. ��ų ����ư�� ���� ��ũ��Ʈ
    /// </summary>

    [SerializeField] Button[] skillsBTN;
    // �ϴ� UI �� > ��ų �޴��ǿ� �ִ� ��ų��� ��ư ������Ʈ�� �迭�� ����
    // Start is called before the first frame update
    void Start()
    {
        // ��ų ��ư�� ������ŭ �ݺ�
        for (int i = 0; i < skillsBTN.Length; i++)
        {
            int index = i;
            // index ������ ���� �����ϴ� ������ -> i ������ ������� ��쿡��
            // ��ư������ �ε����� �ƴ�, ��� ��ư�� ��ų��ư�� �ѷ� ��ŭ �ε����� ���Եȴ�. (����)
            skillsBTN[i].onClick.AddListener(() => OnSkillClick(index));
            // 0�� ��ư Ŭ�������� �Լ� ȣ��
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnSkillClick(int skill_index)
    {
        // ��ų��ư�� Ŭ�������� ȣ��Ǵ� �Լ�
        UsedSkill(skill_index);
        // ��ų �ε������� �޾� �Ű������� ����
    }
    void UsedSkill(int skill_index)
    {
        // ��ư�� �ѷ� ��ŭ �ݺ��ϸ� üũ��
        for (int i = 0; i < skillsBTN.Length; i++)
        {
            // ��ų�ε��� ���� i ���� ���ٸ� == Ŭ���� ��ư�� �ε����� ���� �ݺ��� Ȯ������ ��ư�� �ε����� ���ٸ�
            if (i == skill_index)
            {
                SkillSet(skill_index);
                // �������� ��ų ��� �Լ� ����
            }
        }
    }

    void SkillSet(int skill_index)
    {
        // 0�� �ε������ �Ʒ� ���� ����
        // ���� ���� ����, ���� �ٸ� ��ų�� ���� ���� ������ ��
        if (skill_index == 0)
        {
            GM.Instance.postMP -= 50;
            
            Debug.Log("0�� ��ų");
        }
        if (skill_index == 1)
        {
            GM.Instance.postMP -= 100;
            
            Debug.Log("1�� ��ų");
        }
        if (skill_index == 2)
        {
            GM.Instance.postMP -= 10;
            
            Debug.Log("2�� ��ų");
        }
        if (skill_index == 3)
        {
            GM.Instance.postMP -= 200;
            
            Debug.Log("3�� ��ų");
        }
        UIManager.Instance.TopUIUpdate();
        // ��ų ��뿡 ������ �ʿ��ϹǷ� ���UI ������Ʈ
    }
}
