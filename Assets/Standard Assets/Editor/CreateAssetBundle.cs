using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateAssetBundle  {


    [MenuItem("Assets/ExportAssetBundle")]
    static void Export()
    {
        System.IO.Directory.CreateDirectory(Application.streamingAssetsPath);
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
