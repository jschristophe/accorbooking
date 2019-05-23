using StackExchange.Redis;
using System;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class AzureCacheManager
{
    public static bool IsEnable { get; set; }

    private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
    {
        IsEnable = false;
        string cacheConnection = "appline.redis.cache.windows.net:6380,password=35xFkc2UpL2TFg+ddji6FdqQXpEn1mcThwOZkk+Zzq4=,ssl=True,abortConnect=False";
        return ConnectionMultiplexer.Connect(cacheConnection);
    });

    public static ConnectionMultiplexer Connection
    {
        get
        {
            return lazyConnection.Value;
        }
    }


    public static T Get<T>(string cacheKey)
    {
        try
        {
            if(IsEnable)
                return Deserialize<T>(Connection.GetDatabase().StringGet(cacheKey));
            else
                return default(T);
        }
        catch (Exception e)
        {
            return default(T);
        }
       
    }

    //public static object Get(string cacheKey)
    //{
    //    return Deserialize<object>(Connection.GetDatabase().StringGet(cacheKey));
    //}

    public static void Set(string cacheKey, object cacheValue)
    {
        try
        {
            if (IsEnable)
                Connection.GetDatabase().StringSet(cacheKey, Serialize(cacheValue));
        }
        catch (Exception e)
        {
          
        }
        
    }

    private static byte[] Serialize(object obj)
    {
        if (obj == null)
        {
            return null;
        }
        BinaryFormatter objBinaryFormatter = new BinaryFormatter();
        using (MemoryStream objMemoryStream = new MemoryStream())
        {
            objBinaryFormatter.Serialize(objMemoryStream, obj);
            byte[] objDataAsByte = objMemoryStream.ToArray();
            return objDataAsByte;
        }
    }

    private static T Deserialize<T>(byte[] bytes)
    {
        BinaryFormatter objBinaryFormatter = new BinaryFormatter();
        if (bytes == null)
            return default(T);

        using (MemoryStream objMemoryStream = new MemoryStream(bytes))
        {
            T result = (T)objBinaryFormatter.Deserialize(objMemoryStream);
            return result;
        }
    }
}