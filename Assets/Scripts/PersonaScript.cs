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

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        PersonaScript other = (PersonaScript)obj;
        return Attributes.Name == other.Attributes.Name &&
               Attributes.Age == other.Attributes.Age &&
               Attributes.Country == other.Attributes.Country &&
               Attributes.HighSchool == other.Attributes.HighSchool &&
               Background == other.Background;
    }

    public override int GetHashCode()
    {
        return Attributes.Name.GetHashCode() ^
               Attributes.Age.GetHashCode() ^
               Attributes.Country.GetHashCode() ^
               Attributes.HighSchool.GetHashCode() ^
               Background.GetHashCode();
    }

    public void Start()
    {
        Level(1);
        PersonaManager.PopulateDictionary();
    }

    public void Level(int level)
    {   
        if (level == 1) {
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

        Attribute exampleAttributes3 = new Attribute(
            "John Fortnite",
            25,
            "USA",
            "Example High School",
            new string[] { "Award1", "Award2" },
            new string[] { "Hobby1", "Hobby2" }
        );

        PersonaScript examplePersona3 = new PersonaScript(
            "Some background information", new string[] { "CSE", "Math" },
            exampleAttributes3
        );

        PersonaManager.Personas.Add(examplePersona3);
        
        } else if(level == 2) {
            Debug.Log("Level 2");

            Attribute exampleAttributes1 = new Attribute(
            "John Pork",
            18,
            "Russia",
            "Example High School",
            new string[] { "Award1", "Award2" },
            new string[] { "Hobby1", "Hobby2" }
        );

        PersonaScript examplePersona1 = new PersonaScript(
            "Some background information", new string[] { "CSE", "Math" },
            exampleAttributes1
        );

        PersonaManager.Personas.Add(examplePersona1);

            Attribute exampleAttributes2 = new Attribute(
            "John Pork 2",
            18,
            "Russia",
            "Example High School",
            new string[] { "Award1", "Award2" },
            new string[] { "Hobby1", "Hobby2" }
        );

        PersonaScript examplePersona2 = new PersonaScript(
            "Some background information", new string[] { "CSE", "Math" },
            exampleAttributes2
        );

        PersonaManager.Personas.Add(examplePersona2);

        Attribute exampleAttributes4 = new Attribute(
            "John Pork 3",
            18,
            "Russia",
            "Example High School",
            new string[] { "Award1", "Award2" },
            new string[] { "Hobby1", "Hobby2" }
        );

        PersonaScript examplePersona4 = new PersonaScript(
            "Some background information", new string[] { "CSE", "Math" },
            exampleAttributes4
        );

        PersonaManager.Personas.Add(examplePersona4);
        }
        

        
        
    }
    void Update()
    {
        
    }
}
