/**
* @file ce205_hw3_cs
* @author Semanur Ersoy
* @date 13 December 2022
*
* @brief <b> HW-3 Functions </b>
*
* HW-3 Sample Lib Functions
*
* @see http://bilgisayar.mmf.erdogan.edu.tr/en/
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce205_hw3_avl_redblack_bplus_tree
{
    public class Class1
    {
        public class Node
        {
            public int key, height;
            public Node left, right;

            public Node(int d)
            {
                key = d;
                height = 1;
            }
        }

        public class AVLTree
        {
            public Node root;

            // A utility function to get height of the tree 

            /**
            * @name height
            * @param [in] N [\b Node]
            * @retval [\b int]
            * Searching and traversing do not lead to the violation in property of AVL tree. for all nodes. 
            **/
            int height(Node N)
            {
                if (N == null)
                    return 0;
                return N.height;
            }

            // A utility function to 
            // get maximum of two integers 

            /**
            * @name max
            * @param [in] a [\b int]
            * @param [in] b [\b int]
            * @retval [\b int]
            * Insertions and deletions may require the tree to be rebalanced by one or more tree rotations.
            **/
            int max(int a, int b)
            {
                return (a > b) ? a : b;
            }

            // A utility function to right 
            // rotate subtree rooted with y 
            // See the diagram given above. 
            /**
           * @name rightRotate
           * @param [in] y [\b Node]
           * @retval [\b Node]
           * It is observed that BST's worst-case performance is closest to linear search algorithms.
           **/
            Node rightRotate(Node y)
            {
                Node x = y.left;
                Node T2 = x.right;

                // Perform rotation 
                x.right = y;
                y.left = T2;

                // Update heights 
                y.height = max(height(y.left), height(y.right)) + 1;
                x.height = max(height(x.left), height(x.right)) + 1;

                // Return new root 
                return x;
            }

            // A utility function to left 
            // rotate subtree rooted with x 
            // See the diagram given above. 
            /**
            * @name leftRotate
            * @param [in] x [\b Node]
            * @retval [\b Node]
            * A left rotation is performed by making B the new root node of the subtree.
            **/
            Node leftRotate(Node x)
            {
                Node y = x.right;
                Node T2 = y.left;

                // Perform rotation 
                y.left = x;
                x.right = T2;

                // Update heights 
                x.height = max(height(x.left), height(x.right)) + 1;
                y.height = max(height(y.left), height(y.right)) + 1;

                // Return new root 
                return y;
            }

            // Get Balance factor of node N 

            /**
            * @name getBalance
            * @param [in] N [\b Node]
            * @retval [\b int]
            * An AVL tree is a type of binary search tree.
            **/
            int getBalance(Node N)
            {
                if (N == null)
                    return 0;
                return height(N.left) - height(N.right);
            }
            /**
            * @name insert
            * @param [in] node [\b Node]
            * @param [in] key [\b int]
            * @retval [\b Node]
            * Insertion in AVL tree is performed in the same way as it is performed in a binary search tree.
            **/
            public Node insert(Node node, int key)
            {
                /* 1. Perform the normal BST rotation */
                if (node == null)
                    return (new Node(key));

                if (key < node.key)
                    node.left = insert(node.left, key);
                else if (key > node.key)
                    node.right = insert(node.right, key);
                else // Equal keys not allowed 
                    return node;

                /* 2. Update height of this ancestor node */
                node.height = 1 + max(height(node.left),
                                    height(node.right));

                /* 3. Get the balance factor of this ancestor 
                node to check whether this node became 
                Wunbalanced */
                int balance = getBalance(node);

                // If this node becomes unbalanced, then 
                // there are 4 cases Left Left Case 
                if (balance > 1 && key < node.left.key)
                    return rightRotate(node);

                // Right Right Case 
                if (balance < -1 && key > node.right.key)
                    return leftRotate(node);

                // Left Right Case 
                if (balance > 1 && key > node.left.key)
                {
                    node.left = leftRotate(node.left);
                    return rightRotate(node);
                }

                // Right Left Case 
                if (balance < -1 && key < node.right.key)
                {
                    node.right = rightRotate(node.right);
                    return leftRotate(node);
                }

                /* return the (unchanged) node pointer */
                return node;
            }
            /**
            * @name search
            * @param [in] key [\b int]
            * Insertion in AVL tree is performed in the same way as it is performed in a binary search tree.
            **/
            public Node search(int key)
            {
                Node node = root;
                while (node != null)
                {
                    if (key == node.key)
                    {
                        return node;
                    }
                    else if (key < node.key)
                    {
                        node = node.left;
                    }
                    else
                    {
                        node = node.right;
                    }
                }

                return null;
            }

            /* Given a non-empty binary search tree, return the 
            node with minimum key value found in that tree. 
            Note that the entire tree does not need to be 
            searched. */
            /**
            * @name minValueNode
            * @param [in] node [\b Node]
            * @retval [\b Node]
            * AVL trees are mostly used for in-memory sorts of sets and dictionaries.
            **/
            Node minValueNode(Node node)
            {
                Node current = node;

                /* loop down to find the leftmost leaf */
                while (current.left != null)
                    current = current.left;

                return current;
            }
            /**
            * @name deleteNode
            * @param [in] root [\b Node]
            * @param [in] key [\b int]
            * @retval [\b Node]
            * An AVL tree is a type of binary search tree. 
            **/
            public Node deleteNode(Node root, int key)
            {
                // STEP 1: PERFORM STANDARD BST DELETE 
                if (root == null)
                    return root;

                // If the key to be deleted is smaller than 
                // the root's key, then it lies in left subtree 
                if (key < root.key)
                    root.left = deleteNode(root.left, key);

                // If the key to be deleted is greater than the 
                // root's key, then it lies in right subtree 
                else if (key > root.key)
                    root.right = deleteNode(root.right, key);

                // if key is same as root's key, then this is the node 
                // to be deleted 
                else
                {

                    // node with only one child or no child 
                    if ((root.left == null) || (root.right == null))
                    {
                        Node temp = null;
                        if (temp == root.left)
                            temp = root.right;
                        else
                            temp = root.left;

                        // No child case 
                        if (temp == null)
                        {
                            temp = root;
                            root = null;
                        }
                        else // One child case 
                            root = temp; // Copy the contents of 
                                         // the non-empty child 
                    }
                    else
                    {

                        // node with two children: Get the inorder 
                        // successor (smallest in the right subtree) 
                        Node temp = minValueNode(root.right);

                        // Copy the inorder successor's data to this node 
                        root.key = temp.key;

                        // Delete the inorder successor 
                        root.right = deleteNode(root.right, temp.key);
                    }
                }

                // If the tree had only one node then return 
                if (root == null)
                    return root;

                // STEP 2: UPDATE HEIGHT OF THE CURRENT NODE 
                root.height = max(height(root.left),
                            height(root.right)) + 1;

                // STEP 3: GET THE BALANCE FACTOR
                // OF THIS NODE (to check whether 
                // this node became unbalanced) 
                int balance = getBalance(root);

                // If this node becomes unbalanced, 
                // then there are 4 cases 
                // Left Left Case 
                if (balance > 1 && getBalance(root.left) >= 0)
                    return rightRotate(root);

                // Left Right Case 
                if (balance > 1 && getBalance(root.left) < 0)
                {
                    root.left = leftRotate(root.left);
                    return rightRotate(root);
                }

                // Right Right Case 
                if (balance < -1 && getBalance(root.right) <= 0)
                    return leftRotate(root);

                // Right Left Case 
                if (balance < -1 && getBalance(root.right) > 0)
                {
                    root.right = rightRotate(root.right);
                    return leftRotate(root);
                }

                return root;
            }
        }
        //end of the AVL Tree
        public enum Color
        {
            Red,
            Black
        }
        public class RedBlackTree
        {
            /// <summary>
            /// Object of type Node contains 4 properties
            /// Colour
            /// Left
            /// Right
            /// Parent
            /// Data
            /// </summary>
            public class Node
            {
                public Color colour;
                public Node left;
                public Node right;
                public Node parent;
                public int data;

                public Node(int data) { this.data = data; }
                public Node(Color colour) { this.colour = colour; }
                public Node(int data, Color colour) { this.data = data; this.colour = colour; }
            }
            /// <summary>
            /// Root node of the tree (both reference & pointer)
            /// </summary>
            private Node root;
            /// <summary>
            /// New instance of a Red-Black tree object
            /// </summary>
            public RedBlackTree() { }
            /// <summary>
            /// Left Rotate
            /// </summary>
            /// <param name="X"></param>
            /// <returns>void</returns>
            private void LeftRotate(Node X)
            {
                Node Y = X.right; // set Y
                X.right = Y.left;//turn Y's left subtree into X's right subtree
                if (X.parent == null) return;

                if (Y.left != null)
                {
                    Y.left.parent = X;
                }
                if (Y != null)
                {
                    Y.parent = X.parent;//link X's parent to Y
                }
                if (X.parent == null)
                {
                    root = Y;
                }
                if (X == X.parent.left)
                {
                    X.parent.left = Y;
                }
                else
                {
                    X.parent.right = Y;
                }
                Y.left = X; //put X on Y's left
                if (X != null)
                {
                    X.parent = Y;
                }

            }
            /// <summary>
            /// Rotate Right
            /// </summary>
            /// <param name="Y"></param>
            /// <returns>void</returns>
            private void RightRotate(Node Y)
            {
                // right rotate is simply mirror code from left rotate
                Node X = Y.left;
                Y.left = X.right;
                if (X.right != null)
                {
                    X.right.parent = Y;
                }
                if (X != null)
                {
                    X.parent = Y.parent;
                }
                if (Y.parent == null)
                {
                    root = X;
                }
                if (Y == Y.parent.right)
                {
                    Y.parent.right = X;
                }
                if (Y == Y.parent.left)
                {
                    Y.parent.left = X;
                }

                X.right = Y;//put Y on X's right
                if (Y != null)
                {
                    Y.parent = X;
                }
            }
            /// <summary>
            /// Display Tree
            /// </summary>
            public void DisplayTree()
            {
                if (root == null)
                {
                    Console.WriteLine("Nothing in the tree!");
                    return;
                }
                if (root != null)
                {
                    InOrderDisplay(root);
                }
            }
            /// <summary>
            /// Find item in the tree
            /// </summary>
            /// <param name="key"></param>
            public Node Find(int key)
            {
                bool isFound = false;
                Node temp = root;
                Node item = null;
                try
                {
                    while (!isFound)
                    {
                        if (temp == null)
                        {
                            break;
                        }
                        if (key < temp.data)
                        {
                            temp = temp.left;
                        }
                        if (key > temp.data)
                        {
                            temp = temp.right;
                        }
                        if (key == temp.data)
                        {
                            isFound = true;
                            item = temp;
                        }
                    }
                    if (isFound)
                    {
                        Console.WriteLine("{0} was found", key);
                        return temp;
                    }
                    else
                    {
                        Console.WriteLine("{0} not found", key);
                        return null;
                    }
                }
                catch (Exception e)
                {

                }
                return null;
            }
            /// <summary>
            /// Insert a new object into the RB Tree
            /// </summary>
            /// <param name="item"></param>
            public void Insert(int item)
            {
                Node newItem = new Node(item);
                if (root == null)
                {
                    root = newItem;
                    root.colour = Color.Black;
                    return;
                }
                Node Y = null;
                Node X = root;
                while (X != null)
                {
                    Y = X;
                    if (newItem.data < X.data)
                    {
                        X = X.left;
                    }
                    else
                    {
                        X = X.right;
                    }
                }
                newItem.parent = Y;
                if (Y == null)
                {
                    root = newItem;
                }
                else if (newItem.data < Y.data)
                {
                    Y.left = newItem;
                }
                else
                {
                    Y.right = newItem;
                }
                newItem.left = null;
                newItem.right = null;
                newItem.colour = Color.Red;//colour the new node red
                InsertFixUp(newItem);//call method to check for violations and fix
            }
            private void InOrderDisplay(Node current)
            {
                if (current != null)
                {
                    InOrderDisplay(current.left);
                    Console.Write("({0}) ", current.data);
                    InOrderDisplay(current.right);
                }
            }
            private void InsertFixUp(Node item)
            {
                //Checks Red-Black Tree properties
                while (item != root && item.parent.colour == Color.Red)
                {
                    /*We have a violation*/
                    if (item.parent == item.parent.parent.left)
                    {
                        Node Y = item.parent.parent.right;
                        if (Y != null && Y.colour == Color.Red)//Case 1: uncle is red
                        {
                            item.parent.colour = Color.Black;
                            Y.colour = Color.Black;
                            item.parent.parent.colour = Color.Red;
                            item = item.parent.parent;
                        }
                        else //Case 2: uncle is black
                        {
                            if (item == item.parent.right)
                            {
                                item = item.parent;
                                LeftRotate(item);
                            }
                            //Case 3: recolour & rotate
                            item.parent.colour = Color.Black;
                            item.parent.parent.colour = Color.Red;
                            RightRotate(item.parent.parent);
                        }

                    }
                    else
                    {
                        //mirror image of code above
                        Node X = null;

                        X = item.parent.parent.left;
                        if (X != null && X.colour == Color.Black)//Case 1
                        {
                            item.parent.colour = Color.Red;
                            X.colour = Color.Red;
                            item.parent.parent.colour = Color.Black;
                            item = item.parent.parent;
                        }
                        else //Case 2
                        {
                            if (item == item.parent.left)
                            {
                                item = item.parent;
                                RightRotate(item);
                            }
                            //Case 3: recolour & rotate
                            item.parent.colour = Color.Black;
                            item.parent.parent.colour = Color.Red;
                            LeftRotate(item.parent.parent);

                        }

                    }
                    root.colour = Color.Black;//re-colour the root black as necessary
                }
            }
            /// <summary>
            /// Deletes a specified value from the tree
            /// </summary>
            /// <param name="item"></param>
            public void Delete(int key)
            {
                //first find the node in the tree to delete and assign to item pointer/reference
                Node item = Find(key);
                Node X = null;
                Node Y = null;

                if (item == null)
                {
                    Console.WriteLine("Nothing to delete!");
                    return;
                }
                if (item.left == null || item.right == null)
                {
                    Y = item;
                }
                else
                {
                    Y = TreeSuccessor(item);
                }
                if (Y.left != null)
                {
                    X = Y.left;
                }
                else
                {
                    X = Y.right;
                }
                if (X != null)
                {
                    X.parent = Y;
                }
                if (Y.parent == null)
                {
                    root = X;
                }
                else if (Y == Y.parent.left)
                {
                    Y.parent.left = X;
                }
                else
                {
                    Y.parent.left = X;
                }
                if (Y != item)
                {
                    item.data = Y.data;
                }
                if (Y.colour == Color.Black)
                {
                    DeleteFixUp(X);
                }

            }
            /// <summary>
            /// Checks the tree for any violations after deletion and performs a fix
            /// </summary>
            /// <param name="X"></param>
            private void DeleteFixUp(Node X)
            {

                while (X != null && X != root && X.colour == Color.Black)
                {
                    if (X == X.parent.left)
                    {
                        Node W = X.parent.right;
                        if (W.colour == Color.Red)
                        {
                            W.colour = Color.Black; //case 1
                            X.parent.colour = Color.Red; //case 1
                            LeftRotate(X.parent); //case 1
                            W = X.parent.right; //case 1
                        }
                        if (W.left.colour == Color.Black && W.right.colour == Color.Black)
                        {
                            W.colour = Color.Red; //case 2
                            X = X.parent; //case 2
                        }
                        else if (W.right.colour == Color.Black)
                        {
                            W.left.colour = Color.Black; //case 3
                            W.colour = Color.Red; //case 3
                            RightRotate(W); //case 3
                            W = X.parent.right; //case 3
                        }
                        W.colour = X.parent.colour; //case 4
                        X.parent.colour = Color.Black; //case 4
                        W.right.colour = Color.Black; //case 4
                        LeftRotate(X.parent); //case 4
                        X = root; //case 4
                    }
                    else //mirror code from above with "right" & "left" exchanged
                    {
                        Node W = X.parent.left;
                        if (W.colour == Color.Red)
                        {
                            W.colour = Color.Black;
                            X.parent.colour = Color.Red;
                            RightRotate(X.parent);
                            W = X.parent.left;
                        }
                        if (W.right.colour == Color.Black && W.left.colour == Color.Black)
                        {
                            W.colour = Color.Black;
                            X = X.parent;
                        }
                        else if (W.left.colour == Color.Black)
                        {
                            W.right.colour = Color.Black;
                            W.colour = Color.Red;
                            LeftRotate(W);
                            W = X.parent.left;
                        }
                        W.colour = X.parent.colour;
                        X.parent.colour = Color.Black;
                        W.left.colour = Color.Black;
                        RightRotate(X.parent);
                        X = root;
                    }
                }
                if (X != null)
                    X.colour = Color.Black;
            }
            /// <summary>
            /// min node
            /// </summary>
            /// <param name="X">node</param>
            /// <returns></returns>
            private Node Minimum(Node X)
            {
                while (X.left.left != null)
                {
                    X = X.left;
                }
                if (X.left.right != null)
                {
                    X = X.left.right;
                }
                return X;
            }
            private Node TreeSuccessor(Node X)
            {
                if (X.left != null)
                {
                    return Minimum(X);
                }
                else
                {
                    Node Y = X.parent;
                    while (Y != null && X == Y.right)
                    {
                        X = Y;
                        Y = Y.parent;
                    }
                    return Y;
                }
            }
        }
    }
}
