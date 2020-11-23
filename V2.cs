using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class V2 : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    void Start()
    {
        keywords.Add("This is a hospital", () =>
        {
            GoCalled03();
        });

        keywords.Add("This is a school", () =>
        {
            GoCalled04();
        });

        keywords.Add("This is a police station", () =>
        {
            GoCalled05();
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

    void GoCalled04()
    {
        Debug.Log("Opps!You are wrong. This is a hospital.");
        //this.transform.Translate(Vector3.up * 10.0f);
        ScoreBoard.Score -= 2;
    }

    void GoCalled05()
    {
        Debug.Log("Opps!You are wrong. This is a hospital.");
        //this.transform.Translate(Vector3.up * 10.0f);
        ScoreBoard.Score -= 2;
    }

    void GoCalled03()
    {
        Debug.Log("Excellent! This is a hospital.");
        //this.transform.Translate(Vector3.up * 10.0f);
        ScoreBoard.Score += 2;
    }
}
