using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUse : MonoBehaviour
{
    /// <summary>
    /// Managers 의 UIControl에 붙어있음. 스킬 사용버튼에 대한 스크립트
    /// </summary>

    [SerializeField] Button[] skillsBTN;
    // 하단 UI 탭 > 스킬 메뉴탭에 있는 스킬사용 버튼 오브젝트를 배열로 저장
    // Start is called before the first frame update
    void Start()
    {
        // 스킬 버튼의 갯수만큼 반복
        for (int i = 0; i < skillsBTN.Length; i++)
        {
            int index = i;
            // index 변수를 따로 생성하는 이유는 -> i 변수만 사용했을 경우에는
            // 버튼마다의 인덱스가 아닌, 모든 버튼이 스킬버튼의 총량 만큼 인덱스를 갖게된다. (오류)
            skillsBTN[i].onClick.AddListener(() => OnSkillClick(index));
            // 0번 버튼 클릭했을때 함수 호출
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnSkillClick(int skill_index)
    {
        // 스킬버튼을 클릭했을때 호출되는 함수
        UsedSkill(skill_index);
        // 스킬 인덱스값을 받아 매개변수로 지정
    }
    void UsedSkill(int skill_index)
    {
        // 버튼의 총량 만큼 반복하며 체크함
        for (int i = 0; i < skillsBTN.Length; i++)
        {
            // 스킬인덱스 값이 i 값과 같다면 == 클릭한 버튼의 인덱스와 현재 반복해 확인중인 버튼의 인덱스가 같다면
            if (i == skill_index)
            {
                SkillSet(skill_index);
                // 실질적인 스킬 사용 함수 실행
            }
        }
    }

    void SkillSet(int skill_index)
    {
        // 0번 인덱스라면 아래 내용 실행
        // 이하 같은 내용, 각기 다른 스킬에 대한 값을 넣으면 됨
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
        // 스킬 사용에 마나가 필요하므로 상단UI 업데이트
    }
}
