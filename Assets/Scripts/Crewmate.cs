using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crewmate : MonoBehaviour
{
    public string firstName;
    public string lastName;
    public string hobby;

    public Ship ship;
    public TextDisplay textDisplay;

    public void OnEnable()
    {
        ship = FindObjectOfType<Ship>();
        firstName = ship.GetFirstName();
        lastName = ship.GetLastName();
        hobby = ship.GetHobby();
    }
    public void KillCrewmate()
    {
        if (ship != null)
        {
            ship.RemoveCrewmate(this);
        }
        else
        {
            textDisplay.Problems();
        }
        
        Destroy(gameObject);
    }
}
