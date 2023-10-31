using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Crewmate crewmate;
    public string firstName;
    public string lastName;
    public string candidateHobby;
    public bool isParasite;




    // Start is called before the first frame update
    void Start()
    {
        //Access names from the Crewmate script and store them here

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void CrewmateApplication()
    {
        firstName = crewmate.firstNames.ElementAt(1);

    }
}
