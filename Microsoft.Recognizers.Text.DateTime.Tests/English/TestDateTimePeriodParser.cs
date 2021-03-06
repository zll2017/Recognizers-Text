﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateObject = System.DateTime;

namespace Microsoft.Recognizers.Text.DateTime.English.Tests
{
    [TestClass]
    public class TestDateTimePeriodParser
    {
        readonly IExtractor extractor;
        readonly IDateTimeParser parser;

        readonly DateObject referenceTime;

        public TestDateTimePeriodParser()
        {
            referenceTime = new DateObject(2016, 11, 7, 16, 12, 0);
            extractor = new BaseDateTimePeriodExtractor(new EnglishDateTimePeriodExtractorConfiguration());
            parser = new BaseDateTimePeriodParser(new EnglishDateTimePeriodParserConfiguration(new EnglishCommonDateTimeParserConfiguration()));
        }

        public void BasicTestFuture(string text, DateObject beginDate, DateObject endDate)
        {
            var er = extractor.Extract(text);
            Assert.AreEqual(1, er.Count);
            var pr = parser.Parse(er[0], referenceTime);
            Assert.AreEqual(Constants.SYS_DATETIME_DATETIMEPERIOD, pr.Type);
            Assert.AreEqual(beginDate,
                ((Tuple<DateObject, DateObject>) ((DateTimeResolutionResult) pr.Value).FutureValue).Item1);
            Assert.AreEqual(endDate,
                ((Tuple<DateObject, DateObject>) ((DateTimeResolutionResult) pr.Value).FutureValue).Item2);
        }

        public void BasicTest(string text, string luisValueStr)
        {
            var er = extractor.Extract(text);
            Assert.AreEqual(1, er.Count);
            var pr = parser.Parse(er[0], referenceTime);
            Assert.AreEqual(Constants.SYS_DATETIME_DATETIMEPERIOD, pr.Type);
            Assert.AreEqual(luisValueStr, ((DateTimeResolutionResult) pr.Value).Timex);
        }

        [TestMethod]
        public void TestDateTimePeriodParse()
        {
            int year = 2016, month = 11, day = 7, min = 0, second = 0;

            // basic match
            BasicTestFuture("I'll be out five to seven today",
                new DateObject(year, month, day, 5, min, second),
                new DateObject(year, month, day, 7, min, second));
            BasicTestFuture("I'll be out from 5 to 6 of 4/22/2016",
                new DateObject(2016, 4, 22, 5, min, second),
                new DateObject(2016, 4, 22, 6, min, second));
            BasicTestFuture("I'll be out from 5 to 6 of April 22",
                new DateObject(year + 1, 4, 22, 5, min, second),
                new DateObject(year + 1, 4, 22, 6, min, second));
            BasicTestFuture("I'll be out from 5 to 6pm of April 22",
                new DateObject(year + 1, 4, 22, 17, min, second),
                new DateObject(year + 1, 4, 22, 18, min, second));
            BasicTestFuture("I'll be out from 5 to 6 on 1st Jan",
                new DateObject(year + 1, 1, 1, 5, min, second),
                new DateObject(year + 1, 1, 1, 6, min, second));


            // merge two time points
            BasicTestFuture("I'll be out 3pm to 4pm tomorrow",
                new DateObject(year, month, 8, 15, min, second),
                new DateObject(year, month, 8, 16, min, second));

            BasicTestFuture("I'll be out 3:00 to 4:00 tomorrow",
                new DateObject(year, month, 8, 3, min, second),
                new DateObject(year, month, 8, 4, min, second));

            BasicTestFuture("I'll be out half past seven to 4pm tomorrow",
                new DateObject(year, month, 8, 7, 30, second),
                new DateObject(year, month, 8, 16, min, second));

            BasicTestFuture("I'll be out from 4pm today to 5pm tomorrow",
                new DateObject(year, month, day, 16, min, second),
                new DateObject(year, month, 8, 17, min, second));

            BasicTestFuture("I'll be out from 2:00pm, 2016-2-21 to 3:32, 04/23/2016",
                new DateObject(2016, 2, 21, 14, min, second),
                new DateObject(2016, 4, 23, 3, 32, second));
            BasicTestFuture("I'll be out between 4pm and 5pm today",
                new DateObject(year, month, day, 16, min, second),
                new DateObject(year, month, day, 17, min, second));

            BasicTestFuture("I'll be out between 4pm on Jan 1, 2016 and 5pm today",
                new DateObject(2016, 1, 1, 16, min, second),
                new DateObject(year, month, day, 17, min, second));


            BasicTestFuture("I'll go back tonight",
                new DateObject(year, month, day, 20, min, second),
                new DateObject(year, month, day, 23, 59, 59));
            BasicTestFuture("I'll go back tonight for 8",
                new DateObject(year, month, day, 20, min, second),
                new DateObject(year, month, day, 23, 59, 59));
            BasicTestFuture("I'll go back this night",
                new DateObject(year, month, day, 20, min, second),
                new DateObject(year, month, day, 23, 59, 59));
            BasicTestFuture("I'll go back this evening",
                new DateObject(year, month, day, 16, min, second),
                new DateObject(year, month, day, 20, min, second));
            BasicTestFuture("I'll go back this morning",
                new DateObject(year, month, day, 8, min, second),
                new DateObject(year, month, day, 12, min, second));
            BasicTestFuture("I'll go back this afternoon",
                new DateObject(year, month, day, 12, min, second),
                new DateObject(year, month, day, 16, min, second));
            BasicTestFuture("I'll go back next night",
                new DateObject(year, month, day + 1, 20, min, second),
                new DateObject(year, month, day + 1, 23, 59, 59));
            BasicTestFuture("I'll go back last night",
                new DateObject(year, month, day - 1, 20, min, second),
                new DateObject(year, month, day - 1, 23, 59, 59));
            BasicTestFuture("I'll go back tomorrow night",
                new DateObject(year, month, day + 1, 20, min, second),
                new DateObject(year, month, day + 1, 23, 59, 59));
            BasicTestFuture("I'll go back next monday afternoon",
                new DateObject(year, month, 14, 12, min, second),
                new DateObject(year, month, 14, 16, min, second));

            BasicTestFuture("I'll go back last 3 minute",
                new DateObject(year, month, day, 16, 9, second),
                new DateObject(year, month, day, 16, 12, second));
            BasicTestFuture("I'll go back past 3 minute",
                new DateObject(year, month, day, 16, 9, second),
                new DateObject(year, month, day, 16, 12, second));
            BasicTestFuture("I'll go back previous 3 minute",
                new DateObject(year, month, day, 16, 9, second),
                new DateObject(year, month, day, 16, 12, second));
            BasicTestFuture("I'll go back previous 3mins",
                new DateObject(year, month, day, 16, 9, second),
                new DateObject(year, month, day, 16, 12, second));
            BasicTestFuture("I'll go back in 3 hours",
                new DateObject(year, month, day, 16, 12, second),
                new DateObject(year, month, day, 19, 12, second));
            BasicTestFuture("I'll go back in 5 hrs",
                new DateObject(year, month, day, 16, 12, second),
                new DateObject(year, month, day, 21, 12, second));
            BasicTestFuture("I'll go back next 5 hrs",
                new DateObject(year, month, day, 16, 12, second),
                new DateObject(year, month, day, 21, 12, second));
            BasicTestFuture("I'll go back last minute",
                new DateObject(year, month, day, 16, 11, second),
                new DateObject(year, month, day, 16, 12, second));
            BasicTestFuture("I'll go back next hour",
                new DateObject(year, month, day, 16, 12, second),
                new DateObject(year, month, day, 17, 12, second));
        }

        [TestMethod]
        public void TestDateTimePeriodParseLuis()
        {
            // basic match
            BasicTest("I'll be out five to seven today", "(2016-11-07T05,2016-11-07T07,PT2H)");
            BasicTest("I'll be out from 5 to 6 of 4/22/2016", "(2016-04-22T05,2016-04-22T06,PT1H)");
            BasicTest("I'll be out from 5 to 6 of April 22", "(XXXX-04-22T05,XXXX-04-22T06,PT1H)");
            BasicTest("I'll be out from 5 to 6 on 1st Jan", "(XXXX-01-01T05,XXXX-01-01T06,PT1H)");


            // merge two time points
            BasicTest("I'll be out 3pm to 4pm tomorrow", "(2016-11-08T15,2016-11-08T16,PT1H)");
            BasicTest("I'll be out 3pm to 4pm tomorrow", "(2016-11-08T15,2016-11-08T16,PT1H)");
            BasicTest("I'll be out I'll be out from 2:00pm, 2016-2-21 to 3:32, 04/23/2016",
                "(2016-02-21T14:00,2016-04-23T03:32,PT1478H)");

            BasicTest("I'll go back tonight", "2016-11-07TNI");
            BasicTest("I'll go back this night", "2016-11-07TNI");
            BasicTest("I'll go back this evening", "2016-11-07TEV");
            BasicTest("I'll go back this morning", "2016-11-07TMO");
            BasicTest("I'll go back this afternoon", "2016-11-07TAF");
            BasicTest("I'll go back next night", "2016-11-08TNI");
            BasicTest("I'll go back last night", "2016-11-06TNI");
            BasicTest("I'll go back tomorrow night", "2016-11-08TNI");
            BasicTest("I'll go back next monday afternoon", "2016-11-14TAF");

            BasicTest("I'll go back last 3 minute", "(2016-11-07T16:09:00,2016-11-07T16:12:00,PT3M)");
            BasicTest("I'll go back past 3 minute", "(2016-11-07T16:09:00,2016-11-07T16:12:00,PT3M)");
            BasicTest("I'll go back previous 3 minute", "(2016-11-07T16:09:00,2016-11-07T16:12:00,PT3M)");
            BasicTest("I'll go back previous 3mins", "(2016-11-07T16:09:00,2016-11-07T16:12:00,PT3M)");
            BasicTest("I'll go back in 3 hours", "(2016-11-07T16:12:00,2016-11-07T19:12:00,PT3H)");
            BasicTest("I'll go back in 5 hrs", "(2016-11-07T16:12:00,2016-11-07T21:12:00,PT5H)");
            BasicTest("I'll go back next 5 hrs", "(2016-11-07T16:12:00,2016-11-07T21:12:00,PT5H)");
            BasicTest("I'll go back last minute", "(2016-11-07T16:11:00,2016-11-07T16:12:00,PT1M)");
            BasicTest("I'll go back next hour", "(2016-11-07T16:12:00,2016-11-07T17:12:00,PT1H)");
        }
    }
}