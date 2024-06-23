using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : Singleton<TabManager>
{
    public GameObject[] panels;
    public Button[] tabBtns;

    private void Start()
    {
        for (int i = 0; i < tabBtns.Length; i++)
        {
            int index = i;
            tabBtns[i].onClick.AddListener(() => OnTabClicked(index));
        }
        ActivateTab(0);
    }

    void OnTabClicked(int tabIndex)
    {
        ActivateTab(tabIndex);
    }

    void ActivateTab(int tabIndex)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == tabIndex);

            tabBtns[i].interactable = (i != tabIndex);
        }
    }
}
