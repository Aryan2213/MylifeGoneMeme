using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MyLifeGoneMemeEditMode
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Player_Exists_By_Name()
        {
            // Use the Assert class to test conditions
            var player = GameObject.Find("Player");
            Assert.IsTrue(player != null);
        }
        [Test]
        public void Player_Exists_By_Type()
        {
            // Use the Assert class to test conditions
            var player = GameObject.FindObjectOfType<PlayerPlatformerController>();
            Assert.IsTrue(player != null);
        }
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator MyLifeGoneMemeEditModeWithEnumeratorPasses()
        {

            var enemy = GameObject.FindObjectOfType<Enemy>();

            yield return null;
            Assert.IsTrue(enemy.enemyHit = true);
         

            
            
        }
    }
}
