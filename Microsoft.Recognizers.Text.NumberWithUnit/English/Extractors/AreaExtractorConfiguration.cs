﻿using System.Collections.Immutable;
using System.Globalization;
using Microsoft.Recognizers.Resources.English;

namespace Microsoft.Recognizers.Text.NumberWithUnit.English
{
    public class AreaExtractorConfiguration : EnglishNumberWithUnitExtractorConfiguration
    {
        public AreaExtractorConfiguration() : this(new CultureInfo(Culture.English)) { }

        public AreaExtractorConfiguration(CultureInfo ci) : base(ci) { }

        public override ImmutableDictionary<string, string> SuffixList => AreaSuffixList;

        public override ImmutableDictionary<string, string> PrefixList => null;

        public override ImmutableList<string> AmbiguousUnitList => null;

        public override string ExtractType => Constants.SYS_UNIT_AREA;

        public static readonly ImmutableDictionary<string, string> AreaSuffixList = NumbersWithUnitDefinitions.AreaSuffixList.ToImmutableDictionary();
    }
}