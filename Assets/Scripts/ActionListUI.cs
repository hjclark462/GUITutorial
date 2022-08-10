using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionListUI : MonoBehaviour
{
    public ActionList actionList;
    public ActionUI prefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Action a in actionList.actions)
        {
            // Make this a child of ours on creation.
            // Don't worry about specifying a position as the LayoutGroup handles that
            ActionUI ui = Instantiate(prefab, transform);
            ui.SetAction(a);
        }
    }   
}
