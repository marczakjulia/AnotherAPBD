using System.Text.RegularExpressions;

namespace AnotherAPBD;
/// <summary>
/// Interface for assesing the validity of IP via the use of regex
/// </summary>
public static class IpAddressValidator
{
    private static readonly Regex IpRegex = new Regex("^((25[0-5]|(2[0-4]|1\\d|[1-9]|)\\d)\\.?\\b){4}$");
    /// <summary>
    /// function for checking if valid IP
    /// </summary>
    /// <param name="ipAddress">IP address which is later compared to regex</param>
    public static bool IsValid(string ipAddress)
    {
        if (string.IsNullOrWhiteSpace(ipAddress))
            return false;

        return IpRegex.IsMatch(ipAddress);
    }
}