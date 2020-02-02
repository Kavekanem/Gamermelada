using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuFunctions : MonoBehaviour
{
    public GameObject main_menu;
    public GameObject options;
    public GameObject resolutions;
    public AudioSource mastervolume;

    public string init_level = "Isle";

    // Start is called before the first frame update
    void Start()
    {
        mastervolume.volume = PlayerPrefs.GetFloat("MasterVolume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void InitLevel()
    {
        SceneManager.LoadScene(init_level);
    }

    public void Options()
    {
        main_menu.SetActive(false);
        options.SetActive(true);

    }

    public void exit_options()
    {
        main_menu.SetActive(true);
        options.SetActive(false);
    }

    public void res_menu()
    {
        options.SetActive(false);
        resolutions.SetActive(true);

    }

    public void exit_res()
    {
        options.SetActive(true);
        resolutions.SetActive(false);
    }

    public void fullcreen(bool value)
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, value);
    }

    public void ten_eighty()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    public void seven_twenty()
    {
        Screen.SetResolution(1080, 720, false);
    }

    public void four_eighty()
    {
        Screen.SetResolution(640, 480, false);
    }

    public void ChangeVolume(float vol)
    {
        PlayerPrefs.SetFloat("MasterVolume", vol);
        mastervolume.volume = vol;
    }
}
