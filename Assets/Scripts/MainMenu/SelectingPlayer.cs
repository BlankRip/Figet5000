using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingPlayer : MonoBehaviour
{
    [SerializeField] GameObject[] displaySetObjs;
    int currentSelected;
    int previousSelected;

    // Start is called before the first frame update
    void Start()
    {
        currentSelected = PlayerPrefs.GetInt("PlayerIndex");
        UpdatePlayer();
    }

    public void ChangePlayerUp()
    {
        if(currentSelected < displaySetObjs.Length - 1)
            currentSelected++;
        else
            currentSelected = 0;
        
        UpdatePlayer();
    }

    public void ChangePlayerDown()
    {
        if(currentSelected > 0)
            currentSelected--;
        else
            currentSelected = displaySetObjs.Length - 1;

        UpdatePlayer();
    }

    public void UpdatePlayer()
    {
        displaySetObjs[previousSelected].SetActive(false);
        displaySetObjs[currentSelected].SetActive(true);
        previousSelected = currentSelected;
    }
}
