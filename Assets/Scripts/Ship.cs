using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Crewmate crewmate;
    private string firstName;
    private string lastName;
    private string candidateHobby;

    private int randomIndex; 
    private bool isParasite;
    private bool waitForInput = false;


    //Add list here to store new crewmates


    // Start is called before the first frame update
    void Start()
    {
        CrewmateApplication();

    }


    // Update is called once per frame
    void Update()
    {
        while(waitForInput)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                ApproveCandidate();
                break;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                DeclineCandidate();
                break;
            }
        }       
    }

    //Function that generates a candidates name and hobby
    private void CrewmateApplication()
    {
        HumanOrParasite();

        firstName = crewmate.GetFirstName();
        lastName = crewmate.GetLastName();

        if (isParasite)
        {
            candidateHobby = crewmate.GetParasiteHobby();
        }
        else
        {
            candidateHobby = crewmate.GetHumanHobby();
        }

        Debug.Log($"Is a Parasite: {isParasite}");
        
        Debug.Log($"This candidates name is {firstName} {lastName} , Their favourite thing to do is {candidateHobby}.");

        waitForInput = true;
        Debug.Log("|A| - Accept \n|D| - Decline");
    }

    //Function that randomly decideds if the candidate is a human or a parasite
    private void HumanOrParasite()
    {
        randomIndex = Random.Range(0, 10);
        Debug.Log($"Random Index: {randomIndex}");

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
        Debug.Log("Candidate has been rejected!");
        //Clear candidate name and generate new candidate

        //CrewmateApplication();
    }

    //Function for adding candidate to crew list, while instantiating an object
    private void ApproveCandidate()
    {
        Debug.Log("Candidate has been approved!");
        //Add candidate info to appropriate lists
       //Instantiate crewmate object from prefab
    }
    
    //Function for eliminating crewmates if a parasite is accepted (all crewmates with a randomly picked hobby)
    private void CrewmateMurderTime()
    {
        //Randomly pick a hobby from current crewmates
        //Remove crewmates from list (loop through collection and check 'if' any have the same hobby)
        //Destroy objects
    }

  
}
