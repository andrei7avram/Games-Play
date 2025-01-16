using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using DialogueEditor;

public class PersonaManager : MonoBehaviour
{
    public static List<PersonaScript> Personas = new List<PersonaScript>();

    public static Dictionary<PersonaScript, int> PersonaDictionary = new Dictionary<PersonaScript, int>();

    public PersonaScript levelCreator;

    public Animator transition;

    public int currentlevel = 1;

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

    public GameObject person9;
    public Sprite bio9;
    

    public bool isLevelComplete = false;
    public PersonaScript currentPersona;
    private int index = 0;

    public Canvas FinalScoreCanvas;

    public bool isFinalScoreCanvasActive = false;

    public int finalScore = 0;

    public String selectedCourse = "";

    public StarRenderer starRenderer;

    //public List<TextMeshProUGUI> textMeshProObjects;


    public GameObject bioButton1;
    public GameObject bioButton2;
    public GameObject bioButton3;
    public GameObject bioButton4;
    public NPCConversation ConversationPerson1;
    public NPCConversation ConversationPerson2;
    public NPCConversation ConversationPerson3;
    public NPCConversation ConversationPerson4;
    public NPCConversation ConversationPerson5;
    public NPCConversation ConversationPerson6;
    public NPCConversation ConversationPerson7;
    public NPCConversation ConversationPerson8;
    public NPCConversation ConversationPerson9;

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
        /*
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
        */
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
            bioButton1.SetActive(true);
            
        } else if (currentPersona.Attributes.Name == "Person5") {
            person5.SetActive(true); 
            bioTab.sprite = bio5;
            bioButton2.SetActive(true);
            bioButton1.SetActive(false);
            bioButton3.SetActive(true);
            
        } else if (currentPersona.Attributes.Name == "Person6") {
            person6.SetActive(true); 
            bioTab.sprite = bio6;
            bioButton2.SetActive(false);
            bioButton3.SetActive(false);
            bioButton1.SetActive(false);
            
        } else if (currentPersona.Attributes.Name == "Person7") {
            person7.SetActive(true); 
            bioTab.sprite = bio7;
            bioButton4.SetActive(true);
        } else if (currentPersona.Attributes.Name == "Person8") {
            person8.SetActive(true); 
            bioTab.sprite = bio8;
        } else if (currentPersona.Attributes.Name == "Person9") {
            person9.SetActive(true); 
            bioTab.sprite = bio9;
        }


        //UpdateTextMeshProObjects();
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
        person9.SetActive(false);
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

    /*public void UpdateTextMeshProObjects()
    {
        textMeshProObjects[0].text = "Name: " + currentPersona.Attributes.Name;
        textMeshProObjects[1].text = "Age: " + currentPersona.Attributes.Age.ToString();
        textMeshProObjects[2].text = "Country: " + currentPersona.Attributes.Country;
        textMeshProObjects[3].text = "HighSchool: " + currentPersona.Attributes.HighSchool;
        textMeshProObjects[4].text = "Awards: " + string.Join(", ", currentPersona.Attributes.Awards);
        textMeshProObjects[5].text = "Hobbies: " + string.Join(", ", currentPersona.Attributes.Hobbies);
        textMeshProObjects[6].text = "Background: " + currentPersona.Background;
    }*/

    public void FinalDialogue()
    {
        if (currentPersona.Attributes.Name == "Person1")
        {
            ConversationManager.Instance.StartConversation(ConversationPerson1);
        }
        if (currentPersona.Attributes.Name == "Person2")
        {
            ConversationManager.Instance.StartConversation(ConversationPerson2);
        }
        if (currentPersona.Attributes.Name == "Person3")
        {
            ConversationManager.Instance.StartConversation(ConversationPerson3);
        }
        if (currentPersona.Attributes.Name == "Person4")
        {
            ConversationManager.Instance.StartConversation(ConversationPerson4);
        }
        if (currentPersona.Attributes.Name == "Person5")
        {
            ConversationManager.Instance.StartConversation(ConversationPerson5);
        }
        if (currentPersona.Attributes.Name == "Person6")
        {
            ConversationManager.Instance.StartConversation(ConversationPerson6);
        }
        if (currentPersona.Attributes.Name == "Person7")
        {
            ConversationManager.Instance.StartConversation(ConversationPerson7);
        }
        if (currentPersona.Attributes.Name == "Person8")
        {
            ConversationManager.Instance.StartConversation(ConversationPerson8);
        }
        if (currentPersona.Attributes.Name == "Person9")
        {
            ConversationManager.Instance.StartConversation(ConversationPerson9);
        }
    }
    public void SetSelectedCourseCSE()
    {
        selectedCourse = "CSE";
        evaluateAnswer();
        FinalDialogue();
    }

    public void SetSelectedCoursePhysics()
    {
        selectedCourse = "Physics";
        evaluateAnswer();
        FinalDialogue();
    }

    public void SetSelectedCourseIndustrial()
    {
        selectedCourse = "Industrial";
        evaluateAnswer();
        FinalDialogue();
    }

    public void SetSelectedCourseArchitecture()
    {
        selectedCourse = "Architecture";
        evaluateAnswer();
        FinalDialogue();
    }

    public void SetSelectedCourseMedical()
    {
        selectedCourse = "Medical";
        evaluateAnswer();
        FinalDialogue();
    }

    public void SetSelectedCourseElectrical()
    {
        selectedCourse = "Electrical";
        evaluateAnswer();
        FinalDialogue();
    }

    public void SetSelectedCourseChemistry()
    {
        selectedCourse = "Chemistry";
        evaluateAnswer();
        FinalDialogue();
    }

    public void SetSelectedCourseSustainable()
    {
        selectedCourse = "Sustainable";
        evaluateAnswer();
        FinalDialogue();
    }

    public void SetSelectedCoursePsychology()
    {
        selectedCourse = "Psychology";
        evaluateAnswer();
        FinalDialogue();
    }


    public void evaluateAnswer()
    {  
            if (currentPersona.correctAnswers[0] == selectedCourse)
            {
                Debug.Log("Correct");
                PersonaDictionary[currentPersona] =  2;
                finalScore += 2;
                Debug.Log(finalScore);
                //IncrementCurrentPersona();
                //DisplayCurrentPersona();
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
                //IncrementCurrentPersona();
                //DisplayCurrentPersona();
                if (isLevelComplete)
                {
                    FinishLevel();
                }
            } else
            {
                Debug.Log("Incorrect");
                PersonaDictionary[currentPersona] =  0;
                Debug.Log(finalScore);
                //IncrementCurrentPersona();
                //DisplayCurrentPersona();
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
            if (kvp.Value != 6)
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
        IncrementCurrentPersona();
        DisplayCurrentPersona();
        FinalScoreCanvas.gameObject.SetActive(false);
    }

    public void NextLevel(){
        currentlevel++;
        levelCreator.Level(currentlevel);
    }

    public void bellIncrement() {
        
        if(currentPersona.Attributes.Name == null || !string.IsNullOrEmpty(selectedCourse)) {
            Debug.Log(currentPersona.Attributes.Name == null);
            transition.SetTrigger("Start");
            IncrementCurrentPersona();
            DisplayCurrentPersona();
            selectedCourse = "";
            if (isLevelComplete)
            {
                FinishLevel();
            }
        } else {
            Debug.Log("Please select a course");
        }
    }
}

