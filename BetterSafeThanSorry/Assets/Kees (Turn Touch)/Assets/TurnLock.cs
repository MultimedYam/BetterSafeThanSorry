using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurnLock : MonoBehaviour {

    //rotationspeed
    public float speed;
    private float x;
    private float y;
    //Debug variabeles:
    public Text XValue;
    public Text YValue;
    public Text MousePositionText;
    //Mouse-position
    private Vector2 mousePosition;

	// Use this for initialization
	void Start () {
        //If no speed is selected.
        if (speed == 0)
        {
            speed = 5;
        }

        //getting mouse postion
        mousePosition = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount > 0)
        {
            useTouch();
        }
        else
        {
            useMouse();
        }            
	}

    public void useTouch()
    {
        speed = 0.1f;

        x = Input.touches[0].deltaPosition.x;
        y = Input.touches[0].deltaPosition.y;

        mousePosition = new Vector2(Input.touches[0].position.x, Input.touches[0].position.y);

        //test cooordinates
        drawValues();

        //rotates the lock
        //if the cursor is in the upper-right section
        if ((double)mousePosition.x > Screen.width * 0.5 && (double)mousePosition.y > Screen.height * 0.5)
        {
            transform.rotation *= Quaternion.AngleAxis(x * speed, Vector3.back);
            transform.rotation *= Quaternion.AngleAxis(y * speed, Vector3.forward);
        }
        //if the cursor is in the bottom-right section
        else if ((double)mousePosition.x > Screen.width * 0.5 && (double)mousePosition.y < Screen.height * 0.5)
        {
            transform.rotation *= Quaternion.AngleAxis(x * speed, Vector3.forward);
            transform.rotation *= Quaternion.AngleAxis(y * speed, Vector3.forward);
        }
        //if the cursor is in the bottom-left section
        else if ((double)mousePosition.x < Screen.width * 0.5 && (double)mousePosition.y < Screen.height * 0.5)
        {
            transform.rotation *= Quaternion.AngleAxis(x * speed, Vector3.forward);
            transform.rotation *= Quaternion.AngleAxis(y * speed, Vector3.back);
        }
        //if the cursor is in the upper-left section
        else if ((double)mousePosition.x < Screen.width * 0.5 && (double)mousePosition.y > Screen.height * 0.5)
        {
            transform.rotation *= Quaternion.AngleAxis(x * speed, Vector3.back);
            transform.rotation *= Quaternion.AngleAxis(y * speed, Vector3.back);
        }

    }

    public void useMouse()
    {
        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) || Input.GetTouch(0).phase == TouchPhase.Began)
            {
                speed = 5;

                //get the mouse-position value
                x = Input.GetAxis("Mouse X");
                y = Input.GetAxis("Mouse Y");

                //getting position
                mousePosition = Input.mousePosition;

                //test cooordinates
                drawValues();

                //rotates the lock
                //if the cursor is in the upper-right section
                if ((double)mousePosition.x > Screen.width * 0.5 && (double)mousePosition.y > Screen.height * 0.5)
                {
                    transform.rotation *= Quaternion.AngleAxis(x * speed, Vector3.back);
                    transform.rotation *= Quaternion.AngleAxis(y * speed, Vector3.forward);
                }
                //if the cursor is in the bottom-right section
                else if ((double)mousePosition.x > Screen.width * 0.5 && (double)mousePosition.y < Screen.height * 0.5)
                {
                    transform.rotation *= Quaternion.AngleAxis(x * speed, Vector3.forward);
                    transform.rotation *= Quaternion.AngleAxis(y * speed, Vector3.forward);
                }
                //if the cursor is in the bottom-left section
                else if ((double)mousePosition.x < Screen.width * 0.5 && (double)mousePosition.y < Screen.height * 0.5)
                {
                    transform.rotation *= Quaternion.AngleAxis(x * speed, Vector3.forward);
                    transform.rotation *= Quaternion.AngleAxis(y * speed, Vector3.back);
                }
                //if the cursor is in the upper-left section
                else if ((double)mousePosition.x < Screen.width * 0.5 && (double)mousePosition.y > Screen.height * 0.5)
                {
                    transform.rotation *= Quaternion.AngleAxis(x * speed, Vector3.back);
                    transform.rotation *= Quaternion.AngleAxis(y * speed, Vector3.back);
                }

            }
        }
    }

    public void drawValues(){
        XValue.text = "X: " + x;
        YValue.text = "Y: " + y;
        MousePositionText.text = "Mouse Position: " + mousePosition.x + ";" + mousePosition.y;
    }
}
