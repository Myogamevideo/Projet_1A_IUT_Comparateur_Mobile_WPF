using EasyPhone.Class;
using EasyPhone.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestEasyPhone
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod()
        {
            Manager m = new Manager(new EasyPhone.Persistance.PersistanceXML());
            for (int i = 0; i < m.apple.Count; i++)
                Console.WriteLine(m.apple[i].Title);

            ListTelephone a = m.apple;
            Telephone pixel3 = new Telephone { Title = "pixel3" };
            bool b = a.Ajouter(pixel3);
            for (int i = 0; i < a.Count; i++)
                Console.WriteLine(a[i].Title);
            Console.WriteLine(b);
        }    
    }
}
