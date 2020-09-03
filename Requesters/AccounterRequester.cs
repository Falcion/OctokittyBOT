using Octokit;

public class AccounterRequester {

    public AccountSearchType AccounterRegister(string accountType) {

        switch(accountType) {

            case "org":
                return AccountSearchType.Org;

            case "user":
                return AccountSearchType.User;
        }

        return AccountSearchType.User;
    }
}