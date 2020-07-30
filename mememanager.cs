using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class mememanager : MonoBehaviour
{
    public GameObject player;
    public Vector3 SpawnPoint;
    AudioSource sfx;

    public Canvas mainmenu;
    public Canvas creditsmenu;
    public Canvas difficultymenu;
    public Canvas optionsmenu;
    public Canvas audiomenu;
    public Canvas pausemenu;
    public Canvas timeupmenu;
    public Canvas gameovermenu;
    public Canvas hudcanvas;
    public Canvas currentCanvas;

    
    public Text timeText;

    public float timeRemaining = 180f;
    public bool timerIsRunning = false;
    public bool Paused = false;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Text healthno;

    
    public Image sword;
    public GameObject swordDamage;


    private static mememanager _instance;
    public static mememanager instance
    {
        get
        {
            return _instance;
        }
    }


    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
		    Application.Quit();
#endif
    }


    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        currentCanvas = mainmenu;
        currentCanvas.gameObject.SetActive(true);

        creditsmenu.gameObject.SetActive(false);
        difficultymenu.gameObject.SetActive(false);
        optionsmenu.gameObject.SetActive(false);
        audiomenu.gameObject.SetActive(false);
        pausemenu.gameObject.SetActive(false);
        timeupmenu.gameObject.SetActive(false);
        gameovermenu.gameObject.SetActive(false);
        hudcanvas.gameObject.SetActive(false);

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        sfx = GetComponent<AudioSource>();

        sword.GetComponent<Image>().color = new Color32(255, 255, 255, 150);

        swordDamage.gameObject.SetActive(false);


    }


    public void gotomainmenu()
    {
        currentCanvas.gameObject.SetActive(false);
        currentCanvas = mainmenu;
        currentCanvas.gameObject.SetActive(true);
    }

    public void gotodifficulty()
    {
        currentCanvas.gameObject.SetActive(false);
        currentCanvas = difficultymenu;
        currentCanvas.gameObject.SetActive(true);
    }

    public void gotooptions()
    {
        currentCanvas.gameObject.SetActive(false);
        currentCanvas = optionsmenu;
        currentCanvas.gameObject.SetActive(true);
    }

    public void gotoaudio()
    {
        currentCanvas.gameObject.SetActive(false);
        currentCanvas = audiomenu;
        currentCanvas.gameObject.SetActive(true);
    }

    public void gotocredits()
    {
        currentCanvas.gameObject.SetActive(false);
        currentCanvas = creditsmenu;
        currentCanvas.gameObject.SetActive(true);
    }

    public void gotopause()
    {
        currentCanvas.gameObject.SetActive(false);
        currentCanvas = pausemenu;
        currentCanvas.gameObject.SetActive(true);
    }

    public void gotomedium()
    {
        currentCanvas.gameObject.SetActive(false);
        currentCanvas = hudcanvas;
        currentCanvas.gameObject.SetActive(true);

        player.transform.position = SpawnPoint;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                currentCanvas.gameObject.SetActive(false);
                currentCanvas = timeupmenu;
                currentCanvas.gameObject.SetActive(true);

                timeRemaining = 0f;
                timerIsRunning = false;
            }
        }

        if (Input.GetKeyDown ("escape"))
        {
            if(Paused == true)
            {
                Time.timeScale = 1.0f;

                currentCanvas.gameObject.SetActive(false);
                currentCanvas = hudcanvas;
                currentCanvas.gameObject.SetActive(true);

                Paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;

                currentCanvas.gameObject.SetActive(false);
                currentCanvas = pausemenu;
                currentCanvas.gameObject.SetActive(true);

                Paused = true;
            }
        }
        
        if (currentHealth <= 0)
        {
            currentCanvas.gameObject.SetActive(false);
            currentCanvas = gameovermenu;
            currentCanvas.gameObject.SetActive(true);
            
        }

        healthno.text = currentHealth.ToString() + " / " + maxHealth.ToString();


        if (Input.GetMouseButtonDown(0))
        {
            sword.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            swordDamage.gameObject.SetActive(true);
            GetComponent<AudioSource>().Play();
        }

        if (Input.GetMouseButtonUp(0))
        {
            sword.GetComponent<Image>().color = new Color32(255, 255, 255, 150);
            swordDamage.gameObject.SetActive(false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "fence")
        {
            currentHealth -= 1;
        }

        if (collision.gameObject.tag == "slime")
        {
            currentHealth -= 2;
        }

        if (collision.gameObject.tag == "skeleton")
        {
            currentHealth -= 4;
        }

        if (collision.gameObject.tag == "zombie")
        {
            currentHealth -= 6;
        }

        if (collision.gameObject.tag == "goblin")
        {
            currentHealth -= 8;
        }

        if (collision.gameObject.tag == "troll")
        {
            currentHealth -= 10;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);
    }

    public void ResetHealth()
    {
        healthBar.SetHealth(maxHealth);
        currentHealth = maxHealth;
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void ResetTimer()
    {
        timeRemaining = 180f;
        timerIsRunning = false;
    }


    

}
