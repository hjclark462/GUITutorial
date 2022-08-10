using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionUI : MonoBehaviour
{
    public Action action;

    [Header("Child Components")]
    public Image icon;
    public TextMeshProUGUI nameTag;
    public TextMeshProUGUI descriptionTag;

    public void SetAction(Action a)
    {
        action = a;
        if (nameTag)
        {
            nameTag.text = action.actionName;
        }
        if (descriptionTag)
        {
            descriptionTag.text = action.description;
        }
        if (icon)
        {
            icon.sprite = action.icon;
            icon.color = action.color;
        }
    }
    private void Start()
    {
        if (action != null)        
        SetAction(action);
    }
}

