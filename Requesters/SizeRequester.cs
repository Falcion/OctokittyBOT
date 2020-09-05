using Octokit;

public class SizeRequester {

    public Range SizeRegister(string indexModule, string indexNumber) {

        int sizeNumber = int.Parse(indexNumber);

        if(sizeNumber <= 0) 
            return Range.GreaterThan(0); 

        switch(indexModule) {

            case ">>":
                return Range.GreaterThan(sizeNumber);

            case "<<":
                return Range.LessThan(sizeNumber);

            case "<=":
                return Range.LessThanOrEquals(sizeNumber);

            case ">=":
                return Range.GreaterThanOrEquals(sizeNumber);
        }

        return Range.GreaterThan(0);
    }
}