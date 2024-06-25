using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUse : MonoBehaviour
{
    [SerializeField] Button[] skillsBTN;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < skillsBTN.Length; i++)
        {
            int index = i;
            skillsBTN[i].onClick.AddListener(() => OnSkillClick(index));
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnSkillClick(int skill_index)
    {
        UsedSkill(skill_index);
    }
    void UsedSkill(int skill_index)
    {
        for (int i = 0; i < skillsBTN.Length; i++)
        {
            if (i == skill_index)
            {
                SkillSet(skill_index);
            }
        }
    }

    void SkillSet(int skill_index)
    {
        if (skill_index == 0)
        {
            GM.Instance.postMP -= 50;
            
            Debug.Log("0번 스킬");
        }
        if (skill_index == 1)
        {
            GM.Instance.postMP -= 100;
            
            Debug.Log("1번 스킬");
        }
        if (skill_index == 2)
        {
            GM.Instance.postMP -= 10;
            
            Debug.Log("2번 스킬");
        }
        if (skill_index == 3)
        {
            GM.Instance.postMP -= 200;
            
            Debug.Log("3번 스킬");
        }
        UIManager.Instance.TopUIUpdate();
    }
}
