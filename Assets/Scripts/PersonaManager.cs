using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using Image = UnityEngine.UI.Image;
using UnityEngine.SceneManagement;

public class PersonaManager : MonoBehaviour
{
    public static List<PersonaScript> Personas = new List<PersonaScript>();

    public static Dictionary<PersonaScript, int> PersonaDictionary = new Dictionary<PersonaScript, int>();

    public PersonaScript levelCreator;


    public bool count = false;

    public GameObject egbertTab;

    public GameObject finalScreen;
    public Animator transition;
    
    public Sprite emailtab2;

    public Sprite emailtab3;

    public Image emailTab;

    public int currentlevel = 1;

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

    public int finalScore = 0;

    public String selectedCourse = "";

    public StarRenderer starRenderer;



    public GameObject bioButton1;
    public GameObject bioButton2;
    public GameObject bioButton3;
    public GameObject bioButton4;

    public GameObject bioButton5;
    public NPCConversation ConversationPerson1;
    public NPCConversation ConversationPerson2;
    public NPCConversation ConversationPerson3;
    public NPCConversation ConversationPerson4;
    public NPCConversation ConversationPerson5;
    public NPCConversation ConversationPerson6;
    public NPCConversation ConversationPerson7;
    public NPCConversation ConversationPerson8;
    public NPCConversation ConversationPerson9;
    private AudioSource audioSource;

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
    }

    public void DisplayAllPersonas()
    {
        foreach (var persona in Personas)
        {
            
        }
    }

    private IEnumerator SetActiveAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(true);
    }

    private IEnumerator AssignAfterDelay(Sprite bio,float delay)
    {
        yield return new WaitForSeconds(delay);
        bioTab.sprite = bio;
    }

    public void DisplayCurrentPersona()
    {
        StartCoroutine(SetAllPersonInactive());
        
        if (currentPersona.Attributes.Name == "Person1") {
            StartCoroutine(SetActiveAfterDelay(person1, 1f));
            //bioTab.sprite = bio1;
            StartCoroutine(AssignAfterDelay(bio1, 1f));
            
        } else if (currentPersona.Attributes.Name == "Person2") {
            StartCoroutine(SetActiveAfterDelay(person2, 1f));
            //bioTab.sprite = bio2;
            StartCoroutine(AssignAfterDelay(bio2, 1f));
            
        } else if (currentPersona.Attributes.Name == "Person3" && count == false) {
            StartCoroutine(SetActiveAfterDelay(person3, 0.3f));
            //bioTab.sprite = bio3;
            StartCoroutine(AssignAfterDelay(bio3, 0.3f));
            count = true;
            
        } else if (currentPersona.Attributes.Name == "Person4") {
            person3.SetActive(false);
            person4.SetActive(true);
            //bioTab.sprite = bio4;
            StartCoroutine(AssignAfterDelay(bio4, 0f));
            count = false;
            bioButton1.SetActive(true);
            
        } else if (currentPersona.Attributes.Name == "Person5") {
            StartCoroutine(SetActiveAfterDelay(person5, 1f)); 
            //bioTab.sprite = bio5;
            StartCoroutine(AssignAfterDelay(bio5, 1f));
            bioButton2.SetActive(true);
            bioButton1.SetActive(false);
            bioButton3.SetActive(true);
            
        } else if (currentPersona.Attributes.Name == "Person6"  && count == false) {
            StartCoroutine(SetActiveAfterDelay(person6, 0.4f)); 
            //bioTab.sprite = bio6;
            StartCoroutine(AssignAfterDelay(bio6, 0.4f));
            count = true;
            bioButton2.SetActive(false);
            bioButton3.SetActive(false);
            bioButton1.SetActive(false);
            
        } else if (currentPersona.Attributes.Name == "Person7") {
            person6.SetActive(false);
            person7.SetActive(true); 
            count = false;
            //bioTab.sprite = bio7;
            StartCoroutine(AssignAfterDelay(bio7, 0f));
            bioButton4.SetActive(true);
            bioButton5.SetActive(true);
        } else if (currentPersona.Attributes.Name == "Person8") {
            StartCoroutine(SetActiveAfterDelay(person8, 1f)); 
            //bioTab.sprite = bio8;
            StartCoroutine(AssignAfterDelay(bio8, 1f));
            bioButton4.SetActive(false);
            bioButton5.SetActive(false);
        } else if (currentPersona.Attributes.Name == "Person9") {
            StartCoroutine(SetActiveAfterDelay(person9, 1f)); 
            //bioTab.sprite = bio9;
            StartCoroutine(AssignAfterDelay(bio9, 1f));
        }


        //UpdateTextMeshProObjects();
    }


    private IEnumerator SetAllPersonInactive() // This functions will set all personas inactive
    {   
        if(currentPersona.Attributes.Name == "Person4" || currentPersona.Attributes.Name == "Person7") {
            yield return null;
            person3.SetActive(false);
            person6.SetActive(false);
            Debug.Log("Inactiveeeeeeeee");
        }else if ((currentPersona.Attributes.Name == "Person3" || currentPersona.Attributes.Name == "Person6") && count == true) {
            yield return null;
            person1.SetActive(false);
            person2.SetActive(false);
            person3.SetActive(false);
            person4.SetActive(false);
            person5.SetActive(false);
            person6.SetActive(false);
            person7.SetActive(false);
            person8.SetActive(false);
            person9.SetActive(false);
            
        } else {
           
            yield return new WaitForSeconds(0.4f);
            person1.SetActive(false);
            person2.SetActive(false);
            person4.SetActive(false);
            person5.SetActive(false);
            person7.SetActive(false);
            person8.SetActive(false);
            person9.SetActive(false);
            
        }
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
        if (currentPersona.Attributes.Name == "Person9"){
                
                PersonaDictionary[currentPersona] =  2;
                finalScore += 2;
                
                //IncrementCurrentPersona();
                //DisplayCurrentPersona();
                if (isLevelComplete)
                {
                    FinishLevel();
                }
            } else if (currentPersona.correctAnswers[0] == selectedCourse)
            {
                
                PersonaDictionary[currentPersona] =  2;
                finalScore += 2;
                
                //IncrementCurrentPersona();
                //DisplayCurrentPersona();
                if (isLevelComplete)
                {
                    FinishLevel();
                }
            } else if (currentPersona.correctAnswers[1] == selectedCourse)
            {
                
                PersonaDictionary[currentPersona] =  1;
                finalScore += 1;
                
                //IncrementCurrentPersona();
                //DisplayCurrentPersona();
                if (isLevelComplete)
                {
                    FinishLevel();
                }
            } else
            {
                
                PersonaDictionary[currentPersona] =  0;
                
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
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        //IncrementCurrentPersona();
        
    }

    public void Increment() {
        ClearPersonas();
        if(currentlevel == 3) {
            finalScreen.gameObject.SetActive(true);
            FinalScoreCanvas.gameObject.SetActive(false);
        } else {
        
        starRenderer.starIndex = 0;
        NextLevel();
        IncrementCurrentPersona();
        DisplayCurrentPersona();
        FinalScoreCanvas.gameObject.SetActive(false);
        //transition.SetTrigger("End");
        }
    }

    public void Return(){
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel(){

        currentlevel++;
        if(currentlevel == 2) {
            emailTab.sprite = emailtab2;
        } else if(currentlevel == 3) {
            emailTab.sprite = emailtab3;
        } 
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

