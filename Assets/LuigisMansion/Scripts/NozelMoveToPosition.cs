using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NozelMoveToPosition : MonoBehaviour {

    [SerializeField]
    private Transform nozelPosNode;

    [SerializeField]
    private Transform arCameraTransform;

    [SerializeField]
    private float speedModifier;

    [SerializeField]
    private float repulsionStrength;


    [SerializeField]
    private float maxDistanceOffSet;

    [SerializeField]
    private float minDistanceOffSet;

    // Update is called once per frame
    void Update () {

        Vector3 repulsionVector = new Vector3();

        Vector3 cameraDirection = (arCameraTransform.position - transform.position);


        repulsionVector += (cameraDirection * repulsionStrength);


        repulsionVector *= -1.0f;


        Vector3 targetPosition = nozelPosNode.position;
        Vector3 directionToTarget = targetPosition - transform.position;
        float distance = directionToTarget.magnitude;
        directionToTarget.Normalize();



        targetPosition += repulsionVector;
        //get direction to each target

        if((nozelPosNode.position - transform.position).magnitude > ((targetPosition - transform.position).magnitude + maxDistanceOffSet) 
            || (nozelPosNode.position - transform.position).magnitude < ((targetPosition - transform.position).magnitude + minDistanceOffSet))

            transform.Translate((targetPosition - transform.position).normalized * Time.deltaTime * speedModifier);


        //transform.Translate(direction * Time.deltaTime);

        // look into ai project done last semester for the vector offset
        /*
            
                     __          |
                    /   \        |
                   |     |       |
                    \   /        v
                      --        /
                               /
                              /
                             /
                            v

        */


        // slow it down when it gets close

    }

   
}
