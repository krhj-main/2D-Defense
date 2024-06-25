using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowShot : MonoBehaviour
{
    [Header ("화살 프리팹")]
    [SerializeField] GameObject arrow;
    // 화살 프리팹
    [Header("화살 발사 위치")]
    [SerializeField] Transform muzzle;
    // 화살 발사 포인트 

    




    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            ShootArrow();
        }
    }
    void ShootArrow()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        GameObject arrows = Instantiate(arrow, muzzle.position, Quaternion.Euler(muzzle.transform.eulerAngles));

        Vector2 dir = (mousePos - muzzle.position).normalized;

        Arrow arrowScript = arrows.GetComponent<Arrow>();
        arrowScript.Initialize(dir);
    }
    public void OnHitted(GameObject projectile, GameObject monster, float damage)
    {
        Vector2 dir = monster.transform.position - projectile.transform.position;
        //monster.GetComponent<Rigidbody2D>().AddForce(dir.normalized * 100f, ForceMode2D.Impulse);
        monster.GetComponent<Monster>().state = State.Back;
        monster.GetComponent<Monster>().MM.monster_HP -= damage;
        if(monster.GetComponent<Monster>().MM.monster_HP <= 0)
        {
            Destroy(monster.gameObject);
        }
        //monster.GetComponent<Monster>().Invoke("MoveAxis", 0.35f);
    }
}
