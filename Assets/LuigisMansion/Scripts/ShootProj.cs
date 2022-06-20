using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProj : MonoBehaviour {

    [SerializeField]
    private GameObject projectileGameobject;

    [SerializeField]
    private Transform spawnProjectilePoint;

    [SerializeField]
    private float projSpeed = 1;

    public void SpawnProjectile()
    {
        GameObject temp = Instantiate(projectileGameobject, new Vector3(spawnProjectilePoint.position.x, spawnProjectilePoint.position.y, spawnProjectilePoint.position.z), spawnProjectilePoint.rotation);
        temp.GetComponent<Rigidbody>().AddForce(-temp.transform.forward * projSpeed);
    }


}
