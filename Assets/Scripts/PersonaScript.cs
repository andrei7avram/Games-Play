using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Attribute
{
    public string Name;
    public int Age;
    public string Country;
    public string HighSchool;
    public string[] Awards;
    public string[] Hobbies;
 
    public Attribute(string name, int age, string country, string highSchool, string[] awards, string[] hobbies )
    {
        Name = name;
        Age = age;
        Country = country;
        HighSchool = highSchool;
        Awards = awards;
        Hobbies = hobbies;
    }
}

public class PersonaScript : MonoBehaviour
{
    public string Background;
    public string[] correctAnswers;
    public Attribute Attributes;
    public PersonaScript(string background, string[] correct, Attribute attributes)
    {
        Background = background;
        correctAnswers = correct;
        Attributes = attributes;
    }
    void Start()
    {
        Level1();
    }

    public void Level1()
    {
        Attribute exampleAttributes = new Attribute(
            "John Doe",
            25,
            "USA",
            "Example High School",
            new string[] { "Award1", "Award2" },
            new string[] { "Hobby1", "Hobby2" }
        );

        PersonaScript examplePersona = new PersonaScript(
            "Some background information", new string[] { "CSE", "Math" },
            exampleAttributes
        );

        PersonaManager.Personas.Add(examplePersona);

        Attribute attributes1 = new Attribute(
            "Andrei",
            25,
            "Romania",
            "Example High School",
            new string[] { "Award1", "Award2" },
            new string[] { "Hobby1", "Hobby2" }
        );

        PersonaScript persona1 = new PersonaScript(
            "TU/Eindhoven", new string[] { "Industrial", "Math" },
            attributes1
        );

        PersonaManager.Personas.Add(persona1);
        PersonaManager.PopulateDictionary();
    }
    void Update()
    {
        
    }
}
