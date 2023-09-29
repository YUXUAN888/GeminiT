public class Latest
{
    /// <summary>
    /// 
    /// </summary>
    public string release { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string snapshot { get; set; }
}

public class VersionsItem
{
    /// <summary>
    /// 
    /// </summary>
    public string id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string url { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string time { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string releaseTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string sha1 { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int complianceLevel { get; set; }
}

public class Root
{
    /// <summary>
    /// 
    /// </summary>
    public Latest latest { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<VersionsItem> versions { get; set; }
}
