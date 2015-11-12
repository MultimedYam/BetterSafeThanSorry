using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TickPlaceGenerator : MonoBehaviour {

    public int totalBlocks;
    public GameObject clickPoint;
    private float heigth;
    private float width;
    //cube position
    private float xValue;
    private float yValue;

    //dictionary
    public bool isInside;

    //Dictionary for gameobject values.
    public Dictionary<int, GameObject> insideObjects;

	// Use this for initialization
	void Start () {
        xValue = this.GetComponent<Renderer>().bounds.size.x / 2;
        yValue = this.GetComponent<Renderer>().bounds.size.y / 2;
    
        insideObjects = new Dictionary<int, GameObject>();
        //spawn ticks
        spawnTicks(totalBlocks);
	}
	
	// Update is called once per frame
	void Update () {

        if (insideObjects.Count > 0)
        {
            //Check dot objects. 
        }


	    
	}

    public void spawnTicks(int totblocks)
    {
        for (int i = 0; i < totblocks; i++)
        {
            //multiply 'i' by '1.0f' to ensure the result is a fraction
            float pointNum = (i * 1.0f) / totblocks;

            //angle along the unit circle for placing points
            float angle = pointNum * Mathf.PI * 2;

            float x = Mathf.Sin(angle) * xValue;
            float y = Mathf.Cos(angle) * yValue;


            //Nieuwe plek berekenen.
            Vector3 v = new Vector3(x, y, (float)-1);
            //De lane toevoegen
            GameObject obj = (GameObject)Instantiate(clickPoint);
            //Positie
            obj.transform.position = v;
            //
            obj.transform.SetParent(this.transform);
            obj.name += i;
            insideObjects.Add(i, obj);
        }  

        if(isInside)
        {
            LockManager.instance.insideObjects = insideObjects;
            //managerklasse > naar dictionary van binnenste. 
        }
        else
        {

        }
    }
}
