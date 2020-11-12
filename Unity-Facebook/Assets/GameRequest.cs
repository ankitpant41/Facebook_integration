using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
public class GameRequest : MonoBehaviour
{
    List<string> toID;
    string fromID;
    public void FacebookGameRequest()
    {
        /* List<string> facebookUserList1 = new List<string>();
         //facebookUserList1.Add("702316293923967");//ls
         facebookUserList1.Add("162942648597274");//personal
         AppConfig.isChallengedGame = true;
         FindObjectOfType<MainMenuScreen>().SelectedUsersToChallenge(facebookUserList1);
         ColyseusClient.Instance.SendFrientRequest(facebookUserList1);
         return;
         */
        FB.AppRequest(
            "Come play Slap Fest!!",
            null, null, null, null, null, null,
            delegate (IAppRequestResult result)
            {
                fromID = result.RequestID;

                List<string> str = new List<string>();
                toID = new List<string>();
                str.AddRange(result.To);
                toID = str;

                List<string> facebookUserList = new List<string>();
                foreach (var item in toID)
                {
                    facebookUserList.Add(item);
                }
                //  AppConfig.isChallengedGame = true;
                //  FindObjectOfType<MainMenuScreen>().SelectedUsersToChallenge(facebookUserList);
                // ColyseusClient.Instance.SendFrientRequest(facebookUserList);
            }
        );
    }
}
