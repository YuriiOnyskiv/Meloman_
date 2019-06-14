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
        int list;
        bool timer = true;
        bool wmp = true;

        [TestMethod()]
        public void MakeMusicTest()
        {
            if (list == 0)
                EndGameTest();

        }
        
        [TestMethod()]
        public void EndGameTest()
        {
            timer = false;
            wmp = false;
        }
       
    }
}