namespace SharpUtil.Enums
{
    public enum HttpMessageStatus
    {
        InvalidPin,
        PinVerification,
        InvalidCredential,
        InvalidUserKey,
        InvalidAuthKey,
        ExpiredUserKey,
        SSLRequired,
        AuthenticationRequired,
        InvalidAuthenticationScheme
    }
}
