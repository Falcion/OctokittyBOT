using Octokit;

public class RangeRequester {

    public Range RangeRegister(string indexModule, string indexNumber) {

        int rangeNumber = int.Parse(indexNumber);

        switch(indexModule) {
            
            case ">>":
                return Range.GreaterThan(rangeNumber);

            case "<<":
                return Range.LessThan(rangeNumber);

            case ">=":
                return Range.GreaterThanOrEquals(rangeNumber);

            case "<=":
                return Range.LessThanOrEquals(rangeNumber);
        }
        
        return Range.GreaterThanOrEquals(0);
    }
}