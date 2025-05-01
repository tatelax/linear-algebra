using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MiteredEdgeMesh : MonoBehaviour
{
    // Prism dimensions
    public float width = 1f;
    public float height = 1f;
    public float depth = 1f;
    // How deep the miter cut goes into each prism
    public float miterSize = 0.5f;

    private void Start()
    {
        GenerateMesh();
    }

    void GenerateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.name = "MiteredEdgeMesh";

        // Calculate half-sizes for centering
        float halfH = height / 2f;
        float halfDepth = depth / 2f;
        float halfWidth = width / 2f;

        // --- Define Prism A (extending along +X) ---
        // The left face of Prism A is at x = 0 and the right face is at x = width - miterSize.
        Vector3 a0 = new Vector3(0, -halfH, -halfDepth);
        Vector3 a1 = new Vector3(0,  halfH, -halfDepth);
        Vector3 a2 = new Vector3(0,  halfH,  halfDepth);
        Vector3 a3 = new Vector3(0, -halfH,  halfDepth);
        Vector3 a4 = new Vector3(width - miterSize, -halfH, -halfDepth);
        Vector3 a5 = new Vector3(width - miterSize,  halfH, -halfDepth);
        Vector3 a6 = new Vector3(width - miterSize,  halfH,  halfDepth);
        Vector3 a7 = new Vector3(width - miterSize, -halfH,  halfDepth);

        // --- Define Prism B (extending along +Z) ---
        // The near face of Prism B is at z = 0 and the far face is at z = depth - miterSize.
        Vector3 b0 = new Vector3(-halfWidth, -halfH, 0);
        Vector3 b1 = new Vector3(-halfWidth,  halfH, 0);
        Vector3 b2 = new Vector3( halfWidth,  halfH, 0);
        Vector3 b3 = new Vector3( halfWidth, -halfH, 0);
        Vector3 b4 = new Vector3(-halfWidth, -halfH, depth - miterSize);
        Vector3 b5 = new Vector3(-halfWidth,  halfH, depth - miterSize);
        Vector3 b6 = new Vector3( halfWidth,  halfH, depth - miterSize);
        Vector3 b7 = new Vector3( halfWidth, -halfH, depth - miterSize);

        // --- Define the shared mitered face ---
        // This face is the angled cut that smoothly joins the two prisms.
        // Its four vertices are chosen so that one edge comes from Prism A and the opposite edge from Prism B.
        Vector3 m0 = new Vector3(width - miterSize, -halfH,  halfDepth);       // from Prism A's right face
        Vector3 m1 = new Vector3(width - miterSize,  halfH,  halfDepth);       // from Prism A's right face
        Vector3 m2 = new Vector3( halfWidth,      halfH, depth - miterSize);    // from Prism B's far face
        Vector3 m3 = new Vector3( halfWidth,     -halfH, depth - miterSize);    // from Prism B's far face

        // --- Combine vertices into a single array ---
        Vector3[] vertices = new Vector3[]
        {
            // Prism A (indices 0-7)
            a0, a1, a2, a3,
            a4, a5, a6, a7,
            // Prism B (indices 8-15)
            b0, b1, b2, b3,
            b4, b5, b6, b7,
            // Mitered face (indices 16-19)
            m0, m1, m2, m3
        };

        // --- Define triangles ---
        // Each group of 3 indices makes a triangle (winding order is important)
        int[] triangles = new int[]
        {
            // Prism A faces
            // Left face (x=0)
            0, 1, 2, 0, 2, 3,
            // Right face (x = width-miterSize)
            4, 7, 6, 4, 6, 5,
            // Top face
            1, 5, 6, 1, 6, 2,
            // Bottom face
            0, 3, 7, 0, 7, 4,
            // Back face (side connecting left and right)
            3, 2, 6, 3, 6, 7,

            // Prism B faces
            // Near face (z=0)
            8, 9, 10, 8, 10, 11,
            // Far face (z = depth-miterSize)
            12, 15, 14, 12, 14, 13,
            // Top face
            9, 13, 14, 9, 14, 10,
            // Bottom face
            8, 11, 15, 8, 15, 12,
            // Side face (connecting near and far)
            11, 10, 14, 11, 14, 15,

            // Mitered face (shared angled cut)
            16, 17, 18, 16, 18, 19
        };

        // Assign vertices and triangles to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        // Set the mesh on the MeshFilter
        GetComponent<MeshFilter>().mesh = mesh;
    }
}