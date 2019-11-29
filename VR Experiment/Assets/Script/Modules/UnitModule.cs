using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


//[System.Serializable]
public class UnitModule
{

    public string name;
    public string description;
    public int unit_number;
    public UnitContent unit_content;
    PrefabManager prefabMgr;
    MainManager mainMgr;

    private static UnitModule instance;

    private UnitModule()
    {
    }

    public static UnitModule Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UnitModule();
            }
            return instance;
        }
    }
    
    public class UnitContent
    {
        public string[] info_dialog;
        public MediaContent[] mediaContents;
        public TitleInfo title;

    }

    //refer from JSON to create the class ... serialize the class ... temporarily
    //ExplainerVid explainerVid;

    public void init()
    {
        Debug.Log("Init Called!!!");
        mainMgr = MainManager.getInstance();
        mainMgr.callSampleFunction();
        //mainMgr.getDataFromServer("localhost/nubian_web/Unit.json");

        prefabMgr = PrefabManager.getInstance();
        prefabMgr.callSomeFunction();
        

    }

    public void begin()
    {
        Debug.Log("begin called ");
        //Load title First!
        loadTitle();

    }

    public void loadTitle()
    {
        Debug.Log("Load the title");
        prefabMgr.showTitle("Test\nTitle","Unit_Module","Some description goes here!");
        
    }
}

public class MediaContent
{
    string file_source;
    string media_description;
    string title;
    string type;
}

public class TitleInfo
{
    public string title = "Basic Electronics";
    public string unit_info = "Unit 3: Diodes";
    public string unit_desc = "Some nice info about Diodes goes here!";
    public string unit_graphic;
}

/*
{
  "unit_meta":{
    "name":"Basic Electronic1",
    "unit_number":1,
    "description":"some description of the unit is here"
  },
  "unit_content": {
    "explainer_animations":[
      {
        "name":"some animation about diodes",
        "description":"some description of the video goes here",
        "link":"http://servername/filename.mp4"
      },
      {
        "name":"some animation about diodes",
        "description":"some description of the video goes here",
        "link":"http://servername/filename.mp4"
      }
      ],
    "multi_choice_questions":[
      {
        "question":{
          "question_text": "How many terminals does a dry cell have",
          "MCQ_Type": 
          "possible_answers":[
            {
              "answer": "one",
              "state": "incorrect",
              "reason": "some reason goes here"
            }, 
            {
              "answer": "two",
              "state": "correct",
              "reason": "some reason goes here"
            },
            {
              "answer": "five",
              "state": "incorrect",
              "reason": "some reason goes here"
            },
            {
              "answer": "deux",
              "state": "correct",
              "reason": "some reason goes here"
            },
            {
              "answer": "forty",
              "state": "incorrect",
              "reason": "some reason goes here"
            }
            ],
          "possible_correct_answers":[3, 4],
          "question_type":"regular/intervention",
          "points": 3,
          "achievement": "some_achievement_gained?"
        }
        
      },
      {
        "question":{
          "question_text": "How many terminals does a dry cell have",
          "possible_answers":[
            {
              "answer": "one",
              "state": "incorrect",
              "reason": "some reason goes here"
            }, 
            {
              "answer": "two",
              "state": "correct",
              "reason": "some reason goes here"
            },
            {
              "answer": "five",
              "state": "incorrect",
              "reason": "some reason goes here"
            },
            {
              "answer": "deux",
              "state": "correct",
              "reason": "some reason goes here"
            },
            {
              "answer": "forty",
              "state": "incorrect",
              "reason": "some reason goes here"
            }
            ],
          "possible_correct_answers":[3, 4],
          "question_type":"regular/intervention",
          "points": 3,
          "achievement": "some_achievement_gained?"
        }
        
      }
      ],
    "interactive_3ds":[
      {
        "activity":{
          "activity_uuid": "6bf3a8ccafb10"  
        }
      },
      {
        "activity":{
          "activity_uuid": "435fab215af54"  
        }
      }
      ],
    "video360s":[
        {
          "name":"some animation about diodes",
          "description":"some description of the video goes here",
          "link":"http://servername/filename.mp4"
        },
        {
          "name":"some animation about diodes",
          "description":"some description of the video goes here",
          "link":"http://servername/filename.mp4"
        }
      ],
    "challenges": [],
    "achievements":[],
    "info_dialog": [
      "Begin Experience\Ready, Go",
      "Lesson Preface 1/2\nBuilding upon what we learnt in lesson 1 & 2, in this lesson we will learn how to control the direction of current in circuits using Diodes",
      Lesson Preface 2/2\nAfter this lesson you’ll be able to:\n<Objective 1>\n<Objective 2>\n<Objective 3>,
      ]
  },
  "unit_progress" : [
    {
      "info_dialog": 0
    },
    {
      "info_dialog": 1
    },
    {
      "info_dialog": 2
    },
    {
      "explainer_animations": 0
    }
  ]
}


*/
