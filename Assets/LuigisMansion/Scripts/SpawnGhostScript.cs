using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhostScript : MonoBehaviour {

    

    [SerializeField]
    private GameObject boo = null;

    private bool firstPass = false;

   
    private VacumFunction vacFunc;

	// Use this for initialization
	void Start () {
    
        GameObject temp = Instantiate(boo, transform.position, Quaternion.identity);
        vacFunc = GameObject.FindGameObjectWithTag("Vac").GetComponent<VacumFunction>();
        vacFunc.AddBoo(temp.transform);
    }
	
	// Update is called once per frame
	void Update () {
	   
	}
}
