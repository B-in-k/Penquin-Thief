﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  UI Initialiser Script (VER 1, 13-05-2020) 
 *  
 *  NOTE: Make sure all UI Elements are set to Active in the scene so that the GameObject Parameters can be initialised. This Script will handle turning these
 *      objects OFF/leaving them ON once they have all been assigned to their respective GameObjects.
 *  
 *  Description:
 *      - This script initialises various UI GameObject Parameters, creating a centralised file for Initialisation, Getting and Setting of parameters 
 *      for the Games various UI Elements.
 *      
 *      This Script should be attached to the Scenes 'Canvas' Object.
 *      
 *  Changelog:
 *      - 13-05-2020 (Darcy Wilson, 32926762):
 *          - Created UIInitialiserScript Script
 *          - Created GetPauseMenuObj & GetPlayerUI GET/SET Functions
 *          - Created CheckParameters Function
 *          - Code fully commented
 *          - Tested and Currently Works
 *              - AS LONG AS ALL UI OBJECTS IN HIERARCHY ARE SET TO ACTIVE
 *      - 15-05-2020 (Darcy Wilson, 32926762):
 *          - Created usableItems & collectedItems GameObject
 *          - Created GetUsableItems & GetCollectedItems GET/SET Functions
 *          - Added For Loop to Start() to initialise GetUsableItems & GetCollectedItems
 *          - Added For Loop Check to CheckParameters() to make sure Arrays have no NULL Values
 *              
 *  Known Bugs:
 *      - N/A
*/

public class UIInitialiserScript : MonoBehaviour
{
    private static GameObject pauseMenuObj, playerUI; //Private Variables to store UI GameObjects (Cannot be changed outside of Class)
    private static GameObject[] usableItems = new GameObject[4], collectedItems = new GameObject[4]; //Private Array Variables to store UI GameObjects (Cannot be changed outside of Class)

    public static GameObject GetPauseMenuObj //GetPauseMenuObj is a GET/SET Method. Used to Initialise Pause Menu UI Object (pauseMenu in Hierarchy)
    {
        get { return pauseMenuObj; } //Used to get value when of GetPauseMenuObj when GetPauseMenuObj is called
        set { pauseMenuObj = GameObject.FindWithTag("Pause Menu"); } //Sets pauseMenuObj to GameObject with specific Tag
    }

    public static GameObject GetPlayerUI //GetPlayerUI is a GET/SET Method. Used to Initialise Player UI Object (playerUI in Hierarchy)
    {
        get { return playerUI; } //Used to get value when of GetPlayerUI when GetPlayerUI is called
        set { playerUI = GameObject.FindWithTag("Player UI"); } //Sets playerUI to GameObject with specific Tag
    }

    public static GameObject[] GetUsableItems
    {
        get { return usableItems; }
        set { usableItems = value; }
    }

    public static GameObject[] GetCollectedItems
    {
        get { return collectedItems; }
        set { collectedItems = value; }
    }

    // Start is called before the first frame update
    private void Start()
    {
        GetPauseMenuObj = gameObject; //Calls GET/SET Function for GetPauseMenuObj to initialise it
        GetPlayerUI = gameObject; //Calls GET/SET Function for GetPlayerUI to initialise it

        for(int i = 0; i < 4; i++) //A For Loop which is used to Initialise the Arrays
        {
            GetUsableItems[i] = GameObject.Find("usableItem" + i); //Calls GET/SET Function for GetUsableItems to initialise the array
            GetCollectedItems[i] = GameObject.Find("collectedItems" + i); //Calls GET/SET Function for GetCollectedItems to initialise the array
        }

        CheckParameters(); //Calls CheckParameters() function to make sure values have been set
    }

    void CheckParameters() //A Function used to make sure values have been set. If GameObject variables have NULL Value, prints out Error to Log and Exits Game
    {
        if (GetPauseMenuObj != null) //Checks to see if GameObject is set to NULL
        {
            Debug.Log("Object paired to pauseMenuObj successfully!");
        }
        else
        {
            Debug.LogError("Unable to find object with Tag 'Pause Menu'", pauseMenuObj);
            Application.Quit(); //Closes the Game
        }

        GetPauseMenuObj.SetActive(false); //Sets GetPauseMenuObj to Inactive (Should be hidden when starting game)

        if (GetPlayerUI != null) //Checks to see if GameObject is set to NULL
        {
            Debug.Log("Object paired to playerUI successfully!");
        }
        else
        {
            Debug.LogError("Unable to find object with Tag 'Player UI'", playerUI);
            Application.Quit(); //Closes the Game
        }

        for (int i = 0; i < 4; i++) //The For Loop goes through the entire array to check for a NULL Value
        {
            if (GetUsableItems[i] != null) //Checks to see if GameObject is set to NULL
            {
                Debug.Log("Object usableItem" + i + " paired to playerUI successfully!");
            }
            else
            {
                Debug.LogError("Unable to find object with Name 'usableItem" + i, usableItems[i]);
                Application.Quit(); //Closes the Game
            }

            if (GetCollectedItems[i] != null) //Checks to see if GameObject is set to NULL
            {
                Debug.Log("Object collectedItems" + i + " paired to playerUI successfully!");
            }
            else
            {
                Debug.LogError("Unable to find object with Name 'usableItem" + i, collectedItems[i]);
                Application.Quit(); //Closes the Game
            }
        }
    }
}

/*
 * References:
 *      - https://docs.unity3d.com/ScriptReference/Debug.LogError.html
 *      - https://www.w3schools.com/cs/cs_properties.asp
 *      - https://docs.unity3d.com/ScriptReference/Application.Quit.html
 *      - https://docs.unity3d.com/ScriptReference/GameObject.FindWithTag.html
 *      - https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html
 *      - https://www.w3schools.com/cs/cs_arrays.asp
 *      - https://docs.unity3d.com/ScriptReference/GameObject.Find.html
*/
