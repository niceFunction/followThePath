using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame_test : MonoBehaviour
{

    [SerializeField]
    private string testGameSceneName;

    public static LoadGame_test Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
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

    public void LoadTestGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(testGameSceneName);
    }

}
