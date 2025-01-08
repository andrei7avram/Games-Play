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
        Debug.Log("lolol");
            if(persona.Value == 0)
            {
                Stars[starIndex].texture = star1.texture;
                starIndex++;
            } else if (persona.Value == 1)
            {
                Stars[starIndex].texture = star2.texture;
                starIndex++;
            } else if (persona.Value == 2)
            {
                Stars[starIndex].texture = star3.texture;
                starIndex++;
            }
       }
    }   

    
}
