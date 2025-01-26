using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarRenderer : MonoBehaviour
{
   public Sprite star1;
   public Sprite star2;
   public Sprite star3;

   public RawImage[] Stars = new RawImage[3];

   public int starIndex = 0;

   public PersonaManager PersonaManagerRef;


    public void Start()
    {
       //LoadStars();
       //
    }

    public void LoadStars()
    {

       foreach (var persona in PersonaManager.PersonaDictionary) {
            if(persona.Value == 0)
            {   
                Debug.Log("Bronze " + starIndex + persona.Value + persona.Key.Attributes.Name);
                Stars[starIndex].texture = star1.texture;
                starIndex++;
            } else if (persona.Value == 1)
            {   
                Debug.Log("Silver " + starIndex + persona.Value + persona.Key.Attributes.Name);
                Stars[starIndex].texture = star2.texture;
                starIndex++;
            } else if (persona.Value == 2)
            {   
                Debug.Log("Gold " + starIndex + persona.Value + persona.Key.Attributes.Name);
                Stars[starIndex].texture = star3.texture;
                starIndex++;
            }
       }
    }   

    
}
