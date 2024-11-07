using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{
    public class Testing_Archites : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;

        public TextArchitect.BuildMethod be = TextArchitect.BuildMethod.instant;

        string[] lines = new string[5]
        {
            "This is a random line dialogue.",
            "I want to say somothing, come over here.",
            "The world is crazy place sometime.",
            "Don't lose hope, thing will get better!",
            "It's a bird? It's a plane? No! - It's super Sheltie!"
        };

        void Start ()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.fade;
            architect.speed = .5f;
        }

        void Update()
        {
            if (be !=  architect.buildMethod)
            {
                architect.buildMethod = be;
                architect.Stop();
            }
            if (Input.GetKeyDown(KeyCode.S))
                architect.Stop();
            string longLine = "This is a very long line that makes no sense but I am just populating it with stuff because, you know, stuff is good  right? I like stuff, we all like stuff and the turkey gets stuffed.";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (architect.isBuilding)
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();
                }
                else
                    architect.Build(longLine);
                    //architect.Build(lines[Random.Range(0, lines.Length)]);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                architect.Append(longLine);
                //architect.Append(lines[Random.Range(0, lines.Length)]);
            }
        }
    }
}