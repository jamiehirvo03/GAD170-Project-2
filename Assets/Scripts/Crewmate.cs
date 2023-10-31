using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crewmate : MonoBehaviour
{
    private bool isParasite;
   
    public List<string> firstNames = new List<string>(15) { "Bob", "Dougie", "Hannah", "Jenny", "Peter", "Melissa", "Hugo", "Natasha", "Timothy", "Nancy", "Johnny", "Robert", "Chloe", "Emily", "Mike" };
    public List<string> lastNames = new List<string>(26) { "A.", "B.", "C.", "D.", "E.", "F.", "G.", "H.", "I.", "J.", "K.", "L.", "M.", "N.", "O.", "P.", "Q.", "R.", "S.", "T.", "U.", "V.", "W.", "X.", "Y.", "Z." };
    public List<string> humanHobbies = new List<string>(5) { "Bowling", "Surfing", "Stargazing", "Kareoke", "Reading" };
    public List<string> parasiteHobbies = new List<string>(5) { "Invasion", "Moon Fishing", "Blending In", "Sabotage", "Planetary Pool" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
