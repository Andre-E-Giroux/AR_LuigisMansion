using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooAI : MonoBehaviour {

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float rotateAroundSpeedMax;

    [SerializeField]
    private float rotateAroundSpeed;


    private bool rotateAroundBool = false;



    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float minDistance = 2.0f;


    private ShootProj sProjectile;

    private BooGhost bG;

    // Use this for initialization
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        sProjectile = transform.GetComponent<ShootProj>();
        bG = transform.GetComponent<BooGhost>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!bG.beingVacked && !bG.beenFlashed)
        {
            float distance = (playerTransform.position - transform.position).magnitude;
            if (distance >= minDistance && !rotateAroundBool)
            {
                Debug.Log("Player is outside of min range");
                transform.Translate((Vector3.forward * speed));
            }
            else
            {
                if (rotateAroundBool == false)
                {
                    InvokeRepeating("CallFunction", 2, 6);
                    rotateAroundBool = true;
                }
            }


            if (rotateAroundBool)
            {
                Debug.Log("Rotating");
                RotateAroundObject(1);
            }
        }


        else if (!bG.beingVacked && bG.beenFlashed)
        {
            CancelInvoke("CallFunction");
        }


        else
        {
            if (bG.beingVacked)
            {
                float distance = (playerTransform.position - transform.position).magnitude;
                if (distance >= minDistance && !rotateAroundBool)
                {
                    Debug.Log("Player is outside of min range");
                    transform.Translate((Vector3.forward * speed));
                }
                else
                {
                    if (rotateAroundBool == false)
                    {
                        InvokeRepeating("CallFunction", 2, 4);
                        rotateAroundBool = true;
                    }
                }


                if (rotateAroundBool)
                {
                    Debug.Log("Rotating");
                    RotateAroundObject(1.5f);
                }
            }
        }

    }

    private void CallFunction()
    {
        sProjectile.SpawnProjectile();
    }

    private void RotateAroundObject(float speedModify)
    {
        if(rotateAroundSpeed != rotateAroundSpeedMax)
        {
            if (rotateAroundSpeed < rotateAroundSpeedMax)
                rotateAroundSpeed += 0.5f;
            else
                rotateAroundSpeed = rotateAroundSpeedMax;
        }
        transform.RotateAround(playerTransform.position, Vector3.up, rotateAroundSpeed * speedModify * Time.deltaTime);
      //  transform.RotateAround(playerTransform.position, Vector3.forward, rotateAroundSpeed * Random.Range(-2,2) * speedModify * Time.deltaTime);
    }

}
