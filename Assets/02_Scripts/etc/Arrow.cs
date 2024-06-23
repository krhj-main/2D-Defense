using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Vector2 velocity;
    Vector2 gravity;

    public void Initialize(Vector2 initialVelocity, Vector2 gravity)
    {
        this.velocity = initialVelocity;
        this.gravity = gravity;

        Destroy(this.gameObject,2f);
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
}
