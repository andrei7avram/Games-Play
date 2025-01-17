using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSwitcher : MonoBehaviour
{
    public Texture ComputerScience;
    public Texture AppliedPhysics;
    public Texture IndustrialDesign;
    public Texture Architecture;
    public Texture MedicalSciences;
    public Texture ElectricalEngineering;
    public Texture ChemicalEngineering;
    public Texture Sustainable;
    public Texture Psychology;

    private Texture[] textures;
    private int currentIndex = 0; // Index to keep track of the current texture
    private Renderer rend; // Renderer component of the GameObject

    void Start()
    {
        rend = GetComponent<Renderer>();

        // Populate the textures array with the named textures
        textures = new Texture[]
        {
            ComputerScience, AppliedPhysics, IndustrialDesign, Architecture, MedicalSciences,
            ElectricalEngineering, ChemicalEngineering, Sustainable, Psychology
        };

        // Set the initial texture
        rend.material.mainTexture = textures[currentIndex];
        rend.material.SetTexture("_EmissionMap", textures[currentIndex]);
        rend.material.EnableKeyword("_EMISSION"); // Enable emission keyword
    }

    void Update()
    {
    // Check for left navigation: Left Arrow, A, or Left Mouse Click
    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetMouseButtonDown(0))
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = textures.Length - 1;
        rend.material.mainTexture = textures[currentIndex];
        rend.material.SetTexture("_EmissionMap", textures[currentIndex]);
    }

    // Check for right navigation: Right Arrow, D, Spacebar, or Right Mouse Click
    if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetMouseButtonDown(1))
    {
        currentIndex++;
        if (currentIndex >= textures.Length)
            currentIndex = 0;
        rend.material.mainTexture = textures[currentIndex];
        rend.material.SetTexture("_EmissionMap", textures[currentIndex]);
    }
    }
}
