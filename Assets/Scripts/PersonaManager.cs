using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PersonaManager : MonoBehaviour
{
    public static List<PersonaScript> Personas = new List<PersonaScript>();

    public static Dictionary<PersonaScript, int> PersonaDictionary = new Dictionary<PersonaScript, int>();

    public PersonaScript levelCreator;

    private bool bell = false;

    public UnityEngine.UI.Image bioTab;
    public GameObject person1;
    public Sprite bio1;
    public GameObject person2;
    public Sprite bio2;
    
    public GameObject person3;
    public Sprite bio3;
    
    public GameObject person4;
    public Sprite bio4;
    
    public GameObject person5;
    public Sprite bio5;
    
    public GameObject person6;
    public Sprite bio6;
    
    public GameObject person7;
    public Sprite bio7;
    
    public GameObject person8;
    public Sprite bio8;
    

    public bool isLevelComplete = false;
    public PersonaScript currentPersona;
    private int index = 0;

    public Canvas FinalScoreCanvas;

    public bool isFinalScoreCanvasActive = false;

    public int finalScore = 0;

    public String selectedCourse;

    public StarRenderer starRenderer;

    public List<TextMeshProUGUI> textMeshProObjects;
    public static void PopulateDictionary()
    {
        int value = 0;
        foreach (var persona in Personas)
        {
            if (!PersonaDictionary.ContainsKey(persona))
            {
                PersonaDictionary.Add(persona, value);
            }else
            {
                Debug.Log("Persona already exists in dictionary");
            }
        }
        foreach (var kvp in PersonaDictionary)
        {
            Debug.Log("Key: " + kvp.Key.Attributes.Name + " Value: " + kvp.Value);
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
        }else if (Input.GetKeyDown(KeyCode.E)) {
            PopulateDictionary();
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
        SetAllPersonInactive();
        Debug.Log("Name: " + currentPersona.Attributes.Name);
        //Debug.Log("Age: " + currentPersona.Attributes.Age);
        //Debug.Log("Country: " + currentPersona.Attributes.Country);
        //Debug.Log("HighSchool: " + currentPersona.Attributes.HighSchool);
        //Debug.Log("Awards: " + string.Join(", ", currentPersona.Attributes.Awards));
        //Debug.Log("Hobbies: " + string.Join(", ", currentPersona.Attributes.Hobbies));
        //Debug.Log("Background: " + currentPersona.Background);
        
        if (currentPersona.Attributes.Name == "Person1") {
            person1.SetActive(true); 
            bioTab.sprite = bio1;
        } else if (currentPersona.Attributes.Name == "Person2") {
            person2.SetActive(true); 
            bioTab.sprite = bio2;
        } else if (currentPersona.Attributes.Name == "Person3") {
            person3.SetActive(true); 
            bioTab.sprite = bio3;
        } else if (currentPersona.Attributes.Name == "Person4") {
            person4.SetActive(true); 
            bioTab.sprite = bio4;
        } else if (currentPersona.Attributes.Name == "Person5") {
            person5.SetActive(true); 
            bioTab.sprite = bio5;
        } else if (currentPersona.Attributes.Name == "Person6") {
            person6.SetActive(true); 
            bioTab.sprite = bio6;
        } else if (currentPersona.Attributes.Name == "Person7") {
            person7.SetActive(true); 
            bioTab.sprite = bio7;
        } else if (currentPersona.Attributes.Name == "Person8") {
            person8.SetActive(true); 
            bioTab.sprite = bio8;
        }


        UpdateTextMeshProObjects();
    }

    public void SetAllPersonInactive() // This functions will set all personas inactive
    {
        person1.SetActive(false);
        person2.SetActive(false);
        person3.SetActive(false);
        person4.SetActive(false);
        person5.SetActive(false);
        person6.SetActive(false);
        person7.SetActive(false);
        person8.SetActive(false);
    }

    public PersonaScript IncrementCurrentPersona()
    {   
        if (Personas.Count > 0 && index < Personas.Count)
        {   
            
            currentPersona = Personas[index];
            index++;
            Debug.Log("Index: " + index + " Count: " + Personas.Count);
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
        evaluateAnswer();
    }

    public void SetSelectedCoursePhysics()
    {
        selectedCourse = "Physics";
        evaluateAnswer();
    }

    public void SetSelectedCourseIndustrial()
    {
        selectedCourse = "Industrial";
        evaluateAnswer();
    }

    public void SetSelectedCourseArchitecture()
    {
        selectedCourse = "Architecture";
        evaluateAnswer();
    }

    public void SetSelectedCourseMedical()
    {
        selectedCourse = "Medical";
        evaluateAnswer();
    }

    public void SetSelectedCourseElectrical()
    {
        selectedCourse = "Electrical";
        evaluateAnswer();
    }

    public void SetSelectedCourseChemistry()
    {
        selectedCourse = "Chemistry";
        evaluateAnswer();
    }

    public void SetSelectedCourseSustainable()
    {
        selectedCourse = "Sustainable";
        evaluateAnswer();
    }

    public void SetSelectedCoursePsychology()
    {
        selectedCourse = "Psychology";
        evaluateAnswer();
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
            Personas.Remove(key);
        }
    }

    public void FinishLevel(){
        Debug.Log("Final Score: " + finalScore);
        FinalScoreCanvas.gameObject.SetActive(true);
        index = 0;
        isLevelComplete = false;
        finalScore = 0;
        starRenderer.LoadStars();
        //IncrementCurrentPersona();
        
    }

    public void Increment() {
        ClearPersonas();
        starRenderer.starIndex = 0;
        NextLevel();
        //IncrementCurrentPersona();
        //DisplayCurrentPersona();
        FinalScoreCanvas.gameObject.SetActive(false);
    }

    public void NextLevel(){
        int currentlevel = 1;
        currentlevel++;
        levelCreator.Level(currentlevel);
    }

    public void bellIncrement() {
       
        if (bell == false) {
            bell = true;
            IncrementCurrentPersona();
            DisplayCurrentPersona();
        }
    }
}

