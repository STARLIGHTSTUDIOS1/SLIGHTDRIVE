using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootin : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public GameObject shootEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bulet =Instantiate(bulletPrefab, firepoint.position, transform.rotation);
        Rigidbody2D rb = bulet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
        GameObject effect = Instantiate(shootEffect, firepoint.position, transform.rotation);
        Destroy(effect, 0.05f);
    }
}
