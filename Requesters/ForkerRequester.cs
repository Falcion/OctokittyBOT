using Octokit;

public class ForkerRequester {

    public ForkQualifier ForkerRegister(string enumFork) {

        switch(enumFork) {

            case "true":
                return ForkQualifier.OnlyForks;

            case "false":
                return ForkQualifier.IncludeForks;
        }

        return ForkQualifier.IncludeForks;
    }
}