using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName ="New Dialogue", menuName = "New Dialogue/Dialogue")]
public class dialogue_settings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentences> dialogues = new List<Sentences>();

}
[System.Serializable]
public class Sentences{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}
[System.Serializable]
public class Languages{
    public string portuguese, english, spanish;
}

#if UNITY_EDITOR
[CustomEditor(typeof(dialogue_settings))]
public class BuilderEditor : Editor{
    public override void OnInspectorGUI(){
        DrawDefaultInspector();

        dialogue_settings ds = (dialogue_settings)target;

        Languages l = new Languages();
        Sentences s = new Sentences();

        l.portuguese = ds.sentence;

        s.profile = ds.speakerSprite;
        s.sentence = l;

        if(GUILayout.Button("Create Dialogue")){
            if(ds.sentence != ""){
                ds.dialogues.Add(s);

                ds.speakerSprite = null;
                ds.sentence = "";
            }
        }
    }
}
#endif