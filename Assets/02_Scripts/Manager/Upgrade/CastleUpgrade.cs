using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleUpgrade : MonoBehaviour
{
    [SerializeField] Button[] upgradesBTN;
    // 성 업그레이드 메뉴탭에 있는 업그레이드 버튼들을 저장
    [SerializeField] Renderer[] castleImgs;
    // 성 HP 업그레이드시 바꿔줄 이미지 목록 저장

    // Start is called before the first frame update
    void Start()
    {
        upgradesBTN[0].onClick.AddListener(Castle_HP_UP);
        // HP 업그레이드하는 버튼을 눌렀을때 호출 될 함수
        upgradesBTN[1].onClick.AddListener(Castle_MP_UP);
        // MP 업그레이드하는 버튼을 눌렀을때 호출 될 함수
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Castle_HP_UP()
    {
        // 성 HP 업그레이드 함수
        // 업그레이드에 사용되는 가격값 10000 만큼 골드가 없다면 바로 함수 탈출
        // 스킬이 많아진다면 스킬마다 cost 값을 따로 지정해 스킬의 cost값을 받아와야함
        if (GM.Instance.haveGold < 10000)
        {
            return;
        }

        // 만약 업그레이드 레벨이 준비된 성 업그레이드 이미지보다 많다면
        // 최대업그레이드에 도달한것으로 판단하고 레벨을 최대 업그레이드로 세팅
        // 업그레이드와 골드 연산을 하지않고 함수 탈출
        if (GM.Instance.upgrade_HP_Level >= castleImgs.Length)
        {
            GM.Instance.upgrade_HP_Level = castleImgs.Length;
            Debug.Log("최대 업그레이드 도달");
            return;
        }

        GM.Instance.haveGold -= 10000;
        GM.Instance.upgrade_HP_Level++;
        GM.Instance.postMaxHP += 5000;
        GM.Instance.postHP = GM.Instance.postMaxHP;

        // HP 업그레이드 레벨 증가, 최대체력 증가, 현재 체력을 증가한 최대체력으로 세팅
        // 골드 소모
        
        // 준비된 업그레이드 이미지 만큼 반복
        for (int i = 0; i < castleImgs.Length; i++)
        {
            // 성 이미지 중, 현재 업그레이드 레벨에 맞는 이미지 인덱스라면 true , 아니라면 false
            castleImgs[i].gameObject.SetActive(i == GM.Instance.upgrade_HP_Level);
        }
        UIManager.Instance.UpgradeUIUpdate();
        // 업그레이드칸의 UI 업데이트
    }
    void Castle_MP_UP()
    {
        // MP 업그레이드 코스트인 2000보다 소지골드가 적다면 바로 함수 탈출
        if (GM.Instance.haveGold < 2000)
        {
            return;
        }
        GM.Instance.haveGold -= 2000;
        GM.Instance.upgrade_MP_Level++;
        GM.Instance.postMaxMP += 1000;
        GM.Instance.postMPRegen += 0.05f;

        // 코스트 만큼 골드 소모, MP 업그레이드 레벨 증가, 최대 MP증가, MP리젠속도 증가

        UIManager.Instance.UpgradeUIUpdate();
        // 업그레이드칸의 UI 업데이트
    }
}
