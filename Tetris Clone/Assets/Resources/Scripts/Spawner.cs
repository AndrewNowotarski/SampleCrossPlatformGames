using UnityEngine;
using System.Collections;
using Assets.Resources.Scripts.Letters;
using Assets.Scripts.WordGeneration;

public class Spawner : MonoBehaviour {

    /* Array to hold the different game objects. */
    public static Word CurrentWord;
    public static decimal LetterWeight;

    public void SpawnNext()
    {
        /* Pick a letter at random. */
        char curLetter = LetterGenerator.GetLetter();

        Debug.Log(curLetter);

		var letter = (GameObject)Resources.Load ("Prefabs/Letters/Letter_" + curLetter);

		Instantiate(letter, GetComponent<Transform>().position, Quaternion.identity);
    }
}
