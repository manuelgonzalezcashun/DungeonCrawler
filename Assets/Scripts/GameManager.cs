using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region Singleton Code
    private static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    public void LoadScene(Scenes scene)
    {
        PauseMenu.gameIsPaused = false;
        SceneManager.LoadScene(scene.GetMenuName());
    }

    public void LoadMenuSceneAdditive(Scenes scene)
    { 
        SceneManager.LoadScene(scene.GetMenuName(), LoadSceneMode.Additive);
    }
    public void UnloadMenuScene(Scenes scene)
    {
        SceneManager.UnloadSceneAsync(scene.GetMenuName());
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(currentScene() + 1);
    }
    public int currentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
