using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PCRentalMGR.Models;

public class DbInitializer
{
    public static void Initialize(PCRentalMGRContext context)
    {
        // データベースが作成されていない場合は作成
        context.Database.EnsureCreated();

        // すでにデータが存在する場合は何もしない
        if (context.Users.Any())
        {
            return; // DB はすでに初期化されています
        }

        // 初期データの作成
        var users = new User[]
{
    new User { Employee_no ="A1002",Name = "森脇克美",Name_kana = "モリワキカツミ",Department = "開発1課",Tel_no = "235868783",Mail_address = "katsumi124@clpxtxlcu.ff",Age =49,Gender =1,Position= "一般",Account_level = "管理者"},
    new User { Employee_no ="B1003",Name = "真鍋沙奈",Name_kana = "マナベサナ",Department = "開発2課",Tel_no = "264640385",Mail_address = "amanabe@lkfolssvfl.hczpp.pc",Age =55,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="B1004",Name = "高梨愛姫",Name_kana = "タカナシアキ",Department = "開発2課",Tel_no = "733344935",Mail_address = "Aki_Takanashi@ajtkcn.yk",Age =25,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="B1005",Name = "浅川彩香",Name_kana = "アサカワアヤカ",Department = "開発2課",Tel_no = "765654624",Mail_address = "ayaka53863@hnrwwzt.ouk",Age =46,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="B1006",Name = "山城凛香",Name_kana = "ヤマシロリンカ",Department = "開発2課",Tel_no = "491295233",Mail_address = "rinkayamashiro@iriqg.bkxcb.ttc",Age =22,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1010",Name = "生田瑞紀",Name_kana = "イクタミズキ",Department = "開発1課",Tel_no = "85223705",Mail_address = "mizuki_ikuta@dkjnjxka.lran.sk",Age =55,Gender =1,Position= "部長",Account_level = "管理者"},
    new User { Employee_no ="A1011",Name = "小峰嶺渡",Name_kana = "コミネミネト",Department = "開発1課",Tel_no = "237533606",Mail_address = "gl-fgujhlzunawvmineto16563@qdywk.nwned.fk",Age =26,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1012",Name = "紺野信一",Name_kana = "コンノシンイチ",Department = "開発1課",Tel_no = "417985133",Mail_address = "shinichi117@htnsvbdwmx.df.hi",Age =50,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1013",Name = "波多野正義",Name_kana = "ハタノマサヨシ",Department = "開発1課",Tel_no = "473935195",Mail_address = "Masayoshi_Hatano@mwxuaibo.nxxo.cc",Age =53,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1014",Name = "山口桜子",Name_kana = "ヤマグチサクラコ",Department = "開発1課",Tel_no = "859380890",Mail_address = "oyamaguchi@hfyc.jvj",Age =36,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1015",Name = "伴景子",Name_kana = "バンケイコ",Department = "開発1課",Tel_no = "896187706",Mail_address = "Keiko_Ban@ydtq.vi.qot",Age =40,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1016",Name = "渡部昌利",Name_kana = "ワタナベマサトシ",Department = "開発1課",Tel_no = "738969256",Mail_address = "iwatanabe@uvwzzyek.nin",Age =25,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1017",Name = "川西宏光",Name_kana = "カワニシヒロミツ",Department = "開発1課",Tel_no = "446709239",Mail_address = "Hiromitsu_Kawanishi@qyjcm.ngfg.re",Age =32,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1018",Name = "大貫実可",Name_kana = "オオヌキミカ",Department = "開発1課",Tel_no = "895298503",Mail_address = "mika8222@clkwr.ye",Age =50,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1019",Name = "小玉加奈",Name_kana = "コダマカナ",Department = "開発1課",Tel_no = "989294146",Mail_address = "kana6330@uaxzxngc.co.csz",Age =47,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1020",Name = "三村菜月",Name_kana = "ミムラナヅキ",Department = "開発1課",Tel_no = "768931048",Mail_address = "nazuki_mimura@rmxuls.ruyb.oqg",Age =42,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1021",Name = "細谷松太郎",Name_kana = "ホソヤマツタロウ",Department = "開発1課",Tel_no = "294689528",Mail_address = "matsutarou_hosoya@osyjbr.ut.btz",Age =37,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1022",Name = "岩瀬亜沙美",Name_kana = "イワセアサミ",Department = "開発1課",Tel_no = "890241950",Mail_address = "asami41809@fyqjhh.eih.xjy",Age =34,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1023",Name = "中本道夫",Name_kana = "ナカモトミチオ",Department = "開発1課",Tel_no = "854809728",Mail_address = "michio139@uaozem.hl",Age =45,Gender =0,Position= "課長",Account_level = "管理者"},
    new User { Employee_no ="A1024",Name = "深沢伊代",Name_kana = "フカザワイヨ",Department = "開発1課",Tel_no = "748803221",Mail_address = "Iyo_Fukazawa@wqaufggth.yljjd.kc",Age =50,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1025",Name = "内田康博",Name_kana = "ウチダヤスヒロ",Department = "開発1課",Tel_no = "733077872",Mail_address = "yasuhiro321@posblq.vmw",Age =28,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1026",Name = "成田宗平",Name_kana = "ナリタソウヘイ",Department = "開発1課",Tel_no = "537290977",Mail_address = "souhei7840@yfnwbqiyd.lnv",Age =20,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="C2001",Name = "中原孝",Name_kana = "ナカハラタカシ",Department = "営業1課",Tel_no = "239266713",Mail_address = "n-iaqggmvvtakashi8324@yhdplomkvf.vd",Age =22,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="C2002",Name = "赤木真幸",Name_kana = "アカギマサキ",Department = "営業1課",Tel_no = "175488902",Mail_address = "masaki48828@wukygyyrit.ua",Age =42,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="C2003",Name = "武井米子",Name_kana = "タケイヨネコ",Department = "営業1課",Tel_no = "799064779",Mail_address = "aupmgrmrcjfnbyoneko62050@glcbxipdvn.ml.tgc",Age =23,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="C2004",Name = "高井日菜乃",Name_kana = "タカイヒナノ",Department = "営業1課",Tel_no = "833220779",Mail_address = "fplhcpnfhvu=whinano603@cthbnv.lnt",Age =57,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="C2005",Name = "堤明日人",Name_kana = "ツツミアスト",Department = "営業1課",Tel_no = "583972707",Mail_address = "asuto913@pilddsgte.dhy",Age =20,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="B1201",Name = "岡崎桃歌",Name_kana = "オカザキモモカ",Department = "開発2課",Tel_no = "229681855",Mail_address = "aokazaki@hcexkvbds.dwu",Age =36,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="B1202",Name = "児玉忠正",Name_kana = "コダマタダマサ",Department = "開発2課",Tel_no = "985930354",Mail_address = "tadamasa31219@kroscxis.an",Age =26,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="B1203",Name = "塚田巧聖",Name_kana = "ツカダコウセイ",Department = "開発2課",Tel_no = "23515302",Mail_address = "kouseitsukada@ubhmkvc.qy",Age =27,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1301",Name = "熊沢正人",Name_kana = "クマザワマサト",Department = "開発1課",Tel_no = "749046045",Mail_address = "masato94066@hbcjhfwegj.ryj",Age =28,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="A1302",Name = "柳敦司",Name_kana = "ヤナギアツシ",Department = "開発1課",Tel_no = "467953943",Mail_address = "ybjcbvojsjjybatsushi58903@hxiu.glk",Age =48,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="B1207",Name = "中村真哉",Name_kana = "ナカムラシンヤ",Department = "開発2課",Tel_no = "98384174",Mail_address = "shinya_nakamura@fmevotmcc.hj.qjj",Age =31,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="B1208",Name = "永田紗希",Name_kana = "ナガタサキ",Department = "開発2課",Tel_no = "923868622",Mail_address = "saki8994@bxdykl.mrv",Age =51,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="B1209",Name = "石山啓吾",Name_kana = "イシヤマケイゴ",Department = "開発2課",Tel_no = "957419032",Mail_address = "keigo07374@crqbngds.slz",Age =43,Gender =0,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="B1210",Name = "奥野博久",Name_kana = "オクノヒロヒサ",Department = "開発2課",Tel_no = "776916284",Mail_address = "aokuno@wtdalaju.nfj",Age =54,Gender =0,Position= "課長",Account_level = "管理者"},
    new User { Employee_no ="B1211",Name = "若松利佳",Name_kana = "ワカマツリカ",Department = "開発2課",Tel_no = "826833193",Mail_address = "rika40911@taaevv.gy",Age =42,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="B1212",Name = "白石佳代",Name_kana = "シライシカヨ",Department = "開発2課",Tel_no = "763685214",Mail_address = "rcfm=yguqpvhkayo44770@hivbgovvh.sj",Age =48,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="Z0101",Name = "黒田秀加",Name_kana = "クロダヒデカ",Department = "情報システム部",Tel_no = "157061581",Mail_address = "hideka82106@ovwtkeph.uze",Age =57,Gender =1,Position= "一般",Account_level = "利用者"},
    new User { Employee_no ="Z0102",Name = "佐竹紫雲",Name_kana = "サタケシウン",Department = "情報システム部",Tel_no = "264267595",Mail_address = "shiun814@qamcpg.ovomz.tfp",Age =27,Gender =0,Position= "一般",Account_level = "利用者"},
};

        context.Users.AddRange(users);
        context.SaveChanges();
    }
}
