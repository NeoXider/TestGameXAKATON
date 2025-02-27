using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class OpenWindowsOnLoad
{
    static OpenWindowsOnLoad()
    {
        EditorApplication.delayCall += WelcomeWindow.OpenWindow;
    }
}

public class WelcomeWindow : EditorWindow
{
    const string WindowTitle = "Algoritmika";
    const string doc = "https://docs.google.com/document/d/1oNgSP7tc48sc3GuITt-M9-cc-JzJlb-_RPO_0XkyX0k/edit?tab=t.nkxniar8a393";
    Texture imageAlgo, imageNeo;
    string imageNameNeo = "SlimeNeoxider";
    string imageNameAlgo = "Algoritmika";
    bool initialized = false;

    [MenuItem("Tools/Algoritmika")]
    public static void ShowWindow()
    {
        GetWindow<WelcomeWindow>("Welcome");
    }

    public static void OpenWindow()
    {
        WelcomeWindow wnd = GetWindow<WelcomeWindow>(true);
        wnd.titleContent = new GUIContent(WindowTitle);
        wnd.minSize = new Vector2(650, 650);
        wnd.maxSize = wnd.minSize;
    }

    public void OnGUI()
    {
        if (!initialized)
        {
            string[] images = AssetDatabase.FindAssets(imageNameNeo + " t:Texture");
            if (images.Length > 0)
            {
                imageNeo = AssetDatabase.LoadAssetAtPath<Texture>(AssetDatabase.GUIDToAssetPath(images[0]));
            }

            images = AssetDatabase.FindAssets(imageAlgo + " t:Texture");
            if (images.Length > 0)
            {
                imageAlgo = AssetDatabase.LoadAssetAtPath<Texture>(AssetDatabase.GUIDToAssetPath(images[0]));
            }
            initialized = true;
        }

        float imageHeight = 50;
        float imageWidth = 250;
        float margin = 5;

        if (imageAlgo != null)
        {
            GUI.DrawTexture(new Rect(position.width / 2 - imageWidth / 2, margin, imageWidth, imageHeight), imageAlgo, ScaleMode.ScaleToFit);
        }

        imageHeight = 300;
        imageWidth = 300;
        margin = 70;

        if (imageNeo != null)
        {
            GUI.DrawTexture(new Rect(position.width / 2 - imageWidth / 2, margin, imageWidth, imageHeight), imageNeo, ScaleMode.ScaleToFit);
        }

        GUILayout.BeginArea(new Rect(20, imageHeight + 2 * margin, position.width - margin * 2, position.height - imageHeight + 2 * margin));
        GUILayout.Label(
@"Приветствую разработчиков!

Этот ассет предназначен для создания приключенческих игр.

Создатель этого ассета:
Преподаватель Алгоритмики Бочкарников Виктор");


        if (GUILayout.Button("Документация"))
        {
            Application.OpenURL(doc);
        }
        GUILayout.EndArea();
    }

}