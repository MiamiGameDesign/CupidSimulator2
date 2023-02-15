using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float shootForce, upForce, timeBetweenShooting, reloadTime;
    public int magSize, arrowsPerTap;
    int arrowsLeft, arrowsShot;
    public Rigidbody playerRb;
    public float recoilForce;
    bool shooting, readyToShoot, reloading;
    public bool allowInvoke, allowHolding = true;
    public Camera fpsCam;
    public Transform attackPoint;
    public TextMeshProUGUI ammunitionDisplay;
    private void Awake()
    {
        readyToShoot = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if(allowHolding)
            shooting = Input.GetKey(KeyCode.Mouse0);
        else
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        if (Input.GetKeyDown(KeyCode.R) && arrowsLeft < magSize && !reloading) Reload();
        if (readyToShoot && shooting && !reloading && arrowsLeft <= 0) Reload();
        if(readyToShoot && shooting && !reloading && arrowsLeft > 0) {
            arrowsShot = 0;
            readyToShoot = false;
            Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            Vector3 targetPoint;
            if(Physics.Raycast(ray, out hit))
                targetPoint = hit.point;
            else
                targetPoint = ray.GetPoint(69);
            Vector3 directionWithoutSpread = targetPoint - attackPoint.position;
            Vector3 directionWithSpread = directionWithoutSpread + new Vector3(0, 0, 0);
            GameObject currentArrow = Instantiate(arrow, attackPoint.position, Quaternion.identity);
            currentArrow.SetActive(true);
            currentArrow.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
            currentArrow.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upForce, ForceMode.Impulse);
            arrowsLeft--;
            arrowsShot++;
            if(allowInvoke) {
                Invoke("ResetShot", timeBetweenShooting);
                allowInvoke = false;
                playerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
            }
            if (arrowsShot < arrowsPerTap && arrowsLeft > 0)
            Invoke("Shoot", timeBetweenShooting);
            currentArrow.transform.parent = null;
            currentArrow.transform.localScale = new Vector3(0.7f, 1.5f, 35);
            currentArrow.transform.localEulerAngles = arrow.transform.localEulerAngles;

        }
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(arrowsLeft / arrowsPerTap + " / " + magSize / arrowsPerTap);
    }
    private void ResetShot() {
        readyToShoot = true;
        allowInvoke = true;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        //Fill magazine
        arrowsLeft = magSize;
        reloading = false;
    }
}
