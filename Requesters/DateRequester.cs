using Octokit;
using System;

public class DateRequester {

    public DateRange DateRegister(string enumDate) {

        string[] enumArray = enumDate.Split(' ');
        string[] enumDater = enumArray[1].Split('/');

        int month = int.Parse(enumArray[0]);
        int days = int.Parse(enumArray[1]);
        int year = int.Parse(enumArray[2]);

        if(month > 12 || month < 1) 
            return DateRange.GreaterThanOrEquals(new DateTimeOffset(new DateTime(2011, 4, 1)));

        if(days > 31 || days < 1) 
            return DateRange.GreaterThanOrEquals(new DateTimeOffset(new DateTime(2011, 4, 1)));

        if(year > DateTime.Now.Year || year < 2011)
            return DateRange.GreaterThanOrEquals(new DateTimeOffset(new DateTime(2011, 4, 1)));

        switch(enumArray[0]) {

            case ">>":
                return DateRange.GreaterThan(new DateTimeOffset(new DateTime(year, month, days)));

            case "<<":
                return DateRange.LessThan(new DateTimeOffset(new DateTime(year, month, days)));

            case ">=":
                return DateRange.GreaterThanOrEquals(new DateTimeOffset(new DateTime(year, month, days)));

            case "<=":
                return DateRange.LessThanOrEquals(new DateTimeOffset(new DateTime(year, month, days)));
        }       

        return DateRange.GreaterThanOrEquals(new DateTimeOffset(new DateTime(2011, 4, 1)));
    }
}