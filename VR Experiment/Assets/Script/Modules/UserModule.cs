using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules
{
    public class UserModule
    {

        public class UserProgress
        {
            private int _numQuestionAttempts;
            private int _progressLevel; //(Which part of the unit has the user gotten to) x out y where x is the current position and y is the total
            private int _questionsAnswered;
            private int _questions_skipped;
            private int _questionsAnsweredCorrectly;
            private int _questionsAnsweredIncorrectly;
            private ArrayList _achievements_gained;
            private int _challengesCompleted;
            private int _activities_completed;
            private int _total_completed;

            public int numQuestionAttetmps
            {
                get
                {
                    return _numQuestionAttempts;
                }
                set
                {
                    _numQuestionAttempts = value;
                }
            }

        }


        public UserProgress progress;
        private string name = "Sample Name";
        private string pin = "1234";

        public static UserModule getInstance()
        {
            return null;
        }

        private static UserModule instance = null;
        public static UserModule Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserModule();
                }
                return instance;
            }
        }

        void createDummyUser()
        {
            
        }

        public static UserModule getUserInstance()
        {
            //do WWW request here ...
            UserModule user = new UserModule();
            user.createDummyUser();
            
            return user;
        }

    }





}
