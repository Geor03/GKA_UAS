using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Movs : MonoBehaviour
{
    float speed = 3.0f;
    float rotationSpeed = 100.0f;
    Animator anim;
    public static GameObject controlledBy;
    public bool canpick = false;
    public bool access = false;
    public bool compuse = false;
    public bool opensesame = false;
    public bool refill = false;

    public Button resume;
    public Button exit;
    public Button controlDoor;

    public GameObject Card;
    public GameObject OxygenButton;
    public GameObject ControlPanel;
    public GameObject Gameover;
    public Compooter pooter;
    public Text prompt;
    public Text Taimu;
    public Text Daterino;
    public Text Oksigen;

    private float timePassed = 0f;
    public int oksigen;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Start(){
        oksigen = 80;
        Oksigen.text = oksigen+"%";
        resume.onClick.AddListener(Resume);
        exit.onClick.AddListener(QuitGame);
        controlDoor.onClick.AddListener(pooter.Pyuteruse);
        
    }

    void Awake(){
        anim = this.GetComponent<Animator>();
    }
    
    void FixedUpdate(){
        if(controlledBy != null) return;
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.fixedDeltaTime;
        rotation *= Time.fixedDeltaTime;
        transform.Translate(0,0,translation);
        transform.Rotate(0, rotation, 0);
        if(translation !=0){
            anim.SetBool("wac",true);
            anim.SetFloat("Sped", translation);
        }

        else{
            anim.SetBool("wac",false);
            anim.SetFloat("Sped",0);
        }

        if(Input.GetKeyDown(KeyCode.E)){
            if(canpick == true)
            {
                KardPickup52();
            }
            if(compuse == true && access == true)
            {
                if(ControlPanel.activeSelf == false){
                     ControlPanel.SetActive(true);
                     prompt.text = "";
                }
                else{
                    ControlPanel.SetActive(false);
                    prompt.text = "Press E to use the Computer";
                }
            }
            if(refill == true){
                oksigen = 100;
                Oksigen.text = oksigen + "%";
            }
        }
    }

    void Update(){
        if(!GameIsPaused){
            Taimu.text = DateTime.Now.ToLongTimeString();
            Daterino.text = DateTime.Now.ToString("dd MMMM yyyy");
        }
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            anim.SetBool("Run", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)){
            anim.SetBool("Run",false);
        }

        if (Input.GetKey(KeyCode.Space)){
            anim.SetBool("isJumping", true);
        }
        else{
            anim.SetBool("isJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }else{
                Paused();
            }
        }
        timePassed += Time.deltaTime;
        if(timePassed > 5f)
        {
            Oxygen();
            timePassed = 0;
        }
    }


    void OnTriggerEnter(Collider pick)
    {
        if(pick.CompareTag("Kard")){
            canpick = true;
            prompt.text = "Press E to pick up Card";
        }
        if(pick.CompareTag("Pooter") ){
            if(access){
                // if(!opensesame){
                    compuse = true;
                    prompt.text = "Press E to use the Computer";
                // }
            }
            else if(!access){
                prompt.text = "No Card No Service";
            }
        }
        if(pick.CompareTag("OxygenButton")){
            refill = true;
            prompt.text = "Press E to Refill Oxygen";
        }
    }

    void OnTriggerExit(Collider pick)
    {
        if(pick.CompareTag("Kard")){
            canpick = false;
            prompt.text = "";
        }
        if(pick.CompareTag("Pooter")){
           compuse = false;
           prompt.text = "";
        }
        if(pick.CompareTag("OxygenButton")){
           refill = false;
           prompt.text = "";
        }
    }

    void KardPickup52(){
        Debug.Log("Herro");
        access = true;
        Destroy(Card);
        prompt.text = "";
        
    }
    
    void Oxygen(){
        oksigen -= 1;
        if(oksigen <= 0){
            QuitGame();
        }
        else{
            Oksigen.text = oksigen + "%";
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Paused(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame(){
        Time.timeScale = 0f;
        Application.Quit();
        Gameover.SetActive(true);
        pauseMenuUI.SetActive(false);
        ControlPanel.SetActive(false);


        // EditorApplication.isPlaying = false;
    }
}
