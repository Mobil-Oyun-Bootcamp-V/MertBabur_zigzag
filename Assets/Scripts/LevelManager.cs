using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void RestartScene()
    {
        LoadScene(GetActiveSceneIndex());
    }
    
    private void LoadScene(int buildIndexxx)
    {
        SceneManager.LoadScene(buildIndexxx);
    }

    public int GetActiveSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}