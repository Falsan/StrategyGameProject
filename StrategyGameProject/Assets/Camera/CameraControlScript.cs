using UnityEngine;
using System.Collections;

public class CameraControlScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = Vector3.zero;

        if(Input.GetKey(KeyCode.UpArrow))
        {
            direction.y = direction.y + 0.1f;
            direction.z = direction.z + 0.1f;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            direction.y = direction.y - 0.1f;
            direction.z = direction.z - 0.1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = direction.x - 0.2f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = direction.x + 0.2f;
        }

        if(Input.mousePosition.y > Screen.height - 20.0f)
        {
            direction.y = direction.y + 0.1f;
            direction.z = direction.z + 0.1f;
        }
        if (Input.mousePosition.y < 0 + 20.0f)
        {
            direction.y = direction.y - 0.1f;
            direction.z = direction.z - 0.1f;
        }
        if(Input.mousePosition.x > Screen.width - 20.0f)
        {
            direction.x = direction.x + 0.2f;
        }
        if (Input.mousePosition.x < 0 + 20.0f)
        {
            direction.x = direction.x - 0.2f;
        }

        gameObject.transform.Translate(direction);
    }
}
