using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Range(0,2)]
    public float fireRate = 1f;
    [SerializeField]
    [Range(1, 10)]
    int damage = 1;
    private float timer;
    [SerializeField]
    Transform firePoint; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0;
                FireGun();
            }
        }
    }
    private void FireGun()
    {
        Debug.DrawRay(firePoint.position, firePoint.forward*50, Color.red, 2f);
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, 100))
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
