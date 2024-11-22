using UnityEngine;
using UnityEditor;


[InitializeOnLoad]
public class MainSnapSystem : MonoBehaviour
{
    private static bool snapPositionEnabled = true;
    private static bool snapScaleEnabled = true;
    private static bool snapRotationEnabled = true;

    private static Vector2 positionGridSize = new Vector2(1f, 1f);
    private static Vector2 scaleGridSize = new Vector2(1f, 1f);
    private static float rotationSnapAngle = 15f; // Default angle to snap rotations

    private static bool isWindowedCollapsed = false; // Tracks whether the window is collapsed

    static MainSnapSystem()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private static void OnSceneGUI(SceneView sceneView)
    {
        Handles.BeginGUI();

        // Dynamically calculate the height based on whether the window is collapsed
        int windowHeight = isWindowedCollapsed ? 25 : 290;
        Rect windowRect = new Rect(10, SceneView.lastActiveSceneView.position.height - windowHeight - 40, 180, windowHeight);

        // Draw a collapsible window
        GUILayout.BeginArea(windowRect, GUI.skin.box);
        if (GUILayout.Button(isWindowedCollapsed ? "Snap Settings ▲" : "Snap Settings ▼", EditorStyles.boldLabel))
        {
            isWindowedCollapsed = !isWindowedCollapsed;
        }

        if (!isWindowedCollapsed)
        {
            // Position snapping
            GUILayout.Label("Position Snapping", EditorStyles.boldLabel);
            snapPositionEnabled = GUILayout.Toggle(snapPositionEnabled, "Enable Position Snapping");
            GUILayout.Label("Position Grid Size:");

            GUILayout.BeginHorizontal();
            GUILayout.Label("X:", GUILayout.Width(30)); // Label width reduced
            positionGridSize.x = EditorGUILayout.FloatField(positionGridSize.x, GUILayout.Width(50)); // Field width reduced
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Y:", GUILayout.Width(30));
            positionGridSize.y = EditorGUILayout.FloatField(positionGridSize.y, GUILayout.Width(50));
            GUILayout.EndHorizontal();

            GUILayout.Space(10);



            // Scale snapping
            GUILayout.Label("Scale Snapping", EditorStyles.boldLabel);
            snapScaleEnabled = GUILayout.Toggle(snapScaleEnabled, "Enable Scale Snapping");
            GUILayout.Label("Scale Grid Size:");

            GUILayout.BeginHorizontal();
            GUILayout.Label("X:", GUILayout.Width(30));
            scaleGridSize.x = EditorGUILayout.FloatField(scaleGridSize.x, GUILayout.Width(50));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Y:", GUILayout.Width(30));
            scaleGridSize.y = EditorGUILayout.FloatField(scaleGridSize.y, GUILayout.Width(50));
            GUILayout.EndHorizontal();

            GUILayout.Space(10);



            // Rotation snapping
            GUILayout.Label("Rotation Snapping", EditorStyles.boldLabel);
            snapRotationEnabled = GUILayout.Toggle(snapRotationEnabled, "Enable Rotation Snapping");

            GUILayout.BeginHorizontal();
            GUILayout.Label("Degrees:", GUILayout.Width(60));
            rotationSnapAngle = EditorGUILayout.FloatField(rotationSnapAngle, GUILayout.Width(50));
            GUILayout.EndHorizontal();
        }
        GUILayout.EndArea();

        Handles.EndGUI();

        Event e = Event.current;

        // Position snapping logic
        if (Tools.current == Tool.Move && snapPositionEnabled && Selection.activeTransform != null)
        {
            foreach (Transform transform in Selection.transforms)
            {
                Vector3 position = transform.position;
                Vector3 snappedPosition = new Vector3(
                    Mathf.Round(position.x / positionGridSize.x) * positionGridSize.x,
                    Mathf.Round(position.y / positionGridSize.y) * positionGridSize.y,
                    position.z // Keep Z unchanged
                );

                transform.position = snappedPosition;
            }
        }

        // Scale snapping logic
        if (Tools.current == Tool.Scale && snapScaleEnabled && Selection.activeTransform != null)
        {
            foreach (Transform transform in Selection.transforms)
            {
                Vector3 scale = transform.localScale;
                Vector3 snappedScale = new Vector3(
                    Mathf.Round(scale.x / scaleGridSize.x) * scaleGridSize.x,
                    Mathf.Round(scale.y / scaleGridSize.y) * scaleGridSize.y,
                    scale.z // Keep Z unchanged
                );

                transform.localScale = snappedScale;
            }
        }

        // Rotation snapping logic
        if (Tools.current == Tool.Rotate && snapRotationEnabled && Selection.activeTransform != null)
        {
            foreach (Transform transform in Selection.transforms)
            {
                Vector3 rotation = transform.eulerAngles;
                // Snap only the Z-axis, keep X and Y unchanged
                Vector3 snappedRotation = new Vector3(
                    rotation.x,
                    rotation.y,
                    Mathf.Round(rotation.z / rotationSnapAngle) * rotationSnapAngle
                );

                transform.eulerAngles = snappedRotation;
            }
        }
    }
}
