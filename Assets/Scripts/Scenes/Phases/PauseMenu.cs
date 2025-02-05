﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

namespace Yarn.Unity.Example
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool GameIsPaused = false;

        public GameObject pauseMenuUI;
        public GameObject settingsMenu;
        public GameObject hudMenu;
        public GameObject quest;
        private LevelChanger levelChanger;
        public AudioMixer audioMixer;

        void Start()
        {
            audioMixer.SetFloat("masterVolume", Mathf.Log10(PlayerPrefs.GetFloat("MasterVolume", 0f)) * 20);

            audioMixer.SetFloat("musicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 0f)) * 20);

            audioMixer.SetFloat("soundEffectsVolume", Mathf.Log10(PlayerPrefs.GetFloat("SoundEffectsVolume", 0f)) * 20);

            levelChanger = FindObjectOfType<LevelChanger>();
        }

        void Update()
        {
            // Pausar e despausar quando aperta ESC
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        // Metodo para despausar o jogo quando aperta ESC novamente ou quando aperta no botão
        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            settingsMenu.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        // Metodo para pausar o jogo quando pressionar o botão ESC
        void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        // Metodo para o botão de mudar de cena para o Menu
        public void LoadMenu()
        {
            Time.timeScale = 1f;
            levelChanger.FadeToLevel("Menu");
        }

        // Metodo para o botão de sair do jogo
        public void QuitGame()
        {
            Application.Quit();
        }

        // Metodo para o botão de abir as opções
        public void OpenSettings()
        {
            settingsMenu.SetActive(true);
            pauseMenuUI.SetActive(false);
        }

        // Metodo para o botão de fechar as opções
        public void CloseSettings()
        {
            settingsMenu.SetActive(false);
            pauseMenuUI.SetActive(true);
        }

        // Metodo para mostrar o HUD quando for chamado no dialogo
        [YarnCommand("HUD")]
        public void ShowHUD(string command)
        {
            if(command.Equals("show"))
                hudMenu.SetActive(true);

            if (command.Equals("hide"))
                hudMenu.SetActive(false);
        }

        // Metodo para mostrar as Quests quando for chamado no dialogo
        [YarnCommand("Quests")]
        public void ShowQuests(string command)
        {
            if (command.Equals("show"))
                quest.SetActive(true);

            if (command.Equals("hide"))
                quest.SetActive(false);
        }
    }
}