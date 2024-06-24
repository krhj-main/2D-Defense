using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Vector2 velocity;
    Vector2 gravity;
    ArrowShot arrowScript;
    [SerializeField] Weapon Weapon_Type;
    /*
    public void Initialize(Vector2 initialVelocity, Vector2 gravity)
    {
        this.velocity = initialVelocity;
        this.gravity = gravity;

        Destroy(this.gameObject,2f);
    }*/
    public void Initialize(Vector2 dir)
    {
        this.velocity = dir * Weapon_Type.attackSpeed;
        this.gravity = Weapon_Type.gravity;

        Destroy(this.gameObject, 2f);
    }
    private void Start()
    {
        arrowScript = GameObject.Find("@").GetComponent<ArrowShot>();    
    }

    // Update is called once per frame
    void Update()
    {
        velocity += gravity * Time.deltaTime;

        transform.Translate(velocity * Time.deltaTime,Space.World);

        Vector2 norVelo = velocity.normalized;
        float angle = Mathf.Atan2(norVelo.y, norVelo.x) * Mathf.Rad2Deg;

        angle -= 90;
        transform.rotation = Quaternion.Euler(0,0,angle);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Destroy(gameObject);
            arrowScript.OnHitted(gameObject, collision.gameObject, Weapon_Type.damage);
            Debug.Log(collision.GetComponent<Monster>().MM.monster_HP);
            Debug.Log(Weapon_Type.damage);
        }
    }
}
