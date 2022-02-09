using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Vector3 orignalRotation;
    public Vector3 rotation;
    public float shootDamage;
    public GameObject muzzleFlash;
    public float range = 100f;
    public AudioClip clip;
        public Camera camera;
    public AudioSource gunSound;
    public float timeFlash = 1;
    public bool isShooting = false;
    public GameObject ImpactEffect;
    // Start is called before the first frame updat
    private void Start()
    {
        muzzleFlash.SetActive(false);
    }
    public void Fire()
    {
        Shoot();
    }
    public void Shoot()
    {
        transform.localEulerAngles += rotation;
        muzzleFlash.SetActive(true);
        gunSound.PlayOneShot(clip  );
                                
        Invoke("resetShot", timeFlash);
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.gameObject.name);
        }
        if(hit.transform.gameObject.name != null)
        {
            GameObject hole = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            

        }

    }
    public void DeleteDecal()
    {
        
    }
    public void resetShot()
    {
        transform.localEulerAngles -= rotation;

        muzzleFlash.SetActive(false);
        isShooting = false;
    }
}
