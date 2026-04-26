using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed = 10f;

    public void Shot()
    {
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

    }

}
