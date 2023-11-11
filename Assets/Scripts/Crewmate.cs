using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crewmate : MonoBehaviour
{
    public string firstName;
    public string lastName;
    public string hobby;

    public Ship ship;

    public void OnEnable()
    {
        ship = FindObjectOfType<Ship>();
        firstName = ship.GetFirstName();
        lastName = ship.GetLastName();
        hobby = ship.GetHobby();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void KillCrewmate()
    {
        if(ship != null)
        {
            ship.RemoveCrewmate(this);
        }
        Destroy(gameObject);
    }
}
