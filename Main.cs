using UnityEngine;
using VRLoader.Attributes;
using VRLoader.Modules;

namespace FastRespawn
{
    // Token: 0x0200000D RID: 13
    [ModuleInfo("Respawn / Rejoin / ResetAvatar (CTRL+R / CTRL+SHIFT+R / CTRL+ALT+R)", "1.5", "Oswald, Bluscream")]
	public class Main : VRModule
	{
		private static GameObject gameObject_0;
		// Token: 0x0600003D RID: 61 RVA: 0x000024A9 File Offset: 0x000006A9
		public void Start()
		{
            gameObject_0 = new GameObject();
            gameObject_0.AddComponent<DoShit>();
		}
	}
}
