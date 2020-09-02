using Octokit;

public class FollowersRequester {

    public Range FollowersRegister(string indexChar, string intNumber) {

        int followerRange = int.Parse(intNumber);

        switch(indexChar) {

            case "<<":
                return Range.LessThan(followerRange);

            case ">>":
                return Range.GreaterThan(followerRange);

            case "<=":
                return Range.LessThanOrEquals(followerRange);

            case ">=":
                return Range.GreaterThanOrEquals(followerRange);
        }

        return Range.GreaterThanOrEquals(0);
    }
}