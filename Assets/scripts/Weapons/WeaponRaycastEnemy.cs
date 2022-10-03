using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycastEnemy : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 1;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    [SerializeField] private PlayerTurn playerTurn;
    // Update is called once per frame
    void Update()
    {
        if (playerTurn.IsPlayerTurn())
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                StartCoroutine(Shoot());
            }

        }
    }
    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, 2);

        if (hitInfo)
        {
            TestEnemy testEnemy = hitInfo.transform.GetComponent<TestEnemy>();
            if (testEnemy != null)
            {
                hitInfo.collider.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + -firePoint.right * 1);
        }
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.02f);
        lineRenderer.enabled = false;
    }
}