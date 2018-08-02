using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
    public GameObject m_mainMenu;

    public AudioSource clickPlay;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play()
    {
        clickPlay.Play();
        m_mainMenu.SetActive(false);
    }
}
