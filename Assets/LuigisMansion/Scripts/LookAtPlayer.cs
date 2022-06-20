using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

    private Transform playerCam;

	// Use this for initialization
	void Start () {
        playerCam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(2 * transform.position - playerCam.position);
	}
}
