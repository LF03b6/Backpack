using System;
using System.Collections.Generic;
using System.IO;
using Backpack.Definitions;
using JetBrains.Annotations;
using Model.Entities;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Editor
{
    public class GenerateItems : EditorWindow
    {
        private string _iconFolder;
        private string _aimFolder;
        private bool _disableButton = true;

        [MenuItem("Tools/批量生成ScriptableObject")]
        public static void ShowWindow()
        {
            GetWindow<GenerateItems>("自定义窗口");
        }

        private void OnGUI()
        {
            GUILayout.Label("Generate Items", EditorStyles.boldLabel);
            GUILayout.Space(10);
            EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 1), Color.gray);
            GUILayout.Space(10);
            GUILayout.Label("Icon文件夹：");
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            _iconFolder = GUILayout.TextField(_iconFolder, GUILayout.Width(200));
            GUILayout.Space(10);
            if (GUILayout.Button("选择文件夹", GUILayout.Width(80)))
            {
                var selected = EditorUtility.OpenFolderPanel("选择文件夹", _iconFolder, "");
                if (selected.Length != 0)
                {
                    _disableButton = false;
                    _iconFolder = selected;
                }
                else
                {
                    _disableButton = true;
                }
            }

            GUILayout.EndHorizontal();
            GUILayout.Space(15);
            GUILayout.Label("目标文件夹(in Asset Resources)：");
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            _aimFolder = GUILayout.TextField(_aimFolder, GUILayout.Width(200));
            GUILayout.Space(10);
            if (GUILayout.Button("选择文件夹", GUILayout.Width(80)))
            {
                var selected = EditorUtility.OpenFolderPanel("选择文件夹", _aimFolder, "");
                if (selected.Length != 0)
                {
                    _disableButton = false;
                    _aimFolder = selected;
                }
                else
                {
                    _disableButton = true;
                }
            }

            GUILayout.EndHorizontal();
            GUILayout.Space(10);
            EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 1), Color.gray);
            GUILayout.Space(10);
            EditorGUI.BeginDisabledGroup(_disableButton);
            if (GUILayout.Button("生成", GUILayout.Width(80)))
            {
                Execute();
            }

            EditorGUI.EndDisabledGroup();
        }

        private void Execute()
        {
            var icons = Directory.GetFiles(_iconFolder);
            var destDirPath = _aimFolder + "/" + Path.GetFileName(_iconFolder);
            var projectRoot = Application.dataPath.Replace("/Assets", ""); // 得到项目根路径
            destDirPath = destDirPath.Replace("\\", "/").Replace(projectRoot + "/", "");
            var names = Enum.GetNames(typeof(DataType));
            var thisType = DataType.Props;
            
            if (!Directory.Exists(destDirPath))
                Directory.CreateDirectory(destDirPath);

            foreach (var nameT in names)
            {
                if (nameT == Path.GetFileName(_iconFolder))
                {
                    thisType = (DataType)Enum.Parse(typeof(DataType), nameT);
                }
            }

            var idC = 1u;
            foreach (var iconPath in icons)
            {
                if (!iconPath.EndsWith(".png", StringComparison.OrdinalIgnoreCase)) continue;

                // 获取无扩展名的文件名（碎片_03）
                var fileNameWithoutExt = Path.GetFileNameWithoutExtension(iconPath);

                // 加载 Texture2D（作为 icon）
                var iconRelativePath = iconPath.Replace("\\", "/").Replace(Application.dataPath, "Assets");
                var texture = AssetDatabase.LoadAssetAtPath<Texture2D>(iconRelativePath);

                if (texture == null)
                {
                    Debug.LogError($"无法加载图像资源: {iconRelativePath}");
                    continue;
                }

                var item = CreateInstance<Item>();
                item.id = idC++;
                item.quality = (QualityType)Random.Range(1, 6);
                var sprite = AssetDatabase.LoadAssetAtPath<Sprite>(iconRelativePath);
                item.icon = sprite;
                item.type = thisType;

                // 构造 asset 路径
                var assetPath = $"{destDirPath}/{fileNameWithoutExt}.asset";

                AssetDatabase.CreateAsset(item, assetPath);
                AssetDatabase.SaveAssets();
            }

            AssetDatabase.Refresh();
        }
    }
}