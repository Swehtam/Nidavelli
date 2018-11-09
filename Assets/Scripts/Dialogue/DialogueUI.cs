﻿/*

The MIT License (MIT)

Copyright (c) 2015-2017 Secret Lab Pty. Ltd. and Yarn Spinner contributors.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.Collections.Generic;

namespace Yarn.Unity.Example
{
    /// Displays dialogue lines to the player, and sends
    /// user choices back to the dialogue system.

    /** Note that this is just one way of presenting the
     * dialogue to the user. The only hard requirement
     * is that you provide the RunLine, RunOptions, RunCommand
     * and DialogueComplete coroutines; what they do is up to you.
     */
    public class DialogueUI : Yarn.Unity.DialogueUIBehaviour
    {

        /// The object that contains the dialogue and the options.
        /** This object will be enabled when conversation starts, and 
         * disabled when it ends.
         */
        public GameObject dialogueContainer;

        /// The UI element that displays lines
        public Text lineText;

        //  The UI element that displays the name of the character
        public Text nameText;

        /// A UI element that appears after lines have finished appearing
        public GameObject continuePrompt;

        /// A delegate (ie a function-stored-in-a-variable) that
        /// we call to tell the dialogue system about what option
        /// the user selected
        private Yarn.OptionChooser SetSelectedOption;

        /// How quickly to show the text, in seconds per character
        [Tooltip("How quickly to show the text, in seconds per character")]
        public float textSpeed;

        /// The buttons that let the user choose an option
        public List<Button> optionButtons;

        //Persoagem selecionado na cena
        private GameObject character;

        // Balão do dialogo que será usado para cada personagem na cena
        private GameObject balloon;
        
        //Texto que ficará dentro do balão de dialogo
        private Text text;

        // Texto para apresentar o botão de continuar
        private Text continuetext;

        void Awake()
        {
            // Start by hiding the container, line and option buttons
            if (dialogueContainer != null)
                dialogueContainer.SetActive(false);

            foreach (var button in optionButtons)
            {
                button.gameObject.SetActive(false);
            }

            // Hide the continue prompt if it exists
            if (continuePrompt != null)
                continuePrompt.SetActive(false);
        }

        /// Show a line of dialogue, gradually
        public override IEnumerator RunLine(Yarn.Line line)
        {
            if (!dialogueContainer)
            {
                string[] lineArray = line.text.Split(new string[] { "::" }, 0);
                character = GameObject.Find(lineArray[0]);
                line.text = lineArray[1];
                if (character != null)
                {
                    balloon = character.transform.Find("Canvas/Balloon").gameObject;
                    text = character.transform.Find("Canvas/Text").gameObject.GetComponent<Text>();
                    continuetext = character.transform.Find("Canvas/Continue").gameObject.GetComponent<Text>();
                }

                balloon.SetActive(true);
                text.gameObject.SetActive(true);

                // Show the text
                if (textSpeed > 0.0f)
                {
                    // Display the line one character at a time
                    var stringBuilder = new StringBuilder();

                    foreach (char c in line.text)
                    {
                        stringBuilder.Append(c);
                        text.text = stringBuilder.ToString();
                        yield return new WaitForSeconds(textSpeed);
                    }
                }
                else
                {
                    // Display the line immediately if textSpeed == 0
                    text.text = line.text;
                }

                // Show the 'press any key' prompt when done, if we have one
                if (continuetext != null)
                    continuetext.gameObject.SetActive(true);

                // Wait for any user input
                while (Input.GetKeyDown("space") == false)
                {
                    yield return null;
                }

                // Hide the text and prompt
                text.gameObject.SetActive(false);
                balloon.SetActive(false);

                if (continuetext != null)
                    continuetext.gameObject.SetActive(false);
            }
            else
            {
                string[] lineArray = line.text.Split(new string[] { "::" }, 0);
                nameText.text = lineArray[0];
                line.text = lineArray[1];

                // Show the text
                if (textSpeed > 0.0f)
                {
                    // Display the line one character at a time
                    var stringBuilder = new StringBuilder();

                    foreach (char c in line.text)
                    {
                        stringBuilder.Append(c);
                        lineText.text = stringBuilder.ToString();
                        yield return new WaitForSeconds(textSpeed);
                    }
                }
                else
                {
                    // Display the line immediately if textSpeed == 0
                    lineText.text = line.text;
                }

                if (continuePrompt != null)
                    continuePrompt.gameObject.SetActive(true);

                // Wait for any user input
                while (Input.GetKeyDown("space") == false)
                {
                    yield return null;
                }

                if (continuePrompt != null)
                    continuePrompt.gameObject.SetActive(false);
            }

        }

        /// Show a list of options, and wait for the player to make a selection.
        public override IEnumerator RunOptions(Yarn.Options optionsCollection,
                                                Yarn.OptionChooser optionChooser)
        {
            // Do a little bit of safety checking
            if (optionsCollection.options.Count > optionButtons.Count)
            {
                Debug.LogWarning("There are more options to present than there are" +
                                 "buttons to present them in. This will cause problems.");
            }

            // Display each option in a button, and make it visible
            int i = 0;
            foreach (var optionString in optionsCollection.options)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<Text>().text = optionString;
                i++;
            }

            // Record that we're using it
            SetSelectedOption = optionChooser;

            // Wait until the chooser has been used and then removed (see SetOption below)
            while (SetSelectedOption != null)
            {
                yield return null;
            }

            // Hide all the buttons
            foreach (var button in optionButtons)
            {
                button.gameObject.SetActive(false);
            }
        }

        /// Called by buttons to make a selection.
        public void SetOption(int selectedOption)
        {

            // Call the delegate to tell the dialogue system that we've
            // selected an option.
            SetSelectedOption(selectedOption);

            // Now remove the delegate so that the loop in RunOptions will exit
            SetSelectedOption = null;
        }

        /// Run an internal command.
        public override IEnumerator RunCommand(Yarn.Command command)
        {
            // "Perform" the command
            string[] commandArray = command.text.Split(' ');
            if (commandArray[0] == "wait")
            {
                float time = float.Parse(commandArray[1]);
                yield return new WaitForSeconds(time);
            }
            

            yield break;
        }


        //MUDAR PARA FICAR DENTRO DO RUN LINE
        /// Called when the dialogue system has started running.
        public override IEnumerator DialogueStarted()
        {
            Debug.Log("Dialogue starting!");

            // Enable the dialogue controls.
            if (dialogueContainer != null)
                dialogueContainer.SetActive(true);

            // Hide the game controls.
            /*if (gameControlsContainer != null)
            {
                gameControlsContainer.gameObject.SetActive(false);
            }*/

            yield break;
        }

        /// Called when the dialogue system has finished running.
        public override IEnumerator DialogueComplete()
        {
            Debug.Log("Complete!");

            // Hide the dialogue interface.
            if (dialogueContainer != null)
                dialogueContainer.SetActive(false);

            // Show the game controls.
            /*if (gameControlsContainer != null)
            {
                gameControlsContainer.gameObject.SetActive(true);
            }*/

            yield break;
        }

    }

}
