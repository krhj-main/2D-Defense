using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [Tooltip ("������� ��Ÿ���� �ؽ�Ʈ")]
    [SerializeField] TextMeshProUGUI gold;

    [Tooltip("HP ��")]
    [SerializeField] Slider hp_Slider;
    [SerializeField] TextMeshProUGUI hp_TXT;
    [Space (10)]
    [Tooltip("MP ��")]
    [SerializeField] Slider mp_Slider;
    [SerializeField] TextMeshProUGUI mp_TXT;

    private void Start()
    {
        GM.Instance.postHP = GM.Instance.postMaxHP;
        GM.Instance.postMP = GM.Instance.postMaxMP;

        TopUIUpdate();
    }
    private void Update()
    {

    }
    public void TopUIUpdate()
    {
        gold.text = string.Format("{0}", GM.Instance.haveGold);
        hp_TXT.text = string.Format("{0} / {1}", GM.Instance.postHP, GM.Instance.postMaxHP);
        mp_TXT.text = string.Format("{0} / {1}", GM.Instance.postMP, GM.Instance.postMaxMP);
        hp_Slider.value = GM.Instance.postHP / GM.Instance.postMaxHP;
        mp_Slider.value = GM.Instance.postMP / GM.Instance.postMaxMP;
    }
}
