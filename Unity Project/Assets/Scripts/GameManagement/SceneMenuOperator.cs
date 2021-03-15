using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenuOperator : MonoBehaviour
{
    //[SerializeField] private Scene finiteLevel;
    //[SerializeField] private Scene endlessLevel;

    public void ReloadCurrentScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartFiniteLevel()
    {
        SceneManager.LoadScene(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
