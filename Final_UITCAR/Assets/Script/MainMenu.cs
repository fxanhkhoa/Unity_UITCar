using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
     
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
