using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxCollResize : MonoBehaviour {

    private Camera c_Component;
    private BoxCollider b_Component;
	// Use this for initialization
	void Start () {
        c_Component = transform.GetComponent<Camera>();
        b_Component = transform.GetComponent<BoxCollider>();
        b_Component.size = new Vector3(c_Component.rect.width, c_Component.rect.height, b_Component.size.z);
    }
	
	// Update is called once per frame
	void Update () {
        b_Component.size = new Vector3(c_Component.rect.width, c_Component.rect.height, b_Component.size.z);
    }
}
