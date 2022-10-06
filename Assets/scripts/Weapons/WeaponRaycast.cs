using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycast : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 1;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    [SerializeField] private PlayerTurn playerTurn;
    public bool CanShoot = true;
    private float lineTimer = 0f;
    private float lineTimerDuration = 0.12f;

    private void Start()
    {
        TurnManager.GetInstance().playerOneWeapon = this;
    }
    void  Update()
    {
        if (playerTurn.IsPlayerTurn() && CanShoot)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                //StartCoroutine(Shoot());
                Shoot2();
                Debug.LogError("P1 Shot");
                CanShoot = false;
                TurnManager.GetInstance().TriggerChangeTurn();
            }

        }
        LineTimer();
    }
    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, -firePoint.right, 2);
        if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            TestEnemy testEnemy = hitInfo.transform.GetComponent<TestEnemy>();
            if (testEnemy != null)
            {
                hitInfo.collider.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
            //lineRenderer.SetPosition(0, firePoint.position);
            //lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            //lineRenderer.SetPosition(0, firePoint.position);
            //lineRenderer.SetPosition(1, firePoint.position + -firePoint.right * 1);
        }
        //lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.02f);
        lineRenderer.enabled = false;
    }
    private void Shoot2()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, -firePoint.right, 2);
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
    }
    private void LineTimer()
    {
        if (!lineRenderer.enabled) return;
        if (lineTimer <= lineTimerDuration)
        {
            lineTimer += Time.deltaTime;
            return;
        }
        lineRenderer.enabled = false;
        lineTimer = 0f;
    }
}