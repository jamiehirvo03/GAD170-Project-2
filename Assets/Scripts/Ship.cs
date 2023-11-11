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


    //Add list here to store new crewmates


    // Start is called before the first frame update
    void Start()
    {
        CrewmateApplication();

    }


    // Update is called once per frame
    void Update()
    {
    
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

        Debug.Log($"First Name: {firstName}");
        Debug.Log($"Last Name: {lastName}");
        Debug.Log($"Is a Parasite: {isParasite}");
        Debug.Log($"Their favoruite thing is: {candidateHobby}");
        
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
        //Clear candidate name and generate new candidate
    }

    //Function for adding candidate to crew list, while instantiating an object
    private void ApproveCandidate()
    {
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
