using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Ship : MonoBehaviour
{
    public GameObject crewmatePrefab;

    public CrewmateGenerator crewmate;
    private string candidateFirstName;
    private string candidateLastName;
    private string candidateHobby;

    private int randomIndex; 
    private bool isParasite;
    private bool waitForInput;


    //Add list here to store new crewmates
    public List<Crewmate> crewList = new List<Crewmate>();

    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        waitForInput = false;
        CrewmateApplication();
    }

    public void EndTurn()
    {
        //Complete any checks before ending the turn
        NewTurn();
    }
    private void NewTurn()
    {
        CrewmateApplication();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForInput)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (!isParasite) 
                {
                    ApproveCandidate();
                }
                else
                {
                    if (crewList.Count > 0) 
                    {
                        CrewmateMurderTime();
                    }
                    else
                    {
                        Debug.Log($"{candidateFirstName} {candidateLastName} was secretly a parasite! \nThey couldn't find any humans to kill so they got bored and left!");
                        waitForInput = false;
                        EndTurn();
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                DeclineCandidate();
                
            }
        }
    }

    //Function that generates a candidates name and hobby
    private void CrewmateApplication()
    {
        HumanOrParasite();

        candidateFirstName = crewmate.GetFirstName();
        candidateLastName = crewmate.GetLastName();

        if (isParasite)
        {
            candidateHobby = crewmate.GetParasiteHobby();
        }
        else
        {
            candidateHobby = crewmate.GetHumanHobby();
        }

        //Debug.Log($"Is a Parasite: {isParasite}");
        
        Debug.Log($"This candidates name is {candidateFirstName} {candidateLastName} , Their favourite thing to do is {candidateHobby}.\n|A| - Accept |D| - Decline");

        waitForInput = true;
    }

    //Function that randomly decideds if the candidate is a human or a parasite
    private void HumanOrParasite()
    {
        randomIndex = Random.Range(0, 10);
        //Debug.Log($"Random Index: {randomIndex}");

        if (randomIndex > 5)
        {
            isParasite = true;
        }
        else
        {
            isParasite = false;
        }
    }

    //Function for declining candidate and not adding them to the list
    private void DeclineCandidate()
    {
        waitForInput = false;
        Debug.Log("Candidate has been rejected!\n");
        //Clear candidate name and generate new candidate
       
        EndTurn();
    }

    //Function for adding candidate to crew list, while instantiating an object
    private void ApproveCandidate()
    {
        waitForInput = false;
        Debug.Log("Candidate has been approved!\n");

        //Instantiate crewmate object from prefab
        float x = Random.Range(-10f, 10f);
        float y = 0f;
        float z = Random.Range(-10f, 10f);
        Vector3 spawnPosition = new Vector3(x, y, z);
        GameObject clone = Instantiate(crewmatePrefab, spawnPosition, Quaternion.identity) as GameObject;
        crewList.Add(clone.GetComponent<Crewmate>());

        EndTurn();
    }

    public string GetFirstName()
    {
        return candidateFirstName;
    }

    public string GetLastName()
    {
        return candidateLastName;
    }

    public string GetHobby()
    {
        return candidateHobby;
    }

    //Function for eliminating crewmates if a parasite is accepted (all crewmates with a randomly picked hobby)
    private void CrewmateMurderTime()
    {
        //Randomly pick a hobby from current crewmates
        string targetHobby = crewList[(Random.Range(0, crewList.Count))].GetComponent<Crewmate>().hobby;

        Debug.Log($"{candidateFirstName} {candidateLastName} was secretly a parasite! \nThey are going to kill everyone who enjoys {targetHobby}");

        //Remove crewmates from list (loop through collection and check 'if' any have the same hobby)

        for (int i = 0; i < crewList.Count; i++)
        {
            //Check each item in the list for the targeted hobby
            //Remove each 'targeted' crewmate and destroy their objects 

            if (crewList[i].GetComponent<Crewmate>().hobby == targetHobby)
            {
                crewList[i].GetComponent<Crewmate>().KillCrewmate();
            }
        }
    }
     public void RemoveCrewmate(Crewmate crewmateToRemove)
    {
        crewList.Remove(crewmateToRemove);
    }
  
}
