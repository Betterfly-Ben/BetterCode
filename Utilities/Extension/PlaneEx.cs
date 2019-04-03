using System.Collections;
using System.Collections.Generic;
using Betterfly.BetterCode;
using UnityEngine;

public static partial class PlaneEx {
	public static void Draw(this Plane plane,Color drawColor,int planeLineCount = 100, float planeHalfSize = 5F,bool drawDistance = true)
	{
		Color normalColor = Color.blue; // forward
		Color upColor = Color.green;
		Color rightColor = Color.red;
		float arrowLength = 2F;
		
		//Start draw
		Vector3 planeWorldPoint = -plane.distance * plane.normal;
		Vector3 planeLocalForward = plane.normal; // 以normal为Plane的forward
		
		
		Vector3 planeLocalRight, planeLocalUp;
		if (plane.normal.Approximately(Vector3.up) == false && plane.normal.Approximately(Vector3.down) == false)
		{
			// 以WorldUp为PlaneUp确认PlaneRight
			// Unity是左手坐标系，所以是 up x forward = right
			planeLocalRight = Vector3.Cross(Vector3.up, planeLocalForward).normalized;
			// forward x right = up
			planeLocalUp = Vector3.Cross(planeLocalForward, planeLocalRight).normalized;
		}
		else
		{
			// 以WorldRight为PlaneRight确认PlaneUp
			// Unity是左手坐标系，所以是 forward x right = up
			planeLocalUp = Vector3.Cross(planeLocalForward, Vector3.right).normalized;
			// up x forward = right
			planeLocalRight = Vector3.Cross(planeLocalUp, planeLocalForward).normalized;
		}
		
		//Draw direction
		//forward arrow / normal
		DebugKit.DrawArrow(planeWorldPoint,planeLocalForward * arrowLength, normalColor);
		//right arrow
		DebugKit.DrawArrow(planeWorldPoint,planeLocalRight * arrowLength,rightColor);
		//up arrow
		DebugKit.DrawArrow(planeWorldPoint,planeLocalUp * arrowLength,upColor);

		//Draw distance
		if (drawDistance)
		{
			Debug.DrawRay(planeWorldPoint, plane.normal * plane.distance, drawColor);
		}

		//Draw Mesh
		Vector3 leftDown = planeWorldPoint - planeLocalRight * planeHalfSize - planeLocalUp * planeHalfSize;
		Vector3 leftUp = planeWorldPoint - planeLocalRight * planeHalfSize + planeLocalUp * planeHalfSize;
		Vector3 rightDown = planeWorldPoint + planeLocalRight * planeHalfSize - planeLocalUp * planeHalfSize;
//        Vector3 rightUp = planeWorldPoint + planeLocalRight * planeHalfSize + planeLocalUp * planeHalfSize;

		Vector3 startPoint = leftDown;
		Vector3 endPoint = rightDown;
		Debug.DrawLine(startPoint, endPoint, drawColor);
		Vector3 offset = (leftUp - leftDown) / planeLineCount;
		for (int i = 0; i < planeLineCount; ++i)
		{
			startPoint += offset;
			endPoint += offset;
			Debug.DrawLine(startPoint, endPoint, drawColor);
		}

		startPoint = leftDown;
		endPoint = leftUp;
		Debug.DrawLine(startPoint, endPoint, drawColor);
		offset = (rightDown - leftDown) / planeLineCount;
		for (int j = 0; j < planeLineCount; ++j)
		{
			startPoint += offset;
			endPoint += offset;
			Debug.DrawLine(startPoint, endPoint, drawColor);
		}
	}
}

