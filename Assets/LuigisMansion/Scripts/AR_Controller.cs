using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;

public class AR_Controller : MonoBehaviour {

    // holds the new planes that has been detected in the current frame
    private List<DetectedPlane> m_NewTrackedPlanes = new List<DetectedPlane>();

    [SerializeField]
    private GameObject gridPrefab;


    [SerializeField]
    private GameObject arCamera;

    // WALL TEST
    [SerializeField]
    private GameObject wallPrefab;
    //

    [SerializeField]
    private GameObject iconPrefab;

    public GameObject icon;

    [SerializeField]
    private Text text;

    public bool allowIconChange;


    public bool allowTrackingPlanes;



    
    // Use this for initialization
    void Start () {
        allowIconChange = true;
        allowTrackingPlanes = true;
       
    }
	
	// Update is called once per frame
	void Update () {

        // check ARcore session status
        if (allowTrackingPlanes)
        {
            // not tracking plane
            if (Session.Status != SessionStatus.Tracking)
            {
                return;
            }

            // the following function will fill m_NewTrackedPlanes with the planes that ARcore detected in the current frame
            Session.GetTrackables<DetectedPlane>(m_NewTrackedPlanes, TrackableQueryFilter.New);


            // instantiate a Grid for each TrackedPlanes
            for (int i = 0; i < m_NewTrackedPlanes.Count; i++)
            {
                GameObject grid = Instantiate(gridPrefab, Vector3.zero, Quaternion.identity, transform);
                // this function will set the position of grid and modify the vertices of the attached mesh
                grid.GetComponent<GridVisualizer>().Initialize(m_NewTrackedPlanes[i]);




            }

            // check if the user touched the screen
            Touch touch;
            if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
            {
                return;
            }

            //let's now check if the user touched any of the tracked planes

            TrackableHit hit;
            if (Frame.Raycast(touch.position.x, touch.position.y, TrackableHitFlags.PlaneWithinPolygon, out hit) && allowIconChange)
            {
                if (icon == null)
                {
                    icon = Instantiate(iconPrefab, Vector3.zero, Quaternion.identity, transform);
                }

                else if (!icon.activeInHierarchy)
                {
                    icon.SetActive(true);
                }

                // create a new anchor
                Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);

                // set the position of the icon to be the same as the hit position
                icon.transform.rotation = hit.Pose.rotation;
                icon.transform.position = hit.Pose.position;

                //text.text ="addative: " + ((icon.transform.up * icon.transform.localScale.y));

                // face icon towards camera //


                Vector3 cameraPosition = arCamera.transform.position;

                cameraPosition.y = hit.Pose.position.y;

                // rotate the portal to face the camera
                icon.transform.rotation = hit.Pose.rotation;


                // arCore will keep understanding the world and update the anchors accordingly hence we need to attach our portal to the anchor
                icon.transform.parent = anchor.transform;
                allowIconChange = false;
                
            }
        }
    }
}
