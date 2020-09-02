using Octokit;

public class RepositoryRequester {

    public Range RepositoryRegister(string indexChar, string intNumber) {

        int repositoryRange = int.Parse(intNumber);

        switch(indexChar) {

            case "<<":
                return Range.LessThan(repositoryRange);

            case ">>":
                return Range.GreaterThan(repositoryRange);

            case "<=":
                return Range.LessThanOrEquals(repositoryRange);

            case ">=":
                return Range.GreaterThanOrEquals(repositoryRange);
        }

        return Range.GreaterThanOrEquals(0);
    }
}