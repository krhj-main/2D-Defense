using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    Monster mobM;
    [SerializeField] GameObject arrow;
    GameObject muzzle;

    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        muzzle = GameObject.Find("Muzzle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            RaycastHit2D hit = Physics2D.Raycast(mousePos,Vector2.zero,15f);
            Debug.DrawRay(mousePos,Vector3.forward * 30f,Color.red,2f);
            Debug.Log(hit.point);
            
            GameObject weapon_Arrow = Instantiate(arrow,muzzle.transform.position,Quaternion.Euler(muzzle.transform.eulerAngles));
            

            if (hit.collider != null)
            {
                GameObject gg = hit.collider.gameObject;
                if (gg.CompareTag("Monster"))
                {

                }
            }
        }
    }
    public void Piyoung(GameObject go, float speed)
    {
        Vector3 newPos = new Vector3(mousePos.x,mousePos.y,0);
        go.GetComponent<Rigidbody2D>().AddForce(muzzle.transform.up * speed,ForceMode2D.Impulse);
    }
    /// <summary>
    /// 몬스터가 공격에 맞았을때 체력,데미지처리 및 넉백 효과
    /// </summary>
    /// <param name="projectile">투사체</param>
    /// <param name="monster">몬스터</param>
    /// <param name="hp">몬스터 체력</param>
    /// <param name="damage">투사체의 공격력</param>
    public void OnHitted(GameObject projectile, GameObject monster,float hp, float damage)
    {
        
        Vector2 dir = monster.transform.position - projectile.transform.position;
        monster.GetComponent<Rigidbody2D>().AddForce(dir.normalized * 50f,ForceMode2D.Impulse);
        hp -= damage;
        monster.GetComponent<Monster>().Invoke("MoveAxis",0.35f);

    }
}
