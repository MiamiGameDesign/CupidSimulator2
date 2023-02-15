using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float shootForce, upForce, timeBetweenShooting, spread;
    public bool allowHolding, shooting, readyToShoot;
    public bool allowInvoke = true;
    public Camera fpsCam;
    public Transform attackPoint;
    private void Awake()
    {
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(allowHolding)
            shooting = Input.GetKey(KeyCode.Mouse0);
        else
            shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if(readyToShoot && shooting) {
            readyToShoot = false;
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            Vector3 targetPoint;
            if(Physics.Raycast(ray, out hit))
                targetPoint = hit.point;
            else
                targetPoint = ray.GetPoint(69);
            Vector3 directionWithoutSpread = targetPoint - attackPoint.position;
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);
            Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);
            GameObject currentArrow = Instantiate(arrow, attackPoint.position, Quaternion.identity);
            currentArrow.transform.forward = directionWithSpread.normalized;
            currentArrow.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
            currentArrow.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upForce, ForceMode.Impulse);

            if(allowInvoke) {
                Invoke("ResetShot", timeBetweenShooting);
                allowInvoke = false;
            }
            
        }
        
    }
    private void ResetShot() {
            readyToShoot = true;
            allowInvoke = true;
        }
}
