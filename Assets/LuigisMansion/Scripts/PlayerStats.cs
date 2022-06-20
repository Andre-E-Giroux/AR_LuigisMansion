using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    private float HP;

    [SerializeField]
    private RectTransform hpBar;

    private float tempXSize;
	// Use this for initialization
	void Start () {
        HP = 100;
        tempXSize = hpBar.localScale.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Projectile")
        {
            HP -= 20;
            hpBar.localScale = new Vector3(HP / 100 * tempXSize, hpBar.localScale.y, hpBar.localScale.z);
            Destroy(other.gameObject);
        }
    }
}
