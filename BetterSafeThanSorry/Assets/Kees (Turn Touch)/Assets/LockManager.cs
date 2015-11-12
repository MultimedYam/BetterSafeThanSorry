using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LockManager : MonoBehaviour {

    public static LockManager instance;
    public Dictionary<int, GameObject> insideObjects;
    public Dictionary<int, GameObject> outsideObjects;

    //the right point
    public int goodPoint = 0;
    //the old point
    public int oldPoint;
    
    public string richting;
    private int afstand;

    public Text leftOrRight;
    public Text status;

	// Use this for initialization
	void Start () {
        richting = "rechts";
        leftOrRight.text = "Direction: " + richting;
        status.text = "Status: Alive"; 
        afstand = 5;
        
        oldPoint = -1;
	}

    void Awake()
    {
        instance = this;
    }


    //calls after a "click"
    public void nextValues()
    {
        int newValue = Random.Range(1, 3);
        afstand = 5;
        Debug.Log("Next afstand: " + afstand);    

        //if(richting.Equals("rechts"))
        //{
        //    oldPoint++;
        //}
        //else
        //{
        //    oldPoint--;
        //}
        switch(newValue)
        {
            case 1:
                richting = "links";
              
                break;
            case 2:
                richting = "rechts";
                break;
        }
        leftOrRight.text = "Direction: " + richting;
   
    }

    public void compareVals(int currentID, int prevID)
    {
        oldPoint = prevID;
        if(richting.Equals("rechts"))
        {
            if(currentID > oldPoint || oldPoint == (insideObjects.Count - 1))
            {
                afstand--;
                status.text = "Correct";

                //Alles is goed.
            }
            else
            {
                status.text = "HOORT NIET NAAR LINKS";
            }
        }
        else
        {
            if (currentID < oldPoint || oldPoint == (insideObjects.Count - 1) || currentID == (insideObjects.Count - 1))
            {
                afstand--;
                status.text = "Correct";

                //Alles is goed.
            }
            else
            {
                status.text = "HOORT NIET NAAR RECHTS";
            }
        }
        if(afstand == 0)
        {
            nextValues();
        }
    }

	
}
