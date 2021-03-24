using UnityEngine;

namespace ToolsSystem.Test
{
	public class CameraPositionConverter
	{
		private readonly Camera _camera3D;
		private readonly Camera _camera2D;
		private readonly float _camera2dDistance;

		public CameraPositionConverter(Camera camera3D, Camera camera2D, Canvas canvas)
		{
			_camera3D = camera3D;
			_camera2D = camera2D;
			_camera2dDistance = canvas.planeDistance;
		}

		public Vector3 Convert3dTo2d(Vector3 worldPosition)
		{
			var screenPosition = _camera3D.WorldToScreenPoint(worldPosition);
			var position2d = _camera2D.ScreenToWorldPoint(screenPosition) + _camera3D.transform.forward * _camera2dDistance;
			return position2d;
		}
	}
}