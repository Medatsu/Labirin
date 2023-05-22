using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextBattleButton : MonoBehaviour
{
    private void onEnable()
    {
        //  check next scene kalau tidak ada. sembunyiin button ini 
        var currentScene = SceneManager.GetActiveScene();
        int currentLevel = int.Parse(currentScene.name.Split("level ")[1]);
        int nextLevel = currentLevel + 1;
        var nextSceneBuildIndex = SceneUtility.GetBuildIndexByScenePath("level " + nextLevel);
        Debug.Log(nextSceneBuildIndex);
        if(nextSceneBuildIndex == -1)
            this.gameObject.SetActive(false);
    }

    public void NextLevel()
    {
        var currentScene = SceneManager.GetActiveScene();
        int currentLevel = int.Parse(currentScene.name.Split("level ")[1]);
        int nextLevel = currentLevel + 1;
        SceneManager.LoadScene("Level " + nextLevel);
    }
}
