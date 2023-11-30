using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;
    public float bulletDuration;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = transform.position;
        rb.velocity = new Vector2(direction.x, 0).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        bulletDuration -= Time.deltaTime;

        if(bulletDuration <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
