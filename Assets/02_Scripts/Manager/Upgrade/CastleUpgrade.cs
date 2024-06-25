using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleUpgrade : MonoBehaviour
{
    [SerializeField] Button[] upgradesBTN;
    [SerializeField] Renderer[] castleImgs;

    int UpgradeIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        upgradesBTN[0].onClick.AddListener(Castle_HP_UP);
        upgradesBTN[1].onClick.AddListener(Castle_MP_UP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Castle_HP_UP()
    {
        UpgradeIndex++;
        if (UpgradeIndex >= castleImgs.Length)
        {
            UpgradeIndex = castleImgs.Length;
            Debug.Log("최대 업그레이드 도달");
            return;
        }
        for (int i = 0; i < castleImgs.Length; i++)
        {
            castleImgs[i].gameObject.SetActive(i == UpgradeIndex);
        }
    }
    void Castle_MP_UP()
    {
        GM.Instance.postMaxMP += 1000;
        GM.Instance.postMPRegen += 0.05f;
    }
}
