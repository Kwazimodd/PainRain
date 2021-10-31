using System;

public static class RandomStrManager
{
    private static string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    public static String GetRandomString(int length)
    {
        String randomString = "";
        for (int i = 0; i < length; i++)
        {
            randomString += alphabet[UnityEngine.Random.Range(0, alphabet.Length-1)];
        }

        return randomString;
    }
}