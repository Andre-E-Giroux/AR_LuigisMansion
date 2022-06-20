using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VacumFunction : MonoBehaviour {

    [SerializeField]
    private Transform vacum;

    private List<Transform> boos = new List<Transform>();



    [SerializeField]
    private float maxAngle;

    [SerializeField]
    private Transform image;

    private void Start()
    {
        image.gameObject.SetActive(false);
    }

    public void AddBoo(Transform boo)
    {
        boos.Add(boo);
    }

    public void RemoveBoo(Transform boo)
    {
        boos.Remove(boo);
    }

    public void Flash()
    {
        for (int i = 0; i < boos.Count; i++)
        {
            if(boos[i].GetComponent<BooGhost>().withinAngle)
            {
                boos[i].GetComponent<BooGhost>().Flashed();
            }
        }
    }


    public void Suck()
    {
        for (int i = 0; i < boos.Count; i++)
        {
            if (boos[i].GetComponent<BooGhost>().beenFlashed == true && boos[i].GetComponent<BooGhost>().withinAngle == true)
            {
                boos[i].GetComponent<BooGhost>().beingVacked = true;
            }
            else 
            {
            

                boos[i].GetComponent<BooGhost>().beingVacked = false;
                boos[i].GetComponent<BooGhost>().beenFlashed = false;

                boos[i].GetComponent<BooGhost>().ReCompose();


            }
        }
    }


    public void StopSuck()
    {
        for (int i = 0; i < boos.Count; i++)
        {

            boos[i].GetComponent<BooGhost>().beingVacked = false;
            boos[i].GetComponent<BooGhost>().beenFlashed = false;

            boos[i].GetComponent<BooGhost>().ReCompose();

        }
    }


    private void Update()
    {
        bool isInSight = false;
        for (int i = 0; i < boos.Count; i++)
        {
            Vector3 directionFromBoo = (boos[i].GetChild(1).transform.position - vacum.position);
            // get current angle between the current teamate and the player
            float angle = Vector3.Angle(directionFromBoo, vacum.forward);

            if(angle <= maxAngle)
            {
                isInSight = true;
                boos[i].GetComponent<BooGhost>().withinAngle = true;
               
            }
            else
            {
                boos[i].GetComponent<BooGhost>().withinAngle = false;
            }

        }
        if(isInSight && !image.gameObject.activeInHierarchy)
        {
            image.gameObject.SetActive(true);
        }
        else if(!isInSight && image.gameObject.activeInHierarchy)
        {
            image.gameObject.SetActive(false);
        }
    }

}
