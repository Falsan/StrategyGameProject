using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {

    bool selectable;
    bool isSelected;
    bool needsToBeAddedToSelectableManager;

	// Use this for initialization
	void Start () {

        selectable = true;
        isSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool QuerySelectable()
    {
        return selectable;
    }

    public void SetSelected(bool toSet)
    {
        isSelected = toSet;
  
    }

    public void SetNeedsToBeAddedToSelectableManager(bool toSet)
    {
        needsToBeAddedToSelectableManager = toSet;
    }

    public bool GetNeedsToBeAddedToSelectableManager()
    {
        return needsToBeAddedToSelectableManager;
    }
}
