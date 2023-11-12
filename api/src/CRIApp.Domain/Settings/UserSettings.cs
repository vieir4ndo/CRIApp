namespace CRIApp.Domain.Settings;

public class UserSettings
{
    public static string SectionName { get; private set;  }= nameof(UserSettings);
    public string PasswordPepper { get; set; }
    public int PasswordHashIterations { get; set; }
}