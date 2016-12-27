using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadAsset : MonoBehaviour {

    string status = string.Empty;

	void Start () {
        AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/scene");
        SceneManager.LoadScene("stage", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("stage"));
	}

    public void LoadPlayerAssetBundle()
    {
        StartCoroutine(LoadAssetCoroutine("player", "Player"));
    }

    public void LoadBallAssetBundle()
    {
        StartCoroutine(LoadAssetCoroutine("ball", "Ball"));
    }

    IEnumerator LoadAssetCoroutine(string assetbundleName, string restartTag)
    {
        status = string.Format("load assetbundle {0}", assetbundleName);
        yield return AssetBundle.LoadFromFileAsync(Application.streamingAssetsPath + "/" + assetbundleName);
        status = "done";

        foreach ( var obj in GameObject.FindGameObjectsWithTag(restartTag))
        {
            obj.SetActive(false);
            obj.SetActive(true);
        }
    }

    void OnGUI()
    {
        GUILayout.Label(status);
    }
}