using UnityEngine;

public class Rope_Generator : MonoBehaviour
{
    //--- Public Variables ---//
    public GameObject m_startPrefab;
    public GameObject m_middlePrefab;
    public GameObject m_endPrefab;
    public float m_spawnDistance;
    public int m_numMiddleSections;



    //--- Private Variables ---//
    private GameObject m_prevPiece;
    private Vector3 m_spawnPos;



    //--- Unity Methods ---//
    public void Start()
    {
        // Init the private variables
        m_prevPiece = null;
        m_spawnPos = this.transform.position;

        // Generate the rope
        GenerateRope();
    }



    //--- Methods ---//
    public void GenerateRope()
    {
        // Clear the rope first
        ClearRope();

        // Spawn the initial piece
        m_prevPiece = SpawnSection(m_startPrefab);

        // Spawn the middle pieces
        for (int i = 0; i < m_numMiddleSections; i++)
        {
            m_prevPiece = SpawnSection(m_middlePrefab);
        }

        // Spawn the end piece
        m_prevPiece = SpawnSection(m_endPrefab);
    }
    
    public void ClearRope()
    {
        // Loop through all of the children and destroy them
        for (int i = 0; i < this.transform.childCount; i++)
        {
            DestroyImmediate(this.transform.GetChild(i).gameObject);
            i--;
        }

        // Reset the other information
        this.m_spawnPos = this.transform.position;
        this.m_prevPiece = null;
    }



    //--- Utility Functions ---//
    private GameObject SpawnSection(GameObject _prefabObject)
    {
        // Instantiate a new rope section
        GameObject newPiece = Instantiate(_prefabObject, m_spawnPos, Quaternion.identity, this.transform);

        // Add the rigidbody if it doesn't have one
        if (newPiece.GetComponent<Rigidbody>() == null)
        {
            newPiece.AddComponent<Rigidbody>();
        }
        
        // If there is a previous piece to attach to, we should add a hinge joint and link them
        if (m_prevPiece != null)
        {
            HingeJoint jointComp = newPiece.AddComponent<HingeJoint>();
            jointComp.connectedBody = m_prevPiece.GetComponent<Rigidbody>();
        }

        // Increase the spawn pos
        m_spawnPos += (Vector3.forward * m_spawnDistance);

        // This newly spawned piece is the next piece so we should return it
        return newPiece;
    }
}
