using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragSelectionScript : MonoBehaviour {

    List<GameObject> allSelectableObjects = new List<GameObject>();

	// Use this for initialization
	void Start () {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        for(int iter = 0; allObjects.Length > iter; iter++)
        {
            if (allObjects[iter].GetComponent<Selectable>())
            {
                allSelectableObjects.Add(allObjects[iter]);
            }
        }
    }

    bool isSelecting = false;
    Vector3 mousePosition1;

    void Update()
    {
        // If we press the left mouse button, save mouse location and begin selection
        if (Input.GetMouseButtonDown(0))
        {
            isSelecting = true;
            mousePosition1 = Input.mousePosition;
        }
        // If we let go of the left mouse button, end selection
        if (Input.GetMouseButtonUp(0))
        {
            isSelecting = false;
        }

    }

    void OnGUI()
    {
        if (isSelecting)
        {
            SelectableManager.instance.ClearCurrentSelected();
            // Create a rect from both mouse positions
            Rect rect = GetScreenRect(mousePosition1, Input.mousePosition);
            DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));

            for (int iter = 0; allSelectableObjects.Count > iter; iter++)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(allSelectableObjects[iter].transform.position);
                if (rect.Contains(screenPos))
                {
                    allSelectableObjects[iter].GetComponent<Selectable>().SetSelected(true);
                    allSelectableObjects[iter].GetComponent<Selectable>().SetNeedsToBeAddedToSelectableManager(true);
                }
            }

        }
        else if(!isSelecting)
        {
            for (int iter = 0; allSelectableObjects.Count > iter; iter++)
            {
                if(allSelectableObjects[iter].GetComponent<Selectable>().GetNeedsToBeAddedToSelectableManager())
                {
                    SelectableManager.instance.AddToCurrentSelected(allSelectableObjects[iter]);
                    allSelectableObjects[iter].GetComponent<Selectable>().SetNeedsToBeAddedToSelectableManager(false);
                }
            }
        }
    }

    public Rect GetScreenRect(Vector3 screenPosition1, Vector3 screenPosition2)
    {
        
        // Move origin from bottom left to top left
        screenPosition1.y = Screen.height - screenPosition1.y;
        screenPosition2.y = Screen.height - screenPosition2.y;
        // Calculate corners
        Vector3 topLeft = Vector3.Min(screenPosition1, screenPosition2);
        Vector3 bottomRight = Vector3.Max(screenPosition1, screenPosition2);
        // Create Rect
        Rect newRect = Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
        return newRect;
    }

    public void DrawScreenRect(Rect rect, Color color)
    {
        GUI.color = color;
        GUI.DrawTexture(rect, WhiteTexture);
        GUI.color = Color.white;
    }

    public void DrawScreenRectBorder(Rect rect, float thickness, Color color)
    {
        // Top
        DrawScreenRect(new Rect(rect.xMin, rect.yMin, rect.width, thickness), color);
        // Left
        DrawScreenRect(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color);
        // Right
        DrawScreenRect(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), color);
        // Bottom
        DrawScreenRect(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), color);
    }

    static Texture2D _whiteTexture;
    public static Texture2D WhiteTexture
    {
        get
        {
            if (_whiteTexture == null)
            {
                _whiteTexture = new Texture2D(1, 1);
                _whiteTexture.SetPixel(0, 0, Color.white);
                _whiteTexture.Apply();
            }

            return _whiteTexture;
        }
    }
}
