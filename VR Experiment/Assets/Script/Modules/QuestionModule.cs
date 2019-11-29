using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionModule 
{

    private string question;
    private Answer[] possibleCorrectAnswers;
    private int[] answerIndexes;
    private bool answered_state = false;
    private bool skippable = true;

    enum QuestionType
    {
        regular,
        intervention
    };

    enum MCQ_Type
    {
        revised_mcq,
        select_all_that_apply,
        multiple_true_false_question
    };

    QuestionType questionType;
    int pointEarned;

    public QuestionModule(bool skippable = true)
    {
        this.skippable = skippable;
    }

    //figure out how to include interventions
    public bool functionToTest()
    {
        return true;
    }

}
