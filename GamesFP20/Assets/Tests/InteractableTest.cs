using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace Tests
{
    public class InterActableTest
    {
        [Test]
        public void TestGetChildCollider()
        {
            GameObject treeObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TreeObject"));
            Interactable tree = treeObject.GetComponent<Interactable>();   
            tree.Start();

            Transform child = treeObject.transform.GetChild(0);
            Collider childCollider = child.GetComponent<Collider>();

            Assert.AreEqual(childCollider, tree.GetChildCollider());   
        }

        [Test]
        public void TestGetChild()
        {
            GameObject treeObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TreeObject"));
            Interactable tree = treeObject.GetComponent<Interactable>();   
            tree.Start();

            Transform child = treeObject.transform.GetChild(0);   

            Assert.AreEqual(child, tree.GetChild());           
        }

        [Test]
        public void TestRotateCorrectly()
        {
            GameObject treeObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TreeObject"));
            Interactable tree = treeObject.GetComponent<Interactable>();     
            tree.Start();

            Vector3 amount = tree.amount;    
            
            GameObject compare = new GameObject();
            compare.transform.rotation = treeObject.transform.rotation;

            tree.Rotate();
            compare.transform.Rotate(amount);

            Assert.AreEqual(compare.transform.rotation, tree.transform.rotation);     
        }

        [Test]
        public void TestRotateOnChildCollisionInteractiveObject()
        {
            GameObject treeObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TreeObject"));
            Interactable tree = treeObject.GetComponent<Interactable>();   
            tree.Start();

            GameObject interactObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/projectile"));

            GameObject compare = new GameObject();
            compare.transform.rotation = treeObject.transform.rotation;  

            tree.Collide(interactObject);

            Assert.AreNotEqual(compare.transform.rotation, treeObject.transform.rotation);             
        }

        [Test]
        public void TestNotRotateOnChildCollisionRandomObject()
        {
            GameObject treeObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TreeObject"));
            Interactable tree = treeObject.GetComponent<Interactable>();          
            tree.Start();
            
            GameObject randomObject = new GameObject();

            GameObject compare = new GameObject();
            compare.transform.rotation = treeObject.transform.rotation;  

            tree.Collide(randomObject);

            Assert.AreEqual(compare.transform.rotation, treeObject.transform.rotation);              
        }
    }
}
