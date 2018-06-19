using UnityEditor;

public class TexturePreProcessor : AssetPostprocessor
{
    private void OnPreprocessTexture()
    {
        TextureImporter textureImporter  = (TextureImporter)assetImporter;

        if (textureImporter.textureType == TextureImporterType.Sprite)
        {
            textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
        }
    }
}