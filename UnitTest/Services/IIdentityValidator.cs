namespace JobApplicationLibrary.UnitTest.Services
{
    public interface IIdentityValidator
    {
        bool IsValid(string identityNumber);

        bool IsFake(string identityNumber);
    }
}