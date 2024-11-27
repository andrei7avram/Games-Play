using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonaManager : MonoBehaviour
{
    public static List<PersonaScript> Personas = new List<PersonaScript>();
    public PersonaScript currentPersona;
    private int index = 0;
    void Start()
    {
        
    }

    void Update()
    {   
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            DisplayAllPersonas();
        } else if (Input.GetKeyDown(KeyCode.C))
        {
            DisplayCurrentPersona();
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            IncrementCurrentPersona();
        }
    }

    public void DisplayAllPersonas()
    {
        foreach (var persona in Personas)
        {
            Debug.Log("Name: " + persona.Attributes.Name);
            Debug.Log("Age: " + persona.Attributes.Age);
            Debug.Log("Country: " + persona.Attributes.Country);
            Debug.Log("HighSchool: " + persona.Attributes.HighSchool);
            Debug.Log("Awards: " + string.Join(", ", persona.Attributes.Awards));
            Debug.Log("Hobbies: " + string.Join(", ", persona.Attributes.Hobbies));
            Debug.Log("Background: " + persona.Background);
        }
    }

    public void DisplayCurrentPersona()
    {
        Debug.Log("Name: " + currentPersona.Attributes.Name);
        //Debug.Log("Age: " + currentPersona.Attributes.Age);
        //Debug.Log("Country: " + currentPersona.Attributes.Country);
        //Debug.Log("HighSchool: " + currentPersona.Attributes.HighSchool);
        //Debug.Log("Awards: " + string.Join(", ", currentPersona.Attributes.Awards));
        //Debug.Log("Hobbies: " + string.Join(", ", currentPersona.Attributes.Hobbies));
        //Debug.Log("Background: " + currentPersona.Background);
    }

    public PersonaScript IncrementCurrentPersona()
    {   
        if (Personas.Count > 0 && index < Personas.Count)
        {   
            
            currentPersona = Personas[index];
            index++;
        }else if (index == Personas.Count)
        {
            index = 0;
            currentPersona = Personas[index];
            index++;
        }
        Debug.Log(index + " " + Personas.Count);

        return currentPersona;
    }
}
