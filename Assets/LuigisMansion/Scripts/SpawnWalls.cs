using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour {

    private Transform wallLocation;
    private AR_Controller aR_Controller;

    [SerializeField]
    private GameObject wall;


    private GameObject wallObject;

    [SerializeField]
    private GameObject menuCnavasObject;

    [SerializeField]
    private GameObject gamePlayCanvasObject;


    [SerializeField]
    private GameObject vacuumNozel;
    private void Start()
    {
        aR_Controller = transform.GetComponent<AR_Controller>();
        gamePlayCanvasObject.SetActive(false);

        vacuumNozel.transform.GetComponent<Renderer>().enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            wallObject = Instantiate(wall, new Vector3(0, -1, 5), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            SpawnFunction();
        }

    }

    public void SpawnFunction()
    {
        if (aR_Controller.icon != null)
        {
            aR_Controller.allowTrackingPlanes = false;
            wallLocation = aR_Controller.icon.transform;

            if (wallObject == null)
            {
                wallObject = Instantiate(wall, wallLocation.position, wallLocation.rotation);
                wallObject.transform.position -= wallObject.transform.up * wallObject.transform.GetChild(0).localScale.y;
            }

            else if(wallObject.activeInHierarchy == false)
            {
                wallObject.transform.position = wallLocation.position;
                wallObject.transform.rotation = wallLocation.rotation;
                wallObject.SetActive(true);
            }

            //wallObject.transform.parent = transform;

            wallLocation.gameObject.SetActive(false);

            aR_Controller.allowIconChange = false;

            menuCnavasObject.SetActive(false);


            int numberofChildren = transform.childCount;

            for(int i = 0; i < numberofChildren; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            gamePlayCanvasObject.SetActive(true);

            vacuumNozel.transform.GetComponent<Renderer>().enabled = true;
        }
    }


    public void ResetPostionChoosing()
    {
        if (!aR_Controller.allowIconChange)
        {
            aR_Controller.allowIconChange = true;

            wallLocation.gameObject.SetActive(false);
            aR_Controller.icon.SetActive(false);

            if (wallObject != null)
            {
                wallObject.SetActive(false);
            }

        }
    }
}
