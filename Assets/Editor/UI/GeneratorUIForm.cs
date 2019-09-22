using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Master;
using GameEntry = Master.GameEntry;
using GameFramework.DataTable;

public  class GeneratorUIForm : EditorWindow
{
    [MenuItem("Master/CreateUISource")]
   static void init()
    {
        GeneratorUIForm window = GetWindow<GeneratorUIForm>();
    }
    static readonly string path = "/Master/Scripts/UI/UIForms/UISources/";


    private void OnSelectionChange()
    {
        Repaint();
    }

    private void OnGUI()
    {
        GUILayout.Label("选择需要生成界面源文件的对象");
        if (GUILayout.Button("生成界面源文件"))
        {
            if (this.selectGameObject != null)
            {
                CreateUISource();
            }
        }
        selectGameObject = this.getSelectedActiveObj();
        if (selectGameObject != null)
        {
            GUILayout.Label(selectGameObject.name);
        }
    }
    GameObject selectGameObject;
    void CreateUISource()
    {
        string className = selectGameObject.name;
        string fileName = selectGameObject.name;
        StreamWriter sw = new StreamWriter(Application.dataPath + path + fileName + ".cs");
        sw.WriteLine("using UnityEngine;\nusing System.Collections;\n");
        sw.WriteLine("namespace Master");
        sw.WriteLine("{");
        

        sw.WriteLine("\tpublic partial class " + className + ":UGuiForm{\n");
        foreach (Transform item in this.selectGameObject.transform)
        {
            string childname = item.gameObject.name;
            sw.WriteLine("\t\tpublic GameObject " + childname + ";");
            sw.WriteLine("\t\tpublic Vector3 UIOriginalPosition" + childname+";\n");
        }
        sw.WriteLine("#if UNITY_2017_3_OR_NEWER");
        sw.WriteLine("\t\tprotected override void OnInit(object userData)");
        sw.WriteLine("#else");
        sw.WriteLine("\t\tprotected internal override void OnInit(object userData)");
        sw.WriteLine("#endif");
        sw.WriteLine("\t\t{");
        sw.WriteLine("\t\t\tbase.OnInit(userData);");
        foreach (Transform item in this.selectGameObject.transform)
        {
            string childName = item.gameObject.name;
            sw.WriteLine("\t\t\t" + childName + "=this.transform.Find(\"" + childName + "\").gameObject;");
        }
        sw.WriteLine("\t\t}");
        sw.WriteLine("\t}");
        sw.WriteLine("}");
        sw.Flush();
        sw.Close();
        AssetDatabase.Refresh();
    }






    GameObject getSelectedActiveObj()
    {
        return Selection.activeGameObject;
    }

}
