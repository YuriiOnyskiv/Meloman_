using Microsoft.VisualStudio.TestTools.UnitTesting;
using Meloman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meloman.Tests
{
    [TestClass()]
    public class fGameTests
    {
         bool timer, wmp = true;
         int lista = 0; 
        
        [TestMethod()]
        public void GamePauseTest()
        {
            timer = false;
            wmp = false;
        
        }
        [TestMethod()]
        public void EndGameTest()
        {
            if (lista == 0)
                timer = false;
                wmp = false;
        }
        [TestMethod()]
        public void MakeMusicTest()
        {
            if (lista == 0)
                EndGameTest();
            else
            {
                timer = true;
                wmp = true;
            }
            Assert.IsFalse(timer);
            Assert.IsFalse(wmp);
        }

        [TestMethod()]
        public void GamePlayTest()
        {

        }
        [TestMethod()]
        public void fGameKeyDownTest()
        {
            if (lista == 0)
                EndGameTest();
            else
            {
                timer = true;
                wmp = true;
            }
            Assert.IsFalse(timer);
            Assert.IsFalse(wmp);
        }
    }
}