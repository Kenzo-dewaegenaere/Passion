//using System;
//using System.Linq;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Windows.Speech;

//public class AudioController : MonoBehaviour
//{

//    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
//    private KeywordRecognizer keywordRecognizer;

//    private PlayerCombatController spells;
//    public GameObject spellcast;


//    void Start()
//    {

//        spells = spellcast.GetComponent<PlayerCombatController>();
//        //Add keywords and set them to a function
//        keywordActions.Add("Forfeit", Surrender);
//        keywordActions.Add("Surrender", Surrender);


//        //put all the keywords in an array for easy acces, this way we don't need switch cases etc. 
//        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
//        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
//        keywordRecognizer.Start();
//    }

//    private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
//    {
//        Debug.Log("Keyword:" + args.text);
//        keywordActions[args.text].Invoke();
//    }

//    private void Surrender()
//    {
//        spells.TestSpell();
//    }


//}
