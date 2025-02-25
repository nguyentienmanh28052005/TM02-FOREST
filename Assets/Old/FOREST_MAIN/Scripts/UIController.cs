using System;
using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using UnityEngine;
    using UnityEngine.UI;
    //using UnityEngine.Experimental.TerrainAPI;
    using UnityEngine.SceneManagement;
    
    public class UIController : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject _cam;
        public GameObject pauseMenu;
        public GameObject setting;
        //public GameObject _startMenu;
        public static bool isPause;
        public Slider _musicSlider, _sfxSlider;
        public GameObject _fullSetting;
        private GameObject _scene;
        private SceneO _name;
        [SerializeField] private GameObject _reset;
        [SerializeField] private GameObject _resume;
        [SerializeField] private GameObject _quit;
        [SerializeField] private GameObject _graphic;
        [SerializeField] private GameObject _setting;
        [SerializeField] private GameObject _tutorial;
         private GameObject _key;
         private GameObject _coin;
        private bool isFullScreen = true;
        
        

        void Start(){
            //pauseMenu.SetActive(false);
            SetFullScreen(isFullScreen);
        }
    
        void Update(){
            _scene = GameObject.Find("Scene");
            // if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1) Time.timeScale = 0;
            // else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0) Time.timeScale = 1;
            if(Input.GetKeyDown(KeyCode.Escape)){
                if(isPause){
                    ResumeGame();
                }
                else{
                    Pause();
                }
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (isFullScreen)
                {
                    SetFullScreen(false);
                    isFullScreen = false;
                }
                else
                {
                    SetFullScreen(true);
                    isFullScreen = true;
                }
            }
            
            if (_scene.GetComponent<SceneO>().Name() == 1)
            {
                _reset.SetActive(false);
                _resume.SetActive(false);
                _quit.SetActive(false);
            }
            else
            {
                _reset.SetActive(true);
                _resume.SetActive(true);
                _quit.SetActive(true);
            }
        }

        private void FixedUpdate()
        {
            _key = GameObject.FindWithTag("Key");
            _coin = GameObject.FindWithTag("Coin");
        }

        public void PauseButton()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    
        public void Pause(){
            if (_scene.GetComponent<SceneO>().Name() == 1)
            {
                _key.SetActive(false);
                _coin.SetActive(false);
            }
            _cam.SetActive(true);
            _fullSetting.SetActive(true);
            Time.timeScale = 0;
            isPause = true;
        }
        public void ResumeGame(){
            if (_scene.GetComponent<SceneO>().Name() == 1)
            {
                _key.SetActive(true);
                _coin.SetActive(true);
            }
            _cam.SetActive(false);
            _fullSetting.SetActive(false);
            _cam.SetActive(false);
            Time.timeScale = 1;
            isPause = false;
        }
    
        public void OutGame()
        {
            //pauseMenu.SetActive(false);
            _cam.SetActive(true);
            _fullSetting.SetActive(true);
            AudioManager.Instance.PlayMusic("Music2");
            AudioManager.Instance.PlayMusic2("None");
            Time.timeScale = 1;
            isPause = false;
            SceneManager.LoadScene(1);
        }
    
        public void Reset()
        {
            _name = _scene.GetComponent<SceneO>();
            SceneManager.LoadScene(_name.Name());
            _fullSetting.SetActive(false);
            _cam.SetActive(false);
            isPause = false;
            Time.timeScale = 1;
        }

        public void PlayGame()
        {
            SceneManager.LoadScene(4);
            SceneManager.LoadScene(1);
        }

        public void OnGraphic()
        {
            _graphic.SetActive(true);
            _setting.SetActive(false);
            _tutorial.SetActive(false);
        }

        public void OnSetting()
        {
            _setting.SetActive(true);
            _graphic.SetActive(false);
            _tutorial.SetActive(false);
        }

        public void OnTutorial()
        {
            _tutorial.SetActive(true);
            _setting.SetActive(false);
            _graphic.SetActive(false);
        }

        public void SetFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
        }

        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void Round1()
        {
            AudioManager.Instance.PlayMusic("Music");
            AudioManager.Instance.PlayMusic2("Rain");
            SceneManager.LoadScene(2);
        }
        public void Round2()
        {
            SceneManager.LoadScene(3);
            AudioManager.Instance.PlayMusic("Round2");
            AudioManager.Instance.PlayMusic2("None");
        }

        public void Round3()
        {
            SceneManager.LoadScene(5);
            AudioManager.Instance.PlayMusic("Round3");
            AudioManager.Instance.PlayMusic2("None");
        }
        
        // public void Quit()
        // {
        //     SceneManager.LoadScene(1);
        // }
    
        public void Setting(){
            setting.SetActive(true);
            pauseMenu.SetActive(false);
        }
        public void Back()
        {
            setting.SetActive(false);
            pauseMenu.SetActive(true);
        }

        public void ToggleMuisc()
        {
            AudioManager.Instance.ToggleMusic();
        }

        public void ToggleSFX()
        {
            AudioManager.Instance.ToggleSFX();
        }

        public void MusicVolume()
        {
            AudioManager.Instance.MusicVolume(_musicSlider.value);
        }

        public void SFXVolume()
        {
            AudioManager.Instance.SFXVolume(_sfxSlider.value);
        }
}
