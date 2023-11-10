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


    //Access names from the Crewmate script and store them here


    // Start is called before the first frame update
    void Start()
    {
        CrewmateApplication();

    }


    // Update is called once per frame
    void Update()
    {
    
    }

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
}
