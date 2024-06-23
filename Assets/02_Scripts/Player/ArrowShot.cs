using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    [Header ("화살 프리팹")]
    [SerializeField] GameObject arrow;
    // 화살 프리팹
    [Header("화살 발사 위치")]
    [SerializeField] Transform muzzle;
    // 화살 발사 포인트 
    [Header("화살 발사 속도")]
    [SerializeField] float arrowPower;
    // 화살 발사 힘
    [Header("중력 가속도")]
    [Tooltip ("기본값 -9.81")]
    [SerializeField] Vector2 gravity = new Vector2(0,-9.81f);
    // 중력가속도




    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
        arrowScript.Initialize(dir * arrowPower, gravity);
    }
}
