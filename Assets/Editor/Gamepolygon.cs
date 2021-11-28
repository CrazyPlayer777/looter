/*  This file is part of the "Simple Waypoint System" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them directly or indirectly
 *  from Rebound Games. You shall not license, sublicense, sell, resell, transfer, assign,
 *  distribute or otherwise make available to any third party the Service or the Content. 
 */

using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
/// Rebound Games about/help/support window.
/// <summary>
public class Gamepolygon : EditorWindow
{
    [MenuItem("Window/GamePolygon Studio")]
    static void Init()
    {
        Gamepolygon aboutWindow = (Gamepolygon)EditorWindow.GetWindowWithRect
                (typeof(Gamepolygon), new Rect(0, 0, 350, 300), false, "GamePolygon");
        aboutWindow.Show();
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(70, 20, 300, 100));
        GUILayout.Label("Smart Looter", EditorStyles.boldLabel);
        GUILayout.Label("by Gamepolygon studio");
        GUILayout.EndArea();
        GUILayout.Space(70);


        GUILayout.Label("Info", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        GUILayout.Label("More Games");
        if (GUILayout.Button("Visit", GUILayout.Width(100)))
        {
            Help.BrowseURL("https://www.sellmyapp.com/author/gamepolygon/");
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Website : UPTO 90% OFF!");
        if (GUILayout.Button("Visit", GUILayout.Width(100)))
        {
            Help.BrowseURL("https://www.gamepolygon.com");
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Documentation");
        if (GUILayout.Button("Visit", GUILayout.Width(100)))
        {
            Help.BrowseURL("http://gamepolygon.com/documentation/");
        }
        GUILayout.EndHorizontal();
        GUILayout.Space(5);

        GUILayout.Label("Support", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Gamepolygon Voucher");
        EditorGUILayout.TextField("HAPPYBUER0", GUILayout.Width(200));

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Skype ID");
        EditorGUILayout.TextField("live:.cid.451c7d888a8e9291", GUILayout.Width(200));

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Email ID");
        EditorGUILayout.TextField("gamepolygon.studio@gmail.com", GUILayout.Width(200));
        GUILayout.EndHorizontal();
        GUILayout.Space(5);

        
    }
}