using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceMuzzle : MonoBehaviour
{
    [SerializeField] Weapon Weapon_Type;
    PlayerAttack attack;
    // Start is called before the first frame update
    void Start()
    {
        
        attack = GameObject.Find("@").GetComponent<PlayerAttack>();

        attack.Piyoung(gameObject, Weapon_Type.attackSpeed);
        Destroy(gameObject,3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Destroy(gameObject);
            attack.OnHitted(gameObject, collision.gameObject, 100, Weapon_Type.damage);
            Debug.Log(Weapon_Type.damage);
        }
    }
}
