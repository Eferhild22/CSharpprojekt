using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        TestEnemy testEnemy= hitInfo.GetComponent<TestEnemy>();
        if(testEnemy != null)
        {
            testEnemy.TakeDamage(damage);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
