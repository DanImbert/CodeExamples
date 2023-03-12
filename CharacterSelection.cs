using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{

    private GameObject[] characterList;
    private int index;
    
    // Start is called before the first frame update
    private void Start()
    {

        index = PlayerPrefs.GetInt("CharacterSelected");
        characterList = new GameObject[transform.childCount];




        //fill array with models
        for (int i = 0; i < transform.childCount; i++)

            characterList[i] = transform.GetChild(i).gameObject;


        //toggle off renderer
        foreach (GameObject go in characterList)

            go.SetActive(false);


        //toggle on the selected character
        if (characterList[index])
            characterList[index].SetActive(true);


       
    }
    // Update is called once per frame
    public void ToggleLeft()
    {
        //Toggle off current model
        characterList[index] .SetActive(false);
        index--; //index -= 1; index = index - 1;
        if (index < 0)
            index = characterList.Length - 1;

        // Toggle on the new model
        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        //Toggle off current model
        characterList[index].SetActive(false);
        index++ ; //index -= 1; index = index - 1;
        if (index == characterList.Length)
            index = 0;


        // Toggle on the new model
        characterList[index].SetActive(true);
    }

    public void Confirm()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("ServerScreenBuild");
        PlayerPrefs.GetString("username");

    }

       
 }
