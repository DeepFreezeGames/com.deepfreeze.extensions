using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class ScriptableObjectExtensions
{
    public static T CreateAsset<T>(string path, string fileName) where T : ScriptableObject
    {
        return (T)CreateAsset(typeof (T), path, fileName);
    }

    public static T CreateAsset<T>(string path, string fileName, bool saveAndRefresh) where T : ScriptableObject
    {
        return (T)CreateAsset(typeof(T), path, fileName, saveAndRefresh);
    }

    public static ScriptableObject CreateAsset(Type type, string savePath, string fileName, bool saveAndRefresh = true)
    {
        if (savePath == string.Empty || Directory.Exists(savePath) == false)
        {
            Debug.LogWarning($"The directory you're trying to save to doesn't exist! ({savePath})");
            return null;
        }

        var asset = ScriptableObject.CreateInstance(type);
        if (fileName.EndsWith(".asset") == false)
        {
            fileName = $"{fileName}.asset";
        }

        if (savePath.Contains(Application.dataPath))
        {
            savePath = $"Assets{savePath.Replace(Application.dataPath, "")}";
        }

        AssetDatabase.CreateAsset(asset, savePath + "/" + fileName);
        AssetDatabase.SetLabels(asset, new[] { type.Name });
        if (saveAndRefresh)
        {
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        return asset;
    }

    public static T CreateAssetChooseSaveFolder<T>(string defaultFileName, bool saveAndRefresh)
        where T : ScriptableObject
    {
        var path = EditorUtility.SaveFilePanelInProject("Save file", defaultFileName, "asset", "Choose a location where to save.");
        if (path.EndsWith(".asset"))
        {
            var indexOf = path.LastIndexOf(Path.DirectorySeparatorChar);
            if (indexOf == -1)
            {
                indexOf = path.LastIndexOf('/');
            }

            path = path.Substring(0, indexOf);
        }

        return string.IsNullOrEmpty(path) == false ? CreateAsset<T>(path, defaultFileName, saveAndRefresh) : null;
    }
}
