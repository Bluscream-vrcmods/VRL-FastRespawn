using System;
using UnityEngine;
using VRC.Core;

namespace FastRespawn
{
    // Token: 0x0200000C RID: 12
    public class DoShit : MonoBehaviour
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00002444 File Offset: 0x00000644
		public void Awake()
		{
            KeepMeAlive(this);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000244C File Offset: 0x0000064C
		public void Update()
		{
            var currentEvent = Event.current;
			if (currentEvent.control && Input.GetKeyDown(KeyCode.R) )
			{
                if (currentEvent.alt) {
                    WearDefaultAvatar();
                } else if (currentEvent.shift) {
                    Rejoin();
                } else {
				    Respawn();
                }
			}
		}
        // private static void LogFormat(string message, params string[] format) => Log(string.Format(message, format));
        private static void Log(string message, params object[] messages) {
            message = $"[{DateTime.Now}] FastRespawn: {message}";
            foreach (var msg in messages) {
                message += " " + msg.ToString();
            }
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;
        }

		// Token: 0x06000038 RID: 56 RVA: 0x00002482 File Offset: 0x00000682
		static void KeepMeAlive(UnityEngine.Object object_0)
		{
            DontDestroyOnLoad(object_0);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000024A1 File Offset: 0x000006A1
		static void Respawn() {
            Log("Respawning");
            Resources.FindObjectsOfTypeAll<QuickMenu>()[0].Respawn();
		}

        static void Rejoin() {
            var room = RoomManagerBase.currentRoom;
            var worldInstanceId = $"{room.id}:{room.currentInstanceIdWithTags}";
            Log("Rejoining", worldInstanceId);
            VRCSDK2.Networking.GoToRoom(worldInstanceId);
        }

        static void WearDefaultAvatar()
        {
            var defaultAvatarId = RemoteConfig.GetString("defaultAvatar");
            var defaultAvatar = API.Fetch<ApiAvatar>(defaultAvatarId, ApiAvatarRecieved, ApiAvatarFailed, false);
            Log(string.Format("Resetting avatar to %s (%s)", defaultAvatar.name, defaultAvatar.id));
            defaultAvatar.AssignToThisUser();
            // FFCKMPIEEDF.DGINOKDMPPF = defaultAvatar;
            // APIUser.CurrentUser.avatarId = defaultAvatar.id;
            VRCPlayer.Instance.AvatarChanged(); // VRCPlayer.Instance.NAOJNJOFNII();
        }
        internal static void ApiAvatarRecieved(ApiContainer apiContainer) { }
        internal static void ApiAvatarFailed(ApiContainer apiContainer) { }

		// Token: 0x0400002C RID: 44
		public string Credits = "Credit to meep for the Resources thing i just threw it together for you lazy cunts <3 have fun";
	}
}
