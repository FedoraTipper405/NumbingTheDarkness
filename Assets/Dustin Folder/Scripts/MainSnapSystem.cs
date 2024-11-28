using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class MainSnapSystem
{
    private static bool snapPositionEnabled = false;
    private static bool snapScaleEnabled = false;
    private static bool snapRotationEnabled = false;

    private static Vector2 positionGridSize = new Vector2(1f, 1f);
    private static Vector2 scaleGridSize = new Vector2(1f, 1f);
    private static float rotationSnapAngle = 15f;

    private static bool isWindowCollapsed = false; // Tracks whether the window is collapsed

    // Link toggles for Position and Scale fields
    private static bool linkPositionFields = true; // Link X and Y for position snapping
    private static bool linkScaleFields = true;    // Link X and Y for scale snapping

    static MainSnapSystem()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private static void OnSceneGUI(SceneView sceneView)
    {
        Handles.BeginGUI();

        // Dynamically calculate the height based on whether the window is collapsed
        int windowHeight = isWindowCollapsed ? 40 : 320; // Adjust for rotation snapping section
        Rect windowRect = new Rect(10, SceneView.lastActiveSceneView.position.height - windowHeight - 10, 200, windowHeight);

        // Draw a collapsible window
        GUILayout.BeginArea(windowRect, GUI.skin.box);
        if (GUILayout.Button(isWindowCollapsed ? "Snap Settings ▲" : "Snap Settings ▼", EditorStyles.boldLabel))
        {
            isWindowCollapsed = !isWindowCollapsed;
        }

        if (!isWindowCollapsed)
        {
            // Position snapping
            GUILayout.Label("Position Snapping", EditorStyles.boldLabel);
            snapPositionEnabled = GUILayout.Toggle(snapPositionEnabled, "Enable Position Snapping");
            GUILayout.Label("Position Grid Size:");

            // X field
            GUILayout.BeginHorizontal();
            GUILayout.Label("X:", GUILayout.Width(20));
            positionGridSize.x = EditorGUILayout.FloatField(positionGridSize.x, GUILayout.Width(50));
            if (!linkPositionFields)
                GUILayout.Space(20); // Add spacing if not linked
            GUILayout.EndHorizontal();

            // Y field with link checkbox
            GUILayout.BeginHorizontal();
            GUILayout.Label("Y:", GUILayout.Width(20));
            if (linkPositionFields)
            {
                positionGridSize.y = positionGridSize.x; // Link X and Y
            }
            positionGridSize.y = EditorGUILayout.FloatField(positionGridSize.y, GUILayout.Width(50));
            linkPositionFields = GUILayout.Toggle(linkPositionFields, "Link", GUILayout.Width(40));
            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            // Scale snapping
            GUILayout.Label("Scale Snapping", EditorStyles.boldLabel);
            snapScaleEnabled = GUILayout.Toggle(snapScaleEnabled, "Enable Scale Snapping");
            GUILayout.Label("Scale Grid Size:");

            // X field
            GUILayout.BeginHorizontal();
            GUILayout.Label("X:", GUILayout.Width(20));
            scaleGridSize.x = EditorGUILayout.FloatField(scaleGridSize.x, GUILayout.Width(50));
            if (!linkScaleFields)
                GUILayout.Space(20); // Add spacing if not linked
            GUILayout.EndHorizontal();

            // Y field with link checkbox
            GUILayout.BeginHorizontal();
            GUILayout.Label("Y:", GUILayout.Width(20));
            if (linkScaleFields)
            {
                scaleGridSize.y = scaleGridSize.x; // Link X and Y
            }
            scaleGridSize.y = EditorGUILayout.FloatField(scaleGridSize.y, GUILayout.Width(50));
            linkScaleFields = GUILayout.Toggle(linkScaleFields, "Link", GUILayout.Width(40));
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
                    position.z // Keep Z unchanged for 2D
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
                    scale.z // Keep Z unchanged for 2D
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
                Vector3 snappedRotation = new Vector3(
                    rotation.x, // Keep X unchanged
                    rotation.y, // Keep Y unchanged
                    Mathf.Round(rotation.z / rotationSnapAngle) * rotationSnapAngle // Snap Z
                );

                transform.eulerAngles = snappedRotation;
            }
        }
    }
}
