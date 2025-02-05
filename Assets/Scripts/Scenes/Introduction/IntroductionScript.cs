﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Yarn.Unity.Example
{
    public class IntroductionScript : MonoBehaviour
    {
        [System.Serializable]
        public struct CharactersInfo
        {
            public string name;
            public GameObject characterObject;
        }

        public CharactersInfo[] characters;
        public static int phase;
        private LevelChanger levelChanger;

        void Start()
        {
            levelChanger = FindObjectOfType<LevelChanger>();

            if (phase == 1)
            {
                FindObjectOfType<DialogueRunner>().StartDialogue("Introduction.Phase1");
            }
            else if (phase == 4)
            {
                FindObjectOfType<DialogueRunner>().StartDialogue("Introduction.Phase4");
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(phase == 1)
                {
                    LoadScene("Scene2D");
                }
                else if (phase == 4)
                {
                    LoadScene("BossPhase");
                }
                
            }
        }
        [YarnCommand("as")]
        public void Active(string function, string characterName)
        {
            bool characterFound = false;
            //procura o personagem que tem que precisa desativar ou ativar
            foreach (var info in characters)
            {
                if (info.name == characterName)
                {
                    if(function == "active")
                    {
                        info.characterObject.gameObject.SetActive(true);
                    }
                    else
                    {
                        info.characterObject.gameObject.SetActive(false);
                    }

                    characterFound = true;
                    break;
                }
            } 

            //se não achar mandar uma mensagem para o console
            if (!characterFound)
            {
                Debug.LogErrorFormat("Não foi encontrando o personagem {0}!", characterName);
                return;
            }
        }

        [YarnCommand("loadNextScene")]
        public void LoadScene(string scene)
        {
            levelChanger.FadeToLevel(scene);
        }
    }
}