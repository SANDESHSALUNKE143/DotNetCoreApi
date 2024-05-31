namespace HereWeGo;



public class RandomPasswordGenerator
{
    private static readonly Random random = new Random();

    public static string GeneratePassword(int length)
    {
        const string lowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
        const string uppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string digits = "0123456789";
        const string specialCharacters = "!@#$%^&*()-=_+[]{}|;:,.<>?";

        string password = string.Empty;

        // Generate the first character
        password += GetRandomCharacter(uppercaseLetters);

        // Generate the rest of the password
        while (password.Length < length)
        {
            int category = random.Next(4);

            switch (category)
            {
                case 0:
                    password += GetRandomCharacter(lowercaseLetters);
                    break;
                case 1:
                    password += GetRandomCharacter(uppercaseLetters);
                    break;
                case 2:
                    password += GetRandomCharacter(digits);
                    break;
                case 3:
                    password += GetRandomCharacter(specialCharacters);
                    break;
            }
        }

        return password;
    }

    private static char GetRandomCharacter(string characterSet)
    {
        int index = random.Next(characterSet.Length);
        return characterSet[index];
    }
}


