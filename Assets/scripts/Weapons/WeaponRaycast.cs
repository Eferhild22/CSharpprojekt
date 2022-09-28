using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycast : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 1;
    public HealthBar healthBar;
    public PlayerHealth playerHealth;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, -firePoint.right);
       
        if(hitInfo)
        {
            TestEnemy testEnemy = hitInfo.transform.GetComponent<TestEnemy>();
            if(testEnemy != null)
            {
                testEnemy.TakeDamage(damage);
            }
        }
    }
}
