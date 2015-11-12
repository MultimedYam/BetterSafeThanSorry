using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class lockTrigger : MonoBehaviour {

    //private bool firstHit = false;
    private int triggercount = 0;
    private GameObject lastObject; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    public int findGameObjectID(GameObject go)
    {
        for(int i = 0; i < LockManager.instance.insideObjects.Count; i++)
        {
            if(LockManager.instance.insideObjects[i].Equals(go))
            {
                return i;
            }
        }

        return 0;
    }

    void OnTriggerEnter(Collider col)
    {
        int dictIndex = 0; 
            if (col.gameObject.tag == "clickPoint")
            {
                if(triggercount > 0)
                {
                    foreach (KeyValuePair<int, GameObject> key in LockManager.instance.insideObjects)
                    {
                        if (col.gameObject.Equals(key.Value))
                        {
                            if(!col.gameObject.Equals(lastObject))
                            {

                                LockManager.instance.compareVals(key.Key, findGameObjectID(lastObject));
                                lastObject = col.gameObject;
                                Debug.Log("Current: " + key.Key + "|| old : " + LockManager.instance.oldPoint);
                            }
                            else
                            {
                                
                            }
                        }
                        dictIndex++;
                    }
                }
                else
                {
                    triggercount++;
                }
             
            }
        
      
    }
}
