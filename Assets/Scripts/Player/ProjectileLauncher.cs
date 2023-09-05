using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    public bool canFire;
    public int maxProjCount;

    private float timer;
    public float fireStep;

    public Transform launchPoint;
    public GameObject projectilePrefab;
    public GameObject projectileManager;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void FireProjectile()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) + Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > fireStep)
            {
                canFire = true;
                timer = 0;
            }
        }

        // Attach to parent object for view sake
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, projectilePrefab.transform.rotation, projectileManager.transform);
        canFire = false;
    }
}
