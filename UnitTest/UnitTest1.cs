using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GigaBoomLib;
using GigaBoomLib.Data;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            Connection c = new Connection();

        }

        [TestMethod]
        public void TestMethod2()
        {
            User u = new User();
            bool v1 = u.FindLoginName("test2324");
            bool v2 = u.Find(3);
        }

        [TestMethod]
        public void TestMethod3()
        {
            User u = new User();
            u.Insert("Aaaaaa");
            u.AddEmail("test1@email.com","pass1");
        }

        [TestMethod]
        public void TestMethod1001()
        {

            List<PersonProfile> list = new List<PersonProfile>();

            for (int i = 0; i < 200; i++)
            {
                PersonProfile p = DataGenerator.GeneratePersonProfile();
                System.Diagnostics.Debug.WriteLine(string.Format( "{0} \n", p.ToString() ));
                list.Add(p);
            }

        }
    }
}
