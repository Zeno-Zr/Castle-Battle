using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SandBoxSceneSelect : MonoBehaviour
{
    public GameObject canvas;

    public void OpenCanvas()
    {
        canvas.SetActive(true);
    }

    public void CloseCanvas()
    {
        canvas.SetActive(false);
    }

    public void LoadSandBox11()
    {
        SceneManager.LoadScene("SandBox11");
    }

    public void LoadSandBox12()
    {
        SceneManager.LoadScene("SandBox12");
    }

    public void LoadSandBox13()
    {
        SceneManager.LoadScene("SandBox13");
    }

    public void LoadSandBox21()
    {
        SceneManager.LoadScene("SandBox21");
    }

    public void LoadSandBox22()
    {
        SceneManager.LoadScene("SandBox22");
    }

    public void LoadSandBox23()
    {
        SceneManager.LoadScene("SandBox23");
    }

    public void LoadSandBox31()
    {
        SceneManager.LoadScene("SandBox31");
    }

    public void LoadSandBox32()
    {
        SceneManager.LoadScene("SandBox32");
    }

    public void LoadSandBox33()
    {
        SceneManager.LoadScene("SandBox33");
    }
}
