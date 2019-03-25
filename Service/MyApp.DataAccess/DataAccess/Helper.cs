using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public static class Helper{
public static DbConfig LoadConnSgring()
{
    try{
        using (StreamReader r = new StreamReader("dbconfig.json"))
        {
            string json = r.ReadToEnd();
            DbConfig dbConfig = JsonConvert.DeserializeObject<DbConfig>(json);
            return dbConfig;
        }
    }
    catch( Exception e ){
        return new DbConfig();
    }

}

public struct DbConfig{
    public string connString
    {
        get;
        set;
    }
}

}