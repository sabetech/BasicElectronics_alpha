using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
 

namespace Tests
{
    public class MyNubianTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void MyNubianTestsSimplePasses()
        {
           

        }

        [Test]
        public void checkIfValueIsTrue()
        {
            // Use the Assert class to test conditions
            QuestionModule qm = new QuestionModule();
            bool response = qm.functionToTest();
            Assert.IsTrue(response);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator MyNubianTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.

            //check if light bulb answer is correct ...
            
            //BlackBoardModule bbm = BlackBoardModule.getInstance();
            //string lightBulbString = "btn_light_bulb_q1";

            //GameObject buttonComponent = new GameObject("lightBulbString");
            //bbm.clickOnWhichCompoent(buttonComponent);

            //string expectedAnswer = bbm.currentResponseExpected;
            //Assert.AreEqual(expectedAnswer, lightBulbString);



            //assert a correct answer check ...



            yield return null;
        }
    }
}
