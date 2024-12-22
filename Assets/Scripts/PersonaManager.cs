using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PersonaManager : MonoBehaviour
{
    public static List<PersonaScript> Personas = new List<PersonaScript>();

    public static Dictionary<PersonaScript, int> PersonaDictionary = new Dictionary<PersonaScript, int>();

    public PersonaScript levelCreator;
    public bool isLevelComplete = false;
    public PersonaScript currentPersona;
    private int index = 0;

    public int finalScore = 0;

    public String selectedCourse;

    public List<TextMeshProUGUI> textMeshProObjects;
    public static void PopulateDictionary()
    {
        int value = 0;
        foreach (var persona in Personas)
        {
            if (!PersonaDictionary.ContainsKey(persona))
            {
                PersonaDictionary.Add(persona, value);
                value++;
            }
        }
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
        UpdateTextMeshProObjects();
    }

    public PersonaScript IncrementCurrentPersona()
    {   
        if (Personas.Count > 0 && index < Personas.Count)
        {   
            
            currentPersona = Personas[index];
            index++;
        }else if (index == Personas.Count)
        {
            //index = 0;
            //currentPersona = Personas[index];
            //index++;
            isLevelComplete = true;
            Debug.Log("No more personas");
        }

        return currentPersona;
    }

    public void UpdateTextMeshProObjects()
    {
        textMeshProObjects[0].text = "Name: " + currentPersona.Attributes.Name;
        textMeshProObjects[1].text = "Age: " + currentPersona.Attributes.Age.ToString();
        textMeshProObjects[2].text = "Country: " + currentPersona.Attributes.Country;
        textMeshProObjects[3].text = "HighSchool: " + currentPersona.Attributes.HighSchool;
        textMeshProObjects[4].text = "Awards: " + string.Join(", ", currentPersona.Attributes.Awards);
        textMeshProObjects[5].text = "Hobbies: " + string.Join(", ", currentPersona.Attributes.Hobbies);
        textMeshProObjects[6].text = "Background: " + currentPersona.Background;
    }

    public void SetSelectedCourseCSE()
    {
        selectedCourse = "CSE";
    }

    public void SetSelectedCourseMath()
    {
        selectedCourse = "Math";
    }

    public void SetSelectedCourseIndustrial()
    {
        selectedCourse = "Industrial";
    }

    public void evaluateAnswer()
    {  
            if (currentPersona.correctAnswers[0] == selectedCourse)
            {
                Debug.Log("Correct");
                PersonaDictionary[currentPersona] =  2;
                finalScore += 2;
                Debug.Log(finalScore);
                IncrementCurrentPersona();
                DisplayCurrentPersona();
                if (isLevelComplete)
                {
                    FinishLevel();
                }
            } else if (currentPersona.correctAnswers[1] == selectedCourse)
            {
                Debug.Log("Partially Correct");
                PersonaDictionary[currentPersona] =  1;
                finalScore += 1;
                Debug.Log(finalScore);
                IncrementCurrentPersona();
                DisplayCurrentPersona();
                if (isLevelComplete)
                {
                    FinishLevel();
                }
            } else
            {
                Debug.Log("Incorrect");
                PersonaDictionary[currentPersona] =  0;
                Debug.Log(finalScore);
                IncrementCurrentPersona();
                DisplayCurrentPersona();
                if (isLevelComplete)
                {
                    FinishLevel();
                }
            }
    }

    public void ClearPersonas()
    {
        List<PersonaScript> keysToRemove = new List<PersonaScript>();

        foreach (var kvp in PersonaDictionary)
        {
            if (kvp.Value == 2)
            {
                keysToRemove.Add(kvp.Key);
            }
        }

        foreach (var key in keysToRemove)
        {
            PersonaDictionary.Remove(key);
        }
    }

    public void FinishLevel(){
        Debug.Log("Final Score: " + finalScore);
        NextLevel();
        ClearPersonas();
    }

    public void NextLevel(){
        int currentlevel = 1;
        currentlevel++;
        levelCreator.Level(currentlevel);
    }
}

