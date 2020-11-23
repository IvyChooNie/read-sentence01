using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class v1 : MonoBehaviour
{

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    void Start()
    {
        keywords.Add("He is playing a football", () =>
        {
            GoCalled();
        });

        keywords.Add("He is playing a netball", () =>
        {
            GoCalled01();
        });

        keywords.Add("He is playing a basketball", () =>
        {
            GoCalled02();
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

    void GoCalled()
    {
        Debug.Log("Excellent! He is playing a football.");
        //this.transform.Translate(Vector3.up * 10.0f);
        ScoreBoard.Score += 2;
    }

    void GoCalled01()
    {
        Debug.Log("Opps!You are wrong. He is playing a football.");
        //this.transform.Translate(Vector3.up * 10.0f);
        ScoreBoard.Score -= 2;
    }

    void GoCalled02()
    {
        Debug.Log("Opps!You are wrong. He is playing a football.");
        //this.transform.Translate(Vector3.up * 10.0f);
        ScoreBoard.Score -= 2;
    }

  
}
