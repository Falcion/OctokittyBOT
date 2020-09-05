using Octokit;
using System;

public class UpdateRequester {

    public DateRange UpdateRegister(string enumDate) {

        string[] updateArray = enumDate.Split(' ');

        string[] firstDate = updateArray[0].Split('/');
        string[] secondDate = updateArray[1].Split('/');

        int firstMonth = int.Parse(firstDate[0]);
        int firstDays = int.Parse(firstDate[1]);
        int firstYear = int.Parse(firstDate[2]);

        int secondMonth = int.Parse(secondDate[0]);
        int secondDays = int.Parse(secondDate[1]);
        int secondYear = int.Parse(secondDate[2]);

        if(firstMonth > 12 || firstMonth < 1) 
            return DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), DateTime.Now);

        if(firstDays > 31 || firstDays < 1) 
            return DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), DateTime.Now);

        if(firstYear > DateTime.Now.Year || firstYear < 2011 || firstYear > secondYear)
            return DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), DateTime.Now);

        if(secondMonth > 12 || secondMonth < 1) 
            return DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), DateTime.Now);

        if(secondDays > 31 || secondDays < 1) 
            return DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), DateTime.Now);

        if(secondYear > DateTime.Now.Year || secondYear < 2011)
            return DateRange.Between(new DateTimeOffset(new DateTime(2011, 4, 1)), DateTime.Now);

        DateTimeOffset firstOffset = new DateTimeOffset(new DateTime(firstYear, firstMonth, firstDays));
        DateTimeOffset secondOffset = new DateTimeOffset(new DateTime(secondYear, secondMonth, secondDays));

        return DateRange.Between(firstOffset, secondOffset);
    }
}