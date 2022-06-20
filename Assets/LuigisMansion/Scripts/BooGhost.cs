using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooGhost : MonoBehaviour {

    [SerializeField]
    private Transform player;

 

    [SerializeField]
    private float maxHP;

    private float HP;


    [SerializeField]
    private Material matYellow;

    [SerializeField]
    private Material matDeffault;


    [SerializeField]
    private TextMesh tMesh;

    public bool withinAngle;

    public bool beenFlashed;


    [SerializeField]
    private MeshRenderer mRenderer;

    public bool beingVacked;


    public float vacumeSpeed;


    [SerializeField]
    private VacumFunction vF;

    [SerializeField]
    private GameObject ghostSheet;


    [SerializeField]
    private GameObject textHP;

	// Use this for initialization
	void Start () {
        transform.parent = null;
        player = GameObject.FindGameObjectWithTag("MainCamera").transform;
        tMesh.text = Mathf.Ceil(HP).ToString();
        textHP.SetActive(false);
        HP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(player);


       


       

        if(HP <= 0)
        {
            Destroy(gameObject);
            vF.RemoveBoo(transform);
        }

        if (!beenFlashed && !ghostSheet.activeInHierarchy)
        {
            ghostSheet.SetActive(true);
        }


        //if(withinAngle)
        //    transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>().material.color = Color.green;
        //else
        //    transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>().material.color = Color.white;


    }


    public void Flashed()
    {
        //mRenderer.material = matYellow;
        ghostSheet.SetActive(false);
        beenFlashed = true;

        textHP.SetActive(true);
    }


    private void FixedUpdate()
    {
        if (beingVacked && withinAngle)
        {
            HP -= Time.fixedDeltaTime * vacumeSpeed;

            if (!ghostSheet.activeInHierarchy)
            {
                ghostSheet.SetActive(true);
            }
            tMesh.text = Mathf.Ceil(HP).ToString();
        }
        else
        {
            if (beingVacked)
            {
                beingVacked = false;
                beenFlashed = false;
                ReCompose();
            }
        }

        

    }

    public void ReCompose()
    {
        mRenderer.material = matDeffault;
        beenFlashed = false;
        textHP.SetActive(false);
    }

}
