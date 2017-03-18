using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectableManager : MonoBehaviour {

    public static SelectableManager instance = null;
    public List<GameObject> currentSelected;

    void Start ()
    {
        if (instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
	
	void Update ()
    {
        for(int iter = 0; currentSelected.Count > iter; iter++)
        {
            Debug.Log(currentSelected[iter].name);
        }
	}

    public void AddToCurrentSelected(GameObject toAdd)
    {
        currentSelected.Add(toAdd);
    }

    public void ClearCurrentSelected()
    {
        currentSelected.Clear();
    }

    
}
