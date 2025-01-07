using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PC : MonoBehaviour
{
    public GameObject[] panels = new GameObject[5];

    public void Button()
    {
        Debug.Log("Button pressed");
    }

    public void Main()
    {
        ShowPanel(0);
    }

    public void Bio()
    {
        ShowPanel(1);
    }

    public void Email()
    {
        ShowPanel(2);
    }

    public void Game()
    {
        ShowPanel(3);
    }

    public void Help()
    {
        ShowPanel(4);
    }

    private void ShowPanel(int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == index)
            {
                panels[i].SetActive(true);
            }
            else
            {
                panels[i].SetActive(false);
            }
        }
    }
}
