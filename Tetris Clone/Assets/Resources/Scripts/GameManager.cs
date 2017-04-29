using UnityEngine;
using System.Collections;
using Assets.Scripts;
using Assets.Scripts.WordGeneration;
using Assets.Resources.Scripts.Letters;

public class GameManager : MonoBehaviour {

    int wordsSpelled = 0;
    decimal currentWeight = 10m;

    Word currentWord = null;

	// Use this for initialization
	void Start () {
        GetNewWord();
	}

    void GetNewWord()
    {
        currentWord = WordGenerator.GenerateWord(3);
		LetterGenerator.SetUpWord (currentWord, 100000);
        //TODO
        //
        //Depending on how many words in a row we've spelled, change the weight to make it progressively harder.

        /* Pass the current word and weight to the applicable classes. */
        Spawner.CurrentWord = currentWord;
        Spawner.LetterWeight = currentWeight;
		FindObjectOfType<Spawner>().SpawnNext();
    }

    /// <summary>
    /// Once a word is spelled successfully, add one to the count and get a new word.
    /// </summary>
    public void SuccessfulSpell()
    {
        wordsSpelled++;

        GetNewWord();
    }
}
