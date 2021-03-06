﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;

namespace Microsoft.Recognizers.Text.NumberWithUnit.Chinese
{
    public class CurrencyExtractorConfiguration : ChineseNumberWithUnitExtractorConfiguration
    {
        public CurrencyExtractorConfiguration() : this(new CultureInfo(Culture.Chinese)) { }

        public CurrencyExtractorConfiguration(CultureInfo ci) : base(ci) { }

        public override ImmutableDictionary<string, string> SuffixList => CurrencySuffixList;

        public override ImmutableDictionary<string, string> PrefixList => CurrencyPrefixList;

        public override ImmutableList<string> AmbiguousUnitList => AmbiguousValues;

        public override string ExtractType => Constants.SYS_UNIT_CURRENCY;

        public static readonly ImmutableDictionary<string, string> CurrencySuffixList = new Dictionary<string, string>
        {
            //Reference Source: http://wiki.mbalib.com/wiki/%E4%B8%96%E7%95%8C%E8%B4%A7%E5%B8%81%E5%8D%95%E4%BD%8D%E8%A1%A8

            //Afghan afghani
            {"Afghan afghani", "阿富汗尼"},
            {"Pul", "普尔"},
            //Euro
            {"Euro", "欧元"},
            {"Cent", "美分"},
            //Albanian lek
            //No use of "ALL" "L"
            {"Albanian lek", "阿尔巴尼亚列克|列克"},
            //Angolan kwanza
            {"Angolan kwanza", "安哥拉宽扎|宽扎"},
            //Armenian
            //No use of "AMD"
            {"Armenian dram", "亚美尼亚德拉姆"},
            //Aruban florin
            {"Aruban florin", "阿鲁巴弗罗林|阿鲁巴币"},
            //Bangladeshi taka
            {"Bangladeshi taka", "塔卡|孟加拉塔卡"},
            {"Paisa", "派萨|帕萨"},
            //Bhutanese ngultrum
            {"Bhutanese ngultrum", "不丹努尔特鲁姆|不丹努扎姆|努扎姆"},
            {"Chetrum", "切特鲁姆"},
            //Bolivian boliviano
            {"Bolivian boliviano", "玻利维亚诺|玻利维亚币"},
            //Bosnia and Herzegovina convertible mark	
            {"Bosnia and Herzegovina convertible mark", "波斯尼亚和黑塞哥维那可兑换马克|波赫可兑换马克"},
            //Botswana pula
            {"Botswana pula", "博茨瓦纳普拉|普拉"},
            {"Thebe", "thebe"},
            //Brazilian real
            {"Brazilian real", "巴西雷亚尔"},
            //Bulgarian lev	
            {"Bulgarian lev", "保加利亚列弗|保加利亚列瓦"},
            {"Stotinka", "斯托丁卡"},
            //Cambodian riel
            {"Cambodian riel", "瑞尔"},
            //Cape Verdean escudo
            //No use of "esc" and "$"
            {"Cape Verdean escudo", "佛得角埃斯库多|维德角埃斯库多"},
            //Croatian kuna
            {"Croatian kuna", "克罗地亚库纳|克罗地亚库那|克罗埃西亚库纳"},
            {"Lipa", "利巴"},
            //Eritrean nakfa
            {"Eritrean nakfa", "厄立特里亚纳克法"},
            //Ethiopian birr
            {"Ethiopian birr", "埃塞俄比亚比尔|埃塞俄比亚元"},
            //Gambian dalasi
            {"Gambian dalasi", "冈比亚达拉西|甘比亚达拉西"},
            {"Butut", "布达|布图"},
            //Georgian lari
            {"Georgian lari", "格鲁吉亚拉里"},
            {"Tetri", "特特里|泰特里"},
            //Ghanaian cedi
            {"Ghanaian cedi", "塞地|加纳塞地"},
            {"Pesewa", "比塞瓦"},
            //Guatemalan quetzal
            {"Guatemalan quetzal", "瓜地马拉格查尔"},
            //Haitian gourde
            //No use of G
            {"Haitian gourde", "海地古德"},
            //Honduran lempira
            //No use of L
            {"Honduran lempira", "洪都拉斯伦皮拉"},
            //Hungarian forint
            {"Hungarian forint", "匈牙利福林|匈牙利货币|匈牙利福林币"},
            //Iranian rial
            {"Iranian rial", "伊朗里亚尔|伊朗莱尔"},
            {"Yemeni rial", "叶门莱尔|叶门里亚尔"},
            {"Israeli new shekel", "₪|ils|以色列币|以色列新克尔|谢克尔"},
            //Japanese yen
            {"Japanese yen", "日元|日本元|日币|日圆"},
            //Kazakhstani tenge
            {"Kazakhstani tenge", "哈萨克斯坦坚戈"},
            //Kenyan shilling
            {"Kenyan shilling", "肯尼亚先令"},
            //North Korean won
            {"North Korean won", "朝鲜圆|朝鲜元"},
            {"South Korean won", "韩元|韩圆"},
            {"Korean won", "₩"},
            //Kyrgyzstani som
            {"Kyrgyzstani som", "吉尔吉斯斯坦索姆"},
            //Lao kip
            {"Lao kip", "基普|老挝基普|老挝币"},
            {"Att", "att"},
            //Lesotho loti
            {"Lesotho loti", "莱索托洛提|莱索托马洛蒂"},
            //South African rand
            {"South African rand", "南非兰特"},
            //Macedonian denar
            {"Macedonian denar", "马其顿代纳尔|马其顿币|第纳尔|代纳尔"},
            {"Deni", "第尼"},
            //Malagasy ariary
            {"Malagasy ariary", "马达加斯加阿里亚里"},
            {"Iraimbilanja", "伊莱姆比拉贾"},
            //Malawian kwacha
            {"Malawian kwacha", "马拉威克瓦查"},
            {"Tambala", "坦巴拉"},
            //Malaysian ringgit
            {"Malaysian ringgit", "马来西亚币|马币|马来西亚林吉特"},
            //Mauritanian ouguiya
            {"Mauritanian ouguiya", "毛里塔尼亚乌吉亚"},
            {"Khoums", "库姆斯"},
            //Mozambican metical
            {"Mozambican metical", "莫桑比克梅蒂卡尔|梅蒂卡尔"},
            //Burmese kyat
            {"Burmese kyat", "缅甸元|缅元"},
            {"Pya", "缅分"},
            //Nigerian naira
            {"Nigerian naira", "尼日利亚奈拉|尼日利亚币|奈拉"},
            {"Kobo", "考包"},
            //Turkish lira
            {"Turkish lira", "土耳其里拉"},
            {"Kuruş", "库鲁"},
            //Omani rial
            {"Omani rial", "阿曼里亚尔|阿曼莱尔"},
            //Panamanian balboa
            {"Panamanian balboa", "巴拿马巴波亚"},
            {"Centesimo", "意大利分|乌拉圭分|巴拿马分"},
            //Papua New Guinean kina
            {"Papua New Guinean kina", "基那"},
            {"Toea", "托亚|托伊"},
            //Peruvian sol
            {"Peruvian sol", "秘鲁索尔"},
            //Polish zloty
            {"Polish złoty", "波兰币|波兰兹罗提|兹罗提"},
            {"Grosz", "格罗希"},
            //Qatari riyal
            {"Qatari riyal", "卡达里亚尔"},
            {"Saudi riyal", "沙特里亚尔"},
            {"Riyal", "里亚尔|"},
            {"Dirham", "迪拉姆"},
            {"Halala", "哈拉"},
            //Samoan tālā
            {"Samoan tālā", "萨摩亚塔拉"},
            //Sierra Leonean leone
            {"Sierra Leonean leone", "塞拉利昂利昂|利昂"},
            //Spain
            {"Peseta", "比塞塔|西班牙比塞塔|西班牙币"},
            //Swazi lilangeni
            {"Swazi lilangeni", "斯威士兰里兰吉尼|兰吉尼"},
            //Tajikistani somoni
            {"Tajikistani somoni", "塔吉克斯坦索莫尼"},
            //Thai baht
            {"Thai baht", "泰铢|泰元"},
            {"Satang", "萨当"},
            //Tongan paʻanga
            {"Tongan paʻanga", "汤加潘加|潘加"},
            //Ukrainian hryvnia
            {"Ukrainian hryvnia", "乌克兰格里夫纳|格里夫纳"},
            //Vanuatu vatu
            {"Vanuatu vatu", "瓦努阿图瓦图"},
            //Vietnamese dong
            {"Vietnamese dong", "越南盾"},
            {"Indonesian rupiah", "印度尼西亚盾"},
            {"Netherlands guilder", "荷兰盾|荷属安的列斯盾|列斯盾"},
            {"Surinam florin", "苏里南盾"},
            {"Guilder", "盾"},
            //Zambian kwacha
            {"Zambian kwacha", "赞比亚克瓦查"},
            //Dirham
            {"Moroccan dirham", "摩洛哥迪拉姆"},
            {"United Arab Emirates dirham", "阿联酋迪拉姆"},
            //Manat
            {"Azerbaijani manat", "阿塞拜疆马纳特"},
            {"Turkmenistan manat", "土库曼马纳特"},
            {"Manat", "马纳特"},
            //Shilling
            {"Somali shilling", "索马里先令|索马利先令"},
            {"Somaliland shilling", "索马里兰先令"},
            {"Tanzanian shilling", "坦桑尼亚先令"},
            {"Ugandan shilling", "乌干达先令"},
            //Leu
            {"Romanian leu", "罗马尼亚列伊"},
            {"Moldovan leu", "摩尔多瓦列伊"},
            {"Leu", "列伊"},
            {"Ban", "巴尼"},
            //Rupee
            {"Nepalese rupee", "尼泊尔卢比"},
            {"Pakistani rupee", "巴基斯坦卢比"},
            {"Indian rupee", "印度卢比"},
            {"Seychellois rupee", "塞舌尔卢比"},
            {"Mauritian rupee", "毛里求斯卢比"},
            {"Maldivian rufiyaa", "马尔代夫卢比"},
            {"Sri Lankan rupee", "斯里兰卡卢比"},
            {"Rupee", "卢比"},
            //Krone
            //Czech koruna
            {"Czech koruna", "捷克克朗"},
            {"Danish krone", "丹麦克朗|丹麦克郎"},
            {"Norwegian krone", "挪威克朗"},
            {"Faroese króna", "法罗克朗"},
            {"Icelandic króna", "冰岛克朗"},
            {"Swedish krona", "瑞典克朗"},
            {"Krone", "克朗"},
            {"Øre", "奥依拉|奥拉|埃利"},
            //Franc
            {"West African CFA franc", "非共体法郎"},
            {"Central African CFA franc", "中非法郎|中非金融合作法郎"},
            {"Comorian franc", "科摩罗法郎"},
            {"Congolese franc", "刚果法郎"},
            {"Burundian franc", "布隆迪法郎"},
            {"Djiboutian franc", "吉布提法郎"},
            {"CFP franc", "太平洋法郎"},
            {"Guinean franc", "几内亚法郎"},
            {"Swiss franc", "瑞士法郎"},
            {"Rwandan franc", "卢旺达法郎"},
            {"Belgian franc", "比利时法郎"},
            {"Rappen", "瑞士分|瑞士生丁"},
            {"Franc", "法郎"},
            {"Centime", "生丁|仙士"},
            //Ruble
            {"Russian ruble", "俄国卢布|俄罗斯卢布"},
            {"Transnistrian ruble", "德涅斯特卢布"},
            {"Belarusian ruble", "白俄罗斯卢布"},
            {"Kopek", "戈比"},
            {"Ruble", "卢布"},
            //Dinar
            {"Algerian dinar", "阿尔及利亚第纳尔"},
            {"Bahraini dinar", "巴林第纳尔"},
            {"Iraqi dinar", "伊拉克第纳尔|"},
            {"Jordanian dinar", "约旦第纳尔"},
            {"Kuwaiti dinar", "科威特第纳尔|科威特币"},
            {"Libyan dinar", "利比亚第纳尔"},
            {"Serbian dinar", "塞尔维亚第纳尔|塞尔维亚币"},
            {"Tunisian dinar", "突尼斯第纳尔"},
            {"Dinar", "第纳尔"},
            {"Fils", "费尔"},
            {"Para", "帕拉"},
            {"Millime", "米利姆"},
            //Peso
            {"Argentine peso", "阿根廷比索"},
            {"Chilean peso", "智利比索"},
            {"Colombian peso", "哥伦比亚比索"},
            {"Cuban peso", "古巴比索"},
            {"Dominican peso", "多米尼加比索"},
            {"Mexican peso", "墨西哥比索"},
            {"Philippine peso", "菲律宾比索"},
            {"Uruguayan peso", "乌拉圭比索"},
            {"Peso", "比索"},
            {"Centavo", "仙|菲辅币"},
            //Pound
            {"Alderney pound", "奥尔德尼镑"},
            {"British pound", "英镑"},
            {"Guernsey pound", "根西镑"},
            {"Saint Helena pound", "圣赫勒拿镑"},
            {"Egyptian pound", "埃及镑"},
            {"Falkland Islands pound", "福克兰镑"},
            {"Gibraltar pound", "直布罗陀镑"},
            {"Manx pound", "马恩岛镑"},
            {"Jersey pound", "泽西岛镑"},
            {"Lebanese pound", "黎巴嫩镑"},
            {"South Sudanese pound", "南苏丹镑"},
            {"Sudanese pound", "苏丹镑"},
            {"Syrian pound", "叙利亚镑"},
            {"Pound", "英镑"},
            {"Pence", "便士"},
            {"Shilling", "先令"},
            //Dollar
            {"United States dollar", "美元|美金|美圆"},
            {"East Caribbean dollar", "东加勒比元"},
            {"Australian dollar", "澳大利亚元|澳元"},
            {"Bahamian dollar", "巴哈马元"},
            {"Barbadian dollar", "巴巴多斯元"},
            {"Belize dollar", "伯利兹元"},
            {"Bermudian dollar", "百慕大元"},
            {"Brunei dollar", "文莱元"},
            {"Singapore dollar", "新加坡元|新元"},
            {"Canadian dollar", "加元|加拿大元"},
            {"Cayman Islands dollar", "开曼岛元|"},
            {"New Zealand dollar", "新西兰元|纽元"},
            {"Cook Islands dollar", "库克群岛元"},
            {"Fijian dollar", "斐济元|斐币"},
            {"Guyanese dollar", "圭亚那元"},
            {"Hong Kong dollar", "蚊|港元|港圆|港币"},
            {"Macau Pataca", "澳元|澳门币|澳门元"},
            {"New Taiwan dollar", "箍|新台币|台币"},
            {"Jamaican dollar", "牙买加元"},
            {"Kiribati dollar", "吉里巴斯元"},
            {"Liberian dollar", "利比里亚元"},
            {"Namibian dollar", "纳米比亚元"},
            {"Surinamese dollar", "苏里南元"},
            {"Trinidad and Tobago dollar", "特立尼达多巴哥元"},
            {"Tuvaluan dollar", "吐瓦鲁元"},
            //Chinese yuan
            {"Chinese yuan", "人民币|人民币元|块钱|块|元|圆"},
            {"Fen", "分钱|分"},
            {"Jiao", "毛钱|毛|角钱|角"},
            //Additional
            {"Finnish markka", "芬兰马克"},
            {"Penni", "盆尼"}
        }.ToImmutableDictionary();

        public static readonly ImmutableDictionary<string, string> CurrencyPrefixList = new Dictionary<string, string>
        {
            //Dollar Prefix
            {"Dollar", "$"},
            {"United States dollar", "us$"},
            {"British Virgin Islands dollar", "bvi$"},
            {"Brunei dollar", "b$"},
            {"Sen", "sen"},
            {"Singapore dollar", "s$"},
            {"Canadian dollar", "can$|c$|c $"},
            {"Cayman Islands dollar", "ci$"},
            {"New Zealand dollar", "nz$|nz $"},
            {"Guyanese dollar", "gy$|gy $|g$|g $"},
            {"Hong Kong dollar", "hk$|hkd|hk $"},
            {"Jamaican dollar", "j$"},
            {"Namibian dollar", "nad|n$|n $"},
            {"Solomon Islands dollar", "si$|si $"},
            {"New Taiwan dollar", "nt$|nt $"},
            {"Samoan tālā", "ws$"},
            {"Chinese yuan", "￥"},
            {"Japanese yen", "¥"},
            {"Turkish lira", "₺"},
            {"Euro", "€"},
            {"Pound", "£"},
            {"Costa Rican colón", "₡"}
        }.ToImmutableDictionary();

        private static readonly ImmutableList<string> AmbiguousValues = new List<string>
        {
            "元",
            "仙",
            "分",
            "圆",
            "块",
            "毛",
            "盾",
            "箍",
            "蚊",
            "角",
        }.ToImmutableList();
    }
}
