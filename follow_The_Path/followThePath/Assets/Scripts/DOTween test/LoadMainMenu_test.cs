using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu_test : MonoBehaviour
{
    [SerializeField]
    private string testMainMenuSceneName;

    public static LoadMainMenu_test Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadTestMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(testMainMenuSceneName);
    }

}
