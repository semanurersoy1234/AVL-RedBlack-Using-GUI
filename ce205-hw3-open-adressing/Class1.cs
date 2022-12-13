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

namespace ce205_hw3_open_adressing
{
    public class Class1
    {
        public class HashNode
        {
            public int key;
            public string data;

            /**
            * @name HashNode
            * @param [in] key [\b int]
            * @retval [\b string]
            * The main idea of open addressing is to keep all the data in the same table to achieve it.
            **/
            public HashNode(int key, string value)
            {
                this.key = key;
                this.data = value;
            }
            public int GetKey()
            {
                return this.key;
            }
            public string GetData()
            {
                return this.data;
            }
        }
        public class HashOps
        {
            HashNode[] table;
            const int maxSize = 10;
            #region Utilities
            
            public void OpenTable()
            {
                table = new HashNode[maxSize];
                for (int i = 0; i < maxSize; i++)
                {
                    table[i] = null;
                }
            }
            /**
            * @name CheckOpenSpace
            * @retval [\b bool]
            * A class of collision resolution schemes in which all items are stored within the hash table.
            **/
            public bool CheckOpenSpace()
            {
                bool isOpen = false;
                for (int i = 0; i < maxSize; i++)
                {
                    if (table[i] == null)
                        isOpen = true;
                }
                return isOpen;
            }
            public int Hash1(int key)
            {
                return key % maxSize;
            }
            /**
            * @name Hash2
            * @param [in] key [\b int]
            * @retval [\b int]
            * In open hashing, keys are stored in linked lists attached to cells of a hash table.
            **/
            public int Hash2(int key)
            {
                //Must be non-zero, less than array size, ideally odd
                return 5 - (key % 5);
            }
            #endregion

            #region Operations
            //Linear Insert
            /**
            * @name LinearInsert
            * @param [in] data [\b string]
            * @param [in] key [\b int]
            * In closed hashing, all keys are stored in the hash table itself without the use of linked lists.
            **/
            public void LinearInsert(int key, string data)
            {
                if (!CheckOpenSpace())
                {
                    Console.WriteLine("Table is at full capacity");
                    return;
                }
                int hash = Hash1(key);
                while (table[hash] != null && table[hash].GetKey() != key)
                {
                    hash = (hash + 1) % maxSize;
                }
                table[hash] = new HashNode(key, data);
            }
            //Quadratic Insert
            /**
            * @name QuadraticInsert
            * @param [in] key [\b int]
            * @param [in] data [\b string]
            * The open addressing is another technique for collision resolution.
            **/
            public void QuadraticInsert(int key, string data)
            {
                if (!CheckOpenSpace())
                {
                    Console.WriteLine("Table is at full capacity");
                    return;
                }
                int hash = Hash1(key);
                int j = 0;
                while (table[hash] != null && table[hash].GetKey() != key)
                {
                    j++;
                    hash = (hash + (j * j)) % maxSize;
                }
                table[hash] = new HashNode(key, data);
            }
            //Double Hashing
            /**
            * @name DoubleHashing
            * @param [in] key [\b int]
            * @param [in] data [\b string]
            * Open hashing is a collision avoidence method which uses array of linked list to resolve the collision.
            **/
            public void DoubleHashing(int key, string data)
            {
                if (!CheckOpenSpace())
                {
                    Console.WriteLine("Table is at full capacity");
                    return;
                }
                int hash1 = Hash1(key);
                int hash2 = Hash2(key);
                while (table[hash1] != null && table[hash1].GetKey() != key)
                {
                    hash1 = (hash1 + (hash2 * hash2)) % maxSize;
                }
                table[hash1] = new HashNode(key, data);
            }
            //Get Data through Linear Probing
            /**
            * @name GetDataLinearProbing
            * @param [in] key [\b int]
            * @retval [\b string]
            *  It is also known as the separate chaining method
            **/
            public string GetDataLinearProbing(int key)
            {
                int hash = Hash1(key);
                while (table[hash] != null && table[hash].GetKey() != key)
                {
                    hash = (hash + 1) % maxSize;
                }
                if (table[hash] == null)
                    return "No data mapped with the given key";
                else
                    return table[hash].GetData();

            }
            //Get Data through Quadratic Probing
            /**
            * @name GetDataQuadraticProbing
            * @param [in] key [\b int]
            * @retval [\b string]
            * The difference between the two has to do with whether collisions are stored outside the table
            **/
            public string GetDataQuadraticProbing(int key)
            {
                int hash = Hash1(key);
                int j = 0;
                while (table[hash] != null && table[hash].GetKey() != key)
                {
                    j++;
                    hash = (hash + (j * j)) % maxSize;
                }
                if (table[hash] == null)
                    return "No data mapped with the given key";
                else
                    return table[hash].GetData();

            }
            //Get Data through Double Hashing
            /**
            * @name GetDataDoubleHashing
            * @param [in] key [\b int]
            * @retval [\b string]
            * The simplest form of open hashing defines each slot in the hash table to be the head of a linked list.
            **/
            public string GetDataDoubleHashing(int key)
            {
                int hash1 = Hash1(key);
                int hash2 = Hash2(key);
                while (table[hash1] != null && table[hash1].GetKey() != key)
                {
                    hash1 = (hash1 + (hash2 * hash2)) % maxSize;
                }
                if (table[hash1] == null)
                    return "No data mapped with the given key";
                else
                    return table[hash1].GetData();

            }
            #endregion
        }
    }
}