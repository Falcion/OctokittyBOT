using Octokit;

public class FilterRequester {

    public IssueFilter FilterRegister(string filterString) {

        filterString 
                = filterString.Remove(0, 14);

        switch(filterString) {

            case "all":
                return IssueFilter.All;

            case "assigned":
                return IssueFilter.Assigned;

            case "created":
                return IssueFilter.Created;

            case "mentioned":
                return IssueFilter.Mentioned;

            case "subscribed":
                return IssueFilter.Subscribed;
        }

        return IssueFilter.All;
    }
}