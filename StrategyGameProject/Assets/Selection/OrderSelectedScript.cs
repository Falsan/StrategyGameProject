using UnityEngine;
using System.Collections;

public class OrderSelectedScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetMouseButtonDown(1))
        {
            if(SelectableManager.instance.currentSelected.Count > 0)
            {
                GiveOrder();
            }
        }
	}

    void GiveOrder()
    {
        Vector3 moveTo = Input.mousePosition;
        for (int iter = 0; iter < SelectableManager.instance.currentSelected.Count; iter++)
        {
            SelectableManager.instance.currentSelected[iter].GetComponent<BaseUnitScript>().Move(moveTo);
        }
    }
}
