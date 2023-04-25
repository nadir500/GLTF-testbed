using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GLTFast;
public class GLTFLoadController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Texture Settings")]
    bool generateMipMaps = true;
    [SerializeField]
    [Tooltip("Anistropic Filter Level")]
    int anistropicFilter = 1;
    [SerializeField]
    [Tooltip("Import Model Naming")]
    NameImportMethod nameImportMethod;

    async void Start()
    {
        GltfImport gltfLoader = new GltfImport();
        ImportSettings gltfSettings = new ImportSettings();

        gltfSettings.GenerateMipMaps = generateMipMaps; 
        gltfSettings.AnisotropicFilterLevel = anistropicFilter; 
        gltfSettings.NodeNameMethod = nameImportMethod; 

        var loadedGLTF = await gltfLoader.Load("https://raw.githubusercontent.com/KhronosGroup/glTF-Sample-Models/master/2.0/Duck/glTF-Binary/Duck.glb" , gltfSettings);
        if (loadedGLTF)
        {
            await gltfLoader.InstantiateMainSceneAsync(this.transform);
        }
  
    }
}
