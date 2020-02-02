using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject the_pause_menu;
    public GameObject pause_menu;
    public GameObject resume_pause;
    public GameObject options;
    public GameObject exit_pause_menu;
    public AudioSource mastervolume;

    public static float game_timescale = 1;
    public static bool is_paused = false;
    public string menu_level = "Menu";

    // Start is called before the first frame update
    void Start()
    {
        mastervolume.volume = PlayerPrefs.GetFloat("MasterVolume");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            is_paused = !is_paused;

            if (is_paused)
                start_pause();

            else
                resume_game();
        }
    }

    public void start_pause()
    {
        the_pause_menu.SetActive(true);
        game_timescale = 0;
        Time.timeScale = 0.0f;
    }

    public void resume_game()
    {
        the_pause_menu.SetActive(false);
        is_paused = false;
        game_timescale = 1;
        Time.timeScale = 1.0f;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(menu_level);
    }

    public float get_deltaTime()
    {
        return Time.timeScale * game_timescale;
    }
    


}
