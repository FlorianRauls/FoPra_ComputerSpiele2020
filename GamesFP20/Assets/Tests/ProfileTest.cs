using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ProfileTest
    {
        [Test]
        public void ProfileManagerInstanceTest()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ProfileManager")).GetComponent<ProfileManager>();
            ProfileManager profileManager = ProfileManager.GetInstance();
            Assert.IsTrue(profileManager != null);
        }

        [Test]
        public void ProfileTest()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ProfileManager")).GetComponent<ProfileManager>();
            ProfileManager profileManager = ProfileManager.GetInstance();
            Profile profile = profileManager.GetProfile();
            Assert.IsTrue(profile != null);

        }
        [Test]
        public void SaveAndLoadTest()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ProfileManager")).GetComponent<ProfileManager>();
            ProfileManager profileManager = ProfileManager.GetInstance();
            Profile profile = profileManager.GetProfile();
            Assert.IsTrue(profile != null);
            profileManager.SaveProfiles();
            profileManager.LoadProfiles();
            Profile profile2 = profileManager.GetProfile();

            Assert.IsTrue(profile.GetID() == profile2.GetID());
            Assert.IsTrue(profile.GetName() == profile2.GetName());
            Assert.IsTrue(profile.GetVolume() == profile2.GetVolume());
            Assert.IsTrue(profile.GetCurrentLevel() == profile2.GetCurrentLevel());
            Assert.IsTrue(profile.GetMaxLevel() == profile2.GetMaxLevel());
            Assert.IsTrue(profile.GetAutoRespawn() == profile2.GetAutoRespawn());
        }

        [Test]
        public void CreateProfileTest()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ProfileManager")).GetComponent<ProfileManager>();
            ProfileManager profileManager = ProfileManager.GetInstance();
            Profile profile = profileManager.GetProfile();
            Assert.IsTrue(profile != null);
            Profile profile2 = profileManager.CreateProfile();

            Assert.IsTrue(profile.GetID() == profile2.GetID());
            Assert.IsTrue(profile.GetName() == profile2.GetName());
            Assert.IsTrue(profile.GetVolume() == profile2.GetVolume());
            Assert.IsTrue(profile.GetCurrentLevel() == profile2.GetCurrentLevel());
            Assert.IsTrue(profile.GetMaxLevel() == profile2.GetMaxLevel());
            Assert.IsTrue(profile.GetAutoRespawn() == profile2.GetAutoRespawn());
        }
    }
}
