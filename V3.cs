using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class V3 : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    void Start()
    {

        keywords.Add("The elephants are swimming in the water", () =>
        {
            GoCalled11();
        });

        keywords.Add("The birds are swimming in the water", () =>
        {
            GoCalled12();
        });

        keywords.Add("The fishes are swimming in the water", () =>
        {
            GoCalled13();
        });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizerOnPhraseRecognizer;
        keywordRecognizer.Start();
    }

    void KeywordRecognizerOnPhraseRecognizer(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;

        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    void GoCalled12()
    {
        Debug.Log("Opps!You are wrong.The fishes are swimming in the water.");
        //this.transform.Translate(Vector3.up * 10.0f);
        ScoreBoard.Score -= 2;
    }

    void GoCalled13()
    {
        Debug.Log("Opps!You are wrong.The fishes are swimming in the water.");
        //this.transform.Translate(Vector3.up * 10.0f);
        ScoreBoard.Score -= 2;
    }

    void GoCalled11()
    {
        Debug.Log("Excellent. The fishes are swimming in the water.");
        //this.transform.Translate(Vector3.up * 10.0f);
        ScoreBoard.Score += 2;
    }
}
