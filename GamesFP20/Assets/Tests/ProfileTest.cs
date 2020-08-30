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
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ProfileManager")).GetComponent<ProfileManager>().Start();
            ProfileManager profileManager = ProfileManager.GetInstance();
            Assert.IsTrue(profileManager != null);
        }

        [Test]
        public void ProfileInstanceTest()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ProfileManager")).GetComponent<ProfileManager>().Start();
            ProfileManager profileManager = ProfileManager.GetInstance();
            Profile profile = profileManager.GetProfile();
            Assert.IsTrue(profile != null);

        }
        [Test]
        public void SaveAndLoadTest()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ProfileManager")).GetComponent<ProfileManager>().Start();
            ProfileManager profileManager = ProfileManager.GetInstance();
            profileManager.ClearProfiles();
            Profile profile = profileManager.GetProfile();
            Assert.IsTrue(profile != null);
            profileManager.SaveProfiles();
            profileManager.LoadProfiles();
            Profile profile2 = profileManager.GetProfile();
            Assert.IsTrue(profile2 != null);

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
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ProfileManager")).GetComponent<ProfileManager>().Start();
            ProfileManager profileManager = ProfileManager.GetInstance();
            profileManager.ClearProfiles();
            Profile profile = profileManager.GetProfile();
            Assert.IsTrue(profile != null);
            profileManager.AddProfile();
            Profile profile2 = profileManager.GetProfile();

            Assert.IsTrue(profile.GetID() != profile2.GetID());
            Assert.IsTrue(profile.GetName() == profile2.GetName());
            Assert.IsTrue(profile.GetVolume() == profile2.GetVolume());
            Assert.IsTrue(profile.GetCurrentLevel() == profile2.GetCurrentLevel());
            Assert.IsTrue(profile.GetMaxLevel() == profile2.GetMaxLevel());
            Assert.IsTrue(profile.GetAutoRespawn() == profile2.GetAutoRespawn());
        }


        [Test]
        public void MultipleProfilesTest()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ProfileManager")).GetComponent<ProfileManager>().Start();
            ProfileManager profileManager = ProfileManager.GetInstance();
            profileManager.ClearProfiles();
            profileManager.AddProfile();
            Assert.IsTrue(profileManager.GetProfile().GetID() == 1);
            Assert.IsTrue(profileManager.GetProfileID() == 1);

            profileManager.GetProfile().SetName("Test");
            profileManager.GetProfile().SetVolume(0);
            profileManager.GetProfile().SetCurrentLevel(2);
            profileManager.GetProfile().SetMaxLevel(2);
            profileManager.GetProfile().SetAutoRespawn(true);

            profileManager.SaveProfiles();
            profileManager.LoadProfiles();

            Assert.IsTrue(profileManager.GetProfileID() == 1);
            Assert.IsTrue(profileManager.GetProfile().GetID() == 1);
            Assert.IsTrue(profileManager.GetProfile().GetName() == "Test");
            Assert.IsTrue(profileManager.GetProfile().GetVolume() == 0);
            Assert.IsTrue(profileManager.GetProfile().GetCurrentLevel() == 2);
            Assert.IsTrue(profileManager.GetProfile().GetMaxLevel() == 2);
            Assert.IsTrue(profileManager.GetProfile().GetAutoRespawn() == true);

            profileManager.SetProfileID(0);
            Assert.IsTrue(profileManager.GetProfile().GetID() == 0);
            Assert.IsTrue(profileManager.GetProfile().GetName() == "Player");
            Assert.IsTrue(profileManager.GetProfile().GetVolume() == 100);
            Assert.IsTrue(profileManager.GetProfile().GetCurrentLevel() == 1);
            Assert.IsTrue(profileManager.GetProfile().GetMaxLevel() == 1);
            Assert.IsTrue(profileManager.GetProfile().GetAutoRespawn() == false);
        }
    }
}
