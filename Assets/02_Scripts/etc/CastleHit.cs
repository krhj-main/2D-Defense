using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Monster"))
        {
            Destroy(col.gameObject);
            GM.Instance.postHP -= col.gameObject.GetComponent<Monster>().MM.monster_Dmg;
            UIManager.Instance.TopUIUpdate();
        }
    }
}
