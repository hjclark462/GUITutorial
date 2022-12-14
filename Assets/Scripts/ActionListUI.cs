using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionListUI : MonoBehaviour
{
    public ActionList actionList;
    public ActionUI prefab;
    List<ActionUI> uis = new List<ActionUI>();
    LayoutGroup layoutGroup;
    ContentSizeFitter contentSizeFitter;

    // Start is called before the first frame update
    void Start()
    {
        layoutGroup = GetComponent<LayoutGroup>();
        contentSizeFitter = GetComponent<ContentSizeFitter>();
        StartCoroutine(UpdateUI());

        actionList.onChanged.AddListener(() => { StartCoroutine(UpdateUI()); });
    }

    IEnumerator UpdateUI()
    {
        contentSizeFitter.enabled = true;
        layoutGroup.enabled = true;
        yield return new WaitForEndOfFrame();

        Player player = actionList.GetComponent<Player>();

        // Step through the dictionary, and remove any UIs associated with actions no
        // longer in our list
        for (int i = 0; i < actionList.actions.Length; i++)
        {
            // If we need to add another UI to our list, create it here
            if (i >= uis.Count)
            {
                // Make this a child of ours on creation.
                // Don't worry abour specifying a position as the LayoutGroup handles that
                uis.Add(Instantiate(prefab, transform));

                // Pass the player ref through and hook up any buttons
                uis[i].Init(prefab.player);
            }
            uis[i].gameObject.SetActive(true);
            uis[i].SetAction(actionList.actions[i]);
            // Make sure they all appear in order again
            uis[i].transform.SetAsLastSibling();
        }

        // disable any remaining UIs if the list has shrunk on us
        for (int i = actionList.actions.Length; i < uis.Count; i++)
        {
            uis[i].gameObject.SetActive(false);
        }

        yield return new WaitForEndOfFrame();

        contentSizeFitter.enabled = false;
        layoutGroup.enabled = false;
    }
}
