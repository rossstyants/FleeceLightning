using UnityEngine;
using System.Collections;

namespace Default.Namespace{
public class AchievementDetails : MonoBehaviour {

				public Profile.Enum2 achievementType;
	public string achievementName;
	public bool dontShowHeading;

//	[TextArea(3,10)]
//	public string achievementDescriptionBig ;
	[TextArea(3,10)]
	public string achievementDescription ;

}
}