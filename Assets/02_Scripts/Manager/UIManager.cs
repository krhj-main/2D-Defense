using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [Tooltip ("소지골드 나타내는 텍스트")]
    [SerializeField] TextMeshProUGUI gold;

    [Tooltip("HP 바")]
    [SerializeField] Slider hp_Slider;
    [SerializeField] TextMeshProUGUI hp_TXT;
    [Space (15)]
    [Tooltip("MP 바")]
    [SerializeField] Slider mp_Slider;
    [SerializeField] TextMeshProUGUI mp_TXT;

    [SerializeField] TextMeshProUGUI up_Castle_TXT;
    [SerializeField] TextMeshProUGUI up_Mana_TXT;

    private void Start()
    {
        GM.Instance.postHP = GM.Instance.postMaxHP;
        GM.Instance.postMP = GM.Instance.postMaxMP;

        TopUIUpdate();
    }
    private void Update()
    {
        if (GM.Instance.postMP < GM.Instance.postMaxMP)
        {
            GM.Instance.postMP += GM.Instance.postMPRegen;
            if(GM.Instance.postMP  >= GM.Instance.postMaxMP)
            {
                GM.Instance.postMP = GM.Instance.postMaxMP;
            }
            TopUIUpdate();
        }
    }
    public void TopUIUpdate()
    {
        gold.text = string.Format("{0}", GM.Instance.haveGold);
        hp_TXT.text = string.Format("{0} / {1}", GM.Instance.postHP, GM.Instance.postMaxHP);
        mp_TXT.text = string.Format("{0} / {1}", GM.Instance.postMP, GM.Instance.postMaxMP);
        hp_Slider.value = GM.Instance.postHP / GM.Instance.postMaxHP;
        mp_Slider.value = GM.Instance.postMP / GM.Instance.postMaxMP;
    }
    public void UpgradeUIUpdate()
    {
        up_Castle_TXT.text = string.Format("Cost : 10000\nHP + 5000\nCastle Lv : {0}",GM.Instance.upgrade_HP_Level);
        up_Mana_TXT.text = string.Format("Cost : 2000\nMP + 1000\nMP Regen + 0.05\nMana Lv : {0}",GM.Instance.upgrade_MP_Level);
    }
}
