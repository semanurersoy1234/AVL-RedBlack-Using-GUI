using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static ce205_hw3_open_adressing.Class1;
using static ce205_hw3_hashing_with_chaining.Class1;
using static ce205_hw3_avl_redblack_bplus_tree.Class1;

namespace ce205_hw3_test_cs
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Hashing_With_Chaining_Test1()
        {
            HashSc hashSc = new HashSc();
            hashSc.opentable();
            string LoremText = "Vivamus ultricies pulvinar neque, fringilla vestibulum arcu lacinia a. Etiam.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashSc.insert(i + 1, LoremArray[i]);
            string result = hashSc.retrieve(4);
            string expected = "neque,";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Hashing_With_Chaining_Test2()
        {
            HashSc hashSc = new HashSc();
            hashSc.opentable();
            string LoremText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam molestie.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashSc.insert(i + 1, LoremArray[i]);
            string result = hashSc.retrieve(3);
            string expected = "dolor";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Hashing_With_Chaining_Test3()
        {
            HashSc hashSc = new HashSc();
            hashSc.opentable();
            string LoremText = "Aliquam pharetra interdum mollis. Duis posuere, erat id ultrices ullamcorper.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashSc.insert(i + 1, LoremArray[i]);
            string result = hashSc.retrieve(4);
            string expected = "mollis.";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Open_Addressing_LinearProbing_Test1()
        {
            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ut.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.LinearInsert(i + 1, LoremArray[i]);
            string result = hashOps.GetDataLinearProbing(1);
            string expected = "Lorem";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Open_Addressing_LinearProbing_Test2()
        {
            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "Sed eu venenatis sapien, nec congue lorem. Donec id ante.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.LinearInsert(i + 1, LoremArray[i]);
            string result = hashOps.GetDataLinearProbing(9);
            string expected = "id";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Open_Addressing_LinearProbing_Test3()
        {
            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed tempor.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.LinearInsert(i + 1, LoremArray[i]);
            string result = hashOps.GetDataLinearProbing(3);
            string expected = "dolor";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Open_Addressing_QuadraticProbing_Test1()
        {
            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "In aliquet interdum nulla cursus condimentum. Vestibulum ante ipsum primis.Vestibulum et urna velit. Aenean vitae porttitor mi. Phasellus at.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.QuadraticInsert(i + 1, LoremArray[i]);
            string result = hashOps.GetDataQuadraticProbing(4);
            string expected = "nulla";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Open_Addressing_QuadraticProbing_Test2()
        {
            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer consequat.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.QuadraticInsert(i + 1, LoremArray[i]);
            string result = hashOps.GetDataQuadraticProbing(9);
            string expected = "Integer";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Open_Addressing_QuadraticProbing_Test3()
        {
            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "Mauris pharetra sodales rhoncus. Etiam nec suscipit quam, eget posuere.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.QuadraticInsert(i + 1, LoremArray[i]);
            string result = hashOps.GetDataQuadraticProbing(9);
            string expected = "eget";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Open_Addressing_DoubleHashing_Test1()
        {
            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla mi.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.DoubleHashing(i + 1, LoremArray[i]);
            string result = hashOps.GetDataDoubleHashing(8);
            string expected = "elit.";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Open_Addressing_DoubleHashing_Test2()
        {
            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "Nullam nec libero vel diam viverra consectetur vitae convallis est.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.DoubleHashing(i + 1, LoremArray[i]);
            string result = hashOps.GetDataDoubleHashing(4);
            string expected = "vel";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Open_Addressing_DoubleHashing_Test3()
        {
            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus magna.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.DoubleHashing(i + 1, LoremArray[i]);
            string result = hashOps.GetDataDoubleHashing(4);
            string expected = "sit";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AVLTree_Test1()
        {
            AVLTree tree = new AVLTree();

            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "Integer nec aliquet nisi. Donec gravida efficitur dignissim. Nunc iaculis.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.LinearInsert(i + 1, LoremArray[i]);

            /* Constructing tree given in the above figure */
            for (int i = 1; i < LoremArray.Length; i++)
                tree.root = tree.insert(tree.root, i);

            string result = "";

            tree.root = tree.deleteNode(tree.root, 10);

            result = hashOps.GetDataLinearProbing(tree.search(4).key);

            string expected1 = "nisi.";

            Assert.AreEqual(expected1, result);
        }

        [TestMethod]
        public void AVLTree_Test2()
        {
            AVLTree tree = new AVLTree();

            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "Suspendisse arcu tortor, tempus quis viverra a, dapibus sed metus.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.LinearInsert(i + 1, LoremArray[i]);

            /* Constructing tree given in the above figure */
            for (int i = 1; i < LoremArray.Length; i++)
                tree.root = tree.insert(tree.root, i);

            string result = "";

            tree.root = tree.deleteNode(tree.root, 10);

            result = hashOps.GetDataLinearProbing(tree.search(9).key);

            string expected1 = "sed";

            Assert.AreEqual(expected1, result);
        }

        [TestMethod]
        public void AVLTree_Test3()
        {
            AVLTree tree = new AVLTree();

            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "In id neque odio. Vestibulum rutrum auctor neque ut lacinia.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.LinearInsert(i + 1, LoremArray[i]);

            /* Constructing tree given in the above figure */
            for (int i = 1; i < LoremArray.Length; i++)
                tree.root = tree.insert(tree.root, i);

            string result = "";

            tree.root = tree.deleteNode(tree.root, 10);

            result = hashOps.GetDataLinearProbing(tree.search(3).key);

            string expected1 = "neque";

            Assert.AreEqual(expected1, result);
        }
        [TestMethod]
        public void RedBlackTree1()
        {
            RedBlackTree tree = new RedBlackTree();

            HashOps hashOps = new HashOps();
            hashOps.OpenTable();
            string LoremText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus pulvinar.";
            string[] LoremArray = LoremText.Split();
            for (int i = 0; i < LoremArray.Length; i++)
                hashOps.LinearInsert(i + 1, LoremArray[i]);

            for (int i = 0; i < LoremArray.Length; i++)
                tree.Insert(i + 1);

            string result = hashOps.GetDataLinearProbing(tree.Find(1).data);

            string expected1 = "Lorem";

            Assert.AreEqual(expected1, result);
        }
        
    }
}
