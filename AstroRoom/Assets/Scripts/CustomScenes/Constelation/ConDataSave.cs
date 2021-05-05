using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public static class ConDataSave
{
    public static readonly string path = "Custom/Scriptable/Constelations/Saved/";

    public static void Save(/*ConstelationData constelationData*/)
    {
        Debug.Log(Application.streamingAssetsPath);
        File.Create(Application.streamingAssetsPath + "/new.text");



    }

    public static ConstelationData Load(string name)
    {
        TextAsset loaded = Resources.Load<TextAsset>(path + name);
        Debug.Log(loaded.ToString());
        return null;
    }
}
