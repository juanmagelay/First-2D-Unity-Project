using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed = 10f;

    // Shooting tiene dos overloads de Shot().
    // Shot() sin parámetros es compatible con System.Action, 
    // que es el tipo del slot shootAction en CharacterControler.
    // System.Action solo acepta métodos sin parámetros, 
    // por eso no se puede usar un único Shot() con offset opcional —
    // aunque sea opcional, la firma cambia y deja de ser compatible.
    // Shot(Vector3 offset) es para uso directo desde skills como MultiShotSkill.
    public void Shot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        bulletObj.GetComponent<Bullet>().speed = bulletSpeed;   
    }

    public void Shot(Vector3 offset)
    {
        GameObject bulletObj =Instantiate(bulletPrefab, shootPoint.position + offset, shootPoint.rotation);
        bulletObj.GetComponent<Bullet>().speed = bulletSpeed;
    }

}
