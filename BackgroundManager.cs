using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BackgroundManager : MonoBehaviour
{
    private GameObject[] backgroundManager;
    private int index;


    private void Start()
    {
        backgroundManager = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)

            backgroundManager[i] = transform.GetChild(i).gameObject;


        //toggle off 
        foreach (GameObject song in backgroundManager)

            song.SetActive(false);


        //toggle on the selected 
        if (backgroundManager[index])
            backgroundManager[index].SetActive(true);
    }

    public void SwitchBackgroundR()
    {
        backgroundManager[index].SetActive(false);
        index++; //index -= 1; index = index - 1;
        if (index == backgroundManager.Length)
            index = 0;


        // Toggle on the new back
        backgroundManager[index].SetActive(true);
    }

    public void SwitchBackgroundL()
    {
        //Toggle off current model
        backgroundManager[index].SetActive(false);
        index--; //index -= 1; index = index - 1;
        if (index < 0)
            index = backgroundManager.Length - 1;

        // Toggle on the new model
        backgroundManager[index].SetActive(true);
    }
}
