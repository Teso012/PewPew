using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PEWPEW : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;

    public GameObject Bullet;
    public Transform GunTip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;

        GameObject Pew = Instantiate(Bullet, GunTip.position, GunTip.rotation);
        Bullet.GetComponent<Rigidbody>().AddForce(GunTip.forward * 90f, ForceMode.Impulse);

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            
            AimTrain target = hit.transform.GetComponent<AimTrain>();
            if (target != null) 
            {
                target.getDamage(15);
                
                Debug.Log(hit.transform.name);
            }
        }
    }
}
