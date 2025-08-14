public class CertificateGroups
{
    public string Subject { get; set; }
    public bool FindThis { get; set; }

    public CertificateGroups(string subject)
    {
        Subject = subject;
        FindThis = false;
    }
}