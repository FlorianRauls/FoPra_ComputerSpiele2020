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
            profileManager.LoadProfiles();
            Profile profile2 = profileManager.GetProfile();
            Assert.IsTrue(profile2 != null);

            Assert.IsTrue(profile.GetID() == profile2.GetID());
            Assert.IsTrue(profile.GetName() == profile2.GetName());
            Assert.IsTrue(profile.GetVolume() == profile2.GetVolume());
            Assert.IsTrue(profile.GetCurrentLevelS() == profile2.GetCurrentLevelS());
            Assert.IsTrue(profile.GetMaxLevelS() == profile2.GetMaxLevelS());
            Assert.IsTrue(profile.GetCurrentLevelM() == profile2.GetCurrentLevelM());
            Assert.IsTrue(profile.GetMaxLevelM() == profile2.GetMaxLevelM());
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
            Assert.IsTrue(profile.GetCurrentLevelS() == profile2.GetCurrentLevelS());
            Assert.IsTrue(profile.GetMaxLevelS() == profile2.GetMaxLevelS());
            Assert.IsTrue(profile.GetCurrentLevelM() == profile2.GetCurrentLevelM());
            Assert.IsTrue(profile.GetMaxLevelM() == profile2.GetMaxLevelM());
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
            profileManager.GetProfile().SetCurrentLevelS(2);
            profileManager.GetProfile().SetMaxLevelS(2);
            profileManager.GetProfile().SetCurrentLevelM(3);
            profileManager.GetProfile().SetMaxLevelM(3);
            profileManager.GetProfile().SetAutoRespawn(true);

            profileManager.LoadProfiles();

            Assert.IsTrue(profileManager.GetProfileID() == 1);
            Assert.IsTrue(profileManager.GetProfile().GetID() == 1);
            Assert.IsTrue(profileManager.GetProfile().GetName() == "Test");
            Assert.IsTrue(profileManager.GetProfile().GetVolume() == 0);
            Assert.IsTrue(profileManager.GetProfile().GetCurrentLevelS() == 2);
            Assert.IsTrue(profileManager.GetProfile().GetMaxLevelS() == 2);
            Assert.IsTrue(profileManager.GetProfile().GetCurrentLevelM() == 3);
            Assert.IsTrue(profileManager.GetProfile().GetMaxLevelM() == 3);
            Assert.IsTrue(profileManager.GetProfile().GetAutoRespawn() == true);

            profileManager.SetProfileID(0);
            Assert.IsTrue(profileManager.GetProfile().GetID() == 0);
            Assert.IsTrue(profileManager.GetProfile().GetName() == "Player");
            Assert.IsTrue(profileManager.GetProfile().GetVolume() == 100);
            Assert.IsTrue(profileManager.GetProfile().GetCurrentLevelS() == 1);
            Assert.IsTrue(profileManager.GetProfile().GetMaxLevelS() == 1);
            Assert.IsTrue(profileManager.GetProfile().GetCurrentLevelM() == 1);
            Assert.IsTrue(profileManager.GetProfile().GetMaxLevelM() == 1);
            Assert.IsTrue(profileManager.GetProfile().GetAutoRespawn() == false);

            Assert.IsTrue(profileManager.GetProfileCount() == 2);
        }

        [Test]
        public void DeleteProfile()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ProfileManager")).GetComponent<ProfileManager>().Start();
            ProfileManager profileManager = ProfileManager.GetInstance();
            profileManager.ClearProfiles();
            profileManager.AddProfile();
            profileManager.AddProfile();
            profileManager.DeleteProfile(1);
            Assert.IsTrue(profileManager.GetMaxID() == 2);
            Assert.IsTrue(profileManager.GetProfileID() == 1);
            Assert.IsTrue(profileManager.GetProfileCount() == 2);
        }
    }
}
