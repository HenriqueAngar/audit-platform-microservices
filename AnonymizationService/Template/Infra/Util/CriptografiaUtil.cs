using System.Security.Cryptography;
using System.Text;

namespace AnonymizationService.Infra.Util;

public static class CriptografiaUtil
{
    public static string Criptografar(
        string texto,
        byte[] chave,
        byte[] iv)
    {
        using var aes = Aes.Create();

        aes.Key = chave;
        aes.IV = iv;

        using var encryptor =
            aes.CreateEncryptor();

        var bytes =
            Encoding.UTF8.GetBytes(texto);

        var resultado =
            encryptor.TransformFinalBlock(
                bytes,
                0,
                bytes.Length);

        return Convert.ToBase64String(
            resultado);
    }

    public static string Descriptografar(
        string textoCriptografado,
        byte[] chave,
        byte[] iv)
    {
        using var aes = Aes.Create();

        aes.Key = chave;
        aes.IV = iv;

        using var decryptor =
            aes.CreateDecryptor();

        var bytes =
            Convert.FromBase64String(
                textoCriptografado);

        var resultado =
            decryptor.TransformFinalBlock(
                bytes,
                0,
                bytes.Length);

        return Encoding.UTF8.GetString(
            resultado);
    }
}