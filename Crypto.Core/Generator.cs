namespace Crypto.Core;

public static class Generator
{
    public static string GenerateNft()
    {        
        var guid = Guid.NewGuid();
        var nft = $"Newly Generated NFT (don't right-click): {guid}";
        return nft;
    }
}
