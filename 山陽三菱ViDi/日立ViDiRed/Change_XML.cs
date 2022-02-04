using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Example.Runtime
{
    class Change_XML
    {
        //保存先のファイル名
        //CHANGE_START :2020/10/12 kitayama 理由：参照先を改造内容に合わせた設定ファイルに変更
        //CHANGE_START :2020/4/27 kitayama 理由：参照先を改造内容に合わせた設定ファイルに変更
        //string fileName = @"memberse.xml";
        //string fileName = @"memberse2.xml";
        string fileName = @"memberse3.xml";
        //CHANGE_END :2020/4/27 kitayama 理由：参照先を改造内容に合わせた設定ファイルに変更
        //CHANGE_END :2020/10/12 kitayama 理由：参照先を改造内容に合わせた設定ファイルに変更

        /// <summary>
        /// 設定内容をXMLファイルに反映
        /// </summary>
        public void WriteXML()
        {

            //保存するクラス(SampleClass)のインスタンスを作成
            SampleClass obj = new SampleClass();

            ///////////////////////////////////////////////////////////////////
            ///     設定パラメタ　書き込み
            ///////////////////////////////////////////////////////////////////
            //CHANGE_START :2021/11/27 kitayama 理由：保存先を配列に変更
            obj.OKImagePath = MainWindow.sImagePath[0];
            obj.INTERImagePath = MainWindow.sImagePath[1];
            obj.NGImagePath = MainWindow.sImagePath[2];
            //obj.GetImagePath = MainWindow.sGetImagePath;                             //ファイル取得先フォルダ
            //obj.SetImagePath = MainWindow.sSetImagePath;                             //保存先フォルダ
            //CHANGE_START :2021/11/27 kitayama 理由：保存先を配列に変更
            obj.GetImageInterval = MainWindow.iGetImageInterval;                     //ファイル取得周期
            obj.MoveImageInterval = MainWindow.iMoveImageInterval;                   //ファイル移動周期
            //ADD_START :2020/2/20 kitayama 理由：隔離先パスを追加
            //obj.IsoImagePath = MainWindow.sIsoImagePath;
            //ADD_END :2020/2/20 kitayama 理由：隔離先パスを追加
            //ADD_START :2020/1/17 kitayama 理由：画像表示時間を追加
            obj.HoldTime = MainWindow.iHoldTime;                                    //検査予定枚数0のときの画像表示時間
            //ADD_END :2020/1/17 kitayama 理由：画像表示時間を追加
            //ADD_START :2020/2/21 kitayama 理由：画像保存しきい値を追加
            obj.Blankrate = MainWindow.fBlankrate;
            //ADD_END :2020/2/21 kitayama 理由：画像保存しきい値を追加
            //ADD_START :2020/10/12 kitayama 理由：シャッタースピード、ゲイン？を追加
            obj.shutterspeed = MainWindow.iShutterspeed;
            obj.brightness = MainWindow.iBrightness;
            //ADD_END :2020/10/12 kitayama 理由：シャッタースピード、ゲイン？を追加
            obj.Kishu1 = MainWindow.sKishu[0];                                       //品種1
            obj.Kishu2 = MainWindow.sKishu[1];                                       //品種2
            obj.Kishu3 = MainWindow.sKishu[2];                                       //品種3
            obj.Kishu4 = MainWindow.sKishu[3];                                       //品種4
            obj.Kishu5 = MainWindow.sKishu[4];                                       //品種5
            obj.Kishu6 = MainWindow.sKishu[5];                                       //品種6
            obj.Kishu7 = MainWindow.sKishu[6];                                       //品種7
            obj.Kishu8 = MainWindow.sKishu[7];                                       //品種8
            obj.Kishu9 = MainWindow.sKishu[8];                                       //品種9
            obj.Kishu10 = MainWindow.sKishu[9];                                      //品種10
            obj.WorkSpece1 = MainWindow.sWorkspece[0];                               //ワークスペース1
            obj.WorkSpece2 = MainWindow.sWorkspece[1];                               //ワークスペース2
            obj.WorkSpece3 = MainWindow.sWorkspece[2];                               //ワークスペース3
            obj.WorkSpece4 = MainWindow.sWorkspece[3];                               //ワークスペース4
            obj.WorkSpece5 = MainWindow.sWorkspece[4];                               //ワークスペース5
            obj.WorkSpece6 = MainWindow.sWorkspece[5];                               //ワークスペース6
            obj.WorkSpece7 = MainWindow.sWorkspece[6];                               //ワークスペース7
            obj.WorkSpece8 = MainWindow.sWorkspece[7];                               //ワークスペース8
            obj.WorkSpece9 = MainWindow.sWorkspece[8];                               //ワークスペース9
            obj.WorkSpece10 = MainWindow.sWorkspece[9];                              //ワークスペース10

            //DELETE_START :2021/12/19 kitayama 理由：名称は使用しないので削除
            ////ADD_START :2021/11/14 kitayama 理由：検査名称を格納する処理を追加
            ////品種1
            ////1-Stream1
            //obj.Meisyou000 = MainWindow.a_meisyou[0, 0, 0];
            //obj.Meisyou001 = MainWindow.a_meisyou[0, 0, 1];
            //obj.Meisyou002 = MainWindow.a_meisyou[0, 0, 2];
            //obj.Meisyou003 = MainWindow.a_meisyou[0, 0, 3];
            //obj.Meisyou004 = MainWindow.a_meisyou[0, 0, 4];
            //obj.Meisyou005 = MainWindow.a_meisyou[0, 0, 5];
            //obj.Meisyou006 = MainWindow.a_meisyou[0, 0, 6];
            //obj.Meisyou007 = MainWindow.a_meisyou[0, 0, 7];
            //obj.Meisyou008 = MainWindow.a_meisyou[0, 0, 8];
            //obj.Meisyou009 = MainWindow.a_meisyou[0, 0, 9];
            ////1-Stream2
            //obj.Meisyou010 = MainWindow.a_meisyou[0, 1, 0];
            //obj.Meisyou011 = MainWindow.a_meisyou[0, 1, 1];
            //obj.Meisyou012 = MainWindow.a_meisyou[0, 1, 2];
            //obj.Meisyou013 = MainWindow.a_meisyou[0, 1, 3];
            //obj.Meisyou014 = MainWindow.a_meisyou[0, 1, 4];
            //obj.Meisyou015 = MainWindow.a_meisyou[0, 1, 5];
            //obj.Meisyou016 = MainWindow.a_meisyou[0, 1, 6];
            //obj.Meisyou017 = MainWindow.a_meisyou[0, 1, 7];
            //obj.Meisyou018 = MainWindow.a_meisyou[0, 1, 8];
            //obj.Meisyou019 = MainWindow.a_meisyou[0, 1, 9];
            ////1-Stream3
            //obj.Meisyou020 = MainWindow.a_meisyou[0, 2, 0];
            //obj.Meisyou021 = MainWindow.a_meisyou[0, 2, 1];
            //obj.Meisyou022 = MainWindow.a_meisyou[0, 2, 2];
            //obj.Meisyou023 = MainWindow.a_meisyou[0, 2, 3];
            //obj.Meisyou024 = MainWindow.a_meisyou[0, 2, 4];
            //obj.Meisyou025 = MainWindow.a_meisyou[0, 2, 5];
            //obj.Meisyou026 = MainWindow.a_meisyou[0, 2, 6];
            //obj.Meisyou027 = MainWindow.a_meisyou[0, 2, 7];
            //obj.Meisyou028 = MainWindow.a_meisyou[0, 2, 8];
            //obj.Meisyou029 = MainWindow.a_meisyou[0, 2, 9];
            ////1-Stream4
            //obj.Meisyou030 = MainWindow.a_meisyou[0, 3, 0];
            //obj.Meisyou031 = MainWindow.a_meisyou[0, 3, 1];
            //obj.Meisyou032 = MainWindow.a_meisyou[0, 3, 2];
            //obj.Meisyou033 = MainWindow.a_meisyou[0, 3, 3];
            //obj.Meisyou034 = MainWindow.a_meisyou[0, 3, 4];
            //obj.Meisyou035 = MainWindow.a_meisyou[0, 3, 5];
            //obj.Meisyou036 = MainWindow.a_meisyou[0, 3, 6];
            //obj.Meisyou037 = MainWindow.a_meisyou[0, 3, 7];
            //obj.Meisyou038 = MainWindow.a_meisyou[0, 3, 8];
            //obj.Meisyou039 = MainWindow.a_meisyou[0, 3, 9];
            ////1-Stream5
            //obj.Meisyou040 = MainWindow.a_meisyou[0, 4, 0];
            //obj.Meisyou041 = MainWindow.a_meisyou[0, 4, 1];
            //obj.Meisyou042 = MainWindow.a_meisyou[0, 4, 2];
            //obj.Meisyou043 = MainWindow.a_meisyou[0, 4, 3];
            //obj.Meisyou044 = MainWindow.a_meisyou[0, 4, 4];
            //obj.Meisyou045 = MainWindow.a_meisyou[0, 4, 5];
            //obj.Meisyou046 = MainWindow.a_meisyou[0, 4, 6];
            //obj.Meisyou047 = MainWindow.a_meisyou[0, 4, 7];
            //obj.Meisyou048 = MainWindow.a_meisyou[0, 4, 8];
            //obj.Meisyou049 = MainWindow.a_meisyou[0, 4, 9];
            ////1-Stream6
            //obj.Meisyou050 = MainWindow.a_meisyou[0, 5, 0];
            //obj.Meisyou051 = MainWindow.a_meisyou[0, 5, 1];
            //obj.Meisyou052 = MainWindow.a_meisyou[0, 5, 2];
            //obj.Meisyou053 = MainWindow.a_meisyou[0, 5, 3];
            //obj.Meisyou054 = MainWindow.a_meisyou[0, 5, 4];
            //obj.Meisyou055 = MainWindow.a_meisyou[0, 5, 5];
            //obj.Meisyou056 = MainWindow.a_meisyou[0, 5, 6];
            //obj.Meisyou057 = MainWindow.a_meisyou[0, 5, 7];
            //obj.Meisyou058 = MainWindow.a_meisyou[0, 5, 8];
            //obj.Meisyou059 = MainWindow.a_meisyou[0, 5, 9];
            ////1-Stream7
            //obj.Meisyou060 = MainWindow.a_meisyou[0, 6, 0];
            //obj.Meisyou061 = MainWindow.a_meisyou[0, 6, 1];
            //obj.Meisyou062 = MainWindow.a_meisyou[0, 6, 2];
            //obj.Meisyou063 = MainWindow.a_meisyou[0, 6, 3];
            //obj.Meisyou064 = MainWindow.a_meisyou[0, 6, 4];
            //obj.Meisyou065 = MainWindow.a_meisyou[0, 6, 5];
            //obj.Meisyou066 = MainWindow.a_meisyou[0, 6, 6];
            //obj.Meisyou067 = MainWindow.a_meisyou[0, 6, 7];
            //obj.Meisyou068 = MainWindow.a_meisyou[0, 6, 8];
            //obj.Meisyou069 = MainWindow.a_meisyou[0, 6, 9];
            ////1-Stream8
            //obj.Meisyou070 = MainWindow.a_meisyou[0, 7, 0];
            //obj.Meisyou071 = MainWindow.a_meisyou[0, 7, 1];
            //obj.Meisyou072 = MainWindow.a_meisyou[0, 7, 2];
            //obj.Meisyou073 = MainWindow.a_meisyou[0, 7, 3];
            //obj.Meisyou074 = MainWindow.a_meisyou[0, 7, 4];
            //obj.Meisyou075 = MainWindow.a_meisyou[0, 7, 5];
            //obj.Meisyou076 = MainWindow.a_meisyou[0, 7, 6];
            //obj.Meisyou077 = MainWindow.a_meisyou[0, 7, 7];
            //obj.Meisyou078 = MainWindow.a_meisyou[0, 7, 8];
            //obj.Meisyou079 = MainWindow.a_meisyou[0, 7, 9];
            ////1-Stream9
            //obj.Meisyou080 = MainWindow.a_meisyou[0, 8, 0];
            //obj.Meisyou081 = MainWindow.a_meisyou[0, 8, 1];
            //obj.Meisyou082 = MainWindow.a_meisyou[0, 8, 2];
            //obj.Meisyou083 = MainWindow.a_meisyou[0, 8, 3];
            //obj.Meisyou084 = MainWindow.a_meisyou[0, 8, 4];
            //obj.Meisyou085 = MainWindow.a_meisyou[0, 8, 5];
            //obj.Meisyou086 = MainWindow.a_meisyou[0, 8, 6];
            //obj.Meisyou087 = MainWindow.a_meisyou[0, 8, 7];
            //obj.Meisyou088 = MainWindow.a_meisyou[0, 8, 8];
            //obj.Meisyou089 = MainWindow.a_meisyou[0, 8, 9];
            ////1-Stream10
            //obj.Meisyou090 = MainWindow.a_meisyou[0, 9, 0];
            //obj.Meisyou091 = MainWindow.a_meisyou[0, 9, 1];
            //obj.Meisyou092 = MainWindow.a_meisyou[0, 9, 2];
            //obj.Meisyou093 = MainWindow.a_meisyou[0, 9, 3];
            //obj.Meisyou094 = MainWindow.a_meisyou[0, 9, 4];
            //obj.Meisyou095 = MainWindow.a_meisyou[0, 9, 5];
            //obj.Meisyou096 = MainWindow.a_meisyou[0, 9, 6];
            //obj.Meisyou097 = MainWindow.a_meisyou[0, 9, 7];
            //obj.Meisyou098 = MainWindow.a_meisyou[0, 9, 8];
            //obj.Meisyou099 = MainWindow.a_meisyou[0, 9, 9];
            ////1-Stream11
            //obj.Meisyou0A0 = MainWindow.a_meisyou[0, 10, 0];
            //obj.Meisyou0A1 = MainWindow.a_meisyou[0, 10, 1];
            //obj.Meisyou0A2 = MainWindow.a_meisyou[0, 10, 2];
            //obj.Meisyou0A3 = MainWindow.a_meisyou[0, 10, 3];
            //obj.Meisyou0A4 = MainWindow.a_meisyou[0, 10, 4];
            //obj.Meisyou0A5 = MainWindow.a_meisyou[0, 10, 5];
            //obj.Meisyou0A6 = MainWindow.a_meisyou[0, 10, 6];
            //obj.Meisyou0A7 = MainWindow.a_meisyou[0, 10, 7];
            //obj.Meisyou0A8 = MainWindow.a_meisyou[0, 10, 8];
            //obj.Meisyou0A9 = MainWindow.a_meisyou[0, 10, 9];

            ////品種2
            ////2-Stream1
            //obj.Meisyou100 = MainWindow.a_meisyou[1, 0, 0];
            //obj.Meisyou101 = MainWindow.a_meisyou[1, 0, 1];
            //obj.Meisyou102 = MainWindow.a_meisyou[1, 0, 2];
            //obj.Meisyou103 = MainWindow.a_meisyou[1, 0, 3];
            //obj.Meisyou104 = MainWindow.a_meisyou[1, 0, 4];
            //obj.Meisyou105 = MainWindow.a_meisyou[1, 0, 5];
            //obj.Meisyou106 = MainWindow.a_meisyou[1, 0, 6];
            //obj.Meisyou107 = MainWindow.a_meisyou[1, 0, 7];
            //obj.Meisyou108 = MainWindow.a_meisyou[1, 0, 8];
            //obj.Meisyou109 = MainWindow.a_meisyou[1, 0, 9];
            ////2-Stream2
            //obj.Meisyou110 = MainWindow.a_meisyou[1, 1, 0];
            //obj.Meisyou111 = MainWindow.a_meisyou[1, 1, 1];
            //obj.Meisyou112 = MainWindow.a_meisyou[1, 1, 2];
            //obj.Meisyou113 = MainWindow.a_meisyou[1, 1, 3];
            //obj.Meisyou114 = MainWindow.a_meisyou[1, 1, 4];
            //obj.Meisyou115 = MainWindow.a_meisyou[1, 1, 5];
            //obj.Meisyou116 = MainWindow.a_meisyou[1, 1, 6];
            //obj.Meisyou117 = MainWindow.a_meisyou[1, 1, 7];
            //obj.Meisyou118 = MainWindow.a_meisyou[1, 1, 8];
            //obj.Meisyou119 = MainWindow.a_meisyou[1, 1, 9];
            ////2-Stream3
            //obj.Meisyou120 = MainWindow.a_meisyou[1, 2, 0];
            //obj.Meisyou121 = MainWindow.a_meisyou[1, 2, 1];
            //obj.Meisyou122 = MainWindow.a_meisyou[1, 2, 2];
            //obj.Meisyou123 = MainWindow.a_meisyou[1, 2, 3];
            //obj.Meisyou124 = MainWindow.a_meisyou[1, 2, 4];
            //obj.Meisyou125 = MainWindow.a_meisyou[1, 2, 5];
            //obj.Meisyou126 = MainWindow.a_meisyou[1, 2, 6];
            //obj.Meisyou127 = MainWindow.a_meisyou[1, 2, 7];
            //obj.Meisyou128 = MainWindow.a_meisyou[1, 2, 8];
            //obj.Meisyou129 = MainWindow.a_meisyou[1, 2, 9];
            ////2-Stream4
            //obj.Meisyou130 = MainWindow.a_meisyou[1, 3, 0];
            //obj.Meisyou131 = MainWindow.a_meisyou[1, 3, 1];
            //obj.Meisyou132 = MainWindow.a_meisyou[1, 3, 2];
            //obj.Meisyou133 = MainWindow.a_meisyou[1, 3, 3];
            //obj.Meisyou134 = MainWindow.a_meisyou[1, 3, 4];
            //obj.Meisyou135 = MainWindow.a_meisyou[1, 3, 5];
            //obj.Meisyou136 = MainWindow.a_meisyou[1, 3, 6];
            //obj.Meisyou137 = MainWindow.a_meisyou[1, 3, 7];
            //obj.Meisyou138 = MainWindow.a_meisyou[1, 3, 8];
            //obj.Meisyou139 = MainWindow.a_meisyou[1, 3, 9];
            ////2-Stream5
            //obj.Meisyou140 = MainWindow.a_meisyou[1, 4, 0];
            //obj.Meisyou141 = MainWindow.a_meisyou[1, 4, 1];
            //obj.Meisyou142 = MainWindow.a_meisyou[1, 4, 2];
            //obj.Meisyou143 = MainWindow.a_meisyou[1, 4, 3];
            //obj.Meisyou144 = MainWindow.a_meisyou[1, 4, 4];
            //obj.Meisyou145 = MainWindow.a_meisyou[1, 4, 5];
            //obj.Meisyou146 = MainWindow.a_meisyou[1, 4, 6];
            //obj.Meisyou147 = MainWindow.a_meisyou[1, 4, 7];
            //obj.Meisyou148 = MainWindow.a_meisyou[1, 4, 8];
            //obj.Meisyou149 = MainWindow.a_meisyou[1, 4, 9];
            ////2-Stream6
            //obj.Meisyou150 = MainWindow.a_meisyou[1, 5, 0];
            //obj.Meisyou151 = MainWindow.a_meisyou[1, 5, 1];
            //obj.Meisyou152 = MainWindow.a_meisyou[1, 5, 2];
            //obj.Meisyou153 = MainWindow.a_meisyou[1, 5, 3];
            //obj.Meisyou154 = MainWindow.a_meisyou[1, 5, 4];
            //obj.Meisyou155 = MainWindow.a_meisyou[1, 5, 5];
            //obj.Meisyou156 = MainWindow.a_meisyou[1, 5, 6];
            //obj.Meisyou157 = MainWindow.a_meisyou[1, 5, 7];
            //obj.Meisyou158 = MainWindow.a_meisyou[1, 5, 8];
            //obj.Meisyou159 = MainWindow.a_meisyou[1, 5, 9];
            ////2-Stream7
            //obj.Meisyou160 = MainWindow.a_meisyou[1, 6, 0];
            //obj.Meisyou161 = MainWindow.a_meisyou[1, 6, 1];
            //obj.Meisyou162 = MainWindow.a_meisyou[1, 6, 2];
            //obj.Meisyou163 = MainWindow.a_meisyou[1, 6, 3];
            //obj.Meisyou164 = MainWindow.a_meisyou[1, 6, 4];
            //obj.Meisyou165 = MainWindow.a_meisyou[1, 6, 5];
            //obj.Meisyou166 = MainWindow.a_meisyou[1, 6, 6];
            //obj.Meisyou167 = MainWindow.a_meisyou[1, 6, 7];
            //obj.Meisyou168 = MainWindow.a_meisyou[1, 6, 8];
            //obj.Meisyou169 = MainWindow.a_meisyou[1, 6, 9];
            ////2-Stream8
            //obj.Meisyou170 = MainWindow.a_meisyou[1, 7, 0];
            //obj.Meisyou171 = MainWindow.a_meisyou[1, 7, 1];
            //obj.Meisyou172 = MainWindow.a_meisyou[1, 7, 2];
            //obj.Meisyou173 = MainWindow.a_meisyou[1, 7, 3];
            //obj.Meisyou174 = MainWindow.a_meisyou[1, 7, 4];
            //obj.Meisyou175 = MainWindow.a_meisyou[1, 7, 5];
            //obj.Meisyou176 = MainWindow.a_meisyou[1, 7, 6];
            //obj.Meisyou177 = MainWindow.a_meisyou[1, 7, 7];
            //obj.Meisyou178 = MainWindow.a_meisyou[1, 7, 8];
            //obj.Meisyou179 = MainWindow.a_meisyou[1, 7, 9];
            ////2-Stream9
            //obj.Meisyou180 = MainWindow.a_meisyou[1, 8, 0];
            //obj.Meisyou181 = MainWindow.a_meisyou[1, 8, 1];
            //obj.Meisyou182 = MainWindow.a_meisyou[1, 8, 2];
            //obj.Meisyou183 = MainWindow.a_meisyou[1, 8, 3];
            //obj.Meisyou184 = MainWindow.a_meisyou[1, 8, 4];
            //obj.Meisyou185 = MainWindow.a_meisyou[1, 8, 5];
            //obj.Meisyou186 = MainWindow.a_meisyou[1, 8, 6];
            //obj.Meisyou187 = MainWindow.a_meisyou[1, 8, 7];
            //obj.Meisyou188 = MainWindow.a_meisyou[1, 8, 8];
            //obj.Meisyou189 = MainWindow.a_meisyou[1, 8, 9];
            ////2-Stream10
            //obj.Meisyou190 = MainWindow.a_meisyou[1, 9, 0];
            //obj.Meisyou191 = MainWindow.a_meisyou[1, 9, 1];
            //obj.Meisyou192 = MainWindow.a_meisyou[1, 9, 2];
            //obj.Meisyou193 = MainWindow.a_meisyou[1, 9, 3];
            //obj.Meisyou194 = MainWindow.a_meisyou[1, 9, 4];
            //obj.Meisyou195 = MainWindow.a_meisyou[1, 9, 5];
            //obj.Meisyou196 = MainWindow.a_meisyou[1, 9, 6];
            //obj.Meisyou197 = MainWindow.a_meisyou[1, 9, 7];
            //obj.Meisyou198 = MainWindow.a_meisyou[1, 9, 8];
            //obj.Meisyou199 = MainWindow.a_meisyou[1, 9, 9];
            ////2-Stream11
            //obj.Meisyou1A0 = MainWindow.a_meisyou[1, 10, 0];
            //obj.Meisyou1A1 = MainWindow.a_meisyou[1, 10, 1];
            //obj.Meisyou1A2 = MainWindow.a_meisyou[1, 10, 2];
            //obj.Meisyou1A3 = MainWindow.a_meisyou[1, 10, 3];
            //obj.Meisyou1A4 = MainWindow.a_meisyou[1, 10, 4];
            //obj.Meisyou1A5 = MainWindow.a_meisyou[1, 10, 5];
            //obj.Meisyou1A6 = MainWindow.a_meisyou[1, 10, 6];
            //obj.Meisyou1A7 = MainWindow.a_meisyou[1, 10, 7];
            //obj.Meisyou1A8 = MainWindow.a_meisyou[1, 10, 8];
            //obj.Meisyou1A9 = MainWindow.a_meisyou[1, 10, 9];

            ////品種3
            ////3-Stream1
            //obj.Meisyou200 = MainWindow.a_meisyou[2, 0, 0];
            //obj.Meisyou201 = MainWindow.a_meisyou[2, 0, 1];
            //obj.Meisyou202 = MainWindow.a_meisyou[2, 0, 2];
            //obj.Meisyou203 = MainWindow.a_meisyou[2, 0, 3];
            //obj.Meisyou204 = MainWindow.a_meisyou[2, 0, 4];
            //obj.Meisyou205 = MainWindow.a_meisyou[2, 0, 5];
            //obj.Meisyou206 = MainWindow.a_meisyou[2, 0, 6];
            //obj.Meisyou207 = MainWindow.a_meisyou[2, 0, 7];
            //obj.Meisyou208 = MainWindow.a_meisyou[2, 0, 8];
            //obj.Meisyou209 = MainWindow.a_meisyou[2, 0, 9];
            ////3-Stream2
            //obj.Meisyou210 = MainWindow.a_meisyou[2, 1, 0];
            //obj.Meisyou211 = MainWindow.a_meisyou[2, 1, 1];
            //obj.Meisyou212 = MainWindow.a_meisyou[2, 1, 2];
            //obj.Meisyou213 = MainWindow.a_meisyou[2, 1, 3];
            //obj.Meisyou214 = MainWindow.a_meisyou[2, 1, 4];
            //obj.Meisyou215 = MainWindow.a_meisyou[2, 1, 5];
            //obj.Meisyou216 = MainWindow.a_meisyou[2, 1, 6];
            //obj.Meisyou217 = MainWindow.a_meisyou[2, 1, 7];
            //obj.Meisyou218 = MainWindow.a_meisyou[2, 1, 8];
            //obj.Meisyou219 = MainWindow.a_meisyou[2, 1, 9];
            ////3-Stream3
            //obj.Meisyou220 = MainWindow.a_meisyou[2, 2, 0];
            //obj.Meisyou221 = MainWindow.a_meisyou[2, 2, 1];
            //obj.Meisyou222 = MainWindow.a_meisyou[2, 2, 2];
            //obj.Meisyou223 = MainWindow.a_meisyou[2, 2, 3];
            //obj.Meisyou224 = MainWindow.a_meisyou[2, 2, 4];
            //obj.Meisyou225 = MainWindow.a_meisyou[2, 2, 5];
            //obj.Meisyou226 = MainWindow.a_meisyou[2, 2, 6];
            //obj.Meisyou227 = MainWindow.a_meisyou[2, 2, 7];
            //obj.Meisyou228 = MainWindow.a_meisyou[2, 2, 8];
            //obj.Meisyou229 = MainWindow.a_meisyou[2, 2, 9];
            ////3-Stream4
            //obj.Meisyou230 = MainWindow.a_meisyou[2, 3, 0];
            //obj.Meisyou231 = MainWindow.a_meisyou[2, 3, 1];
            //obj.Meisyou232 = MainWindow.a_meisyou[2, 3, 2];
            //obj.Meisyou233 = MainWindow.a_meisyou[2, 3, 3];
            //obj.Meisyou234 = MainWindow.a_meisyou[2, 3, 4];
            //obj.Meisyou235 = MainWindow.a_meisyou[2, 3, 5];
            //obj.Meisyou236 = MainWindow.a_meisyou[2, 3, 6];
            //obj.Meisyou237 = MainWindow.a_meisyou[2, 3, 7];
            //obj.Meisyou238 = MainWindow.a_meisyou[2, 3, 8];
            //obj.Meisyou239 = MainWindow.a_meisyou[2, 3, 9];
            ////3-Stream5
            //obj.Meisyou240 = MainWindow.a_meisyou[2, 4, 0];
            //obj.Meisyou241 = MainWindow.a_meisyou[2, 4, 1];
            //obj.Meisyou242 = MainWindow.a_meisyou[2, 4, 2];
            //obj.Meisyou243 = MainWindow.a_meisyou[2, 4, 3];
            //obj.Meisyou244 = MainWindow.a_meisyou[2, 4, 4];
            //obj.Meisyou245 = MainWindow.a_meisyou[2, 4, 5];
            //obj.Meisyou246 = MainWindow.a_meisyou[2, 4, 6];
            //obj.Meisyou247 = MainWindow.a_meisyou[2, 4, 7];
            //obj.Meisyou248 = MainWindow.a_meisyou[2, 4, 8];
            //obj.Meisyou249 = MainWindow.a_meisyou[2, 4, 9];
            ////3-Stream6
            //obj.Meisyou250 = MainWindow.a_meisyou[2, 5, 0];
            //obj.Meisyou251 = MainWindow.a_meisyou[2, 5, 1];
            //obj.Meisyou252 = MainWindow.a_meisyou[2, 5, 2];
            //obj.Meisyou253 = MainWindow.a_meisyou[2, 5, 3];
            //obj.Meisyou254 = MainWindow.a_meisyou[2, 5, 4];
            //obj.Meisyou255 = MainWindow.a_meisyou[2, 5, 5];
            //obj.Meisyou256 = MainWindow.a_meisyou[2, 5, 6];
            //obj.Meisyou257 = MainWindow.a_meisyou[2, 5, 7];
            //obj.Meisyou258 = MainWindow.a_meisyou[2, 5, 8];
            //obj.Meisyou259 = MainWindow.a_meisyou[2, 5, 9];
            ////3-Stream7
            //obj.Meisyou260 = MainWindow.a_meisyou[2, 6, 0];
            //obj.Meisyou261 = MainWindow.a_meisyou[2, 6, 1];
            //obj.Meisyou262 = MainWindow.a_meisyou[2, 6, 2];
            //obj.Meisyou263 = MainWindow.a_meisyou[2, 6, 3];
            //obj.Meisyou264 = MainWindow.a_meisyou[2, 6, 4];
            //obj.Meisyou265 = MainWindow.a_meisyou[2, 6, 5];
            //obj.Meisyou266 = MainWindow.a_meisyou[2, 6, 6];
            //obj.Meisyou267 = MainWindow.a_meisyou[2, 6, 7];
            //obj.Meisyou268 = MainWindow.a_meisyou[2, 6, 8];
            //obj.Meisyou269 = MainWindow.a_meisyou[2, 6, 9];
            ////3-Stream8
            //obj.Meisyou270 = MainWindow.a_meisyou[2, 7, 0];
            //obj.Meisyou271 = MainWindow.a_meisyou[2, 7, 1];
            //obj.Meisyou272 = MainWindow.a_meisyou[2, 7, 2];
            //obj.Meisyou273 = MainWindow.a_meisyou[2, 7, 3];
            //obj.Meisyou274 = MainWindow.a_meisyou[2, 7, 4];
            //obj.Meisyou275 = MainWindow.a_meisyou[2, 7, 5];
            //obj.Meisyou276 = MainWindow.a_meisyou[2, 7, 6];
            //obj.Meisyou277 = MainWindow.a_meisyou[2, 7, 7];
            //obj.Meisyou278 = MainWindow.a_meisyou[2, 7, 8];
            //obj.Meisyou279 = MainWindow.a_meisyou[2, 7, 9];
            ////3-Stream9
            //obj.Meisyou280 = MainWindow.a_meisyou[2, 8, 0];
            //obj.Meisyou281 = MainWindow.a_meisyou[2, 8, 1];
            //obj.Meisyou282 = MainWindow.a_meisyou[2, 8, 2];
            //obj.Meisyou283 = MainWindow.a_meisyou[2, 8, 3];
            //obj.Meisyou284 = MainWindow.a_meisyou[2, 8, 4];
            //obj.Meisyou285 = MainWindow.a_meisyou[2, 8, 5];
            //obj.Meisyou286 = MainWindow.a_meisyou[2, 8, 6];
            //obj.Meisyou287 = MainWindow.a_meisyou[2, 8, 7];
            //obj.Meisyou288 = MainWindow.a_meisyou[2, 8, 8];
            //obj.Meisyou289 = MainWindow.a_meisyou[2, 8, 9];
            ////3-Stream10
            //obj.Meisyou290 = MainWindow.a_meisyou[2, 9, 0];
            //obj.Meisyou291 = MainWindow.a_meisyou[2, 9, 1];
            //obj.Meisyou292 = MainWindow.a_meisyou[2, 9, 2];
            //obj.Meisyou293 = MainWindow.a_meisyou[2, 9, 3];
            //obj.Meisyou294 = MainWindow.a_meisyou[2, 9, 4];
            //obj.Meisyou295 = MainWindow.a_meisyou[2, 9, 5];
            //obj.Meisyou296 = MainWindow.a_meisyou[2, 9, 6];
            //obj.Meisyou297 = MainWindow.a_meisyou[2, 9, 7];
            //obj.Meisyou298 = MainWindow.a_meisyou[2, 9, 8];
            //obj.Meisyou299 = MainWindow.a_meisyou[2, 9, 9];
            ////3-Stream11
            //obj.Meisyou2A0 = MainWindow.a_meisyou[2, 10, 0];
            //obj.Meisyou2A1 = MainWindow.a_meisyou[2, 10, 1];
            //obj.Meisyou2A2 = MainWindow.a_meisyou[2, 10, 2];
            //obj.Meisyou2A3 = MainWindow.a_meisyou[2, 10, 3];
            //obj.Meisyou2A4 = MainWindow.a_meisyou[2, 10, 4];
            //obj.Meisyou2A5 = MainWindow.a_meisyou[2, 10, 5];
            //obj.Meisyou2A6 = MainWindow.a_meisyou[2, 10, 6];
            //obj.Meisyou2A7 = MainWindow.a_meisyou[2, 10, 7];
            //obj.Meisyou2A8 = MainWindow.a_meisyou[2, 10, 8];
            //obj.Meisyou2A9 = MainWindow.a_meisyou[2, 10, 9];

            ////品種4
            ////4-Stream1
            //obj.Meisyou300 = MainWindow.a_meisyou[3, 0, 0];
            //obj.Meisyou301 = MainWindow.a_meisyou[3, 0, 1];
            //obj.Meisyou302 = MainWindow.a_meisyou[3, 0, 2];
            //obj.Meisyou303 = MainWindow.a_meisyou[3, 0, 3];
            //obj.Meisyou304 = MainWindow.a_meisyou[3, 0, 4];
            //obj.Meisyou305 = MainWindow.a_meisyou[3, 0, 5];
            //obj.Meisyou306 = MainWindow.a_meisyou[3, 0, 6];
            //obj.Meisyou307 = MainWindow.a_meisyou[3, 0, 7];
            //obj.Meisyou308 = MainWindow.a_meisyou[3, 0, 8];
            //obj.Meisyou309 = MainWindow.a_meisyou[3, 0, 9];
            ////4-Stream2
            //obj.Meisyou310 = MainWindow.a_meisyou[3, 1, 0];
            //obj.Meisyou311 = MainWindow.a_meisyou[3, 1, 1];
            //obj.Meisyou312 = MainWindow.a_meisyou[3, 1, 2];
            //obj.Meisyou313 = MainWindow.a_meisyou[3, 1, 3];
            //obj.Meisyou314 = MainWindow.a_meisyou[3, 1, 4];
            //obj.Meisyou315 = MainWindow.a_meisyou[3, 1, 5];
            //obj.Meisyou316 = MainWindow.a_meisyou[3, 1, 6];
            //obj.Meisyou317 = MainWindow.a_meisyou[3, 1, 7];
            //obj.Meisyou318 = MainWindow.a_meisyou[3, 1, 8];
            //obj.Meisyou319 = MainWindow.a_meisyou[3, 1, 9];
            ////4-Stream3
            //obj.Meisyou320 = MainWindow.a_meisyou[3, 2, 0];
            //obj.Meisyou321 = MainWindow.a_meisyou[3, 2, 1];
            //obj.Meisyou322 = MainWindow.a_meisyou[3, 2, 2];
            //obj.Meisyou323 = MainWindow.a_meisyou[3, 2, 3];
            //obj.Meisyou324 = MainWindow.a_meisyou[3, 2, 4];
            //obj.Meisyou325 = MainWindow.a_meisyou[3, 2, 5];
            //obj.Meisyou326 = MainWindow.a_meisyou[3, 2, 6];
            //obj.Meisyou327 = MainWindow.a_meisyou[3, 2, 7];
            //obj.Meisyou328 = MainWindow.a_meisyou[3, 2, 8];
            //obj.Meisyou329 = MainWindow.a_meisyou[3, 2, 9];
            ////4-Stream4
            //obj.Meisyou330 = MainWindow.a_meisyou[3, 3, 0];
            //obj.Meisyou331 = MainWindow.a_meisyou[3, 3, 1];
            //obj.Meisyou332 = MainWindow.a_meisyou[3, 3, 2];
            //obj.Meisyou333 = MainWindow.a_meisyou[3, 3, 3];
            //obj.Meisyou334 = MainWindow.a_meisyou[3, 3, 4];
            //obj.Meisyou335 = MainWindow.a_meisyou[3, 3, 5];
            //obj.Meisyou336 = MainWindow.a_meisyou[3, 3, 6];
            //obj.Meisyou337 = MainWindow.a_meisyou[3, 3, 7];
            //obj.Meisyou338 = MainWindow.a_meisyou[3, 3, 8];
            //obj.Meisyou339 = MainWindow.a_meisyou[3, 3, 9];
            ////4-Stream5
            //obj.Meisyou340 = MainWindow.a_meisyou[3, 4, 0];
            //obj.Meisyou341 = MainWindow.a_meisyou[3, 4, 1];
            //obj.Meisyou342 = MainWindow.a_meisyou[3, 4, 2];
            //obj.Meisyou343 = MainWindow.a_meisyou[3, 4, 3];
            //obj.Meisyou344 = MainWindow.a_meisyou[3, 4, 4];
            //obj.Meisyou345 = MainWindow.a_meisyou[3, 4, 5];
            //obj.Meisyou346 = MainWindow.a_meisyou[3, 4, 6];
            //obj.Meisyou347 = MainWindow.a_meisyou[3, 4, 7];
            //obj.Meisyou348 = MainWindow.a_meisyou[3, 4, 8];
            //obj.Meisyou349 = MainWindow.a_meisyou[3, 4, 9];
            ////4-Stream6
            //obj.Meisyou350 = MainWindow.a_meisyou[3, 5, 0];
            //obj.Meisyou351 = MainWindow.a_meisyou[3, 5, 1];
            //obj.Meisyou352 = MainWindow.a_meisyou[3, 5, 2];
            //obj.Meisyou353 = MainWindow.a_meisyou[3, 5, 3];
            //obj.Meisyou354 = MainWindow.a_meisyou[3, 5, 4];
            //obj.Meisyou355 = MainWindow.a_meisyou[3, 5, 5];
            //obj.Meisyou356 = MainWindow.a_meisyou[3, 5, 6];
            //obj.Meisyou357 = MainWindow.a_meisyou[3, 5, 7];
            //obj.Meisyou358 = MainWindow.a_meisyou[3, 5, 8];
            //obj.Meisyou359 = MainWindow.a_meisyou[3, 5, 9];
            ////4-Stream7
            //obj.Meisyou360 = MainWindow.a_meisyou[3, 6, 0];
            //obj.Meisyou361 = MainWindow.a_meisyou[3, 6, 1];
            //obj.Meisyou362 = MainWindow.a_meisyou[3, 6, 2];
            //obj.Meisyou363 = MainWindow.a_meisyou[3, 6, 3];
            //obj.Meisyou364 = MainWindow.a_meisyou[3, 6, 4];
            //obj.Meisyou365 = MainWindow.a_meisyou[3, 6, 5];
            //obj.Meisyou366 = MainWindow.a_meisyou[3, 6, 6];
            //obj.Meisyou367 = MainWindow.a_meisyou[3, 6, 7];
            //obj.Meisyou368 = MainWindow.a_meisyou[3, 6, 8];
            //obj.Meisyou369 = MainWindow.a_meisyou[3, 6, 9];
            ////4-Stream8
            //obj.Meisyou370 = MainWindow.a_meisyou[3, 7, 0];
            //obj.Meisyou371 = MainWindow.a_meisyou[3, 7, 1];
            //obj.Meisyou372 = MainWindow.a_meisyou[3, 7, 2];
            //obj.Meisyou373 = MainWindow.a_meisyou[3, 7, 3];
            //obj.Meisyou374 = MainWindow.a_meisyou[3, 7, 4];
            //obj.Meisyou375 = MainWindow.a_meisyou[3, 7, 5];
            //obj.Meisyou376 = MainWindow.a_meisyou[3, 7, 6];
            //obj.Meisyou377 = MainWindow.a_meisyou[3, 7, 7];
            //obj.Meisyou378 = MainWindow.a_meisyou[3, 7, 8];
            //obj.Meisyou379 = MainWindow.a_meisyou[3, 7, 9];
            ////4-Stream9
            //obj.Meisyou380 = MainWindow.a_meisyou[3, 8, 0];
            //obj.Meisyou381 = MainWindow.a_meisyou[3, 8, 1];
            //obj.Meisyou382 = MainWindow.a_meisyou[3, 8, 2];
            //obj.Meisyou383 = MainWindow.a_meisyou[3, 8, 3];
            //obj.Meisyou384 = MainWindow.a_meisyou[3, 8, 4];
            //obj.Meisyou385 = MainWindow.a_meisyou[3, 8, 5];
            //obj.Meisyou386 = MainWindow.a_meisyou[3, 8, 6];
            //obj.Meisyou387 = MainWindow.a_meisyou[3, 8, 7];
            //obj.Meisyou388 = MainWindow.a_meisyou[3, 8, 8];
            //obj.Meisyou389 = MainWindow.a_meisyou[3, 8, 9];
            ////4-Stream10
            //obj.Meisyou390 = MainWindow.a_meisyou[3, 9, 0];
            //obj.Meisyou391 = MainWindow.a_meisyou[3, 9, 1];
            //obj.Meisyou392 = MainWindow.a_meisyou[3, 9, 2];
            //obj.Meisyou393 = MainWindow.a_meisyou[3, 9, 3];
            //obj.Meisyou394 = MainWindow.a_meisyou[3, 9, 4];
            //obj.Meisyou395 = MainWindow.a_meisyou[3, 9, 5];
            //obj.Meisyou396 = MainWindow.a_meisyou[3, 9, 6];
            //obj.Meisyou397 = MainWindow.a_meisyou[3, 9, 7];
            //obj.Meisyou398 = MainWindow.a_meisyou[3, 9, 8];
            //obj.Meisyou399 = MainWindow.a_meisyou[3, 9, 9];
            ////4-Stream11
            //obj.Meisyou3A0 = MainWindow.a_meisyou[3, 10, 0];
            //obj.Meisyou3A1 = MainWindow.a_meisyou[3, 10, 1];
            //obj.Meisyou3A2 = MainWindow.a_meisyou[3, 10, 2];
            //obj.Meisyou3A3 = MainWindow.a_meisyou[3, 10, 3];
            //obj.Meisyou3A4 = MainWindow.a_meisyou[3, 10, 4];
            //obj.Meisyou3A5 = MainWindow.a_meisyou[3, 10, 5];
            //obj.Meisyou3A6 = MainWindow.a_meisyou[3, 10, 6];
            //obj.Meisyou3A7 = MainWindow.a_meisyou[3, 10, 7];
            //obj.Meisyou3A8 = MainWindow.a_meisyou[3, 10, 8];
            //obj.Meisyou3A9 = MainWindow.a_meisyou[3, 10, 9];

            ////品種5
            ////5-Stream1
            //obj.Meisyou400 = MainWindow.a_meisyou[4, 0, 0];
            //obj.Meisyou401 = MainWindow.a_meisyou[4, 0, 1];
            //obj.Meisyou402 = MainWindow.a_meisyou[4, 0, 2];
            //obj.Meisyou403 = MainWindow.a_meisyou[4, 0, 3];
            //obj.Meisyou404 = MainWindow.a_meisyou[4, 0, 4];
            //obj.Meisyou405 = MainWindow.a_meisyou[4, 0, 5];
            //obj.Meisyou406 = MainWindow.a_meisyou[4, 0, 6];
            //obj.Meisyou407 = MainWindow.a_meisyou[4, 0, 7];
            //obj.Meisyou408 = MainWindow.a_meisyou[4, 0, 8];
            //obj.Meisyou409 = MainWindow.a_meisyou[4, 0, 9];
            ////5-Stream2
            //obj.Meisyou410 = MainWindow.a_meisyou[4, 1, 0];
            //obj.Meisyou411 = MainWindow.a_meisyou[4, 1, 1];
            //obj.Meisyou412 = MainWindow.a_meisyou[4, 1, 2];
            //obj.Meisyou413 = MainWindow.a_meisyou[4, 1, 3];
            //obj.Meisyou414 = MainWindow.a_meisyou[4, 1, 4];
            //obj.Meisyou415 = MainWindow.a_meisyou[4, 1, 5];
            //obj.Meisyou416 = MainWindow.a_meisyou[4, 1, 6];
            //obj.Meisyou417 = MainWindow.a_meisyou[4, 1, 7];
            //obj.Meisyou418 = MainWindow.a_meisyou[4, 1, 8];
            //obj.Meisyou419 = MainWindow.a_meisyou[4, 1, 9];
            ////5-Stream3
            //obj.Meisyou420 = MainWindow.a_meisyou[4, 2, 0];
            //obj.Meisyou421 = MainWindow.a_meisyou[4, 2, 1];
            //obj.Meisyou422 = MainWindow.a_meisyou[4, 2, 2];
            //obj.Meisyou423 = MainWindow.a_meisyou[4, 2, 3];
            //obj.Meisyou424 = MainWindow.a_meisyou[4, 2, 4];
            //obj.Meisyou425 = MainWindow.a_meisyou[4, 2, 5];
            //obj.Meisyou426 = MainWindow.a_meisyou[4, 2, 6];
            //obj.Meisyou427 = MainWindow.a_meisyou[4, 2, 7];
            //obj.Meisyou428 = MainWindow.a_meisyou[4, 2, 8];
            //obj.Meisyou429 = MainWindow.a_meisyou[4, 2, 9];
            ////5-Stream4
            //obj.Meisyou430 = MainWindow.a_meisyou[4, 3, 0];
            //obj.Meisyou431 = MainWindow.a_meisyou[4, 3, 1];
            //obj.Meisyou432 = MainWindow.a_meisyou[4, 3, 2];
            //obj.Meisyou433 = MainWindow.a_meisyou[4, 3, 3];
            //obj.Meisyou434 = MainWindow.a_meisyou[4, 3, 4];
            //obj.Meisyou435 = MainWindow.a_meisyou[4, 3, 5];
            //obj.Meisyou436 = MainWindow.a_meisyou[4, 3, 6];
            //obj.Meisyou437 = MainWindow.a_meisyou[4, 3, 7];
            //obj.Meisyou438 = MainWindow.a_meisyou[4, 3, 8];
            //obj.Meisyou439 = MainWindow.a_meisyou[4, 3, 9];
            ////5-Stream5
            //obj.Meisyou440 = MainWindow.a_meisyou[4, 4, 0];
            //obj.Meisyou441 = MainWindow.a_meisyou[4, 4, 1];
            //obj.Meisyou442 = MainWindow.a_meisyou[4, 4, 2];
            //obj.Meisyou443 = MainWindow.a_meisyou[4, 4, 3];
            //obj.Meisyou444 = MainWindow.a_meisyou[4, 4, 4];
            //obj.Meisyou445 = MainWindow.a_meisyou[4, 4, 5];
            //obj.Meisyou446 = MainWindow.a_meisyou[4, 4, 6];
            //obj.Meisyou447 = MainWindow.a_meisyou[4, 4, 7];
            //obj.Meisyou448 = MainWindow.a_meisyou[4, 4, 8];
            //obj.Meisyou449 = MainWindow.a_meisyou[4, 4, 9];
            ////5-Stream6
            //obj.Meisyou450 = MainWindow.a_meisyou[4, 5, 0];
            //obj.Meisyou451 = MainWindow.a_meisyou[4, 5, 1];
            //obj.Meisyou452 = MainWindow.a_meisyou[4, 5, 2];
            //obj.Meisyou453 = MainWindow.a_meisyou[4, 5, 3];
            //obj.Meisyou454 = MainWindow.a_meisyou[4, 5, 4];
            //obj.Meisyou455 = MainWindow.a_meisyou[4, 5, 5];
            //obj.Meisyou456 = MainWindow.a_meisyou[4, 5, 6];
            //obj.Meisyou457 = MainWindow.a_meisyou[4, 5, 7];
            //obj.Meisyou458 = MainWindow.a_meisyou[4, 5, 8];
            //obj.Meisyou459 = MainWindow.a_meisyou[4, 5, 9];
            ////5-Stream7
            //obj.Meisyou460 = MainWindow.a_meisyou[4, 6, 0];
            //obj.Meisyou461 = MainWindow.a_meisyou[4, 6, 1];
            //obj.Meisyou462 = MainWindow.a_meisyou[4, 6, 2];
            //obj.Meisyou463 = MainWindow.a_meisyou[4, 6, 3];
            //obj.Meisyou464 = MainWindow.a_meisyou[4, 6, 4];
            //obj.Meisyou465 = MainWindow.a_meisyou[4, 6, 5];
            //obj.Meisyou466 = MainWindow.a_meisyou[4, 6, 6];
            //obj.Meisyou467 = MainWindow.a_meisyou[4, 6, 7];
            //obj.Meisyou468 = MainWindow.a_meisyou[4, 6, 8];
            //obj.Meisyou469 = MainWindow.a_meisyou[4, 6, 9];
            ////5-Stream8
            //obj.Meisyou470 = MainWindow.a_meisyou[4, 7, 0];
            //obj.Meisyou471 = MainWindow.a_meisyou[4, 7, 1];
            //obj.Meisyou472 = MainWindow.a_meisyou[4, 7, 2];
            //obj.Meisyou473 = MainWindow.a_meisyou[4, 7, 3];
            //obj.Meisyou474 = MainWindow.a_meisyou[4, 7, 4];
            //obj.Meisyou475 = MainWindow.a_meisyou[4, 7, 5];
            //obj.Meisyou476 = MainWindow.a_meisyou[4, 7, 6];
            //obj.Meisyou477 = MainWindow.a_meisyou[4, 7, 7];
            //obj.Meisyou478 = MainWindow.a_meisyou[4, 7, 8];
            //obj.Meisyou479 = MainWindow.a_meisyou[4, 7, 9];
            ////5-Stream9
            //obj.Meisyou480 = MainWindow.a_meisyou[4, 8, 0];
            //obj.Meisyou481 = MainWindow.a_meisyou[4, 8, 1];
            //obj.Meisyou482 = MainWindow.a_meisyou[4, 8, 2];
            //obj.Meisyou483 = MainWindow.a_meisyou[4, 8, 3];
            //obj.Meisyou484 = MainWindow.a_meisyou[4, 8, 4];
            //obj.Meisyou485 = MainWindow.a_meisyou[4, 8, 5];
            //obj.Meisyou486 = MainWindow.a_meisyou[4, 8, 6];
            //obj.Meisyou487 = MainWindow.a_meisyou[4, 8, 7];
            //obj.Meisyou488 = MainWindow.a_meisyou[4, 8, 8];
            //obj.Meisyou489 = MainWindow.a_meisyou[4, 8, 9];
            ////5-Stream10
            //obj.Meisyou490 = MainWindow.a_meisyou[4, 9, 0];
            //obj.Meisyou491 = MainWindow.a_meisyou[4, 9, 1];
            //obj.Meisyou492 = MainWindow.a_meisyou[4, 9, 2];
            //obj.Meisyou493 = MainWindow.a_meisyou[4, 9, 3];
            //obj.Meisyou494 = MainWindow.a_meisyou[4, 9, 4];
            //obj.Meisyou495 = MainWindow.a_meisyou[4, 9, 5];
            //obj.Meisyou496 = MainWindow.a_meisyou[4, 9, 6];
            //obj.Meisyou497 = MainWindow.a_meisyou[4, 9, 7];
            //obj.Meisyou498 = MainWindow.a_meisyou[4, 9, 8];
            //obj.Meisyou499 = MainWindow.a_meisyou[4, 9, 9];
            ////5-Stream11
            //obj.Meisyou4A0 = MainWindow.a_meisyou[4, 10, 0];
            //obj.Meisyou4A1 = MainWindow.a_meisyou[4, 10, 1];
            //obj.Meisyou4A2 = MainWindow.a_meisyou[4, 10, 2];
            //obj.Meisyou4A3 = MainWindow.a_meisyou[4, 10, 3];
            //obj.Meisyou4A4 = MainWindow.a_meisyou[4, 10, 4];
            //obj.Meisyou4A5 = MainWindow.a_meisyou[4, 10, 5];
            //obj.Meisyou4A6 = MainWindow.a_meisyou[4, 10, 6];
            //obj.Meisyou4A7 = MainWindow.a_meisyou[4, 10, 7];
            //obj.Meisyou4A8 = MainWindow.a_meisyou[4, 10, 8];
            //obj.Meisyou4A9 = MainWindow.a_meisyou[4, 10, 9];

            ////品種6
            ////6-Stream1
            //obj.Meisyou500 = MainWindow.a_meisyou[5, 0, 0];
            //obj.Meisyou501 = MainWindow.a_meisyou[5, 0, 1];
            //obj.Meisyou502 = MainWindow.a_meisyou[5, 0, 2];
            //obj.Meisyou503 = MainWindow.a_meisyou[5, 0, 3];
            //obj.Meisyou504 = MainWindow.a_meisyou[5, 0, 4];
            //obj.Meisyou505 = MainWindow.a_meisyou[5, 0, 5];
            //obj.Meisyou506 = MainWindow.a_meisyou[5, 0, 6];
            //obj.Meisyou507 = MainWindow.a_meisyou[5, 0, 7];
            //obj.Meisyou508 = MainWindow.a_meisyou[5, 0, 8];
            //obj.Meisyou509 = MainWindow.a_meisyou[5, 0, 9];
            ////6-Stream2
            //obj.Meisyou510 = MainWindow.a_meisyou[5, 1, 0];
            //obj.Meisyou511 = MainWindow.a_meisyou[5, 1, 1];
            //obj.Meisyou512 = MainWindow.a_meisyou[5, 1, 2];
            //obj.Meisyou513 = MainWindow.a_meisyou[5, 1, 3];
            //obj.Meisyou514 = MainWindow.a_meisyou[5, 1, 4];
            //obj.Meisyou515 = MainWindow.a_meisyou[5, 1, 5];
            //obj.Meisyou516 = MainWindow.a_meisyou[5, 1, 6];
            //obj.Meisyou517 = MainWindow.a_meisyou[5, 1, 7];
            //obj.Meisyou518 = MainWindow.a_meisyou[5, 1, 8];
            //obj.Meisyou519 = MainWindow.a_meisyou[5, 1, 9];
            ////6-Stream3
            //obj.Meisyou520 = MainWindow.a_meisyou[5, 2, 0];
            //obj.Meisyou521 = MainWindow.a_meisyou[5, 2, 1];
            //obj.Meisyou522 = MainWindow.a_meisyou[5, 2, 2];
            //obj.Meisyou523 = MainWindow.a_meisyou[5, 2, 3];
            //obj.Meisyou524 = MainWindow.a_meisyou[5, 2, 4];
            //obj.Meisyou525 = MainWindow.a_meisyou[5, 2, 5];
            //obj.Meisyou526 = MainWindow.a_meisyou[5, 2, 6];
            //obj.Meisyou527 = MainWindow.a_meisyou[5, 2, 7];
            //obj.Meisyou528 = MainWindow.a_meisyou[5, 2, 8];
            //obj.Meisyou529 = MainWindow.a_meisyou[5, 2, 9];
            ////6-Stream4
            //obj.Meisyou530 = MainWindow.a_meisyou[5, 3, 0];
            //obj.Meisyou531 = MainWindow.a_meisyou[5, 3, 1];
            //obj.Meisyou532 = MainWindow.a_meisyou[5, 3, 2];
            //obj.Meisyou533 = MainWindow.a_meisyou[5, 3, 3];
            //obj.Meisyou534 = MainWindow.a_meisyou[5, 3, 4];
            //obj.Meisyou535 = MainWindow.a_meisyou[5, 3, 5];
            //obj.Meisyou536 = MainWindow.a_meisyou[5, 3, 6];
            //obj.Meisyou537 = MainWindow.a_meisyou[5, 3, 7];
            //obj.Meisyou538 = MainWindow.a_meisyou[5, 3, 8];
            //obj.Meisyou539 = MainWindow.a_meisyou[5, 3, 9];
            ////6-Stream5
            //obj.Meisyou540 = MainWindow.a_meisyou[5, 4, 0];
            //obj.Meisyou541 = MainWindow.a_meisyou[5, 4, 1];
            //obj.Meisyou542 = MainWindow.a_meisyou[5, 4, 2];
            //obj.Meisyou543 = MainWindow.a_meisyou[5, 4, 3];
            //obj.Meisyou544 = MainWindow.a_meisyou[5, 4, 4];
            //obj.Meisyou545 = MainWindow.a_meisyou[5, 4, 5];
            //obj.Meisyou546 = MainWindow.a_meisyou[5, 4, 6];
            //obj.Meisyou547 = MainWindow.a_meisyou[5, 4, 7];
            //obj.Meisyou548 = MainWindow.a_meisyou[5, 4, 8];
            //obj.Meisyou549 = MainWindow.a_meisyou[5, 4, 9];
            ////6-Stream6
            //obj.Meisyou550 = MainWindow.a_meisyou[5, 5, 0];
            //obj.Meisyou551 = MainWindow.a_meisyou[5, 5, 1];
            //obj.Meisyou552 = MainWindow.a_meisyou[5, 5, 2];
            //obj.Meisyou553 = MainWindow.a_meisyou[5, 5, 3];
            //obj.Meisyou554 = MainWindow.a_meisyou[5, 5, 4];
            //obj.Meisyou555 = MainWindow.a_meisyou[5, 5, 5];
            //obj.Meisyou556 = MainWindow.a_meisyou[5, 5, 6];
            //obj.Meisyou557 = MainWindow.a_meisyou[5, 5, 7];
            //obj.Meisyou558 = MainWindow.a_meisyou[5, 5, 8];
            //obj.Meisyou559 = MainWindow.a_meisyou[5, 5, 9];
            ////6-Stream7
            //obj.Meisyou560 = MainWindow.a_meisyou[5, 6, 0];
            //obj.Meisyou561 = MainWindow.a_meisyou[5, 6, 1];
            //obj.Meisyou562 = MainWindow.a_meisyou[5, 6, 2];
            //obj.Meisyou563 = MainWindow.a_meisyou[5, 6, 3];
            //obj.Meisyou564 = MainWindow.a_meisyou[5, 6, 4];
            //obj.Meisyou565 = MainWindow.a_meisyou[5, 6, 5];
            //obj.Meisyou566 = MainWindow.a_meisyou[5, 6, 6];
            //obj.Meisyou567 = MainWindow.a_meisyou[5, 6, 7];
            //obj.Meisyou568 = MainWindow.a_meisyou[5, 6, 8];
            //obj.Meisyou569 = MainWindow.a_meisyou[5, 6, 9];
            ////6-Stream8
            //obj.Meisyou570 = MainWindow.a_meisyou[5, 7, 0];
            //obj.Meisyou571 = MainWindow.a_meisyou[5, 7, 1];
            //obj.Meisyou572 = MainWindow.a_meisyou[5, 7, 2];
            //obj.Meisyou573 = MainWindow.a_meisyou[5, 7, 3];
            //obj.Meisyou574 = MainWindow.a_meisyou[5, 7, 4];
            //obj.Meisyou575 = MainWindow.a_meisyou[5, 7, 5];
            //obj.Meisyou576 = MainWindow.a_meisyou[5, 7, 6];
            //obj.Meisyou577 = MainWindow.a_meisyou[5, 7, 7];
            //obj.Meisyou578 = MainWindow.a_meisyou[5, 7, 8];
            //obj.Meisyou579 = MainWindow.a_meisyou[5, 7, 9];
            ////6-Stream9
            //obj.Meisyou580 = MainWindow.a_meisyou[5, 8, 0];
            //obj.Meisyou581 = MainWindow.a_meisyou[5, 8, 1];
            //obj.Meisyou582 = MainWindow.a_meisyou[5, 8, 2];
            //obj.Meisyou583 = MainWindow.a_meisyou[5, 8, 3];
            //obj.Meisyou584 = MainWindow.a_meisyou[5, 8, 4];
            //obj.Meisyou585 = MainWindow.a_meisyou[5, 8, 5];
            //obj.Meisyou586 = MainWindow.a_meisyou[5, 8, 6];
            //obj.Meisyou587 = MainWindow.a_meisyou[5, 8, 7];
            //obj.Meisyou588 = MainWindow.a_meisyou[5, 8, 8];
            //obj.Meisyou589 = MainWindow.a_meisyou[5, 8, 9];
            ////6-Stream10
            //obj.Meisyou590 = MainWindow.a_meisyou[5, 9, 0];
            //obj.Meisyou591 = MainWindow.a_meisyou[5, 9, 1];
            //obj.Meisyou592 = MainWindow.a_meisyou[5, 9, 2];
            //obj.Meisyou593 = MainWindow.a_meisyou[5, 9, 3];
            //obj.Meisyou594 = MainWindow.a_meisyou[5, 9, 4];
            //obj.Meisyou595 = MainWindow.a_meisyou[5, 9, 5];
            //obj.Meisyou596 = MainWindow.a_meisyou[5, 9, 6];
            //obj.Meisyou597 = MainWindow.a_meisyou[5, 9, 7];
            //obj.Meisyou598 = MainWindow.a_meisyou[5, 9, 8];
            //obj.Meisyou599 = MainWindow.a_meisyou[5, 9, 9];
            ////6-Stream11
            //obj.Meisyou5A0 = MainWindow.a_meisyou[5, 10, 0];
            //obj.Meisyou5A1 = MainWindow.a_meisyou[5, 10, 1];
            //obj.Meisyou5A2 = MainWindow.a_meisyou[5, 10, 2];
            //obj.Meisyou5A3 = MainWindow.a_meisyou[5, 10, 3];
            //obj.Meisyou5A4 = MainWindow.a_meisyou[5, 10, 4];
            //obj.Meisyou5A5 = MainWindow.a_meisyou[5, 10, 5];
            //obj.Meisyou5A6 = MainWindow.a_meisyou[5, 10, 6];
            //obj.Meisyou5A7 = MainWindow.a_meisyou[5, 10, 7];
            //obj.Meisyou5A8 = MainWindow.a_meisyou[5, 10, 8];
            //obj.Meisyou5A9 = MainWindow.a_meisyou[5, 10, 9];

            ////品種7
            ////7-Stream1
            //obj.Meisyou600 = MainWindow.a_meisyou[6, 0, 0];
            //obj.Meisyou601 = MainWindow.a_meisyou[6, 0, 1];
            //obj.Meisyou602 = MainWindow.a_meisyou[6, 0, 2];
            //obj.Meisyou603 = MainWindow.a_meisyou[6, 0, 3];
            //obj.Meisyou604 = MainWindow.a_meisyou[6, 0, 4];
            //obj.Meisyou605 = MainWindow.a_meisyou[6, 0, 5];
            //obj.Meisyou606 = MainWindow.a_meisyou[6, 0, 6];
            //obj.Meisyou607 = MainWindow.a_meisyou[6, 0, 7];
            //obj.Meisyou608 = MainWindow.a_meisyou[6, 0, 8];
            //obj.Meisyou609 = MainWindow.a_meisyou[6, 0, 9];
            ////7-Stream2
            //obj.Meisyou610 = MainWindow.a_meisyou[6, 1, 0];
            //obj.Meisyou611 = MainWindow.a_meisyou[6, 1, 1];
            //obj.Meisyou612 = MainWindow.a_meisyou[6, 1, 2];
            //obj.Meisyou613 = MainWindow.a_meisyou[6, 1, 3];
            //obj.Meisyou614 = MainWindow.a_meisyou[6, 1, 4];
            //obj.Meisyou615 = MainWindow.a_meisyou[6, 1, 5];
            //obj.Meisyou616 = MainWindow.a_meisyou[6, 1, 6];
            //obj.Meisyou617 = MainWindow.a_meisyou[6, 1, 7];
            //obj.Meisyou618 = MainWindow.a_meisyou[6, 1, 8];
            //obj.Meisyou619 = MainWindow.a_meisyou[6, 1, 9];
            ////7-Stream3
            //obj.Meisyou620 = MainWindow.a_meisyou[6, 2, 0];
            //obj.Meisyou621 = MainWindow.a_meisyou[6, 2, 1];
            //obj.Meisyou622 = MainWindow.a_meisyou[6, 2, 2];
            //obj.Meisyou623 = MainWindow.a_meisyou[6, 2, 3];
            //obj.Meisyou624 = MainWindow.a_meisyou[6, 2, 4];
            //obj.Meisyou625 = MainWindow.a_meisyou[6, 2, 5];
            //obj.Meisyou626 = MainWindow.a_meisyou[6, 2, 6];
            //obj.Meisyou627 = MainWindow.a_meisyou[6, 2, 7];
            //obj.Meisyou628 = MainWindow.a_meisyou[6, 2, 8];
            //obj.Meisyou629 = MainWindow.a_meisyou[6, 2, 9];
            ////7-Stream4
            //obj.Meisyou630 = MainWindow.a_meisyou[6, 3, 0];
            //obj.Meisyou631 = MainWindow.a_meisyou[6, 3, 1];
            //obj.Meisyou632 = MainWindow.a_meisyou[6, 3, 2];
            //obj.Meisyou633 = MainWindow.a_meisyou[6, 3, 3];
            //obj.Meisyou634 = MainWindow.a_meisyou[6, 3, 4];
            //obj.Meisyou635 = MainWindow.a_meisyou[6, 3, 5];
            //obj.Meisyou636 = MainWindow.a_meisyou[6, 3, 6];
            //obj.Meisyou637 = MainWindow.a_meisyou[6, 3, 7];
            //obj.Meisyou638 = MainWindow.a_meisyou[6, 3, 8];
            //obj.Meisyou639 = MainWindow.a_meisyou[6, 3, 9];
            ////7-Stream5
            //obj.Meisyou640 = MainWindow.a_meisyou[6, 4, 0];
            //obj.Meisyou641 = MainWindow.a_meisyou[6, 4, 1];
            //obj.Meisyou642 = MainWindow.a_meisyou[6, 4, 2];
            //obj.Meisyou643 = MainWindow.a_meisyou[6, 4, 3];
            //obj.Meisyou644 = MainWindow.a_meisyou[6, 4, 4];
            //obj.Meisyou645 = MainWindow.a_meisyou[6, 4, 5];
            //obj.Meisyou646 = MainWindow.a_meisyou[6, 4, 6];
            //obj.Meisyou647 = MainWindow.a_meisyou[6, 4, 7];
            //obj.Meisyou648 = MainWindow.a_meisyou[6, 4, 8];
            //obj.Meisyou649 = MainWindow.a_meisyou[6, 4, 9];
            ////7-Stream6
            //obj.Meisyou650 = MainWindow.a_meisyou[6, 5, 0];
            //obj.Meisyou651 = MainWindow.a_meisyou[6, 5, 1];
            //obj.Meisyou652 = MainWindow.a_meisyou[6, 5, 2];
            //obj.Meisyou653 = MainWindow.a_meisyou[6, 5, 3];
            //obj.Meisyou654 = MainWindow.a_meisyou[6, 5, 4];
            //obj.Meisyou655 = MainWindow.a_meisyou[6, 5, 5];
            //obj.Meisyou656 = MainWindow.a_meisyou[6, 5, 6];
            //obj.Meisyou657 = MainWindow.a_meisyou[6, 5, 7];
            //obj.Meisyou658 = MainWindow.a_meisyou[6, 5, 8];
            //obj.Meisyou659 = MainWindow.a_meisyou[6, 5, 9];
            ////7-Stream7
            //obj.Meisyou660 = MainWindow.a_meisyou[6, 6, 0];
            //obj.Meisyou661 = MainWindow.a_meisyou[6, 6, 1];
            //obj.Meisyou662 = MainWindow.a_meisyou[6, 6, 2];
            //obj.Meisyou663 = MainWindow.a_meisyou[6, 6, 3];
            //obj.Meisyou664 = MainWindow.a_meisyou[6, 6, 4];
            //obj.Meisyou665 = MainWindow.a_meisyou[6, 6, 5];
            //obj.Meisyou666 = MainWindow.a_meisyou[6, 6, 6];
            //obj.Meisyou667 = MainWindow.a_meisyou[6, 6, 7];
            //obj.Meisyou668 = MainWindow.a_meisyou[6, 6, 8];
            //obj.Meisyou669 = MainWindow.a_meisyou[6, 6, 9];
            ////7-Stream8
            //obj.Meisyou670 = MainWindow.a_meisyou[6, 7, 0];
            //obj.Meisyou671 = MainWindow.a_meisyou[6, 7, 1];
            //obj.Meisyou672 = MainWindow.a_meisyou[6, 7, 2];
            //obj.Meisyou673 = MainWindow.a_meisyou[6, 7, 3];
            //obj.Meisyou674 = MainWindow.a_meisyou[6, 7, 4];
            //obj.Meisyou675 = MainWindow.a_meisyou[6, 7, 5];
            //obj.Meisyou676 = MainWindow.a_meisyou[6, 7, 6];
            //obj.Meisyou677 = MainWindow.a_meisyou[6, 7, 7];
            //obj.Meisyou678 = MainWindow.a_meisyou[6, 7, 8];
            //obj.Meisyou679 = MainWindow.a_meisyou[6, 7, 9];
            ////7-Stream9
            //obj.Meisyou680 = MainWindow.a_meisyou[6, 8, 0];
            //obj.Meisyou681 = MainWindow.a_meisyou[6, 8, 1];
            //obj.Meisyou682 = MainWindow.a_meisyou[6, 8, 2];
            //obj.Meisyou683 = MainWindow.a_meisyou[6, 8, 3];
            //obj.Meisyou684 = MainWindow.a_meisyou[6, 8, 4];
            //obj.Meisyou685 = MainWindow.a_meisyou[6, 8, 5];
            //obj.Meisyou686 = MainWindow.a_meisyou[6, 8, 6];
            //obj.Meisyou687 = MainWindow.a_meisyou[6, 8, 7];
            //obj.Meisyou688 = MainWindow.a_meisyou[6, 8, 8];
            //obj.Meisyou689 = MainWindow.a_meisyou[6, 8, 9];
            ////7-Stream10
            //obj.Meisyou690 = MainWindow.a_meisyou[6, 9, 0];
            //obj.Meisyou691 = MainWindow.a_meisyou[6, 9, 1];
            //obj.Meisyou692 = MainWindow.a_meisyou[6, 9, 2];
            //obj.Meisyou693 = MainWindow.a_meisyou[6, 9, 3];
            //obj.Meisyou694 = MainWindow.a_meisyou[6, 9, 4];
            //obj.Meisyou695 = MainWindow.a_meisyou[6, 9, 5];
            //obj.Meisyou696 = MainWindow.a_meisyou[6, 9, 6];
            //obj.Meisyou697 = MainWindow.a_meisyou[6, 9, 7];
            //obj.Meisyou698 = MainWindow.a_meisyou[6, 9, 8];
            //obj.Meisyou699 = MainWindow.a_meisyou[6, 9, 9];
            ////7-Stream11
            //obj.Meisyou6A0 = MainWindow.a_meisyou[6, 10, 0];
            //obj.Meisyou6A1 = MainWindow.a_meisyou[6, 10, 1];
            //obj.Meisyou6A2 = MainWindow.a_meisyou[6, 10, 2];
            //obj.Meisyou6A3 = MainWindow.a_meisyou[6, 10, 3];
            //obj.Meisyou6A4 = MainWindow.a_meisyou[6, 10, 4];
            //obj.Meisyou6A5 = MainWindow.a_meisyou[6, 10, 5];
            //obj.Meisyou6A6 = MainWindow.a_meisyou[6, 10, 6];
            //obj.Meisyou6A7 = MainWindow.a_meisyou[6, 10, 7];
            //obj.Meisyou6A8 = MainWindow.a_meisyou[6, 10, 8];
            //obj.Meisyou6A9 = MainWindow.a_meisyou[6, 10, 9];

            ////品種8
            ////8-Stream1
            //obj.Meisyou700 = MainWindow.a_meisyou[7, 0, 0];
            //obj.Meisyou701 = MainWindow.a_meisyou[7, 0, 1];
            //obj.Meisyou702 = MainWindow.a_meisyou[7, 0, 2];
            //obj.Meisyou703 = MainWindow.a_meisyou[7, 0, 3];
            //obj.Meisyou704 = MainWindow.a_meisyou[7, 0, 4];
            //obj.Meisyou705 = MainWindow.a_meisyou[7, 0, 5];
            //obj.Meisyou706 = MainWindow.a_meisyou[7, 0, 6];
            //obj.Meisyou707 = MainWindow.a_meisyou[7, 0, 7];
            //obj.Meisyou708 = MainWindow.a_meisyou[7, 0, 8];
            //obj.Meisyou709 = MainWindow.a_meisyou[7, 0, 9];
            ////8-Stream2
            //obj.Meisyou710 = MainWindow.a_meisyou[7, 1, 0];
            //obj.Meisyou711 = MainWindow.a_meisyou[7, 1, 1];
            //obj.Meisyou712 = MainWindow.a_meisyou[7, 1, 2];
            //obj.Meisyou713 = MainWindow.a_meisyou[7, 1, 3];
            //obj.Meisyou714 = MainWindow.a_meisyou[7, 1, 4];
            //obj.Meisyou715 = MainWindow.a_meisyou[7, 1, 5];
            //obj.Meisyou716 = MainWindow.a_meisyou[7, 1, 6];
            //obj.Meisyou717 = MainWindow.a_meisyou[7, 1, 7];
            //obj.Meisyou718 = MainWindow.a_meisyou[7, 1, 8];
            //obj.Meisyou719 = MainWindow.a_meisyou[7, 1, 9];
            ////8-Stream3
            //obj.Meisyou720 = MainWindow.a_meisyou[7, 2, 0];
            //obj.Meisyou721 = MainWindow.a_meisyou[7, 2, 1];
            //obj.Meisyou722 = MainWindow.a_meisyou[7, 2, 2];
            //obj.Meisyou723 = MainWindow.a_meisyou[7, 2, 3];
            //obj.Meisyou724 = MainWindow.a_meisyou[7, 2, 4];
            //obj.Meisyou725 = MainWindow.a_meisyou[7, 2, 5];
            //obj.Meisyou726 = MainWindow.a_meisyou[7, 2, 6];
            //obj.Meisyou727 = MainWindow.a_meisyou[7, 2, 7];
            //obj.Meisyou728 = MainWindow.a_meisyou[7, 2, 8];
            //obj.Meisyou729 = MainWindow.a_meisyou[7, 2, 9];
            ////8-Stream4
            //obj.Meisyou730 = MainWindow.a_meisyou[7, 3, 0];
            //obj.Meisyou731 = MainWindow.a_meisyou[7, 3, 1];
            //obj.Meisyou732 = MainWindow.a_meisyou[7, 3, 2];
            //obj.Meisyou733 = MainWindow.a_meisyou[7, 3, 3];
            //obj.Meisyou734 = MainWindow.a_meisyou[7, 3, 4];
            //obj.Meisyou735 = MainWindow.a_meisyou[7, 3, 5];
            //obj.Meisyou736 = MainWindow.a_meisyou[7, 3, 6];
            //obj.Meisyou737 = MainWindow.a_meisyou[7, 3, 7];
            //obj.Meisyou738 = MainWindow.a_meisyou[7, 3, 8];
            //obj.Meisyou739 = MainWindow.a_meisyou[7, 3, 9];
            ////8-Stream5
            //obj.Meisyou740 = MainWindow.a_meisyou[7, 4, 0];
            //obj.Meisyou741 = MainWindow.a_meisyou[7, 4, 1];
            //obj.Meisyou742 = MainWindow.a_meisyou[7, 4, 2];
            //obj.Meisyou743 = MainWindow.a_meisyou[7, 4, 3];
            //obj.Meisyou744 = MainWindow.a_meisyou[7, 4, 4];
            //obj.Meisyou745 = MainWindow.a_meisyou[7, 4, 5];
            //obj.Meisyou746 = MainWindow.a_meisyou[7, 4, 6];
            //obj.Meisyou747 = MainWindow.a_meisyou[7, 4, 7];
            //obj.Meisyou748 = MainWindow.a_meisyou[7, 4, 8];
            //obj.Meisyou749 = MainWindow.a_meisyou[7, 4, 9];
            ////8-Stream6
            //obj.Meisyou750 = MainWindow.a_meisyou[7, 5, 0];
            //obj.Meisyou751 = MainWindow.a_meisyou[7, 5, 1];
            //obj.Meisyou752 = MainWindow.a_meisyou[7, 5, 2];
            //obj.Meisyou753 = MainWindow.a_meisyou[7, 5, 3];
            //obj.Meisyou754 = MainWindow.a_meisyou[7, 5, 4];
            //obj.Meisyou755 = MainWindow.a_meisyou[7, 5, 5];
            //obj.Meisyou756 = MainWindow.a_meisyou[7, 5, 6];
            //obj.Meisyou757 = MainWindow.a_meisyou[7, 5, 7];
            //obj.Meisyou758 = MainWindow.a_meisyou[7, 5, 8];
            //obj.Meisyou759 = MainWindow.a_meisyou[7, 5, 9];
            ////8-Stream7
            //obj.Meisyou760 = MainWindow.a_meisyou[7, 6, 0];
            //obj.Meisyou761 = MainWindow.a_meisyou[7, 6, 1];
            //obj.Meisyou762 = MainWindow.a_meisyou[7, 6, 2];
            //obj.Meisyou763 = MainWindow.a_meisyou[7, 6, 3];
            //obj.Meisyou764 = MainWindow.a_meisyou[7, 6, 4];
            //obj.Meisyou765 = MainWindow.a_meisyou[7, 6, 5];
            //obj.Meisyou766 = MainWindow.a_meisyou[7, 6, 6];
            //obj.Meisyou767 = MainWindow.a_meisyou[7, 6, 7];
            //obj.Meisyou768 = MainWindow.a_meisyou[7, 6, 8];
            //obj.Meisyou769 = MainWindow.a_meisyou[7, 6, 9];
            ////8-Stream8
            //obj.Meisyou770 = MainWindow.a_meisyou[7, 7, 0];
            //obj.Meisyou771 = MainWindow.a_meisyou[7, 7, 1];
            //obj.Meisyou772 = MainWindow.a_meisyou[7, 7, 2];
            //obj.Meisyou773 = MainWindow.a_meisyou[7, 7, 3];
            //obj.Meisyou774 = MainWindow.a_meisyou[7, 7, 4];
            //obj.Meisyou775 = MainWindow.a_meisyou[7, 7, 5];
            //obj.Meisyou776 = MainWindow.a_meisyou[7, 7, 6];
            //obj.Meisyou777 = MainWindow.a_meisyou[7, 7, 7];
            //obj.Meisyou778 = MainWindow.a_meisyou[7, 7, 8];
            //obj.Meisyou779 = MainWindow.a_meisyou[7, 7, 9];
            ////8-Stream9
            //obj.Meisyou780 = MainWindow.a_meisyou[7, 8, 0];
            //obj.Meisyou781 = MainWindow.a_meisyou[7, 8, 1];
            //obj.Meisyou782 = MainWindow.a_meisyou[7, 8, 2];
            //obj.Meisyou783 = MainWindow.a_meisyou[7, 8, 3];
            //obj.Meisyou784 = MainWindow.a_meisyou[7, 8, 4];
            //obj.Meisyou785 = MainWindow.a_meisyou[7, 8, 5];
            //obj.Meisyou786 = MainWindow.a_meisyou[7, 8, 6];
            //obj.Meisyou787 = MainWindow.a_meisyou[7, 8, 7];
            //obj.Meisyou788 = MainWindow.a_meisyou[7, 8, 8];
            //obj.Meisyou789 = MainWindow.a_meisyou[7, 8, 9];
            ////8-Stream10
            //obj.Meisyou790 = MainWindow.a_meisyou[7, 9, 0];
            //obj.Meisyou791 = MainWindow.a_meisyou[7, 9, 1];
            //obj.Meisyou792 = MainWindow.a_meisyou[7, 9, 2];
            //obj.Meisyou793 = MainWindow.a_meisyou[7, 9, 3];
            //obj.Meisyou794 = MainWindow.a_meisyou[7, 9, 4];
            //obj.Meisyou795 = MainWindow.a_meisyou[7, 9, 5];
            //obj.Meisyou796 = MainWindow.a_meisyou[7, 9, 6];
            //obj.Meisyou797 = MainWindow.a_meisyou[7, 9, 7];
            //obj.Meisyou798 = MainWindow.a_meisyou[7, 9, 8];
            //obj.Meisyou799 = MainWindow.a_meisyou[7, 9, 9];
            ////8-Stream11
            //obj.Meisyou7A0 = MainWindow.a_meisyou[7, 10, 0];
            //obj.Meisyou7A1 = MainWindow.a_meisyou[7, 10, 1];
            //obj.Meisyou7A2 = MainWindow.a_meisyou[7, 10, 2];
            //obj.Meisyou7A3 = MainWindow.a_meisyou[7, 10, 3];
            //obj.Meisyou7A4 = MainWindow.a_meisyou[7, 10, 4];
            //obj.Meisyou7A5 = MainWindow.a_meisyou[7, 10, 5];
            //obj.Meisyou7A6 = MainWindow.a_meisyou[7, 10, 6];
            //obj.Meisyou7A7 = MainWindow.a_meisyou[7, 10, 7];
            //obj.Meisyou7A8 = MainWindow.a_meisyou[7, 10, 8];
            //obj.Meisyou7A9 = MainWindow.a_meisyou[7, 10, 9];

            ////品種9
            ////9-Stream1
            //obj.Meisyou800 = MainWindow.a_meisyou[8, 0, 0];
            //obj.Meisyou801 = MainWindow.a_meisyou[8, 0, 1];
            //obj.Meisyou802 = MainWindow.a_meisyou[8, 0, 2];
            //obj.Meisyou803 = MainWindow.a_meisyou[8, 0, 3];
            //obj.Meisyou804 = MainWindow.a_meisyou[8, 0, 4];
            //obj.Meisyou805 = MainWindow.a_meisyou[8, 0, 5];
            //obj.Meisyou806 = MainWindow.a_meisyou[8, 0, 6];
            //obj.Meisyou807 = MainWindow.a_meisyou[8, 0, 7];
            //obj.Meisyou808 = MainWindow.a_meisyou[8, 0, 8];
            //obj.Meisyou809 = MainWindow.a_meisyou[8, 0, 9];
            ////9-Stream2
            //obj.Meisyou810 = MainWindow.a_meisyou[8, 1, 0];
            //obj.Meisyou811 = MainWindow.a_meisyou[8, 1, 1];
            //obj.Meisyou812 = MainWindow.a_meisyou[8, 1, 2];
            //obj.Meisyou813 = MainWindow.a_meisyou[8, 1, 3];
            //obj.Meisyou814 = MainWindow.a_meisyou[8, 1, 4];
            //obj.Meisyou815 = MainWindow.a_meisyou[8, 1, 5];
            //obj.Meisyou816 = MainWindow.a_meisyou[8, 1, 6];
            //obj.Meisyou817 = MainWindow.a_meisyou[8, 1, 7];
            //obj.Meisyou818 = MainWindow.a_meisyou[8, 1, 8];
            //obj.Meisyou819 = MainWindow.a_meisyou[8, 1, 9];
            ////9-Stream3
            //obj.Meisyou820 = MainWindow.a_meisyou[8, 2, 0];
            //obj.Meisyou821 = MainWindow.a_meisyou[8, 2, 1];
            //obj.Meisyou822 = MainWindow.a_meisyou[8, 2, 2];
            //obj.Meisyou823 = MainWindow.a_meisyou[8, 2, 3];
            //obj.Meisyou824 = MainWindow.a_meisyou[8, 2, 4];
            //obj.Meisyou825 = MainWindow.a_meisyou[8, 2, 5];
            //obj.Meisyou826 = MainWindow.a_meisyou[8, 2, 6];
            //obj.Meisyou827 = MainWindow.a_meisyou[8, 2, 7];
            //obj.Meisyou828 = MainWindow.a_meisyou[8, 2, 8];
            //obj.Meisyou829 = MainWindow.a_meisyou[8, 2, 9];
            ////9-Stream4
            //obj.Meisyou830 = MainWindow.a_meisyou[8, 3, 0];
            //obj.Meisyou831 = MainWindow.a_meisyou[8, 3, 1];
            //obj.Meisyou832 = MainWindow.a_meisyou[8, 3, 2];
            //obj.Meisyou833 = MainWindow.a_meisyou[8, 3, 3];
            //obj.Meisyou834 = MainWindow.a_meisyou[8, 3, 4];
            //obj.Meisyou835 = MainWindow.a_meisyou[8, 3, 5];
            //obj.Meisyou836 = MainWindow.a_meisyou[8, 3, 6];
            //obj.Meisyou837 = MainWindow.a_meisyou[8, 3, 7];
            //obj.Meisyou838 = MainWindow.a_meisyou[8, 3, 8];
            //obj.Meisyou839 = MainWindow.a_meisyou[8, 3, 9];
            ////9-Stream5
            //obj.Meisyou840 = MainWindow.a_meisyou[8, 4, 0];
            //obj.Meisyou841 = MainWindow.a_meisyou[8, 4, 1];
            //obj.Meisyou842 = MainWindow.a_meisyou[8, 4, 2];
            //obj.Meisyou843 = MainWindow.a_meisyou[8, 4, 3];
            //obj.Meisyou844 = MainWindow.a_meisyou[8, 4, 4];
            //obj.Meisyou845 = MainWindow.a_meisyou[8, 4, 5];
            //obj.Meisyou846 = MainWindow.a_meisyou[8, 4, 6];
            //obj.Meisyou847 = MainWindow.a_meisyou[8, 4, 7];
            //obj.Meisyou848 = MainWindow.a_meisyou[8, 4, 8];
            //obj.Meisyou849 = MainWindow.a_meisyou[8, 4, 9];
            ////9-Stream6
            //obj.Meisyou850 = MainWindow.a_meisyou[8, 5, 0];
            //obj.Meisyou851 = MainWindow.a_meisyou[8, 5, 1];
            //obj.Meisyou852 = MainWindow.a_meisyou[8, 5, 2];
            //obj.Meisyou853 = MainWindow.a_meisyou[8, 5, 3];
            //obj.Meisyou854 = MainWindow.a_meisyou[8, 5, 4];
            //obj.Meisyou855 = MainWindow.a_meisyou[8, 5, 5];
            //obj.Meisyou856 = MainWindow.a_meisyou[8, 5, 6];
            //obj.Meisyou857 = MainWindow.a_meisyou[8, 5, 7];
            //obj.Meisyou858 = MainWindow.a_meisyou[8, 5, 8];
            //obj.Meisyou859 = MainWindow.a_meisyou[8, 5, 9];
            ////9-Stream7
            //obj.Meisyou860 = MainWindow.a_meisyou[8, 6, 0];
            //obj.Meisyou861 = MainWindow.a_meisyou[8, 6, 1];
            //obj.Meisyou862 = MainWindow.a_meisyou[8, 6, 2];
            //obj.Meisyou863 = MainWindow.a_meisyou[8, 6, 3];
            //obj.Meisyou864 = MainWindow.a_meisyou[8, 6, 4];
            //obj.Meisyou865 = MainWindow.a_meisyou[8, 6, 5];
            //obj.Meisyou866 = MainWindow.a_meisyou[8, 6, 6];
            //obj.Meisyou867 = MainWindow.a_meisyou[8, 6, 7];
            //obj.Meisyou868 = MainWindow.a_meisyou[8, 6, 8];
            //obj.Meisyou869 = MainWindow.a_meisyou[8, 6, 9];
            ////9-Stream8
            //obj.Meisyou870 = MainWindow.a_meisyou[8, 7, 0];
            //obj.Meisyou871 = MainWindow.a_meisyou[8, 7, 1];
            //obj.Meisyou872 = MainWindow.a_meisyou[8, 7, 2];
            //obj.Meisyou873 = MainWindow.a_meisyou[8, 7, 3];
            //obj.Meisyou874 = MainWindow.a_meisyou[8, 7, 4];
            //obj.Meisyou875 = MainWindow.a_meisyou[8, 7, 5];
            //obj.Meisyou876 = MainWindow.a_meisyou[8, 7, 6];
            //obj.Meisyou877 = MainWindow.a_meisyou[8, 7, 7];
            //obj.Meisyou878 = MainWindow.a_meisyou[8, 7, 8];
            //obj.Meisyou879 = MainWindow.a_meisyou[8, 7, 9];
            ////9-Stream9
            //obj.Meisyou880 = MainWindow.a_meisyou[8, 8, 0];
            //obj.Meisyou881 = MainWindow.a_meisyou[8, 8, 1];
            //obj.Meisyou882 = MainWindow.a_meisyou[8, 8, 2];
            //obj.Meisyou883 = MainWindow.a_meisyou[8, 8, 3];
            //obj.Meisyou884 = MainWindow.a_meisyou[8, 8, 4];
            //obj.Meisyou885 = MainWindow.a_meisyou[8, 8, 5];
            //obj.Meisyou886 = MainWindow.a_meisyou[8, 8, 6];
            //obj.Meisyou887 = MainWindow.a_meisyou[8, 8, 7];
            //obj.Meisyou888 = MainWindow.a_meisyou[8, 8, 8];
            //obj.Meisyou889 = MainWindow.a_meisyou[8, 8, 9];
            ////9-Stream10
            //obj.Meisyou890 = MainWindow.a_meisyou[8, 9, 0];
            //obj.Meisyou891 = MainWindow.a_meisyou[8, 9, 1];
            //obj.Meisyou892 = MainWindow.a_meisyou[8, 9, 2];
            //obj.Meisyou893 = MainWindow.a_meisyou[8, 9, 3];
            //obj.Meisyou894 = MainWindow.a_meisyou[8, 9, 4];
            //obj.Meisyou895 = MainWindow.a_meisyou[8, 9, 5];
            //obj.Meisyou896 = MainWindow.a_meisyou[8, 9, 6];
            //obj.Meisyou897 = MainWindow.a_meisyou[8, 9, 7];
            //obj.Meisyou898 = MainWindow.a_meisyou[8, 9, 8];
            //obj.Meisyou899 = MainWindow.a_meisyou[8, 9, 9];
            ////9-Stream11
            //obj.Meisyou8A0 = MainWindow.a_meisyou[8, 10, 0];
            //obj.Meisyou8A1 = MainWindow.a_meisyou[8, 10, 1];
            //obj.Meisyou8A2 = MainWindow.a_meisyou[8, 10, 2];
            //obj.Meisyou8A3 = MainWindow.a_meisyou[8, 10, 3];
            //obj.Meisyou8A4 = MainWindow.a_meisyou[8, 10, 4];
            //obj.Meisyou8A5 = MainWindow.a_meisyou[8, 10, 5];
            //obj.Meisyou8A6 = MainWindow.a_meisyou[8, 10, 6];
            //obj.Meisyou8A7 = MainWindow.a_meisyou[8, 10, 7];
            //obj.Meisyou8A8 = MainWindow.a_meisyou[8, 10, 8];
            //obj.Meisyou8A9 = MainWindow.a_meisyou[8, 10, 9];

            ////品種10
            ////10-Stream1
            //obj.Meisyou900 = MainWindow.a_meisyou[9, 0, 0];
            //obj.Meisyou901 = MainWindow.a_meisyou[9, 0, 1];
            //obj.Meisyou902 = MainWindow.a_meisyou[9, 0, 2];
            //obj.Meisyou903 = MainWindow.a_meisyou[9, 0, 3];
            //obj.Meisyou904 = MainWindow.a_meisyou[9, 0, 4];
            //obj.Meisyou905 = MainWindow.a_meisyou[9, 0, 5];
            //obj.Meisyou906 = MainWindow.a_meisyou[9, 0, 6];
            //obj.Meisyou907 = MainWindow.a_meisyou[9, 0, 7];
            //obj.Meisyou908 = MainWindow.a_meisyou[9, 0, 8];
            //obj.Meisyou909 = MainWindow.a_meisyou[9, 0, 9];
            ////10-Stream2
            //obj.Meisyou910 = MainWindow.a_meisyou[9, 1, 0];
            //obj.Meisyou911 = MainWindow.a_meisyou[9, 1, 1];
            //obj.Meisyou912 = MainWindow.a_meisyou[9, 1, 2];
            //obj.Meisyou913 = MainWindow.a_meisyou[9, 1, 3];
            //obj.Meisyou914 = MainWindow.a_meisyou[9, 1, 4];
            //obj.Meisyou915 = MainWindow.a_meisyou[9, 1, 5];
            //obj.Meisyou916 = MainWindow.a_meisyou[9, 1, 6];
            //obj.Meisyou917 = MainWindow.a_meisyou[9, 1, 7];
            //obj.Meisyou918 = MainWindow.a_meisyou[9, 1, 8];
            //obj.Meisyou919 = MainWindow.a_meisyou[9, 1, 9];
            ////10-Stream3
            //obj.Meisyou920 = MainWindow.a_meisyou[9, 2, 0];
            //obj.Meisyou921 = MainWindow.a_meisyou[9, 2, 1];
            //obj.Meisyou922 = MainWindow.a_meisyou[9, 2, 2];
            //obj.Meisyou923 = MainWindow.a_meisyou[9, 2, 3];
            //obj.Meisyou924 = MainWindow.a_meisyou[9, 2, 4];
            //obj.Meisyou925 = MainWindow.a_meisyou[9, 2, 5];
            //obj.Meisyou926 = MainWindow.a_meisyou[9, 2, 6];
            //obj.Meisyou927 = MainWindow.a_meisyou[9, 2, 7];
            //obj.Meisyou928 = MainWindow.a_meisyou[9, 2, 8];
            //obj.Meisyou929 = MainWindow.a_meisyou[9, 2, 9];
            ////10-Stream4
            //obj.Meisyou930 = MainWindow.a_meisyou[9, 3, 0];
            //obj.Meisyou931 = MainWindow.a_meisyou[9, 3, 1];
            //obj.Meisyou932 = MainWindow.a_meisyou[9, 3, 2];
            //obj.Meisyou933 = MainWindow.a_meisyou[9, 3, 3];
            //obj.Meisyou934 = MainWindow.a_meisyou[9, 3, 4];
            //obj.Meisyou935 = MainWindow.a_meisyou[9, 3, 5];
            //obj.Meisyou936 = MainWindow.a_meisyou[9, 3, 6];
            //obj.Meisyou937 = MainWindow.a_meisyou[9, 3, 7];
            //obj.Meisyou938 = MainWindow.a_meisyou[9, 3, 8];
            //obj.Meisyou939 = MainWindow.a_meisyou[9, 3, 9];
            ////10-Stream5
            //obj.Meisyou940 = MainWindow.a_meisyou[9, 4, 0];
            //obj.Meisyou941 = MainWindow.a_meisyou[9, 4, 1];
            //obj.Meisyou942 = MainWindow.a_meisyou[9, 4, 2];
            //obj.Meisyou943 = MainWindow.a_meisyou[9, 4, 3];
            //obj.Meisyou944 = MainWindow.a_meisyou[9, 4, 4];
            //obj.Meisyou945 = MainWindow.a_meisyou[9, 4, 5];
            //obj.Meisyou946 = MainWindow.a_meisyou[9, 4, 6];
            //obj.Meisyou947 = MainWindow.a_meisyou[9, 4, 7];
            //obj.Meisyou948 = MainWindow.a_meisyou[9, 4, 8];
            //obj.Meisyou949 = MainWindow.a_meisyou[9, 4, 9];
            ////10-Stream6
            //obj.Meisyou950 = MainWindow.a_meisyou[9, 5, 0];
            //obj.Meisyou951 = MainWindow.a_meisyou[9, 5, 1];
            //obj.Meisyou952 = MainWindow.a_meisyou[9, 5, 2];
            //obj.Meisyou953 = MainWindow.a_meisyou[9, 5, 3];
            //obj.Meisyou954 = MainWindow.a_meisyou[9, 5, 4];
            //obj.Meisyou955 = MainWindow.a_meisyou[9, 5, 5];
            //obj.Meisyou956 = MainWindow.a_meisyou[9, 5, 6];
            //obj.Meisyou957 = MainWindow.a_meisyou[9, 5, 7];
            //obj.Meisyou958 = MainWindow.a_meisyou[9, 5, 8];
            //obj.Meisyou959 = MainWindow.a_meisyou[9, 5, 9];
            ////10-Stream7
            //obj.Meisyou960 = MainWindow.a_meisyou[9, 6, 0];
            //obj.Meisyou961 = MainWindow.a_meisyou[9, 6, 1];
            //obj.Meisyou962 = MainWindow.a_meisyou[9, 6, 2];
            //obj.Meisyou963 = MainWindow.a_meisyou[9, 6, 3];
            //obj.Meisyou964 = MainWindow.a_meisyou[9, 6, 4];
            //obj.Meisyou965 = MainWindow.a_meisyou[9, 6, 5];
            //obj.Meisyou966 = MainWindow.a_meisyou[9, 6, 6];
            //obj.Meisyou967 = MainWindow.a_meisyou[9, 6, 7];
            //obj.Meisyou968 = MainWindow.a_meisyou[9, 6, 8];
            //obj.Meisyou969 = MainWindow.a_meisyou[9, 6, 9];
            ////10-Stream8
            //obj.Meisyou970 = MainWindow.a_meisyou[9, 7, 0];
            //obj.Meisyou971 = MainWindow.a_meisyou[9, 7, 1];
            //obj.Meisyou972 = MainWindow.a_meisyou[9, 7, 2];
            //obj.Meisyou973 = MainWindow.a_meisyou[9, 7, 3];
            //obj.Meisyou974 = MainWindow.a_meisyou[9, 7, 4];
            //obj.Meisyou975 = MainWindow.a_meisyou[9, 7, 5];
            //obj.Meisyou976 = MainWindow.a_meisyou[9, 7, 6];
            //obj.Meisyou977 = MainWindow.a_meisyou[9, 7, 7];
            //obj.Meisyou978 = MainWindow.a_meisyou[9, 7, 8];
            //obj.Meisyou979 = MainWindow.a_meisyou[9, 7, 9];
            ////10-Stream9
            //obj.Meisyou980 = MainWindow.a_meisyou[9, 8, 0];
            //obj.Meisyou981 = MainWindow.a_meisyou[9, 8, 1];
            //obj.Meisyou982 = MainWindow.a_meisyou[9, 8, 2];
            //obj.Meisyou983 = MainWindow.a_meisyou[9, 8, 3];
            //obj.Meisyou984 = MainWindow.a_meisyou[9, 8, 4];
            //obj.Meisyou985 = MainWindow.a_meisyou[9, 8, 5];
            //obj.Meisyou986 = MainWindow.a_meisyou[9, 8, 6];
            //obj.Meisyou987 = MainWindow.a_meisyou[9, 8, 7];
            //obj.Meisyou988 = MainWindow.a_meisyou[9, 8, 8];
            //obj.Meisyou989 = MainWindow.a_meisyou[9, 8, 9];
            ////10-Stream10
            //obj.Meisyou990 = MainWindow.a_meisyou[9, 9, 0];
            //obj.Meisyou991 = MainWindow.a_meisyou[9, 9, 1];
            //obj.Meisyou992 = MainWindow.a_meisyou[9, 9, 2];
            //obj.Meisyou993 = MainWindow.a_meisyou[9, 9, 3];
            //obj.Meisyou994 = MainWindow.a_meisyou[9, 9, 4];
            //obj.Meisyou995 = MainWindow.a_meisyou[9, 9, 5];
            //obj.Meisyou996 = MainWindow.a_meisyou[9, 9, 6];
            //obj.Meisyou997 = MainWindow.a_meisyou[9, 9, 7];
            //obj.Meisyou998 = MainWindow.a_meisyou[9, 9, 8];
            //obj.Meisyou999 = MainWindow.a_meisyou[9, 9, 9];
            ////10-Stream11
            //obj.Meisyou9A0 = MainWindow.a_meisyou[9, 10, 0];
            //obj.Meisyou9A1 = MainWindow.a_meisyou[9, 10, 1];
            //obj.Meisyou9A2 = MainWindow.a_meisyou[9, 10, 2];
            //obj.Meisyou9A3 = MainWindow.a_meisyou[9, 10, 3];
            //obj.Meisyou9A4 = MainWindow.a_meisyou[9, 10, 4];
            //obj.Meisyou9A5 = MainWindow.a_meisyou[9, 10, 5];
            //obj.Meisyou9A6 = MainWindow.a_meisyou[9, 10, 6];
            //obj.Meisyou9A7 = MainWindow.a_meisyou[9, 10, 7];
            //obj.Meisyou9A8 = MainWindow.a_meisyou[9, 10, 8];
            //obj.Meisyou9A9 = MainWindow.a_meisyou[9, 10, 9];

            ////ADD_END :2021/11/14 kitayama 理由：検査名称を格納する処理を追加

            ////ADD_START :2021/11/27 kitayama 理由：Streamの名称を格納する処理を追加
            ////品種1
            //obj.S_meisyou00 = MainWindow.s_meisyou[0, 0];
            //obj.S_meisyou01 = MainWindow.s_meisyou[0, 1];
            //obj.S_meisyou02 = MainWindow.s_meisyou[0, 2];
            //obj.S_meisyou03 = MainWindow.s_meisyou[0, 3];
            //obj.S_meisyou04 = MainWindow.s_meisyou[0, 4];
            //obj.S_meisyou05 = MainWindow.s_meisyou[0, 5];
            //obj.S_meisyou06 = MainWindow.s_meisyou[0, 6];
            //obj.S_meisyou07 = MainWindow.s_meisyou[0, 7];
            //obj.S_meisyou08 = MainWindow.s_meisyou[0, 8];
            //obj.S_meisyou09 = MainWindow.s_meisyou[0, 9];

            ////品種2
            //obj.S_meisyou10 = MainWindow.s_meisyou[1, 0];
            //obj.S_meisyou11 = MainWindow.s_meisyou[1, 1];
            //obj.S_meisyou12 = MainWindow.s_meisyou[1, 2];
            //obj.S_meisyou13 = MainWindow.s_meisyou[1, 3];
            //obj.S_meisyou14 = MainWindow.s_meisyou[1, 4];
            //obj.S_meisyou15 = MainWindow.s_meisyou[1, 5];
            //obj.S_meisyou16 = MainWindow.s_meisyou[1, 6];
            //obj.S_meisyou17 = MainWindow.s_meisyou[1, 7];
            //obj.S_meisyou18 = MainWindow.s_meisyou[1, 8];
            //obj.S_meisyou19 = MainWindow.s_meisyou[1, 9];

            ////品種3
            //obj.S_meisyou20 = MainWindow.s_meisyou[2, 0];
            //obj.S_meisyou21 = MainWindow.s_meisyou[2, 1];
            //obj.S_meisyou22 = MainWindow.s_meisyou[2, 2];
            //obj.S_meisyou23 = MainWindow.s_meisyou[2, 3];
            //obj.S_meisyou24 = MainWindow.s_meisyou[2, 4];
            //obj.S_meisyou25 = MainWindow.s_meisyou[2, 5];
            //obj.S_meisyou26 = MainWindow.s_meisyou[2, 6];
            //obj.S_meisyou27 = MainWindow.s_meisyou[2, 7];
            //obj.S_meisyou28 = MainWindow.s_meisyou[2, 8];
            //obj.S_meisyou29 = MainWindow.s_meisyou[2, 9];

            ////品種4
            //obj.S_meisyou30 = MainWindow.s_meisyou[3, 0];
            //obj.S_meisyou31 = MainWindow.s_meisyou[3, 1];
            //obj.S_meisyou32 = MainWindow.s_meisyou[3, 2];
            //obj.S_meisyou33 = MainWindow.s_meisyou[3, 3];
            //obj.S_meisyou34 = MainWindow.s_meisyou[3, 4];
            //obj.S_meisyou35 = MainWindow.s_meisyou[3, 5];
            //obj.S_meisyou36 = MainWindow.s_meisyou[3, 6];
            //obj.S_meisyou37 = MainWindow.s_meisyou[3, 7];
            //obj.S_meisyou38 = MainWindow.s_meisyou[3, 8];
            //obj.S_meisyou39 = MainWindow.s_meisyou[3, 9];

            ////品種5
            //obj.S_meisyou40 = MainWindow.s_meisyou[4, 0];
            //obj.S_meisyou41 = MainWindow.s_meisyou[4, 1];
            //obj.S_meisyou42 = MainWindow.s_meisyou[4, 2];
            //obj.S_meisyou43 = MainWindow.s_meisyou[4, 3];
            //obj.S_meisyou44 = MainWindow.s_meisyou[4, 4];
            //obj.S_meisyou45 = MainWindow.s_meisyou[4, 5];
            //obj.S_meisyou46 = MainWindow.s_meisyou[4, 6];
            //obj.S_meisyou47 = MainWindow.s_meisyou[4, 7];
            //obj.S_meisyou48 = MainWindow.s_meisyou[4, 8];
            //obj.S_meisyou49 = MainWindow.s_meisyou[4, 9];

            ////品種6
            //obj.S_meisyou50 = MainWindow.s_meisyou[5, 0];
            //obj.S_meisyou51 = MainWindow.s_meisyou[5, 1];
            //obj.S_meisyou52 = MainWindow.s_meisyou[5, 2];
            //obj.S_meisyou53 = MainWindow.s_meisyou[5, 3];
            //obj.S_meisyou54 = MainWindow.s_meisyou[5, 4];
            //obj.S_meisyou55 = MainWindow.s_meisyou[5, 5];
            //obj.S_meisyou56 = MainWindow.s_meisyou[5, 6];
            //obj.S_meisyou57 = MainWindow.s_meisyou[5, 7];
            //obj.S_meisyou58 = MainWindow.s_meisyou[5, 8];
            //obj.S_meisyou59 = MainWindow.s_meisyou[5, 9];

            ////品種7
            //obj.S_meisyou60 = MainWindow.s_meisyou[6, 0];
            //obj.S_meisyou61 = MainWindow.s_meisyou[6, 1];
            //obj.S_meisyou62 = MainWindow.s_meisyou[6, 2];
            //obj.S_meisyou63 = MainWindow.s_meisyou[6, 3];
            //obj.S_meisyou64 = MainWindow.s_meisyou[6, 4];
            //obj.S_meisyou65 = MainWindow.s_meisyou[6, 5];
            //obj.S_meisyou66 = MainWindow.s_meisyou[6, 6];
            //obj.S_meisyou67 = MainWindow.s_meisyou[6, 7];
            //obj.S_meisyou68 = MainWindow.s_meisyou[6, 8];
            //obj.S_meisyou69 = MainWindow.s_meisyou[6, 9];

            ////品種8
            //obj.S_meisyou70 = MainWindow.s_meisyou[7, 0];
            //obj.S_meisyou71 = MainWindow.s_meisyou[7, 1];
            //obj.S_meisyou72 = MainWindow.s_meisyou[7, 2];
            //obj.S_meisyou73 = MainWindow.s_meisyou[7, 3];
            //obj.S_meisyou74 = MainWindow.s_meisyou[7, 4];
            //obj.S_meisyou75 = MainWindow.s_meisyou[7, 5];
            //obj.S_meisyou76 = MainWindow.s_meisyou[7, 6];
            //obj.S_meisyou77 = MainWindow.s_meisyou[7, 7];
            //obj.S_meisyou78 = MainWindow.s_meisyou[7, 8];
            //obj.S_meisyou79 = MainWindow.s_meisyou[7, 9];

            ////品種9
            //obj.S_meisyou80 = MainWindow.s_meisyou[8, 0];
            //obj.S_meisyou81 = MainWindow.s_meisyou[8, 1];
            //obj.S_meisyou82 = MainWindow.s_meisyou[8, 2];
            //obj.S_meisyou83 = MainWindow.s_meisyou[8, 3];
            //obj.S_meisyou84 = MainWindow.s_meisyou[8, 4];
            //obj.S_meisyou85 = MainWindow.s_meisyou[8, 5];
            //obj.S_meisyou86 = MainWindow.s_meisyou[8, 6];
            //obj.S_meisyou87 = MainWindow.s_meisyou[8, 7];
            //obj.S_meisyou88 = MainWindow.s_meisyou[8, 8];
            //obj.S_meisyou89 = MainWindow.s_meisyou[8, 9];

            ////品種10
            //obj.S_meisyou90 = MainWindow.s_meisyou[9, 0];
            //obj.S_meisyou91 = MainWindow.s_meisyou[9, 1];
            //obj.S_meisyou92 = MainWindow.s_meisyou[9, 2];
            //obj.S_meisyou93 = MainWindow.s_meisyou[9, 3];
            //obj.S_meisyou94 = MainWindow.s_meisyou[9, 4];
            //obj.S_meisyou95 = MainWindow.s_meisyou[9, 5];
            //obj.S_meisyou96 = MainWindow.s_meisyou[9, 6];
            //obj.S_meisyou97 = MainWindow.s_meisyou[9, 7];
            //obj.S_meisyou98 = MainWindow.s_meisyou[9, 8];
            //obj.S_meisyou99 = MainWindow.s_meisyou[9, 9];

            ////ADD_END :2021/11/27 kitayama 理由：Streamの名称を格納する処理を追加
            /////DELETE_END :2021/12/19 kitayama 理由：名称は使用しないので削除

            //DELETE_START :2021/11/23 kitayama 理由：複数Streamに対応するため削除
            ////ADD_START :2021/11/14 kitayama 理由：閾値の上限下限を格納する配列を追加
            //obj.dThreshold_u00 = MainWindow.dThreshold3[0, 0, 0];
            //obj.dThreshold_u01 = MainWindow.dThreshold3[0, 0, 1];
            //obj.dThreshold_u02 = MainWindow.dThreshold3[0, 0, 2];
            //obj.dThreshold_u03 = MainWindow.dThreshold3[0, 0, 3];
            //obj.dThreshold_u04 = MainWindow.dThreshold3[0, 0, 4];
            //obj.dThreshold_u05 = MainWindow.dThreshold3[0, 0, 5];
            //obj.dThreshold_u06 = MainWindow.dThreshold3[0, 0, 6];
            //obj.dThreshold_u07 = MainWindow.dThreshold3[0, 0, 7];
            //obj.dThreshold_u08 = MainWindow.dThreshold3[0, 0, 8];
            //obj.dThreshold_u09 = MainWindow.dThreshold3[0, 0, 9];
            //obj.dThreshold_u10 = MainWindow.dThreshold3[0, 1, 0];
            //obj.dThreshold_u11 = MainWindow.dThreshold3[0, 1, 1];
            //obj.dThreshold_u12 = MainWindow.dThreshold3[0, 1, 2];
            //obj.dThreshold_u13 = MainWindow.dThreshold3[0, 1, 3];
            //obj.dThreshold_u14 = MainWindow.dThreshold3[0, 1, 4];
            //obj.dThreshold_u15 = MainWindow.dThreshold3[0, 1, 5];
            //obj.dThreshold_u16 = MainWindow.dThreshold3[0, 1, 6];
            //obj.dThreshold_u17 = MainWindow.dThreshold3[0, 1, 7];
            //obj.dThreshold_u18 = MainWindow.dThreshold3[0, 1, 8];
            //obj.dThreshold_u19 = MainWindow.dThreshold3[0, 1, 9];
            //obj.dThreshold_u20 = MainWindow.dThreshold3[0, 2, 0];
            //obj.dThreshold_u21 = MainWindow.dThreshold3[0, 2, 1];
            //obj.dThreshold_u22 = MainWindow.dThreshold3[0, 2, 2];
            //obj.dThreshold_u23 = MainWindow.dThreshold3[0, 2, 3];
            //obj.dThreshold_u24 = MainWindow.dThreshold3[0, 2, 4];
            //obj.dThreshold_u25 = MainWindow.dThreshold3[0, 2, 5];
            //obj.dThreshold_u26 = MainWindow.dThreshold3[0, 2, 6];
            //obj.dThreshold_u27 = MainWindow.dThreshold3[0, 2, 7];
            //obj.dThreshold_u28 = MainWindow.dThreshold3[0, 2, 8];
            //obj.dThreshold_u29 = MainWindow.dThreshold3[0, 2, 9];
            //obj.dThreshold_u30 = MainWindow.dThreshold3[0, 3, 0];
            //obj.dThreshold_u31 = MainWindow.dThreshold3[0, 3, 1];
            //obj.dThreshold_u32 = MainWindow.dThreshold3[0, 3, 2];
            //obj.dThreshold_u33 = MainWindow.dThreshold3[0, 3, 3];
            //obj.dThreshold_u34 = MainWindow.dThreshold3[0, 3, 4];
            //obj.dThreshold_u35 = MainWindow.dThreshold3[0, 3, 5];
            //obj.dThreshold_u36 = MainWindow.dThreshold3[0, 3, 6];
            //obj.dThreshold_u37 = MainWindow.dThreshold3[0, 3, 7];
            //obj.dThreshold_u38 = MainWindow.dThreshold3[0, 3, 8];
            //obj.dThreshold_u39 = MainWindow.dThreshold3[0, 3, 9];
            //obj.dThreshold_u40 = MainWindow.dThreshold3[0, 4, 0];
            //obj.dThreshold_u41 = MainWindow.dThreshold3[0, 4, 1];
            //obj.dThreshold_u42 = MainWindow.dThreshold3[0, 4, 2];
            //obj.dThreshold_u43 = MainWindow.dThreshold3[0, 4, 3];
            //obj.dThreshold_u44 = MainWindow.dThreshold3[0, 4, 4];
            //obj.dThreshold_u45 = MainWindow.dThreshold3[0, 4, 5];
            //obj.dThreshold_u46 = MainWindow.dThreshold3[0, 4, 6];
            //obj.dThreshold_u47 = MainWindow.dThreshold3[0, 4, 7];
            //obj.dThreshold_u48 = MainWindow.dThreshold3[0, 4, 8];
            //obj.dThreshold_u49 = MainWindow.dThreshold3[0, 4, 9];
            //obj.dThreshold_u50 = MainWindow.dThreshold3[0, 5, 0];
            //obj.dThreshold_u51 = MainWindow.dThreshold3[0, 5, 1];
            //obj.dThreshold_u52 = MainWindow.dThreshold3[0, 5, 2];
            //obj.dThreshold_u53 = MainWindow.dThreshold3[0, 5, 3];
            //obj.dThreshold_u54 = MainWindow.dThreshold3[0, 5, 4];
            //obj.dThreshold_u55 = MainWindow.dThreshold3[0, 5, 5];
            //obj.dThreshold_u56 = MainWindow.dThreshold3[0, 5, 6];
            //obj.dThreshold_u57 = MainWindow.dThreshold3[0, 5, 7];
            //obj.dThreshold_u58 = MainWindow.dThreshold3[0, 5, 8];
            //obj.dThreshold_u59 = MainWindow.dThreshold3[0, 5, 9];
            //obj.dThreshold_u60 = MainWindow.dThreshold3[0, 6, 0];
            //obj.dThreshold_u61 = MainWindow.dThreshold3[0, 6, 1];
            //obj.dThreshold_u62 = MainWindow.dThreshold3[0, 6, 2];
            //obj.dThreshold_u63 = MainWindow.dThreshold3[0, 6, 3];
            //obj.dThreshold_u64 = MainWindow.dThreshold3[0, 6, 4];
            //obj.dThreshold_u65 = MainWindow.dThreshold3[0, 6, 5];
            //obj.dThreshold_u66 = MainWindow.dThreshold3[0, 6, 6];
            //obj.dThreshold_u67 = MainWindow.dThreshold3[0, 6, 7];
            //obj.dThreshold_u68 = MainWindow.dThreshold3[0, 6, 8];
            //obj.dThreshold_u69 = MainWindow.dThreshold3[0, 6, 9];
            //obj.dThreshold_u70 = MainWindow.dThreshold3[0, 7, 0];
            //obj.dThreshold_u71 = MainWindow.dThreshold3[0, 7, 1];
            //obj.dThreshold_u72 = MainWindow.dThreshold3[0, 7, 2];
            //obj.dThreshold_u73 = MainWindow.dThreshold3[0, 7, 3];
            //obj.dThreshold_u74 = MainWindow.dThreshold3[0, 7, 4];
            //obj.dThreshold_u75 = MainWindow.dThreshold3[0, 7, 5];
            //obj.dThreshold_u76 = MainWindow.dThreshold3[0, 7, 6];
            //obj.dThreshold_u77 = MainWindow.dThreshold3[0, 7, 7];
            //obj.dThreshold_u78 = MainWindow.dThreshold3[0, 7, 8];
            //obj.dThreshold_u79 = MainWindow.dThreshold3[0, 7, 9];
            //obj.dThreshold_u80 = MainWindow.dThreshold3[0, 8, 0];
            //obj.dThreshold_u81 = MainWindow.dThreshold3[0, 8, 1];
            //obj.dThreshold_u82 = MainWindow.dThreshold3[0, 8, 2];
            //obj.dThreshold_u83 = MainWindow.dThreshold3[0, 8, 3];
            //obj.dThreshold_u84 = MainWindow.dThreshold3[0, 8, 4];
            //obj.dThreshold_u85 = MainWindow.dThreshold3[0, 8, 5];
            //obj.dThreshold_u86 = MainWindow.dThreshold3[0, 8, 6];
            //obj.dThreshold_u87 = MainWindow.dThreshold3[0, 8, 7];
            //obj.dThreshold_u88 = MainWindow.dThreshold3[0, 8, 8];
            //obj.dThreshold_u89 = MainWindow.dThreshold3[0, 8, 9];
            //obj.dThreshold_u90 = MainWindow.dThreshold3[0, 9, 0];
            //obj.dThreshold_u91 = MainWindow.dThreshold3[0, 9, 1];
            //obj.dThreshold_u92 = MainWindow.dThreshold3[0, 9, 2];
            //obj.dThreshold_u93 = MainWindow.dThreshold3[0, 9, 3];
            //obj.dThreshold_u94 = MainWindow.dThreshold3[0, 9, 4];
            //obj.dThreshold_u95 = MainWindow.dThreshold3[0, 9, 5];
            //obj.dThreshold_u96 = MainWindow.dThreshold3[0, 9, 6];
            //obj.dThreshold_u97 = MainWindow.dThreshold3[0, 9, 7];
            //obj.dThreshold_u98 = MainWindow.dThreshold3[0, 9, 8];
            //obj.dThreshold_u99 = MainWindow.dThreshold3[0, 9, 9];

            //obj.dThreshold_l00 = MainWindow.dThreshold3[1, 0, 0];
            //obj.dThreshold_l01 = MainWindow.dThreshold3[1, 0, 1];
            //obj.dThreshold_l02 = MainWindow.dThreshold3[1, 0, 2];
            //obj.dThreshold_l03 = MainWindow.dThreshold3[1, 0, 3];
            //obj.dThreshold_l04 = MainWindow.dThreshold3[1, 0, 4];
            //obj.dThreshold_l05 = MainWindow.dThreshold3[1, 0, 5];
            //obj.dThreshold_l06 = MainWindow.dThreshold3[1, 0, 6];
            //obj.dThreshold_l07 = MainWindow.dThreshold3[1, 0, 7];
            //obj.dThreshold_l08 = MainWindow.dThreshold3[1, 0, 8];
            //obj.dThreshold_l09 = MainWindow.dThreshold3[1, 0, 9];
            //obj.dThreshold_l10 = MainWindow.dThreshold3[1, 1, 0];
            //obj.dThreshold_l11 = MainWindow.dThreshold3[1, 1, 1];
            //obj.dThreshold_l12 = MainWindow.dThreshold3[1, 1, 2];
            //obj.dThreshold_l13 = MainWindow.dThreshold3[1, 1, 3];
            //obj.dThreshold_l14 = MainWindow.dThreshold3[1, 1, 4];
            //obj.dThreshold_l15 = MainWindow.dThreshold3[1, 1, 5];
            //obj.dThreshold_l16 = MainWindow.dThreshold3[1, 1, 6];
            //obj.dThreshold_l17 = MainWindow.dThreshold3[1, 1, 7];
            //obj.dThreshold_l18 = MainWindow.dThreshold3[1, 1, 8];
            //obj.dThreshold_l19 = MainWindow.dThreshold3[1, 1, 9];
            //obj.dThreshold_l20 = MainWindow.dThreshold3[1, 2, 0];
            //obj.dThreshold_l21 = MainWindow.dThreshold3[1, 2, 1];
            //obj.dThreshold_l22 = MainWindow.dThreshold3[1, 2, 2];
            //obj.dThreshold_l23 = MainWindow.dThreshold3[1, 2, 3];
            //obj.dThreshold_l24 = MainWindow.dThreshold3[1, 2, 4];
            //obj.dThreshold_l25 = MainWindow.dThreshold3[1, 2, 5];
            //obj.dThreshold_l26 = MainWindow.dThreshold3[1, 2, 6];
            //obj.dThreshold_l27 = MainWindow.dThreshold3[1, 2, 7];
            //obj.dThreshold_l28 = MainWindow.dThreshold3[1, 2, 8];
            //obj.dThreshold_l29 = MainWindow.dThreshold3[1, 2, 9];
            //obj.dThreshold_l30 = MainWindow.dThreshold3[1, 3, 0];
            //obj.dThreshold_l31 = MainWindow.dThreshold3[1, 3, 1];
            //obj.dThreshold_l32 = MainWindow.dThreshold3[1, 3, 2];
            //obj.dThreshold_l33 = MainWindow.dThreshold3[1, 3, 3];
            //obj.dThreshold_l34 = MainWindow.dThreshold3[1, 3, 4];
            //obj.dThreshold_l35 = MainWindow.dThreshold3[1, 3, 5];
            //obj.dThreshold_l36 = MainWindow.dThreshold3[1, 3, 6];
            //obj.dThreshold_l37 = MainWindow.dThreshold3[1, 3, 7];
            //obj.dThreshold_l38 = MainWindow.dThreshold3[1, 3, 8];
            //obj.dThreshold_l39 = MainWindow.dThreshold3[1, 3, 9];
            //obj.dThreshold_l40 = MainWindow.dThreshold3[1, 4, 0];
            //obj.dThreshold_l41 = MainWindow.dThreshold3[1, 4, 1];
            //obj.dThreshold_l42 = MainWindow.dThreshold3[1, 4, 2];
            //obj.dThreshold_l43 = MainWindow.dThreshold3[1, 4, 3];
            //obj.dThreshold_l44 = MainWindow.dThreshold3[1, 4, 4];
            //obj.dThreshold_l45 = MainWindow.dThreshold3[1, 4, 5];
            //obj.dThreshold_l46 = MainWindow.dThreshold3[1, 4, 6];
            //obj.dThreshold_l47 = MainWindow.dThreshold3[1, 4, 7];
            //obj.dThreshold_l48 = MainWindow.dThreshold3[1, 4, 8];
            //obj.dThreshold_l49 = MainWindow.dThreshold3[1, 4, 9];
            //obj.dThreshold_l50 = MainWindow.dThreshold3[1, 5, 0];
            //obj.dThreshold_l51 = MainWindow.dThreshold3[1, 5, 1];
            //obj.dThreshold_l52 = MainWindow.dThreshold3[1, 5, 2];
            //obj.dThreshold_l53 = MainWindow.dThreshold3[1, 5, 3];
            //obj.dThreshold_l54 = MainWindow.dThreshold3[1, 5, 4];
            //obj.dThreshold_l55 = MainWindow.dThreshold3[1, 5, 5];
            //obj.dThreshold_l56 = MainWindow.dThreshold3[1, 5, 6];
            //obj.dThreshold_l57 = MainWindow.dThreshold3[1, 5, 7];
            //obj.dThreshold_l58 = MainWindow.dThreshold3[1, 5, 8];
            //obj.dThreshold_l59 = MainWindow.dThreshold3[1, 5, 9];
            //obj.dThreshold_l60 = MainWindow.dThreshold3[1, 6, 0];
            //obj.dThreshold_l61 = MainWindow.dThreshold3[1, 6, 1];
            //obj.dThreshold_l62 = MainWindow.dThreshold3[1, 6, 2];
            //obj.dThreshold_l63 = MainWindow.dThreshold3[1, 6, 3];
            //obj.dThreshold_l64 = MainWindow.dThreshold3[1, 6, 4];
            //obj.dThreshold_l65 = MainWindow.dThreshold3[1, 6, 5];
            //obj.dThreshold_l66 = MainWindow.dThreshold3[1, 6, 6];
            //obj.dThreshold_l67 = MainWindow.dThreshold3[1, 6, 7];
            //obj.dThreshold_l68 = MainWindow.dThreshold3[1, 6, 8];
            //obj.dThreshold_l69 = MainWindow.dThreshold3[1, 6, 9];
            //obj.dThreshold_l70 = MainWindow.dThreshold3[1, 7, 0];
            //obj.dThreshold_l71 = MainWindow.dThreshold3[1, 7, 1];
            //obj.dThreshold_l72 = MainWindow.dThreshold3[1, 7, 2];
            //obj.dThreshold_l73 = MainWindow.dThreshold3[1, 7, 3];
            //obj.dThreshold_l74 = MainWindow.dThreshold3[1, 7, 4];
            //obj.dThreshold_l75 = MainWindow.dThreshold3[1, 7, 5];
            //obj.dThreshold_l76 = MainWindow.dThreshold3[1, 7, 6];
            //obj.dThreshold_l77 = MainWindow.dThreshold3[1, 7, 7];
            //obj.dThreshold_l78 = MainWindow.dThreshold3[1, 7, 8];
            //obj.dThreshold_l79 = MainWindow.dThreshold3[1, 7, 9];
            //obj.dThreshold_l80 = MainWindow.dThreshold3[1, 8, 0];
            //obj.dThreshold_l81 = MainWindow.dThreshold3[1, 8, 1];
            //obj.dThreshold_l82 = MainWindow.dThreshold3[1, 8, 2];
            //obj.dThreshold_l83 = MainWindow.dThreshold3[1, 8, 3];
            //obj.dThreshold_l84 = MainWindow.dThreshold3[1, 8, 4];
            //obj.dThreshold_l85 = MainWindow.dThreshold3[1, 8, 5];
            //obj.dThreshold_l86 = MainWindow.dThreshold3[1, 8, 6];
            //obj.dThreshold_l87 = MainWindow.dThreshold3[1, 8, 7];
            //obj.dThreshold_l88 = MainWindow.dThreshold3[1, 8, 8];
            //obj.dThreshold_l89 = MainWindow.dThreshold3[1, 8, 9];
            //obj.dThreshold_l90 = MainWindow.dThreshold3[1, 9, 0];
            //obj.dThreshold_l91 = MainWindow.dThreshold3[1, 9, 1];
            //obj.dThreshold_l92 = MainWindow.dThreshold3[1, 9, 2];
            //obj.dThreshold_l93 = MainWindow.dThreshold3[1, 9, 3];
            //obj.dThreshold_l94 = MainWindow.dThreshold3[1, 9, 4];
            //obj.dThreshold_l95 = MainWindow.dThreshold3[1, 9, 5];
            //obj.dThreshold_l96 = MainWindow.dThreshold3[1, 9, 6];
            //obj.dThreshold_l97 = MainWindow.dThreshold3[1, 9, 7];
            //obj.dThreshold_l98 = MainWindow.dThreshold3[1, 9, 8];
            //obj.dThreshold_l99 = MainWindow.dThreshold3[1, 9, 9];
            ////ADD_END :2021/11/14 kitayama 理由：閾値の上限下限を格納する配列を追加
            //DELETE_END :2021/11/23 kitayama 理由：複数Steamに対応するため削除

            //DELETE_START :2021/11/14 kitayama 理由：閾値の上限下限を格納する配列に変更するので削除
            ////ADD_START :2021/11/7 kitayama 理由：閾値の形式を変更したものを追加
            //obj.dThreshold00 = MainWindow.dThreshold3[0, 0];
            //obj.dThreshold01 = MainWindow.dThreshold3[0, 1];
            //obj.dThreshold02 = MainWindow.dThreshold3[0, 2];
            //obj.dThreshold03 = MainWindow.dThreshold3[0, 3];
            //obj.dThreshold04 = MainWindow.dThreshold3[0, 4];
            //obj.dThreshold10 = MainWindow.dThreshold3[1, 0];
            //obj.dThreshold11 = MainWindow.dThreshold3[1, 1];
            //obj.dThreshold12 = MainWindow.dThreshold3[1, 2];
            //obj.dThreshold13 = MainWindow.dThreshold3[1, 3];
            //obj.dThreshold14 = MainWindow.dThreshold3[1, 4];
            //obj.dThreshold20 = MainWindow.dThreshold3[2, 0];
            //obj.dThreshold21 = MainWindow.dThreshold3[2, 1];
            //obj.dThreshold22 = MainWindow.dThreshold3[2, 2];
            //obj.dThreshold23 = MainWindow.dThreshold3[2, 3];
            //obj.dThreshold24 = MainWindow.dThreshold3[2, 4];
            //obj.dThreshold30 = MainWindow.dThreshold3[3, 0];
            //obj.dThreshold31 = MainWindow.dThreshold3[3, 1];
            //obj.dThreshold32 = MainWindow.dThreshold3[3, 2];
            //obj.dThreshold33 = MainWindow.dThreshold3[3, 3];
            //obj.dThreshold34 = MainWindow.dThreshold3[3, 4];
            //obj.dThreshold40 = MainWindow.dThreshold3[4, 0];
            //obj.dThreshold41 = MainWindow.dThreshold3[4, 1];
            //obj.dThreshold42 = MainWindow.dThreshold3[4, 2];
            //obj.dThreshold43 = MainWindow.dThreshold3[4, 3];
            //obj.dThreshold44 = MainWindow.dThreshold3[4, 4];
            //obj.dThreshold50 = MainWindow.dThreshold3[5, 0];
            //obj.dThreshold51 = MainWindow.dThreshold3[5, 1];
            //obj.dThreshold52 = MainWindow.dThreshold3[5, 2];
            //obj.dThreshold53 = MainWindow.dThreshold3[5, 3];
            //obj.dThreshold54 = MainWindow.dThreshold3[5, 4];
            //obj.dThreshold60 = MainWindow.dThreshold3[6, 0];
            //obj.dThreshold61 = MainWindow.dThreshold3[6, 1];
            //obj.dThreshold62 = MainWindow.dThreshold3[6, 2];
            //obj.dThreshold63 = MainWindow.dThreshold3[6, 3];
            //obj.dThreshold64 = MainWindow.dThreshold3[6, 4];
            //obj.dThreshold70 = MainWindow.dThreshold3[7, 0];
            //obj.dThreshold71 = MainWindow.dThreshold3[7, 1];
            //obj.dThreshold72 = MainWindow.dThreshold3[7, 2];
            //obj.dThreshold73 = MainWindow.dThreshold3[7, 3];
            //obj.dThreshold74 = MainWindow.dThreshold3[7, 4];
            //obj.dThreshold80 = MainWindow.dThreshold3[8, 0];
            //obj.dThreshold81 = MainWindow.dThreshold3[8, 1];
            //obj.dThreshold82 = MainWindow.dThreshold3[8, 2];
            //obj.dThreshold83 = MainWindow.dThreshold3[8, 3];
            //obj.dThreshold84 = MainWindow.dThreshold3[8, 4];
            //obj.dThreshold90 = MainWindow.dThreshold3[9, 0];
            //obj.dThreshold91 = MainWindow.dThreshold3[9, 1];
            //obj.dThreshold92 = MainWindow.dThreshold3[9, 2];
            //obj.dThreshold93 = MainWindow.dThreshold3[9, 3];
            //obj.dThreshold94 = MainWindow.dThreshold3[9, 4];
            ////ADD_END :2021/11/7 kitayama 理由：閾値の形式を変更したものを追加
            //DELETE_END :2021/11/14 kitayama 理由：閾値の上限下限を格納する配列に変更するので削除

            //ADD_START :2020/4/27 kitayama 理由：改造に合わせたしきい値の形式に変更する
            //dThreshold[品種,Stream,Analyze]の形式になっている
            //品種1
            //1-Stream1
            obj.dThreshold_u000 = MainWindow.dThreshold3[0, 0, 0, 0];
            obj.dThreshold_u001 = MainWindow.dThreshold3[0, 0, 0, 1];
            obj.dThreshold_u002 = MainWindow.dThreshold3[0, 0, 0, 2];
            obj.dThreshold_u003 = MainWindow.dThreshold3[0, 0, 0, 3];
            obj.dThreshold_u004 = MainWindow.dThreshold3[0, 0, 0, 4];
            obj.dThreshold_u005 = MainWindow.dThreshold3[0, 0, 0, 5];
            obj.dThreshold_u006 = MainWindow.dThreshold3[0, 0, 0, 6];
            obj.dThreshold_u007 = MainWindow.dThreshold3[0, 0, 0, 7];
            obj.dThreshold_u008 = MainWindow.dThreshold3[0, 0, 0, 8];
            obj.dThreshold_u009 = MainWindow.dThreshold3[0, 0, 0, 9];

            obj.dThreshold_l000 = MainWindow.dThreshold3[1, 0, 0, 0];
            obj.dThreshold_l001 = MainWindow.dThreshold3[1, 0, 0, 1];
            obj.dThreshold_l002 = MainWindow.dThreshold3[1, 0, 0, 2];
            obj.dThreshold_l003 = MainWindow.dThreshold3[1, 0, 0, 3];
            obj.dThreshold_l004 = MainWindow.dThreshold3[1, 0, 0, 4];
            obj.dThreshold_l005 = MainWindow.dThreshold3[1, 0, 0, 5];
            obj.dThreshold_l006 = MainWindow.dThreshold3[1, 0, 0, 6];
            obj.dThreshold_l007 = MainWindow.dThreshold3[1, 0, 0, 7];
            obj.dThreshold_l008 = MainWindow.dThreshold3[1, 0, 0, 8];
            obj.dThreshold_l009 = MainWindow.dThreshold3[1, 0, 0, 9];
            //1-Stream2
            obj.dThreshold_u010 = MainWindow.dThreshold3[0, 0, 1, 0];
            obj.dThreshold_u011 = MainWindow.dThreshold3[0, 0, 1, 1];
            obj.dThreshold_u012 = MainWindow.dThreshold3[0, 0, 1, 2];
            obj.dThreshold_u013 = MainWindow.dThreshold3[0, 0, 1, 3];
            obj.dThreshold_u014 = MainWindow.dThreshold3[0, 0, 1, 4];
            obj.dThreshold_u015 = MainWindow.dThreshold3[0, 0, 1, 5];
            obj.dThreshold_u016 = MainWindow.dThreshold3[0, 0, 1, 6];
            obj.dThreshold_u017 = MainWindow.dThreshold3[0, 0, 1, 7];
            obj.dThreshold_u018 = MainWindow.dThreshold3[0, 0, 1, 8];
            obj.dThreshold_u019 = MainWindow.dThreshold3[0, 0, 1, 9];

            obj.dThreshold_l010 = MainWindow.dThreshold3[1, 0, 1, 0];
            obj.dThreshold_l011 = MainWindow.dThreshold3[1, 0, 1, 1];
            obj.dThreshold_l012 = MainWindow.dThreshold3[1, 0, 1, 2];
            obj.dThreshold_l013 = MainWindow.dThreshold3[1, 0, 1, 3];
            obj.dThreshold_l014 = MainWindow.dThreshold3[1, 0, 1, 4];
            obj.dThreshold_l015 = MainWindow.dThreshold3[1, 0, 1, 5];
            obj.dThreshold_l016 = MainWindow.dThreshold3[1, 0, 1, 6];
            obj.dThreshold_l017 = MainWindow.dThreshold3[1, 0, 1, 7];
            obj.dThreshold_l018 = MainWindow.dThreshold3[1, 0, 1, 8];
            obj.dThreshold_l019 = MainWindow.dThreshold3[1, 0, 1, 9];
            //1-Stream3
            obj.dThreshold_u020 = MainWindow.dThreshold3[0, 0, 2, 0];
            obj.dThreshold_u021 = MainWindow.dThreshold3[0, 0, 2, 1];
            obj.dThreshold_u022 = MainWindow.dThreshold3[0, 0, 2, 2];
            obj.dThreshold_u023 = MainWindow.dThreshold3[0, 0, 2, 3];
            obj.dThreshold_u024 = MainWindow.dThreshold3[0, 0, 2, 4];
            obj.dThreshold_u025 = MainWindow.dThreshold3[0, 0, 2, 5];
            obj.dThreshold_u026 = MainWindow.dThreshold3[0, 0, 2, 6];
            obj.dThreshold_u027 = MainWindow.dThreshold3[0, 0, 2, 7];
            obj.dThreshold_u028 = MainWindow.dThreshold3[0, 0, 2, 8];
            obj.dThreshold_u029 = MainWindow.dThreshold3[0, 0, 2, 9];

            obj.dThreshold_l020 = MainWindow.dThreshold3[1, 0, 2, 0];
            obj.dThreshold_l021 = MainWindow.dThreshold3[1, 0, 2, 1];
            obj.dThreshold_l022 = MainWindow.dThreshold3[1, 0, 2, 2];
            obj.dThreshold_l023 = MainWindow.dThreshold3[1, 0, 2, 3];
            obj.dThreshold_l024 = MainWindow.dThreshold3[1, 0, 2, 4];
            obj.dThreshold_l025 = MainWindow.dThreshold3[1, 0, 2, 5];
            obj.dThreshold_l026 = MainWindow.dThreshold3[1, 0, 2, 6];
            obj.dThreshold_l027 = MainWindow.dThreshold3[1, 0, 2, 7];
            obj.dThreshold_l028 = MainWindow.dThreshold3[1, 0, 2, 8];
            obj.dThreshold_l029 = MainWindow.dThreshold3[1, 0, 2, 9];
            //1-Stream4
            obj.dThreshold_u030 = MainWindow.dThreshold3[0, 0, 3, 0];
            obj.dThreshold_u031 = MainWindow.dThreshold3[0, 0, 3, 1];
            obj.dThreshold_u032 = MainWindow.dThreshold3[0, 0, 3, 2];
            obj.dThreshold_u033 = MainWindow.dThreshold3[0, 0, 3, 3];
            obj.dThreshold_u034 = MainWindow.dThreshold3[0, 0, 3, 4];
            obj.dThreshold_u035 = MainWindow.dThreshold3[0, 0, 3, 5];
            obj.dThreshold_u036 = MainWindow.dThreshold3[0, 0, 3, 6];
            obj.dThreshold_u037 = MainWindow.dThreshold3[0, 0, 3, 7];
            obj.dThreshold_u038 = MainWindow.dThreshold3[0, 0, 3, 8];
            obj.dThreshold_u039 = MainWindow.dThreshold3[0, 0, 3, 9];

            obj.dThreshold_l030 = MainWindow.dThreshold3[1, 0, 3, 0];
            obj.dThreshold_l031 = MainWindow.dThreshold3[1, 0, 3, 1];
            obj.dThreshold_l032 = MainWindow.dThreshold3[1, 0, 3, 2];
            obj.dThreshold_l033 = MainWindow.dThreshold3[1, 0, 3, 3];
            obj.dThreshold_l034 = MainWindow.dThreshold3[1, 0, 3, 4];
            obj.dThreshold_l035 = MainWindow.dThreshold3[1, 0, 3, 5];
            obj.dThreshold_l036 = MainWindow.dThreshold3[1, 0, 3, 6];
            obj.dThreshold_l037 = MainWindow.dThreshold3[1, 0, 3, 7];
            obj.dThreshold_l038 = MainWindow.dThreshold3[1, 0, 3, 8];
            obj.dThreshold_l039 = MainWindow.dThreshold3[1, 0, 3, 9];
            //1-Stream5
            obj.dThreshold_u040 = MainWindow.dThreshold3[0, 0, 4, 0];
            obj.dThreshold_u041 = MainWindow.dThreshold3[0, 0, 4, 1];
            obj.dThreshold_u042 = MainWindow.dThreshold3[0, 0, 4, 2];
            obj.dThreshold_u043 = MainWindow.dThreshold3[0, 0, 4, 3];
            obj.dThreshold_u044 = MainWindow.dThreshold3[0, 0, 4, 4];
            obj.dThreshold_u045 = MainWindow.dThreshold3[0, 0, 4, 5];
            obj.dThreshold_u046 = MainWindow.dThreshold3[0, 0, 4, 6];
            obj.dThreshold_u047 = MainWindow.dThreshold3[0, 0, 4, 7];
            obj.dThreshold_u048 = MainWindow.dThreshold3[0, 0, 4, 8];
            obj.dThreshold_u049 = MainWindow.dThreshold3[0, 0, 4, 9];

            obj.dThreshold_l040 = MainWindow.dThreshold3[1, 0, 4, 0];
            obj.dThreshold_l041 = MainWindow.dThreshold3[1, 0, 4, 1];
            obj.dThreshold_l042 = MainWindow.dThreshold3[1, 0, 4, 2];
            obj.dThreshold_l043 = MainWindow.dThreshold3[1, 0, 4, 3];
            obj.dThreshold_l044 = MainWindow.dThreshold3[1, 0, 4, 4];
            obj.dThreshold_l045 = MainWindow.dThreshold3[1, 0, 4, 5];
            obj.dThreshold_l046 = MainWindow.dThreshold3[1, 0, 4, 6];
            obj.dThreshold_l047 = MainWindow.dThreshold3[1, 0, 4, 7];
            obj.dThreshold_l048 = MainWindow.dThreshold3[1, 0, 4, 8];
            obj.dThreshold_l049 = MainWindow.dThreshold3[1, 0, 4, 9];
            //1-Stream6
            obj.dThreshold_u050 = MainWindow.dThreshold3[0, 0, 5, 0];
            obj.dThreshold_u051 = MainWindow.dThreshold3[0, 0, 5, 1];
            obj.dThreshold_u052 = MainWindow.dThreshold3[0, 0, 5, 2];
            obj.dThreshold_u053 = MainWindow.dThreshold3[0, 0, 5, 3];
            obj.dThreshold_u054 = MainWindow.dThreshold3[0, 0, 5, 4];
            obj.dThreshold_u055 = MainWindow.dThreshold3[0, 0, 5, 5];
            obj.dThreshold_u056 = MainWindow.dThreshold3[0, 0, 5, 6];
            obj.dThreshold_u057 = MainWindow.dThreshold3[0, 0, 5, 7];
            obj.dThreshold_u058 = MainWindow.dThreshold3[0, 0, 5, 8];
            obj.dThreshold_u059 = MainWindow.dThreshold3[0, 0, 5, 9];

            obj.dThreshold_l050 = MainWindow.dThreshold3[1, 0, 5, 0];
            obj.dThreshold_l051 = MainWindow.dThreshold3[1, 0, 5, 1];
            obj.dThreshold_l052 = MainWindow.dThreshold3[1, 0, 5, 2];
            obj.dThreshold_l053 = MainWindow.dThreshold3[1, 0, 5, 3];
            obj.dThreshold_l054 = MainWindow.dThreshold3[1, 0, 5, 4];
            obj.dThreshold_l055 = MainWindow.dThreshold3[1, 0, 5, 5];
            obj.dThreshold_l056 = MainWindow.dThreshold3[1, 0, 5, 6];
            obj.dThreshold_l057 = MainWindow.dThreshold3[1, 0, 5, 7];
            obj.dThreshold_l058 = MainWindow.dThreshold3[1, 0, 5, 8];
            obj.dThreshold_l059 = MainWindow.dThreshold3[1, 0, 5, 9];
            //1-Stream7
            obj.dThreshold_u060 = MainWindow.dThreshold3[0, 0, 6, 0];
            obj.dThreshold_u061 = MainWindow.dThreshold3[0, 0, 6, 1];
            obj.dThreshold_u062 = MainWindow.dThreshold3[0, 0, 6, 2];
            obj.dThreshold_u063 = MainWindow.dThreshold3[0, 0, 6, 3];
            obj.dThreshold_u064 = MainWindow.dThreshold3[0, 0, 6, 4];
            obj.dThreshold_u065 = MainWindow.dThreshold3[0, 0, 6, 5];
            obj.dThreshold_u066 = MainWindow.dThreshold3[0, 0, 6, 6];
            obj.dThreshold_u067 = MainWindow.dThreshold3[0, 0, 6, 7];
            obj.dThreshold_u068 = MainWindow.dThreshold3[0, 0, 6, 8];
            obj.dThreshold_u069 = MainWindow.dThreshold3[0, 0, 6, 9];

            obj.dThreshold_l060 = MainWindow.dThreshold3[1, 0, 6, 0];
            obj.dThreshold_l061 = MainWindow.dThreshold3[1, 0, 6, 1];
            obj.dThreshold_l062 = MainWindow.dThreshold3[1, 0, 6, 2];
            obj.dThreshold_l063 = MainWindow.dThreshold3[1, 0, 6, 3];
            obj.dThreshold_l064 = MainWindow.dThreshold3[1, 0, 6, 4];
            obj.dThreshold_l065 = MainWindow.dThreshold3[1, 0, 6, 5];
            obj.dThreshold_l066 = MainWindow.dThreshold3[1, 0, 6, 6];
            obj.dThreshold_l067 = MainWindow.dThreshold3[1, 0, 6, 7];
            obj.dThreshold_l068 = MainWindow.dThreshold3[1, 0, 6, 8];
            obj.dThreshold_l069 = MainWindow.dThreshold3[1, 0, 6, 9];
            //1-Stream8
            obj.dThreshold_u070 = MainWindow.dThreshold3[0, 0, 7, 0];
            obj.dThreshold_u071 = MainWindow.dThreshold3[0, 0, 7, 1];
            obj.dThreshold_u072 = MainWindow.dThreshold3[0, 0, 7, 2];
            obj.dThreshold_u073 = MainWindow.dThreshold3[0, 0, 7, 3];
            obj.dThreshold_u074 = MainWindow.dThreshold3[0, 0, 7, 4];
            obj.dThreshold_u075 = MainWindow.dThreshold3[0, 0, 7, 5];
            obj.dThreshold_u076 = MainWindow.dThreshold3[0, 0, 7, 6];
            obj.dThreshold_u077 = MainWindow.dThreshold3[0, 0, 7, 7];
            obj.dThreshold_u078 = MainWindow.dThreshold3[0, 0, 7, 8];
            obj.dThreshold_u079 = MainWindow.dThreshold3[0, 0, 7, 9];

            obj.dThreshold_l070 = MainWindow.dThreshold3[1, 0, 7, 0];
            obj.dThreshold_l071 = MainWindow.dThreshold3[1, 0, 7, 1];
            obj.dThreshold_l072 = MainWindow.dThreshold3[1, 0, 7, 2];
            obj.dThreshold_l073 = MainWindow.dThreshold3[1, 0, 7, 3];
            obj.dThreshold_l074 = MainWindow.dThreshold3[1, 0, 7, 4];
            obj.dThreshold_l075 = MainWindow.dThreshold3[1, 0, 7, 5];
            obj.dThreshold_l076 = MainWindow.dThreshold3[1, 0, 7, 6];
            obj.dThreshold_l077 = MainWindow.dThreshold3[1, 0, 7, 7];
            obj.dThreshold_l078 = MainWindow.dThreshold3[1, 0, 7, 8];
            obj.dThreshold_l079 = MainWindow.dThreshold3[1, 0, 7, 9];
            //1-Stream9
            obj.dThreshold_u080 = MainWindow.dThreshold3[0, 0, 8, 0];
            obj.dThreshold_u081 = MainWindow.dThreshold3[0, 0, 8, 1];
            obj.dThreshold_u082 = MainWindow.dThreshold3[0, 0, 8, 2];
            obj.dThreshold_u083 = MainWindow.dThreshold3[0, 0, 8, 3];
            obj.dThreshold_u084 = MainWindow.dThreshold3[0, 0, 8, 4];
            obj.dThreshold_u085 = MainWindow.dThreshold3[0, 0, 8, 5];
            obj.dThreshold_u086 = MainWindow.dThreshold3[0, 0, 8, 6];
            obj.dThreshold_u087 = MainWindow.dThreshold3[0, 0, 8, 7];
            obj.dThreshold_u088 = MainWindow.dThreshold3[0, 0, 8, 8];
            obj.dThreshold_u089 = MainWindow.dThreshold3[0, 0, 8, 9];

            obj.dThreshold_l080 = MainWindow.dThreshold3[1, 0, 8, 0];
            obj.dThreshold_l081 = MainWindow.dThreshold3[1, 0, 8, 1];
            obj.dThreshold_l082 = MainWindow.dThreshold3[1, 0, 8, 2];
            obj.dThreshold_l083 = MainWindow.dThreshold3[1, 0, 8, 3];
            obj.dThreshold_l084 = MainWindow.dThreshold3[1, 0, 8, 4];
            obj.dThreshold_l085 = MainWindow.dThreshold3[1, 0, 8, 5];
            obj.dThreshold_l086 = MainWindow.dThreshold3[1, 0, 8, 6];
            obj.dThreshold_l087 = MainWindow.dThreshold3[1, 0, 8, 7];
            obj.dThreshold_l088 = MainWindow.dThreshold3[1, 0, 8, 8];
            obj.dThreshold_l089 = MainWindow.dThreshold3[1, 0, 8, 9];
            //1-Stream10
            obj.dThreshold_u090 = MainWindow.dThreshold3[0, 0, 9, 0];
            obj.dThreshold_u091 = MainWindow.dThreshold3[0, 0, 9, 1];
            obj.dThreshold_u092 = MainWindow.dThreshold3[0, 0, 9, 2];
            obj.dThreshold_u093 = MainWindow.dThreshold3[0, 0, 9, 3];
            obj.dThreshold_u094 = MainWindow.dThreshold3[0, 0, 9, 4];
            obj.dThreshold_u095 = MainWindow.dThreshold3[0, 0, 9, 5];
            obj.dThreshold_u096 = MainWindow.dThreshold3[0, 0, 9, 6];
            obj.dThreshold_u097 = MainWindow.dThreshold3[0, 0, 9, 7];
            obj.dThreshold_u098 = MainWindow.dThreshold3[0, 0, 9, 8];
            obj.dThreshold_u099 = MainWindow.dThreshold3[0, 0, 9, 9];

            obj.dThreshold_l090 = MainWindow.dThreshold3[1, 0, 9, 0];
            obj.dThreshold_l091 = MainWindow.dThreshold3[1, 0, 9, 1];
            obj.dThreshold_l092 = MainWindow.dThreshold3[1, 0, 9, 2];
            obj.dThreshold_l093 = MainWindow.dThreshold3[1, 0, 9, 3];
            obj.dThreshold_l094 = MainWindow.dThreshold3[1, 0, 9, 4];
            obj.dThreshold_l095 = MainWindow.dThreshold3[1, 0, 9, 5];
            obj.dThreshold_l096 = MainWindow.dThreshold3[1, 0, 9, 6];
            obj.dThreshold_l097 = MainWindow.dThreshold3[1, 0, 9, 7];
            obj.dThreshold_l098 = MainWindow.dThreshold3[1, 0, 9, 8];
            obj.dThreshold_l099 = MainWindow.dThreshold3[1, 0, 9, 9];
            //1-Stream11
            obj.dThreshold_u0A0 = MainWindow.dThreshold3[0, 0, 10, 0];
            obj.dThreshold_u0A1 = MainWindow.dThreshold3[0, 0, 10, 1];
            obj.dThreshold_u0A2 = MainWindow.dThreshold3[0, 0, 10, 2];
            obj.dThreshold_u0A3 = MainWindow.dThreshold3[0, 0, 10, 3];
            obj.dThreshold_u0A4 = MainWindow.dThreshold3[0, 0, 10, 4];
            obj.dThreshold_u0A5 = MainWindow.dThreshold3[0, 0, 10, 5];
            obj.dThreshold_u0A6 = MainWindow.dThreshold3[0, 0, 10, 6];
            obj.dThreshold_u0A7 = MainWindow.dThreshold3[0, 0, 10, 7];
            obj.dThreshold_u0A8 = MainWindow.dThreshold3[0, 0, 10, 8];
            obj.dThreshold_u0A9 = MainWindow.dThreshold3[0, 0, 10, 9];

            obj.dThreshold_l0A0 = MainWindow.dThreshold3[1, 0, 10, 0];
            obj.dThreshold_l0A1 = MainWindow.dThreshold3[1, 0, 10, 1];
            obj.dThreshold_l0A2 = MainWindow.dThreshold3[1, 0, 10, 2];
            obj.dThreshold_l0A3 = MainWindow.dThreshold3[1, 0, 10, 3];
            obj.dThreshold_l0A4 = MainWindow.dThreshold3[1, 0, 10, 4];
            obj.dThreshold_l0A5 = MainWindow.dThreshold3[1, 0, 10, 5];
            obj.dThreshold_l0A6 = MainWindow.dThreshold3[1, 0, 10, 6];
            obj.dThreshold_l0A7 = MainWindow.dThreshold3[1, 0, 10, 7];
            obj.dThreshold_l0A8 = MainWindow.dThreshold3[1, 0, 10, 8];
            obj.dThreshold_l0A9 = MainWindow.dThreshold3[1, 0, 10, 9];

            //品種2
            //2-Stream1
            obj.dThreshold_u100 = MainWindow.dThreshold3[0, 1, 0, 0];
            obj.dThreshold_u101 = MainWindow.dThreshold3[0, 1, 0, 1];
            obj.dThreshold_u102 = MainWindow.dThreshold3[0, 1, 0, 2];
            obj.dThreshold_u103 = MainWindow.dThreshold3[0, 1, 0, 3];
            obj.dThreshold_u104 = MainWindow.dThreshold3[0, 1, 0, 4];
            obj.dThreshold_u105 = MainWindow.dThreshold3[0, 1, 0, 5];
            obj.dThreshold_u106 = MainWindow.dThreshold3[0, 1, 0, 6];
            obj.dThreshold_u107 = MainWindow.dThreshold3[0, 1, 0, 7];
            obj.dThreshold_u108 = MainWindow.dThreshold3[0, 1, 0, 8];
            obj.dThreshold_u109 = MainWindow.dThreshold3[0, 1, 0, 9];

            obj.dThreshold_l100 = MainWindow.dThreshold3[1, 1, 0, 0];
            obj.dThreshold_l101 = MainWindow.dThreshold3[1, 1, 0, 1];
            obj.dThreshold_l102 = MainWindow.dThreshold3[1, 1, 0, 2];
            obj.dThreshold_l103 = MainWindow.dThreshold3[1, 1, 0, 3];
            obj.dThreshold_l104 = MainWindow.dThreshold3[1, 1, 0, 4];
            obj.dThreshold_l105 = MainWindow.dThreshold3[1, 1, 0, 5];
            obj.dThreshold_l106 = MainWindow.dThreshold3[1, 1, 0, 6];
            obj.dThreshold_l107 = MainWindow.dThreshold3[1, 1, 0, 7];
            obj.dThreshold_l108 = MainWindow.dThreshold3[1, 1, 0, 8];
            obj.dThreshold_l109 = MainWindow.dThreshold3[1, 1, 0, 9];
            //2-Stream2
            obj.dThreshold_u110 = MainWindow.dThreshold3[0, 1, 1, 0];
            obj.dThreshold_u111 = MainWindow.dThreshold3[0, 1, 1, 1];
            obj.dThreshold_u112 = MainWindow.dThreshold3[0, 1, 1, 2];
            obj.dThreshold_u113 = MainWindow.dThreshold3[0, 1, 1, 3];
            obj.dThreshold_u114 = MainWindow.dThreshold3[0, 1, 1, 4];
            obj.dThreshold_u115 = MainWindow.dThreshold3[0, 1, 1, 5];
            obj.dThreshold_u116 = MainWindow.dThreshold3[0, 1, 1, 6];
            obj.dThreshold_u117 = MainWindow.dThreshold3[0, 1, 1, 7];
            obj.dThreshold_u118 = MainWindow.dThreshold3[0, 1, 1, 8];
            obj.dThreshold_u119 = MainWindow.dThreshold3[0, 1, 1, 9];

            obj.dThreshold_l110 = MainWindow.dThreshold3[1, 1, 1, 0];
            obj.dThreshold_l111 = MainWindow.dThreshold3[1, 1, 1, 1];
            obj.dThreshold_l112 = MainWindow.dThreshold3[1, 1, 1, 2];
            obj.dThreshold_l113 = MainWindow.dThreshold3[1, 1, 1, 3];
            obj.dThreshold_l114 = MainWindow.dThreshold3[1, 1, 1, 4];
            obj.dThreshold_l115 = MainWindow.dThreshold3[1, 1, 1, 5];
            obj.dThreshold_l116 = MainWindow.dThreshold3[1, 1, 1, 6];
            obj.dThreshold_l117 = MainWindow.dThreshold3[1, 1, 1, 7];
            obj.dThreshold_l118 = MainWindow.dThreshold3[1, 1, 1, 8];
            obj.dThreshold_l119 = MainWindow.dThreshold3[1, 1, 1, 9];
            //2-Stream3
            obj.dThreshold_u120 = MainWindow.dThreshold3[0, 1, 2, 0];
            obj.dThreshold_u121 = MainWindow.dThreshold3[0, 1, 2, 1];
            obj.dThreshold_u122 = MainWindow.dThreshold3[0, 1, 2, 2];
            obj.dThreshold_u123 = MainWindow.dThreshold3[0, 1, 2, 3];
            obj.dThreshold_u124 = MainWindow.dThreshold3[0, 1, 2, 4];
            obj.dThreshold_u125 = MainWindow.dThreshold3[0, 1, 2, 5];
            obj.dThreshold_u126 = MainWindow.dThreshold3[0, 1, 2, 6];
            obj.dThreshold_u127 = MainWindow.dThreshold3[0, 1, 2, 7];
            obj.dThreshold_u128 = MainWindow.dThreshold3[0, 1, 2, 8];
            obj.dThreshold_u129 = MainWindow.dThreshold3[0, 1, 2, 9];

            obj.dThreshold_l120 = MainWindow.dThreshold3[1, 1, 2, 0];
            obj.dThreshold_l121 = MainWindow.dThreshold3[1, 1, 2, 1];
            obj.dThreshold_l122 = MainWindow.dThreshold3[1, 1, 2, 2];
            obj.dThreshold_l123 = MainWindow.dThreshold3[1, 1, 2, 3];
            obj.dThreshold_l124 = MainWindow.dThreshold3[1, 1, 2, 4];
            obj.dThreshold_l125 = MainWindow.dThreshold3[1, 1, 2, 5];
            obj.dThreshold_l126 = MainWindow.dThreshold3[1, 1, 2, 6];
            obj.dThreshold_l127 = MainWindow.dThreshold3[1, 1, 2, 7];
            obj.dThreshold_l128 = MainWindow.dThreshold3[1, 1, 2, 8];
            obj.dThreshold_l129 = MainWindow.dThreshold3[1, 1, 2, 9];
            //2-Stream4
            obj.dThreshold_u130 = MainWindow.dThreshold3[0, 1, 3, 0];
            obj.dThreshold_u131 = MainWindow.dThreshold3[0, 1, 3, 1];
            obj.dThreshold_u132 = MainWindow.dThreshold3[0, 1, 3, 2];
            obj.dThreshold_u133 = MainWindow.dThreshold3[0, 1, 3, 3];
            obj.dThreshold_u134 = MainWindow.dThreshold3[0, 1, 3, 4];
            obj.dThreshold_u135 = MainWindow.dThreshold3[0, 1, 3, 5];
            obj.dThreshold_u136 = MainWindow.dThreshold3[0, 1, 3, 6];
            obj.dThreshold_u137 = MainWindow.dThreshold3[0, 1, 3, 7];
            obj.dThreshold_u138 = MainWindow.dThreshold3[0, 1, 3, 8];
            obj.dThreshold_u139 = MainWindow.dThreshold3[0, 1, 3, 9];

            obj.dThreshold_l130 = MainWindow.dThreshold3[1, 1, 3, 0];
            obj.dThreshold_l131 = MainWindow.dThreshold3[1, 1, 3, 1];
            obj.dThreshold_l132 = MainWindow.dThreshold3[1, 1, 3, 2];
            obj.dThreshold_l133 = MainWindow.dThreshold3[1, 1, 3, 3];
            obj.dThreshold_l134 = MainWindow.dThreshold3[1, 1, 3, 4];
            obj.dThreshold_l135 = MainWindow.dThreshold3[1, 1, 3, 5];
            obj.dThreshold_l136 = MainWindow.dThreshold3[1, 1, 3, 6];
            obj.dThreshold_l137 = MainWindow.dThreshold3[1, 1, 3, 7];
            obj.dThreshold_l138 = MainWindow.dThreshold3[1, 1, 3, 8];
            obj.dThreshold_l139 = MainWindow.dThreshold3[1, 1, 3, 9];
            //2-Stream5
            obj.dThreshold_u140 = MainWindow.dThreshold3[0, 1, 4, 0];
            obj.dThreshold_u141 = MainWindow.dThreshold3[0, 1, 4, 1];
            obj.dThreshold_u142 = MainWindow.dThreshold3[0, 1, 4, 2];
            obj.dThreshold_u143 = MainWindow.dThreshold3[0, 1, 4, 3];
            obj.dThreshold_u144 = MainWindow.dThreshold3[0, 1, 4, 4];
            obj.dThreshold_u145 = MainWindow.dThreshold3[0, 1, 4, 5];
            obj.dThreshold_u146 = MainWindow.dThreshold3[0, 1, 4, 6];
            obj.dThreshold_u147 = MainWindow.dThreshold3[0, 1, 4, 7];
            obj.dThreshold_u148 = MainWindow.dThreshold3[0, 1, 4, 8];
            obj.dThreshold_u149 = MainWindow.dThreshold3[0, 1, 4, 9];

            obj.dThreshold_l140 = MainWindow.dThreshold3[1, 1, 4, 0];
            obj.dThreshold_l141 = MainWindow.dThreshold3[1, 1, 4, 1];
            obj.dThreshold_l142 = MainWindow.dThreshold3[1, 1, 4, 2];
            obj.dThreshold_l143 = MainWindow.dThreshold3[1, 1, 4, 3];
            obj.dThreshold_l144 = MainWindow.dThreshold3[1, 1, 4, 4];
            obj.dThreshold_l145 = MainWindow.dThreshold3[1, 1, 4, 5];
            obj.dThreshold_l146 = MainWindow.dThreshold3[1, 1, 4, 6];
            obj.dThreshold_l147 = MainWindow.dThreshold3[1, 1, 4, 7];
            obj.dThreshold_l148 = MainWindow.dThreshold3[1, 1, 4, 8];
            obj.dThreshold_l149 = MainWindow.dThreshold3[1, 1, 4, 9];
            //2-Stream6
            obj.dThreshold_u150 = MainWindow.dThreshold3[0, 1, 5, 0];
            obj.dThreshold_u151 = MainWindow.dThreshold3[0, 1, 5, 1];
            obj.dThreshold_u152 = MainWindow.dThreshold3[0, 1, 5, 2];
            obj.dThreshold_u153 = MainWindow.dThreshold3[0, 1, 5, 3];
            obj.dThreshold_u154 = MainWindow.dThreshold3[0, 1, 5, 4];
            obj.dThreshold_u155 = MainWindow.dThreshold3[0, 1, 5, 5];
            obj.dThreshold_u156 = MainWindow.dThreshold3[0, 1, 5, 6];
            obj.dThreshold_u157 = MainWindow.dThreshold3[0, 1, 5, 7];
            obj.dThreshold_u158 = MainWindow.dThreshold3[0, 1, 5, 8];
            obj.dThreshold_u159 = MainWindow.dThreshold3[0, 1, 5, 9];

            obj.dThreshold_l150 = MainWindow.dThreshold3[1, 1, 5, 0];
            obj.dThreshold_l151 = MainWindow.dThreshold3[1, 1, 5, 1];
            obj.dThreshold_l152 = MainWindow.dThreshold3[1, 1, 5, 2];
            obj.dThreshold_l153 = MainWindow.dThreshold3[1, 1, 5, 3];
            obj.dThreshold_l154 = MainWindow.dThreshold3[1, 1, 5, 4];
            obj.dThreshold_l155 = MainWindow.dThreshold3[1, 1, 5, 5];
            obj.dThreshold_l156 = MainWindow.dThreshold3[1, 1, 5, 6];
            obj.dThreshold_l157 = MainWindow.dThreshold3[1, 1, 5, 7];
            obj.dThreshold_l158 = MainWindow.dThreshold3[1, 1, 5, 8];
            obj.dThreshold_l159 = MainWindow.dThreshold3[1, 1, 5, 9];
            //2-Stream7
            obj.dThreshold_u160 = MainWindow.dThreshold3[0, 1, 6, 0];
            obj.dThreshold_u161 = MainWindow.dThreshold3[0, 1, 6, 1];
            obj.dThreshold_u162 = MainWindow.dThreshold3[0, 1, 6, 2];
            obj.dThreshold_u163 = MainWindow.dThreshold3[0, 1, 6, 3];
            obj.dThreshold_u164 = MainWindow.dThreshold3[0, 1, 6, 4];
            obj.dThreshold_u165 = MainWindow.dThreshold3[0, 1, 6, 5];
            obj.dThreshold_u166 = MainWindow.dThreshold3[0, 1, 6, 6];
            obj.dThreshold_u167 = MainWindow.dThreshold3[0, 1, 6, 7];
            obj.dThreshold_u168 = MainWindow.dThreshold3[0, 1, 6, 8];
            obj.dThreshold_u169 = MainWindow.dThreshold3[0, 1, 6, 9];

            obj.dThreshold_l160 = MainWindow.dThreshold3[1, 1, 6, 0];
            obj.dThreshold_l161 = MainWindow.dThreshold3[1, 1, 6, 1];
            obj.dThreshold_l162 = MainWindow.dThreshold3[1, 1, 6, 2];
            obj.dThreshold_l163 = MainWindow.dThreshold3[1, 1, 6, 3];
            obj.dThreshold_l164 = MainWindow.dThreshold3[1, 1, 6, 4];
            obj.dThreshold_l165 = MainWindow.dThreshold3[1, 1, 6, 5];
            obj.dThreshold_l166 = MainWindow.dThreshold3[1, 1, 6, 6];
            obj.dThreshold_l167 = MainWindow.dThreshold3[1, 1, 6, 7];
            obj.dThreshold_l168 = MainWindow.dThreshold3[1, 1, 6, 8];
            obj.dThreshold_l169 = MainWindow.dThreshold3[1, 1, 6, 9];
            //2-Stream8
            obj.dThreshold_u170 = MainWindow.dThreshold3[0, 1, 7, 0];
            obj.dThreshold_u171 = MainWindow.dThreshold3[0, 1, 7, 1];
            obj.dThreshold_u172 = MainWindow.dThreshold3[0, 1, 7, 2];
            obj.dThreshold_u173 = MainWindow.dThreshold3[0, 1, 7, 3];
            obj.dThreshold_u174 = MainWindow.dThreshold3[0, 1, 7, 4];
            obj.dThreshold_u175 = MainWindow.dThreshold3[0, 1, 7, 5];
            obj.dThreshold_u176 = MainWindow.dThreshold3[0, 1, 7, 6];
            obj.dThreshold_u177 = MainWindow.dThreshold3[0, 1, 7, 7];
            obj.dThreshold_u178 = MainWindow.dThreshold3[0, 1, 7, 8];
            obj.dThreshold_u179 = MainWindow.dThreshold3[0, 1, 7, 9];

            obj.dThreshold_l170 = MainWindow.dThreshold3[1, 1, 7, 0];
            obj.dThreshold_l171 = MainWindow.dThreshold3[1, 1, 7, 1];
            obj.dThreshold_l172 = MainWindow.dThreshold3[1, 1, 7, 2];
            obj.dThreshold_l173 = MainWindow.dThreshold3[1, 1, 7, 3];
            obj.dThreshold_l174 = MainWindow.dThreshold3[1, 1, 7, 4];
            obj.dThreshold_l175 = MainWindow.dThreshold3[1, 1, 7, 5];
            obj.dThreshold_l176 = MainWindow.dThreshold3[1, 1, 7, 6];
            obj.dThreshold_l177 = MainWindow.dThreshold3[1, 1, 7, 7];
            obj.dThreshold_l178 = MainWindow.dThreshold3[1, 1, 7, 8];
            obj.dThreshold_l179 = MainWindow.dThreshold3[1, 1, 7, 9];
            //2-Stream9
            obj.dThreshold_u180 = MainWindow.dThreshold3[0, 1, 8, 0];
            obj.dThreshold_u181 = MainWindow.dThreshold3[0, 1, 8, 1];
            obj.dThreshold_u182 = MainWindow.dThreshold3[0, 1, 8, 2];
            obj.dThreshold_u183 = MainWindow.dThreshold3[0, 1, 8, 3];
            obj.dThreshold_u184 = MainWindow.dThreshold3[0, 1, 8, 4];
            obj.dThreshold_u185 = MainWindow.dThreshold3[0, 1, 8, 5];
            obj.dThreshold_u186 = MainWindow.dThreshold3[0, 1, 8, 6];
            obj.dThreshold_u187 = MainWindow.dThreshold3[0, 1, 8, 7];
            obj.dThreshold_u188 = MainWindow.dThreshold3[0, 1, 8, 8];
            obj.dThreshold_u189 = MainWindow.dThreshold3[0, 1, 8, 9];

            obj.dThreshold_l180 = MainWindow.dThreshold3[1, 1, 8, 0];
            obj.dThreshold_l181 = MainWindow.dThreshold3[1, 1, 8, 1];
            obj.dThreshold_l182 = MainWindow.dThreshold3[1, 1, 8, 2];
            obj.dThreshold_l183 = MainWindow.dThreshold3[1, 1, 8, 3];
            obj.dThreshold_l184 = MainWindow.dThreshold3[1, 1, 8, 4];
            obj.dThreshold_l185 = MainWindow.dThreshold3[1, 1, 8, 5];
            obj.dThreshold_l186 = MainWindow.dThreshold3[1, 1, 8, 6];
            obj.dThreshold_l187 = MainWindow.dThreshold3[1, 1, 8, 7];
            obj.dThreshold_l188 = MainWindow.dThreshold3[1, 1, 8, 8];
            obj.dThreshold_l189 = MainWindow.dThreshold3[1, 1, 8, 9];
            //2-Stream10
            obj.dThreshold_u190 = MainWindow.dThreshold3[0, 1, 9, 0];
            obj.dThreshold_u191 = MainWindow.dThreshold3[0, 1, 9, 1];
            obj.dThreshold_u192 = MainWindow.dThreshold3[0, 1, 9, 2];
            obj.dThreshold_u193 = MainWindow.dThreshold3[0, 1, 9, 3];
            obj.dThreshold_u194 = MainWindow.dThreshold3[0, 1, 9, 4];
            obj.dThreshold_u195 = MainWindow.dThreshold3[0, 1, 9, 5];
            obj.dThreshold_u196 = MainWindow.dThreshold3[0, 1, 9, 6];
            obj.dThreshold_u197 = MainWindow.dThreshold3[0, 1, 9, 7];
            obj.dThreshold_u198 = MainWindow.dThreshold3[0, 1, 9, 8];
            obj.dThreshold_u199 = MainWindow.dThreshold3[0, 1, 9, 9];

            obj.dThreshold_l190 = MainWindow.dThreshold3[1, 1, 9, 0];
            obj.dThreshold_l191 = MainWindow.dThreshold3[1, 1, 9, 1];
            obj.dThreshold_l192 = MainWindow.dThreshold3[1, 1, 9, 2];
            obj.dThreshold_l193 = MainWindow.dThreshold3[1, 1, 9, 3];
            obj.dThreshold_l194 = MainWindow.dThreshold3[1, 1, 9, 4];
            obj.dThreshold_l195 = MainWindow.dThreshold3[1, 1, 9, 5];
            obj.dThreshold_l196 = MainWindow.dThreshold3[1, 1, 9, 6];
            obj.dThreshold_l197 = MainWindow.dThreshold3[1, 1, 9, 7];
            obj.dThreshold_l198 = MainWindow.dThreshold3[1, 1, 9, 8];
            obj.dThreshold_l199 = MainWindow.dThreshold3[1, 1, 9, 9];
            //2-Stream11
            obj.dThreshold_u1A0 = MainWindow.dThreshold3[0, 1, 10, 0];
            obj.dThreshold_u1A1 = MainWindow.dThreshold3[0, 1, 10, 1];
            obj.dThreshold_u1A2 = MainWindow.dThreshold3[0, 1, 10, 2];
            obj.dThreshold_u1A3 = MainWindow.dThreshold3[0, 1, 10, 3];
            obj.dThreshold_u1A4 = MainWindow.dThreshold3[0, 1, 10, 4];
            obj.dThreshold_u1A5 = MainWindow.dThreshold3[0, 1, 10, 5];
            obj.dThreshold_u1A6 = MainWindow.dThreshold3[0, 1, 10, 6];
            obj.dThreshold_u1A7 = MainWindow.dThreshold3[0, 1, 10, 7];
            obj.dThreshold_u1A8 = MainWindow.dThreshold3[0, 1, 10, 8];
            obj.dThreshold_u1A9 = MainWindow.dThreshold3[0, 1, 10, 9];

            obj.dThreshold_l1A0 = MainWindow.dThreshold3[1, 1, 10, 0];
            obj.dThreshold_l1A1 = MainWindow.dThreshold3[1, 1, 10, 1];
            obj.dThreshold_l1A2 = MainWindow.dThreshold3[1, 1, 10, 2];
            obj.dThreshold_l1A3 = MainWindow.dThreshold3[1, 1, 10, 3];
            obj.dThreshold_l1A4 = MainWindow.dThreshold3[1, 1, 10, 4];
            obj.dThreshold_l1A5 = MainWindow.dThreshold3[1, 1, 10, 5];
            obj.dThreshold_l1A6 = MainWindow.dThreshold3[1, 1, 10, 6];
            obj.dThreshold_l1A7 = MainWindow.dThreshold3[1, 1, 10, 7];
            obj.dThreshold_l1A8 = MainWindow.dThreshold3[1, 1, 10, 8];
            obj.dThreshold_l1A9 = MainWindow.dThreshold3[1, 1, 10, 9];

            //品種3
            //3-Stream1
            obj.dThreshold_u200 = MainWindow.dThreshold3[0, 2, 0, 0];
            obj.dThreshold_u201 = MainWindow.dThreshold3[0, 2, 0, 1];
            obj.dThreshold_u202 = MainWindow.dThreshold3[0, 2, 0, 2];
            obj.dThreshold_u203 = MainWindow.dThreshold3[0, 2, 0, 3];
            obj.dThreshold_u204 = MainWindow.dThreshold3[0, 2, 0, 4];
            obj.dThreshold_u205 = MainWindow.dThreshold3[0, 2, 0, 5];
            obj.dThreshold_u206 = MainWindow.dThreshold3[0, 2, 0, 6];
            obj.dThreshold_u207 = MainWindow.dThreshold3[0, 2, 0, 7];
            obj.dThreshold_u208 = MainWindow.dThreshold3[0, 2, 0, 8];
            obj.dThreshold_u209 = MainWindow.dThreshold3[0, 2, 0, 9];

            obj.dThreshold_l200 = MainWindow.dThreshold3[1, 2, 0, 0];
            obj.dThreshold_l201 = MainWindow.dThreshold3[1, 2, 0, 1];
            obj.dThreshold_l202 = MainWindow.dThreshold3[1, 2, 0, 2];
            obj.dThreshold_l203 = MainWindow.dThreshold3[1, 2, 0, 3];
            obj.dThreshold_l204 = MainWindow.dThreshold3[1, 2, 0, 4];
            obj.dThreshold_l205 = MainWindow.dThreshold3[1, 2, 0, 5];
            obj.dThreshold_l206 = MainWindow.dThreshold3[1, 2, 0, 6];
            obj.dThreshold_l207 = MainWindow.dThreshold3[1, 2, 0, 7];
            obj.dThreshold_l208 = MainWindow.dThreshold3[1, 2, 0, 8];
            obj.dThreshold_l209 = MainWindow.dThreshold3[1, 2, 0, 9];
            //3-Stream2
            obj.dThreshold_u210 = MainWindow.dThreshold3[0, 2, 1, 0];
            obj.dThreshold_u211 = MainWindow.dThreshold3[0, 2, 1, 1];
            obj.dThreshold_u212 = MainWindow.dThreshold3[0, 2, 1, 2];
            obj.dThreshold_u213 = MainWindow.dThreshold3[0, 2, 1, 3];
            obj.dThreshold_u214 = MainWindow.dThreshold3[0, 2, 1, 4];
            obj.dThreshold_u215 = MainWindow.dThreshold3[0, 2, 1, 5];
            obj.dThreshold_u216 = MainWindow.dThreshold3[0, 2, 1, 6];
            obj.dThreshold_u217 = MainWindow.dThreshold3[0, 2, 1, 7];
            obj.dThreshold_u218 = MainWindow.dThreshold3[0, 2, 1, 8];
            obj.dThreshold_u219 = MainWindow.dThreshold3[0, 2, 1, 9];

            obj.dThreshold_l210 = MainWindow.dThreshold3[1, 2, 1, 0];
            obj.dThreshold_l211 = MainWindow.dThreshold3[1, 2, 1, 1];
            obj.dThreshold_l212 = MainWindow.dThreshold3[1, 2, 1, 2];
            obj.dThreshold_l213 = MainWindow.dThreshold3[1, 2, 1, 3];
            obj.dThreshold_l214 = MainWindow.dThreshold3[1, 2, 1, 4];
            obj.dThreshold_l215 = MainWindow.dThreshold3[1, 2, 1, 5];
            obj.dThreshold_l216 = MainWindow.dThreshold3[1, 2, 1, 6];
            obj.dThreshold_l217 = MainWindow.dThreshold3[1, 2, 1, 7];
            obj.dThreshold_l218 = MainWindow.dThreshold3[1, 2, 1, 8];
            obj.dThreshold_l219 = MainWindow.dThreshold3[1, 2, 1, 9];
            //3-Stream3
            obj.dThreshold_u220 = MainWindow.dThreshold3[0, 2, 2, 0];
            obj.dThreshold_u221 = MainWindow.dThreshold3[0, 2, 2, 1];
            obj.dThreshold_u222 = MainWindow.dThreshold3[0, 2, 2, 2];
            obj.dThreshold_u223 = MainWindow.dThreshold3[0, 2, 2, 3];
            obj.dThreshold_u224 = MainWindow.dThreshold3[0, 2, 2, 4];
            obj.dThreshold_u225 = MainWindow.dThreshold3[0, 2, 2, 5];
            obj.dThreshold_u226 = MainWindow.dThreshold3[0, 2, 2, 6];
            obj.dThreshold_u227 = MainWindow.dThreshold3[0, 2, 2, 7];
            obj.dThreshold_u228 = MainWindow.dThreshold3[0, 2, 2, 8];
            obj.dThreshold_u229 = MainWindow.dThreshold3[0, 2, 2, 9];

            obj.dThreshold_l220 = MainWindow.dThreshold3[1, 2, 2, 0];
            obj.dThreshold_l221 = MainWindow.dThreshold3[1, 2, 2, 1];
            obj.dThreshold_l222 = MainWindow.dThreshold3[1, 2, 2, 2];
            obj.dThreshold_l223 = MainWindow.dThreshold3[1, 2, 2, 3];
            obj.dThreshold_l224 = MainWindow.dThreshold3[1, 2, 2, 4];
            obj.dThreshold_l225 = MainWindow.dThreshold3[1, 2, 2, 5];
            obj.dThreshold_l226 = MainWindow.dThreshold3[1, 2, 2, 6];
            obj.dThreshold_l227 = MainWindow.dThreshold3[1, 2, 2, 7];
            obj.dThreshold_l228 = MainWindow.dThreshold3[1, 2, 2, 8];
            obj.dThreshold_l229 = MainWindow.dThreshold3[1, 2, 2, 9];
            //3-Stream4
            obj.dThreshold_u230 = MainWindow.dThreshold3[0, 2, 3, 0];
            obj.dThreshold_u231 = MainWindow.dThreshold3[0, 2, 3, 1];
            obj.dThreshold_u232 = MainWindow.dThreshold3[0, 2, 3, 2];
            obj.dThreshold_u233 = MainWindow.dThreshold3[0, 2, 3, 3];
            obj.dThreshold_u234 = MainWindow.dThreshold3[0, 2, 3, 4];
            obj.dThreshold_u235 = MainWindow.dThreshold3[0, 2, 3, 5];
            obj.dThreshold_u236 = MainWindow.dThreshold3[0, 2, 3, 6];
            obj.dThreshold_u237 = MainWindow.dThreshold3[0, 2, 3, 7];
            obj.dThreshold_u238 = MainWindow.dThreshold3[0, 2, 3, 8];
            obj.dThreshold_u239 = MainWindow.dThreshold3[0, 2, 3, 9];

            obj.dThreshold_l230 = MainWindow.dThreshold3[1, 2, 3, 0];
            obj.dThreshold_l231 = MainWindow.dThreshold3[1, 2, 3, 1];
            obj.dThreshold_l232 = MainWindow.dThreshold3[1, 2, 3, 2];
            obj.dThreshold_l233 = MainWindow.dThreshold3[1, 2, 3, 3];
            obj.dThreshold_l234 = MainWindow.dThreshold3[1, 2, 3, 4];
            obj.dThreshold_l235 = MainWindow.dThreshold3[1, 2, 3, 5];
            obj.dThreshold_l236 = MainWindow.dThreshold3[1, 2, 3, 6];
            obj.dThreshold_l237 = MainWindow.dThreshold3[1, 2, 3, 7];
            obj.dThreshold_l238 = MainWindow.dThreshold3[1, 2, 3, 8];
            obj.dThreshold_l239 = MainWindow.dThreshold3[1, 2, 3, 9];
            //3-Stream5
            obj.dThreshold_u240 = MainWindow.dThreshold3[0, 2, 4, 0];
            obj.dThreshold_u241 = MainWindow.dThreshold3[0, 2, 4, 1];
            obj.dThreshold_u242 = MainWindow.dThreshold3[0, 2, 4, 2];
            obj.dThreshold_u243 = MainWindow.dThreshold3[0, 2, 4, 3];
            obj.dThreshold_u244 = MainWindow.dThreshold3[0, 2, 4, 4];
            obj.dThreshold_u245 = MainWindow.dThreshold3[0, 2, 4, 5];
            obj.dThreshold_u246 = MainWindow.dThreshold3[0, 2, 4, 6];
            obj.dThreshold_u247 = MainWindow.dThreshold3[0, 2, 4, 7];
            obj.dThreshold_u248 = MainWindow.dThreshold3[0, 2, 4, 8];
            obj.dThreshold_u249 = MainWindow.dThreshold3[0, 2, 4, 9];

            obj.dThreshold_l240 = MainWindow.dThreshold3[1, 2, 4, 0];
            obj.dThreshold_l241 = MainWindow.dThreshold3[1, 2, 4, 1];
            obj.dThreshold_l242 = MainWindow.dThreshold3[1, 2, 4, 2];
            obj.dThreshold_l243 = MainWindow.dThreshold3[1, 2, 4, 3];
            obj.dThreshold_l244 = MainWindow.dThreshold3[1, 2, 4, 4];
            obj.dThreshold_l245 = MainWindow.dThreshold3[1, 2, 4, 5];
            obj.dThreshold_l246 = MainWindow.dThreshold3[1, 2, 4, 6];
            obj.dThreshold_l247 = MainWindow.dThreshold3[1, 2, 4, 7];
            obj.dThreshold_l248 = MainWindow.dThreshold3[1, 2, 4, 8];
            obj.dThreshold_l249 = MainWindow.dThreshold3[1, 2, 4, 9];
            //3-Stream6
            obj.dThreshold_u250 = MainWindow.dThreshold3[0, 2, 5, 0];
            obj.dThreshold_u251 = MainWindow.dThreshold3[0, 2, 5, 1];
            obj.dThreshold_u252 = MainWindow.dThreshold3[0, 2, 5, 2];
            obj.dThreshold_u253 = MainWindow.dThreshold3[0, 2, 5, 3];
            obj.dThreshold_u254 = MainWindow.dThreshold3[0, 2, 5, 4];
            obj.dThreshold_u255 = MainWindow.dThreshold3[0, 2, 5, 5];
            obj.dThreshold_u256 = MainWindow.dThreshold3[0, 2, 5, 6];
            obj.dThreshold_u257 = MainWindow.dThreshold3[0, 2, 5, 7];
            obj.dThreshold_u258 = MainWindow.dThreshold3[0, 2, 5, 8];
            obj.dThreshold_u259 = MainWindow.dThreshold3[0, 2, 5, 9];

            obj.dThreshold_l250 = MainWindow.dThreshold3[1, 2, 5, 0];
            obj.dThreshold_l251 = MainWindow.dThreshold3[1, 2, 5, 1];
            obj.dThreshold_l252 = MainWindow.dThreshold3[1, 2, 5, 2];
            obj.dThreshold_l253 = MainWindow.dThreshold3[1, 2, 5, 3];
            obj.dThreshold_l254 = MainWindow.dThreshold3[1, 2, 5, 4];
            obj.dThreshold_l255 = MainWindow.dThreshold3[1, 2, 5, 5];
            obj.dThreshold_l256 = MainWindow.dThreshold3[1, 2, 5, 6];
            obj.dThreshold_l257 = MainWindow.dThreshold3[1, 2, 5, 7];
            obj.dThreshold_l258 = MainWindow.dThreshold3[1, 2, 5, 8];
            obj.dThreshold_l259 = MainWindow.dThreshold3[1, 2, 5, 9];
            //3-Stream7
            obj.dThreshold_u260 = MainWindow.dThreshold3[0, 2, 6, 0];
            obj.dThreshold_u261 = MainWindow.dThreshold3[0, 2, 6, 1];
            obj.dThreshold_u262 = MainWindow.dThreshold3[0, 2, 6, 2];
            obj.dThreshold_u263 = MainWindow.dThreshold3[0, 2, 6, 3];
            obj.dThreshold_u264 = MainWindow.dThreshold3[0, 2, 6, 4];
            obj.dThreshold_u265 = MainWindow.dThreshold3[0, 2, 6, 5];
            obj.dThreshold_u266 = MainWindow.dThreshold3[0, 2, 6, 6];
            obj.dThreshold_u267 = MainWindow.dThreshold3[0, 2, 6, 7];
            obj.dThreshold_u268 = MainWindow.dThreshold3[0, 2, 6, 8];
            obj.dThreshold_u269 = MainWindow.dThreshold3[0, 2, 6, 9];

            obj.dThreshold_l260 = MainWindow.dThreshold3[1, 2, 6, 0];
            obj.dThreshold_l261 = MainWindow.dThreshold3[1, 2, 6, 1];
            obj.dThreshold_l262 = MainWindow.dThreshold3[1, 2, 6, 2];
            obj.dThreshold_l263 = MainWindow.dThreshold3[1, 2, 6, 3];
            obj.dThreshold_l264 = MainWindow.dThreshold3[1, 2, 6, 4];
            obj.dThreshold_l265 = MainWindow.dThreshold3[1, 2, 6, 5];
            obj.dThreshold_l266 = MainWindow.dThreshold3[1, 2, 6, 6];
            obj.dThreshold_l267 = MainWindow.dThreshold3[1, 2, 6, 7];
            obj.dThreshold_l268 = MainWindow.dThreshold3[1, 2, 6, 8];
            obj.dThreshold_l269 = MainWindow.dThreshold3[1, 2, 6, 9];
            //3-Stream8
            obj.dThreshold_u270 = MainWindow.dThreshold3[0, 2, 7, 0];
            obj.dThreshold_u271 = MainWindow.dThreshold3[0, 2, 7, 1];
            obj.dThreshold_u272 = MainWindow.dThreshold3[0, 2, 7, 2];
            obj.dThreshold_u273 = MainWindow.dThreshold3[0, 2, 7, 3];
            obj.dThreshold_u274 = MainWindow.dThreshold3[0, 2, 7, 4];
            obj.dThreshold_u275 = MainWindow.dThreshold3[0, 2, 7, 5];
            obj.dThreshold_u276 = MainWindow.dThreshold3[0, 2, 7, 6];
            obj.dThreshold_u277 = MainWindow.dThreshold3[0, 2, 7, 7];
            obj.dThreshold_u278 = MainWindow.dThreshold3[0, 2, 7, 8];
            obj.dThreshold_u279 = MainWindow.dThreshold3[0, 2, 7, 9];

            obj.dThreshold_l270 = MainWindow.dThreshold3[1, 2, 7, 0];
            obj.dThreshold_l271 = MainWindow.dThreshold3[1, 2, 7, 1];
            obj.dThreshold_l272 = MainWindow.dThreshold3[1, 2, 7, 2];
            obj.dThreshold_l273 = MainWindow.dThreshold3[1, 2, 7, 3];
            obj.dThreshold_l274 = MainWindow.dThreshold3[1, 2, 7, 4];
            obj.dThreshold_l275 = MainWindow.dThreshold3[1, 2, 7, 5];
            obj.dThreshold_l276 = MainWindow.dThreshold3[1, 2, 7, 6];
            obj.dThreshold_l277 = MainWindow.dThreshold3[1, 2, 7, 7];
            obj.dThreshold_l278 = MainWindow.dThreshold3[1, 2, 7, 8];
            obj.dThreshold_l279 = MainWindow.dThreshold3[1, 2, 7, 9];
            //3-Stream9
            obj.dThreshold_u280 = MainWindow.dThreshold3[0, 2, 8, 0];
            obj.dThreshold_u281 = MainWindow.dThreshold3[0, 2, 8, 1];
            obj.dThreshold_u282 = MainWindow.dThreshold3[0, 2, 8, 2];
            obj.dThreshold_u283 = MainWindow.dThreshold3[0, 2, 8, 3];
            obj.dThreshold_u284 = MainWindow.dThreshold3[0, 2, 8, 4];
            obj.dThreshold_u285 = MainWindow.dThreshold3[0, 2, 8, 5];
            obj.dThreshold_u286 = MainWindow.dThreshold3[0, 2, 8, 6];
            obj.dThreshold_u287 = MainWindow.dThreshold3[0, 2, 8, 7];
            obj.dThreshold_u288 = MainWindow.dThreshold3[0, 2, 8, 8];
            obj.dThreshold_u289 = MainWindow.dThreshold3[0, 2, 8, 9];

            obj.dThreshold_l280 = MainWindow.dThreshold3[1, 2, 8, 0];
            obj.dThreshold_l281 = MainWindow.dThreshold3[1, 2, 8, 1];
            obj.dThreshold_l282 = MainWindow.dThreshold3[1, 2, 8, 2];
            obj.dThreshold_l283 = MainWindow.dThreshold3[1, 2, 8, 3];
            obj.dThreshold_l284 = MainWindow.dThreshold3[1, 2, 8, 4];
            obj.dThreshold_l285 = MainWindow.dThreshold3[1, 2, 8, 5];
            obj.dThreshold_l286 = MainWindow.dThreshold3[1, 2, 8, 6];
            obj.dThreshold_l287 = MainWindow.dThreshold3[1, 2, 8, 7];
            obj.dThreshold_l288 = MainWindow.dThreshold3[1, 2, 8, 8];
            obj.dThreshold_l289 = MainWindow.dThreshold3[1, 2, 8, 9];
            //3-Stream10
            obj.dThreshold_u290 = MainWindow.dThreshold3[0, 2, 9, 0];
            obj.dThreshold_u291 = MainWindow.dThreshold3[0, 2, 9, 1];
            obj.dThreshold_u292 = MainWindow.dThreshold3[0, 2, 9, 2];
            obj.dThreshold_u293 = MainWindow.dThreshold3[0, 2, 9, 3];
            obj.dThreshold_u294 = MainWindow.dThreshold3[0, 2, 9, 4];
            obj.dThreshold_u295 = MainWindow.dThreshold3[0, 2, 9, 5];
            obj.dThreshold_u296 = MainWindow.dThreshold3[0, 2, 9, 6];
            obj.dThreshold_u297 = MainWindow.dThreshold3[0, 2, 9, 7];
            obj.dThreshold_u298 = MainWindow.dThreshold3[0, 2, 9, 8];
            obj.dThreshold_u299 = MainWindow.dThreshold3[0, 2, 9, 9];

            obj.dThreshold_l290 = MainWindow.dThreshold3[1, 2, 9, 0];
            obj.dThreshold_l291 = MainWindow.dThreshold3[1, 2, 9, 1];
            obj.dThreshold_l292 = MainWindow.dThreshold3[1, 2, 9, 2];
            obj.dThreshold_l293 = MainWindow.dThreshold3[1, 2, 9, 3];
            obj.dThreshold_l294 = MainWindow.dThreshold3[1, 2, 9, 4];
            obj.dThreshold_l295 = MainWindow.dThreshold3[1, 2, 9, 5];
            obj.dThreshold_l296 = MainWindow.dThreshold3[1, 2, 9, 6];
            obj.dThreshold_l297 = MainWindow.dThreshold3[1, 2, 9, 7];
            obj.dThreshold_l298 = MainWindow.dThreshold3[1, 2, 9, 8];
            obj.dThreshold_l299 = MainWindow.dThreshold3[1, 2, 9, 9];
            //3-Stream11
            obj.dThreshold_u2A0 = MainWindow.dThreshold3[0, 2, 10, 0];
            obj.dThreshold_u2A1 = MainWindow.dThreshold3[0, 2, 10, 1];
            obj.dThreshold_u2A2 = MainWindow.dThreshold3[0, 2, 10, 2];
            obj.dThreshold_u2A3 = MainWindow.dThreshold3[0, 2, 10, 3];
            obj.dThreshold_u2A4 = MainWindow.dThreshold3[0, 2, 10, 4];
            obj.dThreshold_u2A5 = MainWindow.dThreshold3[0, 2, 10, 5];
            obj.dThreshold_u2A6 = MainWindow.dThreshold3[0, 2, 10, 6];
            obj.dThreshold_u2A7 = MainWindow.dThreshold3[0, 2, 10, 7];
            obj.dThreshold_u2A8 = MainWindow.dThreshold3[0, 2, 10, 8];
            obj.dThreshold_u2A9 = MainWindow.dThreshold3[0, 2, 10, 9];

            obj.dThreshold_l2A0 = MainWindow.dThreshold3[1, 2, 10, 0];
            obj.dThreshold_l2A1 = MainWindow.dThreshold3[1, 2, 10, 1];
            obj.dThreshold_l2A2 = MainWindow.dThreshold3[1, 2, 10, 2];
            obj.dThreshold_l2A3 = MainWindow.dThreshold3[1, 2, 10, 3];
            obj.dThreshold_l2A4 = MainWindow.dThreshold3[1, 2, 10, 4];
            obj.dThreshold_l2A5 = MainWindow.dThreshold3[1, 2, 10, 5];
            obj.dThreshold_l2A6 = MainWindow.dThreshold3[1, 2, 10, 6];
            obj.dThreshold_l2A7 = MainWindow.dThreshold3[1, 2, 10, 7];
            obj.dThreshold_l2A8 = MainWindow.dThreshold3[1, 2, 10, 8];
            obj.dThreshold_l2A9 = MainWindow.dThreshold3[1, 2, 10, 9];

            //品種4
            //4-Stream1
            obj.dThreshold_u300 = MainWindow.dThreshold3[0, 3, 0, 0];
            obj.dThreshold_u301 = MainWindow.dThreshold3[0, 3, 0, 1];
            obj.dThreshold_u302 = MainWindow.dThreshold3[0, 3, 0, 2];
            obj.dThreshold_u303 = MainWindow.dThreshold3[0, 3, 0, 3];
            obj.dThreshold_u304 = MainWindow.dThreshold3[0, 3, 0, 4];
            obj.dThreshold_u305 = MainWindow.dThreshold3[0, 3, 0, 5];
            obj.dThreshold_u306 = MainWindow.dThreshold3[0, 3, 0, 6];
            obj.dThreshold_u307 = MainWindow.dThreshold3[0, 3, 0, 7];
            obj.dThreshold_u308 = MainWindow.dThreshold3[0, 3, 0, 8];
            obj.dThreshold_u309 = MainWindow.dThreshold3[0, 3, 0, 9];

            obj.dThreshold_l300 = MainWindow.dThreshold3[1, 3, 0, 0];
            obj.dThreshold_l301 = MainWindow.dThreshold3[1, 3, 0, 1];
            obj.dThreshold_l302 = MainWindow.dThreshold3[1, 3, 0, 2];
            obj.dThreshold_l303 = MainWindow.dThreshold3[1, 3, 0, 3];
            obj.dThreshold_l304 = MainWindow.dThreshold3[1, 3, 0, 4];
            obj.dThreshold_l305 = MainWindow.dThreshold3[1, 3, 0, 5];
            obj.dThreshold_l306 = MainWindow.dThreshold3[1, 3, 0, 6];
            obj.dThreshold_l307 = MainWindow.dThreshold3[1, 3, 0, 7];
            obj.dThreshold_l308 = MainWindow.dThreshold3[1, 3, 0, 8];
            obj.dThreshold_l309 = MainWindow.dThreshold3[1, 3, 0, 9];
            //4-Stream2
            obj.dThreshold_u310 = MainWindow.dThreshold3[0, 3, 1, 0];
            obj.dThreshold_u311 = MainWindow.dThreshold3[0, 3, 1, 1];
            obj.dThreshold_u312 = MainWindow.dThreshold3[0, 3, 1, 2];
            obj.dThreshold_u313 = MainWindow.dThreshold3[0, 3, 1, 3];
            obj.dThreshold_u314 = MainWindow.dThreshold3[0, 3, 1, 4];
            obj.dThreshold_u315 = MainWindow.dThreshold3[0, 3, 1, 5];
            obj.dThreshold_u316 = MainWindow.dThreshold3[0, 3, 1, 6];
            obj.dThreshold_u317 = MainWindow.dThreshold3[0, 3, 1, 7];
            obj.dThreshold_u318 = MainWindow.dThreshold3[0, 3, 1, 8];
            obj.dThreshold_u319 = MainWindow.dThreshold3[0, 3, 1, 9];

            obj.dThreshold_l310 = MainWindow.dThreshold3[1, 3, 1, 0];
            obj.dThreshold_l311 = MainWindow.dThreshold3[1, 3, 1, 1];
            obj.dThreshold_l312 = MainWindow.dThreshold3[1, 3, 1, 2];
            obj.dThreshold_l313 = MainWindow.dThreshold3[1, 3, 1, 3];
            obj.dThreshold_l314 = MainWindow.dThreshold3[1, 3, 1, 4];
            obj.dThreshold_l315 = MainWindow.dThreshold3[1, 3, 1, 5];
            obj.dThreshold_l316 = MainWindow.dThreshold3[1, 3, 1, 6];
            obj.dThreshold_l317 = MainWindow.dThreshold3[1, 3, 1, 7];
            obj.dThreshold_l318 = MainWindow.dThreshold3[1, 3, 1, 8];
            obj.dThreshold_l319 = MainWindow.dThreshold3[1, 3, 1, 9];
            //4-Stream3
            obj.dThreshold_u320 = MainWindow.dThreshold3[0, 3, 2, 0];
            obj.dThreshold_u321 = MainWindow.dThreshold3[0, 3, 2, 1];
            obj.dThreshold_u322 = MainWindow.dThreshold3[0, 3, 2, 2];
            obj.dThreshold_u323 = MainWindow.dThreshold3[0, 3, 2, 3];
            obj.dThreshold_u324 = MainWindow.dThreshold3[0, 3, 2, 4];
            obj.dThreshold_u325 = MainWindow.dThreshold3[0, 3, 2, 5];
            obj.dThreshold_u326 = MainWindow.dThreshold3[0, 3, 2, 6];
            obj.dThreshold_u327 = MainWindow.dThreshold3[0, 3, 2, 7];
            obj.dThreshold_u328 = MainWindow.dThreshold3[0, 3, 2, 8];
            obj.dThreshold_u329 = MainWindow.dThreshold3[0, 3, 2, 9];

            obj.dThreshold_l320 = MainWindow.dThreshold3[1, 3, 2, 0];
            obj.dThreshold_l321 = MainWindow.dThreshold3[1, 3, 2, 1];
            obj.dThreshold_l322 = MainWindow.dThreshold3[1, 3, 2, 2];
            obj.dThreshold_l323 = MainWindow.dThreshold3[1, 3, 2, 3];
            obj.dThreshold_l324 = MainWindow.dThreshold3[1, 3, 2, 4];
            obj.dThreshold_l325 = MainWindow.dThreshold3[1, 3, 2, 5];
            obj.dThreshold_l326 = MainWindow.dThreshold3[1, 3, 2, 6];
            obj.dThreshold_l327 = MainWindow.dThreshold3[1, 3, 2, 7];
            obj.dThreshold_l328 = MainWindow.dThreshold3[1, 3, 2, 8];
            obj.dThreshold_l329 = MainWindow.dThreshold3[1, 3, 2, 9];
            //4-Stream4
            obj.dThreshold_u330 = MainWindow.dThreshold3[0, 3, 3, 0];
            obj.dThreshold_u331 = MainWindow.dThreshold3[0, 3, 3, 1];
            obj.dThreshold_u332 = MainWindow.dThreshold3[0, 3, 3, 2];
            obj.dThreshold_u333 = MainWindow.dThreshold3[0, 3, 3, 3];
            obj.dThreshold_u334 = MainWindow.dThreshold3[0, 3, 3, 4];
            obj.dThreshold_u335 = MainWindow.dThreshold3[0, 3, 3, 5];
            obj.dThreshold_u336 = MainWindow.dThreshold3[0, 3, 3, 6];
            obj.dThreshold_u337 = MainWindow.dThreshold3[0, 3, 3, 7];
            obj.dThreshold_u338 = MainWindow.dThreshold3[0, 3, 3, 8];
            obj.dThreshold_u339 = MainWindow.dThreshold3[0, 3, 3, 9];

            obj.dThreshold_l330 = MainWindow.dThreshold3[1, 3, 3, 0];
            obj.dThreshold_l331 = MainWindow.dThreshold3[1, 3, 3, 1];
            obj.dThreshold_l332 = MainWindow.dThreshold3[1, 3, 3, 2];
            obj.dThreshold_l333 = MainWindow.dThreshold3[1, 3, 3, 3];
            obj.dThreshold_l334 = MainWindow.dThreshold3[1, 3, 3, 4];
            obj.dThreshold_l335 = MainWindow.dThreshold3[1, 3, 3, 5];
            obj.dThreshold_l336 = MainWindow.dThreshold3[1, 3, 3, 6];
            obj.dThreshold_l337 = MainWindow.dThreshold3[1, 3, 3, 7];
            obj.dThreshold_l338 = MainWindow.dThreshold3[1, 3, 3, 8];
            obj.dThreshold_l339 = MainWindow.dThreshold3[1, 3, 3, 9];
            //4-Stream5
            obj.dThreshold_u340 = MainWindow.dThreshold3[0, 3, 4, 0];
            obj.dThreshold_u341 = MainWindow.dThreshold3[0, 3, 4, 1];
            obj.dThreshold_u342 = MainWindow.dThreshold3[0, 3, 4, 2];
            obj.dThreshold_u343 = MainWindow.dThreshold3[0, 3, 4, 3];
            obj.dThreshold_u344 = MainWindow.dThreshold3[0, 3, 4, 4];
            obj.dThreshold_u345 = MainWindow.dThreshold3[0, 3, 4, 5];
            obj.dThreshold_u346 = MainWindow.dThreshold3[0, 3, 4, 6];
            obj.dThreshold_u347 = MainWindow.dThreshold3[0, 3, 4, 7];
            obj.dThreshold_u348 = MainWindow.dThreshold3[0, 3, 4, 8];
            obj.dThreshold_u349 = MainWindow.dThreshold3[0, 3, 4, 9];

            obj.dThreshold_l340 = MainWindow.dThreshold3[1, 3, 4, 0];
            obj.dThreshold_l341 = MainWindow.dThreshold3[1, 3, 4, 1];
            obj.dThreshold_l342 = MainWindow.dThreshold3[1, 3, 4, 2];
            obj.dThreshold_l343 = MainWindow.dThreshold3[1, 3, 4, 3];
            obj.dThreshold_l344 = MainWindow.dThreshold3[1, 3, 4, 4];
            obj.dThreshold_l345 = MainWindow.dThreshold3[1, 3, 4, 5];
            obj.dThreshold_l346 = MainWindow.dThreshold3[1, 3, 4, 6];
            obj.dThreshold_l347 = MainWindow.dThreshold3[1, 3, 4, 7];
            obj.dThreshold_l348 = MainWindow.dThreshold3[1, 3, 4, 8];
            obj.dThreshold_l349 = MainWindow.dThreshold3[1, 3, 4, 9];
            //4-Stream6
            obj.dThreshold_u350 = MainWindow.dThreshold3[0, 3, 5, 0];
            obj.dThreshold_u351 = MainWindow.dThreshold3[0, 3, 5, 1];
            obj.dThreshold_u352 = MainWindow.dThreshold3[0, 3, 5, 2];
            obj.dThreshold_u353 = MainWindow.dThreshold3[0, 3, 5, 3];
            obj.dThreshold_u354 = MainWindow.dThreshold3[0, 3, 5, 4];
            obj.dThreshold_u355 = MainWindow.dThreshold3[0, 3, 5, 5];
            obj.dThreshold_u356 = MainWindow.dThreshold3[0, 3, 5, 6];
            obj.dThreshold_u357 = MainWindow.dThreshold3[0, 3, 5, 7];
            obj.dThreshold_u358 = MainWindow.dThreshold3[0, 3, 5, 8];
            obj.dThreshold_u359 = MainWindow.dThreshold3[0, 3, 5, 9];

            obj.dThreshold_l350 = MainWindow.dThreshold3[1, 3, 5, 0];
            obj.dThreshold_l351 = MainWindow.dThreshold3[1, 3, 5, 1];
            obj.dThreshold_l352 = MainWindow.dThreshold3[1, 3, 5, 2];
            obj.dThreshold_l353 = MainWindow.dThreshold3[1, 3, 5, 3];
            obj.dThreshold_l354 = MainWindow.dThreshold3[1, 3, 5, 4];
            obj.dThreshold_l355 = MainWindow.dThreshold3[1, 3, 5, 5];
            obj.dThreshold_l356 = MainWindow.dThreshold3[1, 3, 5, 6];
            obj.dThreshold_l357 = MainWindow.dThreshold3[1, 3, 5, 7];
            obj.dThreshold_l358 = MainWindow.dThreshold3[1, 3, 5, 8];
            obj.dThreshold_l359 = MainWindow.dThreshold3[1, 3, 5, 9];
            //4-Stream7
            obj.dThreshold_u360 = MainWindow.dThreshold3[0, 3, 6, 0];
            obj.dThreshold_u361 = MainWindow.dThreshold3[0, 3, 6, 1];
            obj.dThreshold_u362 = MainWindow.dThreshold3[0, 3, 6, 2];
            obj.dThreshold_u363 = MainWindow.dThreshold3[0, 3, 6, 3];
            obj.dThreshold_u364 = MainWindow.dThreshold3[0, 3, 6, 4];
            obj.dThreshold_u365 = MainWindow.dThreshold3[0, 3, 6, 5];
            obj.dThreshold_u366 = MainWindow.dThreshold3[0, 3, 6, 6];
            obj.dThreshold_u367 = MainWindow.dThreshold3[0, 3, 6, 7];
            obj.dThreshold_u368 = MainWindow.dThreshold3[0, 3, 6, 8];
            obj.dThreshold_u369 = MainWindow.dThreshold3[0, 3, 6, 9];

            obj.dThreshold_l360 = MainWindow.dThreshold3[1, 3, 6, 0];
            obj.dThreshold_l361 = MainWindow.dThreshold3[1, 3, 6, 1];
            obj.dThreshold_l362 = MainWindow.dThreshold3[1, 3, 6, 2];
            obj.dThreshold_l363 = MainWindow.dThreshold3[1, 3, 6, 3];
            obj.dThreshold_l364 = MainWindow.dThreshold3[1, 3, 6, 4];
            obj.dThreshold_l365 = MainWindow.dThreshold3[1, 3, 6, 5];
            obj.dThreshold_l366 = MainWindow.dThreshold3[1, 3, 6, 6];
            obj.dThreshold_l367 = MainWindow.dThreshold3[1, 3, 6, 7];
            obj.dThreshold_l368 = MainWindow.dThreshold3[1, 3, 6, 8];
            obj.dThreshold_l369 = MainWindow.dThreshold3[1, 3, 6, 9];
            //4-Stream8
            obj.dThreshold_u370 = MainWindow.dThreshold3[0, 3, 7, 0];
            obj.dThreshold_u371 = MainWindow.dThreshold3[0, 3, 7, 1];
            obj.dThreshold_u372 = MainWindow.dThreshold3[0, 3, 7, 2];
            obj.dThreshold_u373 = MainWindow.dThreshold3[0, 3, 7, 3];
            obj.dThreshold_u374 = MainWindow.dThreshold3[0, 3, 7, 4];
            obj.dThreshold_u375 = MainWindow.dThreshold3[0, 3, 7, 5];
            obj.dThreshold_u376 = MainWindow.dThreshold3[0, 3, 7, 6];
            obj.dThreshold_u377 = MainWindow.dThreshold3[0, 3, 7, 7];
            obj.dThreshold_u378 = MainWindow.dThreshold3[0, 3, 7, 8];
            obj.dThreshold_u379 = MainWindow.dThreshold3[0, 3, 7, 9];

            obj.dThreshold_l370 = MainWindow.dThreshold3[1, 3, 7, 0];
            obj.dThreshold_l371 = MainWindow.dThreshold3[1, 3, 7, 1];
            obj.dThreshold_l372 = MainWindow.dThreshold3[1, 3, 7, 2];
            obj.dThreshold_l373 = MainWindow.dThreshold3[1, 3, 7, 3];
            obj.dThreshold_l374 = MainWindow.dThreshold3[1, 3, 7, 4];
            obj.dThreshold_l375 = MainWindow.dThreshold3[1, 3, 7, 5];
            obj.dThreshold_l376 = MainWindow.dThreshold3[1, 3, 7, 6];
            obj.dThreshold_l377 = MainWindow.dThreshold3[1, 3, 7, 7];
            obj.dThreshold_l378 = MainWindow.dThreshold3[1, 3, 7, 8];
            obj.dThreshold_l379 = MainWindow.dThreshold3[1, 3, 7, 9];
            //4-Stream9
            obj.dThreshold_u380 = MainWindow.dThreshold3[0, 3, 8, 0];
            obj.dThreshold_u381 = MainWindow.dThreshold3[0, 3, 8, 1];
            obj.dThreshold_u382 = MainWindow.dThreshold3[0, 3, 8, 2];
            obj.dThreshold_u383 = MainWindow.dThreshold3[0, 3, 8, 3];
            obj.dThreshold_u384 = MainWindow.dThreshold3[0, 3, 8, 4];
            obj.dThreshold_u385 = MainWindow.dThreshold3[0, 3, 8, 5];
            obj.dThreshold_u386 = MainWindow.dThreshold3[0, 3, 8, 6];
            obj.dThreshold_u387 = MainWindow.dThreshold3[0, 3, 8, 7];
            obj.dThreshold_u388 = MainWindow.dThreshold3[0, 3, 8, 8];
            obj.dThreshold_u389 = MainWindow.dThreshold3[0, 3, 8, 9];

            obj.dThreshold_l380 = MainWindow.dThreshold3[1, 3, 8, 0];
            obj.dThreshold_l381 = MainWindow.dThreshold3[1, 3, 8, 1];
            obj.dThreshold_l382 = MainWindow.dThreshold3[1, 3, 8, 2];
            obj.dThreshold_l383 = MainWindow.dThreshold3[1, 3, 8, 3];
            obj.dThreshold_l384 = MainWindow.dThreshold3[1, 3, 8, 4];
            obj.dThreshold_l385 = MainWindow.dThreshold3[1, 3, 8, 5];
            obj.dThreshold_l386 = MainWindow.dThreshold3[1, 3, 8, 6];
            obj.dThreshold_l387 = MainWindow.dThreshold3[1, 3, 8, 7];
            obj.dThreshold_l388 = MainWindow.dThreshold3[1, 3, 8, 8];
            obj.dThreshold_l389 = MainWindow.dThreshold3[1, 3, 8, 9];
            //4-Stream10
            obj.dThreshold_u390 = MainWindow.dThreshold3[0, 3, 9, 0];
            obj.dThreshold_u391 = MainWindow.dThreshold3[0, 3, 9, 1];
            obj.dThreshold_u392 = MainWindow.dThreshold3[0, 3, 9, 2];
            obj.dThreshold_u393 = MainWindow.dThreshold3[0, 3, 9, 3];
            obj.dThreshold_u394 = MainWindow.dThreshold3[0, 3, 9, 4];
            obj.dThreshold_u395 = MainWindow.dThreshold3[0, 3, 9, 5];
            obj.dThreshold_u396 = MainWindow.dThreshold3[0, 3, 9, 6];
            obj.dThreshold_u397 = MainWindow.dThreshold3[0, 3, 9, 7];
            obj.dThreshold_u398 = MainWindow.dThreshold3[0, 3, 9, 8];
            obj.dThreshold_u399 = MainWindow.dThreshold3[0, 3, 9, 9];

            obj.dThreshold_l390 = MainWindow.dThreshold3[1, 3, 9, 0];
            obj.dThreshold_l391 = MainWindow.dThreshold3[1, 3, 9, 1];
            obj.dThreshold_l392 = MainWindow.dThreshold3[1, 3, 9, 2];
            obj.dThreshold_l393 = MainWindow.dThreshold3[1, 3, 9, 3];
            obj.dThreshold_l394 = MainWindow.dThreshold3[1, 3, 9, 4];
            obj.dThreshold_l395 = MainWindow.dThreshold3[1, 3, 9, 5];
            obj.dThreshold_l396 = MainWindow.dThreshold3[1, 3, 9, 6];
            obj.dThreshold_l397 = MainWindow.dThreshold3[1, 3, 9, 7];
            obj.dThreshold_l398 = MainWindow.dThreshold3[1, 3, 9, 8];
            obj.dThreshold_l399 = MainWindow.dThreshold3[1, 3, 9, 9];
            //4-Stream11
            obj.dThreshold_u3A0 = MainWindow.dThreshold3[0, 3, 10, 0];
            obj.dThreshold_u3A1 = MainWindow.dThreshold3[0, 3, 10, 1];
            obj.dThreshold_u3A2 = MainWindow.dThreshold3[0, 3, 10, 2];
            obj.dThreshold_u3A3 = MainWindow.dThreshold3[0, 3, 10, 3];
            obj.dThreshold_u3A4 = MainWindow.dThreshold3[0, 3, 10, 4];
            obj.dThreshold_u3A5 = MainWindow.dThreshold3[0, 3, 10, 5];
            obj.dThreshold_u3A6 = MainWindow.dThreshold3[0, 3, 10, 6];
            obj.dThreshold_u3A7 = MainWindow.dThreshold3[0, 3, 10, 7];
            obj.dThreshold_u3A8 = MainWindow.dThreshold3[0, 3, 10, 8];
            obj.dThreshold_u3A9 = MainWindow.dThreshold3[0, 3, 10, 9];

            obj.dThreshold_l3A0 = MainWindow.dThreshold3[1, 3, 10, 0];
            obj.dThreshold_l3A1 = MainWindow.dThreshold3[1, 3, 10, 1];
            obj.dThreshold_l3A2 = MainWindow.dThreshold3[1, 3, 10, 2];
            obj.dThreshold_l3A3 = MainWindow.dThreshold3[1, 3, 10, 3];
            obj.dThreshold_l3A4 = MainWindow.dThreshold3[1, 3, 10, 4];
            obj.dThreshold_l3A5 = MainWindow.dThreshold3[1, 3, 10, 5];
            obj.dThreshold_l3A6 = MainWindow.dThreshold3[1, 3, 10, 6];
            obj.dThreshold_l3A7 = MainWindow.dThreshold3[1, 3, 10, 7];
            obj.dThreshold_l3A8 = MainWindow.dThreshold3[1, 3, 10, 8];
            obj.dThreshold_l3A9 = MainWindow.dThreshold3[1, 3, 10, 9];

            //品種5
            //5-Stream1
            obj.dThreshold_u400 = MainWindow.dThreshold3[0, 4, 0, 0];
            obj.dThreshold_u401 = MainWindow.dThreshold3[0, 4, 0, 1];
            obj.dThreshold_u402 = MainWindow.dThreshold3[0, 4, 0, 2];
            obj.dThreshold_u403 = MainWindow.dThreshold3[0, 4, 0, 3];
            obj.dThreshold_u404 = MainWindow.dThreshold3[0, 4, 0, 4];
            obj.dThreshold_u405 = MainWindow.dThreshold3[0, 4, 0, 5];
            obj.dThreshold_u406 = MainWindow.dThreshold3[0, 4, 0, 6];
            obj.dThreshold_u407 = MainWindow.dThreshold3[0, 4, 0, 7];
            obj.dThreshold_u408 = MainWindow.dThreshold3[0, 4, 0, 8];
            obj.dThreshold_u409 = MainWindow.dThreshold3[0, 4, 0, 9];

            obj.dThreshold_l400 = MainWindow.dThreshold3[1, 4, 0, 0];
            obj.dThreshold_l401 = MainWindow.dThreshold3[1, 4, 0, 1];
            obj.dThreshold_l402 = MainWindow.dThreshold3[1, 4, 0, 2];
            obj.dThreshold_l403 = MainWindow.dThreshold3[1, 4, 0, 3];
            obj.dThreshold_l404 = MainWindow.dThreshold3[1, 4, 0, 4];
            obj.dThreshold_l405 = MainWindow.dThreshold3[1, 4, 0, 5];
            obj.dThreshold_l406 = MainWindow.dThreshold3[1, 4, 0, 6];
            obj.dThreshold_l407 = MainWindow.dThreshold3[1, 4, 0, 7];
            obj.dThreshold_l408 = MainWindow.dThreshold3[1, 4, 0, 8];
            obj.dThreshold_l409 = MainWindow.dThreshold3[1, 4, 0, 9];
            //5-Stream2
            obj.dThreshold_u410 = MainWindow.dThreshold3[0, 4, 1, 0];
            obj.dThreshold_u411 = MainWindow.dThreshold3[0, 4, 1, 1];
            obj.dThreshold_u412 = MainWindow.dThreshold3[0, 4, 1, 2];
            obj.dThreshold_u413 = MainWindow.dThreshold3[0, 4, 1, 3];
            obj.dThreshold_u414 = MainWindow.dThreshold3[0, 4, 1, 4];
            obj.dThreshold_u415 = MainWindow.dThreshold3[0, 4, 1, 5];
            obj.dThreshold_u416 = MainWindow.dThreshold3[0, 4, 1, 6];
            obj.dThreshold_u417 = MainWindow.dThreshold3[0, 4, 1, 7];
            obj.dThreshold_u418 = MainWindow.dThreshold3[0, 4, 1, 8];
            obj.dThreshold_u419 = MainWindow.dThreshold3[0, 4, 1, 9];

            obj.dThreshold_l410 = MainWindow.dThreshold3[1, 4, 1, 0];
            obj.dThreshold_l411 = MainWindow.dThreshold3[1, 4, 1, 1];
            obj.dThreshold_l412 = MainWindow.dThreshold3[1, 4, 1, 2];
            obj.dThreshold_l413 = MainWindow.dThreshold3[1, 4, 1, 3];
            obj.dThreshold_l414 = MainWindow.dThreshold3[1, 4, 1, 4];
            obj.dThreshold_l415 = MainWindow.dThreshold3[1, 4, 1, 5];
            obj.dThreshold_l416 = MainWindow.dThreshold3[1, 4, 1, 6];
            obj.dThreshold_l417 = MainWindow.dThreshold3[1, 4, 1, 7];
            obj.dThreshold_l418 = MainWindow.dThreshold3[1, 4, 1, 8];
            obj.dThreshold_l419 = MainWindow.dThreshold3[1, 4, 1, 9];
            //5-Stream3
            obj.dThreshold_u420 = MainWindow.dThreshold3[0, 4, 2, 0];
            obj.dThreshold_u421 = MainWindow.dThreshold3[0, 4, 2, 1];
            obj.dThreshold_u422 = MainWindow.dThreshold3[0, 4, 2, 2];
            obj.dThreshold_u423 = MainWindow.dThreshold3[0, 4, 2, 3];
            obj.dThreshold_u424 = MainWindow.dThreshold3[0, 4, 2, 4];
            obj.dThreshold_u425 = MainWindow.dThreshold3[0, 4, 2, 5];
            obj.dThreshold_u426 = MainWindow.dThreshold3[0, 4, 2, 6];
            obj.dThreshold_u427 = MainWindow.dThreshold3[0, 4, 2, 7];
            obj.dThreshold_u428 = MainWindow.dThreshold3[0, 4, 2, 8];
            obj.dThreshold_u429 = MainWindow.dThreshold3[0, 4, 2, 9];

            obj.dThreshold_l420 = MainWindow.dThreshold3[1, 4, 2, 0];
            obj.dThreshold_l421 = MainWindow.dThreshold3[1, 4, 2, 1];
            obj.dThreshold_l422 = MainWindow.dThreshold3[1, 4, 2, 2];
            obj.dThreshold_l423 = MainWindow.dThreshold3[1, 4, 2, 3];
            obj.dThreshold_l424 = MainWindow.dThreshold3[1, 4, 2, 4];
            obj.dThreshold_l425 = MainWindow.dThreshold3[1, 4, 2, 5];
            obj.dThreshold_l426 = MainWindow.dThreshold3[1, 4, 2, 6];
            obj.dThreshold_l427 = MainWindow.dThreshold3[1, 4, 2, 7];
            obj.dThreshold_l428 = MainWindow.dThreshold3[1, 4, 2, 8];
            obj.dThreshold_l429 = MainWindow.dThreshold3[1, 4, 2, 9];
            //5-Stream4
            obj.dThreshold_u430 = MainWindow.dThreshold3[0, 4, 3, 0];
            obj.dThreshold_u431 = MainWindow.dThreshold3[0, 4, 3, 1];
            obj.dThreshold_u432 = MainWindow.dThreshold3[0, 4, 3, 2];
            obj.dThreshold_u433 = MainWindow.dThreshold3[0, 4, 3, 3];
            obj.dThreshold_u434 = MainWindow.dThreshold3[0, 4, 3, 4];
            obj.dThreshold_u435 = MainWindow.dThreshold3[0, 4, 3, 5];
            obj.dThreshold_u436 = MainWindow.dThreshold3[0, 4, 3, 6];
            obj.dThreshold_u437 = MainWindow.dThreshold3[0, 4, 3, 7];
            obj.dThreshold_u438 = MainWindow.dThreshold3[0, 4, 3, 8];
            obj.dThreshold_u439 = MainWindow.dThreshold3[0, 4, 3, 9];

            obj.dThreshold_l430 = MainWindow.dThreshold3[1, 4, 3, 0];
            obj.dThreshold_l431 = MainWindow.dThreshold3[1, 4, 3, 1];
            obj.dThreshold_l432 = MainWindow.dThreshold3[1, 4, 3, 2];
            obj.dThreshold_l433 = MainWindow.dThreshold3[1, 4, 3, 3];
            obj.dThreshold_l434 = MainWindow.dThreshold3[1, 4, 3, 4];
            obj.dThreshold_l435 = MainWindow.dThreshold3[1, 4, 3, 5];
            obj.dThreshold_l436 = MainWindow.dThreshold3[1, 4, 3, 6];
            obj.dThreshold_l437 = MainWindow.dThreshold3[1, 4, 3, 7];
            obj.dThreshold_l438 = MainWindow.dThreshold3[1, 4, 3, 8];
            obj.dThreshold_l439 = MainWindow.dThreshold3[1, 4, 3, 9];
            //5-Stream5
            obj.dThreshold_u440 = MainWindow.dThreshold3[0, 4, 4, 0];
            obj.dThreshold_u441 = MainWindow.dThreshold3[0, 4, 4, 1];
            obj.dThreshold_u442 = MainWindow.dThreshold3[0, 4, 4, 2];
            obj.dThreshold_u443 = MainWindow.dThreshold3[0, 4, 4, 3];
            obj.dThreshold_u444 = MainWindow.dThreshold3[0, 4, 4, 4];
            obj.dThreshold_u445 = MainWindow.dThreshold3[0, 4, 4, 5];
            obj.dThreshold_u446 = MainWindow.dThreshold3[0, 4, 4, 6];
            obj.dThreshold_u447 = MainWindow.dThreshold3[0, 4, 4, 7];
            obj.dThreshold_u448 = MainWindow.dThreshold3[0, 4, 4, 8];
            obj.dThreshold_u449 = MainWindow.dThreshold3[0, 4, 4, 9];

            obj.dThreshold_l440 = MainWindow.dThreshold3[1, 4, 4, 0];
            obj.dThreshold_l441 = MainWindow.dThreshold3[1, 4, 4, 1];
            obj.dThreshold_l442 = MainWindow.dThreshold3[1, 4, 4, 2];
            obj.dThreshold_l443 = MainWindow.dThreshold3[1, 4, 4, 3];
            obj.dThreshold_l444 = MainWindow.dThreshold3[1, 4, 4, 4];
            obj.dThreshold_l445 = MainWindow.dThreshold3[1, 4, 4, 5];
            obj.dThreshold_l446 = MainWindow.dThreshold3[1, 4, 4, 6];
            obj.dThreshold_l447 = MainWindow.dThreshold3[1, 4, 4, 7];
            obj.dThreshold_l448 = MainWindow.dThreshold3[1, 4, 4, 8];
            obj.dThreshold_l449 = MainWindow.dThreshold3[1, 4, 4, 9];
            //5-Stream6
            obj.dThreshold_u450 = MainWindow.dThreshold3[0, 4, 5, 0];
            obj.dThreshold_u451 = MainWindow.dThreshold3[0, 4, 5, 1];
            obj.dThreshold_u452 = MainWindow.dThreshold3[0, 4, 5, 2];
            obj.dThreshold_u453 = MainWindow.dThreshold3[0, 4, 5, 3];
            obj.dThreshold_u454 = MainWindow.dThreshold3[0, 4, 5, 4];
            obj.dThreshold_u455 = MainWindow.dThreshold3[0, 4, 5, 5];
            obj.dThreshold_u456 = MainWindow.dThreshold3[0, 4, 5, 6];
            obj.dThreshold_u457 = MainWindow.dThreshold3[0, 4, 5, 7];
            obj.dThreshold_u458 = MainWindow.dThreshold3[0, 4, 5, 8];
            obj.dThreshold_u459 = MainWindow.dThreshold3[0, 4, 5, 9];

            obj.dThreshold_l450 = MainWindow.dThreshold3[1, 4, 5, 0];
            obj.dThreshold_l451 = MainWindow.dThreshold3[1, 4, 5, 1];
            obj.dThreshold_l452 = MainWindow.dThreshold3[1, 4, 5, 2];
            obj.dThreshold_l453 = MainWindow.dThreshold3[1, 4, 5, 3];
            obj.dThreshold_l454 = MainWindow.dThreshold3[1, 4, 5, 4];
            obj.dThreshold_l455 = MainWindow.dThreshold3[1, 4, 5, 5];
            obj.dThreshold_l456 = MainWindow.dThreshold3[1, 4, 5, 6];
            obj.dThreshold_l457 = MainWindow.dThreshold3[1, 4, 5, 7];
            obj.dThreshold_l458 = MainWindow.dThreshold3[1, 4, 5, 8];
            obj.dThreshold_l459 = MainWindow.dThreshold3[1, 4, 5, 9];
            //5-Stream7
            obj.dThreshold_u460 = MainWindow.dThreshold3[0, 4, 6, 0];
            obj.dThreshold_u461 = MainWindow.dThreshold3[0, 4, 6, 1];
            obj.dThreshold_u462 = MainWindow.dThreshold3[0, 4, 6, 2];
            obj.dThreshold_u463 = MainWindow.dThreshold3[0, 4, 6, 3];
            obj.dThreshold_u464 = MainWindow.dThreshold3[0, 4, 6, 4];
            obj.dThreshold_u465 = MainWindow.dThreshold3[0, 4, 6, 5];
            obj.dThreshold_u466 = MainWindow.dThreshold3[0, 4, 6, 6];
            obj.dThreshold_u467 = MainWindow.dThreshold3[0, 4, 6, 7];
            obj.dThreshold_u468 = MainWindow.dThreshold3[0, 4, 6, 8];
            obj.dThreshold_u469 = MainWindow.dThreshold3[0, 4, 6, 9];

            obj.dThreshold_l460 = MainWindow.dThreshold3[1, 4, 6, 0];
            obj.dThreshold_l461 = MainWindow.dThreshold3[1, 4, 6, 1];
            obj.dThreshold_l462 = MainWindow.dThreshold3[1, 4, 6, 2];
            obj.dThreshold_l463 = MainWindow.dThreshold3[1, 4, 6, 3];
            obj.dThreshold_l464 = MainWindow.dThreshold3[1, 4, 6, 4];
            obj.dThreshold_l465 = MainWindow.dThreshold3[1, 4, 6, 5];
            obj.dThreshold_l466 = MainWindow.dThreshold3[1, 4, 6, 6];
            obj.dThreshold_l467 = MainWindow.dThreshold3[1, 4, 6, 7];
            obj.dThreshold_l468 = MainWindow.dThreshold3[1, 4, 6, 8];
            obj.dThreshold_l469 = MainWindow.dThreshold3[1, 4, 6, 9];
            //5-Stream8
            obj.dThreshold_u470 = MainWindow.dThreshold3[0, 4, 7, 0];
            obj.dThreshold_u471 = MainWindow.dThreshold3[0, 4, 7, 1];
            obj.dThreshold_u472 = MainWindow.dThreshold3[0, 4, 7, 2];
            obj.dThreshold_u473 = MainWindow.dThreshold3[0, 4, 7, 3];
            obj.dThreshold_u474 = MainWindow.dThreshold3[0, 4, 7, 4];
            obj.dThreshold_u475 = MainWindow.dThreshold3[0, 4, 7, 5];
            obj.dThreshold_u476 = MainWindow.dThreshold3[0, 4, 7, 6];
            obj.dThreshold_u477 = MainWindow.dThreshold3[0, 4, 7, 7];
            obj.dThreshold_u478 = MainWindow.dThreshold3[0, 4, 7, 8];
            obj.dThreshold_u479 = MainWindow.dThreshold3[0, 4, 7, 9];

            obj.dThreshold_l470 = MainWindow.dThreshold3[1, 4, 7, 0];
            obj.dThreshold_l471 = MainWindow.dThreshold3[1, 4, 7, 1];
            obj.dThreshold_l472 = MainWindow.dThreshold3[1, 4, 7, 2];
            obj.dThreshold_l473 = MainWindow.dThreshold3[1, 4, 7, 3];
            obj.dThreshold_l474 = MainWindow.dThreshold3[1, 4, 7, 4];
            obj.dThreshold_l475 = MainWindow.dThreshold3[1, 4, 7, 5];
            obj.dThreshold_l476 = MainWindow.dThreshold3[1, 4, 7, 6];
            obj.dThreshold_l477 = MainWindow.dThreshold3[1, 4, 7, 7];
            obj.dThreshold_l478 = MainWindow.dThreshold3[1, 4, 7, 8];
            obj.dThreshold_l479 = MainWindow.dThreshold3[1, 4, 7, 9];
            //5-Stream9
            obj.dThreshold_u480 = MainWindow.dThreshold3[0, 4, 8, 0];
            obj.dThreshold_u481 = MainWindow.dThreshold3[0, 4, 8, 1];
            obj.dThreshold_u482 = MainWindow.dThreshold3[0, 4, 8, 2];
            obj.dThreshold_u483 = MainWindow.dThreshold3[0, 4, 8, 3];
            obj.dThreshold_u484 = MainWindow.dThreshold3[0, 4, 8, 4];
            obj.dThreshold_u485 = MainWindow.dThreshold3[0, 4, 8, 5];
            obj.dThreshold_u486 = MainWindow.dThreshold3[0, 4, 8, 6];
            obj.dThreshold_u487 = MainWindow.dThreshold3[0, 4, 8, 7];
            obj.dThreshold_u488 = MainWindow.dThreshold3[0, 4, 8, 8];
            obj.dThreshold_u489 = MainWindow.dThreshold3[0, 4, 8, 9];

            obj.dThreshold_l480 = MainWindow.dThreshold3[1, 4, 8, 0];
            obj.dThreshold_l481 = MainWindow.dThreshold3[1, 4, 8, 1];
            obj.dThreshold_l482 = MainWindow.dThreshold3[1, 4, 8, 2];
            obj.dThreshold_l483 = MainWindow.dThreshold3[1, 4, 8, 3];
            obj.dThreshold_l484 = MainWindow.dThreshold3[1, 4, 8, 4];
            obj.dThreshold_l485 = MainWindow.dThreshold3[1, 4, 8, 5];
            obj.dThreshold_l486 = MainWindow.dThreshold3[1, 4, 8, 6];
            obj.dThreshold_l487 = MainWindow.dThreshold3[1, 4, 8, 7];
            obj.dThreshold_l488 = MainWindow.dThreshold3[1, 4, 8, 8];
            obj.dThreshold_l489 = MainWindow.dThreshold3[1, 4, 8, 9];
            //5-Stream10
            obj.dThreshold_u490 = MainWindow.dThreshold3[0, 4, 9, 0];
            obj.dThreshold_u491 = MainWindow.dThreshold3[0, 4, 9, 1];
            obj.dThreshold_u492 = MainWindow.dThreshold3[0, 4, 9, 2];
            obj.dThreshold_u493 = MainWindow.dThreshold3[0, 4, 9, 3];
            obj.dThreshold_u494 = MainWindow.dThreshold3[0, 4, 9, 4];
            obj.dThreshold_u495 = MainWindow.dThreshold3[0, 4, 9, 5];
            obj.dThreshold_u496 = MainWindow.dThreshold3[0, 4, 9, 6];
            obj.dThreshold_u497 = MainWindow.dThreshold3[0, 4, 9, 7];
            obj.dThreshold_u498 = MainWindow.dThreshold3[0, 4, 9, 8];
            obj.dThreshold_u499 = MainWindow.dThreshold3[0, 4, 9, 9];

            obj.dThreshold_l490 = MainWindow.dThreshold3[1, 4, 9, 0];
            obj.dThreshold_l491 = MainWindow.dThreshold3[1, 4, 9, 1];
            obj.dThreshold_l492 = MainWindow.dThreshold3[1, 4, 9, 2];
            obj.dThreshold_l493 = MainWindow.dThreshold3[1, 4, 9, 3];
            obj.dThreshold_l494 = MainWindow.dThreshold3[1, 4, 9, 4];
            obj.dThreshold_l495 = MainWindow.dThreshold3[1, 4, 9, 5];
            obj.dThreshold_l496 = MainWindow.dThreshold3[1, 4, 9, 6];
            obj.dThreshold_l497 = MainWindow.dThreshold3[1, 4, 9, 7];
            obj.dThreshold_l498 = MainWindow.dThreshold3[1, 4, 9, 8];
            obj.dThreshold_l499 = MainWindow.dThreshold3[1, 4, 9, 9];
            //5-Stream11
            obj.dThreshold_u4A0 = MainWindow.dThreshold3[0, 4, 10, 0];
            obj.dThreshold_u4A1 = MainWindow.dThreshold3[0, 4, 10, 1];
            obj.dThreshold_u4A2 = MainWindow.dThreshold3[0, 4, 10, 2];
            obj.dThreshold_u4A3 = MainWindow.dThreshold3[0, 4, 10, 3];
            obj.dThreshold_u4A4 = MainWindow.dThreshold3[0, 4, 10, 4];
            obj.dThreshold_u4A5 = MainWindow.dThreshold3[0, 4, 10, 5];
            obj.dThreshold_u4A6 = MainWindow.dThreshold3[0, 4, 10, 6];
            obj.dThreshold_u4A7 = MainWindow.dThreshold3[0, 4, 10, 7];
            obj.dThreshold_u4A8 = MainWindow.dThreshold3[0, 4, 10, 8];
            obj.dThreshold_u4A9 = MainWindow.dThreshold3[0, 4, 10, 9];

            obj.dThreshold_l4A0 = MainWindow.dThreshold3[1, 4, 10, 0];
            obj.dThreshold_l4A1 = MainWindow.dThreshold3[1, 4, 10, 1];
            obj.dThreshold_l4A2 = MainWindow.dThreshold3[1, 4, 10, 2];
            obj.dThreshold_l4A3 = MainWindow.dThreshold3[1, 4, 10, 3];
            obj.dThreshold_l4A4 = MainWindow.dThreshold3[1, 4, 10, 4];
            obj.dThreshold_l4A5 = MainWindow.dThreshold3[1, 4, 10, 5];
            obj.dThreshold_l4A6 = MainWindow.dThreshold3[1, 4, 10, 6];
            obj.dThreshold_l4A7 = MainWindow.dThreshold3[1, 4, 10, 7];
            obj.dThreshold_l4A8 = MainWindow.dThreshold3[1, 4, 10, 8];
            obj.dThreshold_l4A9 = MainWindow.dThreshold3[1, 4, 10, 9];

            //品種6
            //6-Stream1
            obj.dThreshold_u500 = MainWindow.dThreshold3[0, 5, 0, 0];
            obj.dThreshold_u501 = MainWindow.dThreshold3[0, 5, 0, 1];
            obj.dThreshold_u502 = MainWindow.dThreshold3[0, 5, 0, 2];
            obj.dThreshold_u503 = MainWindow.dThreshold3[0, 5, 0, 3];
            obj.dThreshold_u504 = MainWindow.dThreshold3[0, 5, 0, 4];
            obj.dThreshold_u505 = MainWindow.dThreshold3[0, 5, 0, 5];
            obj.dThreshold_u506 = MainWindow.dThreshold3[0, 5, 0, 6];
            obj.dThreshold_u507 = MainWindow.dThreshold3[0, 5, 0, 7];
            obj.dThreshold_u508 = MainWindow.dThreshold3[0, 5, 0, 8];
            obj.dThreshold_u509 = MainWindow.dThreshold3[0, 5, 0, 9];

            obj.dThreshold_l500 = MainWindow.dThreshold3[1, 5, 0, 0];
            obj.dThreshold_l501 = MainWindow.dThreshold3[1, 5, 0, 1];
            obj.dThreshold_l502 = MainWindow.dThreshold3[1, 5, 0, 2];
            obj.dThreshold_l503 = MainWindow.dThreshold3[1, 5, 0, 3];
            obj.dThreshold_l504 = MainWindow.dThreshold3[1, 5, 0, 4];
            obj.dThreshold_l505 = MainWindow.dThreshold3[1, 5, 0, 5];
            obj.dThreshold_l506 = MainWindow.dThreshold3[1, 5, 0, 6];
            obj.dThreshold_l507 = MainWindow.dThreshold3[1, 5, 0, 7];
            obj.dThreshold_l508 = MainWindow.dThreshold3[1, 5, 0, 8];
            obj.dThreshold_l509 = MainWindow.dThreshold3[1, 5, 0, 9];
            //6-Stream2
            obj.dThreshold_u510 = MainWindow.dThreshold3[0, 5, 1, 0];
            obj.dThreshold_u511 = MainWindow.dThreshold3[0, 5, 1, 1];
            obj.dThreshold_u512 = MainWindow.dThreshold3[0, 5, 1, 2];
            obj.dThreshold_u513 = MainWindow.dThreshold3[0, 5, 1, 3];
            obj.dThreshold_u514 = MainWindow.dThreshold3[0, 5, 1, 4];
            obj.dThreshold_u515 = MainWindow.dThreshold3[0, 5, 1, 5];
            obj.dThreshold_u516 = MainWindow.dThreshold3[0, 5, 1, 6];
            obj.dThreshold_u517 = MainWindow.dThreshold3[0, 5, 1, 7];
            obj.dThreshold_u518 = MainWindow.dThreshold3[0, 5, 1, 8];
            obj.dThreshold_u519 = MainWindow.dThreshold3[0, 5, 1, 9];

            obj.dThreshold_l510 = MainWindow.dThreshold3[1, 5, 1, 0];
            obj.dThreshold_l511 = MainWindow.dThreshold3[1, 5, 1, 1];
            obj.dThreshold_l512 = MainWindow.dThreshold3[1, 5, 1, 2];
            obj.dThreshold_l513 = MainWindow.dThreshold3[1, 5, 1, 3];
            obj.dThreshold_l514 = MainWindow.dThreshold3[1, 5, 1, 4];
            obj.dThreshold_l515 = MainWindow.dThreshold3[1, 5, 1, 5];
            obj.dThreshold_l516 = MainWindow.dThreshold3[1, 5, 1, 6];
            obj.dThreshold_l517 = MainWindow.dThreshold3[1, 5, 1, 7];
            obj.dThreshold_l518 = MainWindow.dThreshold3[1, 5, 1, 8];
            obj.dThreshold_l519 = MainWindow.dThreshold3[1, 5, 1, 9];
            //6-Stream3
            obj.dThreshold_u520 = MainWindow.dThreshold3[0, 5, 2, 0];
            obj.dThreshold_u521 = MainWindow.dThreshold3[0, 5, 2, 1];
            obj.dThreshold_u522 = MainWindow.dThreshold3[0, 5, 2, 2];
            obj.dThreshold_u523 = MainWindow.dThreshold3[0, 5, 2, 3];
            obj.dThreshold_u524 = MainWindow.dThreshold3[0, 5, 2, 4];
            obj.dThreshold_u525 = MainWindow.dThreshold3[0, 5, 2, 5];
            obj.dThreshold_u526 = MainWindow.dThreshold3[0, 5, 2, 6];
            obj.dThreshold_u527 = MainWindow.dThreshold3[0, 5, 2, 7];
            obj.dThreshold_u528 = MainWindow.dThreshold3[0, 5, 2, 8];
            obj.dThreshold_u529 = MainWindow.dThreshold3[0, 5, 2, 9];

            obj.dThreshold_l520 = MainWindow.dThreshold3[1, 5, 2, 0];
            obj.dThreshold_l521 = MainWindow.dThreshold3[1, 5, 2, 1];
            obj.dThreshold_l522 = MainWindow.dThreshold3[1, 5, 2, 2];
            obj.dThreshold_l523 = MainWindow.dThreshold3[1, 5, 2, 3];
            obj.dThreshold_l524 = MainWindow.dThreshold3[1, 5, 2, 4];
            obj.dThreshold_l525 = MainWindow.dThreshold3[1, 5, 2, 5];
            obj.dThreshold_l526 = MainWindow.dThreshold3[1, 5, 2, 6];
            obj.dThreshold_l527 = MainWindow.dThreshold3[1, 5, 2, 7];
            obj.dThreshold_l528 = MainWindow.dThreshold3[1, 5, 2, 8];
            obj.dThreshold_l529 = MainWindow.dThreshold3[1, 5, 2, 9];
            //6-Stream4
            obj.dThreshold_u530 = MainWindow.dThreshold3[0, 5, 3, 0];
            obj.dThreshold_u531 = MainWindow.dThreshold3[0, 5, 3, 1];
            obj.dThreshold_u532 = MainWindow.dThreshold3[0, 5, 3, 2];
            obj.dThreshold_u533 = MainWindow.dThreshold3[0, 5, 3, 3];
            obj.dThreshold_u534 = MainWindow.dThreshold3[0, 5, 3, 4];
            obj.dThreshold_u535 = MainWindow.dThreshold3[0, 5, 3, 5];
            obj.dThreshold_u536 = MainWindow.dThreshold3[0, 5, 3, 6];
            obj.dThreshold_u537 = MainWindow.dThreshold3[0, 5, 3, 7];
            obj.dThreshold_u538 = MainWindow.dThreshold3[0, 5, 3, 8];
            obj.dThreshold_u539 = MainWindow.dThreshold3[0, 5, 3, 9];

            obj.dThreshold_l530 = MainWindow.dThreshold3[1, 5, 3, 0];
            obj.dThreshold_l531 = MainWindow.dThreshold3[1, 5, 3, 1];
            obj.dThreshold_l532 = MainWindow.dThreshold3[1, 5, 3, 2];
            obj.dThreshold_l533 = MainWindow.dThreshold3[1, 5, 3, 3];
            obj.dThreshold_l534 = MainWindow.dThreshold3[1, 5, 3, 4];
            obj.dThreshold_l535 = MainWindow.dThreshold3[1, 5, 3, 5];
            obj.dThreshold_l536 = MainWindow.dThreshold3[1, 5, 3, 6];
            obj.dThreshold_l537 = MainWindow.dThreshold3[1, 5, 3, 7];
            obj.dThreshold_l538 = MainWindow.dThreshold3[1, 5, 3, 8];
            obj.dThreshold_l539 = MainWindow.dThreshold3[1, 5, 3, 9];
            //6-Stream5
            obj.dThreshold_u540 = MainWindow.dThreshold3[0, 5, 4, 0];
            obj.dThreshold_u541 = MainWindow.dThreshold3[0, 5, 4, 1];
            obj.dThreshold_u542 = MainWindow.dThreshold3[0, 5, 4, 2];
            obj.dThreshold_u543 = MainWindow.dThreshold3[0, 5, 4, 3];
            obj.dThreshold_u544 = MainWindow.dThreshold3[0, 5, 4, 4];
            obj.dThreshold_u545 = MainWindow.dThreshold3[0, 5, 4, 5];
            obj.dThreshold_u546 = MainWindow.dThreshold3[0, 5, 4, 6];
            obj.dThreshold_u547 = MainWindow.dThreshold3[0, 5, 4, 7];
            obj.dThreshold_u548 = MainWindow.dThreshold3[0, 5, 4, 8];
            obj.dThreshold_u549 = MainWindow.dThreshold3[0, 5, 4, 9];

            obj.dThreshold_l540 = MainWindow.dThreshold3[1, 5, 4, 0];
            obj.dThreshold_l541 = MainWindow.dThreshold3[1, 5, 4, 1];
            obj.dThreshold_l542 = MainWindow.dThreshold3[1, 5, 4, 2];
            obj.dThreshold_l543 = MainWindow.dThreshold3[1, 5, 4, 3];
            obj.dThreshold_l544 = MainWindow.dThreshold3[1, 5, 4, 4];
            obj.dThreshold_l545 = MainWindow.dThreshold3[1, 5, 4, 5];
            obj.dThreshold_l546 = MainWindow.dThreshold3[1, 5, 4, 6];
            obj.dThreshold_l547 = MainWindow.dThreshold3[1, 5, 4, 7];
            obj.dThreshold_l548 = MainWindow.dThreshold3[1, 5, 4, 8];
            obj.dThreshold_l549 = MainWindow.dThreshold3[1, 5, 4, 9];
            //6-Stream6
            obj.dThreshold_u550 = MainWindow.dThreshold3[0, 5, 5, 0];
            obj.dThreshold_u551 = MainWindow.dThreshold3[0, 5, 5, 1];
            obj.dThreshold_u552 = MainWindow.dThreshold3[0, 5, 5, 2];
            obj.dThreshold_u553 = MainWindow.dThreshold3[0, 5, 5, 3];
            obj.dThreshold_u554 = MainWindow.dThreshold3[0, 5, 5, 4];
            obj.dThreshold_u555 = MainWindow.dThreshold3[0, 5, 5, 5];
            obj.dThreshold_u556 = MainWindow.dThreshold3[0, 5, 5, 6];
            obj.dThreshold_u557 = MainWindow.dThreshold3[0, 5, 5, 7];
            obj.dThreshold_u558 = MainWindow.dThreshold3[0, 5, 5, 8];
            obj.dThreshold_u559 = MainWindow.dThreshold3[0, 5, 5, 9];

            obj.dThreshold_l550 = MainWindow.dThreshold3[1, 5, 5, 0];
            obj.dThreshold_l551 = MainWindow.dThreshold3[1, 5, 5, 1];
            obj.dThreshold_l552 = MainWindow.dThreshold3[1, 5, 5, 2];
            obj.dThreshold_l553 = MainWindow.dThreshold3[1, 5, 5, 3];
            obj.dThreshold_l554 = MainWindow.dThreshold3[1, 5, 5, 4];
            obj.dThreshold_l555 = MainWindow.dThreshold3[1, 5, 5, 5];
            obj.dThreshold_l556 = MainWindow.dThreshold3[1, 5, 5, 6];
            obj.dThreshold_l557 = MainWindow.dThreshold3[1, 5, 5, 7];
            obj.dThreshold_l558 = MainWindow.dThreshold3[1, 5, 5, 8];
            obj.dThreshold_l559 = MainWindow.dThreshold3[1, 5, 5, 9];
            //6-Stream7
            obj.dThreshold_u560 = MainWindow.dThreshold3[0, 5, 6, 0];
            obj.dThreshold_u561 = MainWindow.dThreshold3[0, 5, 6, 1];
            obj.dThreshold_u562 = MainWindow.dThreshold3[0, 5, 6, 2];
            obj.dThreshold_u563 = MainWindow.dThreshold3[0, 5, 6, 3];
            obj.dThreshold_u564 = MainWindow.dThreshold3[0, 5, 6, 4];
            obj.dThreshold_u565 = MainWindow.dThreshold3[0, 5, 6, 5];
            obj.dThreshold_u566 = MainWindow.dThreshold3[0, 5, 6, 6];
            obj.dThreshold_u567 = MainWindow.dThreshold3[0, 5, 6, 7];
            obj.dThreshold_u568 = MainWindow.dThreshold3[0, 5, 6, 8];
            obj.dThreshold_u569 = MainWindow.dThreshold3[0, 5, 6, 9];

            obj.dThreshold_l560 = MainWindow.dThreshold3[1, 5, 6, 0];
            obj.dThreshold_l561 = MainWindow.dThreshold3[1, 5, 6, 1];
            obj.dThreshold_l562 = MainWindow.dThreshold3[1, 5, 6, 2];
            obj.dThreshold_l563 = MainWindow.dThreshold3[1, 5, 6, 3];
            obj.dThreshold_l564 = MainWindow.dThreshold3[1, 5, 6, 4];
            obj.dThreshold_l565 = MainWindow.dThreshold3[1, 5, 6, 5];
            obj.dThreshold_l566 = MainWindow.dThreshold3[1, 5, 6, 6];
            obj.dThreshold_l567 = MainWindow.dThreshold3[1, 5, 6, 7];
            obj.dThreshold_l568 = MainWindow.dThreshold3[1, 5, 6, 8];
            obj.dThreshold_l569 = MainWindow.dThreshold3[1, 5, 6, 9];
            //6-Stream8
            obj.dThreshold_u570 = MainWindow.dThreshold3[0, 5, 7, 0];
            obj.dThreshold_u571 = MainWindow.dThreshold3[0, 5, 7, 1];
            obj.dThreshold_u572 = MainWindow.dThreshold3[0, 5, 7, 2];
            obj.dThreshold_u573 = MainWindow.dThreshold3[0, 5, 7, 3];
            obj.dThreshold_u574 = MainWindow.dThreshold3[0, 5, 7, 4];
            obj.dThreshold_u575 = MainWindow.dThreshold3[0, 5, 7, 5];
            obj.dThreshold_u576 = MainWindow.dThreshold3[0, 5, 7, 6];
            obj.dThreshold_u577 = MainWindow.dThreshold3[0, 5, 7, 7];
            obj.dThreshold_u578 = MainWindow.dThreshold3[0, 5, 7, 8];
            obj.dThreshold_u579 = MainWindow.dThreshold3[0, 5, 7, 9];

            obj.dThreshold_l570 = MainWindow.dThreshold3[1, 5, 7, 0];
            obj.dThreshold_l571 = MainWindow.dThreshold3[1, 5, 7, 1];
            obj.dThreshold_l572 = MainWindow.dThreshold3[1, 5, 7, 2];
            obj.dThreshold_l573 = MainWindow.dThreshold3[1, 5, 7, 3];
            obj.dThreshold_l574 = MainWindow.dThreshold3[1, 5, 7, 4];
            obj.dThreshold_l575 = MainWindow.dThreshold3[1, 5, 7, 5];
            obj.dThreshold_l576 = MainWindow.dThreshold3[1, 5, 7, 6];
            obj.dThreshold_l577 = MainWindow.dThreshold3[1, 5, 7, 7];
            obj.dThreshold_l578 = MainWindow.dThreshold3[1, 5, 7, 8];
            obj.dThreshold_l579 = MainWindow.dThreshold3[1, 5, 7, 9];
            //6-Stream9
            obj.dThreshold_u580 = MainWindow.dThreshold3[0, 5, 8, 0];
            obj.dThreshold_u581 = MainWindow.dThreshold3[0, 5, 8, 1];
            obj.dThreshold_u582 = MainWindow.dThreshold3[0, 5, 8, 2];
            obj.dThreshold_u583 = MainWindow.dThreshold3[0, 5, 8, 3];
            obj.dThreshold_u584 = MainWindow.dThreshold3[0, 5, 8, 4];
            obj.dThreshold_u585 = MainWindow.dThreshold3[0, 5, 8, 5];
            obj.dThreshold_u586 = MainWindow.dThreshold3[0, 5, 8, 6];
            obj.dThreshold_u587 = MainWindow.dThreshold3[0, 5, 8, 7];
            obj.dThreshold_u588 = MainWindow.dThreshold3[0, 5, 8, 8];
            obj.dThreshold_u589 = MainWindow.dThreshold3[0, 5, 8, 9];

            obj.dThreshold_l580 = MainWindow.dThreshold3[1, 5, 8, 0];
            obj.dThreshold_l581 = MainWindow.dThreshold3[1, 5, 8, 1];
            obj.dThreshold_l582 = MainWindow.dThreshold3[1, 5, 8, 2];
            obj.dThreshold_l583 = MainWindow.dThreshold3[1, 5, 8, 3];
            obj.dThreshold_l584 = MainWindow.dThreshold3[1, 5, 8, 4];
            obj.dThreshold_l585 = MainWindow.dThreshold3[1, 5, 8, 5];
            obj.dThreshold_l586 = MainWindow.dThreshold3[1, 5, 8, 6];
            obj.dThreshold_l587 = MainWindow.dThreshold3[1, 5, 8, 7];
            obj.dThreshold_l588 = MainWindow.dThreshold3[1, 5, 8, 8];
            obj.dThreshold_l589 = MainWindow.dThreshold3[1, 5, 8, 9];
            //6-Stream10
            obj.dThreshold_u590 = MainWindow.dThreshold3[0, 5, 9, 0];
            obj.dThreshold_u591 = MainWindow.dThreshold3[0, 5, 9, 1];
            obj.dThreshold_u592 = MainWindow.dThreshold3[0, 5, 9, 2];
            obj.dThreshold_u593 = MainWindow.dThreshold3[0, 5, 9, 3];
            obj.dThreshold_u594 = MainWindow.dThreshold3[0, 5, 9, 4];
            obj.dThreshold_u595 = MainWindow.dThreshold3[0, 5, 9, 5];
            obj.dThreshold_u596 = MainWindow.dThreshold3[0, 5, 9, 6];
            obj.dThreshold_u597 = MainWindow.dThreshold3[0, 5, 9, 7];
            obj.dThreshold_u598 = MainWindow.dThreshold3[0, 5, 9, 8];
            obj.dThreshold_u599 = MainWindow.dThreshold3[0, 5, 9, 9];

            obj.dThreshold_l590 = MainWindow.dThreshold3[1, 5, 9, 0];
            obj.dThreshold_l591 = MainWindow.dThreshold3[1, 5, 9, 1];
            obj.dThreshold_l592 = MainWindow.dThreshold3[1, 5, 9, 2];
            obj.dThreshold_l593 = MainWindow.dThreshold3[1, 5, 9, 3];
            obj.dThreshold_l594 = MainWindow.dThreshold3[1, 5, 9, 4];
            obj.dThreshold_l595 = MainWindow.dThreshold3[1, 5, 9, 5];
            obj.dThreshold_l596 = MainWindow.dThreshold3[1, 5, 9, 6];
            obj.dThreshold_l597 = MainWindow.dThreshold3[1, 5, 9, 7];
            obj.dThreshold_l598 = MainWindow.dThreshold3[1, 5, 9, 8];
            obj.dThreshold_l599 = MainWindow.dThreshold3[1, 5, 9, 9];
            //6-Stream11
            obj.dThreshold_u5A0 = MainWindow.dThreshold3[0, 5, 10, 0];
            obj.dThreshold_u5A1 = MainWindow.dThreshold3[0, 5, 10, 1];
            obj.dThreshold_u5A2 = MainWindow.dThreshold3[0, 5, 10, 2];
            obj.dThreshold_u5A3 = MainWindow.dThreshold3[0, 5, 10, 3];
            obj.dThreshold_u5A4 = MainWindow.dThreshold3[0, 5, 10, 4];
            obj.dThreshold_u5A5 = MainWindow.dThreshold3[0, 5, 10, 5];
            obj.dThreshold_u5A6 = MainWindow.dThreshold3[0, 5, 10, 6];
            obj.dThreshold_u5A7 = MainWindow.dThreshold3[0, 5, 10, 7];
            obj.dThreshold_u5A8 = MainWindow.dThreshold3[0, 5, 10, 8];
            obj.dThreshold_u5A9 = MainWindow.dThreshold3[0, 5, 10, 9];

            obj.dThreshold_l5A0 = MainWindow.dThreshold3[1, 5, 10, 0];
            obj.dThreshold_l5A1 = MainWindow.dThreshold3[1, 5, 10, 1];
            obj.dThreshold_l5A2 = MainWindow.dThreshold3[1, 5, 10, 2];
            obj.dThreshold_l5A3 = MainWindow.dThreshold3[1, 5, 10, 3];
            obj.dThreshold_l5A4 = MainWindow.dThreshold3[1, 5, 10, 4];
            obj.dThreshold_l5A5 = MainWindow.dThreshold3[1, 5, 10, 5];
            obj.dThreshold_l5A6 = MainWindow.dThreshold3[1, 5, 10, 6];
            obj.dThreshold_l5A7 = MainWindow.dThreshold3[1, 5, 10, 7];
            obj.dThreshold_l5A8 = MainWindow.dThreshold3[1, 5, 10, 8];
            obj.dThreshold_l5A9 = MainWindow.dThreshold3[1, 5, 10, 9];

            //品種7
            //7-Stream1
            obj.dThreshold_u600 = MainWindow.dThreshold3[0, 6, 0, 0];
            obj.dThreshold_u601 = MainWindow.dThreshold3[0, 6, 0, 1];
            obj.dThreshold_u602 = MainWindow.dThreshold3[0, 6, 0, 2];
            obj.dThreshold_u603 = MainWindow.dThreshold3[0, 6, 0, 3];
            obj.dThreshold_u604 = MainWindow.dThreshold3[0, 6, 0, 4];
            obj.dThreshold_u605 = MainWindow.dThreshold3[0, 6, 0, 5];
            obj.dThreshold_u606 = MainWindow.dThreshold3[0, 6, 0, 6];
            obj.dThreshold_u607 = MainWindow.dThreshold3[0, 6, 0, 7];
            obj.dThreshold_u608 = MainWindow.dThreshold3[0, 6, 0, 8];
            obj.dThreshold_u609 = MainWindow.dThreshold3[0, 6, 0, 9];

            obj.dThreshold_l600 = MainWindow.dThreshold3[1, 6, 0, 0];
            obj.dThreshold_l601 = MainWindow.dThreshold3[1, 6, 0, 1];
            obj.dThreshold_l602 = MainWindow.dThreshold3[1, 6, 0, 2];
            obj.dThreshold_l603 = MainWindow.dThreshold3[1, 6, 0, 3];
            obj.dThreshold_l604 = MainWindow.dThreshold3[1, 6, 0, 4];
            obj.dThreshold_l605 = MainWindow.dThreshold3[1, 6, 0, 5];
            obj.dThreshold_l606 = MainWindow.dThreshold3[1, 6, 0, 6];
            obj.dThreshold_l607 = MainWindow.dThreshold3[1, 6, 0, 7];
            obj.dThreshold_l608 = MainWindow.dThreshold3[1, 6, 0, 8];
            obj.dThreshold_l609 = MainWindow.dThreshold3[1, 6, 0, 9];
            //7-Stream2
            obj.dThreshold_u610 = MainWindow.dThreshold3[0, 6, 1, 0];
            obj.dThreshold_u611 = MainWindow.dThreshold3[0, 6, 1, 1];
            obj.dThreshold_u612 = MainWindow.dThreshold3[0, 6, 1, 2];
            obj.dThreshold_u613 = MainWindow.dThreshold3[0, 6, 1, 3];
            obj.dThreshold_u614 = MainWindow.dThreshold3[0, 6, 1, 4];
            obj.dThreshold_u615 = MainWindow.dThreshold3[0, 6, 1, 5];
            obj.dThreshold_u616 = MainWindow.dThreshold3[0, 6, 1, 6];
            obj.dThreshold_u617 = MainWindow.dThreshold3[0, 6, 1, 7];
            obj.dThreshold_u618 = MainWindow.dThreshold3[0, 6, 1, 8];
            obj.dThreshold_u619 = MainWindow.dThreshold3[0, 6, 1, 9];

            obj.dThreshold_l610 = MainWindow.dThreshold3[1, 6, 1, 0];
            obj.dThreshold_l611 = MainWindow.dThreshold3[1, 6, 1, 1];
            obj.dThreshold_l612 = MainWindow.dThreshold3[1, 6, 1, 2];
            obj.dThreshold_l613 = MainWindow.dThreshold3[1, 6, 1, 3];
            obj.dThreshold_l614 = MainWindow.dThreshold3[1, 6, 1, 4];
            obj.dThreshold_l615 = MainWindow.dThreshold3[1, 6, 1, 5];
            obj.dThreshold_l616 = MainWindow.dThreshold3[1, 6, 1, 6];
            obj.dThreshold_l617 = MainWindow.dThreshold3[1, 6, 1, 7];
            obj.dThreshold_l618 = MainWindow.dThreshold3[1, 6, 1, 8];
            obj.dThreshold_l619 = MainWindow.dThreshold3[1, 6, 1, 9];
            //7-Stream3
            obj.dThreshold_u620 = MainWindow.dThreshold3[0, 6, 2, 0];
            obj.dThreshold_u621 = MainWindow.dThreshold3[0, 6, 2, 1];
            obj.dThreshold_u622 = MainWindow.dThreshold3[0, 6, 2, 2];
            obj.dThreshold_u623 = MainWindow.dThreshold3[0, 6, 2, 3];
            obj.dThreshold_u624 = MainWindow.dThreshold3[0, 6, 2, 4];
            obj.dThreshold_u625 = MainWindow.dThreshold3[0, 6, 2, 5];
            obj.dThreshold_u626 = MainWindow.dThreshold3[0, 6, 2, 6];
            obj.dThreshold_u627 = MainWindow.dThreshold3[0, 6, 2, 7];
            obj.dThreshold_u628 = MainWindow.dThreshold3[0, 6, 2, 8];
            obj.dThreshold_u629 = MainWindow.dThreshold3[0, 6, 2, 9];

            obj.dThreshold_l620 = MainWindow.dThreshold3[1, 6, 2, 0];
            obj.dThreshold_l621 = MainWindow.dThreshold3[1, 6, 2, 1];
            obj.dThreshold_l622 = MainWindow.dThreshold3[1, 6, 2, 2];
            obj.dThreshold_l623 = MainWindow.dThreshold3[1, 6, 2, 3];
            obj.dThreshold_l624 = MainWindow.dThreshold3[1, 6, 2, 4];
            obj.dThreshold_l625 = MainWindow.dThreshold3[1, 6, 2, 5];
            obj.dThreshold_l626 = MainWindow.dThreshold3[1, 6, 2, 6];
            obj.dThreshold_l627 = MainWindow.dThreshold3[1, 6, 2, 7];
            obj.dThreshold_l628 = MainWindow.dThreshold3[1, 6, 2, 8];
            obj.dThreshold_l629 = MainWindow.dThreshold3[1, 6, 2, 9];
            //7-Stream4
            obj.dThreshold_u630 = MainWindow.dThreshold3[0, 6, 3, 0];
            obj.dThreshold_u631 = MainWindow.dThreshold3[0, 6, 3, 1];
            obj.dThreshold_u632 = MainWindow.dThreshold3[0, 6, 3, 2];
            obj.dThreshold_u633 = MainWindow.dThreshold3[0, 6, 3, 3];
            obj.dThreshold_u634 = MainWindow.dThreshold3[0, 6, 3, 4];
            obj.dThreshold_u635 = MainWindow.dThreshold3[0, 6, 3, 5];
            obj.dThreshold_u636 = MainWindow.dThreshold3[0, 6, 3, 6];
            obj.dThreshold_u637 = MainWindow.dThreshold3[0, 6, 3, 7];
            obj.dThreshold_u638 = MainWindow.dThreshold3[0, 6, 3, 8];
            obj.dThreshold_u639 = MainWindow.dThreshold3[0, 6, 3, 9];

            obj.dThreshold_l630 = MainWindow.dThreshold3[1, 6, 3, 0];
            obj.dThreshold_l631 = MainWindow.dThreshold3[1, 6, 3, 1];
            obj.dThreshold_l632 = MainWindow.dThreshold3[1, 6, 3, 2];
            obj.dThreshold_l633 = MainWindow.dThreshold3[1, 6, 3, 3];
            obj.dThreshold_l634 = MainWindow.dThreshold3[1, 6, 3, 4];
            obj.dThreshold_l635 = MainWindow.dThreshold3[1, 6, 3, 5];
            obj.dThreshold_l636 = MainWindow.dThreshold3[1, 6, 3, 6];
            obj.dThreshold_l637 = MainWindow.dThreshold3[1, 6, 3, 7];
            obj.dThreshold_l638 = MainWindow.dThreshold3[1, 6, 3, 8];
            obj.dThreshold_l639 = MainWindow.dThreshold3[1, 6, 3, 9];
            //7-Stream5
            obj.dThreshold_u640 = MainWindow.dThreshold3[0, 6, 4, 0];
            obj.dThreshold_u641 = MainWindow.dThreshold3[0, 6, 4, 1];
            obj.dThreshold_u642 = MainWindow.dThreshold3[0, 6, 4, 2];
            obj.dThreshold_u643 = MainWindow.dThreshold3[0, 6, 4, 3];
            obj.dThreshold_u644 = MainWindow.dThreshold3[0, 6, 4, 4];
            obj.dThreshold_u645 = MainWindow.dThreshold3[0, 6, 4, 5];
            obj.dThreshold_u646 = MainWindow.dThreshold3[0, 6, 4, 6];
            obj.dThreshold_u647 = MainWindow.dThreshold3[0, 6, 4, 7];
            obj.dThreshold_u648 = MainWindow.dThreshold3[0, 6, 4, 8];
            obj.dThreshold_u649 = MainWindow.dThreshold3[0, 6, 4, 9];

            obj.dThreshold_l640 = MainWindow.dThreshold3[1, 6, 4, 0];
            obj.dThreshold_l641 = MainWindow.dThreshold3[1, 6, 4, 1];
            obj.dThreshold_l642 = MainWindow.dThreshold3[1, 6, 4, 2];
            obj.dThreshold_l643 = MainWindow.dThreshold3[1, 6, 4, 3];
            obj.dThreshold_l644 = MainWindow.dThreshold3[1, 6, 4, 4];
            obj.dThreshold_l645 = MainWindow.dThreshold3[1, 6, 4, 5];
            obj.dThreshold_l646 = MainWindow.dThreshold3[1, 6, 4, 6];
            obj.dThreshold_l647 = MainWindow.dThreshold3[1, 6, 4, 7];
            obj.dThreshold_l648 = MainWindow.dThreshold3[1, 6, 4, 8];
            obj.dThreshold_l649 = MainWindow.dThreshold3[1, 6, 4, 9];
            //7-Stream6
            obj.dThreshold_u650 = MainWindow.dThreshold3[0, 6, 5, 0];
            obj.dThreshold_u651 = MainWindow.dThreshold3[0, 6, 5, 1];
            obj.dThreshold_u652 = MainWindow.dThreshold3[0, 6, 5, 2];
            obj.dThreshold_u653 = MainWindow.dThreshold3[0, 6, 5, 3];
            obj.dThreshold_u654 = MainWindow.dThreshold3[0, 6, 5, 4];
            obj.dThreshold_u655 = MainWindow.dThreshold3[0, 6, 5, 5];
            obj.dThreshold_u656 = MainWindow.dThreshold3[0, 6, 5, 6];
            obj.dThreshold_u657 = MainWindow.dThreshold3[0, 6, 5, 7];
            obj.dThreshold_u658 = MainWindow.dThreshold3[0, 6, 5, 8];
            obj.dThreshold_u659 = MainWindow.dThreshold3[0, 6, 5, 9];

            obj.dThreshold_l650 = MainWindow.dThreshold3[1, 6, 5, 0];
            obj.dThreshold_l651 = MainWindow.dThreshold3[1, 6, 5, 1];
            obj.dThreshold_l652 = MainWindow.dThreshold3[1, 6, 5, 2];
            obj.dThreshold_l653 = MainWindow.dThreshold3[1, 6, 5, 3];
            obj.dThreshold_l654 = MainWindow.dThreshold3[1, 6, 5, 4];
            obj.dThreshold_l655 = MainWindow.dThreshold3[1, 6, 5, 5];
            obj.dThreshold_l656 = MainWindow.dThreshold3[1, 6, 5, 6];
            obj.dThreshold_l657 = MainWindow.dThreshold3[1, 6, 5, 7];
            obj.dThreshold_l658 = MainWindow.dThreshold3[1, 6, 5, 8];
            obj.dThreshold_l659 = MainWindow.dThreshold3[1, 6, 5, 9];
            //7-Stream7
            obj.dThreshold_u660 = MainWindow.dThreshold3[0, 6, 6, 0];
            obj.dThreshold_u661 = MainWindow.dThreshold3[0, 6, 6, 1];
            obj.dThreshold_u662 = MainWindow.dThreshold3[0, 6, 6, 2];
            obj.dThreshold_u663 = MainWindow.dThreshold3[0, 6, 6, 3];
            obj.dThreshold_u664 = MainWindow.dThreshold3[0, 6, 6, 4];
            obj.dThreshold_u665 = MainWindow.dThreshold3[0, 6, 6, 5];
            obj.dThreshold_u666 = MainWindow.dThreshold3[0, 6, 6, 6];
            obj.dThreshold_u667 = MainWindow.dThreshold3[0, 6, 6, 7];
            obj.dThreshold_u668 = MainWindow.dThreshold3[0, 6, 6, 8];
            obj.dThreshold_u669 = MainWindow.dThreshold3[0, 6, 6, 9];

            obj.dThreshold_l660 = MainWindow.dThreshold3[1, 6, 6, 0];
            obj.dThreshold_l661 = MainWindow.dThreshold3[1, 6, 6, 1];
            obj.dThreshold_l662 = MainWindow.dThreshold3[1, 6, 6, 2];
            obj.dThreshold_l663 = MainWindow.dThreshold3[1, 6, 6, 3];
            obj.dThreshold_l664 = MainWindow.dThreshold3[1, 6, 6, 4];
            obj.dThreshold_l665 = MainWindow.dThreshold3[1, 6, 6, 5];
            obj.dThreshold_l666 = MainWindow.dThreshold3[1, 6, 6, 6];
            obj.dThreshold_l667 = MainWindow.dThreshold3[1, 6, 6, 7];
            obj.dThreshold_l668 = MainWindow.dThreshold3[1, 6, 6, 8];
            obj.dThreshold_l669 = MainWindow.dThreshold3[1, 6, 6, 9];
            //7-Stream8
            obj.dThreshold_u670 = MainWindow.dThreshold3[0, 6, 7, 0];
            obj.dThreshold_u671 = MainWindow.dThreshold3[0, 6, 7, 1];
            obj.dThreshold_u672 = MainWindow.dThreshold3[0, 6, 7, 2];
            obj.dThreshold_u673 = MainWindow.dThreshold3[0, 6, 7, 3];
            obj.dThreshold_u674 = MainWindow.dThreshold3[0, 6, 7, 4];
            obj.dThreshold_u675 = MainWindow.dThreshold3[0, 6, 7, 5];
            obj.dThreshold_u676 = MainWindow.dThreshold3[0, 6, 7, 6];
            obj.dThreshold_u677 = MainWindow.dThreshold3[0, 6, 7, 7];
            obj.dThreshold_u678 = MainWindow.dThreshold3[0, 6, 7, 8];
            obj.dThreshold_u679 = MainWindow.dThreshold3[0, 6, 7, 9];

            obj.dThreshold_l670 = MainWindow.dThreshold3[1, 6, 7, 0];
            obj.dThreshold_l671 = MainWindow.dThreshold3[1, 6, 7, 1];
            obj.dThreshold_l672 = MainWindow.dThreshold3[1, 6, 7, 2];
            obj.dThreshold_l673 = MainWindow.dThreshold3[1, 6, 7, 3];
            obj.dThreshold_l674 = MainWindow.dThreshold3[1, 6, 7, 4];
            obj.dThreshold_l675 = MainWindow.dThreshold3[1, 6, 7, 5];
            obj.dThreshold_l676 = MainWindow.dThreshold3[1, 6, 7, 6];
            obj.dThreshold_l677 = MainWindow.dThreshold3[1, 6, 7, 7];
            obj.dThreshold_l678 = MainWindow.dThreshold3[1, 6, 7, 8];
            obj.dThreshold_l679 = MainWindow.dThreshold3[1, 6, 7, 9];
            //7-Stream9
            obj.dThreshold_u680 = MainWindow.dThreshold3[0, 6, 8, 0];
            obj.dThreshold_u681 = MainWindow.dThreshold3[0, 6, 8, 1];
            obj.dThreshold_u682 = MainWindow.dThreshold3[0, 6, 8, 2];
            obj.dThreshold_u683 = MainWindow.dThreshold3[0, 6, 8, 3];
            obj.dThreshold_u684 = MainWindow.dThreshold3[0, 6, 8, 4];
            obj.dThreshold_u685 = MainWindow.dThreshold3[0, 6, 8, 5];
            obj.dThreshold_u686 = MainWindow.dThreshold3[0, 6, 8, 6];
            obj.dThreshold_u687 = MainWindow.dThreshold3[0, 6, 8, 7];
            obj.dThreshold_u688 = MainWindow.dThreshold3[0, 6, 8, 8];
            obj.dThreshold_u689 = MainWindow.dThreshold3[0, 6, 8, 9];

            obj.dThreshold_l680 = MainWindow.dThreshold3[1, 6, 8, 0];
            obj.dThreshold_l681 = MainWindow.dThreshold3[1, 6, 8, 1];
            obj.dThreshold_l682 = MainWindow.dThreshold3[1, 6, 8, 2];
            obj.dThreshold_l683 = MainWindow.dThreshold3[1, 6, 8, 3];
            obj.dThreshold_l684 = MainWindow.dThreshold3[1, 6, 8, 4];
            obj.dThreshold_l685 = MainWindow.dThreshold3[1, 6, 8, 5];
            obj.dThreshold_l686 = MainWindow.dThreshold3[1, 6, 8, 6];
            obj.dThreshold_l687 = MainWindow.dThreshold3[1, 6, 8, 7];
            obj.dThreshold_l688 = MainWindow.dThreshold3[1, 6, 8, 8];
            obj.dThreshold_l689 = MainWindow.dThreshold3[1, 6, 8, 9];
            //7-Stream10
            obj.dThreshold_u690 = MainWindow.dThreshold3[0, 6, 9, 0];
            obj.dThreshold_u691 = MainWindow.dThreshold3[0, 6, 9, 1];
            obj.dThreshold_u692 = MainWindow.dThreshold3[0, 6, 9, 2];
            obj.dThreshold_u693 = MainWindow.dThreshold3[0, 6, 9, 3];
            obj.dThreshold_u694 = MainWindow.dThreshold3[0, 6, 9, 4];
            obj.dThreshold_u695 = MainWindow.dThreshold3[0, 6, 9, 5];
            obj.dThreshold_u696 = MainWindow.dThreshold3[0, 6, 9, 6];
            obj.dThreshold_u697 = MainWindow.dThreshold3[0, 6, 9, 7];
            obj.dThreshold_u698 = MainWindow.dThreshold3[0, 6, 9, 8];
            obj.dThreshold_u699 = MainWindow.dThreshold3[0, 6, 9, 9];

            obj.dThreshold_l690 = MainWindow.dThreshold3[1, 6, 9, 0];
            obj.dThreshold_l691 = MainWindow.dThreshold3[1, 6, 9, 1];
            obj.dThreshold_l692 = MainWindow.dThreshold3[1, 6, 9, 2];
            obj.dThreshold_l693 = MainWindow.dThreshold3[1, 6, 9, 3];
            obj.dThreshold_l694 = MainWindow.dThreshold3[1, 6, 9, 4];
            obj.dThreshold_l695 = MainWindow.dThreshold3[1, 6, 9, 5];
            obj.dThreshold_l696 = MainWindow.dThreshold3[1, 6, 9, 6];
            obj.dThreshold_l697 = MainWindow.dThreshold3[1, 6, 9, 7];
            obj.dThreshold_l698 = MainWindow.dThreshold3[1, 6, 9, 8];
            obj.dThreshold_l699 = MainWindow.dThreshold3[1, 6, 9, 9];
            //7-Stream11
            obj.dThreshold_u6A0 = MainWindow.dThreshold3[0, 6, 10, 0];
            obj.dThreshold_u6A1 = MainWindow.dThreshold3[0, 6, 10, 1];
            obj.dThreshold_u6A2 = MainWindow.dThreshold3[0, 6, 10, 2];
            obj.dThreshold_u6A3 = MainWindow.dThreshold3[0, 6, 10, 3];
            obj.dThreshold_u6A4 = MainWindow.dThreshold3[0, 6, 10, 4];
            obj.dThreshold_u6A5 = MainWindow.dThreshold3[0, 6, 10, 5];
            obj.dThreshold_u6A6 = MainWindow.dThreshold3[0, 6, 10, 6];
            obj.dThreshold_u6A7 = MainWindow.dThreshold3[0, 6, 10, 7];
            obj.dThreshold_u6A8 = MainWindow.dThreshold3[0, 6, 10, 8];
            obj.dThreshold_u6A9 = MainWindow.dThreshold3[0, 6, 10, 9];

            obj.dThreshold_l6A0 = MainWindow.dThreshold3[1, 6, 10, 0];
            obj.dThreshold_l6A1 = MainWindow.dThreshold3[1, 6, 10, 1];
            obj.dThreshold_l6A2 = MainWindow.dThreshold3[1, 6, 10, 2];
            obj.dThreshold_l6A3 = MainWindow.dThreshold3[1, 6, 10, 3];
            obj.dThreshold_l6A4 = MainWindow.dThreshold3[1, 6, 10, 4];
            obj.dThreshold_l6A5 = MainWindow.dThreshold3[1, 6, 10, 5];
            obj.dThreshold_l6A6 = MainWindow.dThreshold3[1, 6, 10, 6];
            obj.dThreshold_l6A7 = MainWindow.dThreshold3[1, 6, 10, 7];
            obj.dThreshold_l6A8 = MainWindow.dThreshold3[1, 6, 10, 8];
            obj.dThreshold_l6A9 = MainWindow.dThreshold3[1, 6, 10, 9];

            //品種8
            //8-Stream1
            obj.dThreshold_u700 = MainWindow.dThreshold3[0, 7, 0, 0];
            obj.dThreshold_u701 = MainWindow.dThreshold3[0, 7, 0, 1];
            obj.dThreshold_u702 = MainWindow.dThreshold3[0, 7, 0, 2];
            obj.dThreshold_u703 = MainWindow.dThreshold3[0, 7, 0, 3];
            obj.dThreshold_u704 = MainWindow.dThreshold3[0, 7, 0, 4];
            obj.dThreshold_u705 = MainWindow.dThreshold3[0, 7, 0, 5];
            obj.dThreshold_u706 = MainWindow.dThreshold3[0, 7, 0, 6];
            obj.dThreshold_u707 = MainWindow.dThreshold3[0, 7, 0, 7];
            obj.dThreshold_u708 = MainWindow.dThreshold3[0, 7, 0, 8];
            obj.dThreshold_u709 = MainWindow.dThreshold3[0, 7, 0, 9];

            obj.dThreshold_l700 = MainWindow.dThreshold3[1, 7, 0, 0];
            obj.dThreshold_l701 = MainWindow.dThreshold3[1, 7, 0, 1];
            obj.dThreshold_l702 = MainWindow.dThreshold3[1, 7, 0, 2];
            obj.dThreshold_l703 = MainWindow.dThreshold3[1, 7, 0, 3];
            obj.dThreshold_l704 = MainWindow.dThreshold3[1, 7, 0, 4];
            obj.dThreshold_l705 = MainWindow.dThreshold3[1, 7, 0, 5];
            obj.dThreshold_l706 = MainWindow.dThreshold3[1, 7, 0, 6];
            obj.dThreshold_l707 = MainWindow.dThreshold3[1, 7, 0, 7];
            obj.dThreshold_l708 = MainWindow.dThreshold3[1, 7, 0, 8];
            obj.dThreshold_l709 = MainWindow.dThreshold3[1, 7, 0, 9];
            //8-Stream2
            obj.dThreshold_u710 = MainWindow.dThreshold3[0, 7, 1, 0];
            obj.dThreshold_u711 = MainWindow.dThreshold3[0, 7, 1, 1];
            obj.dThreshold_u712 = MainWindow.dThreshold3[0, 7, 1, 2];
            obj.dThreshold_u713 = MainWindow.dThreshold3[0, 7, 1, 3];
            obj.dThreshold_u714 = MainWindow.dThreshold3[0, 7, 1, 4];
            obj.dThreshold_u715 = MainWindow.dThreshold3[0, 7, 1, 5];
            obj.dThreshold_u716 = MainWindow.dThreshold3[0, 7, 1, 6];
            obj.dThreshold_u717 = MainWindow.dThreshold3[0, 7, 1, 7];
            obj.dThreshold_u718 = MainWindow.dThreshold3[0, 7, 1, 8];
            obj.dThreshold_u719 = MainWindow.dThreshold3[0, 7, 1, 9];

            obj.dThreshold_l710 = MainWindow.dThreshold3[1, 7, 1, 0];
            obj.dThreshold_l711 = MainWindow.dThreshold3[1, 7, 1, 1];
            obj.dThreshold_l712 = MainWindow.dThreshold3[1, 7, 1, 2];
            obj.dThreshold_l713 = MainWindow.dThreshold3[1, 7, 1, 3];
            obj.dThreshold_l714 = MainWindow.dThreshold3[1, 7, 1, 4];
            obj.dThreshold_l715 = MainWindow.dThreshold3[1, 7, 1, 5];
            obj.dThreshold_l716 = MainWindow.dThreshold3[1, 7, 1, 6];
            obj.dThreshold_l717 = MainWindow.dThreshold3[1, 7, 1, 7];
            obj.dThreshold_l718 = MainWindow.dThreshold3[1, 7, 1, 8];
            obj.dThreshold_l719 = MainWindow.dThreshold3[1, 7, 1, 9];
            //8-Stream3
            obj.dThreshold_u720 = MainWindow.dThreshold3[0, 7, 2, 0];
            obj.dThreshold_u721 = MainWindow.dThreshold3[0, 7, 2, 1];
            obj.dThreshold_u722 = MainWindow.dThreshold3[0, 7, 2, 2];
            obj.dThreshold_u723 = MainWindow.dThreshold3[0, 7, 2, 3];
            obj.dThreshold_u724 = MainWindow.dThreshold3[0, 7, 2, 4];
            obj.dThreshold_u725 = MainWindow.dThreshold3[0, 7, 2, 5];
            obj.dThreshold_u726 = MainWindow.dThreshold3[0, 7, 2, 6];
            obj.dThreshold_u727 = MainWindow.dThreshold3[0, 7, 2, 7];
            obj.dThreshold_u728 = MainWindow.dThreshold3[0, 7, 2, 8];
            obj.dThreshold_u729 = MainWindow.dThreshold3[0, 7, 2, 9];

            obj.dThreshold_l720 = MainWindow.dThreshold3[1, 7, 2, 0];
            obj.dThreshold_l721 = MainWindow.dThreshold3[1, 7, 2, 1];
            obj.dThreshold_l722 = MainWindow.dThreshold3[1, 7, 2, 2];
            obj.dThreshold_l723 = MainWindow.dThreshold3[1, 7, 2, 3];
            obj.dThreshold_l724 = MainWindow.dThreshold3[1, 7, 2, 4];
            obj.dThreshold_l725 = MainWindow.dThreshold3[1, 7, 2, 5];
            obj.dThreshold_l726 = MainWindow.dThreshold3[1, 7, 2, 6];
            obj.dThreshold_l727 = MainWindow.dThreshold3[1, 7, 2, 7];
            obj.dThreshold_l728 = MainWindow.dThreshold3[1, 7, 2, 8];
            obj.dThreshold_l729 = MainWindow.dThreshold3[1, 7, 2, 9];
            //8-Stream4
            obj.dThreshold_u730 = MainWindow.dThreshold3[0, 7, 3, 0];
            obj.dThreshold_u731 = MainWindow.dThreshold3[0, 7, 3, 1];
            obj.dThreshold_u732 = MainWindow.dThreshold3[0, 7, 3, 2];
            obj.dThreshold_u733 = MainWindow.dThreshold3[0, 7, 3, 3];
            obj.dThreshold_u734 = MainWindow.dThreshold3[0, 7, 3, 4];
            obj.dThreshold_u735 = MainWindow.dThreshold3[0, 7, 3, 5];
            obj.dThreshold_u736 = MainWindow.dThreshold3[0, 7, 3, 6];
            obj.dThreshold_u737 = MainWindow.dThreshold3[0, 7, 3, 7];
            obj.dThreshold_u738 = MainWindow.dThreshold3[0, 7, 3, 8];
            obj.dThreshold_u739 = MainWindow.dThreshold3[0, 7, 3, 9];

            obj.dThreshold_l730 = MainWindow.dThreshold3[1, 7, 3, 0];
            obj.dThreshold_l731 = MainWindow.dThreshold3[1, 7, 3, 1];
            obj.dThreshold_l732 = MainWindow.dThreshold3[1, 7, 3, 2];
            obj.dThreshold_l733 = MainWindow.dThreshold3[1, 7, 3, 3];
            obj.dThreshold_l734 = MainWindow.dThreshold3[1, 7, 3, 4];
            obj.dThreshold_l735 = MainWindow.dThreshold3[1, 7, 3, 5];
            obj.dThreshold_l736 = MainWindow.dThreshold3[1, 7, 3, 6];
            obj.dThreshold_l737 = MainWindow.dThreshold3[1, 7, 3, 7];
            obj.dThreshold_l738 = MainWindow.dThreshold3[1, 7, 3, 8];
            obj.dThreshold_l739 = MainWindow.dThreshold3[1, 7, 3, 9];
            //8-Stream5
            obj.dThreshold_u740 = MainWindow.dThreshold3[0, 7, 4, 0];
            obj.dThreshold_u741 = MainWindow.dThreshold3[0, 7, 4, 1];
            obj.dThreshold_u742 = MainWindow.dThreshold3[0, 7, 4, 2];
            obj.dThreshold_u743 = MainWindow.dThreshold3[0, 7, 4, 3];
            obj.dThreshold_u744 = MainWindow.dThreshold3[0, 7, 4, 4];
            obj.dThreshold_u745 = MainWindow.dThreshold3[0, 7, 4, 5];
            obj.dThreshold_u746 = MainWindow.dThreshold3[0, 7, 4, 6];
            obj.dThreshold_u747 = MainWindow.dThreshold3[0, 7, 4, 7];
            obj.dThreshold_u748 = MainWindow.dThreshold3[0, 7, 4, 8];
            obj.dThreshold_u749 = MainWindow.dThreshold3[0, 7, 4, 9];

            obj.dThreshold_l740 = MainWindow.dThreshold3[1, 7, 4, 0];
            obj.dThreshold_l741 = MainWindow.dThreshold3[1, 7, 4, 1];
            obj.dThreshold_l742 = MainWindow.dThreshold3[1, 7, 4, 2];
            obj.dThreshold_l743 = MainWindow.dThreshold3[1, 7, 4, 3];
            obj.dThreshold_l744 = MainWindow.dThreshold3[1, 7, 4, 4];
            obj.dThreshold_l745 = MainWindow.dThreshold3[1, 7, 4, 5];
            obj.dThreshold_l746 = MainWindow.dThreshold3[1, 7, 4, 6];
            obj.dThreshold_l747 = MainWindow.dThreshold3[1, 7, 4, 7];
            obj.dThreshold_l748 = MainWindow.dThreshold3[1, 7, 4, 8];
            obj.dThreshold_l749 = MainWindow.dThreshold3[1, 7, 4, 9];
            //8-Stream6
            obj.dThreshold_u750 = MainWindow.dThreshold3[0, 7, 5, 0];
            obj.dThreshold_u751 = MainWindow.dThreshold3[0, 7, 5, 1];
            obj.dThreshold_u752 = MainWindow.dThreshold3[0, 7, 5, 2];
            obj.dThreshold_u753 = MainWindow.dThreshold3[0, 7, 5, 3];
            obj.dThreshold_u754 = MainWindow.dThreshold3[0, 7, 5, 4];
            obj.dThreshold_u755 = MainWindow.dThreshold3[0, 7, 5, 5];
            obj.dThreshold_u756 = MainWindow.dThreshold3[0, 7, 5, 6];
            obj.dThreshold_u757 = MainWindow.dThreshold3[0, 7, 5, 7];
            obj.dThreshold_u758 = MainWindow.dThreshold3[0, 7, 5, 8];
            obj.dThreshold_u759 = MainWindow.dThreshold3[0, 7, 5, 9];

            obj.dThreshold_l750 = MainWindow.dThreshold3[1, 7, 5, 0];
            obj.dThreshold_l751 = MainWindow.dThreshold3[1, 7, 5, 1];
            obj.dThreshold_l752 = MainWindow.dThreshold3[1, 7, 5, 2];
            obj.dThreshold_l753 = MainWindow.dThreshold3[1, 7, 5, 3];
            obj.dThreshold_l754 = MainWindow.dThreshold3[1, 7, 5, 4];
            obj.dThreshold_l755 = MainWindow.dThreshold3[1, 7, 5, 5];
            obj.dThreshold_l756 = MainWindow.dThreshold3[1, 7, 5, 6];
            obj.dThreshold_l757 = MainWindow.dThreshold3[1, 7, 5, 7];
            obj.dThreshold_l758 = MainWindow.dThreshold3[1, 7, 5, 8];
            obj.dThreshold_l759 = MainWindow.dThreshold3[1, 7, 5, 9];
            //8-Stream7
            obj.dThreshold_u760 = MainWindow.dThreshold3[0, 7, 6, 0];
            obj.dThreshold_u761 = MainWindow.dThreshold3[0, 7, 6, 1];
            obj.dThreshold_u762 = MainWindow.dThreshold3[0, 7, 6, 2];
            obj.dThreshold_u763 = MainWindow.dThreshold3[0, 7, 6, 3];
            obj.dThreshold_u764 = MainWindow.dThreshold3[0, 7, 6, 4];
            obj.dThreshold_u765 = MainWindow.dThreshold3[0, 7, 6, 5];
            obj.dThreshold_u766 = MainWindow.dThreshold3[0, 7, 6, 6];
            obj.dThreshold_u767 = MainWindow.dThreshold3[0, 7, 6, 7];
            obj.dThreshold_u768 = MainWindow.dThreshold3[0, 7, 6, 8];
            obj.dThreshold_u769 = MainWindow.dThreshold3[0, 7, 6, 9];

            obj.dThreshold_l760 = MainWindow.dThreshold3[1, 7, 6, 0];
            obj.dThreshold_l761 = MainWindow.dThreshold3[1, 7, 6, 1];
            obj.dThreshold_l762 = MainWindow.dThreshold3[1, 7, 6, 2];
            obj.dThreshold_l763 = MainWindow.dThreshold3[1, 7, 6, 3];
            obj.dThreshold_l764 = MainWindow.dThreshold3[1, 7, 6, 4];
            obj.dThreshold_l765 = MainWindow.dThreshold3[1, 7, 6, 5];
            obj.dThreshold_l766 = MainWindow.dThreshold3[1, 7, 6, 6];
            obj.dThreshold_l767 = MainWindow.dThreshold3[1, 7, 6, 7];
            obj.dThreshold_l768 = MainWindow.dThreshold3[1, 7, 6, 8];
            obj.dThreshold_l769 = MainWindow.dThreshold3[1, 7, 6, 9];
            //8-Stream8
            obj.dThreshold_u770 = MainWindow.dThreshold3[0, 7, 7, 0];
            obj.dThreshold_u771 = MainWindow.dThreshold3[0, 7, 7, 1];
            obj.dThreshold_u772 = MainWindow.dThreshold3[0, 7, 7, 2];
            obj.dThreshold_u773 = MainWindow.dThreshold3[0, 7, 7, 3];
            obj.dThreshold_u774 = MainWindow.dThreshold3[0, 7, 7, 4];
            obj.dThreshold_u775 = MainWindow.dThreshold3[0, 7, 7, 5];
            obj.dThreshold_u776 = MainWindow.dThreshold3[0, 7, 7, 6];
            obj.dThreshold_u777 = MainWindow.dThreshold3[0, 7, 7, 7];
            obj.dThreshold_u778 = MainWindow.dThreshold3[0, 7, 7, 8];
            obj.dThreshold_u779 = MainWindow.dThreshold3[0, 7, 7, 9];

            obj.dThreshold_l770 = MainWindow.dThreshold3[1, 7, 7, 0];
            obj.dThreshold_l771 = MainWindow.dThreshold3[1, 7, 7, 1];
            obj.dThreshold_l772 = MainWindow.dThreshold3[1, 7, 7, 2];
            obj.dThreshold_l773 = MainWindow.dThreshold3[1, 7, 7, 3];
            obj.dThreshold_l774 = MainWindow.dThreshold3[1, 7, 7, 4];
            obj.dThreshold_l775 = MainWindow.dThreshold3[1, 7, 7, 5];
            obj.dThreshold_l776 = MainWindow.dThreshold3[1, 7, 7, 6];
            obj.dThreshold_l777 = MainWindow.dThreshold3[1, 7, 7, 7];
            obj.dThreshold_l778 = MainWindow.dThreshold3[1, 7, 7, 8];
            obj.dThreshold_l779 = MainWindow.dThreshold3[1, 7, 7, 9];
            //8-Stream9
            obj.dThreshold_u780 = MainWindow.dThreshold3[0, 7, 8, 0];
            obj.dThreshold_u781 = MainWindow.dThreshold3[0, 7, 8, 1];
            obj.dThreshold_u782 = MainWindow.dThreshold3[0, 7, 8, 2];
            obj.dThreshold_u783 = MainWindow.dThreshold3[0, 7, 8, 3];
            obj.dThreshold_u784 = MainWindow.dThreshold3[0, 7, 8, 4];
            obj.dThreshold_u785 = MainWindow.dThreshold3[0, 7, 8, 5];
            obj.dThreshold_u786 = MainWindow.dThreshold3[0, 7, 8, 6];
            obj.dThreshold_u787 = MainWindow.dThreshold3[0, 7, 8, 7];
            obj.dThreshold_u788 = MainWindow.dThreshold3[0, 7, 8, 8];
            obj.dThreshold_u789 = MainWindow.dThreshold3[0, 7, 8, 9];

            obj.dThreshold_l780 = MainWindow.dThreshold3[1, 7, 8, 0];
            obj.dThreshold_l781 = MainWindow.dThreshold3[1, 7, 8, 1];
            obj.dThreshold_l782 = MainWindow.dThreshold3[1, 7, 8, 2];
            obj.dThreshold_l783 = MainWindow.dThreshold3[1, 7, 8, 3];
            obj.dThreshold_l784 = MainWindow.dThreshold3[1, 7, 8, 4];
            obj.dThreshold_l785 = MainWindow.dThreshold3[1, 7, 8, 5];
            obj.dThreshold_l786 = MainWindow.dThreshold3[1, 7, 8, 6];
            obj.dThreshold_l787 = MainWindow.dThreshold3[1, 7, 8, 7];
            obj.dThreshold_l788 = MainWindow.dThreshold3[1, 7, 8, 8];
            obj.dThreshold_l789 = MainWindow.dThreshold3[1, 7, 8, 9];
            //8-Stream10
            obj.dThreshold_u790 = MainWindow.dThreshold3[0, 7, 9, 0];
            obj.dThreshold_u791 = MainWindow.dThreshold3[0, 7, 9, 1];
            obj.dThreshold_u792 = MainWindow.dThreshold3[0, 7, 9, 2];
            obj.dThreshold_u793 = MainWindow.dThreshold3[0, 7, 9, 3];
            obj.dThreshold_u794 = MainWindow.dThreshold3[0, 7, 9, 4];
            obj.dThreshold_u795 = MainWindow.dThreshold3[0, 7, 9, 5];
            obj.dThreshold_u796 = MainWindow.dThreshold3[0, 7, 9, 6];
            obj.dThreshold_u797 = MainWindow.dThreshold3[0, 7, 9, 7];
            obj.dThreshold_u798 = MainWindow.dThreshold3[0, 7, 9, 8];
            obj.dThreshold_u799 = MainWindow.dThreshold3[0, 7, 9, 9];

            obj.dThreshold_l790 = MainWindow.dThreshold3[1, 7, 9, 0];
            obj.dThreshold_l791 = MainWindow.dThreshold3[1, 7, 9, 1];
            obj.dThreshold_l792 = MainWindow.dThreshold3[1, 7, 9, 2];
            obj.dThreshold_l793 = MainWindow.dThreshold3[1, 7, 9, 3];
            obj.dThreshold_l794 = MainWindow.dThreshold3[1, 7, 9, 4];
            obj.dThreshold_l795 = MainWindow.dThreshold3[1, 7, 9, 5];
            obj.dThreshold_l796 = MainWindow.dThreshold3[1, 7, 9, 6];
            obj.dThreshold_l797 = MainWindow.dThreshold3[1, 7, 9, 7];
            obj.dThreshold_l798 = MainWindow.dThreshold3[1, 7, 9, 8];
            obj.dThreshold_l799 = MainWindow.dThreshold3[1, 7, 9, 9];
            //8-Stream11
            obj.dThreshold_u7A0 = MainWindow.dThreshold3[0, 7, 10, 0];
            obj.dThreshold_u7A1 = MainWindow.dThreshold3[0, 7, 10, 1];
            obj.dThreshold_u7A2 = MainWindow.dThreshold3[0, 7, 10, 2];
            obj.dThreshold_u7A3 = MainWindow.dThreshold3[0, 7, 10, 3];
            obj.dThreshold_u7A4 = MainWindow.dThreshold3[0, 7, 10, 4];
            obj.dThreshold_u7A5 = MainWindow.dThreshold3[0, 7, 10, 5];
            obj.dThreshold_u7A6 = MainWindow.dThreshold3[0, 7, 10, 6];
            obj.dThreshold_u7A7 = MainWindow.dThreshold3[0, 7, 10, 7];
            obj.dThreshold_u7A8 = MainWindow.dThreshold3[0, 7, 10, 8];
            obj.dThreshold_u7A9 = MainWindow.dThreshold3[0, 7, 10, 9];

            obj.dThreshold_l7A0 = MainWindow.dThreshold3[1, 7, 10, 0];
            obj.dThreshold_l7A1 = MainWindow.dThreshold3[1, 7, 10, 1];
            obj.dThreshold_l7A2 = MainWindow.dThreshold3[1, 7, 10, 2];
            obj.dThreshold_l7A3 = MainWindow.dThreshold3[1, 7, 10, 3];
            obj.dThreshold_l7A4 = MainWindow.dThreshold3[1, 7, 10, 4];
            obj.dThreshold_l7A5 = MainWindow.dThreshold3[1, 7, 10, 5];
            obj.dThreshold_l7A6 = MainWindow.dThreshold3[1, 7, 10, 6];
            obj.dThreshold_l7A7 = MainWindow.dThreshold3[1, 7, 10, 7];
            obj.dThreshold_l7A8 = MainWindow.dThreshold3[1, 7, 10, 8];
            obj.dThreshold_l7A9 = MainWindow.dThreshold3[1, 7, 10, 9];

            //品種9
            //9-Stream1
            obj.dThreshold_u800 = MainWindow.dThreshold3[0, 8, 0, 0];
            obj.dThreshold_u801 = MainWindow.dThreshold3[0, 8, 0, 1];
            obj.dThreshold_u802 = MainWindow.dThreshold3[0, 8, 0, 2];
            obj.dThreshold_u803 = MainWindow.dThreshold3[0, 8, 0, 3];
            obj.dThreshold_u804 = MainWindow.dThreshold3[0, 8, 0, 4];
            obj.dThreshold_u805 = MainWindow.dThreshold3[0, 8, 0, 5];
            obj.dThreshold_u806 = MainWindow.dThreshold3[0, 8, 0, 6];
            obj.dThreshold_u807 = MainWindow.dThreshold3[0, 8, 0, 7];
            obj.dThreshold_u808 = MainWindow.dThreshold3[0, 8, 0, 8];
            obj.dThreshold_u809 = MainWindow.dThreshold3[0, 8, 0, 9];

            obj.dThreshold_l800 = MainWindow.dThreshold3[1, 8, 0, 0];
            obj.dThreshold_l801 = MainWindow.dThreshold3[1, 8, 0, 1];
            obj.dThreshold_l802 = MainWindow.dThreshold3[1, 8, 0, 2];
            obj.dThreshold_l803 = MainWindow.dThreshold3[1, 8, 0, 3];
            obj.dThreshold_l804 = MainWindow.dThreshold3[1, 8, 0, 4];
            obj.dThreshold_l805 = MainWindow.dThreshold3[1, 8, 0, 5];
            obj.dThreshold_l806 = MainWindow.dThreshold3[1, 8, 0, 6];
            obj.dThreshold_l807 = MainWindow.dThreshold3[1, 8, 0, 7];
            obj.dThreshold_l808 = MainWindow.dThreshold3[1, 8, 0, 8];
            obj.dThreshold_l809 = MainWindow.dThreshold3[1, 8, 0, 9];
            //9-Stream2
            obj.dThreshold_u810 = MainWindow.dThreshold3[0, 8, 1, 0];
            obj.dThreshold_u811 = MainWindow.dThreshold3[0, 8, 1, 1];
            obj.dThreshold_u812 = MainWindow.dThreshold3[0, 8, 1, 2];
            obj.dThreshold_u813 = MainWindow.dThreshold3[0, 8, 1, 3];
            obj.dThreshold_u814 = MainWindow.dThreshold3[0, 8, 1, 4];
            obj.dThreshold_u815 = MainWindow.dThreshold3[0, 8, 1, 5];
            obj.dThreshold_u816 = MainWindow.dThreshold3[0, 8, 1, 6];
            obj.dThreshold_u817 = MainWindow.dThreshold3[0, 8, 1, 7];
            obj.dThreshold_u818 = MainWindow.dThreshold3[0, 8, 1, 8];
            obj.dThreshold_u819 = MainWindow.dThreshold3[0, 8, 1, 9];

            obj.dThreshold_l810 = MainWindow.dThreshold3[1, 8, 1, 0];
            obj.dThreshold_l811 = MainWindow.dThreshold3[1, 8, 1, 1];
            obj.dThreshold_l812 = MainWindow.dThreshold3[1, 8, 1, 2];
            obj.dThreshold_l813 = MainWindow.dThreshold3[1, 8, 1, 3];
            obj.dThreshold_l814 = MainWindow.dThreshold3[1, 8, 1, 4];
            obj.dThreshold_l815 = MainWindow.dThreshold3[1, 8, 1, 5];
            obj.dThreshold_l816 = MainWindow.dThreshold3[1, 8, 1, 6];
            obj.dThreshold_l817 = MainWindow.dThreshold3[1, 8, 1, 7];
            obj.dThreshold_l818 = MainWindow.dThreshold3[1, 8, 1, 8];
            obj.dThreshold_l819 = MainWindow.dThreshold3[1, 8, 1, 9];
            //9-Stream3
            obj.dThreshold_u820 = MainWindow.dThreshold3[0, 8, 2, 0];
            obj.dThreshold_u821 = MainWindow.dThreshold3[0, 8, 2, 1];
            obj.dThreshold_u822 = MainWindow.dThreshold3[0, 8, 2, 2];
            obj.dThreshold_u823 = MainWindow.dThreshold3[0, 8, 2, 3];
            obj.dThreshold_u824 = MainWindow.dThreshold3[0, 8, 2, 4];
            obj.dThreshold_u825 = MainWindow.dThreshold3[0, 8, 2, 5];
            obj.dThreshold_u826 = MainWindow.dThreshold3[0, 8, 2, 6];
            obj.dThreshold_u827 = MainWindow.dThreshold3[0, 8, 2, 7];
            obj.dThreshold_u828 = MainWindow.dThreshold3[0, 8, 2, 8];
            obj.dThreshold_u829 = MainWindow.dThreshold3[0, 8, 2, 9];

            obj.dThreshold_l820 = MainWindow.dThreshold3[1, 8, 2, 0];
            obj.dThreshold_l821 = MainWindow.dThreshold3[1, 8, 2, 1];
            obj.dThreshold_l822 = MainWindow.dThreshold3[1, 8, 2, 2];
            obj.dThreshold_l823 = MainWindow.dThreshold3[1, 8, 2, 3];
            obj.dThreshold_l824 = MainWindow.dThreshold3[1, 8, 2, 4];
            obj.dThreshold_l825 = MainWindow.dThreshold3[1, 8, 2, 5];
            obj.dThreshold_l826 = MainWindow.dThreshold3[1, 8, 2, 6];
            obj.dThreshold_l827 = MainWindow.dThreshold3[1, 8, 2, 7];
            obj.dThreshold_l828 = MainWindow.dThreshold3[1, 8, 2, 8];
            obj.dThreshold_l829 = MainWindow.dThreshold3[1, 8, 2, 9];
            //9-Stream4
            obj.dThreshold_u830 = MainWindow.dThreshold3[0, 8, 3, 0];
            obj.dThreshold_u831 = MainWindow.dThreshold3[0, 8, 3, 1];
            obj.dThreshold_u832 = MainWindow.dThreshold3[0, 8, 3, 2];
            obj.dThreshold_u833 = MainWindow.dThreshold3[0, 8, 3, 3];
            obj.dThreshold_u834 = MainWindow.dThreshold3[0, 8, 3, 4];
            obj.dThreshold_u835 = MainWindow.dThreshold3[0, 8, 3, 5];
            obj.dThreshold_u836 = MainWindow.dThreshold3[0, 8, 3, 6];
            obj.dThreshold_u837 = MainWindow.dThreshold3[0, 8, 3, 7];
            obj.dThreshold_u838 = MainWindow.dThreshold3[0, 8, 3, 8];
            obj.dThreshold_u839 = MainWindow.dThreshold3[0, 8, 3, 9];

            obj.dThreshold_l830 = MainWindow.dThreshold3[1, 8, 3, 0];
            obj.dThreshold_l831 = MainWindow.dThreshold3[1, 8, 3, 1];
            obj.dThreshold_l832 = MainWindow.dThreshold3[1, 8, 3, 2];
            obj.dThreshold_l833 = MainWindow.dThreshold3[1, 8, 3, 3];
            obj.dThreshold_l834 = MainWindow.dThreshold3[1, 8, 3, 4];
            obj.dThreshold_l835 = MainWindow.dThreshold3[1, 8, 3, 5];
            obj.dThreshold_l836 = MainWindow.dThreshold3[1, 8, 3, 6];
            obj.dThreshold_l837 = MainWindow.dThreshold3[1, 8, 3, 7];
            obj.dThreshold_l838 = MainWindow.dThreshold3[1, 8, 3, 8];
            obj.dThreshold_l839 = MainWindow.dThreshold3[1, 8, 3, 9];
            //9-Stream5
            obj.dThreshold_u840 = MainWindow.dThreshold3[0, 8, 4, 0];
            obj.dThreshold_u841 = MainWindow.dThreshold3[0, 8, 4, 1];
            obj.dThreshold_u842 = MainWindow.dThreshold3[0, 8, 4, 2];
            obj.dThreshold_u843 = MainWindow.dThreshold3[0, 8, 4, 3];
            obj.dThreshold_u844 = MainWindow.dThreshold3[0, 8, 4, 4];
            obj.dThreshold_u845 = MainWindow.dThreshold3[0, 8, 4, 5];
            obj.dThreshold_u846 = MainWindow.dThreshold3[0, 8, 4, 6];
            obj.dThreshold_u847 = MainWindow.dThreshold3[0, 8, 4, 7];
            obj.dThreshold_u848 = MainWindow.dThreshold3[0, 8, 4, 8];
            obj.dThreshold_u849 = MainWindow.dThreshold3[0, 8, 4, 9];

            obj.dThreshold_l840 = MainWindow.dThreshold3[1, 8, 4, 0];
            obj.dThreshold_l841 = MainWindow.dThreshold3[1, 8, 4, 1];
            obj.dThreshold_l842 = MainWindow.dThreshold3[1, 8, 4, 2];
            obj.dThreshold_l843 = MainWindow.dThreshold3[1, 8, 4, 3];
            obj.dThreshold_l844 = MainWindow.dThreshold3[1, 8, 4, 4];
            obj.dThreshold_l845 = MainWindow.dThreshold3[1, 8, 4, 5];
            obj.dThreshold_l846 = MainWindow.dThreshold3[1, 8, 4, 6];
            obj.dThreshold_l847 = MainWindow.dThreshold3[1, 8, 4, 7];
            obj.dThreshold_l848 = MainWindow.dThreshold3[1, 8, 4, 8];
            obj.dThreshold_l849 = MainWindow.dThreshold3[1, 8, 4, 9];
            //9-Stream6
            obj.dThreshold_u850 = MainWindow.dThreshold3[0, 8, 5, 0];
            obj.dThreshold_u851 = MainWindow.dThreshold3[0, 8, 5, 1];
            obj.dThreshold_u852 = MainWindow.dThreshold3[0, 8, 5, 2];
            obj.dThreshold_u853 = MainWindow.dThreshold3[0, 8, 5, 3];
            obj.dThreshold_u854 = MainWindow.dThreshold3[0, 8, 5, 4];
            obj.dThreshold_u855 = MainWindow.dThreshold3[0, 8, 5, 5];
            obj.dThreshold_u856 = MainWindow.dThreshold3[0, 8, 5, 6];
            obj.dThreshold_u857 = MainWindow.dThreshold3[0, 8, 5, 7];
            obj.dThreshold_u858 = MainWindow.dThreshold3[0, 8, 5, 8];
            obj.dThreshold_u859 = MainWindow.dThreshold3[0, 8, 5, 9];

            obj.dThreshold_l850 = MainWindow.dThreshold3[1, 8, 5, 0];
            obj.dThreshold_l851 = MainWindow.dThreshold3[1, 8, 5, 1];
            obj.dThreshold_l852 = MainWindow.dThreshold3[1, 8, 5, 2];
            obj.dThreshold_l853 = MainWindow.dThreshold3[1, 8, 5, 3];
            obj.dThreshold_l854 = MainWindow.dThreshold3[1, 8, 5, 4];
            obj.dThreshold_l855 = MainWindow.dThreshold3[1, 8, 5, 5];
            obj.dThreshold_l856 = MainWindow.dThreshold3[1, 8, 5, 6];
            obj.dThreshold_l857 = MainWindow.dThreshold3[1, 8, 5, 7];
            obj.dThreshold_l858 = MainWindow.dThreshold3[1, 8, 5, 8];
            obj.dThreshold_l859 = MainWindow.dThreshold3[1, 8, 5, 9];
            //9-Stream7
            obj.dThreshold_u860 = MainWindow.dThreshold3[0, 8, 6, 0];
            obj.dThreshold_u861 = MainWindow.dThreshold3[0, 8, 6, 1];
            obj.dThreshold_u862 = MainWindow.dThreshold3[0, 8, 6, 2];
            obj.dThreshold_u863 = MainWindow.dThreshold3[0, 8, 6, 3];
            obj.dThreshold_u864 = MainWindow.dThreshold3[0, 8, 6, 4];
            obj.dThreshold_u865 = MainWindow.dThreshold3[0, 8, 6, 5];
            obj.dThreshold_u866 = MainWindow.dThreshold3[0, 8, 6, 6];
            obj.dThreshold_u867 = MainWindow.dThreshold3[0, 8, 6, 7];
            obj.dThreshold_u868 = MainWindow.dThreshold3[0, 8, 6, 8];
            obj.dThreshold_u869 = MainWindow.dThreshold3[0, 8, 6, 9];

            obj.dThreshold_l860 = MainWindow.dThreshold3[1, 8, 6, 0];
            obj.dThreshold_l861 = MainWindow.dThreshold3[1, 8, 6, 1];
            obj.dThreshold_l862 = MainWindow.dThreshold3[1, 8, 6, 2];
            obj.dThreshold_l863 = MainWindow.dThreshold3[1, 8, 6, 3];
            obj.dThreshold_l864 = MainWindow.dThreshold3[1, 8, 6, 4];
            obj.dThreshold_l865 = MainWindow.dThreshold3[1, 8, 6, 5];
            obj.dThreshold_l866 = MainWindow.dThreshold3[1, 8, 6, 6];
            obj.dThreshold_l867 = MainWindow.dThreshold3[1, 8, 6, 7];
            obj.dThreshold_l868 = MainWindow.dThreshold3[1, 8, 6, 8];
            obj.dThreshold_l869 = MainWindow.dThreshold3[1, 8, 6, 9];
            //9-Stream8
            obj.dThreshold_u870 = MainWindow.dThreshold3[0, 8, 7, 0];
            obj.dThreshold_u871 = MainWindow.dThreshold3[0, 8, 7, 1];
            obj.dThreshold_u872 = MainWindow.dThreshold3[0, 8, 7, 2];
            obj.dThreshold_u873 = MainWindow.dThreshold3[0, 8, 7, 3];
            obj.dThreshold_u874 = MainWindow.dThreshold3[0, 8, 7, 4];
            obj.dThreshold_u875 = MainWindow.dThreshold3[0, 8, 7, 5];
            obj.dThreshold_u876 = MainWindow.dThreshold3[0, 8, 7, 6];
            obj.dThreshold_u877 = MainWindow.dThreshold3[0, 8, 7, 7];
            obj.dThreshold_u878 = MainWindow.dThreshold3[0, 8, 7, 8];
            obj.dThreshold_u879 = MainWindow.dThreshold3[0, 8, 7, 9];

            obj.dThreshold_l870 = MainWindow.dThreshold3[1, 8, 7, 0];
            obj.dThreshold_l871 = MainWindow.dThreshold3[1, 8, 7, 1];
            obj.dThreshold_l872 = MainWindow.dThreshold3[1, 8, 7, 2];
            obj.dThreshold_l873 = MainWindow.dThreshold3[1, 8, 7, 3];
            obj.dThreshold_l874 = MainWindow.dThreshold3[1, 8, 7, 4];
            obj.dThreshold_l875 = MainWindow.dThreshold3[1, 8, 7, 5];
            obj.dThreshold_l876 = MainWindow.dThreshold3[1, 8, 7, 6];
            obj.dThreshold_l877 = MainWindow.dThreshold3[1, 8, 7, 7];
            obj.dThreshold_l878 = MainWindow.dThreshold3[1, 8, 7, 8];
            obj.dThreshold_l879 = MainWindow.dThreshold3[1, 8, 7, 9];
            //9-Stream9
            obj.dThreshold_u880 = MainWindow.dThreshold3[0, 8, 8, 0];
            obj.dThreshold_u881 = MainWindow.dThreshold3[0, 8, 8, 1];
            obj.dThreshold_u882 = MainWindow.dThreshold3[0, 8, 8, 2];
            obj.dThreshold_u883 = MainWindow.dThreshold3[0, 8, 8, 3];
            obj.dThreshold_u884 = MainWindow.dThreshold3[0, 8, 8, 4];
            obj.dThreshold_u885 = MainWindow.dThreshold3[0, 8, 8, 5];
            obj.dThreshold_u886 = MainWindow.dThreshold3[0, 8, 8, 6];
            obj.dThreshold_u887 = MainWindow.dThreshold3[0, 8, 8, 7];
            obj.dThreshold_u888 = MainWindow.dThreshold3[0, 8, 8, 8];
            obj.dThreshold_u889 = MainWindow.dThreshold3[0, 8, 8, 9];

            obj.dThreshold_l880 = MainWindow.dThreshold3[1, 8, 8, 0];
            obj.dThreshold_l881 = MainWindow.dThreshold3[1, 8, 8, 1];
            obj.dThreshold_l882 = MainWindow.dThreshold3[1, 8, 8, 2];
            obj.dThreshold_l883 = MainWindow.dThreshold3[1, 8, 8, 3];
            obj.dThreshold_l884 = MainWindow.dThreshold3[1, 8, 8, 4];
            obj.dThreshold_l885 = MainWindow.dThreshold3[1, 8, 8, 5];
            obj.dThreshold_l886 = MainWindow.dThreshold3[1, 8, 8, 6];
            obj.dThreshold_l887 = MainWindow.dThreshold3[1, 8, 8, 7];
            obj.dThreshold_l888 = MainWindow.dThreshold3[1, 8, 8, 8];
            obj.dThreshold_l889 = MainWindow.dThreshold3[1, 8, 8, 9];
            //9-Stream10
            obj.dThreshold_u890 = MainWindow.dThreshold3[0, 8, 9, 0];
            obj.dThreshold_u891 = MainWindow.dThreshold3[0, 8, 9, 1];
            obj.dThreshold_u892 = MainWindow.dThreshold3[0, 8, 9, 2];
            obj.dThreshold_u893 = MainWindow.dThreshold3[0, 8, 9, 3];
            obj.dThreshold_u894 = MainWindow.dThreshold3[0, 8, 9, 4];
            obj.dThreshold_u895 = MainWindow.dThreshold3[0, 8, 9, 5];
            obj.dThreshold_u896 = MainWindow.dThreshold3[0, 8, 9, 6];
            obj.dThreshold_u897 = MainWindow.dThreshold3[0, 8, 9, 7];
            obj.dThreshold_u898 = MainWindow.dThreshold3[0, 8, 9, 8];
            obj.dThreshold_u899 = MainWindow.dThreshold3[0, 8, 9, 9];

            obj.dThreshold_l890 = MainWindow.dThreshold3[1, 8, 9, 0];
            obj.dThreshold_l891 = MainWindow.dThreshold3[1, 8, 9, 1];
            obj.dThreshold_l892 = MainWindow.dThreshold3[1, 8, 9, 2];
            obj.dThreshold_l893 = MainWindow.dThreshold3[1, 8, 9, 3];
            obj.dThreshold_l894 = MainWindow.dThreshold3[1, 8, 9, 4];
            obj.dThreshold_l895 = MainWindow.dThreshold3[1, 8, 9, 5];
            obj.dThreshold_l896 = MainWindow.dThreshold3[1, 8, 9, 6];
            obj.dThreshold_l897 = MainWindow.dThreshold3[1, 8, 9, 7];
            obj.dThreshold_l898 = MainWindow.dThreshold3[1, 8, 9, 8];
            obj.dThreshold_l899 = MainWindow.dThreshold3[1, 8, 9, 9];
            //9-Stream11
            obj.dThreshold_u8A0 = MainWindow.dThreshold3[0, 8, 10, 0];
            obj.dThreshold_u8A1 = MainWindow.dThreshold3[0, 8, 10, 1];
            obj.dThreshold_u8A2 = MainWindow.dThreshold3[0, 8, 10, 2];
            obj.dThreshold_u8A3 = MainWindow.dThreshold3[0, 8, 10, 3];
            obj.dThreshold_u8A4 = MainWindow.dThreshold3[0, 8, 10, 4];
            obj.dThreshold_u8A5 = MainWindow.dThreshold3[0, 8, 10, 5];
            obj.dThreshold_u8A6 = MainWindow.dThreshold3[0, 8, 10, 6];
            obj.dThreshold_u8A7 = MainWindow.dThreshold3[0, 8, 10, 7];
            obj.dThreshold_u8A8 = MainWindow.dThreshold3[0, 8, 10, 8];
            obj.dThreshold_u8A9 = MainWindow.dThreshold3[0, 8, 10, 9];

            obj.dThreshold_l8A0 = MainWindow.dThreshold3[1, 8, 10, 0];
            obj.dThreshold_l8A1 = MainWindow.dThreshold3[1, 8, 10, 1];
            obj.dThreshold_l8A2 = MainWindow.dThreshold3[1, 8, 10, 2];
            obj.dThreshold_l8A3 = MainWindow.dThreshold3[1, 8, 10, 3];
            obj.dThreshold_l8A4 = MainWindow.dThreshold3[1, 8, 10, 4];
            obj.dThreshold_l8A5 = MainWindow.dThreshold3[1, 8, 10, 5];
            obj.dThreshold_l8A6 = MainWindow.dThreshold3[1, 8, 10, 6];
            obj.dThreshold_l8A7 = MainWindow.dThreshold3[1, 8, 10, 7];
            obj.dThreshold_l8A8 = MainWindow.dThreshold3[1, 8, 10, 8];
            obj.dThreshold_l8A9 = MainWindow.dThreshold3[1, 8, 10, 9];

            //品種10
            //10-Stream1
            obj.dThreshold_u900 = MainWindow.dThreshold3[0, 9, 0, 0];
            obj.dThreshold_u901 = MainWindow.dThreshold3[0, 9, 0, 1];
            obj.dThreshold_u902 = MainWindow.dThreshold3[0, 9, 0, 2];
            obj.dThreshold_u903 = MainWindow.dThreshold3[0, 9, 0, 3];
            obj.dThreshold_u904 = MainWindow.dThreshold3[0, 9, 0, 4];
            obj.dThreshold_u905 = MainWindow.dThreshold3[0, 9, 0, 5];
            obj.dThreshold_u906 = MainWindow.dThreshold3[0, 9, 0, 6];
            obj.dThreshold_u907 = MainWindow.dThreshold3[0, 9, 0, 7];
            obj.dThreshold_u908 = MainWindow.dThreshold3[0, 9, 0, 8];
            obj.dThreshold_u909 = MainWindow.dThreshold3[0, 9, 0, 9];

            obj.dThreshold_l900 = MainWindow.dThreshold3[1, 9, 0, 0];
            obj.dThreshold_l901 = MainWindow.dThreshold3[1, 9, 0, 1];
            obj.dThreshold_l902 = MainWindow.dThreshold3[1, 9, 0, 2];
            obj.dThreshold_l903 = MainWindow.dThreshold3[1, 9, 0, 3];
            obj.dThreshold_l904 = MainWindow.dThreshold3[1, 9, 0, 4];
            obj.dThreshold_l905 = MainWindow.dThreshold3[1, 9, 0, 5];
            obj.dThreshold_l906 = MainWindow.dThreshold3[1, 9, 0, 6];
            obj.dThreshold_l907 = MainWindow.dThreshold3[1, 9, 0, 7];
            obj.dThreshold_l908 = MainWindow.dThreshold3[1, 9, 0, 8];
            obj.dThreshold_l909 = MainWindow.dThreshold3[1, 9, 0, 9];
            //10-Stream2
            obj.dThreshold_u910 = MainWindow.dThreshold3[0, 9, 1, 0];
            obj.dThreshold_u911 = MainWindow.dThreshold3[0, 9, 1, 1];
            obj.dThreshold_u912 = MainWindow.dThreshold3[0, 9, 1, 2];
            obj.dThreshold_u913 = MainWindow.dThreshold3[0, 9, 1, 3];
            obj.dThreshold_u914 = MainWindow.dThreshold3[0, 9, 1, 4];
            obj.dThreshold_u915 = MainWindow.dThreshold3[0, 9, 1, 5];
            obj.dThreshold_u916 = MainWindow.dThreshold3[0, 9, 1, 6];
            obj.dThreshold_u917 = MainWindow.dThreshold3[0, 9, 1, 7];
            obj.dThreshold_u918 = MainWindow.dThreshold3[0, 9, 1, 8];
            obj.dThreshold_u919 = MainWindow.dThreshold3[0, 9, 1, 9];

            obj.dThreshold_l910 = MainWindow.dThreshold3[1, 9, 1, 0];
            obj.dThreshold_l911 = MainWindow.dThreshold3[1, 9, 1, 1];
            obj.dThreshold_l912 = MainWindow.dThreshold3[1, 9, 1, 2];
            obj.dThreshold_l913 = MainWindow.dThreshold3[1, 9, 1, 3];
            obj.dThreshold_l914 = MainWindow.dThreshold3[1, 9, 1, 4];
            obj.dThreshold_l915 = MainWindow.dThreshold3[1, 9, 1, 5];
            obj.dThreshold_l916 = MainWindow.dThreshold3[1, 9, 1, 6];
            obj.dThreshold_l917 = MainWindow.dThreshold3[1, 9, 1, 7];
            obj.dThreshold_l918 = MainWindow.dThreshold3[1, 9, 1, 8];
            obj.dThreshold_l919 = MainWindow.dThreshold3[1, 9, 1, 9];
            //10-Stream3
            obj.dThreshold_u920 = MainWindow.dThreshold3[0, 9, 2, 0];
            obj.dThreshold_u921 = MainWindow.dThreshold3[0, 9, 2, 1];
            obj.dThreshold_u922 = MainWindow.dThreshold3[0, 9, 2, 2];
            obj.dThreshold_u923 = MainWindow.dThreshold3[0, 9, 2, 3];
            obj.dThreshold_u924 = MainWindow.dThreshold3[0, 9, 2, 4];
            obj.dThreshold_u925 = MainWindow.dThreshold3[0, 9, 2, 5];
            obj.dThreshold_u926 = MainWindow.dThreshold3[0, 9, 2, 6];
            obj.dThreshold_u927 = MainWindow.dThreshold3[0, 9, 2, 7];
            obj.dThreshold_u928 = MainWindow.dThreshold3[0, 9, 2, 8];
            obj.dThreshold_u929 = MainWindow.dThreshold3[0, 9, 2, 9];

            obj.dThreshold_l920 = MainWindow.dThreshold3[1, 9, 2, 0];
            obj.dThreshold_l921 = MainWindow.dThreshold3[1, 9, 2, 1];
            obj.dThreshold_l922 = MainWindow.dThreshold3[1, 9, 2, 2];
            obj.dThreshold_l923 = MainWindow.dThreshold3[1, 9, 2, 3];
            obj.dThreshold_l924 = MainWindow.dThreshold3[1, 9, 2, 4];
            obj.dThreshold_l925 = MainWindow.dThreshold3[1, 9, 2, 5];
            obj.dThreshold_l926 = MainWindow.dThreshold3[1, 9, 2, 6];
            obj.dThreshold_l927 = MainWindow.dThreshold3[1, 9, 2, 7];
            obj.dThreshold_l928 = MainWindow.dThreshold3[1, 9, 2, 8];
            obj.dThreshold_l929 = MainWindow.dThreshold3[1, 9, 2, 9];
            //10-Stream4
            obj.dThreshold_u930 = MainWindow.dThreshold3[0, 9, 3, 0];
            obj.dThreshold_u931 = MainWindow.dThreshold3[0, 9, 3, 1];
            obj.dThreshold_u932 = MainWindow.dThreshold3[0, 9, 3, 2];
            obj.dThreshold_u933 = MainWindow.dThreshold3[0, 9, 3, 3];
            obj.dThreshold_u934 = MainWindow.dThreshold3[0, 9, 3, 4];
            obj.dThreshold_u935 = MainWindow.dThreshold3[0, 9, 3, 5];
            obj.dThreshold_u936 = MainWindow.dThreshold3[0, 9, 3, 6];
            obj.dThreshold_u937 = MainWindow.dThreshold3[0, 9, 3, 7];
            obj.dThreshold_u938 = MainWindow.dThreshold3[0, 9, 3, 8];
            obj.dThreshold_u939 = MainWindow.dThreshold3[0, 9, 3, 9];

            obj.dThreshold_l930 = MainWindow.dThreshold3[1, 9, 3, 0];
            obj.dThreshold_l931 = MainWindow.dThreshold3[1, 9, 3, 1];
            obj.dThreshold_l932 = MainWindow.dThreshold3[1, 9, 3, 2];
            obj.dThreshold_l933 = MainWindow.dThreshold3[1, 9, 3, 3];
            obj.dThreshold_l934 = MainWindow.dThreshold3[1, 9, 3, 4];
            obj.dThreshold_l935 = MainWindow.dThreshold3[1, 9, 3, 5];
            obj.dThreshold_l936 = MainWindow.dThreshold3[1, 9, 3, 6];
            obj.dThreshold_l937 = MainWindow.dThreshold3[1, 9, 3, 7];
            obj.dThreshold_l938 = MainWindow.dThreshold3[1, 9, 3, 8];
            obj.dThreshold_l939 = MainWindow.dThreshold3[1, 9, 3, 9];
            //10-Stream5
            obj.dThreshold_u940 = MainWindow.dThreshold3[0, 9, 4, 0];
            obj.dThreshold_u941 = MainWindow.dThreshold3[0, 9, 4, 1];
            obj.dThreshold_u942 = MainWindow.dThreshold3[0, 9, 4, 2];
            obj.dThreshold_u943 = MainWindow.dThreshold3[0, 9, 4, 3];
            obj.dThreshold_u944 = MainWindow.dThreshold3[0, 9, 4, 4];
            obj.dThreshold_u945 = MainWindow.dThreshold3[0, 9, 4, 5];
            obj.dThreshold_u946 = MainWindow.dThreshold3[0, 9, 4, 6];
            obj.dThreshold_u947 = MainWindow.dThreshold3[0, 9, 4, 7];
            obj.dThreshold_u948 = MainWindow.dThreshold3[0, 9, 4, 8];
            obj.dThreshold_u949 = MainWindow.dThreshold3[0, 9, 4, 9];

            obj.dThreshold_l940 = MainWindow.dThreshold3[1, 9, 4, 0];
            obj.dThreshold_l941 = MainWindow.dThreshold3[1, 9, 4, 1];
            obj.dThreshold_l942 = MainWindow.dThreshold3[1, 9, 4, 2];
            obj.dThreshold_l943 = MainWindow.dThreshold3[1, 9, 4, 3];
            obj.dThreshold_l944 = MainWindow.dThreshold3[1, 9, 4, 4];
            obj.dThreshold_l945 = MainWindow.dThreshold3[1, 9, 4, 5];
            obj.dThreshold_l946 = MainWindow.dThreshold3[1, 9, 4, 6];
            obj.dThreshold_l947 = MainWindow.dThreshold3[1, 9, 4, 7];
            obj.dThreshold_l948 = MainWindow.dThreshold3[1, 9, 4, 8];
            obj.dThreshold_l949 = MainWindow.dThreshold3[1, 9, 4, 9];
            //10-Stream6
            obj.dThreshold_u950 = MainWindow.dThreshold3[0, 9, 5, 0];
            obj.dThreshold_u951 = MainWindow.dThreshold3[0, 9, 5, 1];
            obj.dThreshold_u952 = MainWindow.dThreshold3[0, 9, 5, 2];
            obj.dThreshold_u953 = MainWindow.dThreshold3[0, 9, 5, 3];
            obj.dThreshold_u954 = MainWindow.dThreshold3[0, 9, 5, 4];
            obj.dThreshold_u955 = MainWindow.dThreshold3[0, 9, 5, 5];
            obj.dThreshold_u956 = MainWindow.dThreshold3[0, 9, 5, 6];
            obj.dThreshold_u957 = MainWindow.dThreshold3[0, 9, 5, 7];
            obj.dThreshold_u958 = MainWindow.dThreshold3[0, 9, 5, 8];
            obj.dThreshold_u959 = MainWindow.dThreshold3[0, 9, 5, 9];

            obj.dThreshold_l950 = MainWindow.dThreshold3[1, 9, 5, 0];
            obj.dThreshold_l951 = MainWindow.dThreshold3[1, 9, 5, 1];
            obj.dThreshold_l952 = MainWindow.dThreshold3[1, 9, 5, 2];
            obj.dThreshold_l953 = MainWindow.dThreshold3[1, 9, 5, 3];
            obj.dThreshold_l954 = MainWindow.dThreshold3[1, 9, 5, 4];
            obj.dThreshold_l955 = MainWindow.dThreshold3[1, 9, 5, 5];
            obj.dThreshold_l956 = MainWindow.dThreshold3[1, 9, 5, 6];
            obj.dThreshold_l957 = MainWindow.dThreshold3[1, 9, 5, 7];
            obj.dThreshold_l958 = MainWindow.dThreshold3[1, 9, 5, 8];
            obj.dThreshold_l959 = MainWindow.dThreshold3[1, 9, 5, 9];
            //10-Stream7
            obj.dThreshold_u960 = MainWindow.dThreshold3[0, 9, 6, 0];
            obj.dThreshold_u961 = MainWindow.dThreshold3[0, 9, 6, 1];
            obj.dThreshold_u962 = MainWindow.dThreshold3[0, 9, 6, 2];
            obj.dThreshold_u963 = MainWindow.dThreshold3[0, 9, 6, 3];
            obj.dThreshold_u964 = MainWindow.dThreshold3[0, 9, 6, 4];
            obj.dThreshold_u965 = MainWindow.dThreshold3[0, 9, 6, 5];
            obj.dThreshold_u966 = MainWindow.dThreshold3[0, 9, 6, 6];
            obj.dThreshold_u967 = MainWindow.dThreshold3[0, 9, 6, 7];
            obj.dThreshold_u968 = MainWindow.dThreshold3[0, 9, 6, 8];
            obj.dThreshold_u969 = MainWindow.dThreshold3[0, 9, 6, 9];

            obj.dThreshold_l960 = MainWindow.dThreshold3[1, 9, 6, 0];
            obj.dThreshold_l961 = MainWindow.dThreshold3[1, 9, 6, 1];
            obj.dThreshold_l962 = MainWindow.dThreshold3[1, 9, 6, 2];
            obj.dThreshold_l963 = MainWindow.dThreshold3[1, 9, 6, 3];
            obj.dThreshold_l964 = MainWindow.dThreshold3[1, 9, 6, 4];
            obj.dThreshold_l965 = MainWindow.dThreshold3[1, 9, 6, 5];
            obj.dThreshold_l966 = MainWindow.dThreshold3[1, 9, 6, 6];
            obj.dThreshold_l967 = MainWindow.dThreshold3[1, 9, 6, 7];
            obj.dThreshold_l968 = MainWindow.dThreshold3[1, 9, 6, 8];
            obj.dThreshold_l969 = MainWindow.dThreshold3[1, 9, 6, 9];
            //10-Stream8
            obj.dThreshold_u970 = MainWindow.dThreshold3[0, 9, 7, 0];
            obj.dThreshold_u971 = MainWindow.dThreshold3[0, 9, 7, 1];
            obj.dThreshold_u972 = MainWindow.dThreshold3[0, 9, 7, 2];
            obj.dThreshold_u973 = MainWindow.dThreshold3[0, 9, 7, 3];
            obj.dThreshold_u974 = MainWindow.dThreshold3[0, 9, 7, 4];
            obj.dThreshold_u975 = MainWindow.dThreshold3[0, 9, 7, 5];
            obj.dThreshold_u976 = MainWindow.dThreshold3[0, 9, 7, 6];
            obj.dThreshold_u977 = MainWindow.dThreshold3[0, 9, 7, 7];
            obj.dThreshold_u978 = MainWindow.dThreshold3[0, 9, 7, 8];
            obj.dThreshold_u979 = MainWindow.dThreshold3[0, 9, 7, 9];

            obj.dThreshold_l970 = MainWindow.dThreshold3[1, 9, 7, 0];
            obj.dThreshold_l971 = MainWindow.dThreshold3[1, 9, 7, 1];
            obj.dThreshold_l972 = MainWindow.dThreshold3[1, 9, 7, 2];
            obj.dThreshold_l973 = MainWindow.dThreshold3[1, 9, 7, 3];
            obj.dThreshold_l974 = MainWindow.dThreshold3[1, 9, 7, 4];
            obj.dThreshold_l975 = MainWindow.dThreshold3[1, 9, 7, 5];
            obj.dThreshold_l976 = MainWindow.dThreshold3[1, 9, 7, 6];
            obj.dThreshold_l977 = MainWindow.dThreshold3[1, 9, 7, 7];
            obj.dThreshold_l978 = MainWindow.dThreshold3[1, 9, 7, 8];
            obj.dThreshold_l979 = MainWindow.dThreshold3[1, 9, 7, 9];
            //10-Stream9
            obj.dThreshold_u980 = MainWindow.dThreshold3[0, 9, 8, 0];
            obj.dThreshold_u981 = MainWindow.dThreshold3[0, 9, 8, 1];
            obj.dThreshold_u982 = MainWindow.dThreshold3[0, 9, 8, 2];
            obj.dThreshold_u983 = MainWindow.dThreshold3[0, 9, 8, 3];
            obj.dThreshold_u984 = MainWindow.dThreshold3[0, 9, 8, 4];
            obj.dThreshold_u985 = MainWindow.dThreshold3[0, 9, 8, 5];
            obj.dThreshold_u986 = MainWindow.dThreshold3[0, 9, 8, 6];
            obj.dThreshold_u987 = MainWindow.dThreshold3[0, 9, 8, 7];
            obj.dThreshold_u988 = MainWindow.dThreshold3[0, 9, 8, 8];
            obj.dThreshold_u989 = MainWindow.dThreshold3[0, 9, 8, 9];

            obj.dThreshold_l980 = MainWindow.dThreshold3[1, 9, 8, 0];
            obj.dThreshold_l981 = MainWindow.dThreshold3[1, 9, 8, 1];
            obj.dThreshold_l982 = MainWindow.dThreshold3[1, 9, 8, 2];
            obj.dThreshold_l983 = MainWindow.dThreshold3[1, 9, 8, 3];
            obj.dThreshold_l984 = MainWindow.dThreshold3[1, 9, 8, 4];
            obj.dThreshold_l985 = MainWindow.dThreshold3[1, 9, 8, 5];
            obj.dThreshold_l986 = MainWindow.dThreshold3[1, 9, 8, 6];
            obj.dThreshold_l987 = MainWindow.dThreshold3[1, 9, 8, 7];
            obj.dThreshold_l988 = MainWindow.dThreshold3[1, 9, 8, 8];
            obj.dThreshold_l989 = MainWindow.dThreshold3[1, 9, 8, 9];
            //10-Stream10
            obj.dThreshold_u990 = MainWindow.dThreshold3[0, 9, 9, 0];
            obj.dThreshold_u991 = MainWindow.dThreshold3[0, 9, 9, 1];
            obj.dThreshold_u992 = MainWindow.dThreshold3[0, 9, 9, 2];
            obj.dThreshold_u993 = MainWindow.dThreshold3[0, 9, 9, 3];
            obj.dThreshold_u994 = MainWindow.dThreshold3[0, 9, 9, 4];
            obj.dThreshold_u995 = MainWindow.dThreshold3[0, 9, 9, 5];
            obj.dThreshold_u996 = MainWindow.dThreshold3[0, 9, 9, 6];
            obj.dThreshold_u997 = MainWindow.dThreshold3[0, 9, 9, 7];
            obj.dThreshold_u998 = MainWindow.dThreshold3[0, 9, 9, 8];
            obj.dThreshold_u999 = MainWindow.dThreshold3[0, 9, 9, 9];

            obj.dThreshold_l990 = MainWindow.dThreshold3[1, 9, 9, 0];
            obj.dThreshold_l991 = MainWindow.dThreshold3[1, 9, 9, 1];
            obj.dThreshold_l992 = MainWindow.dThreshold3[1, 9, 9, 2];
            obj.dThreshold_l993 = MainWindow.dThreshold3[1, 9, 9, 3];
            obj.dThreshold_l994 = MainWindow.dThreshold3[1, 9, 9, 4];
            obj.dThreshold_l995 = MainWindow.dThreshold3[1, 9, 9, 5];
            obj.dThreshold_l996 = MainWindow.dThreshold3[1, 9, 9, 6];
            obj.dThreshold_l997 = MainWindow.dThreshold3[1, 9, 9, 7];
            obj.dThreshold_l998 = MainWindow.dThreshold3[1, 9, 9, 8];
            obj.dThreshold_l999 = MainWindow.dThreshold3[1, 9, 9, 9];
            //10-Stream11
            obj.dThreshold_u9A0 = MainWindow.dThreshold3[0, 9, 10, 0];
            obj.dThreshold_u9A1 = MainWindow.dThreshold3[0, 9, 10, 1];
            obj.dThreshold_u9A2 = MainWindow.dThreshold3[0, 9, 10, 2];
            obj.dThreshold_u9A3 = MainWindow.dThreshold3[0, 9, 10, 3];
            obj.dThreshold_u9A4 = MainWindow.dThreshold3[0, 9, 10, 4];
            obj.dThreshold_u9A5 = MainWindow.dThreshold3[0, 9, 10, 5];
            obj.dThreshold_u9A6 = MainWindow.dThreshold3[0, 9, 10, 6];
            obj.dThreshold_u9A7 = MainWindow.dThreshold3[0, 9, 10, 7];
            obj.dThreshold_u9A8 = MainWindow.dThreshold3[0, 9, 10, 8];
            obj.dThreshold_u9A9 = MainWindow.dThreshold3[0, 9, 10, 9];

            obj.dThreshold_l9A0 = MainWindow.dThreshold3[1, 9, 10, 0];
            obj.dThreshold_l9A1 = MainWindow.dThreshold3[1, 9, 10, 1];
            obj.dThreshold_l9A2 = MainWindow.dThreshold3[1, 9, 10, 2];
            obj.dThreshold_l9A3 = MainWindow.dThreshold3[1, 9, 10, 3];
            obj.dThreshold_l9A4 = MainWindow.dThreshold3[1, 9, 10, 4];
            obj.dThreshold_l9A5 = MainWindow.dThreshold3[1, 9, 10, 5];
            obj.dThreshold_l9A6 = MainWindow.dThreshold3[1, 9, 10, 6];
            obj.dThreshold_l9A7 = MainWindow.dThreshold3[1, 9, 10, 7];
            obj.dThreshold_l9A8 = MainWindow.dThreshold3[1, 9, 10, 8];
            obj.dThreshold_l9A9 = MainWindow.dThreshold3[1, 9, 10, 9];
            //ADD_END :2020/4/27 kitayama 理由：改造に合わせたしきい値の形式に変更する

            //XmlSerializerオブジェクトを作成
            //オブジェクトの型を指定する
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(SampleClass));
            //書き込むファイルを開く（UTF-8 BOM無し）
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, new System.Text.UTF8Encoding(false));
            //シリアル化し、XMLファイルに保存する
            serializer.Serialize(sw, obj);
            //ファイルを閉じる
            sw.Close();
        }


        public void ReadXML()
        {
            ///////////////////////////////////////////////////////////////////////////
            ///             初期値パラメタXMLファイル読み込み処理
            ///////////////////////////////////////////////////////////////////////////
            try
            {

                //XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(SampleClass));
                //読み込むファイルを開く
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    fileName, new System.Text.UTF8Encoding(false));
                //XMLファイルから読み込み、逆シリアル化する
                SampleClass obj = (SampleClass)serializer.Deserialize(sr);

                //////////////// パラメタ ///////////////////////////////////////////////////
                //CHANGE_START :2021/11/27 kitayama 理由：保存先をOK画像、NG画像、判定不可画像の3種に変更
                MainWindow.sImagePath[0] = obj.OKImagePath;
                MainWindow.sImagePath[1] = obj.INTERImagePath;
                MainWindow.sImagePath[2] = obj.NGImagePath;

                //MainWindow.sGetImagePath = obj.GetImagePath;                         //画像取得先パス
                //MainWindow.iGetImageInterval = obj.GetImageInterval;                 //画像取得周期
                //MainWindow.iMoveImageInterval = obj.MoveImageInterval;               //画像移動周期
                //MainWindow.sSetImagePath = obj.SetImagePath;                         //画像保存先パス
                //ADD_START :2020/2/20 kitayama 理由：隔離先パスを追加                                                                     
                //MainWindow.sIsoImagePath=obj.IsoImagePath;
                //ADD_END :2020/2/20 kitayama 理由：隔離先パスを追加
                //CHANGE_START :2021/11/27 kitayama 理由：保存先をOK画像、NG画像、判定不可画像の3種に変更

                //ADD_START :2020/1/17 kitayama 理由：画像表示時間を追加
                MainWindow.iHoldTime = obj.HoldTime;                                 //検査予定枚数0のときの画像表示時間
                                                                                     //ADD_START :2020/1/17 kitayama 理由：画像表示時間を追加
                                                                                     //ADD_START :2020/2/21 kitayama 理由：画像保存しきい値を追加
                MainWindow.fBlankrate = obj.Blankrate;
                //ADD_END :2020/2/21 kitayama 理由：画像保存しきい値を追加
                //ADD_START :2020/10/12 kitayama 理由：シャッタースピード、ゲイン？を追加
                MainWindow.iShutterspeed = obj.shutterspeed;
                MainWindow.iBrightness = obj.brightness;
                //ADD_END :2020/10/12 kitayama 理由：シャッタースピード、ゲイン？を追加

                MainWindow.sKishu[0] = obj.Kishu1;                                   //品種1
                MainWindow.sKishu[1] = obj.Kishu2;                                   //品種2
                MainWindow.sKishu[2] = obj.Kishu3;                                   //品種3
                MainWindow.sKishu[3] = obj.Kishu4;                                   //品種4
                MainWindow.sKishu[4] = obj.Kishu5;                                   //品種5
                MainWindow.sKishu[5] = obj.Kishu6;                                   //品種6
                MainWindow.sKishu[6] = obj.Kishu7;                                   //品種7
                MainWindow.sKishu[7] = obj.Kishu8;                                   //品種8
                MainWindow.sKishu[8] = obj.Kishu9;                                   //品種9
                MainWindow.sKishu[9] = obj.Kishu10;                                  //品種10
                MainWindow.sWorkspece[0] = obj.WorkSpece1;                           //ワークスペース1
                MainWindow.sWorkspece[1] = obj.WorkSpece2;                           //ワークスペース2
                MainWindow.sWorkspece[2] = obj.WorkSpece3;                           //ワークスペース3
                MainWindow.sWorkspece[3] = obj.WorkSpece4;                           //ワークスペース4
                MainWindow.sWorkspece[4] = obj.WorkSpece5;                           //ワークスペース5
                MainWindow.sWorkspece[5] = obj.WorkSpece6;                           //ワークスペース6
                MainWindow.sWorkspece[6] = obj.WorkSpece7;                           //ワークスペース7
                MainWindow.sWorkspece[7] = obj.WorkSpece8;                           //ワークスペース8
                MainWindow.sWorkspece[8] = obj.WorkSpece9;                           //ワークスペース9
                MainWindow.sWorkspece[9] = obj.WorkSpece10;                          //ワークスペース10

                //DELETE_START :2021/12/19 kitayama 理由：名称は使用しないので削除
                ////ADD_START :2021/11/14 kitayama 理由：検査名称を格納する処理を追加
                ////品種1
                ////1-Stream1
                //MainWindow.a_meisyou[0, 0, 0] = obj.Meisyou000;
                //MainWindow.a_meisyou[0, 0, 1] = obj.Meisyou001;
                //MainWindow.a_meisyou[0, 0, 2] = obj.Meisyou002;
                //MainWindow.a_meisyou[0, 0, 3] = obj.Meisyou003;
                //MainWindow.a_meisyou[0, 0, 4] = obj.Meisyou004;
                //MainWindow.a_meisyou[0, 0, 5] = obj.Meisyou005;
                //MainWindow.a_meisyou[0, 0, 6] = obj.Meisyou006;
                //MainWindow.a_meisyou[0, 0, 7] = obj.Meisyou007;
                //MainWindow.a_meisyou[0, 0, 8] = obj.Meisyou008;
                //MainWindow.a_meisyou[0, 0, 9] = obj.Meisyou009;
                ////1-Stream2
                //MainWindow.a_meisyou[0, 1, 0] = obj.Meisyou010;
                //MainWindow.a_meisyou[0, 1, 1] = obj.Meisyou011;
                //MainWindow.a_meisyou[0, 1, 2] = obj.Meisyou012;
                //MainWindow.a_meisyou[0, 1, 3] = obj.Meisyou013;
                //MainWindow.a_meisyou[0, 1, 4] = obj.Meisyou014;
                //MainWindow.a_meisyou[0, 1, 5] = obj.Meisyou015;
                //MainWindow.a_meisyou[0, 1, 6] = obj.Meisyou016;
                //MainWindow.a_meisyou[0, 1, 7] = obj.Meisyou017;
                //MainWindow.a_meisyou[0, 1, 8] = obj.Meisyou018;
                //MainWindow.a_meisyou[0, 1, 9] = obj.Meisyou019;
                ////1-Stream3
                //MainWindow.a_meisyou[0, 2, 0] = obj.Meisyou020;
                //MainWindow.a_meisyou[0, 2, 1] = obj.Meisyou021;
                //MainWindow.a_meisyou[0, 2, 2] = obj.Meisyou022;
                //MainWindow.a_meisyou[0, 2, 3] = obj.Meisyou023;
                //MainWindow.a_meisyou[0, 2, 4] = obj.Meisyou024;
                //MainWindow.a_meisyou[0, 2, 5] = obj.Meisyou025;
                //MainWindow.a_meisyou[0, 2, 6] = obj.Meisyou026;
                //MainWindow.a_meisyou[0, 2, 7] = obj.Meisyou027;
                //MainWindow.a_meisyou[0, 2, 8] = obj.Meisyou028;
                //MainWindow.a_meisyou[0, 2, 9] = obj.Meisyou029;
                ////1-Stream4
                //MainWindow.a_meisyou[0, 3, 0] = obj.Meisyou030;
                //MainWindow.a_meisyou[0, 3, 1] = obj.Meisyou031;
                //MainWindow.a_meisyou[0, 3, 2] = obj.Meisyou032;
                //MainWindow.a_meisyou[0, 3, 3] = obj.Meisyou033;
                //MainWindow.a_meisyou[0, 3, 4] = obj.Meisyou034;
                //MainWindow.a_meisyou[0, 3, 5] = obj.Meisyou035;
                //MainWindow.a_meisyou[0, 3, 6] = obj.Meisyou036;
                //MainWindow.a_meisyou[0, 3, 7] = obj.Meisyou037;
                //MainWindow.a_meisyou[0, 3, 8] = obj.Meisyou038;
                //MainWindow.a_meisyou[0, 3, 9] = obj.Meisyou039;
                ////1-Stream5
                //MainWindow.a_meisyou[0, 4, 0] = obj.Meisyou040;
                //MainWindow.a_meisyou[0, 4, 1] = obj.Meisyou041;
                //MainWindow.a_meisyou[0, 4, 2] = obj.Meisyou042;
                //MainWindow.a_meisyou[0, 4, 3] = obj.Meisyou043;
                //MainWindow.a_meisyou[0, 4, 4] = obj.Meisyou044;
                //MainWindow.a_meisyou[0, 4, 5] = obj.Meisyou045;
                //MainWindow.a_meisyou[0, 4, 6] = obj.Meisyou046;
                //MainWindow.a_meisyou[0, 4, 7] = obj.Meisyou047;
                //MainWindow.a_meisyou[0, 4, 8] = obj.Meisyou048;
                //MainWindow.a_meisyou[0, 4, 9] = obj.Meisyou049;
                ////1-Stream6
                //MainWindow.a_meisyou[0, 5, 0] = obj.Meisyou050;
                //MainWindow.a_meisyou[0, 5, 1] = obj.Meisyou051;
                //MainWindow.a_meisyou[0, 5, 2] = obj.Meisyou052;
                //MainWindow.a_meisyou[0, 5, 3] = obj.Meisyou053;
                //MainWindow.a_meisyou[0, 5, 4] = obj.Meisyou054;
                //MainWindow.a_meisyou[0, 5, 5] = obj.Meisyou055;
                //MainWindow.a_meisyou[0, 5, 6] = obj.Meisyou056;
                //MainWindow.a_meisyou[0, 5, 7] = obj.Meisyou057;
                //MainWindow.a_meisyou[0, 5, 8] = obj.Meisyou058;
                //MainWindow.a_meisyou[0, 5, 9] = obj.Meisyou059;
                ////1-Stream7
                //MainWindow.a_meisyou[0, 6, 0] = obj.Meisyou060;
                //MainWindow.a_meisyou[0, 6, 1] = obj.Meisyou061;
                //MainWindow.a_meisyou[0, 6, 2] = obj.Meisyou062;
                //MainWindow.a_meisyou[0, 6, 3] = obj.Meisyou063;
                //MainWindow.a_meisyou[0, 6, 4] = obj.Meisyou064;
                //MainWindow.a_meisyou[0, 6, 5] = obj.Meisyou065;
                //MainWindow.a_meisyou[0, 6, 6] = obj.Meisyou066;
                //MainWindow.a_meisyou[0, 6, 7] = obj.Meisyou067;
                //MainWindow.a_meisyou[0, 6, 8] = obj.Meisyou068;
                //MainWindow.a_meisyou[0, 6, 9] = obj.Meisyou069;
                ////1-Stream8
                //MainWindow.a_meisyou[0, 7, 0] = obj.Meisyou070;
                //MainWindow.a_meisyou[0, 7, 1] = obj.Meisyou071;
                //MainWindow.a_meisyou[0, 7, 2] = obj.Meisyou072;
                //MainWindow.a_meisyou[0, 7, 3] = obj.Meisyou073;
                //MainWindow.a_meisyou[0, 7, 4] = obj.Meisyou074;
                //MainWindow.a_meisyou[0, 7, 5] = obj.Meisyou075;
                //MainWindow.a_meisyou[0, 7, 6] = obj.Meisyou076;
                //MainWindow.a_meisyou[0, 7, 7] = obj.Meisyou077;
                //MainWindow.a_meisyou[0, 7, 8] = obj.Meisyou078;
                //MainWindow.a_meisyou[0, 7, 9] = obj.Meisyou079;
                ////1-Stream9
                //MainWindow.a_meisyou[0, 8, 0] = obj.Meisyou080;
                //MainWindow.a_meisyou[0, 8, 1] = obj.Meisyou081;
                //MainWindow.a_meisyou[0, 8, 2] = obj.Meisyou082;
                //MainWindow.a_meisyou[0, 8, 3] = obj.Meisyou083;
                //MainWindow.a_meisyou[0, 8, 4] = obj.Meisyou084;
                //MainWindow.a_meisyou[0, 8, 5] = obj.Meisyou085;
                //MainWindow.a_meisyou[0, 8, 6] = obj.Meisyou086;
                //MainWindow.a_meisyou[0, 8, 7] = obj.Meisyou087;
                //MainWindow.a_meisyou[0, 8, 8] = obj.Meisyou088;
                //MainWindow.a_meisyou[0, 8, 9] = obj.Meisyou089;
                ////1-Stream10
                //MainWindow.a_meisyou[0, 9, 0] = obj.Meisyou090;
                //MainWindow.a_meisyou[0, 9, 1] = obj.Meisyou091;
                //MainWindow.a_meisyou[0, 9, 2] = obj.Meisyou092;
                //MainWindow.a_meisyou[0, 9, 3] = obj.Meisyou093;
                //MainWindow.a_meisyou[0, 9, 4] = obj.Meisyou094;
                //MainWindow.a_meisyou[0, 9, 5] = obj.Meisyou095;
                //MainWindow.a_meisyou[0, 9, 6] = obj.Meisyou096;
                //MainWindow.a_meisyou[0, 9, 7] = obj.Meisyou097;
                //MainWindow.a_meisyou[0, 9, 8] = obj.Meisyou098;
                //MainWindow.a_meisyou[0, 9, 9] = obj.Meisyou099;
                ////1-Stream11
                //MainWindow.a_meisyou[0, 10, 0] = obj.Meisyou0A0;
                //MainWindow.a_meisyou[0, 10, 1] = obj.Meisyou0A1;
                //MainWindow.a_meisyou[0, 10, 2] = obj.Meisyou0A2;
                //MainWindow.a_meisyou[0, 10, 3] = obj.Meisyou0A3;
                //MainWindow.a_meisyou[0, 10, 4] = obj.Meisyou0A4;
                //MainWindow.a_meisyou[0, 10, 5] = obj.Meisyou0A5;
                //MainWindow.a_meisyou[0, 10, 6] = obj.Meisyou0A6;
                //MainWindow.a_meisyou[0, 10, 7] = obj.Meisyou0A7;
                //MainWindow.a_meisyou[0, 10, 8] = obj.Meisyou0A8;
                //MainWindow.a_meisyou[0, 10, 9] = obj.Meisyou0A9;

                ////品種2
                ////2-Stream1
                //MainWindow.a_meisyou[1, 0, 0] = obj.Meisyou100;
                //MainWindow.a_meisyou[1, 0, 1] = obj.Meisyou101;
                //MainWindow.a_meisyou[1, 0, 2] = obj.Meisyou102;
                //MainWindow.a_meisyou[1, 0, 3] = obj.Meisyou103;
                //MainWindow.a_meisyou[1, 0, 4] = obj.Meisyou104;
                //MainWindow.a_meisyou[1, 0, 5] = obj.Meisyou105;
                //MainWindow.a_meisyou[1, 0, 6] = obj.Meisyou106;
                //MainWindow.a_meisyou[1, 0, 7] = obj.Meisyou107;
                //MainWindow.a_meisyou[1, 0, 8] = obj.Meisyou108;
                //MainWindow.a_meisyou[1, 0, 9] = obj.Meisyou109;
                ////2-Stream2
                //MainWindow.a_meisyou[1, 1, 0] = obj.Meisyou110;
                //MainWindow.a_meisyou[1, 1, 1] = obj.Meisyou111;
                //MainWindow.a_meisyou[1, 1, 2] = obj.Meisyou112;
                //MainWindow.a_meisyou[1, 1, 3] = obj.Meisyou113;
                //MainWindow.a_meisyou[1, 1, 4] = obj.Meisyou114;
                //MainWindow.a_meisyou[1, 1, 5] = obj.Meisyou115;
                //MainWindow.a_meisyou[1, 1, 6] = obj.Meisyou116;
                //MainWindow.a_meisyou[1, 1, 7] = obj.Meisyou117;
                //MainWindow.a_meisyou[1, 1, 8] = obj.Meisyou118;
                //MainWindow.a_meisyou[1, 1, 9] = obj.Meisyou119;
                ////2-Stream3
                //MainWindow.a_meisyou[1, 2, 0] = obj.Meisyou120;
                //MainWindow.a_meisyou[1, 2, 1] = obj.Meisyou121;
                //MainWindow.a_meisyou[1, 2, 2] = obj.Meisyou122;
                //MainWindow.a_meisyou[1, 2, 3] = obj.Meisyou123;
                //MainWindow.a_meisyou[1, 2, 4] = obj.Meisyou124;
                //MainWindow.a_meisyou[1, 2, 5] = obj.Meisyou125;
                //MainWindow.a_meisyou[1, 2, 6] = obj.Meisyou126;
                //MainWindow.a_meisyou[1, 2, 7] = obj.Meisyou127;
                //MainWindow.a_meisyou[1, 2, 8] = obj.Meisyou128;
                //MainWindow.a_meisyou[1, 2, 9] = obj.Meisyou129;
                ////2-Stream4
                //MainWindow.a_meisyou[1, 3, 0] = obj.Meisyou130;
                //MainWindow.a_meisyou[1, 3, 1] = obj.Meisyou131;
                //MainWindow.a_meisyou[1, 3, 2] = obj.Meisyou132;
                //MainWindow.a_meisyou[1, 3, 3] = obj.Meisyou133;
                //MainWindow.a_meisyou[1, 3, 4] = obj.Meisyou134;
                //MainWindow.a_meisyou[1, 3, 5] = obj.Meisyou135;
                //MainWindow.a_meisyou[1, 3, 6] = obj.Meisyou136;
                //MainWindow.a_meisyou[1, 3, 7] = obj.Meisyou137;
                //MainWindow.a_meisyou[1, 3, 8] = obj.Meisyou138;
                //MainWindow.a_meisyou[1, 3, 9] = obj.Meisyou139;
                ////2-Stream5
                //MainWindow.a_meisyou[1, 4, 0] = obj.Meisyou140;
                //MainWindow.a_meisyou[1, 4, 1] = obj.Meisyou141;
                //MainWindow.a_meisyou[1, 4, 2] = obj.Meisyou142;
                //MainWindow.a_meisyou[1, 4, 3] = obj.Meisyou143;
                //MainWindow.a_meisyou[1, 4, 4] = obj.Meisyou144;
                //MainWindow.a_meisyou[1, 4, 5] = obj.Meisyou145;
                //MainWindow.a_meisyou[1, 4, 6] = obj.Meisyou146;
                //MainWindow.a_meisyou[1, 4, 7] = obj.Meisyou147;
                //MainWindow.a_meisyou[1, 4, 8] = obj.Meisyou148;
                //MainWindow.a_meisyou[1, 4, 9] = obj.Meisyou149;
                ////2-Stream6
                //MainWindow.a_meisyou[1, 5, 0] = obj.Meisyou150;
                //MainWindow.a_meisyou[1, 5, 1] = obj.Meisyou151;
                //MainWindow.a_meisyou[1, 5, 2] = obj.Meisyou152;
                //MainWindow.a_meisyou[1, 5, 3] = obj.Meisyou153;
                //MainWindow.a_meisyou[1, 5, 4] = obj.Meisyou154;
                //MainWindow.a_meisyou[1, 5, 5] = obj.Meisyou155;
                //MainWindow.a_meisyou[1, 5, 6] = obj.Meisyou156;
                //MainWindow.a_meisyou[1, 5, 7] = obj.Meisyou157;
                //MainWindow.a_meisyou[1, 5, 8] = obj.Meisyou158;
                //MainWindow.a_meisyou[1, 5, 9] = obj.Meisyou159;
                ////2-Stream7
                //MainWindow.a_meisyou[1, 6, 0] = obj.Meisyou160;
                //MainWindow.a_meisyou[1, 6, 1] = obj.Meisyou161;
                //MainWindow.a_meisyou[1, 6, 2] = obj.Meisyou162;
                //MainWindow.a_meisyou[1, 6, 3] = obj.Meisyou163;
                //MainWindow.a_meisyou[1, 6, 4] = obj.Meisyou164;
                //MainWindow.a_meisyou[1, 6, 5] = obj.Meisyou165;
                //MainWindow.a_meisyou[1, 6, 6] = obj.Meisyou166;
                //MainWindow.a_meisyou[1, 6, 7] = obj.Meisyou167;
                //MainWindow.a_meisyou[1, 6, 8] = obj.Meisyou168;
                //MainWindow.a_meisyou[1, 6, 9] = obj.Meisyou169;
                ////2-Stream8
                //MainWindow.a_meisyou[1, 7, 0] = obj.Meisyou170;
                //MainWindow.a_meisyou[1, 7, 1] = obj.Meisyou171;
                //MainWindow.a_meisyou[1, 7, 2] = obj.Meisyou172;
                //MainWindow.a_meisyou[1, 7, 3] = obj.Meisyou173;
                //MainWindow.a_meisyou[1, 7, 4] = obj.Meisyou174;
                //MainWindow.a_meisyou[1, 7, 5] = obj.Meisyou175;
                //MainWindow.a_meisyou[1, 7, 6] = obj.Meisyou176;
                //MainWindow.a_meisyou[1, 7, 7] = obj.Meisyou177;
                //MainWindow.a_meisyou[1, 7, 8] = obj.Meisyou178;
                //MainWindow.a_meisyou[1, 7, 9] = obj.Meisyou179;
                ////2-Stream9
                //MainWindow.a_meisyou[1, 8, 0] = obj.Meisyou180;
                //MainWindow.a_meisyou[1, 8, 1] = obj.Meisyou181;
                //MainWindow.a_meisyou[1, 8, 2] = obj.Meisyou182;
                //MainWindow.a_meisyou[1, 8, 3] = obj.Meisyou183;
                //MainWindow.a_meisyou[1, 8, 4] = obj.Meisyou184;
                //MainWindow.a_meisyou[1, 8, 5] = obj.Meisyou185;
                //MainWindow.a_meisyou[1, 8, 6] = obj.Meisyou186;
                //MainWindow.a_meisyou[1, 8, 7] = obj.Meisyou187;
                //MainWindow.a_meisyou[1, 8, 8] = obj.Meisyou188;
                //MainWindow.a_meisyou[1, 8, 9] = obj.Meisyou189;
                ////2-Stream10
                //MainWindow.a_meisyou[1, 9, 0] = obj.Meisyou190;
                //MainWindow.a_meisyou[1, 9, 1] = obj.Meisyou191;
                //MainWindow.a_meisyou[1, 9, 2] = obj.Meisyou192;
                //MainWindow.a_meisyou[1, 9, 3] = obj.Meisyou193;
                //MainWindow.a_meisyou[1, 9, 4] = obj.Meisyou194;
                //MainWindow.a_meisyou[1, 9, 5] = obj.Meisyou195;
                //MainWindow.a_meisyou[1, 9, 6] = obj.Meisyou196;
                //MainWindow.a_meisyou[1, 9, 7] = obj.Meisyou197;
                //MainWindow.a_meisyou[1, 9, 8] = obj.Meisyou198;
                //MainWindow.a_meisyou[1, 9, 9] = obj.Meisyou199;
                ////2-Stream11
                //MainWindow.a_meisyou[1, 10, 0] = obj.Meisyou1A0;
                //MainWindow.a_meisyou[1, 10, 1] = obj.Meisyou1A1;
                //MainWindow.a_meisyou[1, 10, 2] = obj.Meisyou1A2;
                //MainWindow.a_meisyou[1, 10, 3] = obj.Meisyou1A3;
                //MainWindow.a_meisyou[1, 10, 4] = obj.Meisyou1A4;
                //MainWindow.a_meisyou[1, 10, 5] = obj.Meisyou1A5;
                //MainWindow.a_meisyou[1, 10, 6] = obj.Meisyou1A6;
                //MainWindow.a_meisyou[1, 10, 7] = obj.Meisyou1A7;
                //MainWindow.a_meisyou[1, 10, 8] = obj.Meisyou1A8;
                //MainWindow.a_meisyou[1, 10, 9] = obj.Meisyou1A9;

                ////品種3
                ////3-Stream1
                //MainWindow.a_meisyou[2, 0, 0] = obj.Meisyou200;
                //MainWindow.a_meisyou[2, 0, 1] = obj.Meisyou201;
                //MainWindow.a_meisyou[2, 0, 2] = obj.Meisyou202;
                //MainWindow.a_meisyou[2, 0, 3] = obj.Meisyou203;
                //MainWindow.a_meisyou[2, 0, 4] = obj.Meisyou204;
                //MainWindow.a_meisyou[2, 0, 5] = obj.Meisyou205;
                //MainWindow.a_meisyou[2, 0, 6] = obj.Meisyou206;
                //MainWindow.a_meisyou[2, 0, 7] = obj.Meisyou207;
                //MainWindow.a_meisyou[2, 0, 8] = obj.Meisyou208;
                //MainWindow.a_meisyou[2, 0, 9] = obj.Meisyou209;
                ////3-Stream2
                //MainWindow.a_meisyou[2, 1, 0] = obj.Meisyou210;
                //MainWindow.a_meisyou[2, 1, 1] = obj.Meisyou211;
                //MainWindow.a_meisyou[2, 1, 2] = obj.Meisyou212;
                //MainWindow.a_meisyou[2, 1, 3] = obj.Meisyou213;
                //MainWindow.a_meisyou[2, 1, 4] = obj.Meisyou214;
                //MainWindow.a_meisyou[2, 1, 5] = obj.Meisyou215;
                //MainWindow.a_meisyou[2, 1, 6] = obj.Meisyou216;
                //MainWindow.a_meisyou[2, 1, 7] = obj.Meisyou217;
                //MainWindow.a_meisyou[2, 1, 8] = obj.Meisyou218;
                //MainWindow.a_meisyou[2, 1, 9] = obj.Meisyou219;
                ////3-Stream3
                //MainWindow.a_meisyou[2, 2, 0] = obj.Meisyou220;
                //MainWindow.a_meisyou[2, 2, 1] = obj.Meisyou221;
                //MainWindow.a_meisyou[2, 2, 2] = obj.Meisyou222;
                //MainWindow.a_meisyou[2, 2, 3] = obj.Meisyou223;
                //MainWindow.a_meisyou[2, 2, 4] = obj.Meisyou224;
                //MainWindow.a_meisyou[2, 2, 5] = obj.Meisyou225;
                //MainWindow.a_meisyou[2, 2, 6] = obj.Meisyou226;
                //MainWindow.a_meisyou[2, 2, 7] = obj.Meisyou227;
                //MainWindow.a_meisyou[2, 2, 8] = obj.Meisyou228;
                //MainWindow.a_meisyou[2, 2, 9] = obj.Meisyou229;
                ////3-Stream4
                //MainWindow.a_meisyou[2, 3, 0] = obj.Meisyou230;
                //MainWindow.a_meisyou[2, 3, 1] = obj.Meisyou231;
                //MainWindow.a_meisyou[2, 3, 2] = obj.Meisyou232;
                //MainWindow.a_meisyou[2, 3, 3] = obj.Meisyou233;
                //MainWindow.a_meisyou[2, 3, 4] = obj.Meisyou234;
                //MainWindow.a_meisyou[2, 3, 5] = obj.Meisyou235;
                //MainWindow.a_meisyou[2, 3, 6] = obj.Meisyou236;
                //MainWindow.a_meisyou[2, 3, 7] = obj.Meisyou237;
                //MainWindow.a_meisyou[2, 3, 8] = obj.Meisyou238;
                //MainWindow.a_meisyou[2, 3, 9] = obj.Meisyou239;
                ////3-Stream5
                //MainWindow.a_meisyou[2, 4, 0] = obj.Meisyou240;
                //MainWindow.a_meisyou[2, 4, 1] = obj.Meisyou241;
                //MainWindow.a_meisyou[2, 4, 2] = obj.Meisyou242;
                //MainWindow.a_meisyou[2, 4, 3] = obj.Meisyou243;
                //MainWindow.a_meisyou[2, 4, 4] = obj.Meisyou244;
                //MainWindow.a_meisyou[2, 4, 5] = obj.Meisyou245;
                //MainWindow.a_meisyou[2, 4, 6] = obj.Meisyou246;
                //MainWindow.a_meisyou[2, 4, 7] = obj.Meisyou247;
                //MainWindow.a_meisyou[2, 4, 8] = obj.Meisyou248;
                //MainWindow.a_meisyou[2, 4, 9] = obj.Meisyou249;
                ////3-Stream6
                //MainWindow.a_meisyou[2, 5, 0] = obj.Meisyou250;
                //MainWindow.a_meisyou[2, 5, 1] = obj.Meisyou251;
                //MainWindow.a_meisyou[2, 5, 2] = obj.Meisyou252;
                //MainWindow.a_meisyou[2, 5, 3] = obj.Meisyou253;
                //MainWindow.a_meisyou[2, 5, 4] = obj.Meisyou254;
                //MainWindow.a_meisyou[2, 5, 5] = obj.Meisyou255;
                //MainWindow.a_meisyou[2, 5, 6] = obj.Meisyou256;
                //MainWindow.a_meisyou[2, 5, 7] = obj.Meisyou257;
                //MainWindow.a_meisyou[2, 5, 8] = obj.Meisyou258;
                //MainWindow.a_meisyou[2, 5, 9] = obj.Meisyou259;
                ////3-Stream7
                //MainWindow.a_meisyou[2, 6, 0] = obj.Meisyou260;
                //MainWindow.a_meisyou[2, 6, 1] = obj.Meisyou261;
                //MainWindow.a_meisyou[2, 6, 2] = obj.Meisyou262;
                //MainWindow.a_meisyou[2, 6, 3] = obj.Meisyou263;
                //MainWindow.a_meisyou[2, 6, 4] = obj.Meisyou264;
                //MainWindow.a_meisyou[2, 6, 5] = obj.Meisyou265;
                //MainWindow.a_meisyou[2, 6, 6] = obj.Meisyou266;
                //MainWindow.a_meisyou[2, 6, 7] = obj.Meisyou267;
                //MainWindow.a_meisyou[2, 6, 8] = obj.Meisyou268;
                //MainWindow.a_meisyou[2, 6, 9] = obj.Meisyou269;
                ////3-Stream8
                //MainWindow.a_meisyou[2, 7, 0] = obj.Meisyou270;
                //MainWindow.a_meisyou[2, 7, 1] = obj.Meisyou271;
                //MainWindow.a_meisyou[2, 7, 2] = obj.Meisyou272;
                //MainWindow.a_meisyou[2, 7, 3] = obj.Meisyou273;
                //MainWindow.a_meisyou[2, 7, 4] = obj.Meisyou274;
                //MainWindow.a_meisyou[2, 7, 5] = obj.Meisyou275;
                //MainWindow.a_meisyou[2, 7, 6] = obj.Meisyou276;
                //MainWindow.a_meisyou[2, 7, 7] = obj.Meisyou277;
                //MainWindow.a_meisyou[2, 7, 8] = obj.Meisyou278;
                //MainWindow.a_meisyou[2, 7, 9] = obj.Meisyou279;
                ////3-Stream9
                //MainWindow.a_meisyou[2, 8, 0] = obj.Meisyou280;
                //MainWindow.a_meisyou[2, 8, 1] = obj.Meisyou281;
                //MainWindow.a_meisyou[2, 8, 2] = obj.Meisyou282;
                //MainWindow.a_meisyou[2, 8, 3] = obj.Meisyou283;
                //MainWindow.a_meisyou[2, 8, 4] = obj.Meisyou284;
                //MainWindow.a_meisyou[2, 8, 5] = obj.Meisyou285;
                //MainWindow.a_meisyou[2, 8, 6] = obj.Meisyou286;
                //MainWindow.a_meisyou[2, 8, 7] = obj.Meisyou287;
                //MainWindow.a_meisyou[2, 8, 8] = obj.Meisyou288;
                //MainWindow.a_meisyou[2, 8, 9] = obj.Meisyou289;
                ////3-Stream10
                //MainWindow.a_meisyou[2, 9, 0] = obj.Meisyou290;
                //MainWindow.a_meisyou[2, 9, 1] = obj.Meisyou291;
                //MainWindow.a_meisyou[2, 9, 2] = obj.Meisyou292;
                //MainWindow.a_meisyou[2, 9, 3] = obj.Meisyou293;
                //MainWindow.a_meisyou[2, 9, 4] = obj.Meisyou294;
                //MainWindow.a_meisyou[2, 9, 5] = obj.Meisyou295;
                //MainWindow.a_meisyou[2, 9, 6] = obj.Meisyou296;
                //MainWindow.a_meisyou[2, 9, 7] = obj.Meisyou297;
                //MainWindow.a_meisyou[2, 9, 8] = obj.Meisyou298;
                //MainWindow.a_meisyou[2, 9, 9] = obj.Meisyou299;
                ////3-Stream11
                //MainWindow.a_meisyou[2, 10, 0] = obj.Meisyou2A0;
                //MainWindow.a_meisyou[2, 10, 1] = obj.Meisyou2A1;
                //MainWindow.a_meisyou[2, 10, 2] = obj.Meisyou2A2;
                //MainWindow.a_meisyou[2, 10, 3] = obj.Meisyou2A3;
                //MainWindow.a_meisyou[2, 10, 4] = obj.Meisyou2A4;
                //MainWindow.a_meisyou[2, 10, 5] = obj.Meisyou2A5;
                //MainWindow.a_meisyou[2, 10, 6] = obj.Meisyou2A6;
                //MainWindow.a_meisyou[2, 10, 7] = obj.Meisyou2A7;
                //MainWindow.a_meisyou[2, 10, 8] = obj.Meisyou2A8;
                //MainWindow.a_meisyou[2, 10, 9] = obj.Meisyou2A9;

                ////品種4
                ////4-Stream1
                //MainWindow.a_meisyou[3, 0, 0] = obj.Meisyou300;
                //MainWindow.a_meisyou[3, 0, 1] = obj.Meisyou301;
                //MainWindow.a_meisyou[3, 0, 2] = obj.Meisyou302;
                //MainWindow.a_meisyou[3, 0, 3] = obj.Meisyou303;
                //MainWindow.a_meisyou[3, 0, 4] = obj.Meisyou304;
                //MainWindow.a_meisyou[3, 0, 5] = obj.Meisyou305;
                //MainWindow.a_meisyou[3, 0, 6] = obj.Meisyou306;
                //MainWindow.a_meisyou[3, 0, 7] = obj.Meisyou307;
                //MainWindow.a_meisyou[3, 0, 8] = obj.Meisyou308;
                //MainWindow.a_meisyou[3, 0, 9] = obj.Meisyou309;
                ////4-Stream2
                //MainWindow.a_meisyou[3, 1, 0] = obj.Meisyou310;
                //MainWindow.a_meisyou[3, 1, 1] = obj.Meisyou311;
                //MainWindow.a_meisyou[3, 1, 2] = obj.Meisyou312;
                //MainWindow.a_meisyou[3, 1, 3] = obj.Meisyou313;
                //MainWindow.a_meisyou[3, 1, 4] = obj.Meisyou314;
                //MainWindow.a_meisyou[3, 1, 5] = obj.Meisyou315;
                //MainWindow.a_meisyou[3, 1, 6] = obj.Meisyou316;
                //MainWindow.a_meisyou[3, 1, 7] = obj.Meisyou317;
                //MainWindow.a_meisyou[3, 1, 8] = obj.Meisyou318;
                //MainWindow.a_meisyou[3, 1, 9] = obj.Meisyou319;
                ////4-Stream3
                //MainWindow.a_meisyou[3, 2, 0] = obj.Meisyou320;
                //MainWindow.a_meisyou[3, 2, 1] = obj.Meisyou321;
                //MainWindow.a_meisyou[3, 2, 2] = obj.Meisyou322;
                //MainWindow.a_meisyou[3, 2, 3] = obj.Meisyou323;
                //MainWindow.a_meisyou[3, 2, 4] = obj.Meisyou324;
                //MainWindow.a_meisyou[3, 2, 5] = obj.Meisyou325;
                //MainWindow.a_meisyou[3, 2, 6] = obj.Meisyou326;
                //MainWindow.a_meisyou[3, 2, 7] = obj.Meisyou327;
                //MainWindow.a_meisyou[3, 2, 8] = obj.Meisyou328;
                //MainWindow.a_meisyou[3, 2, 9] = obj.Meisyou329;
                ////4-Stream4
                //MainWindow.a_meisyou[3, 3, 0] = obj.Meisyou330;
                //MainWindow.a_meisyou[3, 3, 1] = obj.Meisyou331;
                //MainWindow.a_meisyou[3, 3, 2] = obj.Meisyou332;
                //MainWindow.a_meisyou[3, 3, 3] = obj.Meisyou333;
                //MainWindow.a_meisyou[3, 3, 4] = obj.Meisyou334;
                //MainWindow.a_meisyou[3, 3, 5] = obj.Meisyou335;
                //MainWindow.a_meisyou[3, 3, 6] = obj.Meisyou336;
                //MainWindow.a_meisyou[3, 3, 7] = obj.Meisyou337;
                //MainWindow.a_meisyou[3, 3, 8] = obj.Meisyou338;
                //MainWindow.a_meisyou[3, 3, 9] = obj.Meisyou339;
                ////4-Stream5
                //MainWindow.a_meisyou[3, 4, 0] = obj.Meisyou340;
                //MainWindow.a_meisyou[3, 4, 1] = obj.Meisyou341;
                //MainWindow.a_meisyou[3, 4, 2] = obj.Meisyou342;
                //MainWindow.a_meisyou[3, 4, 3] = obj.Meisyou343;
                //MainWindow.a_meisyou[3, 4, 4] = obj.Meisyou344;
                //MainWindow.a_meisyou[3, 4, 5] = obj.Meisyou345;
                //MainWindow.a_meisyou[3, 4, 6] = obj.Meisyou346;
                //MainWindow.a_meisyou[3, 4, 7] = obj.Meisyou347;
                //MainWindow.a_meisyou[3, 4, 8] = obj.Meisyou348;
                //MainWindow.a_meisyou[3, 4, 9] = obj.Meisyou349;
                ////4-Stream6
                //MainWindow.a_meisyou[3, 5, 0] = obj.Meisyou350;
                //MainWindow.a_meisyou[3, 5, 1] = obj.Meisyou351;
                //MainWindow.a_meisyou[3, 5, 2] = obj.Meisyou352;
                //MainWindow.a_meisyou[3, 5, 3] = obj.Meisyou353;
                //MainWindow.a_meisyou[3, 5, 4] = obj.Meisyou354;
                //MainWindow.a_meisyou[3, 5, 5] = obj.Meisyou355;
                //MainWindow.a_meisyou[3, 5, 6] = obj.Meisyou356;
                //MainWindow.a_meisyou[3, 5, 7] = obj.Meisyou357;
                //MainWindow.a_meisyou[3, 5, 8] = obj.Meisyou358;
                //MainWindow.a_meisyou[3, 5, 9] = obj.Meisyou359;
                ////4-Stream7
                //MainWindow.a_meisyou[3, 6, 0] = obj.Meisyou360;
                //MainWindow.a_meisyou[3, 6, 1] = obj.Meisyou361;
                //MainWindow.a_meisyou[3, 6, 2] = obj.Meisyou362;
                //MainWindow.a_meisyou[3, 6, 3] = obj.Meisyou363;
                //MainWindow.a_meisyou[3, 6, 4] = obj.Meisyou364;
                //MainWindow.a_meisyou[3, 6, 5] = obj.Meisyou365;
                //MainWindow.a_meisyou[3, 6, 6] = obj.Meisyou366;
                //MainWindow.a_meisyou[3, 6, 7] = obj.Meisyou367;
                //MainWindow.a_meisyou[3, 6, 8] = obj.Meisyou368;
                //MainWindow.a_meisyou[3, 6, 9] = obj.Meisyou369;
                ////4-Stream8
                //MainWindow.a_meisyou[3, 7, 0] = obj.Meisyou370;
                //MainWindow.a_meisyou[3, 7, 1] = obj.Meisyou371;
                //MainWindow.a_meisyou[3, 7, 2] = obj.Meisyou372;
                //MainWindow.a_meisyou[3, 7, 3] = obj.Meisyou373;
                //MainWindow.a_meisyou[3, 7, 4] = obj.Meisyou374;
                //MainWindow.a_meisyou[3, 7, 5] = obj.Meisyou375;
                //MainWindow.a_meisyou[3, 7, 6] = obj.Meisyou376;
                //MainWindow.a_meisyou[3, 7, 7] = obj.Meisyou377;
                //MainWindow.a_meisyou[3, 7, 8] = obj.Meisyou378;
                //MainWindow.a_meisyou[3, 7, 9] = obj.Meisyou379;
                ////4-Stream9
                //MainWindow.a_meisyou[3, 8, 0] = obj.Meisyou380;
                //MainWindow.a_meisyou[3, 8, 1] = obj.Meisyou381;
                //MainWindow.a_meisyou[3, 8, 2] = obj.Meisyou382;
                //MainWindow.a_meisyou[3, 8, 3] = obj.Meisyou383;
                //MainWindow.a_meisyou[3, 8, 4] = obj.Meisyou384;
                //MainWindow.a_meisyou[3, 8, 5] = obj.Meisyou385;
                //MainWindow.a_meisyou[3, 8, 6] = obj.Meisyou386;
                //MainWindow.a_meisyou[3, 8, 7] = obj.Meisyou387;
                //MainWindow.a_meisyou[3, 8, 8] = obj.Meisyou388;
                //MainWindow.a_meisyou[3, 8, 9] = obj.Meisyou389;
                ////4-Stream10
                //MainWindow.a_meisyou[3, 9, 0] = obj.Meisyou390;
                //MainWindow.a_meisyou[3, 9, 1] = obj.Meisyou391;
                //MainWindow.a_meisyou[3, 9, 2] = obj.Meisyou392;
                //MainWindow.a_meisyou[3, 9, 3] = obj.Meisyou393;
                //MainWindow.a_meisyou[3, 9, 4] = obj.Meisyou394;
                //MainWindow.a_meisyou[3, 9, 5] = obj.Meisyou395;
                //MainWindow.a_meisyou[3, 9, 6] = obj.Meisyou396;
                //MainWindow.a_meisyou[3, 9, 7] = obj.Meisyou397;
                //MainWindow.a_meisyou[3, 9, 8] = obj.Meisyou398;
                //MainWindow.a_meisyou[3, 9, 9] = obj.Meisyou399;
                ////4-Stream11
                //MainWindow.a_meisyou[3, 10, 0] = obj.Meisyou3A0;
                //MainWindow.a_meisyou[3, 10, 1] = obj.Meisyou3A1;
                //MainWindow.a_meisyou[3, 10, 2] = obj.Meisyou3A2;
                //MainWindow.a_meisyou[3, 10, 3] = obj.Meisyou3A3;
                //MainWindow.a_meisyou[3, 10, 4] = obj.Meisyou3A4;
                //MainWindow.a_meisyou[3, 10, 5] = obj.Meisyou3A5;
                //MainWindow.a_meisyou[3, 10, 6] = obj.Meisyou3A6;
                //MainWindow.a_meisyou[3, 10, 7] = obj.Meisyou3A7;
                //MainWindow.a_meisyou[3, 10, 8] = obj.Meisyou3A8;
                //MainWindow.a_meisyou[3, 10, 9] = obj.Meisyou3A9;

                ////品種5
                ////5-Stream1
                //MainWindow.a_meisyou[4, 0, 0] = obj.Meisyou400;
                //MainWindow.a_meisyou[4, 0, 1] = obj.Meisyou401;
                //MainWindow.a_meisyou[4, 0, 2] = obj.Meisyou402;
                //MainWindow.a_meisyou[4, 0, 3] = obj.Meisyou403;
                //MainWindow.a_meisyou[4, 0, 4] = obj.Meisyou404;
                //MainWindow.a_meisyou[4, 0, 5] = obj.Meisyou405;
                //MainWindow.a_meisyou[4, 0, 6] = obj.Meisyou406;
                //MainWindow.a_meisyou[4, 0, 7] = obj.Meisyou407;
                //MainWindow.a_meisyou[4, 0, 8] = obj.Meisyou408;
                //MainWindow.a_meisyou[4, 0, 9] = obj.Meisyou409;
                ////5-Stream2
                //MainWindow.a_meisyou[4, 1, 0] = obj.Meisyou410;
                //MainWindow.a_meisyou[4, 1, 1] = obj.Meisyou411;
                //MainWindow.a_meisyou[4, 1, 2] = obj.Meisyou412;
                //MainWindow.a_meisyou[4, 1, 3] = obj.Meisyou413;
                //MainWindow.a_meisyou[4, 1, 4] = obj.Meisyou414;
                //MainWindow.a_meisyou[4, 1, 5] = obj.Meisyou415;
                //MainWindow.a_meisyou[4, 1, 6] = obj.Meisyou416;
                //MainWindow.a_meisyou[4, 1, 7] = obj.Meisyou417;
                //MainWindow.a_meisyou[4, 1, 8] = obj.Meisyou418;
                //MainWindow.a_meisyou[4, 1, 9] = obj.Meisyou419;
                ////5-Stream3
                //MainWindow.a_meisyou[4, 2, 0] = obj.Meisyou420;
                //MainWindow.a_meisyou[4, 2, 1] = obj.Meisyou421;
                //MainWindow.a_meisyou[4, 2, 2] = obj.Meisyou422;
                //MainWindow.a_meisyou[4, 2, 3] = obj.Meisyou423;
                //MainWindow.a_meisyou[4, 2, 4] = obj.Meisyou424;
                //MainWindow.a_meisyou[4, 2, 5] = obj.Meisyou425;
                //MainWindow.a_meisyou[4, 2, 6] = obj.Meisyou426;
                //MainWindow.a_meisyou[4, 2, 7] = obj.Meisyou427;
                //MainWindow.a_meisyou[4, 2, 8] = obj.Meisyou428;
                //MainWindow.a_meisyou[4, 2, 9] = obj.Meisyou429;
                ////5-Stream4
                //MainWindow.a_meisyou[4, 3, 0] = obj.Meisyou430;
                //MainWindow.a_meisyou[4, 3, 1] = obj.Meisyou431;
                //MainWindow.a_meisyou[4, 3, 2] = obj.Meisyou432;
                //MainWindow.a_meisyou[4, 3, 3] = obj.Meisyou433;
                //MainWindow.a_meisyou[4, 3, 4] = obj.Meisyou434;
                //MainWindow.a_meisyou[4, 3, 5] = obj.Meisyou435;
                //MainWindow.a_meisyou[4, 3, 6] = obj.Meisyou436;
                //MainWindow.a_meisyou[4, 3, 7] = obj.Meisyou437;
                //MainWindow.a_meisyou[4, 3, 8] = obj.Meisyou438;
                //MainWindow.a_meisyou[4, 3, 9] = obj.Meisyou439;
                ////5-Stream5
                //MainWindow.a_meisyou[4, 4, 0] = obj.Meisyou440;
                //MainWindow.a_meisyou[4, 4, 1] = obj.Meisyou441;
                //MainWindow.a_meisyou[4, 4, 2] = obj.Meisyou442;
                //MainWindow.a_meisyou[4, 4, 3] = obj.Meisyou443;
                //MainWindow.a_meisyou[4, 4, 4] = obj.Meisyou444;
                //MainWindow.a_meisyou[4, 4, 5] = obj.Meisyou445;
                //MainWindow.a_meisyou[4, 4, 6] = obj.Meisyou446;
                //MainWindow.a_meisyou[4, 4, 7] = obj.Meisyou447;
                //MainWindow.a_meisyou[4, 4, 8] = obj.Meisyou448;
                //MainWindow.a_meisyou[4, 4, 9] = obj.Meisyou449;
                ////5-Stream6
                //MainWindow.a_meisyou[4, 5, 0] = obj.Meisyou450;
                //MainWindow.a_meisyou[4, 5, 1] = obj.Meisyou451;
                //MainWindow.a_meisyou[4, 5, 2] = obj.Meisyou452;
                //MainWindow.a_meisyou[4, 5, 3] = obj.Meisyou453;
                //MainWindow.a_meisyou[4, 5, 4] = obj.Meisyou454;
                //MainWindow.a_meisyou[4, 5, 5] = obj.Meisyou455;
                //MainWindow.a_meisyou[4, 5, 6] = obj.Meisyou456;
                //MainWindow.a_meisyou[4, 5, 7] = obj.Meisyou457;
                //MainWindow.a_meisyou[4, 5, 8] = obj.Meisyou458;
                //MainWindow.a_meisyou[4, 5, 9] = obj.Meisyou459;
                ////5-Stream7
                //MainWindow.a_meisyou[4, 6, 0] = obj.Meisyou460;
                //MainWindow.a_meisyou[4, 6, 1] = obj.Meisyou461;
                //MainWindow.a_meisyou[4, 6, 2] = obj.Meisyou462;
                //MainWindow.a_meisyou[4, 6, 3] = obj.Meisyou463;
                //MainWindow.a_meisyou[4, 6, 4] = obj.Meisyou464;
                //MainWindow.a_meisyou[4, 6, 5] = obj.Meisyou465;
                //MainWindow.a_meisyou[4, 6, 6] = obj.Meisyou466;
                //MainWindow.a_meisyou[4, 6, 7] = obj.Meisyou467;
                //MainWindow.a_meisyou[4, 6, 8] = obj.Meisyou468;
                //MainWindow.a_meisyou[4, 6, 9] = obj.Meisyou469;
                ////5-Stream8
                //MainWindow.a_meisyou[4, 7, 0] = obj.Meisyou470;
                //MainWindow.a_meisyou[4, 7, 1] = obj.Meisyou471;
                //MainWindow.a_meisyou[4, 7, 2] = obj.Meisyou472;
                //MainWindow.a_meisyou[4, 7, 3] = obj.Meisyou473;
                //MainWindow.a_meisyou[4, 7, 4] = obj.Meisyou474;
                //MainWindow.a_meisyou[4, 7, 5] = obj.Meisyou475;
                //MainWindow.a_meisyou[4, 7, 6] = obj.Meisyou476;
                //MainWindow.a_meisyou[4, 7, 7] = obj.Meisyou477;
                //MainWindow.a_meisyou[4, 7, 8] = obj.Meisyou478;
                //MainWindow.a_meisyou[4, 7, 9] = obj.Meisyou479;
                ////5-Stream9
                //MainWindow.a_meisyou[4, 8, 0] = obj.Meisyou480;
                //MainWindow.a_meisyou[4, 8, 1] = obj.Meisyou481;
                //MainWindow.a_meisyou[4, 8, 2] = obj.Meisyou482;
                //MainWindow.a_meisyou[4, 8, 3] = obj.Meisyou483;
                //MainWindow.a_meisyou[4, 8, 4] = obj.Meisyou484;
                //MainWindow.a_meisyou[4, 8, 5] = obj.Meisyou485;
                //MainWindow.a_meisyou[4, 8, 6] = obj.Meisyou486;
                //MainWindow.a_meisyou[4, 8, 7] = obj.Meisyou487;
                //MainWindow.a_meisyou[4, 8, 8] = obj.Meisyou488;
                //MainWindow.a_meisyou[4, 8, 9] = obj.Meisyou489;
                ////5-Stream10
                //MainWindow.a_meisyou[4, 9, 0] = obj.Meisyou490;
                //MainWindow.a_meisyou[4, 9, 1] = obj.Meisyou491;
                //MainWindow.a_meisyou[4, 9, 2] = obj.Meisyou492;
                //MainWindow.a_meisyou[4, 9, 3] = obj.Meisyou493;
                //MainWindow.a_meisyou[4, 9, 4] = obj.Meisyou494;
                //MainWindow.a_meisyou[4, 9, 5] = obj.Meisyou495;
                //MainWindow.a_meisyou[4, 9, 6] = obj.Meisyou496;
                //MainWindow.a_meisyou[4, 9, 7] = obj.Meisyou497;
                //MainWindow.a_meisyou[4, 9, 8] = obj.Meisyou498;
                //MainWindow.a_meisyou[4, 9, 9] = obj.Meisyou499;
                ////5-Stream11
                //MainWindow.a_meisyou[4, 10, 0] = obj.Meisyou4A0;
                //MainWindow.a_meisyou[4, 10, 1] = obj.Meisyou4A1;
                //MainWindow.a_meisyou[4, 10, 2] = obj.Meisyou4A2;
                //MainWindow.a_meisyou[4, 10, 3] = obj.Meisyou4A3;
                //MainWindow.a_meisyou[4, 10, 4] = obj.Meisyou4A4;
                //MainWindow.a_meisyou[4, 10, 5] = obj.Meisyou4A5;
                //MainWindow.a_meisyou[4, 10, 6] = obj.Meisyou4A6;
                //MainWindow.a_meisyou[4, 10, 7] = obj.Meisyou4A7;
                //MainWindow.a_meisyou[4, 10, 8] = obj.Meisyou4A8;
                //MainWindow.a_meisyou[4, 10, 9] = obj.Meisyou4A9;

                ////品種6
                ////6-Stream1
                //MainWindow.a_meisyou[5, 0, 0] = obj.Meisyou500;
                //MainWindow.a_meisyou[5, 0, 1] = obj.Meisyou501;
                //MainWindow.a_meisyou[5, 0, 2] = obj.Meisyou502;
                //MainWindow.a_meisyou[5, 0, 3] = obj.Meisyou503;
                //MainWindow.a_meisyou[5, 0, 4] = obj.Meisyou504;
                //MainWindow.a_meisyou[5, 0, 5] = obj.Meisyou505;
                //MainWindow.a_meisyou[5, 0, 6] = obj.Meisyou506;
                //MainWindow.a_meisyou[5, 0, 7] = obj.Meisyou507;
                //MainWindow.a_meisyou[5, 0, 8] = obj.Meisyou508;
                //MainWindow.a_meisyou[5, 0, 9] = obj.Meisyou509;
                ////6-Stream2
                //MainWindow.a_meisyou[5, 1, 0] = obj.Meisyou510;
                //MainWindow.a_meisyou[5, 1, 1] = obj.Meisyou511;
                //MainWindow.a_meisyou[5, 1, 2] = obj.Meisyou512;
                //MainWindow.a_meisyou[5, 1, 3] = obj.Meisyou513;
                //MainWindow.a_meisyou[5, 1, 4] = obj.Meisyou514;
                //MainWindow.a_meisyou[5, 1, 5] = obj.Meisyou515;
                //MainWindow.a_meisyou[5, 1, 6] = obj.Meisyou516;
                //MainWindow.a_meisyou[5, 1, 7] = obj.Meisyou517;
                //MainWindow.a_meisyou[5, 1, 8] = obj.Meisyou518;
                //MainWindow.a_meisyou[5, 1, 9] = obj.Meisyou519;
                ////6-Stream3
                //MainWindow.a_meisyou[5, 2, 0] = obj.Meisyou520;
                //MainWindow.a_meisyou[5, 2, 1] = obj.Meisyou521;
                //MainWindow.a_meisyou[5, 2, 2] = obj.Meisyou522;
                //MainWindow.a_meisyou[5, 2, 3] = obj.Meisyou523;
                //MainWindow.a_meisyou[5, 2, 4] = obj.Meisyou524;
                //MainWindow.a_meisyou[5, 2, 5] = obj.Meisyou525;
                //MainWindow.a_meisyou[5, 2, 6] = obj.Meisyou526;
                //MainWindow.a_meisyou[5, 2, 7] = obj.Meisyou527;
                //MainWindow.a_meisyou[5, 2, 8] = obj.Meisyou528;
                //MainWindow.a_meisyou[5, 2, 9] = obj.Meisyou529;
                ////6-Stream4
                //MainWindow.a_meisyou[5, 3, 0] = obj.Meisyou530;
                //MainWindow.a_meisyou[5, 3, 1] = obj.Meisyou531;
                //MainWindow.a_meisyou[5, 3, 2] = obj.Meisyou532;
                //MainWindow.a_meisyou[5, 3, 3] = obj.Meisyou533;
                //MainWindow.a_meisyou[5, 3, 4] = obj.Meisyou534;
                //MainWindow.a_meisyou[5, 3, 5] = obj.Meisyou535;
                //MainWindow.a_meisyou[5, 3, 6] = obj.Meisyou536;
                //MainWindow.a_meisyou[5, 3, 7] = obj.Meisyou537;
                //MainWindow.a_meisyou[5, 3, 8] = obj.Meisyou538;
                //MainWindow.a_meisyou[5, 3, 9] = obj.Meisyou539;
                ////6-Stream5
                //MainWindow.a_meisyou[5, 4, 0] = obj.Meisyou540;
                //MainWindow.a_meisyou[5, 4, 1] = obj.Meisyou541;
                //MainWindow.a_meisyou[5, 4, 2] = obj.Meisyou542;
                //MainWindow.a_meisyou[5, 4, 3] = obj.Meisyou543;
                //MainWindow.a_meisyou[5, 4, 4] = obj.Meisyou544;
                //MainWindow.a_meisyou[5, 4, 5] = obj.Meisyou545;
                //MainWindow.a_meisyou[5, 4, 6] = obj.Meisyou546;
                //MainWindow.a_meisyou[5, 4, 7] = obj.Meisyou547;
                //MainWindow.a_meisyou[5, 4, 8] = obj.Meisyou548;
                //MainWindow.a_meisyou[5, 4, 9] = obj.Meisyou549;
                ////6-Stream6
                //MainWindow.a_meisyou[5, 5, 0] = obj.Meisyou550;
                //MainWindow.a_meisyou[5, 5, 1] = obj.Meisyou551;
                //MainWindow.a_meisyou[5, 5, 2] = obj.Meisyou552;
                //MainWindow.a_meisyou[5, 5, 3] = obj.Meisyou553;
                //MainWindow.a_meisyou[5, 5, 4] = obj.Meisyou554;
                //MainWindow.a_meisyou[5, 5, 5] = obj.Meisyou555;
                //MainWindow.a_meisyou[5, 5, 6] = obj.Meisyou556;
                //MainWindow.a_meisyou[5, 5, 7] = obj.Meisyou557;
                //MainWindow.a_meisyou[5, 5, 8] = obj.Meisyou558;
                //MainWindow.a_meisyou[5, 5, 9] = obj.Meisyou559;
                ////6-Stream7
                //MainWindow.a_meisyou[5, 6, 0] = obj.Meisyou560;
                //MainWindow.a_meisyou[5, 6, 1] = obj.Meisyou561;
                //MainWindow.a_meisyou[5, 6, 2] = obj.Meisyou562;
                //MainWindow.a_meisyou[5, 6, 3] = obj.Meisyou563;
                //MainWindow.a_meisyou[5, 6, 4] = obj.Meisyou564;
                //MainWindow.a_meisyou[5, 6, 5] = obj.Meisyou565;
                //MainWindow.a_meisyou[5, 6, 6] = obj.Meisyou566;
                //MainWindow.a_meisyou[5, 6, 7] = obj.Meisyou567;
                //MainWindow.a_meisyou[5, 6, 8] = obj.Meisyou568;
                //MainWindow.a_meisyou[5, 6, 9] = obj.Meisyou569;
                ////6-Stream8
                //MainWindow.a_meisyou[5, 7, 0] = obj.Meisyou570;
                //MainWindow.a_meisyou[5, 7, 1] = obj.Meisyou571;
                //MainWindow.a_meisyou[5, 7, 2] = obj.Meisyou572;
                //MainWindow.a_meisyou[5, 7, 3] = obj.Meisyou573;
                //MainWindow.a_meisyou[5, 7, 4] = obj.Meisyou574;
                //MainWindow.a_meisyou[5, 7, 5] = obj.Meisyou575;
                //MainWindow.a_meisyou[5, 7, 6] = obj.Meisyou576;
                //MainWindow.a_meisyou[5, 7, 7] = obj.Meisyou577;
                //MainWindow.a_meisyou[5, 7, 8] = obj.Meisyou578;
                //MainWindow.a_meisyou[5, 7, 9] = obj.Meisyou579;
                ////6-Stream9
                //MainWindow.a_meisyou[5, 8, 0] = obj.Meisyou580;
                //MainWindow.a_meisyou[5, 8, 1] = obj.Meisyou581;
                //MainWindow.a_meisyou[5, 8, 2] = obj.Meisyou582;
                //MainWindow.a_meisyou[5, 8, 3] = obj.Meisyou583;
                //MainWindow.a_meisyou[5, 8, 4] = obj.Meisyou584;
                //MainWindow.a_meisyou[5, 8, 5] = obj.Meisyou585;
                //MainWindow.a_meisyou[5, 8, 6] = obj.Meisyou586;
                //MainWindow.a_meisyou[5, 8, 7] = obj.Meisyou587;
                //MainWindow.a_meisyou[5, 8, 8] = obj.Meisyou588;
                //MainWindow.a_meisyou[5, 8, 9] = obj.Meisyou589;
                ////6-Stream10
                //MainWindow.a_meisyou[5, 9, 0] = obj.Meisyou590;
                //MainWindow.a_meisyou[5, 9, 1] = obj.Meisyou591;
                //MainWindow.a_meisyou[5, 9, 2] = obj.Meisyou592;
                //MainWindow.a_meisyou[5, 9, 3] = obj.Meisyou593;
                //MainWindow.a_meisyou[5, 9, 4] = obj.Meisyou594;
                //MainWindow.a_meisyou[5, 9, 5] = obj.Meisyou595;
                //MainWindow.a_meisyou[5, 9, 6] = obj.Meisyou596;
                //MainWindow.a_meisyou[5, 9, 7] = obj.Meisyou597;
                //MainWindow.a_meisyou[5, 9, 8] = obj.Meisyou598;
                //MainWindow.a_meisyou[5, 9, 9] = obj.Meisyou599;
                ////6-Stream11
                //MainWindow.a_meisyou[5, 10, 0] = obj.Meisyou5A0;
                //MainWindow.a_meisyou[5, 10, 1] = obj.Meisyou5A1;
                //MainWindow.a_meisyou[5, 10, 2] = obj.Meisyou5A2;
                //MainWindow.a_meisyou[5, 10, 3] = obj.Meisyou5A3;
                //MainWindow.a_meisyou[5, 10, 4] = obj.Meisyou5A4;
                //MainWindow.a_meisyou[5, 10, 5] = obj.Meisyou5A5;
                //MainWindow.a_meisyou[5, 10, 6] = obj.Meisyou5A6;
                //MainWindow.a_meisyou[5, 10, 7] = obj.Meisyou5A7;
                //MainWindow.a_meisyou[5, 10, 8] = obj.Meisyou5A8;
                //MainWindow.a_meisyou[5, 10, 9] = obj.Meisyou5A9;

                ////品種7
                ////7-Stream1
                //MainWindow.a_meisyou[6, 0, 0] = obj.Meisyou600;
                //MainWindow.a_meisyou[6, 0, 1] = obj.Meisyou601;
                //MainWindow.a_meisyou[6, 0, 2] = obj.Meisyou602;
                //MainWindow.a_meisyou[6, 0, 3] = obj.Meisyou603;
                //MainWindow.a_meisyou[6, 0, 4] = obj.Meisyou604;
                //MainWindow.a_meisyou[6, 0, 5] = obj.Meisyou605;
                //MainWindow.a_meisyou[6, 0, 6] = obj.Meisyou606;
                //MainWindow.a_meisyou[6, 0, 7] = obj.Meisyou607;
                //MainWindow.a_meisyou[6, 0, 8] = obj.Meisyou608;
                //MainWindow.a_meisyou[6, 0, 9] = obj.Meisyou609;
                ////7-Stream2
                //MainWindow.a_meisyou[6, 1, 0] = obj.Meisyou610;
                //MainWindow.a_meisyou[6, 1, 1] = obj.Meisyou611;
                //MainWindow.a_meisyou[6, 1, 2] = obj.Meisyou612;
                //MainWindow.a_meisyou[6, 1, 3] = obj.Meisyou613;
                //MainWindow.a_meisyou[6, 1, 4] = obj.Meisyou614;
                //MainWindow.a_meisyou[6, 1, 5] = obj.Meisyou615;
                //MainWindow.a_meisyou[6, 1, 6] = obj.Meisyou616;
                //MainWindow.a_meisyou[6, 1, 7] = obj.Meisyou617;
                //MainWindow.a_meisyou[6, 1, 8] = obj.Meisyou618;
                //MainWindow.a_meisyou[6, 1, 9] = obj.Meisyou619;
                ////7-Stream3
                //MainWindow.a_meisyou[6, 2, 0] = obj.Meisyou620;
                //MainWindow.a_meisyou[6, 2, 1] = obj.Meisyou621;
                //MainWindow.a_meisyou[6, 2, 2] = obj.Meisyou622;
                //MainWindow.a_meisyou[6, 2, 3] = obj.Meisyou623;
                //MainWindow.a_meisyou[6, 2, 4] = obj.Meisyou624;
                //MainWindow.a_meisyou[6, 2, 5] = obj.Meisyou625;
                //MainWindow.a_meisyou[6, 2, 6] = obj.Meisyou626;
                //MainWindow.a_meisyou[6, 2, 7] = obj.Meisyou627;
                //MainWindow.a_meisyou[6, 2, 8] = obj.Meisyou628;
                //MainWindow.a_meisyou[6, 2, 9] = obj.Meisyou629;
                ////7-Stream4
                //MainWindow.a_meisyou[6, 3, 0] = obj.Meisyou630;
                //MainWindow.a_meisyou[6, 3, 1] = obj.Meisyou631;
                //MainWindow.a_meisyou[6, 3, 2] = obj.Meisyou632;
                //MainWindow.a_meisyou[6, 3, 3] = obj.Meisyou633;
                //MainWindow.a_meisyou[6, 3, 4] = obj.Meisyou634;
                //MainWindow.a_meisyou[6, 3, 5] = obj.Meisyou635;
                //MainWindow.a_meisyou[6, 3, 6] = obj.Meisyou636;
                //MainWindow.a_meisyou[6, 3, 7] = obj.Meisyou637;
                //MainWindow.a_meisyou[6, 3, 8] = obj.Meisyou638;
                //MainWindow.a_meisyou[6, 3, 9] = obj.Meisyou639;
                ////7-Stream5
                //MainWindow.a_meisyou[6, 4, 0] = obj.Meisyou640;
                //MainWindow.a_meisyou[6, 4, 1] = obj.Meisyou641;
                //MainWindow.a_meisyou[6, 4, 2] = obj.Meisyou642;
                //MainWindow.a_meisyou[6, 4, 3] = obj.Meisyou643;
                //MainWindow.a_meisyou[6, 4, 4] = obj.Meisyou644;
                //MainWindow.a_meisyou[6, 4, 5] = obj.Meisyou645;
                //MainWindow.a_meisyou[6, 4, 6] = obj.Meisyou646;
                //MainWindow.a_meisyou[6, 4, 7] = obj.Meisyou647;
                //MainWindow.a_meisyou[6, 4, 8] = obj.Meisyou648;
                //MainWindow.a_meisyou[6, 4, 9] = obj.Meisyou649;
                ////7-Stream6
                //MainWindow.a_meisyou[6, 5, 0] = obj.Meisyou650;
                //MainWindow.a_meisyou[6, 5, 1] = obj.Meisyou651;
                //MainWindow.a_meisyou[6, 5, 2] = obj.Meisyou652;
                //MainWindow.a_meisyou[6, 5, 3] = obj.Meisyou653;
                //MainWindow.a_meisyou[6, 5, 4] = obj.Meisyou654;
                //MainWindow.a_meisyou[6, 5, 5] = obj.Meisyou655;
                //MainWindow.a_meisyou[6, 5, 6] = obj.Meisyou656;
                //MainWindow.a_meisyou[6, 5, 7] = obj.Meisyou657;
                //MainWindow.a_meisyou[6, 5, 8] = obj.Meisyou658;
                //MainWindow.a_meisyou[6, 5, 9] = obj.Meisyou659;
                ////7-Stream7
                //MainWindow.a_meisyou[6, 6, 0] = obj.Meisyou660;
                //MainWindow.a_meisyou[6, 6, 1] = obj.Meisyou661;
                //MainWindow.a_meisyou[6, 6, 2] = obj.Meisyou662;
                //MainWindow.a_meisyou[6, 6, 3] = obj.Meisyou663;
                //MainWindow.a_meisyou[6, 6, 4] = obj.Meisyou664;
                //MainWindow.a_meisyou[6, 6, 5] = obj.Meisyou665;
                //MainWindow.a_meisyou[6, 6, 6] = obj.Meisyou666;
                //MainWindow.a_meisyou[6, 6, 7] = obj.Meisyou667;
                //MainWindow.a_meisyou[6, 6, 8] = obj.Meisyou668;
                //MainWindow.a_meisyou[6, 6, 9] = obj.Meisyou669;
                ////7-Stream8
                //MainWindow.a_meisyou[6, 7, 0] = obj.Meisyou670;
                //MainWindow.a_meisyou[6, 7, 1] = obj.Meisyou671;
                //MainWindow.a_meisyou[6, 7, 2] = obj.Meisyou672;
                //MainWindow.a_meisyou[6, 7, 3] = obj.Meisyou673;
                //MainWindow.a_meisyou[6, 7, 4] = obj.Meisyou674;
                //MainWindow.a_meisyou[6, 7, 5] = obj.Meisyou675;
                //MainWindow.a_meisyou[6, 7, 6] = obj.Meisyou676;
                //MainWindow.a_meisyou[6, 7, 7] = obj.Meisyou677;
                //MainWindow.a_meisyou[6, 7, 8] = obj.Meisyou678;
                //MainWindow.a_meisyou[6, 7, 9] = obj.Meisyou679;
                ////7-Stream9
                //MainWindow.a_meisyou[6, 8, 0] = obj.Meisyou680;
                //MainWindow.a_meisyou[6, 8, 1] = obj.Meisyou681;
                //MainWindow.a_meisyou[6, 8, 2] = obj.Meisyou682;
                //MainWindow.a_meisyou[6, 8, 3] = obj.Meisyou683;
                //MainWindow.a_meisyou[6, 8, 4] = obj.Meisyou684;
                //MainWindow.a_meisyou[6, 8, 5] = obj.Meisyou685;
                //MainWindow.a_meisyou[6, 8, 6] = obj.Meisyou686;
                //MainWindow.a_meisyou[6, 8, 7] = obj.Meisyou687;
                //MainWindow.a_meisyou[6, 8, 8] = obj.Meisyou688;
                //MainWindow.a_meisyou[6, 8, 9] = obj.Meisyou689;
                ////7-Stream10
                //MainWindow.a_meisyou[6, 9, 0] = obj.Meisyou690;
                //MainWindow.a_meisyou[6, 9, 1] = obj.Meisyou691;
                //MainWindow.a_meisyou[6, 9, 2] = obj.Meisyou692;
                //MainWindow.a_meisyou[6, 9, 3] = obj.Meisyou693;
                //MainWindow.a_meisyou[6, 9, 4] = obj.Meisyou694;
                //MainWindow.a_meisyou[6, 9, 5] = obj.Meisyou695;
                //MainWindow.a_meisyou[6, 9, 6] = obj.Meisyou696;
                //MainWindow.a_meisyou[6, 9, 7] = obj.Meisyou697;
                //MainWindow.a_meisyou[6, 9, 8] = obj.Meisyou698;
                //MainWindow.a_meisyou[6, 9, 9] = obj.Meisyou699;
                ////7-Stream11
                //MainWindow.a_meisyou[6, 10, 0] = obj.Meisyou6A0;
                //MainWindow.a_meisyou[6, 10, 1] = obj.Meisyou6A1;
                //MainWindow.a_meisyou[6, 10, 2] = obj.Meisyou6A2;
                //MainWindow.a_meisyou[6, 10, 3] = obj.Meisyou6A3;
                //MainWindow.a_meisyou[6, 10, 4] = obj.Meisyou6A4;
                //MainWindow.a_meisyou[6, 10, 5] = obj.Meisyou6A5;
                //MainWindow.a_meisyou[6, 10, 6] = obj.Meisyou6A6;
                //MainWindow.a_meisyou[6, 10, 7] = obj.Meisyou6A7;
                //MainWindow.a_meisyou[6, 10, 8] = obj.Meisyou6A8;
                //MainWindow.a_meisyou[6, 10, 9] = obj.Meisyou6A9;

                ////品種8
                ////8-Stream1
                //MainWindow.a_meisyou[7, 0, 0] = obj.Meisyou700;
                //MainWindow.a_meisyou[7, 0, 1] = obj.Meisyou701;
                //MainWindow.a_meisyou[7, 0, 2] = obj.Meisyou702;
                //MainWindow.a_meisyou[7, 0, 3] = obj.Meisyou703;
                //MainWindow.a_meisyou[7, 0, 4] = obj.Meisyou704;
                //MainWindow.a_meisyou[7, 0, 5] = obj.Meisyou705;
                //MainWindow.a_meisyou[7, 0, 6] = obj.Meisyou706;
                //MainWindow.a_meisyou[7, 0, 7] = obj.Meisyou707;
                //MainWindow.a_meisyou[7, 0, 8] = obj.Meisyou708;
                //MainWindow.a_meisyou[7, 0, 9] = obj.Meisyou709;
                ////8-Stream2
                //MainWindow.a_meisyou[7, 1, 0] = obj.Meisyou710;
                //MainWindow.a_meisyou[7, 1, 1] = obj.Meisyou711;
                //MainWindow.a_meisyou[7, 1, 2] = obj.Meisyou712;
                //MainWindow.a_meisyou[7, 1, 3] = obj.Meisyou713;
                //MainWindow.a_meisyou[7, 1, 4] = obj.Meisyou714;
                //MainWindow.a_meisyou[7, 1, 5] = obj.Meisyou715;
                //MainWindow.a_meisyou[7, 1, 6] = obj.Meisyou716;
                //MainWindow.a_meisyou[7, 1, 7] = obj.Meisyou717;
                //MainWindow.a_meisyou[7, 1, 8] = obj.Meisyou718;
                //MainWindow.a_meisyou[7, 1, 9] = obj.Meisyou719;
                ////8-Stream3
                //MainWindow.a_meisyou[7, 2, 0] = obj.Meisyou720;
                //MainWindow.a_meisyou[7, 2, 1] = obj.Meisyou721;
                //MainWindow.a_meisyou[7, 2, 2] = obj.Meisyou722;
                //MainWindow.a_meisyou[7, 2, 3] = obj.Meisyou723;
                //MainWindow.a_meisyou[7, 2, 4] = obj.Meisyou724;
                //MainWindow.a_meisyou[7, 2, 5] = obj.Meisyou725;
                //MainWindow.a_meisyou[7, 2, 6] = obj.Meisyou726;
                //MainWindow.a_meisyou[7, 2, 7] = obj.Meisyou727;
                //MainWindow.a_meisyou[7, 2, 8] = obj.Meisyou728;
                //MainWindow.a_meisyou[7, 2, 9] = obj.Meisyou729;
                ////8-Stream4
                //MainWindow.a_meisyou[7, 3, 0] = obj.Meisyou730;
                //MainWindow.a_meisyou[7, 3, 1] = obj.Meisyou731;
                //MainWindow.a_meisyou[7, 3, 2] = obj.Meisyou732;
                //MainWindow.a_meisyou[7, 3, 3] = obj.Meisyou733;
                //MainWindow.a_meisyou[7, 3, 4] = obj.Meisyou734;
                //MainWindow.a_meisyou[7, 3, 5] = obj.Meisyou735;
                //MainWindow.a_meisyou[7, 3, 6] = obj.Meisyou736;
                //MainWindow.a_meisyou[7, 3, 7] = obj.Meisyou737;
                //MainWindow.a_meisyou[7, 3, 8] = obj.Meisyou738;
                //MainWindow.a_meisyou[7, 3, 9] = obj.Meisyou739;
                ////8-Stream5
                //MainWindow.a_meisyou[7, 4, 0] = obj.Meisyou740;
                //MainWindow.a_meisyou[7, 4, 1] = obj.Meisyou741;
                //MainWindow.a_meisyou[7, 4, 2] = obj.Meisyou742;
                //MainWindow.a_meisyou[7, 4, 3] = obj.Meisyou743;
                //MainWindow.a_meisyou[7, 4, 4] = obj.Meisyou744;
                //MainWindow.a_meisyou[7, 4, 5] = obj.Meisyou745;
                //MainWindow.a_meisyou[7, 4, 6] = obj.Meisyou746;
                //MainWindow.a_meisyou[7, 4, 7] = obj.Meisyou747;
                //MainWindow.a_meisyou[7, 4, 8] = obj.Meisyou748;
                //MainWindow.a_meisyou[7, 4, 9] = obj.Meisyou749;
                ////8-Stream6
                //MainWindow.a_meisyou[7, 5, 0] = obj.Meisyou750;
                //MainWindow.a_meisyou[7, 5, 1] = obj.Meisyou751;
                //MainWindow.a_meisyou[7, 5, 2] = obj.Meisyou752;
                //MainWindow.a_meisyou[7, 5, 3] = obj.Meisyou753;
                //MainWindow.a_meisyou[7, 5, 4] = obj.Meisyou754;
                //MainWindow.a_meisyou[7, 5, 5] = obj.Meisyou755;
                //MainWindow.a_meisyou[7, 5, 6] = obj.Meisyou756;
                //MainWindow.a_meisyou[7, 5, 7] = obj.Meisyou757;
                //MainWindow.a_meisyou[7, 5, 8] = obj.Meisyou758;
                //MainWindow.a_meisyou[7, 5, 9] = obj.Meisyou759;
                ////8-Stream7
                //MainWindow.a_meisyou[7, 6, 0] = obj.Meisyou760;
                //MainWindow.a_meisyou[7, 6, 1] = obj.Meisyou761;
                //MainWindow.a_meisyou[7, 6, 2] = obj.Meisyou762;
                //MainWindow.a_meisyou[7, 6, 3] = obj.Meisyou763;
                //MainWindow.a_meisyou[7, 6, 4] = obj.Meisyou764;
                //MainWindow.a_meisyou[7, 6, 5] = obj.Meisyou765;
                //MainWindow.a_meisyou[7, 6, 6] = obj.Meisyou766;
                //MainWindow.a_meisyou[7, 6, 7] = obj.Meisyou767;
                //MainWindow.a_meisyou[7, 6, 8] = obj.Meisyou768;
                //MainWindow.a_meisyou[7, 6, 9] = obj.Meisyou769;
                ////8-Stream8
                //MainWindow.a_meisyou[7, 7, 0] = obj.Meisyou770;
                //MainWindow.a_meisyou[7, 7, 1] = obj.Meisyou771;
                //MainWindow.a_meisyou[7, 7, 2] = obj.Meisyou772;
                //MainWindow.a_meisyou[7, 7, 3] = obj.Meisyou773;
                //MainWindow.a_meisyou[7, 7, 4] = obj.Meisyou774;
                //MainWindow.a_meisyou[7, 7, 5] = obj.Meisyou775;
                //MainWindow.a_meisyou[7, 7, 6] = obj.Meisyou776;
                //MainWindow.a_meisyou[7, 7, 7] = obj.Meisyou777;
                //MainWindow.a_meisyou[7, 7, 8] = obj.Meisyou778;
                //MainWindow.a_meisyou[7, 7, 9] = obj.Meisyou779;
                ////8-Stream9
                //MainWindow.a_meisyou[7, 8, 0] = obj.Meisyou780;
                //MainWindow.a_meisyou[7, 8, 1] = obj.Meisyou781;
                //MainWindow.a_meisyou[7, 8, 2] = obj.Meisyou782;
                //MainWindow.a_meisyou[7, 8, 3] = obj.Meisyou783;
                //MainWindow.a_meisyou[7, 8, 4] = obj.Meisyou784;
                //MainWindow.a_meisyou[7, 8, 5] = obj.Meisyou785;
                //MainWindow.a_meisyou[7, 8, 6] = obj.Meisyou786;
                //MainWindow.a_meisyou[7, 8, 7] = obj.Meisyou787;
                //MainWindow.a_meisyou[7, 8, 8] = obj.Meisyou788;
                //MainWindow.a_meisyou[7, 8, 9] = obj.Meisyou789;
                ////8-Stream10
                //MainWindow.a_meisyou[7, 9, 0] = obj.Meisyou790;
                //MainWindow.a_meisyou[7, 9, 1] = obj.Meisyou791;
                //MainWindow.a_meisyou[7, 9, 2] = obj.Meisyou792;
                //MainWindow.a_meisyou[7, 9, 3] = obj.Meisyou793;
                //MainWindow.a_meisyou[7, 9, 4] = obj.Meisyou794;
                //MainWindow.a_meisyou[7, 9, 5] = obj.Meisyou795;
                //MainWindow.a_meisyou[7, 9, 6] = obj.Meisyou796;
                //MainWindow.a_meisyou[7, 9, 7] = obj.Meisyou797;
                //MainWindow.a_meisyou[7, 9, 8] = obj.Meisyou798;
                //MainWindow.a_meisyou[7, 9, 9] = obj.Meisyou799;
                ////8-Stream11
                //MainWindow.a_meisyou[7, 10, 0] = obj.Meisyou7A0;
                //MainWindow.a_meisyou[7, 10, 1] = obj.Meisyou7A1;
                //MainWindow.a_meisyou[7, 10, 2] = obj.Meisyou7A2;
                //MainWindow.a_meisyou[7, 10, 3] = obj.Meisyou7A3;
                //MainWindow.a_meisyou[7, 10, 4] = obj.Meisyou7A4;
                //MainWindow.a_meisyou[7, 10, 5] = obj.Meisyou7A5;
                //MainWindow.a_meisyou[7, 10, 6] = obj.Meisyou7A6;
                //MainWindow.a_meisyou[7, 10, 7] = obj.Meisyou7A7;
                //MainWindow.a_meisyou[7, 10, 8] = obj.Meisyou7A8;
                //MainWindow.a_meisyou[7, 10, 9] = obj.Meisyou7A9;

                ////品種9
                ////9-Stream1
                //MainWindow.a_meisyou[8, 0, 0] = obj.Meisyou800;
                //MainWindow.a_meisyou[8, 0, 1] = obj.Meisyou801;
                //MainWindow.a_meisyou[8, 0, 2] = obj.Meisyou802;
                //MainWindow.a_meisyou[8, 0, 3] = obj.Meisyou803;
                //MainWindow.a_meisyou[8, 0, 4] = obj.Meisyou804;
                //MainWindow.a_meisyou[8, 0, 5] = obj.Meisyou805;
                //MainWindow.a_meisyou[8, 0, 6] = obj.Meisyou806;
                //MainWindow.a_meisyou[8, 0, 7] = obj.Meisyou807;
                //MainWindow.a_meisyou[8, 0, 8] = obj.Meisyou808;
                //MainWindow.a_meisyou[8, 0, 9] = obj.Meisyou809;
                ////9-Stream2
                //MainWindow.a_meisyou[8, 1, 0] = obj.Meisyou810;
                //MainWindow.a_meisyou[8, 1, 1] = obj.Meisyou811;
                //MainWindow.a_meisyou[8, 1, 2] = obj.Meisyou812;
                //MainWindow.a_meisyou[8, 1, 3] = obj.Meisyou813;
                //MainWindow.a_meisyou[8, 1, 4] = obj.Meisyou814;
                //MainWindow.a_meisyou[8, 1, 5] = obj.Meisyou815;
                //MainWindow.a_meisyou[8, 1, 6] = obj.Meisyou816;
                //MainWindow.a_meisyou[8, 1, 7] = obj.Meisyou817;
                //MainWindow.a_meisyou[8, 1, 8] = obj.Meisyou818;
                //MainWindow.a_meisyou[8, 1, 9] = obj.Meisyou819;
                ////9-Stream3
                //MainWindow.a_meisyou[8, 2, 0] = obj.Meisyou820;
                //MainWindow.a_meisyou[8, 2, 1] = obj.Meisyou821;
                //MainWindow.a_meisyou[8, 2, 2] = obj.Meisyou822;
                //MainWindow.a_meisyou[8, 2, 3] = obj.Meisyou823;
                //MainWindow.a_meisyou[8, 2, 4] = obj.Meisyou824;
                //MainWindow.a_meisyou[8, 2, 5] = obj.Meisyou825;
                //MainWindow.a_meisyou[8, 2, 6] = obj.Meisyou826;
                //MainWindow.a_meisyou[8, 2, 7] = obj.Meisyou827;
                //MainWindow.a_meisyou[8, 2, 8] = obj.Meisyou828;
                //MainWindow.a_meisyou[8, 2, 9] = obj.Meisyou829;
                ////9-Stream4
                //MainWindow.a_meisyou[8, 3, 0] = obj.Meisyou830;
                //MainWindow.a_meisyou[8, 3, 1] = obj.Meisyou831;
                //MainWindow.a_meisyou[8, 3, 2] = obj.Meisyou832;
                //MainWindow.a_meisyou[8, 3, 3] = obj.Meisyou833;
                //MainWindow.a_meisyou[8, 3, 4] = obj.Meisyou834;
                //MainWindow.a_meisyou[8, 3, 5] = obj.Meisyou835;
                //MainWindow.a_meisyou[8, 3, 6] = obj.Meisyou836;
                //MainWindow.a_meisyou[8, 3, 7] = obj.Meisyou837;
                //MainWindow.a_meisyou[8, 3, 8] = obj.Meisyou838;
                //MainWindow.a_meisyou[8, 3, 9] = obj.Meisyou839;
                ////9-Stream5
                //MainWindow.a_meisyou[8, 4, 0] = obj.Meisyou840;
                //MainWindow.a_meisyou[8, 4, 1] = obj.Meisyou841;
                //MainWindow.a_meisyou[8, 4, 2] = obj.Meisyou842;
                //MainWindow.a_meisyou[8, 4, 3] = obj.Meisyou843;
                //MainWindow.a_meisyou[8, 4, 4] = obj.Meisyou844;
                //MainWindow.a_meisyou[8, 4, 5] = obj.Meisyou845;
                //MainWindow.a_meisyou[8, 4, 6] = obj.Meisyou846;
                //MainWindow.a_meisyou[8, 4, 7] = obj.Meisyou847;
                //MainWindow.a_meisyou[8, 4, 8] = obj.Meisyou848;
                //MainWindow.a_meisyou[8, 4, 9] = obj.Meisyou849;
                ////9-Stream6
                //MainWindow.a_meisyou[8, 5, 0] = obj.Meisyou850;
                //MainWindow.a_meisyou[8, 5, 1] = obj.Meisyou851;
                //MainWindow.a_meisyou[8, 5, 2] = obj.Meisyou852;
                //MainWindow.a_meisyou[8, 5, 3] = obj.Meisyou853;
                //MainWindow.a_meisyou[8, 5, 4] = obj.Meisyou854;
                //MainWindow.a_meisyou[8, 5, 5] = obj.Meisyou855;
                //MainWindow.a_meisyou[8, 5, 6] = obj.Meisyou856;
                //MainWindow.a_meisyou[8, 5, 7] = obj.Meisyou857;
                //MainWindow.a_meisyou[8, 5, 8] = obj.Meisyou858;
                //MainWindow.a_meisyou[8, 5, 9] = obj.Meisyou859;
                ////9-Stream7
                //MainWindow.a_meisyou[8, 6, 0] = obj.Meisyou860;
                //MainWindow.a_meisyou[8, 6, 1] = obj.Meisyou861;
                //MainWindow.a_meisyou[8, 6, 2] = obj.Meisyou862;
                //MainWindow.a_meisyou[8, 6, 3] = obj.Meisyou863;
                //MainWindow.a_meisyou[8, 6, 4] = obj.Meisyou864;
                //MainWindow.a_meisyou[8, 6, 5] = obj.Meisyou865;
                //MainWindow.a_meisyou[8, 6, 6] = obj.Meisyou866;
                //MainWindow.a_meisyou[8, 6, 7] = obj.Meisyou867;
                //MainWindow.a_meisyou[8, 6, 8] = obj.Meisyou868;
                //MainWindow.a_meisyou[8, 6, 9] = obj.Meisyou869;
                ////9-Stream8
                //MainWindow.a_meisyou[8, 7, 0] = obj.Meisyou870;
                //MainWindow.a_meisyou[8, 7, 1] = obj.Meisyou871;
                //MainWindow.a_meisyou[8, 7, 2] = obj.Meisyou872;
                //MainWindow.a_meisyou[8, 7, 3] = obj.Meisyou873;
                //MainWindow.a_meisyou[8, 7, 4] = obj.Meisyou874;
                //MainWindow.a_meisyou[8, 7, 5] = obj.Meisyou875;
                //MainWindow.a_meisyou[8, 7, 6] = obj.Meisyou876;
                //MainWindow.a_meisyou[8, 7, 7] = obj.Meisyou877;
                //MainWindow.a_meisyou[8, 7, 8] = obj.Meisyou878;
                //MainWindow.a_meisyou[8, 7, 9] = obj.Meisyou879;
                ////9-Stream9
                //MainWindow.a_meisyou[8, 8, 0] = obj.Meisyou880;
                //MainWindow.a_meisyou[8, 8, 1] = obj.Meisyou881;
                //MainWindow.a_meisyou[8, 8, 2] = obj.Meisyou882;
                //MainWindow.a_meisyou[8, 8, 3] = obj.Meisyou883;
                //MainWindow.a_meisyou[8, 8, 4] = obj.Meisyou884;
                //MainWindow.a_meisyou[8, 8, 5] = obj.Meisyou885;
                //MainWindow.a_meisyou[8, 8, 6] = obj.Meisyou886;
                //MainWindow.a_meisyou[8, 8, 7] = obj.Meisyou887;
                //MainWindow.a_meisyou[8, 8, 8] = obj.Meisyou888;
                //MainWindow.a_meisyou[8, 8, 9] = obj.Meisyou889;
                ////9-Stream10
                //MainWindow.a_meisyou[8, 9, 0] = obj.Meisyou890;
                //MainWindow.a_meisyou[8, 9, 1] = obj.Meisyou891;
                //MainWindow.a_meisyou[8, 9, 2] = obj.Meisyou892;
                //MainWindow.a_meisyou[8, 9, 3] = obj.Meisyou893;
                //MainWindow.a_meisyou[8, 9, 4] = obj.Meisyou894;
                //MainWindow.a_meisyou[8, 9, 5] = obj.Meisyou895;
                //MainWindow.a_meisyou[8, 9, 6] = obj.Meisyou896;
                //MainWindow.a_meisyou[8, 9, 7] = obj.Meisyou897;
                //MainWindow.a_meisyou[8, 9, 8] = obj.Meisyou898;
                //MainWindow.a_meisyou[8, 9, 9] = obj.Meisyou899;
                ////9-Stream11
                //MainWindow.a_meisyou[8, 10, 0] = obj.Meisyou8A0;
                //MainWindow.a_meisyou[8, 10, 1] = obj.Meisyou8A1;
                //MainWindow.a_meisyou[8, 10, 2] = obj.Meisyou8A2;
                //MainWindow.a_meisyou[8, 10, 3] = obj.Meisyou8A3;
                //MainWindow.a_meisyou[8, 10, 4] = obj.Meisyou8A4;
                //MainWindow.a_meisyou[8, 10, 5] = obj.Meisyou8A5;
                //MainWindow.a_meisyou[8, 10, 6] = obj.Meisyou8A6;
                //MainWindow.a_meisyou[8, 10, 7] = obj.Meisyou8A7;
                //MainWindow.a_meisyou[8, 10, 8] = obj.Meisyou8A8;

                ////品種10
                ////10-Stream1
                //MainWindow.a_meisyou[9, 0, 0] = obj.Meisyou900;
                //MainWindow.a_meisyou[9, 0, 1] = obj.Meisyou901;
                //MainWindow.a_meisyou[9, 0, 2] = obj.Meisyou902;
                //MainWindow.a_meisyou[9, 0, 3] = obj.Meisyou903;
                //MainWindow.a_meisyou[9, 0, 4] = obj.Meisyou904;
                //MainWindow.a_meisyou[9, 0, 5] = obj.Meisyou905;
                //MainWindow.a_meisyou[9, 0, 6] = obj.Meisyou906;
                //MainWindow.a_meisyou[9, 0, 7] = obj.Meisyou907;
                //MainWindow.a_meisyou[9, 0, 8] = obj.Meisyou908;
                //MainWindow.a_meisyou[9, 0, 9] = obj.Meisyou909;
                ////10-Stream2
                //MainWindow.a_meisyou[9, 1, 0] = obj.Meisyou910;
                //MainWindow.a_meisyou[9, 1, 1] = obj.Meisyou911;
                //MainWindow.a_meisyou[9, 1, 2] = obj.Meisyou912;
                //MainWindow.a_meisyou[9, 1, 3] = obj.Meisyou913;
                //MainWindow.a_meisyou[9, 1, 4] = obj.Meisyou914;
                //MainWindow.a_meisyou[9, 1, 5] = obj.Meisyou915;
                //MainWindow.a_meisyou[9, 1, 6] = obj.Meisyou916;
                //MainWindow.a_meisyou[9, 1, 7] = obj.Meisyou917;
                //MainWindow.a_meisyou[9, 1, 8] = obj.Meisyou918;
                //MainWindow.a_meisyou[9, 1, 9] = obj.Meisyou919;
                ////10-Stream3
                //MainWindow.a_meisyou[9, 2, 0] = obj.Meisyou920;
                //MainWindow.a_meisyou[9, 2, 1] = obj.Meisyou921;
                //MainWindow.a_meisyou[9, 2, 2] = obj.Meisyou922;
                //MainWindow.a_meisyou[9, 2, 3] = obj.Meisyou923;
                //MainWindow.a_meisyou[9, 2, 4] = obj.Meisyou924;
                //MainWindow.a_meisyou[9, 2, 5] = obj.Meisyou925;
                //MainWindow.a_meisyou[9, 2, 6] = obj.Meisyou926;
                //MainWindow.a_meisyou[9, 2, 7] = obj.Meisyou927;
                //MainWindow.a_meisyou[9, 2, 8] = obj.Meisyou928;
                //MainWindow.a_meisyou[9, 2, 9] = obj.Meisyou929;
                ////10-Stream4
                //MainWindow.a_meisyou[9, 3, 0] = obj.Meisyou930;
                //MainWindow.a_meisyou[9, 3, 1] = obj.Meisyou931;
                //MainWindow.a_meisyou[9, 3, 2] = obj.Meisyou932;
                //MainWindow.a_meisyou[9, 3, 3] = obj.Meisyou933;
                //MainWindow.a_meisyou[9, 3, 4] = obj.Meisyou934;
                //MainWindow.a_meisyou[9, 3, 5] = obj.Meisyou935;
                //MainWindow.a_meisyou[9, 3, 6] = obj.Meisyou936;
                //MainWindow.a_meisyou[9, 3, 7] = obj.Meisyou937;
                //MainWindow.a_meisyou[9, 3, 8] = obj.Meisyou938;
                //MainWindow.a_meisyou[9, 3, 9] = obj.Meisyou939;
                ////10-Stream5
                //MainWindow.a_meisyou[9, 4, 0] = obj.Meisyou940;
                //MainWindow.a_meisyou[9, 4, 1] = obj.Meisyou941;
                //MainWindow.a_meisyou[9, 4, 2] = obj.Meisyou942;
                //MainWindow.a_meisyou[9, 4, 3] = obj.Meisyou943;
                //MainWindow.a_meisyou[9, 4, 4] = obj.Meisyou944;
                //MainWindow.a_meisyou[9, 4, 5] = obj.Meisyou945;
                //MainWindow.a_meisyou[9, 4, 6] = obj.Meisyou946;
                //MainWindow.a_meisyou[9, 4, 7] = obj.Meisyou947;
                //MainWindow.a_meisyou[9, 4, 8] = obj.Meisyou948;
                //MainWindow.a_meisyou[9, 4, 9] = obj.Meisyou949;
                ////10-Stream6
                //MainWindow.a_meisyou[9, 5, 0] = obj.Meisyou950;
                //MainWindow.a_meisyou[9, 5, 1] = obj.Meisyou951;
                //MainWindow.a_meisyou[9, 5, 2] = obj.Meisyou952;
                //MainWindow.a_meisyou[9, 5, 3] = obj.Meisyou953;
                //MainWindow.a_meisyou[9, 5, 4] = obj.Meisyou954;
                //MainWindow.a_meisyou[9, 5, 5] = obj.Meisyou955;
                //MainWindow.a_meisyou[9, 5, 6] = obj.Meisyou956;
                //MainWindow.a_meisyou[9, 5, 7] = obj.Meisyou957;
                //MainWindow.a_meisyou[9, 5, 8] = obj.Meisyou958;
                //MainWindow.a_meisyou[9, 5, 9] = obj.Meisyou959;
                ////10-Stream7
                //MainWindow.a_meisyou[9, 6, 0] = obj.Meisyou960;
                //MainWindow.a_meisyou[9, 6, 1] = obj.Meisyou961;
                //MainWindow.a_meisyou[9, 6, 2] = obj.Meisyou962;
                //MainWindow.a_meisyou[9, 6, 3] = obj.Meisyou963;
                //MainWindow.a_meisyou[9, 6, 4] = obj.Meisyou964;
                //MainWindow.a_meisyou[9, 6, 5] = obj.Meisyou965;
                //MainWindow.a_meisyou[9, 6, 6] = obj.Meisyou966;
                //MainWindow.a_meisyou[9, 6, 7] = obj.Meisyou967;
                //MainWindow.a_meisyou[9, 6, 8] = obj.Meisyou968;
                //MainWindow.a_meisyou[9, 6, 9] = obj.Meisyou969;
                ////10-Stream8
                //MainWindow.a_meisyou[9, 7, 0] = obj.Meisyou970;
                //MainWindow.a_meisyou[9, 7, 1] = obj.Meisyou971;
                //MainWindow.a_meisyou[9, 7, 2] = obj.Meisyou972;
                //MainWindow.a_meisyou[9, 7, 3] = obj.Meisyou973;
                //MainWindow.a_meisyou[9, 7, 4] = obj.Meisyou974;
                //MainWindow.a_meisyou[9, 7, 5] = obj.Meisyou975;
                //MainWindow.a_meisyou[9, 7, 6] = obj.Meisyou976;
                //MainWindow.a_meisyou[9, 7, 7] = obj.Meisyou977;
                //MainWindow.a_meisyou[9, 7, 8] = obj.Meisyou978;
                //MainWindow.a_meisyou[9, 7, 9] = obj.Meisyou979;
                ////10-Stream9
                //MainWindow.a_meisyou[9, 8, 0] = obj.Meisyou980;
                //MainWindow.a_meisyou[9, 8, 1] = obj.Meisyou981;
                //MainWindow.a_meisyou[9, 8, 2] = obj.Meisyou982;
                //MainWindow.a_meisyou[9, 8, 3] = obj.Meisyou983;
                //MainWindow.a_meisyou[9, 8, 4] = obj.Meisyou984;
                //MainWindow.a_meisyou[9, 8, 5] = obj.Meisyou985;
                //MainWindow.a_meisyou[9, 8, 6] = obj.Meisyou986;
                //MainWindow.a_meisyou[9, 8, 7] = obj.Meisyou987;
                //MainWindow.a_meisyou[9, 8, 8] = obj.Meisyou988;
                //MainWindow.a_meisyou[9, 8, 9] = obj.Meisyou989;
                ////10-Stream10
                //MainWindow.a_meisyou[9, 9, 0] = obj.Meisyou990;
                //MainWindow.a_meisyou[9, 9, 1] = obj.Meisyou991;
                //MainWindow.a_meisyou[9, 9, 2] = obj.Meisyou992;
                //MainWindow.a_meisyou[9, 9, 3] = obj.Meisyou993;
                //MainWindow.a_meisyou[9, 9, 4] = obj.Meisyou994;
                //MainWindow.a_meisyou[9, 9, 5] = obj.Meisyou995;
                //MainWindow.a_meisyou[9, 9, 6] = obj.Meisyou996;
                //MainWindow.a_meisyou[9, 9, 7] = obj.Meisyou997;
                //MainWindow.a_meisyou[9, 9, 8] = obj.Meisyou998;
                //MainWindow.a_meisyou[9, 9, 9] = obj.Meisyou999;
                ////10-Stream11
                //MainWindow.a_meisyou[9, 10, 0] = obj.Meisyou9A0;
                //MainWindow.a_meisyou[9, 10, 1] = obj.Meisyou9A1;
                //MainWindow.a_meisyou[9, 10, 2] = obj.Meisyou9A2;
                //MainWindow.a_meisyou[9, 10, 3] = obj.Meisyou9A3;
                //MainWindow.a_meisyou[9, 10, 4] = obj.Meisyou9A4;
                //MainWindow.a_meisyou[9, 10, 5] = obj.Meisyou9A5;
                //MainWindow.a_meisyou[9, 10, 6] = obj.Meisyou9A6;
                //MainWindow.a_meisyou[9, 10, 7] = obj.Meisyou9A7;
                //MainWindow.a_meisyou[9, 10, 8] = obj.Meisyou9A8;
                //MainWindow.a_meisyou[9, 10, 9] = obj.Meisyou9A9;

                ////ADD_END :2021/11/14 kitayama 理由：検査名称を格納する処理を追加

                ////ADD_START :2021/11/27 kitayama 理由：Streamの名称を格納する処理を追加
                ////品種1
                //MainWindow.s_meisyou[0, 0] = obj.S_meisyou00;
                //MainWindow.s_meisyou[0, 1] = obj.S_meisyou01;
                //MainWindow.s_meisyou[0, 2] = obj.S_meisyou02;
                //MainWindow.s_meisyou[0, 3] = obj.S_meisyou03;
                //MainWindow.s_meisyou[0, 4] = obj.S_meisyou04;
                //MainWindow.s_meisyou[0, 5] = obj.S_meisyou05;
                //MainWindow.s_meisyou[0, 6] = obj.S_meisyou06;
                //MainWindow.s_meisyou[0, 7] = obj.S_meisyou07;
                //MainWindow.s_meisyou[0, 8] = obj.S_meisyou08;
                //MainWindow.s_meisyou[0, 9] = obj.S_meisyou09;

                ////品種2
                //MainWindow.s_meisyou[1, 0] = obj.S_meisyou10;
                //MainWindow.s_meisyou[1, 1] = obj.S_meisyou11;
                //MainWindow.s_meisyou[1, 2] = obj.S_meisyou12;
                //MainWindow.s_meisyou[1, 3] = obj.S_meisyou13;
                //MainWindow.s_meisyou[1, 4] = obj.S_meisyou14;
                //MainWindow.s_meisyou[1, 5] = obj.S_meisyou15;
                //MainWindow.s_meisyou[1, 6] = obj.S_meisyou16;
                //MainWindow.s_meisyou[1, 7] = obj.S_meisyou17;
                //MainWindow.s_meisyou[1, 8] = obj.S_meisyou18;
                //MainWindow.s_meisyou[1, 9] = obj.S_meisyou19;

                ////品種3
                //MainWindow.s_meisyou[2, 0] = obj.S_meisyou20;
                //MainWindow.s_meisyou[2, 1] = obj.S_meisyou21;
                //MainWindow.s_meisyou[2, 2] = obj.S_meisyou22;
                //MainWindow.s_meisyou[2, 3] = obj.S_meisyou23;
                //MainWindow.s_meisyou[2, 4] = obj.S_meisyou24;
                //MainWindow.s_meisyou[2, 5] = obj.S_meisyou25;
                //MainWindow.s_meisyou[2, 6] = obj.S_meisyou26;
                //MainWindow.s_meisyou[2, 7] = obj.S_meisyou27;
                //MainWindow.s_meisyou[2, 8] = obj.S_meisyou28;
                //MainWindow.s_meisyou[2, 9] = obj.S_meisyou29;

                ////品種4
                //MainWindow.s_meisyou[3, 0] = obj.S_meisyou30;
                //MainWindow.s_meisyou[3, 1] = obj.S_meisyou31;
                //MainWindow.s_meisyou[3, 2] = obj.S_meisyou32;
                //MainWindow.s_meisyou[3, 3] = obj.S_meisyou33;
                //MainWindow.s_meisyou[3, 4] = obj.S_meisyou34;
                //MainWindow.s_meisyou[3, 5] = obj.S_meisyou35;
                //MainWindow.s_meisyou[3, 6] = obj.S_meisyou36;
                //MainWindow.s_meisyou[3, 7] = obj.S_meisyou37;
                //MainWindow.s_meisyou[3, 8] = obj.S_meisyou38;
                //MainWindow.s_meisyou[3, 9] = obj.S_meisyou39;

                ////品種5
                //MainWindow.s_meisyou[4, 0] = obj.S_meisyou40;
                //MainWindow.s_meisyou[4, 1] = obj.S_meisyou41;
                //MainWindow.s_meisyou[4, 2] = obj.S_meisyou42;
                //MainWindow.s_meisyou[4, 3] = obj.S_meisyou43;
                //MainWindow.s_meisyou[4, 4] = obj.S_meisyou44;
                //MainWindow.s_meisyou[4, 5] = obj.S_meisyou45;
                //MainWindow.s_meisyou[4, 6] = obj.S_meisyou46;
                //MainWindow.s_meisyou[4, 7] = obj.S_meisyou47;
                //MainWindow.s_meisyou[4, 8] = obj.S_meisyou48;
                //MainWindow.s_meisyou[4, 9] = obj.S_meisyou49;

                ////品種6
                //MainWindow.s_meisyou[5, 0] = obj.S_meisyou50;
                //MainWindow.s_meisyou[5, 1] = obj.S_meisyou51;
                //MainWindow.s_meisyou[5, 2] = obj.S_meisyou52;
                //MainWindow.s_meisyou[5, 3] = obj.S_meisyou53;
                //MainWindow.s_meisyou[5, 4] = obj.S_meisyou54;
                //MainWindow.s_meisyou[5, 5] = obj.S_meisyou55;
                //MainWindow.s_meisyou[5, 6] = obj.S_meisyou56;
                //MainWindow.s_meisyou[5, 7] = obj.S_meisyou57;
                //MainWindow.s_meisyou[5, 8] = obj.S_meisyou58;
                //MainWindow.s_meisyou[5, 9] = obj.S_meisyou59;

                ////品種7
                //MainWindow.s_meisyou[6, 0] = obj.S_meisyou60;
                //MainWindow.s_meisyou[6, 1] = obj.S_meisyou61;
                //MainWindow.s_meisyou[6, 2] = obj.S_meisyou62;
                //MainWindow.s_meisyou[6, 3] = obj.S_meisyou63;
                //MainWindow.s_meisyou[6, 4] = obj.S_meisyou64;
                //MainWindow.s_meisyou[6, 5] = obj.S_meisyou65;
                //MainWindow.s_meisyou[6, 6] = obj.S_meisyou66;
                //MainWindow.s_meisyou[6, 7] = obj.S_meisyou67;
                //MainWindow.s_meisyou[6, 8] = obj.S_meisyou68;
                //MainWindow.s_meisyou[6, 9] = obj.S_meisyou69;

                ////品種8
                //MainWindow.s_meisyou[7, 0] = obj.S_meisyou70;
                //MainWindow.s_meisyou[7, 1] = obj.S_meisyou71;
                //MainWindow.s_meisyou[7, 2] = obj.S_meisyou72;
                //MainWindow.s_meisyou[7, 3] = obj.S_meisyou73;
                //MainWindow.s_meisyou[7, 4] = obj.S_meisyou74;
                //MainWindow.s_meisyou[7, 5] = obj.S_meisyou75;
                //MainWindow.s_meisyou[7, 6] = obj.S_meisyou76;
                //MainWindow.s_meisyou[7, 7] = obj.S_meisyou77;
                //MainWindow.s_meisyou[7, 8] = obj.S_meisyou78;
                //MainWindow.s_meisyou[7, 9] = obj.S_meisyou79;

                ////品種9
                //MainWindow.s_meisyou[8, 0] = obj.S_meisyou80;
                //MainWindow.s_meisyou[8, 1] = obj.S_meisyou81;
                //MainWindow.s_meisyou[8, 2] = obj.S_meisyou82;
                //MainWindow.s_meisyou[8, 3] = obj.S_meisyou83;
                //MainWindow.s_meisyou[8, 4] = obj.S_meisyou84;
                //MainWindow.s_meisyou[8, 5] = obj.S_meisyou85;
                //MainWindow.s_meisyou[8, 6] = obj.S_meisyou86;
                //MainWindow.s_meisyou[8, 7] = obj.S_meisyou87;
                //MainWindow.s_meisyou[8, 8] = obj.S_meisyou88;
                //MainWindow.s_meisyou[8, 9] = obj.S_meisyou89;

                ////品種10
                //MainWindow.s_meisyou[9, 0] = obj.S_meisyou90;
                //MainWindow.s_meisyou[9, 1] = obj.S_meisyou91;
                //MainWindow.s_meisyou[9, 2] = obj.S_meisyou92;
                //MainWindow.s_meisyou[9, 3] = obj.S_meisyou93;
                //MainWindow.s_meisyou[9, 4] = obj.S_meisyou94;
                //MainWindow.s_meisyou[9, 5] = obj.S_meisyou95;
                //MainWindow.s_meisyou[9, 6] = obj.S_meisyou96;
                //MainWindow.s_meisyou[9, 7] = obj.S_meisyou97;
                //MainWindow.s_meisyou[9, 8] = obj.S_meisyou98;
                //MainWindow.s_meisyou[9, 9] = obj.S_meisyou99;

                ////ADD_END :2021/11/27 kitayama 理由：Streamの名称を格納する処理を追加
                /////DELETE_START :2021/12/19 kitayama 理由：名称は使用しないので削除

                //DELETE_START :2021/11/23 kitayama 理由：複数Streamに対応するため削除
                ////ADD_START :2021/11/14 kitayama 理由：閾値の上限下限を格納する配列を追加
                //MainWindow.dThreshold3[0, 0, 0] = obj.dThreshold_u00;
                //MainWindow.dThreshold3[0, 0, 1] = obj.dThreshold_u01;
                //MainWindow.dThreshold3[0, 0, 2] = obj.dThreshold_u02;
                //MainWindow.dThreshold3[0, 0, 3] = obj.dThreshold_u03;
                //MainWindow.dThreshold3[0, 0, 4] = obj.dThreshold_u04;
                //MainWindow.dThreshold3[0, 0, 5] = obj.dThreshold_u05;
                //MainWindow.dThreshold3[0, 0, 6] = obj.dThreshold_u06;
                //MainWindow.dThreshold3[0, 0, 7] = obj.dThreshold_u07;
                //MainWindow.dThreshold3[0, 0, 8] = obj.dThreshold_u08;
                //MainWindow.dThreshold3[0, 0, 9] = obj.dThreshold_u09;
                //MainWindow.dThreshold3[0, 1, 0] = obj.dThreshold_u10;
                //MainWindow.dThreshold3[0, 1, 1] = obj.dThreshold_u11;
                //MainWindow.dThreshold3[0, 1, 2] = obj.dThreshold_u12;
                //MainWindow.dThreshold3[0, 1, 3] = obj.dThreshold_u13;
                //MainWindow.dThreshold3[0, 1, 4] = obj.dThreshold_u14;
                //MainWindow.dThreshold3[0, 1, 5] = obj.dThreshold_u15;
                //MainWindow.dThreshold3[0, 1, 6] = obj.dThreshold_u16;
                //MainWindow.dThreshold3[0, 1, 7] = obj.dThreshold_u17;
                //MainWindow.dThreshold3[0, 1, 8] = obj.dThreshold_u18;
                //MainWindow.dThreshold3[0, 1, 9] = obj.dThreshold_u19;
                //MainWindow.dThreshold3[0, 2, 0] = obj.dThreshold_u20;
                //MainWindow.dThreshold3[0, 2, 1] = obj.dThreshold_u21;
                //MainWindow.dThreshold3[0, 2, 2] = obj.dThreshold_u22;
                //MainWindow.dThreshold3[0, 2, 3] = obj.dThreshold_u23;
                //MainWindow.dThreshold3[0, 2, 4] = obj.dThreshold_u24;
                //MainWindow.dThreshold3[0, 2, 5] = obj.dThreshold_u25;
                //MainWindow.dThreshold3[0, 2, 6] = obj.dThreshold_u26;
                //MainWindow.dThreshold3[0, 2, 7] = obj.dThreshold_u27;
                //MainWindow.dThreshold3[0, 2, 8] = obj.dThreshold_u28;
                //MainWindow.dThreshold3[0, 2, 9] = obj.dThreshold_u29;
                //MainWindow.dThreshold3[0, 3, 0] = obj.dThreshold_u30;
                //MainWindow.dThreshold3[0, 3, 1] = obj.dThreshold_u31;
                //MainWindow.dThreshold3[0, 3, 2] = obj.dThreshold_u32;
                //MainWindow.dThreshold3[0, 3, 3] = obj.dThreshold_u33;
                //MainWindow.dThreshold3[0, 3, 4] = obj.dThreshold_u34;
                //MainWindow.dThreshold3[0, 3, 5] = obj.dThreshold_u35;
                //MainWindow.dThreshold3[0, 3, 6] = obj.dThreshold_u36;
                //MainWindow.dThreshold3[0, 3, 7] = obj.dThreshold_u37;
                //MainWindow.dThreshold3[0, 3, 8] = obj.dThreshold_u38;
                //MainWindow.dThreshold3[0, 3, 9] = obj.dThreshold_u39;
                //MainWindow.dThreshold3[0, 4, 0] = obj.dThreshold_u40;
                //MainWindow.dThreshold3[0, 4, 1] = obj.dThreshold_u41;
                //MainWindow.dThreshold3[0, 4, 2] = obj.dThreshold_u42;
                //MainWindow.dThreshold3[0, 4, 3] = obj.dThreshold_u43;
                //MainWindow.dThreshold3[0, 4, 4] = obj.dThreshold_u44;
                //MainWindow.dThreshold3[0, 4, 5] = obj.dThreshold_u45;
                //MainWindow.dThreshold3[0, 4, 6] = obj.dThreshold_u46;
                //MainWindow.dThreshold3[0, 4, 7] = obj.dThreshold_u47;
                //MainWindow.dThreshold3[0, 4, 8] = obj.dThreshold_u48;
                //MainWindow.dThreshold3[0, 4, 9] = obj.dThreshold_u49;
                //MainWindow.dThreshold3[0, 5, 0] = obj.dThreshold_u50;
                //MainWindow.dThreshold3[0, 5, 1] = obj.dThreshold_u51;
                //MainWindow.dThreshold3[0, 5, 2] = obj.dThreshold_u52;
                //MainWindow.dThreshold3[0, 5, 3] = obj.dThreshold_u53;
                //MainWindow.dThreshold3[0, 5, 4] = obj.dThreshold_u54;
                //MainWindow.dThreshold3[0, 5, 5] = obj.dThreshold_u55;
                //MainWindow.dThreshold3[0, 5, 6] = obj.dThreshold_u56;
                //MainWindow.dThreshold3[0, 5, 7] = obj.dThreshold_u57;
                //MainWindow.dThreshold3[0, 5, 8] = obj.dThreshold_u58;
                //MainWindow.dThreshold3[0, 5, 9] = obj.dThreshold_u59;
                //MainWindow.dThreshold3[0, 6, 0] = obj.dThreshold_u60;
                //MainWindow.dThreshold3[0, 6, 1] = obj.dThreshold_u61;
                //MainWindow.dThreshold3[0, 6, 2] = obj.dThreshold_u62;
                //MainWindow.dThreshold3[0, 6, 3] = obj.dThreshold_u63;
                //MainWindow.dThreshold3[0, 6, 4] = obj.dThreshold_u64;
                //MainWindow.dThreshold3[0, 6, 5] = obj.dThreshold_u65;
                //MainWindow.dThreshold3[0, 6, 6] = obj.dThreshold_u66;
                //MainWindow.dThreshold3[0, 6, 7] = obj.dThreshold_u67;
                //MainWindow.dThreshold3[0, 6, 8] = obj.dThreshold_u68;
                //MainWindow.dThreshold3[0, 6, 9] = obj.dThreshold_u69;
                //MainWindow.dThreshold3[0, 7, 0] = obj.dThreshold_u70;
                //MainWindow.dThreshold3[0, 7, 1] = obj.dThreshold_u71;
                //MainWindow.dThreshold3[0, 7, 2] = obj.dThreshold_u72;
                //MainWindow.dThreshold3[0, 7, 3] = obj.dThreshold_u73;
                //MainWindow.dThreshold3[0, 7, 4] = obj.dThreshold_u74;
                //MainWindow.dThreshold3[0, 7, 5] = obj.dThreshold_u75;
                //MainWindow.dThreshold3[0, 7, 6] = obj.dThreshold_u76;
                //MainWindow.dThreshold3[0, 7, 7] = obj.dThreshold_u77;
                //MainWindow.dThreshold3[0, 7, 8] = obj.dThreshold_u78;
                //MainWindow.dThreshold3[0, 7, 9] = obj.dThreshold_u79;
                //MainWindow.dThreshold3[0, 8, 0] = obj.dThreshold_u80;
                //MainWindow.dThreshold3[0, 8, 1] = obj.dThreshold_u81;
                //MainWindow.dThreshold3[0, 8, 2] = obj.dThreshold_u82;
                //MainWindow.dThreshold3[0, 8, 3] = obj.dThreshold_u83;
                //MainWindow.dThreshold3[0, 8, 4] = obj.dThreshold_u84;
                //MainWindow.dThreshold3[0, 8, 5] = obj.dThreshold_u85;
                //MainWindow.dThreshold3[0, 8, 6] = obj.dThreshold_u86;
                //MainWindow.dThreshold3[0, 8, 7] = obj.dThreshold_u87;
                //MainWindow.dThreshold3[0, 8, 8] = obj.dThreshold_u88;
                //MainWindow.dThreshold3[0, 8, 9] = obj.dThreshold_u89;
                //MainWindow.dThreshold3[0, 9, 0] = obj.dThreshold_u90;
                //MainWindow.dThreshold3[0, 9, 1] = obj.dThreshold_u91;
                //MainWindow.dThreshold3[0, 9, 2] = obj.dThreshold_u92;
                //MainWindow.dThreshold3[0, 9, 3] = obj.dThreshold_u93;
                //MainWindow.dThreshold3[0, 9, 4] = obj.dThreshold_u94;
                //MainWindow.dThreshold3[0, 9, 5] = obj.dThreshold_u95;
                //MainWindow.dThreshold3[0, 9, 6] = obj.dThreshold_u96;
                //MainWindow.dThreshold3[0, 9, 7] = obj.dThreshold_u97;
                //MainWindow.dThreshold3[0, 9, 8] = obj.dThreshold_u98;
                //MainWindow.dThreshold3[0, 9, 9] = obj.dThreshold_u99;

                //MainWindow.dThreshold3[1, 0, 0] = obj.dThreshold_l00;
                //MainWindow.dThreshold3[1, 0, 1] = obj.dThreshold_l01;
                //MainWindow.dThreshold3[1, 0, 2] = obj.dThreshold_l02;
                //MainWindow.dThreshold3[1, 0, 3] = obj.dThreshold_l03;
                //MainWindow.dThreshold3[1, 0, 4] = obj.dThreshold_l04;
                //MainWindow.dThreshold3[1, 0, 5] = obj.dThreshold_l05;
                //MainWindow.dThreshold3[1, 0, 6] = obj.dThreshold_l06;
                //MainWindow.dThreshold3[1, 0, 7] = obj.dThreshold_l07;
                //MainWindow.dThreshold3[1, 0, 8] = obj.dThreshold_l08;
                //MainWindow.dThreshold3[1, 0, 9] = obj.dThreshold_l09;
                //MainWindow.dThreshold3[1, 1, 0] = obj.dThreshold_l10;
                //MainWindow.dThreshold3[1, 1, 1] = obj.dThreshold_l11;
                //MainWindow.dThreshold3[1, 1, 2] = obj.dThreshold_l12;
                //MainWindow.dThreshold3[1, 1, 3] = obj.dThreshold_l13;
                //MainWindow.dThreshold3[1, 1, 4] = obj.dThreshold_l14;
                //MainWindow.dThreshold3[1, 1, 5] = obj.dThreshold_l15;
                //MainWindow.dThreshold3[1, 1, 6] = obj.dThreshold_l16;
                //MainWindow.dThreshold3[1, 1, 7] = obj.dThreshold_l17;
                //MainWindow.dThreshold3[1, 1, 8] = obj.dThreshold_l18;
                //MainWindow.dThreshold3[1, 1, 9] = obj.dThreshold_l19;
                //MainWindow.dThreshold3[1, 2, 0] = obj.dThreshold_l20;
                //MainWindow.dThreshold3[1, 2, 1] = obj.dThreshold_l21;
                //MainWindow.dThreshold3[1, 2, 2] = obj.dThreshold_l22;
                //MainWindow.dThreshold3[1, 2, 3] = obj.dThreshold_l23;
                //MainWindow.dThreshold3[1, 2, 4] = obj.dThreshold_l24;
                //MainWindow.dThreshold3[1, 2, 5] = obj.dThreshold_l25;
                //MainWindow.dThreshold3[1, 2, 6] = obj.dThreshold_l26;
                //MainWindow.dThreshold3[1, 2, 7] = obj.dThreshold_l27;
                //MainWindow.dThreshold3[1, 2, 8] = obj.dThreshold_l28;
                //MainWindow.dThreshold3[1, 2, 9] = obj.dThreshold_l29;
                //MainWindow.dThreshold3[1, 3, 0] = obj.dThreshold_l30;
                //MainWindow.dThreshold3[1, 3, 1] = obj.dThreshold_l31;
                //MainWindow.dThreshold3[1, 3, 2] = obj.dThreshold_l32;
                //MainWindow.dThreshold3[1, 3, 3] = obj.dThreshold_l33;
                //MainWindow.dThreshold3[1, 3, 4] = obj.dThreshold_l34;
                //MainWindow.dThreshold3[1, 3, 5] = obj.dThreshold_l35;
                //MainWindow.dThreshold3[1, 3, 6] = obj.dThreshold_l36;
                //MainWindow.dThreshold3[1, 3, 7] = obj.dThreshold_l37;
                //MainWindow.dThreshold3[1, 3, 8] = obj.dThreshold_l38;
                //MainWindow.dThreshold3[1, 3, 9] = obj.dThreshold_l39;
                //MainWindow.dThreshold3[1, 4, 0] = obj.dThreshold_l40;
                //MainWindow.dThreshold3[1, 4, 1] = obj.dThreshold_l41;
                //MainWindow.dThreshold3[1, 4, 2] = obj.dThreshold_l42;
                //MainWindow.dThreshold3[1, 4, 3] = obj.dThreshold_l43;
                //MainWindow.dThreshold3[1, 4, 4] = obj.dThreshold_l44;
                //MainWindow.dThreshold3[1, 4, 5] = obj.dThreshold_l45;
                //MainWindow.dThreshold3[1, 4, 6] = obj.dThreshold_l46;
                //MainWindow.dThreshold3[1, 4, 7] = obj.dThreshold_l47;
                //MainWindow.dThreshold3[1, 4, 8] = obj.dThreshold_l48;
                //MainWindow.dThreshold3[1, 4, 9] = obj.dThreshold_l49;
                //MainWindow.dThreshold3[1, 5, 0] = obj.dThreshold_l50;
                //MainWindow.dThreshold3[1, 5, 1] = obj.dThreshold_l51;
                //MainWindow.dThreshold3[1, 5, 2] = obj.dThreshold_l52;
                //MainWindow.dThreshold3[1, 5, 3] = obj.dThreshold_l53;
                //MainWindow.dThreshold3[1, 5, 4] = obj.dThreshold_l54;
                //MainWindow.dThreshold3[1, 5, 5] = obj.dThreshold_l55;
                //MainWindow.dThreshold3[1, 5, 6] = obj.dThreshold_l56;
                //MainWindow.dThreshold3[1, 5, 7] = obj.dThreshold_l57;
                //MainWindow.dThreshold3[1, 5, 8] = obj.dThreshold_l58;
                //MainWindow.dThreshold3[1, 5, 9] = obj.dThreshold_l59;
                //MainWindow.dThreshold3[1, 6, 0] = obj.dThreshold_l60;
                //MainWindow.dThreshold3[1, 6, 1] = obj.dThreshold_l61;
                //MainWindow.dThreshold3[1, 6, 2] = obj.dThreshold_l62;
                //MainWindow.dThreshold3[1, 6, 3] = obj.dThreshold_l63;
                //MainWindow.dThreshold3[1, 6, 4] = obj.dThreshold_l64;
                //MainWindow.dThreshold3[1, 6, 5] = obj.dThreshold_l65;
                //MainWindow.dThreshold3[1, 6, 6] = obj.dThreshold_l66;
                //MainWindow.dThreshold3[1, 6, 7] = obj.dThreshold_l67;
                //MainWindow.dThreshold3[1, 6, 8] = obj.dThreshold_l68;
                //MainWindow.dThreshold3[1, 6, 9] = obj.dThreshold_l69;
                //MainWindow.dThreshold3[1, 7, 0] = obj.dThreshold_l70;
                //MainWindow.dThreshold3[1, 7, 1] = obj.dThreshold_l71;
                //MainWindow.dThreshold3[1, 7, 2] = obj.dThreshold_l72;
                //MainWindow.dThreshold3[1, 7, 3] = obj.dThreshold_l73;
                //MainWindow.dThreshold3[1, 7, 4] = obj.dThreshold_l74;
                //MainWindow.dThreshold3[1, 7, 5] = obj.dThreshold_l75;
                //MainWindow.dThreshold3[1, 7, 6] = obj.dThreshold_l76;
                //MainWindow.dThreshold3[1, 7, 7] = obj.dThreshold_l77;
                //MainWindow.dThreshold3[1, 7, 8] = obj.dThreshold_l78;
                //MainWindow.dThreshold3[1, 7, 9] = obj.dThreshold_l79;
                //MainWindow.dThreshold3[1, 8, 0] = obj.dThreshold_l80;
                //MainWindow.dThreshold3[1, 8, 1] = obj.dThreshold_l81;
                //MainWindow.dThreshold3[1, 8, 2] = obj.dThreshold_l82;
                //MainWindow.dThreshold3[1, 8, 3] = obj.dThreshold_l83;
                //MainWindow.dThreshold3[1, 8, 4] = obj.dThreshold_l84;
                //MainWindow.dThreshold3[1, 8, 5] = obj.dThreshold_l85;
                //MainWindow.dThreshold3[1, 8, 6] = obj.dThreshold_l86;
                //MainWindow.dThreshold3[1, 8, 7] = obj.dThreshold_l87;
                //MainWindow.dThreshold3[1, 8, 8] = obj.dThreshold_l88;
                //MainWindow.dThreshold3[1, 8, 9] = obj.dThreshold_l89;
                //MainWindow.dThreshold3[1, 9, 0] = obj.dThreshold_l90;
                //MainWindow.dThreshold3[1, 9, 1] = obj.dThreshold_l91;
                //MainWindow.dThreshold3[1, 9, 2] = obj.dThreshold_l92;
                //MainWindow.dThreshold3[1, 9, 3] = obj.dThreshold_l93;
                //MainWindow.dThreshold3[1, 9, 4] = obj.dThreshold_l94;
                //MainWindow.dThreshold3[1, 9, 5] = obj.dThreshold_l95;
                //MainWindow.dThreshold3[1, 9, 6] = obj.dThreshold_l96;
                //MainWindow.dThreshold3[1, 9, 7] = obj.dThreshold_l97;
                //MainWindow.dThreshold3[1, 9, 8] = obj.dThreshold_l98;
                //MainWindow.dThreshold3[1, 9, 9] = obj.dThreshold_l99;
                ////ADD_END :2021/11/14 kitayama 理由：閾値の上限下限を格納する配列を追加
                //DELETE_END :2021/11/23 kitayama 理由：複数Streamに対応するため削除


                //ADD_START :2020/4/27 kitayama 理由：改造に合わせたしきい値の形式に変更する
                //dThreshold[品種,Stream,Analyze]の形式になっている
                //品種1
                //1-Stream1
                MainWindow.dThreshold3[0, 0, 0, 0] = obj.dThreshold_u000;
                MainWindow.dThreshold3[0, 0, 0, 1] = obj.dThreshold_u001;
                MainWindow.dThreshold3[0, 0, 0, 2] = obj.dThreshold_u002;
                MainWindow.dThreshold3[0, 0, 0, 3] = obj.dThreshold_u003;
                MainWindow.dThreshold3[0, 0, 0, 4] = obj.dThreshold_u004;
                MainWindow.dThreshold3[0, 0, 0, 5] = obj.dThreshold_u005;
                MainWindow.dThreshold3[0, 0, 0, 6] = obj.dThreshold_u006;
                MainWindow.dThreshold3[0, 0, 0, 7] = obj.dThreshold_u007;
                MainWindow.dThreshold3[0, 0, 0, 8] = obj.dThreshold_u008;
                MainWindow.dThreshold3[0, 0, 0, 9] = obj.dThreshold_u009;

                MainWindow.dThreshold3[1, 0, 0, 0] = obj.dThreshold_l000;
                MainWindow.dThreshold3[1, 0, 0, 1] = obj.dThreshold_l001;
                MainWindow.dThreshold3[1, 0, 0, 2] = obj.dThreshold_l002;
                MainWindow.dThreshold3[1, 0, 0, 3] = obj.dThreshold_l003;
                MainWindow.dThreshold3[1, 0, 0, 4] = obj.dThreshold_l004;
                MainWindow.dThreshold3[1, 0, 0, 5] = obj.dThreshold_l005;
                MainWindow.dThreshold3[1, 0, 0, 6] = obj.dThreshold_l006;
                MainWindow.dThreshold3[1, 0, 0, 7] = obj.dThreshold_l007;
                MainWindow.dThreshold3[1, 0, 0, 8] = obj.dThreshold_l008;
                MainWindow.dThreshold3[1, 0, 0, 9] = obj.dThreshold_l009;
                //1-Stream2
                MainWindow.dThreshold3[0, 0, 1, 0] = obj.dThreshold_u010;
                MainWindow.dThreshold3[0, 0, 1, 1] = obj.dThreshold_u011;
                MainWindow.dThreshold3[0, 0, 1, 2] = obj.dThreshold_u012;
                MainWindow.dThreshold3[0, 0, 1, 3] = obj.dThreshold_u013;
                MainWindow.dThreshold3[0, 0, 1, 4] = obj.dThreshold_u014;
                MainWindow.dThreshold3[0, 0, 1, 5] = obj.dThreshold_u015;
                MainWindow.dThreshold3[0, 0, 1, 6] = obj.dThreshold_u016;
                MainWindow.dThreshold3[0, 0, 1, 7] = obj.dThreshold_u017;
                MainWindow.dThreshold3[0, 0, 1, 8] = obj.dThreshold_u018;
                MainWindow.dThreshold3[0, 0, 1, 9] = obj.dThreshold_u019;

                MainWindow.dThreshold3[1, 0, 1, 0] = obj.dThreshold_l010;
                MainWindow.dThreshold3[1, 0, 1, 1] = obj.dThreshold_l011;
                MainWindow.dThreshold3[1, 0, 1, 2] = obj.dThreshold_l012;
                MainWindow.dThreshold3[1, 0, 1, 3] = obj.dThreshold_l013;
                MainWindow.dThreshold3[1, 0, 1, 4] = obj.dThreshold_l014;
                MainWindow.dThreshold3[1, 0, 1, 5] = obj.dThreshold_l015;
                MainWindow.dThreshold3[1, 0, 1, 6] = obj.dThreshold_l016;
                MainWindow.dThreshold3[1, 0, 1, 7] = obj.dThreshold_l017;
                MainWindow.dThreshold3[1, 0, 1, 8] = obj.dThreshold_l018;
                MainWindow.dThreshold3[1, 0, 1, 9] = obj.dThreshold_l019;
                //1-Stream3
                MainWindow.dThreshold3[0, 0, 2, 0] = obj.dThreshold_u020;
                MainWindow.dThreshold3[0, 0, 2, 1] = obj.dThreshold_u021;
                MainWindow.dThreshold3[0, 0, 2, 2] = obj.dThreshold_u022;
                MainWindow.dThreshold3[0, 0, 2, 3] = obj.dThreshold_u023;
                MainWindow.dThreshold3[0, 0, 2, 4] = obj.dThreshold_u024;
                MainWindow.dThreshold3[0, 0, 2, 5] = obj.dThreshold_u025;
                MainWindow.dThreshold3[0, 0, 2, 6] = obj.dThreshold_u026;
                MainWindow.dThreshold3[0, 0, 2, 7] = obj.dThreshold_u027;
                MainWindow.dThreshold3[0, 0, 2, 8] = obj.dThreshold_u028;
                MainWindow.dThreshold3[0, 0, 2, 9] = obj.dThreshold_u029;

                MainWindow.dThreshold3[1, 0, 2, 0] = obj.dThreshold_l020;
                MainWindow.dThreshold3[1, 0, 2, 1] = obj.dThreshold_l021;
                MainWindow.dThreshold3[1, 0, 2, 2] = obj.dThreshold_l022;
                MainWindow.dThreshold3[1, 0, 2, 3] = obj.dThreshold_l023;
                MainWindow.dThreshold3[1, 0, 2, 4] = obj.dThreshold_l024;
                MainWindow.dThreshold3[1, 0, 2, 5] = obj.dThreshold_l025;
                MainWindow.dThreshold3[1, 0, 2, 6] = obj.dThreshold_l026;
                MainWindow.dThreshold3[1, 0, 2, 7] = obj.dThreshold_l027;
                MainWindow.dThreshold3[1, 0, 2, 8] = obj.dThreshold_l028;
                MainWindow.dThreshold3[1, 0, 2, 9] = obj.dThreshold_l029;
                //1-Stream4
                MainWindow.dThreshold3[0, 0, 3, 0] = obj.dThreshold_u030;
                MainWindow.dThreshold3[0, 0, 3, 1] = obj.dThreshold_u031;
                MainWindow.dThreshold3[0, 0, 3, 2] = obj.dThreshold_u032;
                MainWindow.dThreshold3[0, 0, 3, 3] = obj.dThreshold_u033;
                MainWindow.dThreshold3[0, 0, 3, 4] = obj.dThreshold_u034;
                MainWindow.dThreshold3[0, 0, 3, 5] = obj.dThreshold_u035;
                MainWindow.dThreshold3[0, 0, 3, 6] = obj.dThreshold_u036;
                MainWindow.dThreshold3[0, 0, 3, 7] = obj.dThreshold_u037;
                MainWindow.dThreshold3[0, 0, 3, 8] = obj.dThreshold_u038;
                MainWindow.dThreshold3[0, 0, 3, 9] = obj.dThreshold_u039;

                MainWindow.dThreshold3[1, 0, 3, 0] = obj.dThreshold_l030;
                MainWindow.dThreshold3[1, 0, 3, 1] = obj.dThreshold_l031;
                MainWindow.dThreshold3[1, 0, 3, 2] = obj.dThreshold_l032;
                MainWindow.dThreshold3[1, 0, 3, 3] = obj.dThreshold_l033;
                MainWindow.dThreshold3[1, 0, 3, 4] = obj.dThreshold_l034;
                MainWindow.dThreshold3[1, 0, 3, 5] = obj.dThreshold_l035;
                MainWindow.dThreshold3[1, 0, 3, 6] = obj.dThreshold_l036;
                MainWindow.dThreshold3[1, 0, 3, 7] = obj.dThreshold_l037;
                MainWindow.dThreshold3[1, 0, 3, 8] = obj.dThreshold_l038;
                MainWindow.dThreshold3[1, 0, 3, 9] = obj.dThreshold_l039;
                //1-Stream5
                MainWindow.dThreshold3[0, 0, 4, 0] = obj.dThreshold_u040;
                MainWindow.dThreshold3[0, 0, 4, 1] = obj.dThreshold_u041;
                MainWindow.dThreshold3[0, 0, 4, 2] = obj.dThreshold_u042;
                MainWindow.dThreshold3[0, 0, 4, 3] = obj.dThreshold_u043;
                MainWindow.dThreshold3[0, 0, 4, 4] = obj.dThreshold_u044;
                MainWindow.dThreshold3[0, 0, 4, 5] = obj.dThreshold_u045;
                MainWindow.dThreshold3[0, 0, 4, 6] = obj.dThreshold_u046;
                MainWindow.dThreshold3[0, 0, 4, 7] = obj.dThreshold_u047;
                MainWindow.dThreshold3[0, 0, 4, 8] = obj.dThreshold_u048;
                MainWindow.dThreshold3[0, 0, 4, 9] = obj.dThreshold_u049;

                MainWindow.dThreshold3[1, 0, 4, 0] = obj.dThreshold_l040;
                MainWindow.dThreshold3[1, 0, 4, 1] = obj.dThreshold_l041;
                MainWindow.dThreshold3[1, 0, 4, 2] = obj.dThreshold_l042;
                MainWindow.dThreshold3[1, 0, 4, 3] = obj.dThreshold_l043;
                MainWindow.dThreshold3[1, 0, 4, 4] = obj.dThreshold_l044;
                MainWindow.dThreshold3[1, 0, 4, 5] = obj.dThreshold_l045;
                MainWindow.dThreshold3[1, 0, 4, 6] = obj.dThreshold_l046;
                MainWindow.dThreshold3[1, 0, 4, 7] = obj.dThreshold_l047;
                MainWindow.dThreshold3[1, 0, 4, 8] = obj.dThreshold_l048;
                MainWindow.dThreshold3[1, 0, 4, 9] = obj.dThreshold_l049;
                //1-Stream6
                MainWindow.dThreshold3[0, 0, 5, 0] = obj.dThreshold_u050;
                MainWindow.dThreshold3[0, 0, 5, 1] = obj.dThreshold_u051;
                MainWindow.dThreshold3[0, 0, 5, 2] = obj.dThreshold_u052;
                MainWindow.dThreshold3[0, 0, 5, 3] = obj.dThreshold_u053;
                MainWindow.dThreshold3[0, 0, 5, 4] = obj.dThreshold_u054;
                MainWindow.dThreshold3[0, 0, 5, 5] = obj.dThreshold_u055;
                MainWindow.dThreshold3[0, 0, 5, 6] = obj.dThreshold_u056;
                MainWindow.dThreshold3[0, 0, 5, 7] = obj.dThreshold_u057;
                MainWindow.dThreshold3[0, 0, 5, 8] = obj.dThreshold_u058;
                MainWindow.dThreshold3[0, 0, 5, 9] = obj.dThreshold_u059;

                MainWindow.dThreshold3[1, 0, 5, 0] = obj.dThreshold_l050;
                MainWindow.dThreshold3[1, 0, 5, 1] = obj.dThreshold_l051;
                MainWindow.dThreshold3[1, 0, 5, 2] = obj.dThreshold_l052;
                MainWindow.dThreshold3[1, 0, 5, 3] = obj.dThreshold_l053;
                MainWindow.dThreshold3[1, 0, 5, 4] = obj.dThreshold_l054;
                MainWindow.dThreshold3[1, 0, 5, 5] = obj.dThreshold_l055;
                MainWindow.dThreshold3[1, 0, 5, 6] = obj.dThreshold_l056;
                MainWindow.dThreshold3[1, 0, 5, 7] = obj.dThreshold_l057;
                MainWindow.dThreshold3[1, 0, 5, 8] = obj.dThreshold_l058;
                MainWindow.dThreshold3[1, 0, 5, 9] = obj.dThreshold_l059;
                //1-Stream7
                MainWindow.dThreshold3[0, 0, 6, 0] = obj.dThreshold_u060;
                MainWindow.dThreshold3[0, 0, 6, 1] = obj.dThreshold_u061;
                MainWindow.dThreshold3[0, 0, 6, 2] = obj.dThreshold_u062;
                MainWindow.dThreshold3[0, 0, 6, 3] = obj.dThreshold_u063;
                MainWindow.dThreshold3[0, 0, 6, 4] = obj.dThreshold_u064;
                MainWindow.dThreshold3[0, 0, 6, 5] = obj.dThreshold_u065;
                MainWindow.dThreshold3[0, 0, 6, 6] = obj.dThreshold_u066;
                MainWindow.dThreshold3[0, 0, 6, 7] = obj.dThreshold_u067;
                MainWindow.dThreshold3[0, 0, 6, 8] = obj.dThreshold_u068;
                MainWindow.dThreshold3[0, 0, 6, 9] = obj.dThreshold_u069;

                MainWindow.dThreshold3[1, 0, 6, 0] = obj.dThreshold_l060;
                MainWindow.dThreshold3[1, 0, 6, 1] = obj.dThreshold_l061;
                MainWindow.dThreshold3[1, 0, 6, 2] = obj.dThreshold_l062;
                MainWindow.dThreshold3[1, 0, 6, 3] = obj.dThreshold_l063;
                MainWindow.dThreshold3[1, 0, 6, 4] = obj.dThreshold_l064;
                MainWindow.dThreshold3[1, 0, 6, 5] = obj.dThreshold_l065;
                MainWindow.dThreshold3[1, 0, 6, 6] = obj.dThreshold_l066;
                MainWindow.dThreshold3[1, 0, 6, 7] = obj.dThreshold_l067;
                MainWindow.dThreshold3[1, 0, 6, 8] = obj.dThreshold_l068;
                MainWindow.dThreshold3[1, 0, 6, 9] = obj.dThreshold_l069;
                //1-Stream8
                MainWindow.dThreshold3[0, 0, 7, 0] = obj.dThreshold_u070;
                MainWindow.dThreshold3[0, 0, 7, 1] = obj.dThreshold_u071;
                MainWindow.dThreshold3[0, 0, 7, 2] = obj.dThreshold_u072;
                MainWindow.dThreshold3[0, 0, 7, 3] = obj.dThreshold_u073;
                MainWindow.dThreshold3[0, 0, 7, 4] = obj.dThreshold_u074;
                MainWindow.dThreshold3[0, 0, 7, 5] = obj.dThreshold_u075;
                MainWindow.dThreshold3[0, 0, 7, 6] = obj.dThreshold_u076;
                MainWindow.dThreshold3[0, 0, 7, 7] = obj.dThreshold_u077;
                MainWindow.dThreshold3[0, 0, 7, 8] = obj.dThreshold_u078;
                MainWindow.dThreshold3[0, 0, 7, 9] = obj.dThreshold_u079;

                MainWindow.dThreshold3[1, 0, 7, 0] = obj.dThreshold_l070;
                MainWindow.dThreshold3[1, 0, 7, 1] = obj.dThreshold_l071;
                MainWindow.dThreshold3[1, 0, 7, 2] = obj.dThreshold_l072;
                MainWindow.dThreshold3[1, 0, 7, 3] = obj.dThreshold_l073;
                MainWindow.dThreshold3[1, 0, 7, 4] = obj.dThreshold_l074;
                MainWindow.dThreshold3[1, 0, 7, 5] = obj.dThreshold_l075;
                MainWindow.dThreshold3[1, 0, 7, 6] = obj.dThreshold_l076;
                MainWindow.dThreshold3[1, 0, 7, 7] = obj.dThreshold_l077;
                MainWindow.dThreshold3[1, 0, 7, 8] = obj.dThreshold_l078;
                MainWindow.dThreshold3[1, 0, 7, 9] = obj.dThreshold_l079;
                //1-Stream9
                MainWindow.dThreshold3[0, 0, 8, 0] = obj.dThreshold_u080;
                MainWindow.dThreshold3[0, 0, 8, 1] = obj.dThreshold_u081;
                MainWindow.dThreshold3[0, 0, 8, 2] = obj.dThreshold_u082;
                MainWindow.dThreshold3[0, 0, 8, 3] = obj.dThreshold_u083;
                MainWindow.dThreshold3[0, 0, 8, 4] = obj.dThreshold_u084;
                MainWindow.dThreshold3[0, 0, 8, 5] = obj.dThreshold_u085;
                MainWindow.dThreshold3[0, 0, 8, 6] = obj.dThreshold_u086;
                MainWindow.dThreshold3[0, 0, 8, 7] = obj.dThreshold_u087;
                MainWindow.dThreshold3[0, 0, 8, 8] = obj.dThreshold_u088;
                MainWindow.dThreshold3[0, 0, 8, 9] = obj.dThreshold_u089;

                MainWindow.dThreshold3[1, 0, 8, 0] = obj.dThreshold_l080;
                MainWindow.dThreshold3[1, 0, 8, 1] = obj.dThreshold_l081;
                MainWindow.dThreshold3[1, 0, 8, 2] = obj.dThreshold_l082;
                MainWindow.dThreshold3[1, 0, 8, 3] = obj.dThreshold_l083;
                MainWindow.dThreshold3[1, 0, 8, 4] = obj.dThreshold_l084;
                MainWindow.dThreshold3[1, 0, 8, 5] = obj.dThreshold_l085;
                MainWindow.dThreshold3[1, 0, 8, 6] = obj.dThreshold_l086;
                MainWindow.dThreshold3[1, 0, 8, 7] = obj.dThreshold_l087;
                MainWindow.dThreshold3[1, 0, 8, 8] = obj.dThreshold_l088;
                MainWindow.dThreshold3[1, 0, 8, 9] = obj.dThreshold_l089;
                //1-Stream10
                MainWindow.dThreshold3[0, 0, 9, 0] = obj.dThreshold_u090;
                MainWindow.dThreshold3[0, 0, 9, 1] = obj.dThreshold_u091;
                MainWindow.dThreshold3[0, 0, 9, 2] = obj.dThreshold_u092;
                MainWindow.dThreshold3[0, 0, 9, 3] = obj.dThreshold_u093;
                MainWindow.dThreshold3[0, 0, 9, 4] = obj.dThreshold_u094;
                MainWindow.dThreshold3[0, 0, 9, 5] = obj.dThreshold_u095;
                MainWindow.dThreshold3[0, 0, 9, 6] = obj.dThreshold_u096;
                MainWindow.dThreshold3[0, 0, 9, 7] = obj.dThreshold_u097;
                MainWindow.dThreshold3[0, 0, 9, 8] = obj.dThreshold_u098;
                MainWindow.dThreshold3[0, 0, 9, 9] = obj.dThreshold_u099;

                MainWindow.dThreshold3[1, 0, 9, 0] = obj.dThreshold_l090;
                MainWindow.dThreshold3[1, 0, 9, 1] = obj.dThreshold_l091;
                MainWindow.dThreshold3[1, 0, 9, 2] = obj.dThreshold_l092;
                MainWindow.dThreshold3[1, 0, 9, 3] = obj.dThreshold_l093;
                MainWindow.dThreshold3[1, 0, 9, 4] = obj.dThreshold_l094;
                MainWindow.dThreshold3[1, 0, 9, 5] = obj.dThreshold_l095;
                MainWindow.dThreshold3[1, 0, 9, 6] = obj.dThreshold_l096;
                MainWindow.dThreshold3[1, 0, 9, 7] = obj.dThreshold_l097;
                MainWindow.dThreshold3[1, 0, 9, 8] = obj.dThreshold_l098;
                MainWindow.dThreshold3[1, 0, 9, 9] = obj.dThreshold_l099;
                //1-Stream11
                MainWindow.dThreshold3[0, 0, 10, 0] = obj.dThreshold_u0A0;
                MainWindow.dThreshold3[0, 0, 10, 1] = obj.dThreshold_u0A1;
                MainWindow.dThreshold3[0, 0, 10, 2] = obj.dThreshold_u0A2;
                MainWindow.dThreshold3[0, 0, 10, 3] = obj.dThreshold_u0A3;
                MainWindow.dThreshold3[0, 0, 10, 4] = obj.dThreshold_u0A4;
                MainWindow.dThreshold3[0, 0, 10, 5] = obj.dThreshold_u0A5;
                MainWindow.dThreshold3[0, 0, 10, 6] = obj.dThreshold_u0A6;
                MainWindow.dThreshold3[0, 0, 10, 7] = obj.dThreshold_u0A7;
                MainWindow.dThreshold3[0, 0, 10, 8] = obj.dThreshold_u0A8;
                MainWindow.dThreshold3[0, 0, 10, 9] = obj.dThreshold_u0A9;

                MainWindow.dThreshold3[1, 0, 10, 0] = obj.dThreshold_l0A0;
                MainWindow.dThreshold3[1, 0, 10, 1] = obj.dThreshold_l0A1;
                MainWindow.dThreshold3[1, 0, 10, 2] = obj.dThreshold_l0A2;
                MainWindow.dThreshold3[1, 0, 10, 3] = obj.dThreshold_l0A3;
                MainWindow.dThreshold3[1, 0, 10, 4] = obj.dThreshold_l0A4;
                MainWindow.dThreshold3[1, 0, 10, 5] = obj.dThreshold_l0A5;
                MainWindow.dThreshold3[1, 0, 10, 6] = obj.dThreshold_l0A6;
                MainWindow.dThreshold3[1, 0, 10, 7] = obj.dThreshold_l0A7;
                MainWindow.dThreshold3[1, 0, 10, 8] = obj.dThreshold_l0A8;
                MainWindow.dThreshold3[1, 0, 10, 9] = obj.dThreshold_l0A9;

                //品種2
                //2-Stream1
                MainWindow.dThreshold3[0, 1, 0, 0] = obj.dThreshold_u100;
                MainWindow.dThreshold3[0, 1, 0, 1] = obj.dThreshold_u101;
                MainWindow.dThreshold3[0, 1, 0, 2] = obj.dThreshold_u102;
                MainWindow.dThreshold3[0, 1, 0, 3] = obj.dThreshold_u103;
                MainWindow.dThreshold3[0, 1, 0, 4] = obj.dThreshold_u104;
                MainWindow.dThreshold3[0, 1, 0, 5] = obj.dThreshold_u105;
                MainWindow.dThreshold3[0, 1, 0, 6] = obj.dThreshold_u106;
                MainWindow.dThreshold3[0, 1, 0, 7] = obj.dThreshold_u107;
                MainWindow.dThreshold3[0, 1, 0, 8] = obj.dThreshold_u108;
                MainWindow.dThreshold3[0, 1, 0, 9] = obj.dThreshold_u109;

                MainWindow.dThreshold3[1, 1, 0, 0] = obj.dThreshold_l100;
                MainWindow.dThreshold3[1, 1, 0, 1] = obj.dThreshold_l101;
                MainWindow.dThreshold3[1, 1, 0, 2] = obj.dThreshold_l102;
                MainWindow.dThreshold3[1, 1, 0, 3] = obj.dThreshold_l103;
                MainWindow.dThreshold3[1, 1, 0, 4] = obj.dThreshold_l104;
                MainWindow.dThreshold3[1, 1, 0, 5] = obj.dThreshold_l105;
                MainWindow.dThreshold3[1, 1, 0, 6] = obj.dThreshold_l106;
                MainWindow.dThreshold3[1, 1, 0, 7] = obj.dThreshold_l107;
                MainWindow.dThreshold3[1, 1, 0, 8] = obj.dThreshold_l108;
                MainWindow.dThreshold3[1, 1, 0, 9] = obj.dThreshold_l109;
                //2-Stream2
                MainWindow.dThreshold3[0, 1, 1, 0] = obj.dThreshold_u110;
                MainWindow.dThreshold3[0, 1, 1, 1] = obj.dThreshold_u111;
                MainWindow.dThreshold3[0, 1, 1, 2] = obj.dThreshold_u112;
                MainWindow.dThreshold3[0, 1, 1, 3] = obj.dThreshold_u113;
                MainWindow.dThreshold3[0, 1, 1, 4] = obj.dThreshold_u114;
                MainWindow.dThreshold3[0, 1, 1, 5] = obj.dThreshold_u115;
                MainWindow.dThreshold3[0, 1, 1, 6] = obj.dThreshold_u116;
                MainWindow.dThreshold3[0, 1, 1, 7] = obj.dThreshold_u117;
                MainWindow.dThreshold3[0, 1, 1, 8] = obj.dThreshold_u118;
                MainWindow.dThreshold3[0, 1, 1, 9] = obj.dThreshold_u119;

                MainWindow.dThreshold3[1, 1, 1, 0] = obj.dThreshold_l110;
                MainWindow.dThreshold3[1, 1, 1, 1] = obj.dThreshold_l111;
                MainWindow.dThreshold3[1, 1, 1, 2] = obj.dThreshold_l112;
                MainWindow.dThreshold3[1, 1, 1, 3] = obj.dThreshold_l113;
                MainWindow.dThreshold3[1, 1, 1, 4] = obj.dThreshold_l114;
                MainWindow.dThreshold3[1, 1, 1, 5] = obj.dThreshold_l115;
                MainWindow.dThreshold3[1, 1, 1, 6] = obj.dThreshold_l116;
                MainWindow.dThreshold3[1, 1, 1, 7] = obj.dThreshold_l117;
                MainWindow.dThreshold3[1, 1, 1, 8] = obj.dThreshold_l118;
                MainWindow.dThreshold3[1, 1, 1, 9] = obj.dThreshold_l119;
                //2-Stream3
                MainWindow.dThreshold3[0, 1, 2, 0] = obj.dThreshold_u120;
                MainWindow.dThreshold3[0, 1, 2, 1] = obj.dThreshold_u121;
                MainWindow.dThreshold3[0, 1, 2, 2] = obj.dThreshold_u122;
                MainWindow.dThreshold3[0, 1, 2, 3] = obj.dThreshold_u123;
                MainWindow.dThreshold3[0, 1, 2, 4] = obj.dThreshold_u124;
                MainWindow.dThreshold3[0, 1, 2, 5] = obj.dThreshold_u125;
                MainWindow.dThreshold3[0, 1, 2, 6] = obj.dThreshold_u126;
                MainWindow.dThreshold3[0, 1, 2, 7] = obj.dThreshold_u127;
                MainWindow.dThreshold3[0, 1, 2, 8] = obj.dThreshold_u128;
                MainWindow.dThreshold3[0, 1, 2, 9] = obj.dThreshold_u129;

                MainWindow.dThreshold3[1, 1, 2, 0] = obj.dThreshold_l120;
                MainWindow.dThreshold3[1, 1, 2, 1] = obj.dThreshold_l121;
                MainWindow.dThreshold3[1, 1, 2, 2] = obj.dThreshold_l122;
                MainWindow.dThreshold3[1, 1, 2, 3] = obj.dThreshold_l123;
                MainWindow.dThreshold3[1, 1, 2, 4] = obj.dThreshold_l124;
                MainWindow.dThreshold3[1, 1, 2, 5] = obj.dThreshold_l125;
                MainWindow.dThreshold3[1, 1, 2, 6] = obj.dThreshold_l126;
                MainWindow.dThreshold3[1, 1, 2, 7] = obj.dThreshold_l127;
                MainWindow.dThreshold3[1, 1, 2, 8] = obj.dThreshold_l128;
                MainWindow.dThreshold3[1, 1, 2, 9] = obj.dThreshold_l129;
                //2-Stream4
                MainWindow.dThreshold3[0, 1, 3, 0] = obj.dThreshold_u130;
                MainWindow.dThreshold3[0, 1, 3, 1] = obj.dThreshold_u131;
                MainWindow.dThreshold3[0, 1, 3, 2] = obj.dThreshold_u132;
                MainWindow.dThreshold3[0, 1, 3, 3] = obj.dThreshold_u133;
                MainWindow.dThreshold3[0, 1, 3, 4] = obj.dThreshold_u134;
                MainWindow.dThreshold3[0, 1, 3, 5] = obj.dThreshold_u135;
                MainWindow.dThreshold3[0, 1, 3, 6] = obj.dThreshold_u136;
                MainWindow.dThreshold3[0, 1, 3, 7] = obj.dThreshold_u137;
                MainWindow.dThreshold3[0, 1, 3, 8] = obj.dThreshold_u138;
                MainWindow.dThreshold3[0, 1, 3, 9] = obj.dThreshold_u139;

                MainWindow.dThreshold3[1, 1, 3, 0] = obj.dThreshold_l130;
                MainWindow.dThreshold3[1, 1, 3, 1] = obj.dThreshold_l131;
                MainWindow.dThreshold3[1, 1, 3, 2] = obj.dThreshold_l132;
                MainWindow.dThreshold3[1, 1, 3, 3] = obj.dThreshold_l133;
                MainWindow.dThreshold3[1, 1, 3, 4] = obj.dThreshold_l134;
                MainWindow.dThreshold3[1, 1, 3, 5] = obj.dThreshold_l135;
                MainWindow.dThreshold3[1, 1, 3, 6] = obj.dThreshold_l136;
                MainWindow.dThreshold3[1, 1, 3, 7] = obj.dThreshold_l137;
                MainWindow.dThreshold3[1, 1, 3, 8] = obj.dThreshold_l138;
                MainWindow.dThreshold3[1, 1, 3, 9] = obj.dThreshold_l139;
                //2-Stream5
                MainWindow.dThreshold3[0, 1, 4, 0] = obj.dThreshold_u140;
                MainWindow.dThreshold3[0, 1, 4, 1] = obj.dThreshold_u141;
                MainWindow.dThreshold3[0, 1, 4, 2] = obj.dThreshold_u142;
                MainWindow.dThreshold3[0, 1, 4, 3] = obj.dThreshold_u143;
                MainWindow.dThreshold3[0, 1, 4, 4] = obj.dThreshold_u144;
                MainWindow.dThreshold3[0, 1, 4, 5] = obj.dThreshold_u145;
                MainWindow.dThreshold3[0, 1, 4, 6] = obj.dThreshold_u146;
                MainWindow.dThreshold3[0, 1, 4, 7] = obj.dThreshold_u147;
                MainWindow.dThreshold3[0, 1, 4, 8] = obj.dThreshold_u148;
                MainWindow.dThreshold3[0, 1, 4, 9] = obj.dThreshold_u149;

                MainWindow.dThreshold3[1, 1, 4, 0] = obj.dThreshold_l140;
                MainWindow.dThreshold3[1, 1, 4, 1] = obj.dThreshold_l141;
                MainWindow.dThreshold3[1, 1, 4, 2] = obj.dThreshold_l142;
                MainWindow.dThreshold3[1, 1, 4, 3] = obj.dThreshold_l143;
                MainWindow.dThreshold3[1, 1, 4, 4] = obj.dThreshold_l144;
                MainWindow.dThreshold3[1, 1, 4, 5] = obj.dThreshold_l145;
                MainWindow.dThreshold3[1, 1, 4, 6] = obj.dThreshold_l146;
                MainWindow.dThreshold3[1, 1, 4, 7] = obj.dThreshold_l147;
                MainWindow.dThreshold3[1, 1, 4, 8] = obj.dThreshold_l148;
                MainWindow.dThreshold3[1, 1, 4, 9] = obj.dThreshold_l149;
                //2-Stream6
                MainWindow.dThreshold3[0, 1, 5, 0] = obj.dThreshold_u150;
                MainWindow.dThreshold3[0, 1, 5, 1] = obj.dThreshold_u151;
                MainWindow.dThreshold3[0, 1, 5, 2] = obj.dThreshold_u152;
                MainWindow.dThreshold3[0, 1, 5, 3] = obj.dThreshold_u153;
                MainWindow.dThreshold3[0, 1, 5, 4] = obj.dThreshold_u154;
                MainWindow.dThreshold3[0, 1, 5, 5] = obj.dThreshold_u155;
                MainWindow.dThreshold3[0, 1, 5, 6] = obj.dThreshold_u156;
                MainWindow.dThreshold3[0, 1, 5, 7] = obj.dThreshold_u157;
                MainWindow.dThreshold3[0, 1, 5, 8] = obj.dThreshold_u158;
                MainWindow.dThreshold3[0, 1, 5, 9] = obj.dThreshold_u159;

                MainWindow.dThreshold3[1, 1, 5, 0] = obj.dThreshold_l150;
                MainWindow.dThreshold3[1, 1, 5, 1] = obj.dThreshold_l151;
                MainWindow.dThreshold3[1, 1, 5, 2] = obj.dThreshold_l152;
                MainWindow.dThreshold3[1, 1, 5, 3] = obj.dThreshold_l153;
                MainWindow.dThreshold3[1, 1, 5, 4] = obj.dThreshold_l154;
                MainWindow.dThreshold3[1, 1, 5, 5] = obj.dThreshold_l155;
                MainWindow.dThreshold3[1, 1, 5, 6] = obj.dThreshold_l156;
                MainWindow.dThreshold3[1, 1, 5, 7] = obj.dThreshold_l157;
                MainWindow.dThreshold3[1, 1, 5, 8] = obj.dThreshold_l158;
                MainWindow.dThreshold3[1, 1, 5, 9] = obj.dThreshold_l159;
                //2-Stream7
                MainWindow.dThreshold3[0, 1, 6, 0] = obj.dThreshold_u160;
                MainWindow.dThreshold3[0, 1, 6, 1] = obj.dThreshold_u161;
                MainWindow.dThreshold3[0, 1, 6, 2] = obj.dThreshold_u162;
                MainWindow.dThreshold3[0, 1, 6, 3] = obj.dThreshold_u163;
                MainWindow.dThreshold3[0, 1, 6, 4] = obj.dThreshold_u164;
                MainWindow.dThreshold3[0, 1, 6, 5] = obj.dThreshold_u165;
                MainWindow.dThreshold3[0, 1, 6, 6] = obj.dThreshold_u166;
                MainWindow.dThreshold3[0, 1, 6, 7] = obj.dThreshold_u167;
                MainWindow.dThreshold3[0, 1, 6, 8] = obj.dThreshold_u168;
                MainWindow.dThreshold3[0, 1, 6, 9] = obj.dThreshold_u169;

                MainWindow.dThreshold3[1, 1, 6, 0] = obj.dThreshold_l160;
                MainWindow.dThreshold3[1, 1, 6, 1] = obj.dThreshold_l161;
                MainWindow.dThreshold3[1, 1, 6, 2] = obj.dThreshold_l162;
                MainWindow.dThreshold3[1, 1, 6, 3] = obj.dThreshold_l163;
                MainWindow.dThreshold3[1, 1, 6, 4] = obj.dThreshold_l164;
                MainWindow.dThreshold3[1, 1, 6, 5] = obj.dThreshold_l165;
                MainWindow.dThreshold3[1, 1, 6, 6] = obj.dThreshold_l166;
                MainWindow.dThreshold3[1, 1, 6, 7] = obj.dThreshold_l167;
                MainWindow.dThreshold3[1, 1, 6, 8] = obj.dThreshold_l168;
                MainWindow.dThreshold3[1, 1, 6, 9] = obj.dThreshold_l169;
                //2-Stream8
                MainWindow.dThreshold3[0, 1, 7, 0] = obj.dThreshold_u170;
                MainWindow.dThreshold3[0, 1, 7, 1] = obj.dThreshold_u171;
                MainWindow.dThreshold3[0, 1, 7, 2] = obj.dThreshold_u172;
                MainWindow.dThreshold3[0, 1, 7, 3] = obj.dThreshold_u173;
                MainWindow.dThreshold3[0, 1, 7, 4] = obj.dThreshold_u174;
                MainWindow.dThreshold3[0, 1, 7, 5] = obj.dThreshold_u175;
                MainWindow.dThreshold3[0, 1, 7, 6] = obj.dThreshold_u176;
                MainWindow.dThreshold3[0, 1, 7, 7] = obj.dThreshold_u177;
                MainWindow.dThreshold3[0, 1, 7, 8] = obj.dThreshold_u178;
                MainWindow.dThreshold3[0, 1, 7, 9] = obj.dThreshold_u179;

                MainWindow.dThreshold3[1, 1, 7, 0] = obj.dThreshold_l170;
                MainWindow.dThreshold3[1, 1, 7, 1] = obj.dThreshold_l171;
                MainWindow.dThreshold3[1, 1, 7, 2] = obj.dThreshold_l172;
                MainWindow.dThreshold3[1, 1, 7, 3] = obj.dThreshold_l173;
                MainWindow.dThreshold3[1, 1, 7, 4] = obj.dThreshold_l174;
                MainWindow.dThreshold3[1, 1, 7, 5] = obj.dThreshold_l175;
                MainWindow.dThreshold3[1, 1, 7, 6] = obj.dThreshold_l176;
                MainWindow.dThreshold3[1, 1, 7, 7] = obj.dThreshold_l177;
                MainWindow.dThreshold3[1, 1, 7, 8] = obj.dThreshold_l178;
                MainWindow.dThreshold3[1, 1, 7, 9] = obj.dThreshold_l179;
                //2-Stream9
                MainWindow.dThreshold3[0, 1, 8, 0] = obj.dThreshold_u180;
                MainWindow.dThreshold3[0, 1, 8, 1] = obj.dThreshold_u181;
                MainWindow.dThreshold3[0, 1, 8, 2] = obj.dThreshold_u182;
                MainWindow.dThreshold3[0, 1, 8, 3] = obj.dThreshold_u183;
                MainWindow.dThreshold3[0, 1, 8, 4] = obj.dThreshold_u184;
                MainWindow.dThreshold3[0, 1, 8, 5] = obj.dThreshold_u185;
                MainWindow.dThreshold3[0, 1, 8, 6] = obj.dThreshold_u186;
                MainWindow.dThreshold3[0, 1, 8, 7] = obj.dThreshold_u187;
                MainWindow.dThreshold3[0, 1, 8, 8] = obj.dThreshold_u188;
                MainWindow.dThreshold3[0, 1, 8, 9] = obj.dThreshold_u189;

                MainWindow.dThreshold3[1, 1, 8, 0] = obj.dThreshold_l180;
                MainWindow.dThreshold3[1, 1, 8, 1] = obj.dThreshold_l181;
                MainWindow.dThreshold3[1, 1, 8, 2] = obj.dThreshold_l182;
                MainWindow.dThreshold3[1, 1, 8, 3] = obj.dThreshold_l183;
                MainWindow.dThreshold3[1, 1, 8, 4] = obj.dThreshold_l184;
                MainWindow.dThreshold3[1, 1, 8, 5] = obj.dThreshold_l185;
                MainWindow.dThreshold3[1, 1, 8, 6] = obj.dThreshold_l186;
                MainWindow.dThreshold3[1, 1, 8, 7] = obj.dThreshold_l187;
                MainWindow.dThreshold3[1, 1, 8, 8] = obj.dThreshold_l188;
                MainWindow.dThreshold3[1, 1, 8, 9] = obj.dThreshold_l189;
                //2-Stream10
                MainWindow.dThreshold3[0, 1, 9, 0] = obj.dThreshold_u190;
                MainWindow.dThreshold3[0, 1, 9, 1] = obj.dThreshold_u191;
                MainWindow.dThreshold3[0, 1, 9, 2] = obj.dThreshold_u192;
                MainWindow.dThreshold3[0, 1, 9, 3] = obj.dThreshold_u193;
                MainWindow.dThreshold3[0, 1, 9, 4] = obj.dThreshold_u194;
                MainWindow.dThreshold3[0, 1, 9, 5] = obj.dThreshold_u195;
                MainWindow.dThreshold3[0, 1, 9, 6] = obj.dThreshold_u196;
                MainWindow.dThreshold3[0, 1, 9, 7] = obj.dThreshold_u197;
                MainWindow.dThreshold3[0, 1, 9, 8] = obj.dThreshold_u198;
                MainWindow.dThreshold3[0, 1, 9, 9] = obj.dThreshold_u199;

                MainWindow.dThreshold3[1, 1, 9, 0] = obj.dThreshold_l190;
                MainWindow.dThreshold3[1, 1, 9, 1] = obj.dThreshold_l191;
                MainWindow.dThreshold3[1, 1, 9, 2] = obj.dThreshold_l192;
                MainWindow.dThreshold3[1, 1, 9, 3] = obj.dThreshold_l193;
                MainWindow.dThreshold3[1, 1, 9, 4] = obj.dThreshold_l194;
                MainWindow.dThreshold3[1, 1, 9, 5] = obj.dThreshold_l195;
                MainWindow.dThreshold3[1, 1, 9, 6] = obj.dThreshold_l196;
                MainWindow.dThreshold3[1, 1, 9, 7] = obj.dThreshold_l197;
                MainWindow.dThreshold3[1, 1, 9, 8] = obj.dThreshold_l198;
                MainWindow.dThreshold3[1, 1, 9, 9] = obj.dThreshold_l199;
                //2-Stream11
                MainWindow.dThreshold3[0, 1, 10, 0] = obj.dThreshold_u1A0;
                MainWindow.dThreshold3[0, 1, 10, 1] = obj.dThreshold_u1A1;
                MainWindow.dThreshold3[0, 1, 10, 2] = obj.dThreshold_u1A2;
                MainWindow.dThreshold3[0, 1, 10, 3] = obj.dThreshold_u1A3;
                MainWindow.dThreshold3[0, 1, 10, 4] = obj.dThreshold_u1A4;
                MainWindow.dThreshold3[0, 1, 10, 5] = obj.dThreshold_u1A5;
                MainWindow.dThreshold3[0, 1, 10, 6] = obj.dThreshold_u1A6;
                MainWindow.dThreshold3[0, 1, 10, 7] = obj.dThreshold_u1A7;
                MainWindow.dThreshold3[0, 1, 10, 8] = obj.dThreshold_u1A8;
                MainWindow.dThreshold3[0, 1, 10, 9] = obj.dThreshold_u1A9;

                MainWindow.dThreshold3[1, 1, 10, 0] = obj.dThreshold_l1A0;
                MainWindow.dThreshold3[1, 1, 10, 1] = obj.dThreshold_l1A1;
                MainWindow.dThreshold3[1, 1, 10, 2] = obj.dThreshold_l1A2;
                MainWindow.dThreshold3[1, 1, 10, 3] = obj.dThreshold_l1A3;
                MainWindow.dThreshold3[1, 1, 10, 4] = obj.dThreshold_l1A4;
                MainWindow.dThreshold3[1, 1, 10, 5] = obj.dThreshold_l1A5;
                MainWindow.dThreshold3[1, 1, 10, 6] = obj.dThreshold_l1A6;
                MainWindow.dThreshold3[1, 1, 10, 7] = obj.dThreshold_l1A7;
                MainWindow.dThreshold3[1, 1, 10, 8] = obj.dThreshold_l1A8;
                MainWindow.dThreshold3[1, 1, 10, 9] = obj.dThreshold_l1A9;

                //品種3
                //3-Stream1
                MainWindow.dThreshold3[0, 2, 0, 0] = obj.dThreshold_u200;
                MainWindow.dThreshold3[0, 2, 0, 1] = obj.dThreshold_u201;
                MainWindow.dThreshold3[0, 2, 0, 2] = obj.dThreshold_u202;
                MainWindow.dThreshold3[0, 2, 0, 3] = obj.dThreshold_u203;
                MainWindow.dThreshold3[0, 2, 0, 4] = obj.dThreshold_u204;
                MainWindow.dThreshold3[0, 2, 0, 5] = obj.dThreshold_u205;
                MainWindow.dThreshold3[0, 2, 0, 6] = obj.dThreshold_u206;
                MainWindow.dThreshold3[0, 2, 0, 7] = obj.dThreshold_u207;
                MainWindow.dThreshold3[0, 2, 0, 8] = obj.dThreshold_u208;
                MainWindow.dThreshold3[0, 2, 0, 9] = obj.dThreshold_u209;

                MainWindow.dThreshold3[1, 2, 0, 0] = obj.dThreshold_l200;
                MainWindow.dThreshold3[1, 2, 0, 1] = obj.dThreshold_l201;
                MainWindow.dThreshold3[1, 2, 0, 2] = obj.dThreshold_l202;
                MainWindow.dThreshold3[1, 2, 0, 3] = obj.dThreshold_l203;
                MainWindow.dThreshold3[1, 2, 0, 4] = obj.dThreshold_l204;
                MainWindow.dThreshold3[1, 2, 0, 5] = obj.dThreshold_l205;
                MainWindow.dThreshold3[1, 2, 0, 6] = obj.dThreshold_l206;
                MainWindow.dThreshold3[1, 2, 0, 7] = obj.dThreshold_l207;
                MainWindow.dThreshold3[1, 2, 0, 8] = obj.dThreshold_l208;
                MainWindow.dThreshold3[1, 2, 0, 9] = obj.dThreshold_l209;
                //3-Stream2
                MainWindow.dThreshold3[0, 2, 1, 0] = obj.dThreshold_u210;
                MainWindow.dThreshold3[0, 2, 1, 1] = obj.dThreshold_u211;
                MainWindow.dThreshold3[0, 2, 1, 2] = obj.dThreshold_u212;
                MainWindow.dThreshold3[0, 2, 1, 3] = obj.dThreshold_u213;
                MainWindow.dThreshold3[0, 2, 1, 4] = obj.dThreshold_u214;
                MainWindow.dThreshold3[0, 2, 1, 5] = obj.dThreshold_u215;
                MainWindow.dThreshold3[0, 2, 1, 6] = obj.dThreshold_u216;
                MainWindow.dThreshold3[0, 2, 1, 7] = obj.dThreshold_u217;
                MainWindow.dThreshold3[0, 2, 1, 8] = obj.dThreshold_u218;
                MainWindow.dThreshold3[0, 2, 1, 9] = obj.dThreshold_u219;

                MainWindow.dThreshold3[1, 2, 1, 0] = obj.dThreshold_l210;
                MainWindow.dThreshold3[1, 2, 1, 1] = obj.dThreshold_l211;
                MainWindow.dThreshold3[1, 2, 1, 2] = obj.dThreshold_l212;
                MainWindow.dThreshold3[1, 2, 1, 3] = obj.dThreshold_l213;
                MainWindow.dThreshold3[1, 2, 1, 4] = obj.dThreshold_l214;
                MainWindow.dThreshold3[1, 2, 1, 5] = obj.dThreshold_l215;
                MainWindow.dThreshold3[1, 2, 1, 6] = obj.dThreshold_l216;
                MainWindow.dThreshold3[1, 2, 1, 7] = obj.dThreshold_l217;
                MainWindow.dThreshold3[1, 2, 1, 8] = obj.dThreshold_l218;
                MainWindow.dThreshold3[1, 2, 1, 9] = obj.dThreshold_l219;
                //3-Stream3
                MainWindow.dThreshold3[0, 2, 2, 0] = obj.dThreshold_u220;
                MainWindow.dThreshold3[0, 2, 2, 1] = obj.dThreshold_u221;
                MainWindow.dThreshold3[0, 2, 2, 2] = obj.dThreshold_u222;
                MainWindow.dThreshold3[0, 2, 2, 3] = obj.dThreshold_u223;
                MainWindow.dThreshold3[0, 2, 2, 4] = obj.dThreshold_u224;
                MainWindow.dThreshold3[0, 2, 2, 5] = obj.dThreshold_u225;
                MainWindow.dThreshold3[0, 2, 2, 6] = obj.dThreshold_u226;
                MainWindow.dThreshold3[0, 2, 2, 7] = obj.dThreshold_u227;
                MainWindow.dThreshold3[0, 2, 2, 8] = obj.dThreshold_u228;
                MainWindow.dThreshold3[0, 2, 2, 9] = obj.dThreshold_u229;

                MainWindow.dThreshold3[1, 2, 2, 0] = obj.dThreshold_l220;
                MainWindow.dThreshold3[1, 2, 2, 1] = obj.dThreshold_l221;
                MainWindow.dThreshold3[1, 2, 2, 2] = obj.dThreshold_l222;
                MainWindow.dThreshold3[1, 2, 2, 3] = obj.dThreshold_l223;
                MainWindow.dThreshold3[1, 2, 2, 4] = obj.dThreshold_l224;
                MainWindow.dThreshold3[1, 2, 2, 5] = obj.dThreshold_l225;
                MainWindow.dThreshold3[1, 2, 2, 6] = obj.dThreshold_l226;
                MainWindow.dThreshold3[1, 2, 2, 7] = obj.dThreshold_l227;
                MainWindow.dThreshold3[1, 2, 2, 8] = obj.dThreshold_l228;
                MainWindow.dThreshold3[1, 2, 2, 9] = obj.dThreshold_l229;
                //3-Stream4
                MainWindow.dThreshold3[0, 2, 3, 0] = obj.dThreshold_u230;
                MainWindow.dThreshold3[0, 2, 3, 1] = obj.dThreshold_u231;
                MainWindow.dThreshold3[0, 2, 3, 2] = obj.dThreshold_u232;
                MainWindow.dThreshold3[0, 2, 3, 3] = obj.dThreshold_u233;
                MainWindow.dThreshold3[0, 2, 3, 4] = obj.dThreshold_u234;
                MainWindow.dThreshold3[0, 2, 3, 5] = obj.dThreshold_u235;
                MainWindow.dThreshold3[0, 2, 3, 6] = obj.dThreshold_u236;
                MainWindow.dThreshold3[0, 2, 3, 7] = obj.dThreshold_u237;
                MainWindow.dThreshold3[0, 2, 3, 8] = obj.dThreshold_u238;
                MainWindow.dThreshold3[0, 2, 3, 9] = obj.dThreshold_u239;

                MainWindow.dThreshold3[1, 2, 3, 0] = obj.dThreshold_l230;
                MainWindow.dThreshold3[1, 2, 3, 1] = obj.dThreshold_l231;
                MainWindow.dThreshold3[1, 2, 3, 2] = obj.dThreshold_l232;
                MainWindow.dThreshold3[1, 2, 3, 3] = obj.dThreshold_l233;
                MainWindow.dThreshold3[1, 2, 3, 4] = obj.dThreshold_l234;
                MainWindow.dThreshold3[1, 2, 3, 5] = obj.dThreshold_l235;
                MainWindow.dThreshold3[1, 2, 3, 6] = obj.dThreshold_l236;
                MainWindow.dThreshold3[1, 2, 3, 7] = obj.dThreshold_l237;
                MainWindow.dThreshold3[1, 2, 3, 8] = obj.dThreshold_l238;
                MainWindow.dThreshold3[1, 2, 3, 9] = obj.dThreshold_l239;
                //3-Stream5
                MainWindow.dThreshold3[0, 2, 4, 0] = obj.dThreshold_u240;
                MainWindow.dThreshold3[0, 2, 4, 1] = obj.dThreshold_u241;
                MainWindow.dThreshold3[0, 2, 4, 2] = obj.dThreshold_u242;
                MainWindow.dThreshold3[0, 2, 4, 3] = obj.dThreshold_u243;
                MainWindow.dThreshold3[0, 2, 4, 4] = obj.dThreshold_u244;
                MainWindow.dThreshold3[0, 2, 4, 5] = obj.dThreshold_u245;
                MainWindow.dThreshold3[0, 2, 4, 6] = obj.dThreshold_u246;
                MainWindow.dThreshold3[0, 2, 4, 7] = obj.dThreshold_u247;
                MainWindow.dThreshold3[0, 2, 4, 8] = obj.dThreshold_u248;
                MainWindow.dThreshold3[0, 2, 4, 9] = obj.dThreshold_u249;

                MainWindow.dThreshold3[1, 2, 4, 0] = obj.dThreshold_l240;
                MainWindow.dThreshold3[1, 2, 4, 1] = obj.dThreshold_l241;
                MainWindow.dThreshold3[1, 2, 4, 2] = obj.dThreshold_l242;
                MainWindow.dThreshold3[1, 2, 4, 3] = obj.dThreshold_l243;
                MainWindow.dThreshold3[1, 2, 4, 4] = obj.dThreshold_l244;
                MainWindow.dThreshold3[1, 2, 4, 5] = obj.dThreshold_l245;
                MainWindow.dThreshold3[1, 2, 4, 6] = obj.dThreshold_l246;
                MainWindow.dThreshold3[1, 2, 4, 7] = obj.dThreshold_l247;
                MainWindow.dThreshold3[1, 2, 4, 8] = obj.dThreshold_l248;
                MainWindow.dThreshold3[1, 2, 4, 9] = obj.dThreshold_l249;
                //3-Stream6
                MainWindow.dThreshold3[0, 2, 5, 0] = obj.dThreshold_u250;
                MainWindow.dThreshold3[0, 2, 5, 1] = obj.dThreshold_u251;
                MainWindow.dThreshold3[0, 2, 5, 2] = obj.dThreshold_u252;
                MainWindow.dThreshold3[0, 2, 5, 3] = obj.dThreshold_u253;
                MainWindow.dThreshold3[0, 2, 5, 4] = obj.dThreshold_u254;
                MainWindow.dThreshold3[0, 2, 5, 5] = obj.dThreshold_u255;
                MainWindow.dThreshold3[0, 2, 5, 6] = obj.dThreshold_u256;
                MainWindow.dThreshold3[0, 2, 5, 7] = obj.dThreshold_u257;
                MainWindow.dThreshold3[0, 2, 5, 8] = obj.dThreshold_u258;
                MainWindow.dThreshold3[0, 2, 5, 9] = obj.dThreshold_u259;

                MainWindow.dThreshold3[1, 2, 5, 0] = obj.dThreshold_l250;
                MainWindow.dThreshold3[1, 2, 5, 1] = obj.dThreshold_l251;
                MainWindow.dThreshold3[1, 2, 5, 2] = obj.dThreshold_l252;
                MainWindow.dThreshold3[1, 2, 5, 3] = obj.dThreshold_l253;
                MainWindow.dThreshold3[1, 2, 5, 4] = obj.dThreshold_l254;
                MainWindow.dThreshold3[1, 2, 5, 5] = obj.dThreshold_l255;
                MainWindow.dThreshold3[1, 2, 5, 6] = obj.dThreshold_l256;
                MainWindow.dThreshold3[1, 2, 5, 7] = obj.dThreshold_l257;
                MainWindow.dThreshold3[1, 2, 5, 8] = obj.dThreshold_l258;
                MainWindow.dThreshold3[1, 2, 5, 9] = obj.dThreshold_l259;
                //3-Stream7
                MainWindow.dThreshold3[0, 2, 6, 0] = obj.dThreshold_u260;
                MainWindow.dThreshold3[0, 2, 6, 1] = obj.dThreshold_u261;
                MainWindow.dThreshold3[0, 2, 6, 2] = obj.dThreshold_u262;
                MainWindow.dThreshold3[0, 2, 6, 3] = obj.dThreshold_u263;
                MainWindow.dThreshold3[0, 2, 6, 4] = obj.dThreshold_u264;
                MainWindow.dThreshold3[0, 2, 6, 5] = obj.dThreshold_u265;
                MainWindow.dThreshold3[0, 2, 6, 6] = obj.dThreshold_u266;
                MainWindow.dThreshold3[0, 2, 6, 7] = obj.dThreshold_u267;
                MainWindow.dThreshold3[0, 2, 6, 8] = obj.dThreshold_u268;
                MainWindow.dThreshold3[0, 2, 6, 9] = obj.dThreshold_u269;

                MainWindow.dThreshold3[1, 2, 6, 0] = obj.dThreshold_l260;
                MainWindow.dThreshold3[1, 2, 6, 1] = obj.dThreshold_l261;
                MainWindow.dThreshold3[1, 2, 6, 2] = obj.dThreshold_l262;
                MainWindow.dThreshold3[1, 2, 6, 3] = obj.dThreshold_l263;
                MainWindow.dThreshold3[1, 2, 6, 4] = obj.dThreshold_l264;
                MainWindow.dThreshold3[1, 2, 6, 5] = obj.dThreshold_l265;
                MainWindow.dThreshold3[1, 2, 6, 6] = obj.dThreshold_l266;
                MainWindow.dThreshold3[1, 2, 6, 7] = obj.dThreshold_l267;
                MainWindow.dThreshold3[1, 2, 6, 8] = obj.dThreshold_l268;
                MainWindow.dThreshold3[1, 2, 6, 9] = obj.dThreshold_l269;
                //3-Stream8
                MainWindow.dThreshold3[0, 2, 7, 0] = obj.dThreshold_u270;
                MainWindow.dThreshold3[0, 2, 7, 1] = obj.dThreshold_u271;
                MainWindow.dThreshold3[0, 2, 7, 2] = obj.dThreshold_u272;
                MainWindow.dThreshold3[0, 2, 7, 3] = obj.dThreshold_u273;
                MainWindow.dThreshold3[0, 2, 7, 4] = obj.dThreshold_u274;
                MainWindow.dThreshold3[0, 2, 7, 5] = obj.dThreshold_u275;
                MainWindow.dThreshold3[0, 2, 7, 6] = obj.dThreshold_u276;
                MainWindow.dThreshold3[0, 2, 7, 7] = obj.dThreshold_u277;
                MainWindow.dThreshold3[0, 2, 7, 8] = obj.dThreshold_u278;
                MainWindow.dThreshold3[0, 2, 7, 9] = obj.dThreshold_u279;

                MainWindow.dThreshold3[1, 2, 7, 0] = obj.dThreshold_l270;
                MainWindow.dThreshold3[1, 2, 7, 1] = obj.dThreshold_l271;
                MainWindow.dThreshold3[1, 2, 7, 2] = obj.dThreshold_l272;
                MainWindow.dThreshold3[1, 2, 7, 3] = obj.dThreshold_l273;
                MainWindow.dThreshold3[1, 2, 7, 4] = obj.dThreshold_l274;
                MainWindow.dThreshold3[1, 2, 7, 5] = obj.dThreshold_l275;
                MainWindow.dThreshold3[1, 2, 7, 6] = obj.dThreshold_l276;
                MainWindow.dThreshold3[1, 2, 7, 7] = obj.dThreshold_l277;
                MainWindow.dThreshold3[1, 2, 7, 8] = obj.dThreshold_l278;
                MainWindow.dThreshold3[1, 2, 7, 9] = obj.dThreshold_l279;
                //3-Stream9
                MainWindow.dThreshold3[0, 2, 8, 0] = obj.dThreshold_u280;
                MainWindow.dThreshold3[0, 2, 8, 1] = obj.dThreshold_u281;
                MainWindow.dThreshold3[0, 2, 8, 2] = obj.dThreshold_u282;
                MainWindow.dThreshold3[0, 2, 8, 3] = obj.dThreshold_u283;
                MainWindow.dThreshold3[0, 2, 8, 4] = obj.dThreshold_u284;
                MainWindow.dThreshold3[0, 2, 8, 5] = obj.dThreshold_u285;
                MainWindow.dThreshold3[0, 2, 8, 6] = obj.dThreshold_u286;
                MainWindow.dThreshold3[0, 2, 8, 7] = obj.dThreshold_u287;
                MainWindow.dThreshold3[0, 2, 8, 8] = obj.dThreshold_u288;
                MainWindow.dThreshold3[0, 2, 8, 9] = obj.dThreshold_u289;

                MainWindow.dThreshold3[1, 2, 8, 0] = obj.dThreshold_l280;
                MainWindow.dThreshold3[1, 2, 8, 1] = obj.dThreshold_l281;
                MainWindow.dThreshold3[1, 2, 8, 2] = obj.dThreshold_l282;
                MainWindow.dThreshold3[1, 2, 8, 3] = obj.dThreshold_l283;
                MainWindow.dThreshold3[1, 2, 8, 4] = obj.dThreshold_l284;
                MainWindow.dThreshold3[1, 2, 8, 5] = obj.dThreshold_l285;
                MainWindow.dThreshold3[1, 2, 8, 6] = obj.dThreshold_l286;
                MainWindow.dThreshold3[1, 2, 8, 7] = obj.dThreshold_l287;
                MainWindow.dThreshold3[1, 2, 8, 8] = obj.dThreshold_l288;
                MainWindow.dThreshold3[1, 2, 8, 9] = obj.dThreshold_l289;
                //3-Stream10
                MainWindow.dThreshold3[0, 2, 9, 0] = obj.dThreshold_u290;
                MainWindow.dThreshold3[0, 2, 9, 1] = obj.dThreshold_u291;
                MainWindow.dThreshold3[0, 2, 9, 2] = obj.dThreshold_u292;
                MainWindow.dThreshold3[0, 2, 9, 3] = obj.dThreshold_u293;
                MainWindow.dThreshold3[0, 2, 9, 4] = obj.dThreshold_u294;
                MainWindow.dThreshold3[0, 2, 9, 5] = obj.dThreshold_u295;
                MainWindow.dThreshold3[0, 2, 9, 6] = obj.dThreshold_u296;
                MainWindow.dThreshold3[0, 2, 9, 7] = obj.dThreshold_u297;
                MainWindow.dThreshold3[0, 2, 9, 8] = obj.dThreshold_u298;
                MainWindow.dThreshold3[0, 2, 9, 9] = obj.dThreshold_u299;

                MainWindow.dThreshold3[1, 2, 9, 0] = obj.dThreshold_l290;
                MainWindow.dThreshold3[1, 2, 9, 1] = obj.dThreshold_l291;
                MainWindow.dThreshold3[1, 2, 9, 2] = obj.dThreshold_l292;
                MainWindow.dThreshold3[1, 2, 9, 3] = obj.dThreshold_l293;
                MainWindow.dThreshold3[1, 2, 9, 4] = obj.dThreshold_l294;
                MainWindow.dThreshold3[1, 2, 9, 5] = obj.dThreshold_l295;
                MainWindow.dThreshold3[1, 2, 9, 6] = obj.dThreshold_l296;
                MainWindow.dThreshold3[1, 2, 9, 7] = obj.dThreshold_l297;
                MainWindow.dThreshold3[1, 2, 9, 8] = obj.dThreshold_l298;
                MainWindow.dThreshold3[1, 2, 9, 9] = obj.dThreshold_l299;
                //3-Stream11
                MainWindow.dThreshold3[0, 2, 10, 0] = obj.dThreshold_u2A0;
                MainWindow.dThreshold3[0, 2, 10, 1] = obj.dThreshold_u2A1;
                MainWindow.dThreshold3[0, 2, 10, 2] = obj.dThreshold_u2A2;
                MainWindow.dThreshold3[0, 2, 10, 3] = obj.dThreshold_u2A3;
                MainWindow.dThreshold3[0, 2, 10, 4] = obj.dThreshold_u2A4;
                MainWindow.dThreshold3[0, 2, 10, 5] = obj.dThreshold_u2A5;
                MainWindow.dThreshold3[0, 2, 10, 6] = obj.dThreshold_u2A6;
                MainWindow.dThreshold3[0, 2, 10, 7] = obj.dThreshold_u2A7;
                MainWindow.dThreshold3[0, 2, 10, 8] = obj.dThreshold_u2A8;
                MainWindow.dThreshold3[0, 2, 10, 9] = obj.dThreshold_u2A9;

                MainWindow.dThreshold3[1, 2, 10, 0] = obj.dThreshold_l2A0;
                MainWindow.dThreshold3[1, 2, 10, 1] = obj.dThreshold_l2A1;
                MainWindow.dThreshold3[1, 2, 10, 2] = obj.dThreshold_l2A2;
                MainWindow.dThreshold3[1, 2, 10, 3] = obj.dThreshold_l2A3;
                MainWindow.dThreshold3[1, 2, 10, 4] = obj.dThreshold_l2A4;
                MainWindow.dThreshold3[1, 2, 10, 5] = obj.dThreshold_l2A5;
                MainWindow.dThreshold3[1, 2, 10, 6] = obj.dThreshold_l2A6;
                MainWindow.dThreshold3[1, 2, 10, 7] = obj.dThreshold_l2A7;
                MainWindow.dThreshold3[1, 2, 10, 8] = obj.dThreshold_l2A8;
                MainWindow.dThreshold3[1, 2, 10, 9] = obj.dThreshold_l2A9;

                //品種4
                //4-Stream1
                MainWindow.dThreshold3[0, 3, 0, 0] = obj.dThreshold_u300;
                MainWindow.dThreshold3[0, 3, 0, 1] = obj.dThreshold_u301;
                MainWindow.dThreshold3[0, 3, 0, 2] = obj.dThreshold_u302;
                MainWindow.dThreshold3[0, 3, 0, 3] = obj.dThreshold_u303;
                MainWindow.dThreshold3[0, 3, 0, 4] = obj.dThreshold_u304;
                MainWindow.dThreshold3[0, 3, 0, 5] = obj.dThreshold_u305;
                MainWindow.dThreshold3[0, 3, 0, 6] = obj.dThreshold_u306;
                MainWindow.dThreshold3[0, 3, 0, 7] = obj.dThreshold_u307;
                MainWindow.dThreshold3[0, 3, 0, 8] = obj.dThreshold_u308;
                MainWindow.dThreshold3[0, 3, 0, 9] = obj.dThreshold_u309;

                MainWindow.dThreshold3[1, 3, 0, 0] = obj.dThreshold_l300;
                MainWindow.dThreshold3[1, 3, 0, 1] = obj.dThreshold_l301;
                MainWindow.dThreshold3[1, 3, 0, 2] = obj.dThreshold_l302;
                MainWindow.dThreshold3[1, 3, 0, 3] = obj.dThreshold_l303;
                MainWindow.dThreshold3[1, 3, 0, 4] = obj.dThreshold_l304;
                MainWindow.dThreshold3[1, 3, 0, 5] = obj.dThreshold_l305;
                MainWindow.dThreshold3[1, 3, 0, 6] = obj.dThreshold_l306;
                MainWindow.dThreshold3[1, 3, 0, 7] = obj.dThreshold_l307;
                MainWindow.dThreshold3[1, 3, 0, 8] = obj.dThreshold_l308;
                MainWindow.dThreshold3[1, 3, 0, 9] = obj.dThreshold_l309;
                //4-Stream2
                MainWindow.dThreshold3[0, 3, 1, 0] = obj.dThreshold_u310;
                MainWindow.dThreshold3[0, 3, 1, 1] = obj.dThreshold_u311;
                MainWindow.dThreshold3[0, 3, 1, 2] = obj.dThreshold_u312;
                MainWindow.dThreshold3[0, 3, 1, 3] = obj.dThreshold_u313;
                MainWindow.dThreshold3[0, 3, 1, 4] = obj.dThreshold_u314;
                MainWindow.dThreshold3[0, 3, 1, 5] = obj.dThreshold_u315;
                MainWindow.dThreshold3[0, 3, 1, 6] = obj.dThreshold_u316;
                MainWindow.dThreshold3[0, 3, 1, 7] = obj.dThreshold_u317;
                MainWindow.dThreshold3[0, 3, 1, 8] = obj.dThreshold_u318;
                MainWindow.dThreshold3[0, 3, 1, 9] = obj.dThreshold_u319;

                MainWindow.dThreshold3[1, 3, 1, 0] = obj.dThreshold_l310;
                MainWindow.dThreshold3[1, 3, 1, 1] = obj.dThreshold_l311;
                MainWindow.dThreshold3[1, 3, 1, 2] = obj.dThreshold_l312;
                MainWindow.dThreshold3[1, 3, 1, 3] = obj.dThreshold_l313;
                MainWindow.dThreshold3[1, 3, 1, 4] = obj.dThreshold_l314;
                MainWindow.dThreshold3[1, 3, 1, 5] = obj.dThreshold_l315;
                MainWindow.dThreshold3[1, 3, 1, 6] = obj.dThreshold_l316;
                MainWindow.dThreshold3[1, 3, 1, 7] = obj.dThreshold_l317;
                MainWindow.dThreshold3[1, 3, 1, 8] = obj.dThreshold_l318;
                MainWindow.dThreshold3[1, 3, 1, 9] = obj.dThreshold_l319;
                //4-Stream3
                MainWindow.dThreshold3[0, 3, 2, 0] = obj.dThreshold_u320;
                MainWindow.dThreshold3[0, 3, 2, 1] = obj.dThreshold_u321;
                MainWindow.dThreshold3[0, 3, 2, 2] = obj.dThreshold_u322;
                MainWindow.dThreshold3[0, 3, 2, 3] = obj.dThreshold_u323;
                MainWindow.dThreshold3[0, 3, 2, 4] = obj.dThreshold_u324;
                MainWindow.dThreshold3[0, 3, 2, 5] = obj.dThreshold_u325;
                MainWindow.dThreshold3[0, 3, 2, 6] = obj.dThreshold_u326;
                MainWindow.dThreshold3[0, 3, 2, 7] = obj.dThreshold_u327;
                MainWindow.dThreshold3[0, 3, 2, 8] = obj.dThreshold_u328;
                MainWindow.dThreshold3[0, 3, 2, 9] = obj.dThreshold_u329;

                MainWindow.dThreshold3[1, 3, 2, 0] = obj.dThreshold_l320;
                MainWindow.dThreshold3[1, 3, 2, 1] = obj.dThreshold_l321;
                MainWindow.dThreshold3[1, 3, 2, 2] = obj.dThreshold_l322;
                MainWindow.dThreshold3[1, 3, 2, 3] = obj.dThreshold_l323;
                MainWindow.dThreshold3[1, 3, 2, 4] = obj.dThreshold_l324;
                MainWindow.dThreshold3[1, 3, 2, 5] = obj.dThreshold_l325;
                MainWindow.dThreshold3[1, 3, 2, 6] = obj.dThreshold_l326;
                MainWindow.dThreshold3[1, 3, 2, 7] = obj.dThreshold_l327;
                MainWindow.dThreshold3[1, 3, 2, 8] = obj.dThreshold_l328;
                MainWindow.dThreshold3[1, 3, 2, 9] = obj.dThreshold_l329;
                //4-Stream4
                MainWindow.dThreshold3[0, 3, 3, 0] = obj.dThreshold_u330;
                MainWindow.dThreshold3[0, 3, 3, 1] = obj.dThreshold_u331;
                MainWindow.dThreshold3[0, 3, 3, 2] = obj.dThreshold_u332;
                MainWindow.dThreshold3[0, 3, 3, 3] = obj.dThreshold_u333;
                MainWindow.dThreshold3[0, 3, 3, 4] = obj.dThreshold_u334;
                MainWindow.dThreshold3[0, 3, 3, 5] = obj.dThreshold_u335;
                MainWindow.dThreshold3[0, 3, 3, 6] = obj.dThreshold_u336;
                MainWindow.dThreshold3[0, 3, 3, 7] = obj.dThreshold_u337;
                MainWindow.dThreshold3[0, 3, 3, 8] = obj.dThreshold_u338;
                MainWindow.dThreshold3[0, 3, 3, 9] = obj.dThreshold_u339;

                MainWindow.dThreshold3[1, 3, 3, 0] = obj.dThreshold_l330;
                MainWindow.dThreshold3[1, 3, 3, 1] = obj.dThreshold_l331;
                MainWindow.dThreshold3[1, 3, 3, 2] = obj.dThreshold_l332;
                MainWindow.dThreshold3[1, 3, 3, 3] = obj.dThreshold_l333;
                MainWindow.dThreshold3[1, 3, 3, 4] = obj.dThreshold_l334;
                MainWindow.dThreshold3[1, 3, 3, 5] = obj.dThreshold_l335;
                MainWindow.dThreshold3[1, 3, 3, 6] = obj.dThreshold_l336;
                MainWindow.dThreshold3[1, 3, 3, 7] = obj.dThreshold_l337;
                MainWindow.dThreshold3[1, 3, 3, 8] = obj.dThreshold_l338;
                MainWindow.dThreshold3[1, 3, 3, 9] = obj.dThreshold_l339;
                //4-Stream5
                MainWindow.dThreshold3[0, 3, 4, 0] = obj.dThreshold_u340;
                MainWindow.dThreshold3[0, 3, 4, 1] = obj.dThreshold_u341;
                MainWindow.dThreshold3[0, 3, 4, 2] = obj.dThreshold_u342;
                MainWindow.dThreshold3[0, 3, 4, 3] = obj.dThreshold_u343;
                MainWindow.dThreshold3[0, 3, 4, 4] = obj.dThreshold_u344;
                MainWindow.dThreshold3[0, 3, 4, 5] = obj.dThreshold_u345;
                MainWindow.dThreshold3[0, 3, 4, 6] = obj.dThreshold_u346;
                MainWindow.dThreshold3[0, 3, 4, 7] = obj.dThreshold_u347;
                MainWindow.dThreshold3[0, 3, 4, 8] = obj.dThreshold_u348;
                MainWindow.dThreshold3[0, 3, 4, 9] = obj.dThreshold_u349;

                MainWindow.dThreshold3[1, 3, 4, 0] = obj.dThreshold_l340;
                MainWindow.dThreshold3[1, 3, 4, 1] = obj.dThreshold_l341;
                MainWindow.dThreshold3[1, 3, 4, 2] = obj.dThreshold_l342;
                MainWindow.dThreshold3[1, 3, 4, 3] = obj.dThreshold_l343;
                MainWindow.dThreshold3[1, 3, 4, 4] = obj.dThreshold_l344;
                MainWindow.dThreshold3[1, 3, 4, 5] = obj.dThreshold_l345;
                MainWindow.dThreshold3[1, 3, 4, 6] = obj.dThreshold_l346;
                MainWindow.dThreshold3[1, 3, 4, 7] = obj.dThreshold_l347;
                MainWindow.dThreshold3[1, 3, 4, 8] = obj.dThreshold_l348;
                MainWindow.dThreshold3[1, 3, 4, 9] = obj.dThreshold_l349;
                //4-Stream6
                MainWindow.dThreshold3[0, 3, 5, 0] = obj.dThreshold_u350;
                MainWindow.dThreshold3[0, 3, 5, 1] = obj.dThreshold_u351;
                MainWindow.dThreshold3[0, 3, 5, 2] = obj.dThreshold_u352;
                MainWindow.dThreshold3[0, 3, 5, 3] = obj.dThreshold_u353;
                MainWindow.dThreshold3[0, 3, 5, 4] = obj.dThreshold_u354;
                MainWindow.dThreshold3[0, 3, 5, 5] = obj.dThreshold_u355;
                MainWindow.dThreshold3[0, 3, 5, 6] = obj.dThreshold_u356;
                MainWindow.dThreshold3[0, 3, 5, 7] = obj.dThreshold_u357;
                MainWindow.dThreshold3[0, 3, 5, 8] = obj.dThreshold_u358;
                MainWindow.dThreshold3[0, 3, 5, 9] = obj.dThreshold_u359;

                MainWindow.dThreshold3[1, 3, 5, 0] = obj.dThreshold_l350;
                MainWindow.dThreshold3[1, 3, 5, 1] = obj.dThreshold_l351;
                MainWindow.dThreshold3[1, 3, 5, 2] = obj.dThreshold_l352;
                MainWindow.dThreshold3[1, 3, 5, 3] = obj.dThreshold_l353;
                MainWindow.dThreshold3[1, 3, 5, 4] = obj.dThreshold_l354;
                MainWindow.dThreshold3[1, 3, 5, 5] = obj.dThreshold_l355;
                MainWindow.dThreshold3[1, 3, 5, 6] = obj.dThreshold_l356;
                MainWindow.dThreshold3[1, 3, 5, 7] = obj.dThreshold_l357;
                MainWindow.dThreshold3[1, 3, 5, 8] = obj.dThreshold_l358;
                MainWindow.dThreshold3[1, 3, 5, 9] = obj.dThreshold_l359;
                //4-Stream7
                MainWindow.dThreshold3[0, 3, 6, 0] = obj.dThreshold_u360;
                MainWindow.dThreshold3[0, 3, 6, 1] = obj.dThreshold_u361;
                MainWindow.dThreshold3[0, 3, 6, 2] = obj.dThreshold_u362;
                MainWindow.dThreshold3[0, 3, 6, 3] = obj.dThreshold_u363;
                MainWindow.dThreshold3[0, 3, 6, 4] = obj.dThreshold_u364;
                MainWindow.dThreshold3[0, 3, 6, 5] = obj.dThreshold_u365;
                MainWindow.dThreshold3[0, 3, 6, 6] = obj.dThreshold_u366;
                MainWindow.dThreshold3[0, 3, 6, 7] = obj.dThreshold_u367;
                MainWindow.dThreshold3[0, 3, 6, 8] = obj.dThreshold_u368;
                MainWindow.dThreshold3[0, 3, 6, 9] = obj.dThreshold_u369;

                MainWindow.dThreshold3[1, 3, 6, 0] = obj.dThreshold_l360;
                MainWindow.dThreshold3[1, 3, 6, 1] = obj.dThreshold_l361;
                MainWindow.dThreshold3[1, 3, 6, 2] = obj.dThreshold_l362;
                MainWindow.dThreshold3[1, 3, 6, 3] = obj.dThreshold_l363;
                MainWindow.dThreshold3[1, 3, 6, 4] = obj.dThreshold_l364;
                MainWindow.dThreshold3[1, 3, 6, 5] = obj.dThreshold_l365;
                MainWindow.dThreshold3[1, 3, 6, 6] = obj.dThreshold_l366;
                MainWindow.dThreshold3[1, 3, 6, 7] = obj.dThreshold_l367;
                MainWindow.dThreshold3[1, 3, 6, 8] = obj.dThreshold_l368;
                MainWindow.dThreshold3[1, 3, 6, 9] = obj.dThreshold_l369;
                //4-Stream8
                MainWindow.dThreshold3[0, 3, 7, 0] = obj.dThreshold_u370;
                MainWindow.dThreshold3[0, 3, 7, 1] = obj.dThreshold_u371;
                MainWindow.dThreshold3[0, 3, 7, 2] = obj.dThreshold_u372;
                MainWindow.dThreshold3[0, 3, 7, 3] = obj.dThreshold_u373;
                MainWindow.dThreshold3[0, 3, 7, 4] = obj.dThreshold_u374;
                MainWindow.dThreshold3[0, 3, 7, 5] = obj.dThreshold_u375;
                MainWindow.dThreshold3[0, 3, 7, 6] = obj.dThreshold_u376;
                MainWindow.dThreshold3[0, 3, 7, 7] = obj.dThreshold_u377;
                MainWindow.dThreshold3[0, 3, 7, 8] = obj.dThreshold_u378;
                MainWindow.dThreshold3[0, 3, 7, 9] = obj.dThreshold_u379;

                MainWindow.dThreshold3[1, 3, 7, 0] = obj.dThreshold_l370;
                MainWindow.dThreshold3[1, 3, 7, 1] = obj.dThreshold_l371;
                MainWindow.dThreshold3[1, 3, 7, 2] = obj.dThreshold_l372;
                MainWindow.dThreshold3[1, 3, 7, 3] = obj.dThreshold_l373;
                MainWindow.dThreshold3[1, 3, 7, 4] = obj.dThreshold_l374;
                MainWindow.dThreshold3[1, 3, 7, 5] = obj.dThreshold_l375;
                MainWindow.dThreshold3[1, 3, 7, 6] = obj.dThreshold_l376;
                MainWindow.dThreshold3[1, 3, 7, 7] = obj.dThreshold_l377;
                MainWindow.dThreshold3[1, 3, 7, 8] = obj.dThreshold_l378;
                MainWindow.dThreshold3[1, 3, 7, 9] = obj.dThreshold_l379;
                //4-Stream9
                MainWindow.dThreshold3[0, 3, 8, 0] = obj.dThreshold_u380;
                MainWindow.dThreshold3[0, 3, 8, 1] = obj.dThreshold_u381;
                MainWindow.dThreshold3[0, 3, 8, 2] = obj.dThreshold_u382;
                MainWindow.dThreshold3[0, 3, 8, 3] = obj.dThreshold_u383;
                MainWindow.dThreshold3[0, 3, 8, 4] = obj.dThreshold_u384;
                MainWindow.dThreshold3[0, 3, 8, 5] = obj.dThreshold_u385;
                MainWindow.dThreshold3[0, 3, 8, 6] = obj.dThreshold_u386;
                MainWindow.dThreshold3[0, 3, 8, 7] = obj.dThreshold_u387;
                MainWindow.dThreshold3[0, 3, 8, 8] = obj.dThreshold_u388;
                MainWindow.dThreshold3[0, 3, 8, 9] = obj.dThreshold_u389;

                MainWindow.dThreshold3[1, 3, 8, 0] = obj.dThreshold_l380;
                MainWindow.dThreshold3[1, 3, 8, 1] = obj.dThreshold_l381;
                MainWindow.dThreshold3[1, 3, 8, 2] = obj.dThreshold_l382;
                MainWindow.dThreshold3[1, 3, 8, 3] = obj.dThreshold_l383;
                MainWindow.dThreshold3[1, 3, 8, 4] = obj.dThreshold_l384;
                MainWindow.dThreshold3[1, 3, 8, 5] = obj.dThreshold_l385;
                MainWindow.dThreshold3[1, 3, 8, 6] = obj.dThreshold_l386;
                MainWindow.dThreshold3[1, 3, 8, 7] = obj.dThreshold_l387;
                MainWindow.dThreshold3[1, 3, 8, 8] = obj.dThreshold_l388;
                MainWindow.dThreshold3[1, 3, 8, 9] = obj.dThreshold_l389;
                //4-Stream10
                MainWindow.dThreshold3[0, 3, 9, 0] = obj.dThreshold_u390;
                MainWindow.dThreshold3[0, 3, 9, 1] = obj.dThreshold_u391;
                MainWindow.dThreshold3[0, 3, 9, 2] = obj.dThreshold_u392;
                MainWindow.dThreshold3[0, 3, 9, 3] = obj.dThreshold_u393;
                MainWindow.dThreshold3[0, 3, 9, 4] = obj.dThreshold_u394;
                MainWindow.dThreshold3[0, 3, 9, 5] = obj.dThreshold_u395;
                MainWindow.dThreshold3[0, 3, 9, 6] = obj.dThreshold_u396;
                MainWindow.dThreshold3[0, 3, 9, 7] = obj.dThreshold_u397;
                MainWindow.dThreshold3[0, 3, 9, 8] = obj.dThreshold_u398;
                MainWindow.dThreshold3[0, 3, 9, 9] = obj.dThreshold_u399;

                MainWindow.dThreshold3[1, 3, 9, 0] = obj.dThreshold_l390;
                MainWindow.dThreshold3[1, 3, 9, 1] = obj.dThreshold_l391;
                MainWindow.dThreshold3[1, 3, 9, 2] = obj.dThreshold_l392;
                MainWindow.dThreshold3[1, 3, 9, 3] = obj.dThreshold_l393;
                MainWindow.dThreshold3[1, 3, 9, 4] = obj.dThreshold_l394;
                MainWindow.dThreshold3[1, 3, 9, 5] = obj.dThreshold_l395;
                MainWindow.dThreshold3[1, 3, 9, 6] = obj.dThreshold_l396;
                MainWindow.dThreshold3[1, 3, 9, 7] = obj.dThreshold_l397;
                MainWindow.dThreshold3[1, 3, 9, 8] = obj.dThreshold_l398;
                MainWindow.dThreshold3[1, 3, 9, 9] = obj.dThreshold_l399;
                //4-Stream11
                MainWindow.dThreshold3[0, 3, 10, 0] = obj.dThreshold_u3A0;
                MainWindow.dThreshold3[0, 3, 10, 1] = obj.dThreshold_u3A1;
                MainWindow.dThreshold3[0, 3, 10, 2] = obj.dThreshold_u3A2;
                MainWindow.dThreshold3[0, 3, 10, 3] = obj.dThreshold_u3A3;
                MainWindow.dThreshold3[0, 3, 10, 4] = obj.dThreshold_u3A4;
                MainWindow.dThreshold3[0, 3, 10, 5] = obj.dThreshold_u3A5;
                MainWindow.dThreshold3[0, 3, 10, 6] = obj.dThreshold_u3A6;
                MainWindow.dThreshold3[0, 3, 10, 7] = obj.dThreshold_u3A7;
                MainWindow.dThreshold3[0, 3, 10, 8] = obj.dThreshold_u3A8;
                MainWindow.dThreshold3[0, 3, 10, 9] = obj.dThreshold_u3A9;

                MainWindow.dThreshold3[1, 3, 10, 0] = obj.dThreshold_l3A0;
                MainWindow.dThreshold3[1, 3, 10, 1] = obj.dThreshold_l3A1;
                MainWindow.dThreshold3[1, 3, 10, 2] = obj.dThreshold_l3A2;
                MainWindow.dThreshold3[1, 3, 10, 3] = obj.dThreshold_l3A3;
                MainWindow.dThreshold3[1, 3, 10, 4] = obj.dThreshold_l3A4;
                MainWindow.dThreshold3[1, 3, 10, 5] = obj.dThreshold_l3A5;
                MainWindow.dThreshold3[1, 3, 10, 6] = obj.dThreshold_l3A6;
                MainWindow.dThreshold3[1, 3, 10, 7] = obj.dThreshold_l3A7;
                MainWindow.dThreshold3[1, 3, 10, 8] = obj.dThreshold_l3A8;
                MainWindow.dThreshold3[1, 3, 10, 9] = obj.dThreshold_l3A9;

                //品種5
                //5-Stream1
                MainWindow.dThreshold3[0, 4, 0, 0] = obj.dThreshold_u400;
                MainWindow.dThreshold3[0, 4, 0, 1] = obj.dThreshold_u401;
                MainWindow.dThreshold3[0, 4, 0, 2] = obj.dThreshold_u402;
                MainWindow.dThreshold3[0, 4, 0, 3] = obj.dThreshold_u403;
                MainWindow.dThreshold3[0, 4, 0, 4] = obj.dThreshold_u404;
                MainWindow.dThreshold3[0, 4, 0, 5] = obj.dThreshold_u405;
                MainWindow.dThreshold3[0, 4, 0, 6] = obj.dThreshold_u406;
                MainWindow.dThreshold3[0, 4, 0, 7] = obj.dThreshold_u407;
                MainWindow.dThreshold3[0, 4, 0, 8] = obj.dThreshold_u408;
                MainWindow.dThreshold3[0, 4, 0, 9] = obj.dThreshold_u409;

                MainWindow.dThreshold3[1, 4, 0, 0] = obj.dThreshold_l400;
                MainWindow.dThreshold3[1, 4, 0, 1] = obj.dThreshold_l401;
                MainWindow.dThreshold3[1, 4, 0, 2] = obj.dThreshold_l402;
                MainWindow.dThreshold3[1, 4, 0, 3] = obj.dThreshold_l403;
                MainWindow.dThreshold3[1, 4, 0, 4] = obj.dThreshold_l404;
                MainWindow.dThreshold3[1, 4, 0, 5] = obj.dThreshold_l405;
                MainWindow.dThreshold3[1, 4, 0, 6] = obj.dThreshold_l406;
                MainWindow.dThreshold3[1, 4, 0, 7] = obj.dThreshold_l407;
                MainWindow.dThreshold3[1, 4, 0, 8] = obj.dThreshold_l408;
                MainWindow.dThreshold3[1, 4, 0, 9] = obj.dThreshold_l409;
                //5-Stream2
                MainWindow.dThreshold3[0, 4, 1, 0] = obj.dThreshold_u410;
                MainWindow.dThreshold3[0, 4, 1, 1] = obj.dThreshold_u411;
                MainWindow.dThreshold3[0, 4, 1, 2] = obj.dThreshold_u412;
                MainWindow.dThreshold3[0, 4, 1, 3] = obj.dThreshold_u413;
                MainWindow.dThreshold3[0, 4, 1, 4] = obj.dThreshold_u414;
                MainWindow.dThreshold3[0, 4, 1, 5] = obj.dThreshold_u415;
                MainWindow.dThreshold3[0, 4, 1, 6] = obj.dThreshold_u416;
                MainWindow.dThreshold3[0, 4, 1, 7] = obj.dThreshold_u417;
                MainWindow.dThreshold3[0, 4, 1, 8] = obj.dThreshold_u418;
                MainWindow.dThreshold3[0, 4, 1, 9] = obj.dThreshold_u419;

                MainWindow.dThreshold3[1, 4, 1, 0] = obj.dThreshold_l410;
                MainWindow.dThreshold3[1, 4, 1, 1] = obj.dThreshold_l411;
                MainWindow.dThreshold3[1, 4, 1, 2] = obj.dThreshold_l412;
                MainWindow.dThreshold3[1, 4, 1, 3] = obj.dThreshold_l413;
                MainWindow.dThreshold3[1, 4, 1, 4] = obj.dThreshold_l414;
                MainWindow.dThreshold3[1, 4, 1, 5] = obj.dThreshold_l415;
                MainWindow.dThreshold3[1, 4, 1, 6] = obj.dThreshold_l416;
                MainWindow.dThreshold3[1, 4, 1, 7] = obj.dThreshold_l417;
                MainWindow.dThreshold3[1, 4, 1, 8] = obj.dThreshold_l418;
                MainWindow.dThreshold3[1, 4, 1, 9] = obj.dThreshold_l419;
                //5-Stream3
                MainWindow.dThreshold3[0, 4, 2, 0] = obj.dThreshold_u420;
                MainWindow.dThreshold3[0, 4, 2, 1] = obj.dThreshold_u421;
                MainWindow.dThreshold3[0, 4, 2, 2] = obj.dThreshold_u422;
                MainWindow.dThreshold3[0, 4, 2, 3] = obj.dThreshold_u423;
                MainWindow.dThreshold3[0, 4, 2, 4] = obj.dThreshold_u424;
                MainWindow.dThreshold3[0, 4, 2, 5] = obj.dThreshold_u425;
                MainWindow.dThreshold3[0, 4, 2, 6] = obj.dThreshold_u426;
                MainWindow.dThreshold3[0, 4, 2, 7] = obj.dThreshold_u427;
                MainWindow.dThreshold3[0, 4, 2, 8] = obj.dThreshold_u428;
                MainWindow.dThreshold3[0, 4, 2, 9] = obj.dThreshold_u429;

                MainWindow.dThreshold3[1, 4, 2, 0] = obj.dThreshold_l420;
                MainWindow.dThreshold3[1, 4, 2, 1] = obj.dThreshold_l421;
                MainWindow.dThreshold3[1, 4, 2, 2] = obj.dThreshold_l422;
                MainWindow.dThreshold3[1, 4, 2, 3] = obj.dThreshold_l423;
                MainWindow.dThreshold3[1, 4, 2, 4] = obj.dThreshold_l424;
                MainWindow.dThreshold3[1, 4, 2, 5] = obj.dThreshold_l425;
                MainWindow.dThreshold3[1, 4, 2, 6] = obj.dThreshold_l426;
                MainWindow.dThreshold3[1, 4, 2, 7] = obj.dThreshold_l427;
                MainWindow.dThreshold3[1, 4, 2, 8] = obj.dThreshold_l428;
                MainWindow.dThreshold3[1, 4, 2, 9] = obj.dThreshold_l429;
                //5-Stream4
                MainWindow.dThreshold3[0, 4, 3, 0] = obj.dThreshold_u430;
                MainWindow.dThreshold3[0, 4, 3, 1] = obj.dThreshold_u431;
                MainWindow.dThreshold3[0, 4, 3, 2] = obj.dThreshold_u432;
                MainWindow.dThreshold3[0, 4, 3, 3] = obj.dThreshold_u433;
                MainWindow.dThreshold3[0, 4, 3, 4] = obj.dThreshold_u434;
                MainWindow.dThreshold3[0, 4, 3, 5] = obj.dThreshold_u435;
                MainWindow.dThreshold3[0, 4, 3, 6] = obj.dThreshold_u436;
                MainWindow.dThreshold3[0, 4, 3, 7] = obj.dThreshold_u437;
                MainWindow.dThreshold3[0, 4, 3, 8] = obj.dThreshold_u438;
                MainWindow.dThreshold3[0, 4, 3, 9] = obj.dThreshold_u439;

                MainWindow.dThreshold3[1, 4, 3, 0] = obj.dThreshold_l430;
                MainWindow.dThreshold3[1, 4, 3, 1] = obj.dThreshold_l431;
                MainWindow.dThreshold3[1, 4, 3, 2] = obj.dThreshold_l432;
                MainWindow.dThreshold3[1, 4, 3, 3] = obj.dThreshold_l433;
                MainWindow.dThreshold3[1, 4, 3, 4] = obj.dThreshold_l434;
                MainWindow.dThreshold3[1, 4, 3, 5] = obj.dThreshold_l435;
                MainWindow.dThreshold3[1, 4, 3, 6] = obj.dThreshold_l436;
                MainWindow.dThreshold3[1, 4, 3, 7] = obj.dThreshold_l437;
                MainWindow.dThreshold3[1, 4, 3, 8] = obj.dThreshold_l438;
                MainWindow.dThreshold3[1, 4, 3, 9] = obj.dThreshold_l439;
                //5-Stream5
                MainWindow.dThreshold3[0, 4, 4, 0] = obj.dThreshold_u440;
                MainWindow.dThreshold3[0, 4, 4, 1] = obj.dThreshold_u441;
                MainWindow.dThreshold3[0, 4, 4, 2] = obj.dThreshold_u442;
                MainWindow.dThreshold3[0, 4, 4, 3] = obj.dThreshold_u443;
                MainWindow.dThreshold3[0, 4, 4, 4] = obj.dThreshold_u444;
                MainWindow.dThreshold3[0, 4, 4, 5] = obj.dThreshold_u445;
                MainWindow.dThreshold3[0, 4, 4, 6] = obj.dThreshold_u446;
                MainWindow.dThreshold3[0, 4, 4, 7] = obj.dThreshold_u447;
                MainWindow.dThreshold3[0, 4, 4, 8] = obj.dThreshold_u448;
                MainWindow.dThreshold3[0, 4, 4, 9] = obj.dThreshold_u449;

                MainWindow.dThreshold3[1, 4, 4, 0] = obj.dThreshold_l440;
                MainWindow.dThreshold3[1, 4, 4, 1] = obj.dThreshold_l441;
                MainWindow.dThreshold3[1, 4, 4, 2] = obj.dThreshold_l442;
                MainWindow.dThreshold3[1, 4, 4, 3] = obj.dThreshold_l443;
                MainWindow.dThreshold3[1, 4, 4, 4] = obj.dThreshold_l444;
                MainWindow.dThreshold3[1, 4, 4, 5] = obj.dThreshold_l445;
                MainWindow.dThreshold3[1, 4, 4, 6] = obj.dThreshold_l446;
                MainWindow.dThreshold3[1, 4, 4, 7] = obj.dThreshold_l447;
                MainWindow.dThreshold3[1, 4, 4, 8] = obj.dThreshold_l448;
                MainWindow.dThreshold3[1, 4, 4, 9] = obj.dThreshold_l449;
                //5-Stream6
                MainWindow.dThreshold3[0, 4, 5, 0] = obj.dThreshold_u450;
                MainWindow.dThreshold3[0, 4, 5, 1] = obj.dThreshold_u451;
                MainWindow.dThreshold3[0, 4, 5, 2] = obj.dThreshold_u452;
                MainWindow.dThreshold3[0, 4, 5, 3] = obj.dThreshold_u453;
                MainWindow.dThreshold3[0, 4, 5, 4] = obj.dThreshold_u454;
                MainWindow.dThreshold3[0, 4, 5, 5] = obj.dThreshold_u455;
                MainWindow.dThreshold3[0, 4, 5, 6] = obj.dThreshold_u456;
                MainWindow.dThreshold3[0, 4, 5, 7] = obj.dThreshold_u457;
                MainWindow.dThreshold3[0, 4, 5, 8] = obj.dThreshold_u458;
                MainWindow.dThreshold3[0, 4, 5, 9] = obj.dThreshold_u459;

                MainWindow.dThreshold3[1, 4, 5, 0] = obj.dThreshold_l450;
                MainWindow.dThreshold3[1, 4, 5, 1] = obj.dThreshold_l451;
                MainWindow.dThreshold3[1, 4, 5, 2] = obj.dThreshold_l452;
                MainWindow.dThreshold3[1, 4, 5, 3] = obj.dThreshold_l453;
                MainWindow.dThreshold3[1, 4, 5, 4] = obj.dThreshold_l454;
                MainWindow.dThreshold3[1, 4, 5, 5] = obj.dThreshold_l455;
                MainWindow.dThreshold3[1, 4, 5, 6] = obj.dThreshold_l456;
                MainWindow.dThreshold3[1, 4, 5, 7] = obj.dThreshold_l457;
                MainWindow.dThreshold3[1, 4, 5, 8] = obj.dThreshold_l458;
                MainWindow.dThreshold3[1, 4, 5, 9] = obj.dThreshold_l459;
                //5-Stream7
                MainWindow.dThreshold3[0, 4, 6, 0] = obj.dThreshold_u460;
                MainWindow.dThreshold3[0, 4, 6, 1] = obj.dThreshold_u461;
                MainWindow.dThreshold3[0, 4, 6, 2] = obj.dThreshold_u462;
                MainWindow.dThreshold3[0, 4, 6, 3] = obj.dThreshold_u463;
                MainWindow.dThreshold3[0, 4, 6, 4] = obj.dThreshold_u464;
                MainWindow.dThreshold3[0, 4, 6, 5] = obj.dThreshold_u465;
                MainWindow.dThreshold3[0, 4, 6, 6] = obj.dThreshold_u466;
                MainWindow.dThreshold3[0, 4, 6, 7] = obj.dThreshold_u467;
                MainWindow.dThreshold3[0, 4, 6, 8] = obj.dThreshold_u468;
                MainWindow.dThreshold3[0, 4, 6, 9] = obj.dThreshold_u469;

                MainWindow.dThreshold3[1, 4, 6, 0] = obj.dThreshold_l460;
                MainWindow.dThreshold3[1, 4, 6, 1] = obj.dThreshold_l461;
                MainWindow.dThreshold3[1, 4, 6, 2] = obj.dThreshold_l462;
                MainWindow.dThreshold3[1, 4, 6, 3] = obj.dThreshold_l463;
                MainWindow.dThreshold3[1, 4, 6, 4] = obj.dThreshold_l464;
                MainWindow.dThreshold3[1, 4, 6, 5] = obj.dThreshold_l465;
                MainWindow.dThreshold3[1, 4, 6, 6] = obj.dThreshold_l466;
                MainWindow.dThreshold3[1, 4, 6, 7] = obj.dThreshold_l467;
                MainWindow.dThreshold3[1, 4, 6, 8] = obj.dThreshold_l468;
                MainWindow.dThreshold3[1, 4, 6, 9] = obj.dThreshold_l469;
                //5-Stream8
                MainWindow.dThreshold3[0, 4, 7, 0] = obj.dThreshold_u470;
                MainWindow.dThreshold3[0, 4, 7, 1] = obj.dThreshold_u471;
                MainWindow.dThreshold3[0, 4, 7, 2] = obj.dThreshold_u472;
                MainWindow.dThreshold3[0, 4, 7, 3] = obj.dThreshold_u473;
                MainWindow.dThreshold3[0, 4, 7, 4] = obj.dThreshold_u474;
                MainWindow.dThreshold3[0, 4, 7, 5] = obj.dThreshold_u475;
                MainWindow.dThreshold3[0, 4, 7, 6] = obj.dThreshold_u476;
                MainWindow.dThreshold3[0, 4, 7, 7] = obj.dThreshold_u477;
                MainWindow.dThreshold3[0, 4, 7, 8] = obj.dThreshold_u478;
                MainWindow.dThreshold3[0, 4, 7, 9] = obj.dThreshold_u479;

                MainWindow.dThreshold3[1, 4, 7, 0] = obj.dThreshold_l470;
                MainWindow.dThreshold3[1, 4, 7, 1] = obj.dThreshold_l471;
                MainWindow.dThreshold3[1, 4, 7, 2] = obj.dThreshold_l472;
                MainWindow.dThreshold3[1, 4, 7, 3] = obj.dThreshold_l473;
                MainWindow.dThreshold3[1, 4, 7, 4] = obj.dThreshold_l474;
                MainWindow.dThreshold3[1, 4, 7, 5] = obj.dThreshold_l475;
                MainWindow.dThreshold3[1, 4, 7, 6] = obj.dThreshold_l476;
                MainWindow.dThreshold3[1, 4, 7, 7] = obj.dThreshold_l477;
                MainWindow.dThreshold3[1, 4, 7, 8] = obj.dThreshold_l478;
                MainWindow.dThreshold3[1, 4, 7, 9] = obj.dThreshold_l479;
                //5-Stream9
                MainWindow.dThreshold3[0, 4, 8, 0] = obj.dThreshold_u480;
                MainWindow.dThreshold3[0, 4, 8, 1] = obj.dThreshold_u481;
                MainWindow.dThreshold3[0, 4, 8, 2] = obj.dThreshold_u482;
                MainWindow.dThreshold3[0, 4, 8, 3] = obj.dThreshold_u483;
                MainWindow.dThreshold3[0, 4, 8, 4] = obj.dThreshold_u484;
                MainWindow.dThreshold3[0, 4, 8, 5] = obj.dThreshold_u485;
                MainWindow.dThreshold3[0, 4, 8, 6] = obj.dThreshold_u486;
                MainWindow.dThreshold3[0, 4, 8, 7] = obj.dThreshold_u487;
                MainWindow.dThreshold3[0, 4, 8, 8] = obj.dThreshold_u488;
                MainWindow.dThreshold3[0, 4, 8, 9] = obj.dThreshold_u489;

                MainWindow.dThreshold3[1, 4, 8, 0] = obj.dThreshold_l480;
                MainWindow.dThreshold3[1, 4, 8, 1] = obj.dThreshold_l481;
                MainWindow.dThreshold3[1, 4, 8, 2] = obj.dThreshold_l482;
                MainWindow.dThreshold3[1, 4, 8, 3] = obj.dThreshold_l483;
                MainWindow.dThreshold3[1, 4, 8, 4] = obj.dThreshold_l484;
                MainWindow.dThreshold3[1, 4, 8, 5] = obj.dThreshold_l485;
                MainWindow.dThreshold3[1, 4, 8, 6] = obj.dThreshold_l486;
                MainWindow.dThreshold3[1, 4, 8, 7] = obj.dThreshold_l487;
                MainWindow.dThreshold3[1, 4, 8, 8] = obj.dThreshold_l488;
                MainWindow.dThreshold3[1, 4, 8, 9] = obj.dThreshold_l489;
                //5-Stream10
                MainWindow.dThreshold3[0, 4, 9, 0] = obj.dThreshold_u490;
                MainWindow.dThreshold3[0, 4, 9, 1] = obj.dThreshold_u491;
                MainWindow.dThreshold3[0, 4, 9, 2] = obj.dThreshold_u492;
                MainWindow.dThreshold3[0, 4, 9, 3] = obj.dThreshold_u493;
                MainWindow.dThreshold3[0, 4, 9, 4] = obj.dThreshold_u494;
                MainWindow.dThreshold3[0, 4, 9, 5] = obj.dThreshold_u495;
                MainWindow.dThreshold3[0, 4, 9, 6] = obj.dThreshold_u496;
                MainWindow.dThreshold3[0, 4, 9, 7] = obj.dThreshold_u497;
                MainWindow.dThreshold3[0, 4, 9, 8] = obj.dThreshold_u498;
                MainWindow.dThreshold3[0, 4, 9, 9] = obj.dThreshold_u499;

                MainWindow.dThreshold3[1, 4, 9, 0] = obj.dThreshold_l490;
                MainWindow.dThreshold3[1, 4, 9, 1] = obj.dThreshold_l491;
                MainWindow.dThreshold3[1, 4, 9, 2] = obj.dThreshold_l492;
                MainWindow.dThreshold3[1, 4, 9, 3] = obj.dThreshold_l493;
                MainWindow.dThreshold3[1, 4, 9, 4] = obj.dThreshold_l494;
                MainWindow.dThreshold3[1, 4, 9, 5] = obj.dThreshold_l495;
                MainWindow.dThreshold3[1, 4, 9, 6] = obj.dThreshold_l496;
                MainWindow.dThreshold3[1, 4, 9, 7] = obj.dThreshold_l497;
                MainWindow.dThreshold3[1, 4, 9, 8] = obj.dThreshold_l498;
                MainWindow.dThreshold3[1, 4, 9, 9] = obj.dThreshold_l499;
                //5-Stream11
                MainWindow.dThreshold3[0, 4, 10, 0] = obj.dThreshold_u4A0;
                MainWindow.dThreshold3[0, 4, 10, 1] = obj.dThreshold_u4A1;
                MainWindow.dThreshold3[0, 4, 10, 2] = obj.dThreshold_u4A2;
                MainWindow.dThreshold3[0, 4, 10, 3] = obj.dThreshold_u4A3;
                MainWindow.dThreshold3[0, 4, 10, 4] = obj.dThreshold_u4A4;
                MainWindow.dThreshold3[0, 4, 10, 5] = obj.dThreshold_u4A5;
                MainWindow.dThreshold3[0, 4, 10, 6] = obj.dThreshold_u4A6;
                MainWindow.dThreshold3[0, 4, 10, 7] = obj.dThreshold_u4A7;
                MainWindow.dThreshold3[0, 4, 10, 8] = obj.dThreshold_u4A8;
                MainWindow.dThreshold3[0, 4, 10, 9] = obj.dThreshold_u4A9;

                MainWindow.dThreshold3[1, 4, 10, 0] = obj.dThreshold_l4A0;
                MainWindow.dThreshold3[1, 4, 10, 1] = obj.dThreshold_l4A1;
                MainWindow.dThreshold3[1, 4, 10, 2] = obj.dThreshold_l4A2;
                MainWindow.dThreshold3[1, 4, 10, 3] = obj.dThreshold_l4A3;
                MainWindow.dThreshold3[1, 4, 10, 4] = obj.dThreshold_l4A4;
                MainWindow.dThreshold3[1, 4, 10, 5] = obj.dThreshold_l4A5;
                MainWindow.dThreshold3[1, 4, 10, 6] = obj.dThreshold_l4A6;
                MainWindow.dThreshold3[1, 4, 10, 7] = obj.dThreshold_l4A7;
                MainWindow.dThreshold3[1, 4, 10, 8] = obj.dThreshold_l4A8;
                MainWindow.dThreshold3[1, 4, 10, 9] = obj.dThreshold_l4A9;

                //品種6
                //6-Stream1
                MainWindow.dThreshold3[0, 5, 0, 0] = obj.dThreshold_u500;
                MainWindow.dThreshold3[0, 5, 0, 1] = obj.dThreshold_u501;
                MainWindow.dThreshold3[0, 5, 0, 2] = obj.dThreshold_u502;
                MainWindow.dThreshold3[0, 5, 0, 3] = obj.dThreshold_u503;
                MainWindow.dThreshold3[0, 5, 0, 4] = obj.dThreshold_u504;
                MainWindow.dThreshold3[0, 5, 0, 5] = obj.dThreshold_u505;
                MainWindow.dThreshold3[0, 5, 0, 6] = obj.dThreshold_u506;
                MainWindow.dThreshold3[0, 5, 0, 7] = obj.dThreshold_u507;
                MainWindow.dThreshold3[0, 5, 0, 8] = obj.dThreshold_u508;
                MainWindow.dThreshold3[0, 5, 0, 9] = obj.dThreshold_u509;

                MainWindow.dThreshold3[1, 5, 0, 0] = obj.dThreshold_l500;
                MainWindow.dThreshold3[1, 5, 0, 1] = obj.dThreshold_l501;
                MainWindow.dThreshold3[1, 5, 0, 2] = obj.dThreshold_l502;
                MainWindow.dThreshold3[1, 5, 0, 3] = obj.dThreshold_l503;
                MainWindow.dThreshold3[1, 5, 0, 4] = obj.dThreshold_l504;
                MainWindow.dThreshold3[1, 5, 0, 5] = obj.dThreshold_l505;
                MainWindow.dThreshold3[1, 5, 0, 6] = obj.dThreshold_l506;
                MainWindow.dThreshold3[1, 5, 0, 7] = obj.dThreshold_l507;
                MainWindow.dThreshold3[1, 5, 0, 8] = obj.dThreshold_l508;
                MainWindow.dThreshold3[1, 5, 0, 9] = obj.dThreshold_l509;
                //6-Stream2
                MainWindow.dThreshold3[0, 5, 1, 0] = obj.dThreshold_u510;
                MainWindow.dThreshold3[0, 5, 1, 1] = obj.dThreshold_u511;
                MainWindow.dThreshold3[0, 5, 1, 2] = obj.dThreshold_u512;
                MainWindow.dThreshold3[0, 5, 1, 3] = obj.dThreshold_u513;
                MainWindow.dThreshold3[0, 5, 1, 4] = obj.dThreshold_u514;
                MainWindow.dThreshold3[0, 5, 1, 5] = obj.dThreshold_u515;
                MainWindow.dThreshold3[0, 5, 1, 6] = obj.dThreshold_u516;
                MainWindow.dThreshold3[0, 5, 1, 7] = obj.dThreshold_u517;
                MainWindow.dThreshold3[0, 5, 1, 8] = obj.dThreshold_u518;
                MainWindow.dThreshold3[0, 5, 1, 9] = obj.dThreshold_u519;

                MainWindow.dThreshold3[1, 5, 1, 0] = obj.dThreshold_l510;
                MainWindow.dThreshold3[1, 5, 1, 1] = obj.dThreshold_l511;
                MainWindow.dThreshold3[1, 5, 1, 2] = obj.dThreshold_l512;
                MainWindow.dThreshold3[1, 5, 1, 3] = obj.dThreshold_l513;
                MainWindow.dThreshold3[1, 5, 1, 4] = obj.dThreshold_l514;
                MainWindow.dThreshold3[1, 5, 1, 5] = obj.dThreshold_l515;
                MainWindow.dThreshold3[1, 5, 1, 6] = obj.dThreshold_l516;
                MainWindow.dThreshold3[1, 5, 1, 7] = obj.dThreshold_l517;
                MainWindow.dThreshold3[1, 5, 1, 8] = obj.dThreshold_l518;
                MainWindow.dThreshold3[1, 5, 1, 9] = obj.dThreshold_l519;
                //6-Stream3
                MainWindow.dThreshold3[0, 5, 2, 0] = obj.dThreshold_u520;
                MainWindow.dThreshold3[0, 5, 2, 1] = obj.dThreshold_u521;
                MainWindow.dThreshold3[0, 5, 2, 2] = obj.dThreshold_u522;
                MainWindow.dThreshold3[0, 5, 2, 3] = obj.dThreshold_u523;
                MainWindow.dThreshold3[0, 5, 2, 4] = obj.dThreshold_u524;
                MainWindow.dThreshold3[0, 5, 2, 5] = obj.dThreshold_u525;
                MainWindow.dThreshold3[0, 5, 2, 6] = obj.dThreshold_u526;
                MainWindow.dThreshold3[0, 5, 2, 7] = obj.dThreshold_u527;
                MainWindow.dThreshold3[0, 5, 2, 8] = obj.dThreshold_u528;
                MainWindow.dThreshold3[0, 5, 2, 9] = obj.dThreshold_u529;

                MainWindow.dThreshold3[1, 5, 2, 0] = obj.dThreshold_l520;
                MainWindow.dThreshold3[1, 5, 2, 1] = obj.dThreshold_l521;
                MainWindow.dThreshold3[1, 5, 2, 2] = obj.dThreshold_l522;
                MainWindow.dThreshold3[1, 5, 2, 3] = obj.dThreshold_l523;
                MainWindow.dThreshold3[1, 5, 2, 4] = obj.dThreshold_l524;
                MainWindow.dThreshold3[1, 5, 2, 5] = obj.dThreshold_l525;
                MainWindow.dThreshold3[1, 5, 2, 6] = obj.dThreshold_l526;
                MainWindow.dThreshold3[1, 5, 2, 7] = obj.dThreshold_l527;
                MainWindow.dThreshold3[1, 5, 2, 8] = obj.dThreshold_l528;
                MainWindow.dThreshold3[1, 5, 2, 9] = obj.dThreshold_l529;
                //6-Stream4
                MainWindow.dThreshold3[0, 5, 3, 0] = obj.dThreshold_u530;
                MainWindow.dThreshold3[0, 5, 3, 1] = obj.dThreshold_u531;
                MainWindow.dThreshold3[0, 5, 3, 2] = obj.dThreshold_u532;
                MainWindow.dThreshold3[0, 5, 3, 3] = obj.dThreshold_u533;
                MainWindow.dThreshold3[0, 5, 3, 4] = obj.dThreshold_u534;
                MainWindow.dThreshold3[0, 5, 3, 5] = obj.dThreshold_u535;
                MainWindow.dThreshold3[0, 5, 3, 6] = obj.dThreshold_u536;
                MainWindow.dThreshold3[0, 5, 3, 7] = obj.dThreshold_u537;
                MainWindow.dThreshold3[0, 5, 3, 8] = obj.dThreshold_u538;
                MainWindow.dThreshold3[0, 5, 3, 9] = obj.dThreshold_u539;

                MainWindow.dThreshold3[1, 5, 3, 0] = obj.dThreshold_l530;
                MainWindow.dThreshold3[1, 5, 3, 1] = obj.dThreshold_l531;
                MainWindow.dThreshold3[1, 5, 3, 2] = obj.dThreshold_l532;
                MainWindow.dThreshold3[1, 5, 3, 3] = obj.dThreshold_l533;
                MainWindow.dThreshold3[1, 5, 3, 4] = obj.dThreshold_l534;
                MainWindow.dThreshold3[1, 5, 3, 5] = obj.dThreshold_l535;
                MainWindow.dThreshold3[1, 5, 3, 6] = obj.dThreshold_l536;
                MainWindow.dThreshold3[1, 5, 3, 7] = obj.dThreshold_l537;
                MainWindow.dThreshold3[1, 5, 3, 8] = obj.dThreshold_l538;
                MainWindow.dThreshold3[1, 5, 3, 9] = obj.dThreshold_l539;
                //6-Stream5
                MainWindow.dThreshold3[0, 5, 4, 0] = obj.dThreshold_u540;
                MainWindow.dThreshold3[0, 5, 4, 1] = obj.dThreshold_u541;
                MainWindow.dThreshold3[0, 5, 4, 2] = obj.dThreshold_u542;
                MainWindow.dThreshold3[0, 5, 4, 3] = obj.dThreshold_u543;
                MainWindow.dThreshold3[0, 5, 4, 4] = obj.dThreshold_u544;
                MainWindow.dThreshold3[0, 5, 4, 5] = obj.dThreshold_u545;
                MainWindow.dThreshold3[0, 5, 4, 6] = obj.dThreshold_u546;
                MainWindow.dThreshold3[0, 5, 4, 7] = obj.dThreshold_u547;
                MainWindow.dThreshold3[0, 5, 4, 8] = obj.dThreshold_u548;
                MainWindow.dThreshold3[0, 5, 4, 9] = obj.dThreshold_u549;

                MainWindow.dThreshold3[1, 5, 4, 0] = obj.dThreshold_l540;
                MainWindow.dThreshold3[1, 5, 4, 1] = obj.dThreshold_l541;
                MainWindow.dThreshold3[1, 5, 4, 2] = obj.dThreshold_l542;
                MainWindow.dThreshold3[1, 5, 4, 3] = obj.dThreshold_l543;
                MainWindow.dThreshold3[1, 5, 4, 4] = obj.dThreshold_l544;
                MainWindow.dThreshold3[1, 5, 4, 5] = obj.dThreshold_l545;
                MainWindow.dThreshold3[1, 5, 4, 6] = obj.dThreshold_l546;
                MainWindow.dThreshold3[1, 5, 4, 7] = obj.dThreshold_l547;
                MainWindow.dThreshold3[1, 5, 4, 8] = obj.dThreshold_l548;
                MainWindow.dThreshold3[1, 5, 4, 9] = obj.dThreshold_l549;
                //6-Stream6
                MainWindow.dThreshold3[0, 5, 5, 0] = obj.dThreshold_u550;
                MainWindow.dThreshold3[0, 5, 5, 1] = obj.dThreshold_u551;
                MainWindow.dThreshold3[0, 5, 5, 2] = obj.dThreshold_u552;
                MainWindow.dThreshold3[0, 5, 5, 3] = obj.dThreshold_u553;
                MainWindow.dThreshold3[0, 5, 5, 4] = obj.dThreshold_u554;
                MainWindow.dThreshold3[0, 5, 5, 5] = obj.dThreshold_u555;
                MainWindow.dThreshold3[0, 5, 5, 6] = obj.dThreshold_u556;
                MainWindow.dThreshold3[0, 5, 5, 7] = obj.dThreshold_u557;
                MainWindow.dThreshold3[0, 5, 5, 8] = obj.dThreshold_u558;
                MainWindow.dThreshold3[0, 5, 5, 9] = obj.dThreshold_u559;

                MainWindow.dThreshold3[1, 5, 5, 0] = obj.dThreshold_l550;
                MainWindow.dThreshold3[1, 5, 5, 1] = obj.dThreshold_l551;
                MainWindow.dThreshold3[1, 5, 5, 2] = obj.dThreshold_l552;
                MainWindow.dThreshold3[1, 5, 5, 3] = obj.dThreshold_l553;
                MainWindow.dThreshold3[1, 5, 5, 4] = obj.dThreshold_l554;
                MainWindow.dThreshold3[1, 5, 5, 5] = obj.dThreshold_l555;
                MainWindow.dThreshold3[1, 5, 5, 6] = obj.dThreshold_l556;
                MainWindow.dThreshold3[1, 5, 5, 7] = obj.dThreshold_l557;
                MainWindow.dThreshold3[1, 5, 5, 8] = obj.dThreshold_l558;
                MainWindow.dThreshold3[1, 5, 5, 9] = obj.dThreshold_l559;
                //6-Stream7
                MainWindow.dThreshold3[0, 5, 6, 0] = obj.dThreshold_u560;
                MainWindow.dThreshold3[0, 5, 6, 1] = obj.dThreshold_u561;
                MainWindow.dThreshold3[0, 5, 6, 2] = obj.dThreshold_u562;
                MainWindow.dThreshold3[0, 5, 6, 3] = obj.dThreshold_u563;
                MainWindow.dThreshold3[0, 5, 6, 4] = obj.dThreshold_u564;
                MainWindow.dThreshold3[0, 5, 6, 5] = obj.dThreshold_u565;
                MainWindow.dThreshold3[0, 5, 6, 6] = obj.dThreshold_u566;
                MainWindow.dThreshold3[0, 5, 6, 7] = obj.dThreshold_u567;
                MainWindow.dThreshold3[0, 5, 6, 8] = obj.dThreshold_u568;
                MainWindow.dThreshold3[0, 5, 6, 9] = obj.dThreshold_u569;

                MainWindow.dThreshold3[1, 5, 6, 0] = obj.dThreshold_l560;
                MainWindow.dThreshold3[1, 5, 6, 1] = obj.dThreshold_l561;
                MainWindow.dThreshold3[1, 5, 6, 2] = obj.dThreshold_l562;
                MainWindow.dThreshold3[1, 5, 6, 3] = obj.dThreshold_l563;
                MainWindow.dThreshold3[1, 5, 6, 4] = obj.dThreshold_l564;
                MainWindow.dThreshold3[1, 5, 6, 5] = obj.dThreshold_l565;
                MainWindow.dThreshold3[1, 5, 6, 6] = obj.dThreshold_l566;
                MainWindow.dThreshold3[1, 5, 6, 7] = obj.dThreshold_l567;
                MainWindow.dThreshold3[1, 5, 6, 8] = obj.dThreshold_l568;
                MainWindow.dThreshold3[1, 5, 6, 9] = obj.dThreshold_l569;
                //6-Stream8
                MainWindow.dThreshold3[0, 5, 7, 0] = obj.dThreshold_u570;
                MainWindow.dThreshold3[0, 5, 7, 1] = obj.dThreshold_u571;
                MainWindow.dThreshold3[0, 5, 7, 2] = obj.dThreshold_u572;
                MainWindow.dThreshold3[0, 5, 7, 3] = obj.dThreshold_u573;
                MainWindow.dThreshold3[0, 5, 7, 4] = obj.dThreshold_u574;
                MainWindow.dThreshold3[0, 5, 7, 5] = obj.dThreshold_u575;
                MainWindow.dThreshold3[0, 5, 7, 6] = obj.dThreshold_u576;
                MainWindow.dThreshold3[0, 5, 7, 7] = obj.dThreshold_u577;
                MainWindow.dThreshold3[0, 5, 7, 8] = obj.dThreshold_u578;
                MainWindow.dThreshold3[0, 5, 7, 9] = obj.dThreshold_u579;

                MainWindow.dThreshold3[1, 5, 7, 0] = obj.dThreshold_l570;
                MainWindow.dThreshold3[1, 5, 7, 1] = obj.dThreshold_l571;
                MainWindow.dThreshold3[1, 5, 7, 2] = obj.dThreshold_l572;
                MainWindow.dThreshold3[1, 5, 7, 3] = obj.dThreshold_l573;
                MainWindow.dThreshold3[1, 5, 7, 4] = obj.dThreshold_l574;
                MainWindow.dThreshold3[1, 5, 7, 5] = obj.dThreshold_l575;
                MainWindow.dThreshold3[1, 5, 7, 6] = obj.dThreshold_l576;
                MainWindow.dThreshold3[1, 5, 7, 7] = obj.dThreshold_l577;
                MainWindow.dThreshold3[1, 5, 7, 8] = obj.dThreshold_l578;
                MainWindow.dThreshold3[1, 5, 7, 9] = obj.dThreshold_l579;
                //6-Stream9
                MainWindow.dThreshold3[0, 5, 8, 0] = obj.dThreshold_u580;
                MainWindow.dThreshold3[0, 5, 8, 1] = obj.dThreshold_u581;
                MainWindow.dThreshold3[0, 5, 8, 2] = obj.dThreshold_u582;
                MainWindow.dThreshold3[0, 5, 8, 3] = obj.dThreshold_u583;
                MainWindow.dThreshold3[0, 5, 8, 4] = obj.dThreshold_u584;
                MainWindow.dThreshold3[0, 5, 8, 5] = obj.dThreshold_u585;
                MainWindow.dThreshold3[0, 5, 8, 6] = obj.dThreshold_u586;
                MainWindow.dThreshold3[0, 5, 8, 7] = obj.dThreshold_u587;
                MainWindow.dThreshold3[0, 5, 8, 8] = obj.dThreshold_u588;
                MainWindow.dThreshold3[0, 5, 8, 9] = obj.dThreshold_u589;

                MainWindow.dThreshold3[1, 5, 8, 0] = obj.dThreshold_l580;
                MainWindow.dThreshold3[1, 5, 8, 1] = obj.dThreshold_l581;
                MainWindow.dThreshold3[1, 5, 8, 2] = obj.dThreshold_l582;
                MainWindow.dThreshold3[1, 5, 8, 3] = obj.dThreshold_l583;
                MainWindow.dThreshold3[1, 5, 8, 4] = obj.dThreshold_l584;
                MainWindow.dThreshold3[1, 5, 8, 5] = obj.dThreshold_l585;
                MainWindow.dThreshold3[1, 5, 8, 6] = obj.dThreshold_l586;
                MainWindow.dThreshold3[1, 5, 8, 7] = obj.dThreshold_l587;
                MainWindow.dThreshold3[1, 5, 8, 8] = obj.dThreshold_l588;
                MainWindow.dThreshold3[1, 5, 8, 9] = obj.dThreshold_l589;
                //6-Stream10
                MainWindow.dThreshold3[0, 5, 9, 0] = obj.dThreshold_u590;
                MainWindow.dThreshold3[0, 5, 9, 1] = obj.dThreshold_u591;
                MainWindow.dThreshold3[0, 5, 9, 2] = obj.dThreshold_u592;
                MainWindow.dThreshold3[0, 5, 9, 3] = obj.dThreshold_u593;
                MainWindow.dThreshold3[0, 5, 9, 4] = obj.dThreshold_u594;
                MainWindow.dThreshold3[0, 5, 9, 5] = obj.dThreshold_u595;
                MainWindow.dThreshold3[0, 5, 9, 6] = obj.dThreshold_u596;
                MainWindow.dThreshold3[0, 5, 9, 7] = obj.dThreshold_u597;
                MainWindow.dThreshold3[0, 5, 9, 8] = obj.dThreshold_u598;
                MainWindow.dThreshold3[0, 5, 9, 9] = obj.dThreshold_u599;

                MainWindow.dThreshold3[1, 5, 9, 0] = obj.dThreshold_l590;
                MainWindow.dThreshold3[1, 5, 9, 1] = obj.dThreshold_l591;
                MainWindow.dThreshold3[1, 5, 9, 2] = obj.dThreshold_l592;
                MainWindow.dThreshold3[1, 5, 9, 3] = obj.dThreshold_l593;
                MainWindow.dThreshold3[1, 5, 9, 4] = obj.dThreshold_l594;
                MainWindow.dThreshold3[1, 5, 9, 5] = obj.dThreshold_l595;
                MainWindow.dThreshold3[1, 5, 9, 6] = obj.dThreshold_l596;
                MainWindow.dThreshold3[1, 5, 9, 7] = obj.dThreshold_l597;
                MainWindow.dThreshold3[1, 5, 9, 8] = obj.dThreshold_l598;
                MainWindow.dThreshold3[1, 5, 9, 9] = obj.dThreshold_l599;
                //6-Stream11
                MainWindow.dThreshold3[0, 5, 10, 0] = obj.dThreshold_u5A0;
                MainWindow.dThreshold3[0, 5, 10, 1] = obj.dThreshold_u5A1;
                MainWindow.dThreshold3[0, 5, 10, 2] = obj.dThreshold_u5A2;
                MainWindow.dThreshold3[0, 5, 10, 3] = obj.dThreshold_u5A3;
                MainWindow.dThreshold3[0, 5, 10, 4] = obj.dThreshold_u5A4;
                MainWindow.dThreshold3[0, 5, 10, 5] = obj.dThreshold_u5A5;
                MainWindow.dThreshold3[0, 5, 10, 6] = obj.dThreshold_u5A6;
                MainWindow.dThreshold3[0, 5, 10, 7] = obj.dThreshold_u5A7;
                MainWindow.dThreshold3[0, 5, 10, 8] = obj.dThreshold_u5A8;
                MainWindow.dThreshold3[0, 5, 10, 9] = obj.dThreshold_u5A9;

                MainWindow.dThreshold3[1, 5, 10, 0] = obj.dThreshold_l5A0;
                MainWindow.dThreshold3[1, 5, 10, 1] = obj.dThreshold_l5A1;
                MainWindow.dThreshold3[1, 5, 10, 2] = obj.dThreshold_l5A2;
                MainWindow.dThreshold3[1, 5, 10, 3] = obj.dThreshold_l5A3;
                MainWindow.dThreshold3[1, 5, 10, 4] = obj.dThreshold_l5A4;
                MainWindow.dThreshold3[1, 5, 10, 5] = obj.dThreshold_l5A5;
                MainWindow.dThreshold3[1, 5, 10, 6] = obj.dThreshold_l5A6;
                MainWindow.dThreshold3[1, 5, 10, 7] = obj.dThreshold_l5A7;
                MainWindow.dThreshold3[1, 5, 10, 8] = obj.dThreshold_l5A8;
                MainWindow.dThreshold3[1, 5, 10, 9] = obj.dThreshold_l5A9;

                //品種7
                //7-Stream1
                MainWindow.dThreshold3[0, 6, 0, 0] = obj.dThreshold_u600;
                MainWindow.dThreshold3[0, 6, 0, 1] = obj.dThreshold_u601;
                MainWindow.dThreshold3[0, 6, 0, 2] = obj.dThreshold_u602;
                MainWindow.dThreshold3[0, 6, 0, 3] = obj.dThreshold_u603;
                MainWindow.dThreshold3[0, 6, 0, 4] = obj.dThreshold_u604;
                MainWindow.dThreshold3[0, 6, 0, 5] = obj.dThreshold_u605;
                MainWindow.dThreshold3[0, 6, 0, 6] = obj.dThreshold_u606;
                MainWindow.dThreshold3[0, 6, 0, 7] = obj.dThreshold_u607;
                MainWindow.dThreshold3[0, 6, 0, 8] = obj.dThreshold_u608;
                MainWindow.dThreshold3[0, 6, 0, 9] = obj.dThreshold_u609;

                MainWindow.dThreshold3[1, 6, 0, 0] = obj.dThreshold_l600;
                MainWindow.dThreshold3[1, 6, 0, 1] = obj.dThreshold_l601;
                MainWindow.dThreshold3[1, 6, 0, 2] = obj.dThreshold_l602;
                MainWindow.dThreshold3[1, 6, 0, 3] = obj.dThreshold_l603;
                MainWindow.dThreshold3[1, 6, 0, 4] = obj.dThreshold_l604;
                MainWindow.dThreshold3[1, 6, 0, 5] = obj.dThreshold_l605;
                MainWindow.dThreshold3[1, 6, 0, 6] = obj.dThreshold_l606;
                MainWindow.dThreshold3[1, 6, 0, 7] = obj.dThreshold_l607;
                MainWindow.dThreshold3[1, 6, 0, 8] = obj.dThreshold_l608;
                MainWindow.dThreshold3[1, 6, 0, 9] = obj.dThreshold_l609;
                //7-Stream2
                MainWindow.dThreshold3[0, 6, 1, 0] = obj.dThreshold_u610;
                MainWindow.dThreshold3[0, 6, 1, 1] = obj.dThreshold_u611;
                MainWindow.dThreshold3[0, 6, 1, 2] = obj.dThreshold_u612;
                MainWindow.dThreshold3[0, 6, 1, 3] = obj.dThreshold_u613;
                MainWindow.dThreshold3[0, 6, 1, 4] = obj.dThreshold_u614;
                MainWindow.dThreshold3[0, 6, 1, 5] = obj.dThreshold_u615;
                MainWindow.dThreshold3[0, 6, 1, 6] = obj.dThreshold_u616;
                MainWindow.dThreshold3[0, 6, 1, 7] = obj.dThreshold_u617;
                MainWindow.dThreshold3[0, 6, 1, 8] = obj.dThreshold_u618;
                MainWindow.dThreshold3[0, 6, 1, 9] = obj.dThreshold_u619;

                MainWindow.dThreshold3[1, 6, 1, 0] = obj.dThreshold_l610;
                MainWindow.dThreshold3[1, 6, 1, 1] = obj.dThreshold_l611;
                MainWindow.dThreshold3[1, 6, 1, 2] = obj.dThreshold_l612;
                MainWindow.dThreshold3[1, 6, 1, 3] = obj.dThreshold_l613;
                MainWindow.dThreshold3[1, 6, 1, 4] = obj.dThreshold_l614;
                MainWindow.dThreshold3[1, 6, 1, 5] = obj.dThreshold_l615;
                MainWindow.dThreshold3[1, 6, 1, 6] = obj.dThreshold_l616;
                MainWindow.dThreshold3[1, 6, 1, 7] = obj.dThreshold_l617;
                MainWindow.dThreshold3[1, 6, 1, 8] = obj.dThreshold_l618;
                MainWindow.dThreshold3[1, 6, 1, 9] = obj.dThreshold_l619;
                //7-Stream3
                MainWindow.dThreshold3[0, 6, 2, 0] = obj.dThreshold_u620;
                MainWindow.dThreshold3[0, 6, 2, 1] = obj.dThreshold_u621;
                MainWindow.dThreshold3[0, 6, 2, 2] = obj.dThreshold_u622;
                MainWindow.dThreshold3[0, 6, 2, 3] = obj.dThreshold_u623;
                MainWindow.dThreshold3[0, 6, 2, 4] = obj.dThreshold_u624;
                MainWindow.dThreshold3[0, 6, 2, 5] = obj.dThreshold_u625;
                MainWindow.dThreshold3[0, 6, 2, 6] = obj.dThreshold_u626;
                MainWindow.dThreshold3[0, 6, 2, 7] = obj.dThreshold_u627;
                MainWindow.dThreshold3[0, 6, 2, 8] = obj.dThreshold_u628;
                MainWindow.dThreshold3[0, 6, 2, 9] = obj.dThreshold_u629;

                MainWindow.dThreshold3[1, 6, 2, 0] = obj.dThreshold_l620;
                MainWindow.dThreshold3[1, 6, 2, 1] = obj.dThreshold_l621;
                MainWindow.dThreshold3[1, 6, 2, 2] = obj.dThreshold_l622;
                MainWindow.dThreshold3[1, 6, 2, 3] = obj.dThreshold_l623;
                MainWindow.dThreshold3[1, 6, 2, 4] = obj.dThreshold_l624;
                MainWindow.dThreshold3[1, 6, 2, 5] = obj.dThreshold_l625;
                MainWindow.dThreshold3[1, 6, 2, 6] = obj.dThreshold_l626;
                MainWindow.dThreshold3[1, 6, 2, 7] = obj.dThreshold_l627;
                MainWindow.dThreshold3[1, 6, 2, 8] = obj.dThreshold_l628;
                MainWindow.dThreshold3[1, 6, 2, 9] = obj.dThreshold_l629;
                //7-Stream4
                MainWindow.dThreshold3[0, 6, 3, 0] = obj.dThreshold_u630;
                MainWindow.dThreshold3[0, 6, 3, 1] = obj.dThreshold_u631;
                MainWindow.dThreshold3[0, 6, 3, 2] = obj.dThreshold_u632;
                MainWindow.dThreshold3[0, 6, 3, 3] = obj.dThreshold_u633;
                MainWindow.dThreshold3[0, 6, 3, 4] = obj.dThreshold_u634;
                MainWindow.dThreshold3[0, 6, 3, 5] = obj.dThreshold_u635;
                MainWindow.dThreshold3[0, 6, 3, 6] = obj.dThreshold_u636;
                MainWindow.dThreshold3[0, 6, 3, 7] = obj.dThreshold_u637;
                MainWindow.dThreshold3[0, 6, 3, 8] = obj.dThreshold_u638;
                MainWindow.dThreshold3[0, 6, 3, 9] = obj.dThreshold_u639;

                MainWindow.dThreshold3[1, 6, 3, 0] = obj.dThreshold_l630;
                MainWindow.dThreshold3[1, 6, 3, 1] = obj.dThreshold_l631;
                MainWindow.dThreshold3[1, 6, 3, 2] = obj.dThreshold_l632;
                MainWindow.dThreshold3[1, 6, 3, 3] = obj.dThreshold_l633;
                MainWindow.dThreshold3[1, 6, 3, 4] = obj.dThreshold_l634;
                MainWindow.dThreshold3[1, 6, 3, 5] = obj.dThreshold_l635;
                MainWindow.dThreshold3[1, 6, 3, 6] = obj.dThreshold_l636;
                MainWindow.dThreshold3[1, 6, 3, 7] = obj.dThreshold_l637;
                MainWindow.dThreshold3[1, 6, 3, 8] = obj.dThreshold_l638;
                MainWindow.dThreshold3[1, 6, 3, 9] = obj.dThreshold_l639;
                //7-Stream5
                MainWindow.dThreshold3[0, 6, 4, 0] = obj.dThreshold_u640;
                MainWindow.dThreshold3[0, 6, 4, 1] = obj.dThreshold_u641;
                MainWindow.dThreshold3[0, 6, 4, 2] = obj.dThreshold_u642;
                MainWindow.dThreshold3[0, 6, 4, 3] = obj.dThreshold_u643;
                MainWindow.dThreshold3[0, 6, 4, 4] = obj.dThreshold_u644;
                MainWindow.dThreshold3[0, 6, 4, 5] = obj.dThreshold_u645;
                MainWindow.dThreshold3[0, 6, 4, 6] = obj.dThreshold_u646;
                MainWindow.dThreshold3[0, 6, 4, 7] = obj.dThreshold_u647;
                MainWindow.dThreshold3[0, 6, 4, 8] = obj.dThreshold_u648;
                MainWindow.dThreshold3[0, 6, 4, 9] = obj.dThreshold_u649;

                MainWindow.dThreshold3[1, 6, 4, 0] = obj.dThreshold_l640;
                MainWindow.dThreshold3[1, 6, 4, 1] = obj.dThreshold_l641;
                MainWindow.dThreshold3[1, 6, 4, 2] = obj.dThreshold_l642;
                MainWindow.dThreshold3[1, 6, 4, 3] = obj.dThreshold_l643;
                MainWindow.dThreshold3[1, 6, 4, 4] = obj.dThreshold_l644;
                MainWindow.dThreshold3[1, 6, 4, 5] = obj.dThreshold_l645;
                MainWindow.dThreshold3[1, 6, 4, 6] = obj.dThreshold_l646;
                MainWindow.dThreshold3[1, 6, 4, 7] = obj.dThreshold_l647;
                MainWindow.dThreshold3[1, 6, 4, 8] = obj.dThreshold_l648;
                MainWindow.dThreshold3[1, 6, 4, 9] = obj.dThreshold_l649;
                //7-Stream6
                MainWindow.dThreshold3[0, 6, 5, 0] = obj.dThreshold_u650;
                MainWindow.dThreshold3[0, 6, 5, 1] = obj.dThreshold_u651;
                MainWindow.dThreshold3[0, 6, 5, 2] = obj.dThreshold_u652;
                MainWindow.dThreshold3[0, 6, 5, 3] = obj.dThreshold_u653;
                MainWindow.dThreshold3[0, 6, 5, 4] = obj.dThreshold_u654;
                MainWindow.dThreshold3[0, 6, 5, 5] = obj.dThreshold_u655;
                MainWindow.dThreshold3[0, 6, 5, 6] = obj.dThreshold_u656;
                MainWindow.dThreshold3[0, 6, 5, 7] = obj.dThreshold_u657;
                MainWindow.dThreshold3[0, 6, 5, 8] = obj.dThreshold_u658;
                MainWindow.dThreshold3[0, 6, 5, 9] = obj.dThreshold_u659;

                MainWindow.dThreshold3[1, 6, 5, 0] = obj.dThreshold_l650;
                MainWindow.dThreshold3[1, 6, 5, 1] = obj.dThreshold_l651;
                MainWindow.dThreshold3[1, 6, 5, 2] = obj.dThreshold_l652;
                MainWindow.dThreshold3[1, 6, 5, 3] = obj.dThreshold_l653;
                MainWindow.dThreshold3[1, 6, 5, 4] = obj.dThreshold_l654;
                MainWindow.dThreshold3[1, 6, 5, 5] = obj.dThreshold_l655;
                MainWindow.dThreshold3[1, 6, 5, 6] = obj.dThreshold_l656;
                MainWindow.dThreshold3[1, 6, 5, 7] = obj.dThreshold_l657;
                MainWindow.dThreshold3[1, 6, 5, 8] = obj.dThreshold_l658;
                MainWindow.dThreshold3[1, 6, 5, 9] = obj.dThreshold_l659;
                //7-Stream7
                MainWindow.dThreshold3[0, 6, 6, 0] = obj.dThreshold_u660;
                MainWindow.dThreshold3[0, 6, 6, 1] = obj.dThreshold_u661;
                MainWindow.dThreshold3[0, 6, 6, 2] = obj.dThreshold_u662;
                MainWindow.dThreshold3[0, 6, 6, 3] = obj.dThreshold_u663;
                MainWindow.dThreshold3[0, 6, 6, 4] = obj.dThreshold_u664;
                MainWindow.dThreshold3[0, 6, 6, 5] = obj.dThreshold_u665;
                MainWindow.dThreshold3[0, 6, 6, 6] = obj.dThreshold_u666;
                MainWindow.dThreshold3[0, 6, 6, 7] = obj.dThreshold_u667;
                MainWindow.dThreshold3[0, 6, 6, 8] = obj.dThreshold_u668;
                MainWindow.dThreshold3[0, 6, 6, 9] = obj.dThreshold_u669;

                MainWindow.dThreshold3[1, 6, 6, 0] = obj.dThreshold_l660;
                MainWindow.dThreshold3[1, 6, 6, 1] = obj.dThreshold_l661;
                MainWindow.dThreshold3[1, 6, 6, 2] = obj.dThreshold_l662;
                MainWindow.dThreshold3[1, 6, 6, 3] = obj.dThreshold_l663;
                MainWindow.dThreshold3[1, 6, 6, 4] = obj.dThreshold_l664;
                MainWindow.dThreshold3[1, 6, 6, 5] = obj.dThreshold_l665;
                MainWindow.dThreshold3[1, 6, 6, 6] = obj.dThreshold_l666;
                MainWindow.dThreshold3[1, 6, 6, 7] = obj.dThreshold_l667;
                MainWindow.dThreshold3[1, 6, 6, 8] = obj.dThreshold_l668;
                MainWindow.dThreshold3[1, 6, 6, 9] = obj.dThreshold_l669;
                //7-Stream8
                MainWindow.dThreshold3[0, 6, 7, 0] = obj.dThreshold_u670;
                MainWindow.dThreshold3[0, 6, 7, 1] = obj.dThreshold_u671;
                MainWindow.dThreshold3[0, 6, 7, 2] = obj.dThreshold_u672;
                MainWindow.dThreshold3[0, 6, 7, 3] = obj.dThreshold_u673;
                MainWindow.dThreshold3[0, 6, 7, 4] = obj.dThreshold_u674;
                MainWindow.dThreshold3[0, 6, 7, 5] = obj.dThreshold_u675;
                MainWindow.dThreshold3[0, 6, 7, 6] = obj.dThreshold_u676;
                MainWindow.dThreshold3[0, 6, 7, 7] = obj.dThreshold_u677;
                MainWindow.dThreshold3[0, 6, 7, 8] = obj.dThreshold_u678;
                MainWindow.dThreshold3[0, 6, 7, 9] = obj.dThreshold_u679;

                MainWindow.dThreshold3[1, 6, 7, 0] = obj.dThreshold_l670;
                MainWindow.dThreshold3[1, 6, 7, 1] = obj.dThreshold_l671;
                MainWindow.dThreshold3[1, 6, 7, 2] = obj.dThreshold_l672;
                MainWindow.dThreshold3[1, 6, 7, 3] = obj.dThreshold_l673;
                MainWindow.dThreshold3[1, 6, 7, 4] = obj.dThreshold_l674;
                MainWindow.dThreshold3[1, 6, 7, 5] = obj.dThreshold_l675;
                MainWindow.dThreshold3[1, 6, 7, 6] = obj.dThreshold_l676;
                MainWindow.dThreshold3[1, 6, 7, 7] = obj.dThreshold_l677;
                MainWindow.dThreshold3[1, 6, 7, 8] = obj.dThreshold_l678;
                MainWindow.dThreshold3[1, 6, 7, 9] = obj.dThreshold_l679;
                //7-Stream9
                MainWindow.dThreshold3[0, 6, 8, 0] = obj.dThreshold_u680;
                MainWindow.dThreshold3[0, 6, 8, 1] = obj.dThreshold_u681;
                MainWindow.dThreshold3[0, 6, 8, 2] = obj.dThreshold_u682;
                MainWindow.dThreshold3[0, 6, 8, 3] = obj.dThreshold_u683;
                MainWindow.dThreshold3[0, 6, 8, 4] = obj.dThreshold_u684;
                MainWindow.dThreshold3[0, 6, 8, 5] = obj.dThreshold_u685;
                MainWindow.dThreshold3[0, 6, 8, 6] = obj.dThreshold_u686;
                MainWindow.dThreshold3[0, 6, 8, 7] = obj.dThreshold_u687;
                MainWindow.dThreshold3[0, 6, 8, 8] = obj.dThreshold_u688;
                MainWindow.dThreshold3[0, 6, 8, 9] = obj.dThreshold_u689;

                MainWindow.dThreshold3[1, 6, 8, 0] = obj.dThreshold_l680;
                MainWindow.dThreshold3[1, 6, 8, 1] = obj.dThreshold_l681;
                MainWindow.dThreshold3[1, 6, 8, 2] = obj.dThreshold_l682;
                MainWindow.dThreshold3[1, 6, 8, 3] = obj.dThreshold_l683;
                MainWindow.dThreshold3[1, 6, 8, 4] = obj.dThreshold_l684;
                MainWindow.dThreshold3[1, 6, 8, 5] = obj.dThreshold_l685;
                MainWindow.dThreshold3[1, 6, 8, 6] = obj.dThreshold_l686;
                MainWindow.dThreshold3[1, 6, 8, 7] = obj.dThreshold_l687;
                MainWindow.dThreshold3[1, 6, 8, 8] = obj.dThreshold_l688;
                MainWindow.dThreshold3[1, 6, 8, 9] = obj.dThreshold_l689;
                //7-Stream10
                MainWindow.dThreshold3[0, 6, 9, 0] = obj.dThreshold_u690;
                MainWindow.dThreshold3[0, 6, 9, 1] = obj.dThreshold_u691;
                MainWindow.dThreshold3[0, 6, 9, 2] = obj.dThreshold_u692;
                MainWindow.dThreshold3[0, 6, 9, 3] = obj.dThreshold_u693;
                MainWindow.dThreshold3[0, 6, 9, 4] = obj.dThreshold_u694;
                MainWindow.dThreshold3[0, 6, 9, 5] = obj.dThreshold_u695;
                MainWindow.dThreshold3[0, 6, 9, 6] = obj.dThreshold_u696;
                MainWindow.dThreshold3[0, 6, 9, 7] = obj.dThreshold_u697;
                MainWindow.dThreshold3[0, 6, 9, 8] = obj.dThreshold_u698;
                MainWindow.dThreshold3[0, 6, 9, 9] = obj.dThreshold_u699;

                MainWindow.dThreshold3[1, 6, 9, 0] = obj.dThreshold_l690;
                MainWindow.dThreshold3[1, 6, 9, 1] = obj.dThreshold_l691;
                MainWindow.dThreshold3[1, 6, 9, 2] = obj.dThreshold_l692;
                MainWindow.dThreshold3[1, 6, 9, 3] = obj.dThreshold_l693;
                MainWindow.dThreshold3[1, 6, 9, 4] = obj.dThreshold_l694;
                MainWindow.dThreshold3[1, 6, 9, 5] = obj.dThreshold_l695;
                MainWindow.dThreshold3[1, 6, 9, 6] = obj.dThreshold_l696;
                MainWindow.dThreshold3[1, 6, 9, 7] = obj.dThreshold_l697;
                MainWindow.dThreshold3[1, 6, 9, 8] = obj.dThreshold_l698;
                MainWindow.dThreshold3[1, 6, 9, 9] = obj.dThreshold_l699;
                //7-Stream11
                MainWindow.dThreshold3[0, 6, 10, 0] = obj.dThreshold_u6A0;
                MainWindow.dThreshold3[0, 6, 10, 1] = obj.dThreshold_u6A1;
                MainWindow.dThreshold3[0, 6, 10, 2] = obj.dThreshold_u6A2;
                MainWindow.dThreshold3[0, 6, 10, 3] = obj.dThreshold_u6A3;
                MainWindow.dThreshold3[0, 6, 10, 4] = obj.dThreshold_u6A4;
                MainWindow.dThreshold3[0, 6, 10, 5] = obj.dThreshold_u6A5;
                MainWindow.dThreshold3[0, 6, 10, 6] = obj.dThreshold_u6A6;
                MainWindow.dThreshold3[0, 6, 10, 7] = obj.dThreshold_u6A7;
                MainWindow.dThreshold3[0, 6, 10, 8] = obj.dThreshold_u6A8;
                MainWindow.dThreshold3[0, 6, 10, 9] = obj.dThreshold_u6A9;

                MainWindow.dThreshold3[1, 6, 10, 0] = obj.dThreshold_l6A0;
                MainWindow.dThreshold3[1, 6, 10, 1] = obj.dThreshold_l6A1;
                MainWindow.dThreshold3[1, 6, 10, 2] = obj.dThreshold_l6A2;
                MainWindow.dThreshold3[1, 6, 10, 3] = obj.dThreshold_l6A3;
                MainWindow.dThreshold3[1, 6, 10, 4] = obj.dThreshold_l6A4;
                MainWindow.dThreshold3[1, 6, 10, 5] = obj.dThreshold_l6A5;
                MainWindow.dThreshold3[1, 6, 10, 6] = obj.dThreshold_l6A6;
                MainWindow.dThreshold3[1, 6, 10, 7] = obj.dThreshold_l6A7;
                MainWindow.dThreshold3[1, 6, 10, 8] = obj.dThreshold_l6A8;
                MainWindow.dThreshold3[1, 6, 10, 9] = obj.dThreshold_l6A9;

                //品種8
                //8-Stream1
                MainWindow.dThreshold3[0, 7, 0, 0] = obj.dThreshold_u700;
                MainWindow.dThreshold3[0, 7, 0, 1] = obj.dThreshold_u701;
                MainWindow.dThreshold3[0, 7, 0, 2] = obj.dThreshold_u702;
                MainWindow.dThreshold3[0, 7, 0, 3] = obj.dThreshold_u703;
                MainWindow.dThreshold3[0, 7, 0, 4] = obj.dThreshold_u704;
                MainWindow.dThreshold3[0, 7, 0, 5] = obj.dThreshold_u705;
                MainWindow.dThreshold3[0, 7, 0, 6] = obj.dThreshold_u706;
                MainWindow.dThreshold3[0, 7, 0, 7] = obj.dThreshold_u707;
                MainWindow.dThreshold3[0, 7, 0, 8] = obj.dThreshold_u708;
                MainWindow.dThreshold3[0, 7, 0, 9] = obj.dThreshold_u709;

                MainWindow.dThreshold3[1, 7, 0, 0] = obj.dThreshold_l700;
                MainWindow.dThreshold3[1, 7, 0, 1] = obj.dThreshold_l701;
                MainWindow.dThreshold3[1, 7, 0, 2] = obj.dThreshold_l702;
                MainWindow.dThreshold3[1, 7, 0, 3] = obj.dThreshold_l703;
                MainWindow.dThreshold3[1, 7, 0, 4] = obj.dThreshold_l704;
                MainWindow.dThreshold3[1, 7, 0, 5] = obj.dThreshold_l705;
                MainWindow.dThreshold3[1, 7, 0, 6] = obj.dThreshold_l706;
                MainWindow.dThreshold3[1, 7, 0, 7] = obj.dThreshold_l707;
                MainWindow.dThreshold3[1, 7, 0, 8] = obj.dThreshold_l708;
                MainWindow.dThreshold3[1, 7, 0, 9] = obj.dThreshold_l709;
                //8-Stream2
                MainWindow.dThreshold3[0, 7, 1, 0] = obj.dThreshold_u710;
                MainWindow.dThreshold3[0, 7, 1, 1] = obj.dThreshold_u711;
                MainWindow.dThreshold3[0, 7, 1, 2] = obj.dThreshold_u712;
                MainWindow.dThreshold3[0, 7, 1, 3] = obj.dThreshold_u713;
                MainWindow.dThreshold3[0, 7, 1, 4] = obj.dThreshold_u714;
                MainWindow.dThreshold3[0, 7, 1, 5] = obj.dThreshold_u715;
                MainWindow.dThreshold3[0, 7, 1, 6] = obj.dThreshold_u716;
                MainWindow.dThreshold3[0, 7, 1, 7] = obj.dThreshold_u717;
                MainWindow.dThreshold3[0, 7, 1, 8] = obj.dThreshold_u718;
                MainWindow.dThreshold3[0, 7, 1, 9] = obj.dThreshold_u719;

                MainWindow.dThreshold3[1, 7, 1, 0] = obj.dThreshold_l710;
                MainWindow.dThreshold3[1, 7, 1, 1] = obj.dThreshold_l711;
                MainWindow.dThreshold3[1, 7, 1, 2] = obj.dThreshold_l712;
                MainWindow.dThreshold3[1, 7, 1, 3] = obj.dThreshold_l713;
                MainWindow.dThreshold3[1, 7, 1, 4] = obj.dThreshold_l714;
                MainWindow.dThreshold3[1, 7, 1, 5] = obj.dThreshold_l715;
                MainWindow.dThreshold3[1, 7, 1, 6] = obj.dThreshold_l716;
                MainWindow.dThreshold3[1, 7, 1, 7] = obj.dThreshold_l717;
                MainWindow.dThreshold3[1, 7, 1, 8] = obj.dThreshold_l718;
                MainWindow.dThreshold3[1, 7, 1, 9] = obj.dThreshold_l719;
                //8-Stream3
                MainWindow.dThreshold3[0, 7, 2, 0] = obj.dThreshold_u720;
                MainWindow.dThreshold3[0, 7, 2, 1] = obj.dThreshold_u721;
                MainWindow.dThreshold3[0, 7, 2, 2] = obj.dThreshold_u722;
                MainWindow.dThreshold3[0, 7, 2, 3] = obj.dThreshold_u723;
                MainWindow.dThreshold3[0, 7, 2, 4] = obj.dThreshold_u724;
                MainWindow.dThreshold3[0, 7, 2, 5] = obj.dThreshold_u725;
                MainWindow.dThreshold3[0, 7, 2, 6] = obj.dThreshold_u726;
                MainWindow.dThreshold3[0, 7, 2, 7] = obj.dThreshold_u727;
                MainWindow.dThreshold3[0, 7, 2, 8] = obj.dThreshold_u728;
                MainWindow.dThreshold3[0, 7, 2, 9] = obj.dThreshold_u729;

                MainWindow.dThreshold3[1, 7, 2, 0] = obj.dThreshold_l720;
                MainWindow.dThreshold3[1, 7, 2, 1] = obj.dThreshold_l721;
                MainWindow.dThreshold3[1, 7, 2, 2] = obj.dThreshold_l722;
                MainWindow.dThreshold3[1, 7, 2, 3] = obj.dThreshold_l723;
                MainWindow.dThreshold3[1, 7, 2, 4] = obj.dThreshold_l724;
                MainWindow.dThreshold3[1, 7, 2, 5] = obj.dThreshold_l725;
                MainWindow.dThreshold3[1, 7, 2, 6] = obj.dThreshold_l726;
                MainWindow.dThreshold3[1, 7, 2, 7] = obj.dThreshold_l727;
                MainWindow.dThreshold3[1, 7, 2, 8] = obj.dThreshold_l728;
                MainWindow.dThreshold3[1, 7, 2, 9] = obj.dThreshold_l729;
                //8-Stream4
                MainWindow.dThreshold3[0, 7, 3, 0] = obj.dThreshold_u730;
                MainWindow.dThreshold3[0, 7, 3, 1] = obj.dThreshold_u731;
                MainWindow.dThreshold3[0, 7, 3, 2] = obj.dThreshold_u732;
                MainWindow.dThreshold3[0, 7, 3, 3] = obj.dThreshold_u733;
                MainWindow.dThreshold3[0, 7, 3, 4] = obj.dThreshold_u734;
                MainWindow.dThreshold3[0, 7, 3, 5] = obj.dThreshold_u735;
                MainWindow.dThreshold3[0, 7, 3, 6] = obj.dThreshold_u736;
                MainWindow.dThreshold3[0, 7, 3, 7] = obj.dThreshold_u737;
                MainWindow.dThreshold3[0, 7, 3, 8] = obj.dThreshold_u738;
                MainWindow.dThreshold3[0, 7, 3, 9] = obj.dThreshold_u739;

                MainWindow.dThreshold3[1, 7, 3, 0] = obj.dThreshold_l730;
                MainWindow.dThreshold3[1, 7, 3, 1] = obj.dThreshold_l731;
                MainWindow.dThreshold3[1, 7, 3, 2] = obj.dThreshold_l732;
                MainWindow.dThreshold3[1, 7, 3, 3] = obj.dThreshold_l733;
                MainWindow.dThreshold3[1, 7, 3, 4] = obj.dThreshold_l734;
                MainWindow.dThreshold3[1, 7, 3, 5] = obj.dThreshold_l735;
                MainWindow.dThreshold3[1, 7, 3, 6] = obj.dThreshold_l736;
                MainWindow.dThreshold3[1, 7, 3, 7] = obj.dThreshold_l737;
                MainWindow.dThreshold3[1, 7, 3, 8] = obj.dThreshold_l738;
                MainWindow.dThreshold3[1, 7, 3, 9] = obj.dThreshold_l739;
                //8-Stream5
                MainWindow.dThreshold3[0, 7, 4, 0] = obj.dThreshold_u740;
                MainWindow.dThreshold3[0, 7, 4, 1] = obj.dThreshold_u741;
                MainWindow.dThreshold3[0, 7, 4, 2] = obj.dThreshold_u742;
                MainWindow.dThreshold3[0, 7, 4, 3] = obj.dThreshold_u743;
                MainWindow.dThreshold3[0, 7, 4, 4] = obj.dThreshold_u744;
                MainWindow.dThreshold3[0, 7, 4, 5] = obj.dThreshold_u745;
                MainWindow.dThreshold3[0, 7, 4, 6] = obj.dThreshold_u746;
                MainWindow.dThreshold3[0, 7, 4, 7] = obj.dThreshold_u747;
                MainWindow.dThreshold3[0, 7, 4, 8] = obj.dThreshold_u748;
                MainWindow.dThreshold3[0, 7, 4, 9] = obj.dThreshold_u749;

                MainWindow.dThreshold3[1, 7, 4, 0] = obj.dThreshold_l740;
                MainWindow.dThreshold3[1, 7, 4, 1] = obj.dThreshold_l741;
                MainWindow.dThreshold3[1, 7, 4, 2] = obj.dThreshold_l742;
                MainWindow.dThreshold3[1, 7, 4, 3] = obj.dThreshold_l743;
                MainWindow.dThreshold3[1, 7, 4, 4] = obj.dThreshold_l744;
                MainWindow.dThreshold3[1, 7, 4, 5] = obj.dThreshold_l745;
                MainWindow.dThreshold3[1, 7, 4, 6] = obj.dThreshold_l746;
                MainWindow.dThreshold3[1, 7, 4, 7] = obj.dThreshold_l747;
                MainWindow.dThreshold3[1, 7, 4, 8] = obj.dThreshold_l748;
                MainWindow.dThreshold3[1, 7, 4, 9] = obj.dThreshold_l749;
                //8-Stream6
                MainWindow.dThreshold3[0, 7, 5, 0] = obj.dThreshold_u750;
                MainWindow.dThreshold3[0, 7, 5, 1] = obj.dThreshold_u751;
                MainWindow.dThreshold3[0, 7, 5, 2] = obj.dThreshold_u752;
                MainWindow.dThreshold3[0, 7, 5, 3] = obj.dThreshold_u753;
                MainWindow.dThreshold3[0, 7, 5, 4] = obj.dThreshold_u754;
                MainWindow.dThreshold3[0, 7, 5, 5] = obj.dThreshold_u755;
                MainWindow.dThreshold3[0, 7, 5, 6] = obj.dThreshold_u756;
                MainWindow.dThreshold3[0, 7, 5, 7] = obj.dThreshold_u757;
                MainWindow.dThreshold3[0, 7, 5, 8] = obj.dThreshold_u758;
                MainWindow.dThreshold3[0, 7, 5, 9] = obj.dThreshold_u759;

                MainWindow.dThreshold3[1, 7, 5, 0] = obj.dThreshold_l750;
                MainWindow.dThreshold3[1, 7, 5, 1] = obj.dThreshold_l751;
                MainWindow.dThreshold3[1, 7, 5, 2] = obj.dThreshold_l752;
                MainWindow.dThreshold3[1, 7, 5, 3] = obj.dThreshold_l753;
                MainWindow.dThreshold3[1, 7, 5, 4] = obj.dThreshold_l754;
                MainWindow.dThreshold3[1, 7, 5, 5] = obj.dThreshold_l755;
                MainWindow.dThreshold3[1, 7, 5, 6] = obj.dThreshold_l756;
                MainWindow.dThreshold3[1, 7, 5, 7] = obj.dThreshold_l757;
                MainWindow.dThreshold3[1, 7, 5, 8] = obj.dThreshold_l758;
                MainWindow.dThreshold3[1, 7, 5, 9] = obj.dThreshold_l759;
                //8-Stream7
                MainWindow.dThreshold3[0, 7, 6, 0] = obj.dThreshold_u760;
                MainWindow.dThreshold3[0, 7, 6, 1] = obj.dThreshold_u761;
                MainWindow.dThreshold3[0, 7, 6, 2] = obj.dThreshold_u762;
                MainWindow.dThreshold3[0, 7, 6, 3] = obj.dThreshold_u763;
                MainWindow.dThreshold3[0, 7, 6, 4] = obj.dThreshold_u764;
                MainWindow.dThreshold3[0, 7, 6, 5] = obj.dThreshold_u765;
                MainWindow.dThreshold3[0, 7, 6, 6] = obj.dThreshold_u766;
                MainWindow.dThreshold3[0, 7, 6, 7] = obj.dThreshold_u767;
                MainWindow.dThreshold3[0, 7, 6, 8] = obj.dThreshold_u768;
                MainWindow.dThreshold3[0, 7, 6, 9] = obj.dThreshold_u769;

                MainWindow.dThreshold3[1, 7, 6, 0] = obj.dThreshold_l760;
                MainWindow.dThreshold3[1, 7, 6, 1] = obj.dThreshold_l761;
                MainWindow.dThreshold3[1, 7, 6, 2] = obj.dThreshold_l762;
                MainWindow.dThreshold3[1, 7, 6, 3] = obj.dThreshold_l763;
                MainWindow.dThreshold3[1, 7, 6, 4] = obj.dThreshold_l764;
                MainWindow.dThreshold3[1, 7, 6, 5] = obj.dThreshold_l765;
                MainWindow.dThreshold3[1, 7, 6, 6] = obj.dThreshold_l766;
                MainWindow.dThreshold3[1, 7, 6, 7] = obj.dThreshold_l767;
                MainWindow.dThreshold3[1, 7, 6, 8] = obj.dThreshold_l768;
                MainWindow.dThreshold3[1, 7, 6, 9] = obj.dThreshold_l769;
                //8-Stream8
                MainWindow.dThreshold3[0, 7, 7, 0] = obj.dThreshold_u770;
                MainWindow.dThreshold3[0, 7, 7, 1] = obj.dThreshold_u771;
                MainWindow.dThreshold3[0, 7, 7, 2] = obj.dThreshold_u772;
                MainWindow.dThreshold3[0, 7, 7, 3] = obj.dThreshold_u773;
                MainWindow.dThreshold3[0, 7, 7, 4] = obj.dThreshold_u774;
                MainWindow.dThreshold3[0, 7, 7, 5] = obj.dThreshold_u775;
                MainWindow.dThreshold3[0, 7, 7, 6] = obj.dThreshold_u776;
                MainWindow.dThreshold3[0, 7, 7, 7] = obj.dThreshold_u777;
                MainWindow.dThreshold3[0, 7, 7, 8] = obj.dThreshold_u778;
                MainWindow.dThreshold3[0, 7, 7, 9] = obj.dThreshold_u779;

                MainWindow.dThreshold3[1, 7, 7, 0] = obj.dThreshold_l770;
                MainWindow.dThreshold3[1, 7, 7, 1] = obj.dThreshold_l771;
                MainWindow.dThreshold3[1, 7, 7, 2] = obj.dThreshold_l772;
                MainWindow.dThreshold3[1, 7, 7, 3] = obj.dThreshold_l773;
                MainWindow.dThreshold3[1, 7, 7, 4] = obj.dThreshold_l774;
                MainWindow.dThreshold3[1, 7, 7, 5] = obj.dThreshold_l775;
                MainWindow.dThreshold3[1, 7, 7, 6] = obj.dThreshold_l776;
                MainWindow.dThreshold3[1, 7, 7, 7] = obj.dThreshold_l777;
                MainWindow.dThreshold3[1, 7, 7, 8] = obj.dThreshold_l778;
                MainWindow.dThreshold3[1, 7, 7, 9] = obj.dThreshold_l779;
                //8-Stream9
                MainWindow.dThreshold3[0, 7, 8, 0] = obj.dThreshold_u780;
                MainWindow.dThreshold3[0, 7, 8, 1] = obj.dThreshold_u781;
                MainWindow.dThreshold3[0, 7, 8, 2] = obj.dThreshold_u782;
                MainWindow.dThreshold3[0, 7, 8, 3] = obj.dThreshold_u783;
                MainWindow.dThreshold3[0, 7, 8, 4] = obj.dThreshold_u784;
                MainWindow.dThreshold3[0, 7, 8, 5] = obj.dThreshold_u785;
                MainWindow.dThreshold3[0, 7, 8, 6] = obj.dThreshold_u786;
                MainWindow.dThreshold3[0, 7, 8, 7] = obj.dThreshold_u787;
                MainWindow.dThreshold3[0, 7, 8, 8] = obj.dThreshold_u788;
                MainWindow.dThreshold3[0, 7, 8, 9] = obj.dThreshold_u789;

                MainWindow.dThreshold3[1, 7, 8, 0] = obj.dThreshold_l780;
                MainWindow.dThreshold3[1, 7, 8, 1] = obj.dThreshold_l781;
                MainWindow.dThreshold3[1, 7, 8, 2] = obj.dThreshold_l782;
                MainWindow.dThreshold3[1, 7, 8, 3] = obj.dThreshold_l783;
                MainWindow.dThreshold3[1, 7, 8, 4] = obj.dThreshold_l784;
                MainWindow.dThreshold3[1, 7, 8, 5] = obj.dThreshold_l785;
                MainWindow.dThreshold3[1, 7, 8, 6] = obj.dThreshold_l786;
                MainWindow.dThreshold3[1, 7, 8, 7] = obj.dThreshold_l787;
                MainWindow.dThreshold3[1, 7, 8, 8] = obj.dThreshold_l788;
                MainWindow.dThreshold3[1, 7, 8, 9] = obj.dThreshold_l789;
                //8-Stream10
                MainWindow.dThreshold3[0, 7, 9, 0] = obj.dThreshold_u790;
                MainWindow.dThreshold3[0, 7, 9, 1] = obj.dThreshold_u791;
                MainWindow.dThreshold3[0, 7, 9, 2] = obj.dThreshold_u792;
                MainWindow.dThreshold3[0, 7, 9, 3] = obj.dThreshold_u793;
                MainWindow.dThreshold3[0, 7, 9, 4] = obj.dThreshold_u794;
                MainWindow.dThreshold3[0, 7, 9, 5] = obj.dThreshold_u795;
                MainWindow.dThreshold3[0, 7, 9, 6] = obj.dThreshold_u796;
                MainWindow.dThreshold3[0, 7, 9, 7] = obj.dThreshold_u797;
                MainWindow.dThreshold3[0, 7, 9, 8] = obj.dThreshold_u798;
                MainWindow.dThreshold3[0, 7, 9, 9] = obj.dThreshold_u799;

                MainWindow.dThreshold3[1, 7, 9, 0] = obj.dThreshold_l790;
                MainWindow.dThreshold3[1, 7, 9, 1] = obj.dThreshold_l791;
                MainWindow.dThreshold3[1, 7, 9, 2] = obj.dThreshold_l792;
                MainWindow.dThreshold3[1, 7, 9, 3] = obj.dThreshold_l793;
                MainWindow.dThreshold3[1, 7, 9, 4] = obj.dThreshold_l794;
                MainWindow.dThreshold3[1, 7, 9, 5] = obj.dThreshold_l795;
                MainWindow.dThreshold3[1, 7, 9, 6] = obj.dThreshold_l796;
                MainWindow.dThreshold3[1, 7, 9, 7] = obj.dThreshold_l797;
                MainWindow.dThreshold3[1, 7, 9, 8] = obj.dThreshold_l798;
                MainWindow.dThreshold3[1, 7, 9, 9] = obj.dThreshold_l799;
                //8-Stream11
                MainWindow.dThreshold3[0, 7, 10, 0] = obj.dThreshold_u7A0;
                MainWindow.dThreshold3[0, 7, 10, 1] = obj.dThreshold_u7A1;
                MainWindow.dThreshold3[0, 7, 10, 2] = obj.dThreshold_u7A2;
                MainWindow.dThreshold3[0, 7, 10, 3] = obj.dThreshold_u7A3;
                MainWindow.dThreshold3[0, 7, 10, 4] = obj.dThreshold_u7A4;
                MainWindow.dThreshold3[0, 7, 10, 5] = obj.dThreshold_u7A5;
                MainWindow.dThreshold3[0, 7, 10, 6] = obj.dThreshold_u7A6;
                MainWindow.dThreshold3[0, 7, 10, 7] = obj.dThreshold_u7A7;
                MainWindow.dThreshold3[0, 7, 10, 8] = obj.dThreshold_u7A8;
                MainWindow.dThreshold3[0, 7, 10, 9] = obj.dThreshold_u7A9;

                MainWindow.dThreshold3[1, 7, 10, 0] = obj.dThreshold_l7A0;
                MainWindow.dThreshold3[1, 7, 10, 1] = obj.dThreshold_l7A1;
                MainWindow.dThreshold3[1, 7, 10, 2] = obj.dThreshold_l7A2;
                MainWindow.dThreshold3[1, 7, 10, 3] = obj.dThreshold_l7A3;
                MainWindow.dThreshold3[1, 7, 10, 4] = obj.dThreshold_l7A4;
                MainWindow.dThreshold3[1, 7, 10, 5] = obj.dThreshold_l7A5;
                MainWindow.dThreshold3[1, 7, 10, 6] = obj.dThreshold_l7A6;
                MainWindow.dThreshold3[1, 7, 10, 7] = obj.dThreshold_l7A7;
                MainWindow.dThreshold3[1, 7, 10, 8] = obj.dThreshold_l7A8;
                MainWindow.dThreshold3[1, 7, 10, 9] = obj.dThreshold_l7A9;

                //品種9
                //9-Stream1
                MainWindow.dThreshold3[0, 8, 0, 0] = obj.dThreshold_u800;
                MainWindow.dThreshold3[0, 8, 0, 1] = obj.dThreshold_u801;
                MainWindow.dThreshold3[0, 8, 0, 2] = obj.dThreshold_u802;
                MainWindow.dThreshold3[0, 8, 0, 3] = obj.dThreshold_u803;
                MainWindow.dThreshold3[0, 8, 0, 4] = obj.dThreshold_u804;
                MainWindow.dThreshold3[0, 8, 0, 5] = obj.dThreshold_u805;
                MainWindow.dThreshold3[0, 8, 0, 6] = obj.dThreshold_u806;
                MainWindow.dThreshold3[0, 8, 0, 7] = obj.dThreshold_u807;
                MainWindow.dThreshold3[0, 8, 0, 8] = obj.dThreshold_u808;
                MainWindow.dThreshold3[0, 8, 0, 9] = obj.dThreshold_u809;

                MainWindow.dThreshold3[1, 8, 0, 0] = obj.dThreshold_l800;
                MainWindow.dThreshold3[1, 8, 0, 1] = obj.dThreshold_l801;
                MainWindow.dThreshold3[1, 8, 0, 2] = obj.dThreshold_l802;
                MainWindow.dThreshold3[1, 8, 0, 3] = obj.dThreshold_l803;
                MainWindow.dThreshold3[1, 8, 0, 4] = obj.dThreshold_l804;
                MainWindow.dThreshold3[1, 8, 0, 5] = obj.dThreshold_l805;
                MainWindow.dThreshold3[1, 8, 0, 6] = obj.dThreshold_l806;
                MainWindow.dThreshold3[1, 8, 0, 7] = obj.dThreshold_l807;
                MainWindow.dThreshold3[1, 8, 0, 8] = obj.dThreshold_l808;
                MainWindow.dThreshold3[1, 8, 0, 9] = obj.dThreshold_l809;
                //9-Stream2
                MainWindow.dThreshold3[0, 8, 1, 0] = obj.dThreshold_u810;
                MainWindow.dThreshold3[0, 8, 1, 1] = obj.dThreshold_u811;
                MainWindow.dThreshold3[0, 8, 1, 2] = obj.dThreshold_u812;
                MainWindow.dThreshold3[0, 8, 1, 3] = obj.dThreshold_u813;
                MainWindow.dThreshold3[0, 8, 1, 4] = obj.dThreshold_u814;
                MainWindow.dThreshold3[0, 8, 1, 5] = obj.dThreshold_u815;
                MainWindow.dThreshold3[0, 8, 1, 6] = obj.dThreshold_u816;
                MainWindow.dThreshold3[0, 8, 1, 7] = obj.dThreshold_u817;
                MainWindow.dThreshold3[0, 8, 1, 8] = obj.dThreshold_u818;
                MainWindow.dThreshold3[0, 8, 1, 9] = obj.dThreshold_u819;

                MainWindow.dThreshold3[1, 8, 1, 0] = obj.dThreshold_l810;
                MainWindow.dThreshold3[1, 8, 1, 1] = obj.dThreshold_l811;
                MainWindow.dThreshold3[1, 8, 1, 2] = obj.dThreshold_l812;
                MainWindow.dThreshold3[1, 8, 1, 3] = obj.dThreshold_l813;
                MainWindow.dThreshold3[1, 8, 1, 4] = obj.dThreshold_l814;
                MainWindow.dThreshold3[1, 8, 1, 5] = obj.dThreshold_l815;
                MainWindow.dThreshold3[1, 8, 1, 6] = obj.dThreshold_l816;
                MainWindow.dThreshold3[1, 8, 1, 7] = obj.dThreshold_l817;
                MainWindow.dThreshold3[1, 8, 1, 8] = obj.dThreshold_l818;
                MainWindow.dThreshold3[1, 8, 1, 9] = obj.dThreshold_l819;
                //9-Stream3
                MainWindow.dThreshold3[0, 8, 2, 0] = obj.dThreshold_u820;
                MainWindow.dThreshold3[0, 8, 2, 1] = obj.dThreshold_u821;
                MainWindow.dThreshold3[0, 8, 2, 2] = obj.dThreshold_u822;
                MainWindow.dThreshold3[0, 8, 2, 3] = obj.dThreshold_u823;
                MainWindow.dThreshold3[0, 8, 2, 4] = obj.dThreshold_u824;
                MainWindow.dThreshold3[0, 8, 2, 5] = obj.dThreshold_u825;
                MainWindow.dThreshold3[0, 8, 2, 6] = obj.dThreshold_u826;
                MainWindow.dThreshold3[0, 8, 2, 7] = obj.dThreshold_u827;
                MainWindow.dThreshold3[0, 8, 2, 8] = obj.dThreshold_u828;
                MainWindow.dThreshold3[0, 8, 2, 9] = obj.dThreshold_u829;

                MainWindow.dThreshold3[1, 8, 2, 0] = obj.dThreshold_l820;
                MainWindow.dThreshold3[1, 8, 2, 1] = obj.dThreshold_l821;
                MainWindow.dThreshold3[1, 8, 2, 2] = obj.dThreshold_l822;
                MainWindow.dThreshold3[1, 8, 2, 3] = obj.dThreshold_l823;
                MainWindow.dThreshold3[1, 8, 2, 4] = obj.dThreshold_l824;
                MainWindow.dThreshold3[1, 8, 2, 5] = obj.dThreshold_l825;
                MainWindow.dThreshold3[1, 8, 2, 6] = obj.dThreshold_l826;
                MainWindow.dThreshold3[1, 8, 2, 7] = obj.dThreshold_l827;
                MainWindow.dThreshold3[1, 8, 2, 8] = obj.dThreshold_l828;
                MainWindow.dThreshold3[1, 8, 2, 9] = obj.dThreshold_l829;
                //9-Stream4
                MainWindow.dThreshold3[0, 8, 3, 0] = obj.dThreshold_u830;
                MainWindow.dThreshold3[0, 8, 3, 1] = obj.dThreshold_u831;
                MainWindow.dThreshold3[0, 8, 3, 2] = obj.dThreshold_u832;
                MainWindow.dThreshold3[0, 8, 3, 3] = obj.dThreshold_u833;
                MainWindow.dThreshold3[0, 8, 3, 4] = obj.dThreshold_u834;
                MainWindow.dThreshold3[0, 8, 3, 5] = obj.dThreshold_u835;
                MainWindow.dThreshold3[0, 8, 3, 6] = obj.dThreshold_u836;
                MainWindow.dThreshold3[0, 8, 3, 7] = obj.dThreshold_u837;
                MainWindow.dThreshold3[0, 8, 3, 8] = obj.dThreshold_u838;
                MainWindow.dThreshold3[0, 8, 3, 9] = obj.dThreshold_u839;

                MainWindow.dThreshold3[1, 8, 3, 0] = obj.dThreshold_l830;
                MainWindow.dThreshold3[1, 8, 3, 1] = obj.dThreshold_l831;
                MainWindow.dThreshold3[1, 8, 3, 2] = obj.dThreshold_l832;
                MainWindow.dThreshold3[1, 8, 3, 3] = obj.dThreshold_l833;
                MainWindow.dThreshold3[1, 8, 3, 4] = obj.dThreshold_l834;
                MainWindow.dThreshold3[1, 8, 3, 5] = obj.dThreshold_l835;
                MainWindow.dThreshold3[1, 8, 3, 6] = obj.dThreshold_l836;
                MainWindow.dThreshold3[1, 8, 3, 7] = obj.dThreshold_l837;
                MainWindow.dThreshold3[1, 8, 3, 8] = obj.dThreshold_l838;
                MainWindow.dThreshold3[1, 8, 3, 9] = obj.dThreshold_l839;
                //9-Stream5
                MainWindow.dThreshold3[0, 8, 4, 0] = obj.dThreshold_u840;
                MainWindow.dThreshold3[0, 8, 4, 1] = obj.dThreshold_u841;
                MainWindow.dThreshold3[0, 8, 4, 2] = obj.dThreshold_u842;
                MainWindow.dThreshold3[0, 8, 4, 3] = obj.dThreshold_u843;
                MainWindow.dThreshold3[0, 8, 4, 4] = obj.dThreshold_u844;
                MainWindow.dThreshold3[0, 8, 4, 5] = obj.dThreshold_u845;
                MainWindow.dThreshold3[0, 8, 4, 6] = obj.dThreshold_u846;
                MainWindow.dThreshold3[0, 8, 4, 7] = obj.dThreshold_u847;
                MainWindow.dThreshold3[0, 8, 4, 8] = obj.dThreshold_u848;
                MainWindow.dThreshold3[0, 8, 4, 9] = obj.dThreshold_u849;

                MainWindow.dThreshold3[1, 8, 4, 0] = obj.dThreshold_l840;
                MainWindow.dThreshold3[1, 8, 4, 1] = obj.dThreshold_l841;
                MainWindow.dThreshold3[1, 8, 4, 2] = obj.dThreshold_l842;
                MainWindow.dThreshold3[1, 8, 4, 3] = obj.dThreshold_l843;
                MainWindow.dThreshold3[1, 8, 4, 4] = obj.dThreshold_l844;
                MainWindow.dThreshold3[1, 8, 4, 5] = obj.dThreshold_l845;
                MainWindow.dThreshold3[1, 8, 4, 6] = obj.dThreshold_l846;
                MainWindow.dThreshold3[1, 8, 4, 7] = obj.dThreshold_l847;
                MainWindow.dThreshold3[1, 8, 4, 8] = obj.dThreshold_l848;
                MainWindow.dThreshold3[1, 8, 4, 9] = obj.dThreshold_l849;
                //9-Stream6
                MainWindow.dThreshold3[0, 8, 5, 0] = obj.dThreshold_u850;
                MainWindow.dThreshold3[0, 8, 5, 1] = obj.dThreshold_u851;
                MainWindow.dThreshold3[0, 8, 5, 2] = obj.dThreshold_u852;
                MainWindow.dThreshold3[0, 8, 5, 3] = obj.dThreshold_u853;
                MainWindow.dThreshold3[0, 8, 5, 4] = obj.dThreshold_u854;
                MainWindow.dThreshold3[0, 8, 5, 5] = obj.dThreshold_u855;
                MainWindow.dThreshold3[0, 8, 5, 6] = obj.dThreshold_u856;
                MainWindow.dThreshold3[0, 8, 5, 7] = obj.dThreshold_u857;
                MainWindow.dThreshold3[0, 8, 5, 8] = obj.dThreshold_u858;
                MainWindow.dThreshold3[0, 8, 5, 9] = obj.dThreshold_u859;

                MainWindow.dThreshold3[1, 8, 5, 0] = obj.dThreshold_l850;
                MainWindow.dThreshold3[1, 8, 5, 1] = obj.dThreshold_l851;
                MainWindow.dThreshold3[1, 8, 5, 2] = obj.dThreshold_l852;
                MainWindow.dThreshold3[1, 8, 5, 3] = obj.dThreshold_l853;
                MainWindow.dThreshold3[1, 8, 5, 4] = obj.dThreshold_l854;
                MainWindow.dThreshold3[1, 8, 5, 5] = obj.dThreshold_l855;
                MainWindow.dThreshold3[1, 8, 5, 6] = obj.dThreshold_l856;
                MainWindow.dThreshold3[1, 8, 5, 7] = obj.dThreshold_l857;
                MainWindow.dThreshold3[1, 8, 5, 8] = obj.dThreshold_l858;
                MainWindow.dThreshold3[1, 8, 5, 9] = obj.dThreshold_l859;
                //9-Stream7
                MainWindow.dThreshold3[0, 8, 6, 0] = obj.dThreshold_u860;
                MainWindow.dThreshold3[0, 8, 6, 1] = obj.dThreshold_u861;
                MainWindow.dThreshold3[0, 8, 6, 2] = obj.dThreshold_u862;
                MainWindow.dThreshold3[0, 8, 6, 3] = obj.dThreshold_u863;
                MainWindow.dThreshold3[0, 8, 6, 4] = obj.dThreshold_u864;
                MainWindow.dThreshold3[0, 8, 6, 5] = obj.dThreshold_u865;
                MainWindow.dThreshold3[0, 8, 6, 6] = obj.dThreshold_u866;
                MainWindow.dThreshold3[0, 8, 6, 7] = obj.dThreshold_u867;
                MainWindow.dThreshold3[0, 8, 6, 8] = obj.dThreshold_u868;
                MainWindow.dThreshold3[0, 8, 6, 9] = obj.dThreshold_u869;

                MainWindow.dThreshold3[1, 8, 6, 0] = obj.dThreshold_l860;
                MainWindow.dThreshold3[1, 8, 6, 1] = obj.dThreshold_l861;
                MainWindow.dThreshold3[1, 8, 6, 2] = obj.dThreshold_l862;
                MainWindow.dThreshold3[1, 8, 6, 3] = obj.dThreshold_l863;
                MainWindow.dThreshold3[1, 8, 6, 4] = obj.dThreshold_l864;
                MainWindow.dThreshold3[1, 8, 6, 5] = obj.dThreshold_l865;
                MainWindow.dThreshold3[1, 8, 6, 6] = obj.dThreshold_l866;
                MainWindow.dThreshold3[1, 8, 6, 7] = obj.dThreshold_l867;
                MainWindow.dThreshold3[1, 8, 6, 8] = obj.dThreshold_l868;
                MainWindow.dThreshold3[1, 8, 6, 9] = obj.dThreshold_l869;
                //9-Stream8
                MainWindow.dThreshold3[0, 8, 7, 0] = obj.dThreshold_u870;
                MainWindow.dThreshold3[0, 8, 7, 1] = obj.dThreshold_u871;
                MainWindow.dThreshold3[0, 8, 7, 2] = obj.dThreshold_u872;
                MainWindow.dThreshold3[0, 8, 7, 3] = obj.dThreshold_u873;
                MainWindow.dThreshold3[0, 8, 7, 4] = obj.dThreshold_u874;
                MainWindow.dThreshold3[0, 8, 7, 5] = obj.dThreshold_u875;
                MainWindow.dThreshold3[0, 8, 7, 6] = obj.dThreshold_u876;
                MainWindow.dThreshold3[0, 8, 7, 7] = obj.dThreshold_u877;
                MainWindow.dThreshold3[0, 8, 7, 8] = obj.dThreshold_u878;
                MainWindow.dThreshold3[0, 8, 7, 9] = obj.dThreshold_u879;

                MainWindow.dThreshold3[1, 8, 7, 0] = obj.dThreshold_l870;
                MainWindow.dThreshold3[1, 8, 7, 1] = obj.dThreshold_l871;
                MainWindow.dThreshold3[1, 8, 7, 2] = obj.dThreshold_l872;
                MainWindow.dThreshold3[1, 8, 7, 3] = obj.dThreshold_l873;
                MainWindow.dThreshold3[1, 8, 7, 4] = obj.dThreshold_l874;
                MainWindow.dThreshold3[1, 8, 7, 5] = obj.dThreshold_l875;
                MainWindow.dThreshold3[1, 8, 7, 6] = obj.dThreshold_l876;
                MainWindow.dThreshold3[1, 8, 7, 7] = obj.dThreshold_l877;
                MainWindow.dThreshold3[1, 8, 7, 8] = obj.dThreshold_l878;
                MainWindow.dThreshold3[1, 8, 7, 9] = obj.dThreshold_l879;
                //9-Stream9
                MainWindow.dThreshold3[0, 8, 8, 0] = obj.dThreshold_u880;
                MainWindow.dThreshold3[0, 8, 8, 1] = obj.dThreshold_u881;
                MainWindow.dThreshold3[0, 8, 8, 2] = obj.dThreshold_u882;
                MainWindow.dThreshold3[0, 8, 8, 3] = obj.dThreshold_u883;
                MainWindow.dThreshold3[0, 8, 8, 4] = obj.dThreshold_u884;
                MainWindow.dThreshold3[0, 8, 8, 5] = obj.dThreshold_u885;
                MainWindow.dThreshold3[0, 8, 8, 6] = obj.dThreshold_u886;
                MainWindow.dThreshold3[0, 8, 8, 7] = obj.dThreshold_u887;
                MainWindow.dThreshold3[0, 8, 8, 8] = obj.dThreshold_u888;
                MainWindow.dThreshold3[0, 8, 8, 9] = obj.dThreshold_u889;

                MainWindow.dThreshold3[1, 8, 8, 0] = obj.dThreshold_l880;
                MainWindow.dThreshold3[1, 8, 8, 1] = obj.dThreshold_l881;
                MainWindow.dThreshold3[1, 8, 8, 2] = obj.dThreshold_l882;
                MainWindow.dThreshold3[1, 8, 8, 3] = obj.dThreshold_l883;
                MainWindow.dThreshold3[1, 8, 8, 4] = obj.dThreshold_l884;
                MainWindow.dThreshold3[1, 8, 8, 5] = obj.dThreshold_l885;
                MainWindow.dThreshold3[1, 8, 8, 6] = obj.dThreshold_l886;
                MainWindow.dThreshold3[1, 8, 8, 7] = obj.dThreshold_l887;
                MainWindow.dThreshold3[1, 8, 8, 8] = obj.dThreshold_l888;
                MainWindow.dThreshold3[1, 8, 8, 9] = obj.dThreshold_l889;
                //9-Stream10
                MainWindow.dThreshold3[0, 8, 9, 0] = obj.dThreshold_u890;
                MainWindow.dThreshold3[0, 8, 9, 1] = obj.dThreshold_u891;
                MainWindow.dThreshold3[0, 8, 9, 2] = obj.dThreshold_u892;
                MainWindow.dThreshold3[0, 8, 9, 3] = obj.dThreshold_u893;
                MainWindow.dThreshold3[0, 8, 9, 4] = obj.dThreshold_u894;
                MainWindow.dThreshold3[0, 8, 9, 5] = obj.dThreshold_u895;
                MainWindow.dThreshold3[0, 8, 9, 6] = obj.dThreshold_u896;
                MainWindow.dThreshold3[0, 8, 9, 7] = obj.dThreshold_u897;
                MainWindow.dThreshold3[0, 8, 9, 8] = obj.dThreshold_u898;
                MainWindow.dThreshold3[0, 8, 9, 9] = obj.dThreshold_u899;

                MainWindow.dThreshold3[1, 8, 9, 0] = obj.dThreshold_l890;
                MainWindow.dThreshold3[1, 8, 9, 1] = obj.dThreshold_l891;
                MainWindow.dThreshold3[1, 8, 9, 2] = obj.dThreshold_l892;
                MainWindow.dThreshold3[1, 8, 9, 3] = obj.dThreshold_l893;
                MainWindow.dThreshold3[1, 8, 9, 4] = obj.dThreshold_l894;
                MainWindow.dThreshold3[1, 8, 9, 5] = obj.dThreshold_l895;
                MainWindow.dThreshold3[1, 8, 9, 6] = obj.dThreshold_l896;
                MainWindow.dThreshold3[1, 8, 9, 7] = obj.dThreshold_l897;
                MainWindow.dThreshold3[1, 8, 9, 8] = obj.dThreshold_l898;
                MainWindow.dThreshold3[1, 8, 9, 9] = obj.dThreshold_l899;
                //9-Stream11
                MainWindow.dThreshold3[0, 8, 10, 0] = obj.dThreshold_u8A0;
                MainWindow.dThreshold3[0, 8, 10, 1] = obj.dThreshold_u8A1;
                MainWindow.dThreshold3[0, 8, 10, 2] = obj.dThreshold_u8A2;
                MainWindow.dThreshold3[0, 8, 10, 3] = obj.dThreshold_u8A3;
                MainWindow.dThreshold3[0, 8, 10, 4] = obj.dThreshold_u8A4;
                MainWindow.dThreshold3[0, 8, 10, 5] = obj.dThreshold_u8A5;
                MainWindow.dThreshold3[0, 8, 10, 6] = obj.dThreshold_u8A6;
                MainWindow.dThreshold3[0, 8, 10, 7] = obj.dThreshold_u8A7;
                MainWindow.dThreshold3[0, 8, 10, 8] = obj.dThreshold_u8A8;
                MainWindow.dThreshold3[0, 8, 10, 9] = obj.dThreshold_u8A9;

                MainWindow.dThreshold3[1, 8, 10, 0] = obj.dThreshold_l8A0;
                MainWindow.dThreshold3[1, 8, 10, 1] = obj.dThreshold_l8A1;
                MainWindow.dThreshold3[1, 8, 10, 2] = obj.dThreshold_l8A2;
                MainWindow.dThreshold3[1, 8, 10, 3] = obj.dThreshold_l8A3;
                MainWindow.dThreshold3[1, 8, 10, 4] = obj.dThreshold_l8A4;
                MainWindow.dThreshold3[1, 8, 10, 5] = obj.dThreshold_l8A5;
                MainWindow.dThreshold3[1, 8, 10, 6] = obj.dThreshold_l8A6;
                MainWindow.dThreshold3[1, 8, 10, 7] = obj.dThreshold_l8A7;
                MainWindow.dThreshold3[1, 8, 10, 8] = obj.dThreshold_l8A8;
                MainWindow.dThreshold3[1, 8, 10, 9] = obj.dThreshold_l8A9;

                //品種10
                //10-Stream1
                MainWindow.dThreshold3[0, 9, 0, 0] = obj.dThreshold_u900;
                MainWindow.dThreshold3[0, 9, 0, 1] = obj.dThreshold_u901;
                MainWindow.dThreshold3[0, 9, 0, 2] = obj.dThreshold_u902;
                MainWindow.dThreshold3[0, 9, 0, 3] = obj.dThreshold_u903;
                MainWindow.dThreshold3[0, 9, 0, 4] = obj.dThreshold_u904;
                MainWindow.dThreshold3[0, 9, 0, 5] = obj.dThreshold_u905;
                MainWindow.dThreshold3[0, 9, 0, 6] = obj.dThreshold_u906;
                MainWindow.dThreshold3[0, 9, 0, 7] = obj.dThreshold_u907;
                MainWindow.dThreshold3[0, 9, 0, 8] = obj.dThreshold_u908;
                MainWindow.dThreshold3[0, 9, 0, 9] = obj.dThreshold_u909;

                MainWindow.dThreshold3[1, 9, 0, 0] = obj.dThreshold_l900;
                MainWindow.dThreshold3[1, 9, 0, 1] = obj.dThreshold_l901;
                MainWindow.dThreshold3[1, 9, 0, 2] = obj.dThreshold_l902;
                MainWindow.dThreshold3[1, 9, 0, 3] = obj.dThreshold_l903;
                MainWindow.dThreshold3[1, 9, 0, 4] = obj.dThreshold_l904;
                MainWindow.dThreshold3[1, 9, 0, 5] = obj.dThreshold_l905;
                MainWindow.dThreshold3[1, 9, 0, 6] = obj.dThreshold_l906;
                MainWindow.dThreshold3[1, 9, 0, 7] = obj.dThreshold_l907;
                MainWindow.dThreshold3[1, 9, 0, 8] = obj.dThreshold_l908;
                MainWindow.dThreshold3[1, 9, 0, 9] = obj.dThreshold_l909;
                //10-Stream2
                MainWindow.dThreshold3[0, 9, 1, 0] = obj.dThreshold_u910;
                MainWindow.dThreshold3[0, 9, 1, 1] = obj.dThreshold_u911;
                MainWindow.dThreshold3[0, 9, 1, 2] = obj.dThreshold_u912;
                MainWindow.dThreshold3[0, 9, 1, 3] = obj.dThreshold_u913;
                MainWindow.dThreshold3[0, 9, 1, 4] = obj.dThreshold_u914;
                MainWindow.dThreshold3[0, 9, 1, 5] = obj.dThreshold_u915;
                MainWindow.dThreshold3[0, 9, 1, 6] = obj.dThreshold_u916;
                MainWindow.dThreshold3[0, 9, 1, 7] = obj.dThreshold_u917;
                MainWindow.dThreshold3[0, 9, 1, 8] = obj.dThreshold_u918;
                MainWindow.dThreshold3[0, 9, 1, 9] = obj.dThreshold_u919;

                MainWindow.dThreshold3[1, 9, 1, 0] = obj.dThreshold_l910;
                MainWindow.dThreshold3[1, 9, 1, 1] = obj.dThreshold_l911;
                MainWindow.dThreshold3[1, 9, 1, 2] = obj.dThreshold_l912;
                MainWindow.dThreshold3[1, 9, 1, 3] = obj.dThreshold_l913;
                MainWindow.dThreshold3[1, 9, 1, 4] = obj.dThreshold_l914;
                MainWindow.dThreshold3[1, 9, 1, 5] = obj.dThreshold_l915;
                MainWindow.dThreshold3[1, 9, 1, 6] = obj.dThreshold_l916;
                MainWindow.dThreshold3[1, 9, 1, 7] = obj.dThreshold_l917;
                MainWindow.dThreshold3[1, 9, 1, 8] = obj.dThreshold_l918;
                MainWindow.dThreshold3[1, 9, 1, 9] = obj.dThreshold_l919;
                //10-Stream3
                MainWindow.dThreshold3[0, 9, 2, 0] = obj.dThreshold_u920;
                MainWindow.dThreshold3[0, 9, 2, 1] = obj.dThreshold_u921;
                MainWindow.dThreshold3[0, 9, 2, 2] = obj.dThreshold_u922;
                MainWindow.dThreshold3[0, 9, 2, 3] = obj.dThreshold_u923;
                MainWindow.dThreshold3[0, 9, 2, 4] = obj.dThreshold_u924;
                MainWindow.dThreshold3[0, 9, 2, 5] = obj.dThreshold_u925;
                MainWindow.dThreshold3[0, 9, 2, 6] = obj.dThreshold_u926;
                MainWindow.dThreshold3[0, 9, 2, 7] = obj.dThreshold_u927;
                MainWindow.dThreshold3[0, 9, 2, 8] = obj.dThreshold_u928;
                MainWindow.dThreshold3[0, 9, 2, 9] = obj.dThreshold_u929;

                MainWindow.dThreshold3[1, 9, 2, 0] = obj.dThreshold_l920;
                MainWindow.dThreshold3[1, 9, 2, 1] = obj.dThreshold_l921;
                MainWindow.dThreshold3[1, 9, 2, 2] = obj.dThreshold_l922;
                MainWindow.dThreshold3[1, 9, 2, 3] = obj.dThreshold_l923;
                MainWindow.dThreshold3[1, 9, 2, 4] = obj.dThreshold_l924;
                MainWindow.dThreshold3[1, 9, 2, 5] = obj.dThreshold_l925;
                MainWindow.dThreshold3[1, 9, 2, 6] = obj.dThreshold_l926;
                MainWindow.dThreshold3[1, 9, 2, 7] = obj.dThreshold_l927;
                MainWindow.dThreshold3[1, 9, 2, 8] = obj.dThreshold_l928;
                MainWindow.dThreshold3[1, 9, 2, 9] = obj.dThreshold_l929;
                //10-Stream4
                MainWindow.dThreshold3[0, 9, 3, 0] = obj.dThreshold_u930;
                MainWindow.dThreshold3[0, 9, 3, 1] = obj.dThreshold_u931;
                MainWindow.dThreshold3[0, 9, 3, 2] = obj.dThreshold_u932;
                MainWindow.dThreshold3[0, 9, 3, 3] = obj.dThreshold_u933;
                MainWindow.dThreshold3[0, 9, 3, 4] = obj.dThreshold_u934;
                MainWindow.dThreshold3[0, 9, 3, 5] = obj.dThreshold_u935;
                MainWindow.dThreshold3[0, 9, 3, 6] = obj.dThreshold_u936;
                MainWindow.dThreshold3[0, 9, 3, 7] = obj.dThreshold_u937;
                MainWindow.dThreshold3[0, 9, 3, 8] = obj.dThreshold_u938;
                MainWindow.dThreshold3[0, 9, 3, 9] = obj.dThreshold_u939;

                MainWindow.dThreshold3[1, 9, 3, 0] = obj.dThreshold_l930;
                MainWindow.dThreshold3[1, 9, 3, 1] = obj.dThreshold_l931;
                MainWindow.dThreshold3[1, 9, 3, 2] = obj.dThreshold_l932;
                MainWindow.dThreshold3[1, 9, 3, 3] = obj.dThreshold_l933;
                MainWindow.dThreshold3[1, 9, 3, 4] = obj.dThreshold_l934;
                MainWindow.dThreshold3[1, 9, 3, 5] = obj.dThreshold_l935;
                MainWindow.dThreshold3[1, 9, 3, 6] = obj.dThreshold_l936;
                MainWindow.dThreshold3[1, 9, 3, 7] = obj.dThreshold_l937;
                MainWindow.dThreshold3[1, 9, 3, 8] = obj.dThreshold_l938;
                MainWindow.dThreshold3[1, 9, 3, 9] = obj.dThreshold_l939;
                //10-Stream5
                MainWindow.dThreshold3[0, 9, 4, 0] = obj.dThreshold_u940;
                MainWindow.dThreshold3[0, 9, 4, 1] = obj.dThreshold_u941;
                MainWindow.dThreshold3[0, 9, 4, 2] = obj.dThreshold_u942;
                MainWindow.dThreshold3[0, 9, 4, 3] = obj.dThreshold_u943;
                MainWindow.dThreshold3[0, 9, 4, 4] = obj.dThreshold_u944;
                MainWindow.dThreshold3[0, 9, 4, 5] = obj.dThreshold_u945;
                MainWindow.dThreshold3[0, 9, 4, 6] = obj.dThreshold_u946;
                MainWindow.dThreshold3[0, 9, 4, 7] = obj.dThreshold_u947;
                MainWindow.dThreshold3[0, 9, 4, 8] = obj.dThreshold_u948;
                MainWindow.dThreshold3[0, 9, 4, 9] = obj.dThreshold_u949;

                MainWindow.dThreshold3[1, 9, 4, 0] = obj.dThreshold_l940;
                MainWindow.dThreshold3[1, 9, 4, 1] = obj.dThreshold_l941;
                MainWindow.dThreshold3[1, 9, 4, 2] = obj.dThreshold_l942;
                MainWindow.dThreshold3[1, 9, 4, 3] = obj.dThreshold_l943;
                MainWindow.dThreshold3[1, 9, 4, 4] = obj.dThreshold_l944;
                MainWindow.dThreshold3[1, 9, 4, 5] = obj.dThreshold_l945;
                MainWindow.dThreshold3[1, 9, 4, 6] = obj.dThreshold_l946;
                MainWindow.dThreshold3[1, 9, 4, 7] = obj.dThreshold_l947;
                MainWindow.dThreshold3[1, 9, 4, 8] = obj.dThreshold_l948;
                MainWindow.dThreshold3[1, 9, 4, 9] = obj.dThreshold_l949;
                //10-Stream6
                MainWindow.dThreshold3[0, 9, 5, 0] = obj.dThreshold_u950;
                MainWindow.dThreshold3[0, 9, 5, 1] = obj.dThreshold_u951;
                MainWindow.dThreshold3[0, 9, 5, 2] = obj.dThreshold_u952;
                MainWindow.dThreshold3[0, 9, 5, 3] = obj.dThreshold_u953;
                MainWindow.dThreshold3[0, 9, 5, 4] = obj.dThreshold_u954;
                MainWindow.dThreshold3[0, 9, 5, 5] = obj.dThreshold_u955;
                MainWindow.dThreshold3[0, 9, 5, 6] = obj.dThreshold_u956;
                MainWindow.dThreshold3[0, 9, 5, 7] = obj.dThreshold_u957;
                MainWindow.dThreshold3[0, 9, 5, 8] = obj.dThreshold_u958;
                MainWindow.dThreshold3[0, 9, 5, 9] = obj.dThreshold_u959;

                MainWindow.dThreshold3[1, 9, 5, 0] = obj.dThreshold_l950;
                MainWindow.dThreshold3[1, 9, 5, 1] = obj.dThreshold_l951;
                MainWindow.dThreshold3[1, 9, 5, 2] = obj.dThreshold_l952;
                MainWindow.dThreshold3[1, 9, 5, 3] = obj.dThreshold_l953;
                MainWindow.dThreshold3[1, 9, 5, 4] = obj.dThreshold_l954;
                MainWindow.dThreshold3[1, 9, 5, 5] = obj.dThreshold_l955;
                MainWindow.dThreshold3[1, 9, 5, 6] = obj.dThreshold_l956;
                MainWindow.dThreshold3[1, 9, 5, 7] = obj.dThreshold_l957;
                MainWindow.dThreshold3[1, 9, 5, 8] = obj.dThreshold_l958;
                MainWindow.dThreshold3[1, 9, 5, 9] = obj.dThreshold_l959;
                //10-Stream7
                MainWindow.dThreshold3[0, 9, 6, 0] = obj.dThreshold_u960;
                MainWindow.dThreshold3[0, 9, 6, 1] = obj.dThreshold_u961;
                MainWindow.dThreshold3[0, 9, 6, 2] = obj.dThreshold_u962;
                MainWindow.dThreshold3[0, 9, 6, 3] = obj.dThreshold_u963;
                MainWindow.dThreshold3[0, 9, 6, 4] = obj.dThreshold_u964;
                MainWindow.dThreshold3[0, 9, 6, 5] = obj.dThreshold_u965;
                MainWindow.dThreshold3[0, 9, 6, 6] = obj.dThreshold_u966;
                MainWindow.dThreshold3[0, 9, 6, 7] = obj.dThreshold_u967;
                MainWindow.dThreshold3[0, 9, 6, 8] = obj.dThreshold_u968;
                MainWindow.dThreshold3[0, 9, 6, 9] = obj.dThreshold_u969;

                MainWindow.dThreshold3[1, 9, 6, 0] = obj.dThreshold_l960;
                MainWindow.dThreshold3[1, 9, 6, 1] = obj.dThreshold_l961;
                MainWindow.dThreshold3[1, 9, 6, 2] = obj.dThreshold_l962;
                MainWindow.dThreshold3[1, 9, 6, 3] = obj.dThreshold_l963;
                MainWindow.dThreshold3[1, 9, 6, 4] = obj.dThreshold_l964;
                MainWindow.dThreshold3[1, 9, 6, 5] = obj.dThreshold_l965;
                MainWindow.dThreshold3[1, 9, 6, 6] = obj.dThreshold_l966;
                MainWindow.dThreshold3[1, 9, 6, 7] = obj.dThreshold_l967;
                MainWindow.dThreshold3[1, 9, 6, 8] = obj.dThreshold_l968;
                MainWindow.dThreshold3[1, 9, 6, 9] = obj.dThreshold_l969;
                //10-Stream8
                MainWindow.dThreshold3[0, 9, 7, 0] = obj.dThreshold_u970;
                MainWindow.dThreshold3[0, 9, 7, 1] = obj.dThreshold_u971;
                MainWindow.dThreshold3[0, 9, 7, 2] = obj.dThreshold_u972;
                MainWindow.dThreshold3[0, 9, 7, 3] = obj.dThreshold_u973;
                MainWindow.dThreshold3[0, 9, 7, 4] = obj.dThreshold_u974;
                MainWindow.dThreshold3[0, 9, 7, 5] = obj.dThreshold_u975;
                MainWindow.dThreshold3[0, 9, 7, 6] = obj.dThreshold_u976;
                MainWindow.dThreshold3[0, 9, 7, 7] = obj.dThreshold_u977;
                MainWindow.dThreshold3[0, 9, 7, 8] = obj.dThreshold_u978;
                MainWindow.dThreshold3[0, 9, 7, 9] = obj.dThreshold_u979;

                MainWindow.dThreshold3[1, 9, 7, 0] = obj.dThreshold_l970;
                MainWindow.dThreshold3[1, 9, 7, 1] = obj.dThreshold_l971;
                MainWindow.dThreshold3[1, 9, 7, 2] = obj.dThreshold_l972;
                MainWindow.dThreshold3[1, 9, 7, 3] = obj.dThreshold_l973;
                MainWindow.dThreshold3[1, 9, 7, 4] = obj.dThreshold_l974;
                MainWindow.dThreshold3[1, 9, 7, 5] = obj.dThreshold_l975;
                MainWindow.dThreshold3[1, 9, 7, 6] = obj.dThreshold_l976;
                MainWindow.dThreshold3[1, 9, 7, 7] = obj.dThreshold_l977;
                MainWindow.dThreshold3[1, 9, 7, 8] = obj.dThreshold_l978;
                MainWindow.dThreshold3[1, 9, 7, 9] = obj.dThreshold_l979;
                //10-Stream9
                MainWindow.dThreshold3[0, 9, 8, 0] = obj.dThreshold_u980;
                MainWindow.dThreshold3[0, 9, 8, 1] = obj.dThreshold_u981;
                MainWindow.dThreshold3[0, 9, 8, 2] = obj.dThreshold_u982;
                MainWindow.dThreshold3[0, 9, 8, 3] = obj.dThreshold_u983;
                MainWindow.dThreshold3[0, 9, 8, 4] = obj.dThreshold_u984;
                MainWindow.dThreshold3[0, 9, 8, 5] = obj.dThreshold_u985;
                MainWindow.dThreshold3[0, 9, 8, 6] = obj.dThreshold_u986;
                MainWindow.dThreshold3[0, 9, 8, 7] = obj.dThreshold_u987;
                MainWindow.dThreshold3[0, 9, 8, 8] = obj.dThreshold_u988;
                MainWindow.dThreshold3[0, 9, 8, 9] = obj.dThreshold_u989;

                MainWindow.dThreshold3[1, 9, 8, 0] = obj.dThreshold_l980;
                MainWindow.dThreshold3[1, 9, 8, 1] = obj.dThreshold_l981;
                MainWindow.dThreshold3[1, 9, 8, 2] = obj.dThreshold_l982;
                MainWindow.dThreshold3[1, 9, 8, 3] = obj.dThreshold_l983;
                MainWindow.dThreshold3[1, 9, 8, 4] = obj.dThreshold_l984;
                MainWindow.dThreshold3[1, 9, 8, 5] = obj.dThreshold_l985;
                MainWindow.dThreshold3[1, 9, 8, 6] = obj.dThreshold_l986;
                MainWindow.dThreshold3[1, 9, 8, 7] = obj.dThreshold_l987;
                MainWindow.dThreshold3[1, 9, 8, 8] = obj.dThreshold_l988;
                MainWindow.dThreshold3[1, 9, 8, 9] = obj.dThreshold_l989;
                //10-Stream10
                MainWindow.dThreshold3[0, 9, 9, 0] = obj.dThreshold_u990;
                MainWindow.dThreshold3[0, 9, 9, 1] = obj.dThreshold_u991;
                MainWindow.dThreshold3[0, 9, 9, 2] = obj.dThreshold_u992;
                MainWindow.dThreshold3[0, 9, 9, 3] = obj.dThreshold_u993;
                MainWindow.dThreshold3[0, 9, 9, 4] = obj.dThreshold_u994;
                MainWindow.dThreshold3[0, 9, 9, 5] = obj.dThreshold_u995;
                MainWindow.dThreshold3[0, 9, 9, 6] = obj.dThreshold_u996;
                MainWindow.dThreshold3[0, 9, 9, 7] = obj.dThreshold_u997;
                MainWindow.dThreshold3[0, 9, 9, 8] = obj.dThreshold_u998;
                MainWindow.dThreshold3[0, 9, 9, 9] = obj.dThreshold_u999;

                MainWindow.dThreshold3[1, 9, 9, 0] = obj.dThreshold_l990;
                MainWindow.dThreshold3[1, 9, 9, 1] = obj.dThreshold_l991;
                MainWindow.dThreshold3[1, 9, 9, 2] = obj.dThreshold_l992;
                MainWindow.dThreshold3[1, 9, 9, 3] = obj.dThreshold_l993;
                MainWindow.dThreshold3[1, 9, 9, 4] = obj.dThreshold_l994;
                MainWindow.dThreshold3[1, 9, 9, 5] = obj.dThreshold_l995;
                MainWindow.dThreshold3[1, 9, 9, 6] = obj.dThreshold_l996;
                MainWindow.dThreshold3[1, 9, 9, 7] = obj.dThreshold_l997;
                MainWindow.dThreshold3[1, 9, 9, 8] = obj.dThreshold_l998;
                MainWindow.dThreshold3[1, 9, 9, 9] = obj.dThreshold_l999;
                //10-Stream11
                MainWindow.dThreshold3[0, 9, 10, 0] = obj.dThreshold_u9A0;
                MainWindow.dThreshold3[0, 9, 10, 1] = obj.dThreshold_u9A1;
                MainWindow.dThreshold3[0, 9, 10, 2] = obj.dThreshold_u9A2;
                MainWindow.dThreshold3[0, 9, 10, 3] = obj.dThreshold_u9A3;
                MainWindow.dThreshold3[0, 9, 10, 4] = obj.dThreshold_u9A4;
                MainWindow.dThreshold3[0, 9, 10, 5] = obj.dThreshold_u9A5;
                MainWindow.dThreshold3[0, 9, 10, 6] = obj.dThreshold_u9A6;
                MainWindow.dThreshold3[0, 9, 10, 7] = obj.dThreshold_u9A7;
                MainWindow.dThreshold3[0, 9, 10, 8] = obj.dThreshold_u9A8;
                MainWindow.dThreshold3[0, 9, 10, 9] = obj.dThreshold_u9A9;

                MainWindow.dThreshold3[1, 9, 10, 0] = obj.dThreshold_l9A0;
                MainWindow.dThreshold3[1, 9, 10, 1] = obj.dThreshold_l9A1;
                MainWindow.dThreshold3[1, 9, 10, 2] = obj.dThreshold_l9A2;
                MainWindow.dThreshold3[1, 9, 10, 3] = obj.dThreshold_l9A3;
                MainWindow.dThreshold3[1, 9, 10, 4] = obj.dThreshold_l9A4;
                MainWindow.dThreshold3[1, 9, 10, 5] = obj.dThreshold_l9A5;
                MainWindow.dThreshold3[1, 9, 10, 6] = obj.dThreshold_l9A6;
                MainWindow.dThreshold3[1, 9, 10, 7] = obj.dThreshold_l9A7;
                MainWindow.dThreshold3[1, 9, 10, 8] = obj.dThreshold_l9A8;
                MainWindow.dThreshold3[1, 9, 10, 9] = obj.dThreshold_l9A9;
                //ADD_END :2020/4/27 kitayama 理由：改造に合わせたしきい値の形式に変更する


                /////////////// パラメタ ///////////////////////////////////////////////////
                //ファイルを閉じる
                sr.Close();
                //////////////////////////////////////////////////////////////////////////////
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

    }

    /// <summary>
    /// XMLファイルに保存するオブジェクトのためのクラス
    /// </summary>
    public class SampleClass
    {
        /////////////////////////////////////////////////////////////////////////////
        ///                     画画像取得設定関連パラメタ
        /////////////////////////////////////////////////////////////////////////////
        public int GetImageInterval;        //画画像取得周期（単位msec)
        public int MoveImageInterval;       //画像移動周期（単位msec)
        //CHANGE_START :2021/11/27 kitayama 理由：保存先をOK画像、NG画像、判定不可画像の3種に変更
        public string OKImagePath;         //OK画像取得先パス
        public string INTERImagePath;         //判定不可画像保存先パス
        public string NGImagePath;         //NG画像保存先パス
        //public string GetImagePath;         //画像取得先パス
        //public string SetImagePath;         //画像保存先パス
        //public string IsoImagePath;         //画像隔離先パス
        //CHANGE_START :2021/11/27 kitayama 理由：保存先をOK画像、NG画像、判定不可画像の3種に変更
        //ADD_START :2020/1/17 kitayama 理由：画像表示時間を追加
        public int HoldTime;                //検査予定枚数が0の場合の検査画像表示時間
        //ADD_END :2020/1/17 kitayama 理由：画像表示時間を追加
        //ADD_START :2020/2/21 kitayama 理由：画像保存しきい値を追加
        public int Blankrate;
        //ADD_END :2020/2/21 kitayama 理由：画像保存しきい値を追加
        //ADD_START :2020/10/12 kitayama 理由：シャッタースピード、ゲイン？を追加
        public int shutterspeed;
        public int brightness;
        //ADD_END :2020/10/12 kitayama 理由：シャッタースピード、ゲイン？を追加
        /////////////////////////////////////////////////////////////////////////////
        ///                     品種名データ　パラメタ
        /////////////////////////////////////////////////////////////////////////////
        public string Kishu1;
        public string Kishu2;
        public string Kishu3;
        public string Kishu4;
        public string Kishu5;
        public string Kishu6;
        public string Kishu7;
        public string Kishu8;
        public string Kishu9;
        public string Kishu10;
        /////////////////////////////////////////////////////////////////////////////
        ///                     ViDiワークスペース　ファイル名　パラメタ
        /////////////////////////////////////////////////////////////////////////////
        public string WorkSpece1;
        public string WorkSpece2;
        public string WorkSpece3;
        public string WorkSpece4;
        public string WorkSpece5;
        public string WorkSpece6;
        public string WorkSpece7;
        public string WorkSpece8;
        public string WorkSpece9;
        public string WorkSpece10;

        /////////////////////////////////////////////////////////////////////////////
        ///                     ViDi Analyzeの検査名称
        /////////////////////////////////////////////////////////////////////////////

        //DELETE_START :2021/12/19 kitayama 理由：名称は使用しないので削除
        ////ADD_START :2021/11/23 kitayama 理由：検査名称を追加
        ////品種1
        ////1-Stream1
        //public string Meisyou000;
        //public string Meisyou001;
        //public string Meisyou002;
        //public string Meisyou003;
        //public string Meisyou004;
        //public string Meisyou005;
        //public string Meisyou006;
        //public string Meisyou007;
        //public string Meisyou008;
        //public string Meisyou009;
        ////1-Stream2
        //public string Meisyou010;
        //public string Meisyou011;
        //public string Meisyou012;
        //public string Meisyou013;
        //public string Meisyou014;
        //public string Meisyou015;
        //public string Meisyou016;
        //public string Meisyou017;
        //public string Meisyou018;
        //public string Meisyou019;
        ////1-Stream3
        //public string Meisyou020;
        //public string Meisyou021;
        //public string Meisyou022;
        //public string Meisyou023;
        //public string Meisyou024;
        //public string Meisyou025;
        //public string Meisyou026;
        //public string Meisyou027;
        //public string Meisyou028;
        //public string Meisyou029;
        ////1-Stream4
        //public string Meisyou030;
        //public string Meisyou031;
        //public string Meisyou032;
        //public string Meisyou033;
        //public string Meisyou034;
        //public string Meisyou035;
        //public string Meisyou036;
        //public string Meisyou037;
        //public string Meisyou038;
        //public string Meisyou039;
        ////1-Stream5
        //public string Meisyou040;
        //public string Meisyou041;
        //public string Meisyou042;
        //public string Meisyou043;
        //public string Meisyou044;
        //public string Meisyou045;
        //public string Meisyou046;
        //public string Meisyou047;
        //public string Meisyou048;
        //public string Meisyou049;
        ////1-Stream6
        //public string Meisyou050;
        //public string Meisyou051;
        //public string Meisyou052;
        //public string Meisyou053;
        //public string Meisyou054;
        //public string Meisyou055;
        //public string Meisyou056;
        //public string Meisyou057;
        //public string Meisyou058;
        //public string Meisyou059;
        ////1-Stream7
        //public string Meisyou060;
        //public string Meisyou061;
        //public string Meisyou062;
        //public string Meisyou063;
        //public string Meisyou064;
        //public string Meisyou065;
        //public string Meisyou066;
        //public string Meisyou067;
        //public string Meisyou068;
        //public string Meisyou069;
        ////1-Stream8
        //public string Meisyou070;
        //public string Meisyou071;
        //public string Meisyou072;
        //public string Meisyou073;
        //public string Meisyou074;
        //public string Meisyou075;
        //public string Meisyou076;
        //public string Meisyou077;
        //public string Meisyou078;
        //public string Meisyou079;
        ////1-Stream9
        //public string Meisyou080;
        //public string Meisyou081;
        //public string Meisyou082;
        //public string Meisyou083;
        //public string Meisyou084;
        //public string Meisyou085;
        //public string Meisyou086;
        //public string Meisyou087;
        //public string Meisyou088;
        //public string Meisyou089;
        ////1-Stream10
        //public string Meisyou090;
        //public string Meisyou091;
        //public string Meisyou092;
        //public string Meisyou093;
        //public string Meisyou094;
        //public string Meisyou095;
        //public string Meisyou096;
        //public string Meisyou097;
        //public string Meisyou098;
        //public string Meisyou099;
        ////1-Stream11
        //public string Meisyou0A0;
        //public string Meisyou0A1;
        //public string Meisyou0A2;
        //public string Meisyou0A3;
        //public string Meisyou0A4;
        //public string Meisyou0A5;
        //public string Meisyou0A6;
        //public string Meisyou0A7;
        //public string Meisyou0A8;
        //public string Meisyou0A9;

        ////品種2
        ////2-Stream1
        //public string Meisyou100;
        //public string Meisyou101;
        //public string Meisyou102;
        //public string Meisyou103;
        //public string Meisyou104;
        //public string Meisyou105;
        //public string Meisyou106;
        //public string Meisyou107;
        //public string Meisyou108;
        //public string Meisyou109;
        ////2-Stream2
        //public string Meisyou110;
        //public string Meisyou111;
        //public string Meisyou112;
        //public string Meisyou113;
        //public string Meisyou114;
        //public string Meisyou115;
        //public string Meisyou116;
        //public string Meisyou117;
        //public string Meisyou118;
        //public string Meisyou119;
        ////2-Stream3
        //public string Meisyou120;
        //public string Meisyou121;
        //public string Meisyou122;
        //public string Meisyou123;
        //public string Meisyou124;
        //public string Meisyou125;
        //public string Meisyou126;
        //public string Meisyou127;
        //public string Meisyou128;
        //public string Meisyou129;
        ////2-Stream4
        //public string Meisyou130;
        //public string Meisyou131;
        //public string Meisyou132;
        //public string Meisyou133;
        //public string Meisyou134;
        //public string Meisyou135;
        //public string Meisyou136;
        //public string Meisyou137;
        //public string Meisyou138;
        //public string Meisyou139;
        ////2-Stream5
        //public string Meisyou140;
        //public string Meisyou141;
        //public string Meisyou142;
        //public string Meisyou143;
        //public string Meisyou144;
        //public string Meisyou145;
        //public string Meisyou146;
        //public string Meisyou147;
        //public string Meisyou148;
        //public string Meisyou149;
        ////2-Stream6
        //public string Meisyou150;
        //public string Meisyou151;
        //public string Meisyou152;
        //public string Meisyou153;
        //public string Meisyou154;
        //public string Meisyou155;
        //public string Meisyou156;
        //public string Meisyou157;
        //public string Meisyou158;
        //public string Meisyou159;
        ////2-Stream7
        //public string Meisyou160;
        //public string Meisyou161;
        //public string Meisyou162;
        //public string Meisyou163;
        //public string Meisyou164;
        //public string Meisyou165;
        //public string Meisyou166;
        //public string Meisyou167;
        //public string Meisyou168;
        //public string Meisyou169;
        ////2-Stream8
        //public string Meisyou170;
        //public string Meisyou171;
        //public string Meisyou172;
        //public string Meisyou173;
        //public string Meisyou174;
        //public string Meisyou175;
        //public string Meisyou176;
        //public string Meisyou177;
        //public string Meisyou178;
        //public string Meisyou179;
        ////2-Stream9
        //public string Meisyou180;
        //public string Meisyou181;
        //public string Meisyou182;
        //public string Meisyou183;
        //public string Meisyou184;
        //public string Meisyou185;
        //public string Meisyou186;
        //public string Meisyou187;
        //public string Meisyou188;
        //public string Meisyou189;
        ////2-Stream10
        //public string Meisyou190;
        //public string Meisyou191;
        //public string Meisyou192;
        //public string Meisyou193;
        //public string Meisyou194;
        //public string Meisyou195;
        //public string Meisyou196;
        //public string Meisyou197;
        //public string Meisyou198;
        //public string Meisyou199;
        ////2-Stream11
        //public string Meisyou1A0;
        //public string Meisyou1A1;
        //public string Meisyou1A2;
        //public string Meisyou1A3;
        //public string Meisyou1A4;
        //public string Meisyou1A5;
        //public string Meisyou1A6;
        //public string Meisyou1A7;
        //public string Meisyou1A8;
        //public string Meisyou1A9;

        ////品種3
        ////3-Stream1
        //public string Meisyou200;
        //public string Meisyou201;
        //public string Meisyou202;
        //public string Meisyou203;
        //public string Meisyou204;
        //public string Meisyou205;
        //public string Meisyou206;
        //public string Meisyou207;
        //public string Meisyou208;
        //public string Meisyou209;
        ////3-Stream2
        //public string Meisyou210;
        //public string Meisyou211;
        //public string Meisyou212;
        //public string Meisyou213;
        //public string Meisyou214;
        //public string Meisyou215;
        //public string Meisyou216;
        //public string Meisyou217;
        //public string Meisyou218;
        //public string Meisyou219;
        ////3-Stream3
        //public string Meisyou220;
        //public string Meisyou221;
        //public string Meisyou222;
        //public string Meisyou223;
        //public string Meisyou224;
        //public string Meisyou225;
        //public string Meisyou226;
        //public string Meisyou227;
        //public string Meisyou228;
        //public string Meisyou229;
        ////3-Stream4
        //public string Meisyou230;
        //public string Meisyou231;
        //public string Meisyou232;
        //public string Meisyou233;
        //public string Meisyou234;
        //public string Meisyou235;
        //public string Meisyou236;
        //public string Meisyou237;
        //public string Meisyou238;
        //public string Meisyou239;
        ////3-Stream5
        //public string Meisyou240;
        //public string Meisyou241;
        //public string Meisyou242;
        //public string Meisyou243;
        //public string Meisyou244;
        //public string Meisyou245;
        //public string Meisyou246;
        //public string Meisyou247;
        //public string Meisyou248;
        //public string Meisyou249;
        ////3-Stream6
        //public string Meisyou250;
        //public string Meisyou251;
        //public string Meisyou252;
        //public string Meisyou253;
        //public string Meisyou254;
        //public string Meisyou255;
        //public string Meisyou256;
        //public string Meisyou257;
        //public string Meisyou258;
        //public string Meisyou259;
        ////3-Stream7
        //public string Meisyou260;
        //public string Meisyou261;
        //public string Meisyou262;
        //public string Meisyou263;
        //public string Meisyou264;
        //public string Meisyou265;
        //public string Meisyou266;
        //public string Meisyou267;
        //public string Meisyou268;
        //public string Meisyou269;
        ////3-Stream8
        //public string Meisyou270;
        //public string Meisyou271;
        //public string Meisyou272;
        //public string Meisyou273;
        //public string Meisyou274;
        //public string Meisyou275;
        //public string Meisyou276;
        //public string Meisyou277;
        //public string Meisyou278;
        //public string Meisyou279;
        ////3-Stream9
        //public string Meisyou280;
        //public string Meisyou281;
        //public string Meisyou282;
        //public string Meisyou283;
        //public string Meisyou284;
        //public string Meisyou285;
        //public string Meisyou286;
        //public string Meisyou287;
        //public string Meisyou288;
        //public string Meisyou289;
        ////3-Stream10
        //public string Meisyou290;
        //public string Meisyou291;
        //public string Meisyou292;
        //public string Meisyou293;
        //public string Meisyou294;
        //public string Meisyou295;
        //public string Meisyou296;
        //public string Meisyou297;
        //public string Meisyou298;
        //public string Meisyou299;
        ////3-Stream11
        //public string Meisyou2A0;
        //public string Meisyou2A1;
        //public string Meisyou2A2;
        //public string Meisyou2A3;
        //public string Meisyou2A4;
        //public string Meisyou2A5;
        //public string Meisyou2A6;
        //public string Meisyou2A7;
        //public string Meisyou2A8;
        //public string Meisyou2A9;

        ////品種4
        ////4-Stream1
        //public string Meisyou300;
        //public string Meisyou301;
        //public string Meisyou302;
        //public string Meisyou303;
        //public string Meisyou304;
        //public string Meisyou305;
        //public string Meisyou306;
        //public string Meisyou307;
        //public string Meisyou308;
        //public string Meisyou309;
        ////4-Stream2
        //public string Meisyou310;
        //public string Meisyou311;
        //public string Meisyou312;
        //public string Meisyou313;
        //public string Meisyou314;
        //public string Meisyou315;
        //public string Meisyou316;
        //public string Meisyou317;
        //public string Meisyou318;
        //public string Meisyou319;
        ////4-Stream3
        //public string Meisyou320;
        //public string Meisyou321;
        //public string Meisyou322;
        //public string Meisyou323;
        //public string Meisyou324;
        //public string Meisyou325;
        //public string Meisyou326;
        //public string Meisyou327;
        //public string Meisyou328;
        //public string Meisyou329;
        ////4-Stream4
        //public string Meisyou330;
        //public string Meisyou331;
        //public string Meisyou332;
        //public string Meisyou333;
        //public string Meisyou334;
        //public string Meisyou335;
        //public string Meisyou336;
        //public string Meisyou337;
        //public string Meisyou338;
        //public string Meisyou339;
        ////4-Stream5
        //public string Meisyou340;
        //public string Meisyou341;
        //public string Meisyou342;
        //public string Meisyou343;
        //public string Meisyou344;
        //public string Meisyou345;
        //public string Meisyou346;
        //public string Meisyou347;
        //public string Meisyou348;
        //public string Meisyou349;
        ////4-Stream6
        //public string Meisyou350;
        //public string Meisyou351;
        //public string Meisyou352;
        //public string Meisyou353;
        //public string Meisyou354;
        //public string Meisyou355;
        //public string Meisyou356;
        //public string Meisyou357;
        //public string Meisyou358;
        //public string Meisyou359;
        ////4-Stream7
        //public string Meisyou360;
        //public string Meisyou361;
        //public string Meisyou362;
        //public string Meisyou363;
        //public string Meisyou364;
        //public string Meisyou365;
        //public string Meisyou366;
        //public string Meisyou367;
        //public string Meisyou368;
        //public string Meisyou369;
        ////4-Stream8
        //public string Meisyou370;
        //public string Meisyou371;
        //public string Meisyou372;
        //public string Meisyou373;
        //public string Meisyou374;
        //public string Meisyou375;
        //public string Meisyou376;
        //public string Meisyou377;
        //public string Meisyou378;
        //public string Meisyou379;
        ////4-Stream9
        //public string Meisyou380;
        //public string Meisyou381;
        //public string Meisyou382;
        //public string Meisyou383;
        //public string Meisyou384;
        //public string Meisyou385;
        //public string Meisyou386;
        //public string Meisyou387;
        //public string Meisyou388;
        //public string Meisyou389;
        ////4-Stream10
        //public string Meisyou390;
        //public string Meisyou391;
        //public string Meisyou392;
        //public string Meisyou393;
        //public string Meisyou394;
        //public string Meisyou395;
        //public string Meisyou396;
        //public string Meisyou397;
        //public string Meisyou398;
        //public string Meisyou399;
        ////4-Stream11
        //public string Meisyou3A0;
        //public string Meisyou3A1;
        //public string Meisyou3A2;
        //public string Meisyou3A3;
        //public string Meisyou3A4;
        //public string Meisyou3A5;
        //public string Meisyou3A6;
        //public string Meisyou3A7;
        //public string Meisyou3A8;
        //public string Meisyou3A9;

        ////品種5
        ////5-Stream1
        //public string Meisyou400;
        //public string Meisyou401;
        //public string Meisyou402;
        //public string Meisyou403;
        //public string Meisyou404;
        //public string Meisyou405;
        //public string Meisyou406;
        //public string Meisyou407;
        //public string Meisyou408;
        //public string Meisyou409;
        ////5-Stream2
        //public string Meisyou410;
        //public string Meisyou411;
        //public string Meisyou412;
        //public string Meisyou413;
        //public string Meisyou414;
        //public string Meisyou415;
        //public string Meisyou416;
        //public string Meisyou417;
        //public string Meisyou418;
        //public string Meisyou419;
        ////5-Stream3
        //public string Meisyou420;
        //public string Meisyou421;
        //public string Meisyou422;
        //public string Meisyou423;
        //public string Meisyou424;
        //public string Meisyou425;
        //public string Meisyou426;
        //public string Meisyou427;
        //public string Meisyou428;
        //public string Meisyou429;
        ////5-Stream4
        //public string Meisyou430;
        //public string Meisyou431;
        //public string Meisyou432;
        //public string Meisyou433;
        //public string Meisyou434;
        //public string Meisyou435;
        //public string Meisyou436;
        //public string Meisyou437;
        //public string Meisyou438;
        //public string Meisyou439;
        ////5-Stream5
        //public string Meisyou440;
        //public string Meisyou441;
        //public string Meisyou442;
        //public string Meisyou443;
        //public string Meisyou444;
        //public string Meisyou445;
        //public string Meisyou446;
        //public string Meisyou447;
        //public string Meisyou448;
        //public string Meisyou449;
        ////5-Stream6
        //public string Meisyou450;
        //public string Meisyou451;
        //public string Meisyou452;
        //public string Meisyou453;
        //public string Meisyou454;
        //public string Meisyou455;
        //public string Meisyou456;
        //public string Meisyou457;
        //public string Meisyou458;
        //public string Meisyou459;
        ////5-Stream7
        //public string Meisyou460;
        //public string Meisyou461;
        //public string Meisyou462;
        //public string Meisyou463;
        //public string Meisyou464;
        //public string Meisyou465;
        //public string Meisyou466;
        //public string Meisyou467;
        //public string Meisyou468;
        //public string Meisyou469;
        ////5-Stream8
        //public string Meisyou470;
        //public string Meisyou471;
        //public string Meisyou472;
        //public string Meisyou473;
        //public string Meisyou474;
        //public string Meisyou475;
        //public string Meisyou476;
        //public string Meisyou477;
        //public string Meisyou478;
        //public string Meisyou479;
        ////5-Stream9
        //public string Meisyou480;
        //public string Meisyou481;
        //public string Meisyou482;
        //public string Meisyou483;
        //public string Meisyou484;
        //public string Meisyou485;
        //public string Meisyou486;
        //public string Meisyou487;
        //public string Meisyou488;
        //public string Meisyou489;
        ////5-Stream10
        //public string Meisyou490;
        //public string Meisyou491;
        //public string Meisyou492;
        //public string Meisyou493;
        //public string Meisyou494;
        //public string Meisyou495;
        //public string Meisyou496;
        //public string Meisyou497;
        //public string Meisyou498;
        //public string Meisyou499;
        ////5-Stream11
        //public string Meisyou4A0;
        //public string Meisyou4A1;
        //public string Meisyou4A2;
        //public string Meisyou4A3;
        //public string Meisyou4A4;
        //public string Meisyou4A5;
        //public string Meisyou4A6;
        //public string Meisyou4A7;
        //public string Meisyou4A8;
        //public string Meisyou4A9;

        ////品種6
        ////6-Stream1
        //public string Meisyou500;
        //public string Meisyou501;
        //public string Meisyou502;
        //public string Meisyou503;
        //public string Meisyou504;
        //public string Meisyou505;
        //public string Meisyou506;
        //public string Meisyou507;
        //public string Meisyou508;
        //public string Meisyou509;
        ////6-Stream2
        //public string Meisyou510;
        //public string Meisyou511;
        //public string Meisyou512;
        //public string Meisyou513;
        //public string Meisyou514;
        //public string Meisyou515;
        //public string Meisyou516;
        //public string Meisyou517;
        //public string Meisyou518;
        //public string Meisyou519;
        ////6-Stream3
        //public string Meisyou520;
        //public string Meisyou521;
        //public string Meisyou522;
        //public string Meisyou523;
        //public string Meisyou524;
        //public string Meisyou525;
        //public string Meisyou526;
        //public string Meisyou527;
        //public string Meisyou528;
        //public string Meisyou529;
        ////6-Stream4
        //public string Meisyou530;
        //public string Meisyou531;
        //public string Meisyou532;
        //public string Meisyou533;
        //public string Meisyou534;
        //public string Meisyou535;
        //public string Meisyou536;
        //public string Meisyou537;
        //public string Meisyou538;
        //public string Meisyou539;
        ////6-Stream5
        //public string Meisyou540;
        //public string Meisyou541;
        //public string Meisyou542;
        //public string Meisyou543;
        //public string Meisyou544;
        //public string Meisyou545;
        //public string Meisyou546;
        //public string Meisyou547;
        //public string Meisyou548;
        //public string Meisyou549;
        ////6-Stream6
        //public string Meisyou550;
        //public string Meisyou551;
        //public string Meisyou552;
        //public string Meisyou553;
        //public string Meisyou554;
        //public string Meisyou555;
        //public string Meisyou556;
        //public string Meisyou557;
        //public string Meisyou558;
        //public string Meisyou559;
        ////6-Stream7
        //public string Meisyou560;
        //public string Meisyou561;
        //public string Meisyou562;
        //public string Meisyou563;
        //public string Meisyou564;
        //public string Meisyou565;
        //public string Meisyou566;
        //public string Meisyou567;
        //public string Meisyou568;
        //public string Meisyou569;
        ////6-Stream8
        //public string Meisyou570;
        //public string Meisyou571;
        //public string Meisyou572;
        //public string Meisyou573;
        //public string Meisyou574;
        //public string Meisyou575;
        //public string Meisyou576;
        //public string Meisyou577;
        //public string Meisyou578;
        //public string Meisyou579;
        ////6-Stream9
        //public string Meisyou580;
        //public string Meisyou581;
        //public string Meisyou582;
        //public string Meisyou583;
        //public string Meisyou584;
        //public string Meisyou585;
        //public string Meisyou586;
        //public string Meisyou587;
        //public string Meisyou588;
        //public string Meisyou589;
        ////6-Stream10
        //public string Meisyou590;
        //public string Meisyou591;
        //public string Meisyou592;
        //public string Meisyou593;
        //public string Meisyou594;
        //public string Meisyou595;
        //public string Meisyou596;
        //public string Meisyou597;
        //public string Meisyou598;
        //public string Meisyou599;
        ////6-Stream11
        //public string Meisyou5A0;
        //public string Meisyou5A1;
        //public string Meisyou5A2;
        //public string Meisyou5A3;
        //public string Meisyou5A4;
        //public string Meisyou5A5;
        //public string Meisyou5A6;
        //public string Meisyou5A7;
        //public string Meisyou5A8;
        //public string Meisyou5A9;

        ////品種7
        ////7-Stream1
        //public string Meisyou600;
        //public string Meisyou601;
        //public string Meisyou602;
        //public string Meisyou603;
        //public string Meisyou604;
        //public string Meisyou605;
        //public string Meisyou606;
        //public string Meisyou607;
        //public string Meisyou608;
        //public string Meisyou609;
        ////7-Stream2
        //public string Meisyou610;
        //public string Meisyou611;
        //public string Meisyou612;
        //public string Meisyou613;
        //public string Meisyou614;
        //public string Meisyou615;
        //public string Meisyou616;
        //public string Meisyou617;
        //public string Meisyou618;
        //public string Meisyou619;
        ////7-Stream3
        //public string Meisyou620;
        //public string Meisyou621;
        //public string Meisyou622;
        //public string Meisyou623;
        //public string Meisyou624;
        //public string Meisyou625;
        //public string Meisyou626;
        //public string Meisyou627;
        //public string Meisyou628;
        //public string Meisyou629;
        ////7-Stream4
        //public string Meisyou630;
        //public string Meisyou631;
        //public string Meisyou632;
        //public string Meisyou633;
        //public string Meisyou634;
        //public string Meisyou635;
        //public string Meisyou636;
        //public string Meisyou637;
        //public string Meisyou638;
        //public string Meisyou639;
        ////7-Stream5
        //public string Meisyou640;
        //public string Meisyou641;
        //public string Meisyou642;
        //public string Meisyou643;
        //public string Meisyou644;
        //public string Meisyou645;
        //public string Meisyou646;
        //public string Meisyou647;
        //public string Meisyou648;
        //public string Meisyou649;
        ////7-Stream6
        //public string Meisyou650;
        //public string Meisyou651;
        //public string Meisyou652;
        //public string Meisyou653;
        //public string Meisyou654;
        //public string Meisyou655;
        //public string Meisyou656;
        //public string Meisyou657;
        //public string Meisyou658;
        //public string Meisyou659;
        ////7-Stream7
        //public string Meisyou660;
        //public string Meisyou661;
        //public string Meisyou662;
        //public string Meisyou663;
        //public string Meisyou664;
        //public string Meisyou665;
        //public string Meisyou666;
        //public string Meisyou667;
        //public string Meisyou668;
        //public string Meisyou669;
        ////7-Stream8
        //public string Meisyou670;
        //public string Meisyou671;
        //public string Meisyou672;
        //public string Meisyou673;
        //public string Meisyou674;
        //public string Meisyou675;
        //public string Meisyou676;
        //public string Meisyou677;
        //public string Meisyou678;
        //public string Meisyou679;
        ////7-Stream9
        //public string Meisyou680;
        //public string Meisyou681;
        //public string Meisyou682;
        //public string Meisyou683;
        //public string Meisyou684;
        //public string Meisyou685;
        //public string Meisyou686;
        //public string Meisyou687;
        //public string Meisyou688;
        //public string Meisyou689;
        ////7-Stream10
        //public string Meisyou690;
        //public string Meisyou691;
        //public string Meisyou692;
        //public string Meisyou693;
        //public string Meisyou694;
        //public string Meisyou695;
        //public string Meisyou696;
        //public string Meisyou697;
        //public string Meisyou698;
        //public string Meisyou699;
        ////7-Stream11
        //public string Meisyou6A0;
        //public string Meisyou6A1;
        //public string Meisyou6A2;
        //public string Meisyou6A3;
        //public string Meisyou6A4;
        //public string Meisyou6A5;
        //public string Meisyou6A6;
        //public string Meisyou6A7;
        //public string Meisyou6A8;
        //public string Meisyou6A9;

        ////品種8
        ////8-Stream1
        //public string Meisyou700;
        //public string Meisyou701;
        //public string Meisyou702;
        //public string Meisyou703;
        //public string Meisyou704;
        //public string Meisyou705;
        //public string Meisyou706;
        //public string Meisyou707;
        //public string Meisyou708;
        //public string Meisyou709;
        ////8-Stream2
        //public string Meisyou710;
        //public string Meisyou711;
        //public string Meisyou712;
        //public string Meisyou713;
        //public string Meisyou714;
        //public string Meisyou715;
        //public string Meisyou716;
        //public string Meisyou717;
        //public string Meisyou718;
        //public string Meisyou719;
        ////8-Stream3
        //public string Meisyou720;
        //public string Meisyou721;
        //public string Meisyou722;
        //public string Meisyou723;
        //public string Meisyou724;
        //public string Meisyou725;
        //public string Meisyou726;
        //public string Meisyou727;
        //public string Meisyou728;
        //public string Meisyou729;
        ////8-Stream4
        //public string Meisyou730;
        //public string Meisyou731;
        //public string Meisyou732;
        //public string Meisyou733;
        //public string Meisyou734;
        //public string Meisyou735;
        //public string Meisyou736;
        //public string Meisyou737;
        //public string Meisyou738;
        //public string Meisyou739;
        ////8-Stream5
        //public string Meisyou740;
        //public string Meisyou741;
        //public string Meisyou742;
        //public string Meisyou743;
        //public string Meisyou744;
        //public string Meisyou745;
        //public string Meisyou746;
        //public string Meisyou747;
        //public string Meisyou748;
        //public string Meisyou749;
        ////8-Stream6
        //public string Meisyou750;
        //public string Meisyou751;
        //public string Meisyou752;
        //public string Meisyou753;
        //public string Meisyou754;
        //public string Meisyou755;
        //public string Meisyou756;
        //public string Meisyou757;
        //public string Meisyou758;
        //public string Meisyou759;
        ////8-Stream7
        //public string Meisyou760;
        //public string Meisyou761;
        //public string Meisyou762;
        //public string Meisyou763;
        //public string Meisyou764;
        //public string Meisyou765;
        //public string Meisyou766;
        //public string Meisyou767;
        //public string Meisyou768;
        //public string Meisyou769;
        ////8-Stream8
        //public string Meisyou770;
        //public string Meisyou771;
        //public string Meisyou772;
        //public string Meisyou773;
        //public string Meisyou774;
        //public string Meisyou775;
        //public string Meisyou776;
        //public string Meisyou777;
        //public string Meisyou778;
        //public string Meisyou779;
        ////8-Stream9
        //public string Meisyou780;
        //public string Meisyou781;
        //public string Meisyou782;
        //public string Meisyou783;
        //public string Meisyou784;
        //public string Meisyou785;
        //public string Meisyou786;
        //public string Meisyou787;
        //public string Meisyou788;
        //public string Meisyou789;
        ////8-Stream10
        //public string Meisyou790;
        //public string Meisyou791;
        //public string Meisyou792;
        //public string Meisyou793;
        //public string Meisyou794;
        //public string Meisyou795;
        //public string Meisyou796;
        //public string Meisyou797;
        //public string Meisyou798;
        //public string Meisyou799;
        ////8-Stream11
        //public string Meisyou7A0;
        //public string Meisyou7A1;
        //public string Meisyou7A2;
        //public string Meisyou7A3;
        //public string Meisyou7A4;
        //public string Meisyou7A5;
        //public string Meisyou7A6;
        //public string Meisyou7A7;
        //public string Meisyou7A8;
        //public string Meisyou7A9;

        ////品種9
        ////9-Stream1
        //public string Meisyou800;
        //public string Meisyou801;
        //public string Meisyou802;
        //public string Meisyou803;
        //public string Meisyou804;
        //public string Meisyou805;
        //public string Meisyou806;
        //public string Meisyou807;
        //public string Meisyou808;
        //public string Meisyou809;
        ////9-Stream2
        //public string Meisyou810;
        //public string Meisyou811;
        //public string Meisyou812;
        //public string Meisyou813;
        //public string Meisyou814;
        //public string Meisyou815;
        //public string Meisyou816;
        //public string Meisyou817;
        //public string Meisyou818;
        //public string Meisyou819;
        ////9-Stream3
        //public string Meisyou820;
        //public string Meisyou821;
        //public string Meisyou822;
        //public string Meisyou823;
        //public string Meisyou824;
        //public string Meisyou825;
        //public string Meisyou826;
        //public string Meisyou827;
        //public string Meisyou828;
        //public string Meisyou829;
        ////9-Stream4
        //public string Meisyou830;
        //public string Meisyou831;
        //public string Meisyou832;
        //public string Meisyou833;
        //public string Meisyou834;
        //public string Meisyou835;
        //public string Meisyou836;
        //public string Meisyou837;
        //public string Meisyou838;
        //public string Meisyou839;
        ////9-Stream5
        //public string Meisyou840;
        //public string Meisyou841;
        //public string Meisyou842;
        //public string Meisyou843;
        //public string Meisyou844;
        //public string Meisyou845;
        //public string Meisyou846;
        //public string Meisyou847;
        //public string Meisyou848;
        //public string Meisyou849;
        ////9-Stream6
        //public string Meisyou850;
        //public string Meisyou851;
        //public string Meisyou852;
        //public string Meisyou853;
        //public string Meisyou854;
        //public string Meisyou855;
        //public string Meisyou856;
        //public string Meisyou857;
        //public string Meisyou858;
        //public string Meisyou859;
        ////9-Stream7
        //public string Meisyou860;
        //public string Meisyou861;
        //public string Meisyou862;
        //public string Meisyou863;
        //public string Meisyou864;
        //public string Meisyou865;
        //public string Meisyou866;
        //public string Meisyou867;
        //public string Meisyou868;
        //public string Meisyou869;
        ////9-Stream8
        //public string Meisyou870;
        //public string Meisyou871;
        //public string Meisyou872;
        //public string Meisyou873;
        //public string Meisyou874;
        //public string Meisyou875;
        //public string Meisyou876;
        //public string Meisyou877;
        //public string Meisyou878;
        //public string Meisyou879;
        ////9-Stream9
        //public string Meisyou880;
        //public string Meisyou881;
        //public string Meisyou882;
        //public string Meisyou883;
        //public string Meisyou884;
        //public string Meisyou885;
        //public string Meisyou886;
        //public string Meisyou887;
        //public string Meisyou888;
        //public string Meisyou889;
        ////9-Stream10
        //public string Meisyou890;
        //public string Meisyou891;
        //public string Meisyou892;
        //public string Meisyou893;
        //public string Meisyou894;
        //public string Meisyou895;
        //public string Meisyou896;
        //public string Meisyou897;
        //public string Meisyou898;
        //public string Meisyou899;
        ////9-Stream11
        //public string Meisyou8A0;
        //public string Meisyou8A1;
        //public string Meisyou8A2;
        //public string Meisyou8A3;
        //public string Meisyou8A4;
        //public string Meisyou8A5;
        //public string Meisyou8A6;
        //public string Meisyou8A7;
        //public string Meisyou8A8;
        //public string Meisyou8A9;

        ////品種10
        ////10-Stream1
        //public string Meisyou900;
        //public string Meisyou901;
        //public string Meisyou902;
        //public string Meisyou903;
        //public string Meisyou904;
        //public string Meisyou905;
        //public string Meisyou906;
        //public string Meisyou907;
        //public string Meisyou908;
        //public string Meisyou909;
        ////10-Stream2
        //public string Meisyou910;
        //public string Meisyou911;
        //public string Meisyou912;
        //public string Meisyou913;
        //public string Meisyou914;
        //public string Meisyou915;
        //public string Meisyou916;
        //public string Meisyou917;
        //public string Meisyou918;
        //public string Meisyou919;
        ////10-Stream3
        //public string Meisyou920;
        //public string Meisyou921;
        //public string Meisyou922;
        //public string Meisyou923;
        //public string Meisyou924;
        //public string Meisyou925;
        //public string Meisyou926;
        //public string Meisyou927;
        //public string Meisyou928;
        //public string Meisyou929;
        ////10-Stream4
        //public string Meisyou930;
        //public string Meisyou931;
        //public string Meisyou932;
        //public string Meisyou933;
        //public string Meisyou934;
        //public string Meisyou935;
        //public string Meisyou936;
        //public string Meisyou937;
        //public string Meisyou938;
        //public string Meisyou939;
        ////10-Stream5
        //public string Meisyou940;
        //public string Meisyou941;
        //public string Meisyou942;
        //public string Meisyou943;
        //public string Meisyou944;
        //public string Meisyou945;
        //public string Meisyou946;
        //public string Meisyou947;
        //public string Meisyou948;
        //public string Meisyou949;
        ////10-Stream6
        //public string Meisyou950;
        //public string Meisyou951;
        //public string Meisyou952;
        //public string Meisyou953;
        //public string Meisyou954;
        //public string Meisyou955;
        //public string Meisyou956;
        //public string Meisyou957;
        //public string Meisyou958;
        //public string Meisyou959;
        ////10-Stream7
        //public string Meisyou960;
        //public string Meisyou961;
        //public string Meisyou962;
        //public string Meisyou963;
        //public string Meisyou964;
        //public string Meisyou965;
        //public string Meisyou966;
        //public string Meisyou967;
        //public string Meisyou968;
        //public string Meisyou969;
        ////10-Stream8
        //public string Meisyou970;
        //public string Meisyou971;
        //public string Meisyou972;
        //public string Meisyou973;
        //public string Meisyou974;
        //public string Meisyou975;
        //public string Meisyou976;
        //public string Meisyou977;
        //public string Meisyou978;
        //public string Meisyou979;
        ////10-Stream9
        //public string Meisyou980;
        //public string Meisyou981;
        //public string Meisyou982;
        //public string Meisyou983;
        //public string Meisyou984;
        //public string Meisyou985;
        //public string Meisyou986;
        //public string Meisyou987;
        //public string Meisyou988;
        //public string Meisyou989;
        ////10-Stream10
        //public string Meisyou990;
        //public string Meisyou991;
        //public string Meisyou992;
        //public string Meisyou993;
        //public string Meisyou994;
        //public string Meisyou995;
        //public string Meisyou996;
        //public string Meisyou997;
        //public string Meisyou998;
        //public string Meisyou999;
        ////10-Stream11
        //public string Meisyou9A0;
        //public string Meisyou9A1;
        //public string Meisyou9A2;
        //public string Meisyou9A3;
        //public string Meisyou9A4;
        //public string Meisyou9A5;
        //public string Meisyou9A6;
        //public string Meisyou9A7;
        //public string Meisyou9A8;
        //public string Meisyou9A9;

        ////ADD_END :2021/11/23 kitayama 理由：検査名称を追加

        ////ADD_START :2021/11/27 kitayama 理由：Streamの名称を格納する処理を追加
        ////品種1
        //public string S_meisyou00;
        //public string S_meisyou01;
        //public string S_meisyou02;
        //public string S_meisyou03;
        //public string S_meisyou04;
        //public string S_meisyou05;
        //public string S_meisyou06;
        //public string S_meisyou07;
        //public string S_meisyou08;
        //public string S_meisyou09;
        //public string S_meisyou0A;

        ////品種2
        //public string S_meisyou10;
        //public string S_meisyou11;
        //public string S_meisyou12;
        //public string S_meisyou13;
        //public string S_meisyou14;
        //public string S_meisyou15;
        //public string S_meisyou16;
        //public string S_meisyou17;
        //public string S_meisyou18;
        //public string S_meisyou19;
        //public string S_meisyou1A;

        ////品種3
        //public string S_meisyou20;
        //public string S_meisyou21;
        //public string S_meisyou22;
        //public string S_meisyou23;
        //public string S_meisyou24;
        //public string S_meisyou25;
        //public string S_meisyou26;
        //public string S_meisyou27;
        //public string S_meisyou28;
        //public string S_meisyou29;
        //public string S_meisyou2A;

        ////品種4
        //public string S_meisyou30;
        //public string S_meisyou31;
        //public string S_meisyou32;
        //public string S_meisyou33;
        //public string S_meisyou34;
        //public string S_meisyou35;
        //public string S_meisyou36;
        //public string S_meisyou37;
        //public string S_meisyou38;
        //public string S_meisyou39;
        //public string S_meisyou3A;

        ////品種5
        //public string S_meisyou40;
        //public string S_meisyou41;
        //public string S_meisyou42;
        //public string S_meisyou43;
        //public string S_meisyou44;
        //public string S_meisyou45;
        //public string S_meisyou46;
        //public string S_meisyou47;
        //public string S_meisyou48;
        //public string S_meisyou49;
        //public string S_meisyou4A;

        ////品種6
        //public string S_meisyou50;
        //public string S_meisyou51;
        //public string S_meisyou52;
        //public string S_meisyou53;
        //public string S_meisyou54;
        //public string S_meisyou55;
        //public string S_meisyou56;
        //public string S_meisyou57;
        //public string S_meisyou58;
        //public string S_meisyou59;
        //public string S_meisyou5A;

        ////品種7
        //public string S_meisyou60;
        //public string S_meisyou61;
        //public string S_meisyou62;
        //public string S_meisyou63;
        //public string S_meisyou64;
        //public string S_meisyou65;
        //public string S_meisyou66;
        //public string S_meisyou67;
        //public string S_meisyou68;
        //public string S_meisyou69;
        //public string S_meisyou6A;

        ////品種8
        //public string S_meisyou70;
        //public string S_meisyou71;
        //public string S_meisyou72;
        //public string S_meisyou73;
        //public string S_meisyou74;
        //public string S_meisyou75;
        //public string S_meisyou76;
        //public string S_meisyou77;
        //public string S_meisyou78;
        //public string S_meisyou79;
        //public string S_meisyou7A;

        ////品種9
        //public string S_meisyou80;
        //public string S_meisyou81;
        //public string S_meisyou82;
        //public string S_meisyou83;
        //public string S_meisyou84;
        //public string S_meisyou85;
        //public string S_meisyou86;
        //public string S_meisyou87;
        //public string S_meisyou88;
        //public string S_meisyou89;
        //public string S_meisyou8A;

        ////品種10
        //public string S_meisyou90;
        //public string S_meisyou91;
        //public string S_meisyou92;
        //public string S_meisyou93;
        //public string S_meisyou94;
        //public string S_meisyou95;
        //public string S_meisyou96;
        //public string S_meisyou97;
        //public string S_meisyou98;
        //public string S_meisyou99;
        //public string S_meisyou9A;

        ////ADD_END :2021/11/27 kitayama 理由：Streamの名称を格納する処理を追加
        //DELETE_END :2021/12/19 kitayama 理由：名称は使用しないので削除

        /////////////////////////////////////////////////////////////////////////////
        ///                     撮影回数　パラメタ
        /////////////////////////////////////////////////////////////////////////////

        //DELETE_START :2021/11/23 kitayama 理由：複数Streamに対応するため削除
        ////ADD_START :2021/11/14 kitayama 理由：閾値の上限下限を格納する配列を追加
        ////閾値の上限を格納する
        //public double dThreshold_u00;
        //public double dThreshold_u01;
        //public double dThreshold_u02;
        //public double dThreshold_u03;
        //public double dThreshold_u04;
        //public double dThreshold_u05;
        //public double dThreshold_u06;
        //public double dThreshold_u07;
        //public double dThreshold_u08;
        //public double dThreshold_u09;
        //public double dThreshold_u10;
        //public double dThreshold_u11;
        //public double dThreshold_u12;
        //public double dThreshold_u13;
        //public double dThreshold_u14;
        //public double dThreshold_u15;
        //public double dThreshold_u16;
        //public double dThreshold_u17;
        //public double dThreshold_u18;
        //public double dThreshold_u19;
        //public double dThreshold_u20;
        //public double dThreshold_u21;
        //public double dThreshold_u22;
        //public double dThreshold_u23;
        //public double dThreshold_u24;
        //public double dThreshold_u25;
        //public double dThreshold_u26;
        //public double dThreshold_u27;
        //public double dThreshold_u28;
        //public double dThreshold_u29;
        //public double dThreshold_u30;
        //public double dThreshold_u31;
        //public double dThreshold_u32;
        //public double dThreshold_u33;
        //public double dThreshold_u34;
        //public double dThreshold_u35;
        //public double dThreshold_u36;
        //public double dThreshold_u37;
        //public double dThreshold_u38;
        //public double dThreshold_u39;
        //public double dThreshold_u40;
        //public double dThreshold_u41;
        //public double dThreshold_u42;
        //public double dThreshold_u43;
        //public double dThreshold_u44;
        //public double dThreshold_u45;
        //public double dThreshold_u46;
        //public double dThreshold_u47;
        //public double dThreshold_u48;
        //public double dThreshold_u49;
        //public double dThreshold_u50;
        //public double dThreshold_u51;
        //public double dThreshold_u52;
        //public double dThreshold_u53;
        //public double dThreshold_u54;
        //public double dThreshold_u55;
        //public double dThreshold_u56;
        //public double dThreshold_u57;
        //public double dThreshold_u58;
        //public double dThreshold_u59;
        //public double dThreshold_u60;
        //public double dThreshold_u61;
        //public double dThreshold_u62;
        //public double dThreshold_u63;
        //public double dThreshold_u64;
        //public double dThreshold_u65;
        //public double dThreshold_u66;
        //public double dThreshold_u67;
        //public double dThreshold_u68;
        //public double dThreshold_u69;
        //public double dThreshold_u70;
        //public double dThreshold_u71;
        //public double dThreshold_u72;
        //public double dThreshold_u73;
        //public double dThreshold_u74;
        //public double dThreshold_u75;
        //public double dThreshold_u76;
        //public double dThreshold_u77;
        //public double dThreshold_u78;
        //public double dThreshold_u79;
        //public double dThreshold_u80;
        //public double dThreshold_u81;
        //public double dThreshold_u82;
        //public double dThreshold_u83;
        //public double dThreshold_u84;
        //public double dThreshold_u85;
        //public double dThreshold_u86;
        //public double dThreshold_u87;
        //public double dThreshold_u88;
        //public double dThreshold_u89;
        //public double dThreshold_u90;
        //public double dThreshold_u91;
        //public double dThreshold_u92;
        //public double dThreshold_u93;
        //public double dThreshold_u94;
        //public double dThreshold_u95;
        //public double dThreshold_u96;
        //public double dThreshold_u97;
        //public double dThreshold_u98;
        //public double dThreshold_u99;
        ////閾値の下限を格納する
        //public double dThreshold_l00;
        //public double dThreshold_l01;
        //public double dThreshold_l02;
        //public double dThreshold_l03;
        //public double dThreshold_l04;
        //public double dThreshold_l05;
        //public double dThreshold_l06;
        //public double dThreshold_l07;
        //public double dThreshold_l08;
        //public double dThreshold_l09;
        //public double dThreshold_l10;
        //public double dThreshold_l11;
        //public double dThreshold_l12;
        //public double dThreshold_l13;
        //public double dThreshold_l14;
        //public double dThreshold_l15;
        //public double dThreshold_l16;
        //public double dThreshold_l17;
        //public double dThreshold_l18;
        //public double dThreshold_l19;
        //public double dThreshold_l20;
        //public double dThreshold_l21;
        //public double dThreshold_l22;
        //public double dThreshold_l23;
        //public double dThreshold_l24;
        //public double dThreshold_l25;
        //public double dThreshold_l26;
        //public double dThreshold_l27;
        //public double dThreshold_l28;
        //public double dThreshold_l29;
        //public double dThreshold_l30;
        //public double dThreshold_l31;
        //public double dThreshold_l32;
        //public double dThreshold_l33;
        //public double dThreshold_l34;
        //public double dThreshold_l35;
        //public double dThreshold_l36;
        //public double dThreshold_l37;
        //public double dThreshold_l38;
        //public double dThreshold_l39;
        //public double dThreshold_l40;
        //public double dThreshold_l41;
        //public double dThreshold_l42;
        //public double dThreshold_l43;
        //public double dThreshold_l44;
        //public double dThreshold_l45;
        //public double dThreshold_l46;
        //public double dThreshold_l47;
        //public double dThreshold_l48;
        //public double dThreshold_l49;
        //public double dThreshold_l50;
        //public double dThreshold_l51;
        //public double dThreshold_l52;
        //public double dThreshold_l53;
        //public double dThreshold_l54;
        //public double dThreshold_l55;
        //public double dThreshold_l56;
        //public double dThreshold_l57;
        //public double dThreshold_l58;
        //public double dThreshold_l59;
        //public double dThreshold_l60;
        //public double dThreshold_l61;
        //public double dThreshold_l62;
        //public double dThreshold_l63;
        //public double dThreshold_l64;
        //public double dThreshold_l65;
        //public double dThreshold_l66;
        //public double dThreshold_l67;
        //public double dThreshold_l68;
        //public double dThreshold_l69;
        //public double dThreshold_l70;
        //public double dThreshold_l71;
        //public double dThreshold_l72;
        //public double dThreshold_l73;
        //public double dThreshold_l74;
        //public double dThreshold_l75;
        //public double dThreshold_l76;
        //public double dThreshold_l77;
        //public double dThreshold_l78;
        //public double dThreshold_l79;
        //public double dThreshold_l80;
        //public double dThreshold_l81;
        //public double dThreshold_l82;
        //public double dThreshold_l83;
        //public double dThreshold_l84;
        //public double dThreshold_l85;
        //public double dThreshold_l86;
        //public double dThreshold_l87;
        //public double dThreshold_l88;
        //public double dThreshold_l89;
        //public double dThreshold_l90;
        //public double dThreshold_l91;
        //public double dThreshold_l92;
        //public double dThreshold_l93;
        //public double dThreshold_l94;
        //public double dThreshold_l95;
        //public double dThreshold_l96;
        //public double dThreshold_l97;
        //public double dThreshold_l98;
        //public double dThreshold_l99;
        ////ADD_START :2021/11/14 kitayama 理由：閾値の上限下限を格納する配列を追加
        //DELETE_END :2021/11/23 kitayama 理由：複数Streamに対応するため削除

        //DELETE_START :2021/11/14 kitayama 理由：閾値の上限下限を格納する配列に変更するので削除
        ////ADD_START :2021/11/7 kitayama 理由：閾値の形式を変更したものを追加
        //public double dThreshold00;
        //public double dThreshold01;
        //public double dThreshold02;
        //public double dThreshold03;
        //public double dThreshold04;
        //public double dThreshold10;
        //public double dThreshold11;
        //public double dThreshold12;
        //public double dThreshold13;
        //public double dThreshold14;
        //public double dThreshold20;
        //public double dThreshold21;
        //public double dThreshold22;
        //public double dThreshold23;
        //public double dThreshold24;
        //public double dThreshold30;
        //public double dThreshold31;
        //public double dThreshold32;
        //public double dThreshold33;
        //public double dThreshold34;
        //public double dThreshold40;
        //public double dThreshold41;
        //public double dThreshold42;
        //public double dThreshold43;
        //public double dThreshold44;
        //public double dThreshold50;
        //public double dThreshold51;
        //public double dThreshold52;
        //public double dThreshold53;
        //public double dThreshold54;
        //public double dThreshold60;
        //public double dThreshold61;
        //public double dThreshold62;
        //public double dThreshold63;
        //public double dThreshold64;
        //public double dThreshold70;
        //public double dThreshold71;
        //public double dThreshold72;
        //public double dThreshold73;
        //public double dThreshold74;
        //public double dThreshold80;
        //public double dThreshold81;
        //public double dThreshold82;
        //public double dThreshold83;
        //public double dThreshold84;
        //public double dThreshold90;
        //public double dThreshold91;
        //public double dThreshold92;
        //public double dThreshold93;
        //public double dThreshold94;
        ////ADD_END :2021/11/7 kitayama 理由：閾値の形式を変更したものを追加
        //DELETE_END :2021/11/14 kitayama 理由：閾値の上限下限を格納する配列に変更するので削除


        //ADD_START :2020/4/27 kitayama 理由：改造に合わせたしきい値を設定するため追加
        //品種1の設定
        //1-Stream1
        public double dThreshold_u000;
        public double dThreshold_u001;
        public double dThreshold_u002;
        public double dThreshold_u003;
        public double dThreshold_u004;
        public double dThreshold_u005;
        public double dThreshold_u006;
        public double dThreshold_u007;
        public double dThreshold_u008;
        public double dThreshold_u009;

        public double dThreshold_l000;
        public double dThreshold_l001;
        public double dThreshold_l002;
        public double dThreshold_l003;
        public double dThreshold_l004;
        public double dThreshold_l005;
        public double dThreshold_l006;
        public double dThreshold_l007;
        public double dThreshold_l008;
        public double dThreshold_l009;
        //1-Stream2
        public double dThreshold_u010;
        public double dThreshold_u011;
        public double dThreshold_u012;
        public double dThreshold_u013;
        public double dThreshold_u014;
        public double dThreshold_u015;
        public double dThreshold_u016;
        public double dThreshold_u017;
        public double dThreshold_u018;
        public double dThreshold_u019;

        public double dThreshold_l010;
        public double dThreshold_l011;
        public double dThreshold_l012;
        public double dThreshold_l013;
        public double dThreshold_l014;
        public double dThreshold_l015;
        public double dThreshold_l016;
        public double dThreshold_l017;
        public double dThreshold_l018;
        public double dThreshold_l019;
        //1-Stream3
        public double dThreshold_u020;
        public double dThreshold_u021;
        public double dThreshold_u022;
        public double dThreshold_u023;
        public double dThreshold_u024;
        public double dThreshold_u025;
        public double dThreshold_u026;
        public double dThreshold_u027;
        public double dThreshold_u028;
        public double dThreshold_u029;

        public double dThreshold_l020;
        public double dThreshold_l021;
        public double dThreshold_l022;
        public double dThreshold_l023;
        public double dThreshold_l024;
        public double dThreshold_l025;
        public double dThreshold_l026;
        public double dThreshold_l027;
        public double dThreshold_l028;
        public double dThreshold_l029;
        //1-Stream4
        public double dThreshold_u030;
        public double dThreshold_u031;
        public double dThreshold_u032;
        public double dThreshold_u033;
        public double dThreshold_u034;
        public double dThreshold_u035;
        public double dThreshold_u036;
        public double dThreshold_u037;
        public double dThreshold_u038;
        public double dThreshold_u039;

        public double dThreshold_l030;
        public double dThreshold_l031;
        public double dThreshold_l032;
        public double dThreshold_l033;
        public double dThreshold_l034;
        public double dThreshold_l035;
        public double dThreshold_l036;
        public double dThreshold_l037;
        public double dThreshold_l038;
        public double dThreshold_l039;
        //1-Stream5
        public double dThreshold_u040;
        public double dThreshold_u041;
        public double dThreshold_u042;
        public double dThreshold_u043;
        public double dThreshold_u044;
        public double dThreshold_u045;
        public double dThreshold_u046;
        public double dThreshold_u047;
        public double dThreshold_u048;
        public double dThreshold_u049;

        public double dThreshold_l040;
        public double dThreshold_l041;
        public double dThreshold_l042;
        public double dThreshold_l043;
        public double dThreshold_l044;
        public double dThreshold_l045;
        public double dThreshold_l046;
        public double dThreshold_l047;
        public double dThreshold_l048;
        public double dThreshold_l049;
        //1-Stream6
        public double dThreshold_u050;
        public double dThreshold_u051;
        public double dThreshold_u052;
        public double dThreshold_u053;
        public double dThreshold_u054;
        public double dThreshold_u055;
        public double dThreshold_u056;
        public double dThreshold_u057;
        public double dThreshold_u058;
        public double dThreshold_u059;

        public double dThreshold_l050;
        public double dThreshold_l051;
        public double dThreshold_l052;
        public double dThreshold_l053;
        public double dThreshold_l054;
        public double dThreshold_l055;
        public double dThreshold_l056;
        public double dThreshold_l057;
        public double dThreshold_l058;
        public double dThreshold_l059;
        //1-Stream7
        public double dThreshold_u060;
        public double dThreshold_u061;
        public double dThreshold_u062;
        public double dThreshold_u063;
        public double dThreshold_u064;
        public double dThreshold_u065;
        public double dThreshold_u066;
        public double dThreshold_u067;
        public double dThreshold_u068;
        public double dThreshold_u069;

        public double dThreshold_l060;
        public double dThreshold_l061;
        public double dThreshold_l062;
        public double dThreshold_l063;
        public double dThreshold_l064;
        public double dThreshold_l065;
        public double dThreshold_l066;
        public double dThreshold_l067;
        public double dThreshold_l068;
        public double dThreshold_l069;
        //1-Stream8
        public double dThreshold_u070;
        public double dThreshold_u071;
        public double dThreshold_u072;
        public double dThreshold_u073;
        public double dThreshold_u074;
        public double dThreshold_u075;
        public double dThreshold_u076;
        public double dThreshold_u077;
        public double dThreshold_u078;
        public double dThreshold_u079;

        public double dThreshold_l070;
        public double dThreshold_l071;
        public double dThreshold_l072;
        public double dThreshold_l073;
        public double dThreshold_l074;
        public double dThreshold_l075;
        public double dThreshold_l076;
        public double dThreshold_l077;
        public double dThreshold_l078;
        public double dThreshold_l079;
        //1-Stream9
        public double dThreshold_u080;
        public double dThreshold_u081;
        public double dThreshold_u082;
        public double dThreshold_u083;
        public double dThreshold_u084;
        public double dThreshold_u085;
        public double dThreshold_u086;
        public double dThreshold_u087;
        public double dThreshold_u088;
        public double dThreshold_u089;

        public double dThreshold_l080;
        public double dThreshold_l081;
        public double dThreshold_l082;
        public double dThreshold_l083;
        public double dThreshold_l084;
        public double dThreshold_l085;
        public double dThreshold_l086;
        public double dThreshold_l087;
        public double dThreshold_l088;
        public double dThreshold_l089;
        //1-Stream10
        public double dThreshold_u090;
        public double dThreshold_u091;
        public double dThreshold_u092;
        public double dThreshold_u093;
        public double dThreshold_u094;
        public double dThreshold_u095;
        public double dThreshold_u096;
        public double dThreshold_u097;
        public double dThreshold_u098;
        public double dThreshold_u099;

        public double dThreshold_l090;
        public double dThreshold_l091;
        public double dThreshold_l092;
        public double dThreshold_l093;
        public double dThreshold_l094;
        public double dThreshold_l095;
        public double dThreshold_l096;
        public double dThreshold_l097;
        public double dThreshold_l098;
        public double dThreshold_l099;
        //1-Stream11
        public double dThreshold_u0A0;
        public double dThreshold_u0A1;
        public double dThreshold_u0A2;
        public double dThreshold_u0A3;
        public double dThreshold_u0A4;
        public double dThreshold_u0A5;
        public double dThreshold_u0A6;
        public double dThreshold_u0A7;
        public double dThreshold_u0A8;
        public double dThreshold_u0A9;

        public double dThreshold_l0A0;
        public double dThreshold_l0A1;
        public double dThreshold_l0A2;
        public double dThreshold_l0A3;
        public double dThreshold_l0A4;
        public double dThreshold_l0A5;
        public double dThreshold_l0A6;
        public double dThreshold_l0A7;
        public double dThreshold_l0A8;
        public double dThreshold_l0A9;

        //品種2の設定
        //2-Stream1
        public double dThreshold_u100;
        public double dThreshold_u101;
        public double dThreshold_u102;
        public double dThreshold_u103;
        public double dThreshold_u104;
        public double dThreshold_u105;
        public double dThreshold_u106;
        public double dThreshold_u107;
        public double dThreshold_u108;
        public double dThreshold_u109;

        public double dThreshold_l100;
        public double dThreshold_l101;
        public double dThreshold_l102;
        public double dThreshold_l103;
        public double dThreshold_l104;
        public double dThreshold_l105;
        public double dThreshold_l106;
        public double dThreshold_l107;
        public double dThreshold_l108;
        public double dThreshold_l109;
        //2-Stream2
        public double dThreshold_u110;
        public double dThreshold_u111;
        public double dThreshold_u112;
        public double dThreshold_u113;
        public double dThreshold_u114;
        public double dThreshold_u115;
        public double dThreshold_u116;
        public double dThreshold_u117;
        public double dThreshold_u118;
        public double dThreshold_u119;

        public double dThreshold_l110;
        public double dThreshold_l111;
        public double dThreshold_l112;
        public double dThreshold_l113;
        public double dThreshold_l114;
        public double dThreshold_l115;
        public double dThreshold_l116;
        public double dThreshold_l117;
        public double dThreshold_l118;
        public double dThreshold_l119;
        //2-Stream3
        public double dThreshold_u120;
        public double dThreshold_u121;
        public double dThreshold_u122;
        public double dThreshold_u123;
        public double dThreshold_u124;
        public double dThreshold_u125;
        public double dThreshold_u126;
        public double dThreshold_u127;
        public double dThreshold_u128;
        public double dThreshold_u129;

        public double dThreshold_l120;
        public double dThreshold_l121;
        public double dThreshold_l122;
        public double dThreshold_l123;
        public double dThreshold_l124;
        public double dThreshold_l125;
        public double dThreshold_l126;
        public double dThreshold_l127;
        public double dThreshold_l128;
        public double dThreshold_l129;
        //2-Stream4
        public double dThreshold_u130;
        public double dThreshold_u131;
        public double dThreshold_u132;
        public double dThreshold_u133;
        public double dThreshold_u134;
        public double dThreshold_u135;
        public double dThreshold_u136;
        public double dThreshold_u137;
        public double dThreshold_u138;
        public double dThreshold_u139;

        public double dThreshold_l130;
        public double dThreshold_l131;
        public double dThreshold_l132;
        public double dThreshold_l133;
        public double dThreshold_l134;
        public double dThreshold_l135;
        public double dThreshold_l136;
        public double dThreshold_l137;
        public double dThreshold_l138;
        public double dThreshold_l139;
        //2-Stream5
        public double dThreshold_u140;
        public double dThreshold_u141;
        public double dThreshold_u142;
        public double dThreshold_u143;
        public double dThreshold_u144;
        public double dThreshold_u145;
        public double dThreshold_u146;
        public double dThreshold_u147;
        public double dThreshold_u148;
        public double dThreshold_u149;

        public double dThreshold_l140;
        public double dThreshold_l141;
        public double dThreshold_l142;
        public double dThreshold_l143;
        public double dThreshold_l144;
        public double dThreshold_l145;
        public double dThreshold_l146;
        public double dThreshold_l147;
        public double dThreshold_l148;
        public double dThreshold_l149;
        //2-Stream6
        public double dThreshold_u150;
        public double dThreshold_u151;
        public double dThreshold_u152;
        public double dThreshold_u153;
        public double dThreshold_u154;
        public double dThreshold_u155;
        public double dThreshold_u156;
        public double dThreshold_u157;
        public double dThreshold_u158;
        public double dThreshold_u159;

        public double dThreshold_l150;
        public double dThreshold_l151;
        public double dThreshold_l152;
        public double dThreshold_l153;
        public double dThreshold_l154;
        public double dThreshold_l155;
        public double dThreshold_l156;
        public double dThreshold_l157;
        public double dThreshold_l158;
        public double dThreshold_l159;
        //2-Stream7
        public double dThreshold_u160;
        public double dThreshold_u161;
        public double dThreshold_u162;
        public double dThreshold_u163;
        public double dThreshold_u164;
        public double dThreshold_u165;
        public double dThreshold_u166;
        public double dThreshold_u167;
        public double dThreshold_u168;
        public double dThreshold_u169;

        public double dThreshold_l160;
        public double dThreshold_l161;
        public double dThreshold_l162;
        public double dThreshold_l163;
        public double dThreshold_l164;
        public double dThreshold_l165;
        public double dThreshold_l166;
        public double dThreshold_l167;
        public double dThreshold_l168;
        public double dThreshold_l169;
        //2-Stream8
        public double dThreshold_u170;
        public double dThreshold_u171;
        public double dThreshold_u172;
        public double dThreshold_u173;
        public double dThreshold_u174;
        public double dThreshold_u175;
        public double dThreshold_u176;
        public double dThreshold_u177;
        public double dThreshold_u178;
        public double dThreshold_u179;

        public double dThreshold_l170;
        public double dThreshold_l171;
        public double dThreshold_l172;
        public double dThreshold_l173;
        public double dThreshold_l174;
        public double dThreshold_l175;
        public double dThreshold_l176;
        public double dThreshold_l177;
        public double dThreshold_l178;
        public double dThreshold_l179;
        //2-Stream9
        public double dThreshold_u180;
        public double dThreshold_u181;
        public double dThreshold_u182;
        public double dThreshold_u183;
        public double dThreshold_u184;
        public double dThreshold_u185;
        public double dThreshold_u186;
        public double dThreshold_u187;
        public double dThreshold_u188;
        public double dThreshold_u189;

        public double dThreshold_l180;
        public double dThreshold_l181;
        public double dThreshold_l182;
        public double dThreshold_l183;
        public double dThreshold_l184;
        public double dThreshold_l185;
        public double dThreshold_l186;
        public double dThreshold_l187;
        public double dThreshold_l188;
        public double dThreshold_l189;
        //2-Stream10
        public double dThreshold_u190;
        public double dThreshold_u191;
        public double dThreshold_u192;
        public double dThreshold_u193;
        public double dThreshold_u194;
        public double dThreshold_u195;
        public double dThreshold_u196;
        public double dThreshold_u197;
        public double dThreshold_u198;
        public double dThreshold_u199;

        public double dThreshold_l190;
        public double dThreshold_l191;
        public double dThreshold_l192;
        public double dThreshold_l193;
        public double dThreshold_l194;
        public double dThreshold_l195;
        public double dThreshold_l196;
        public double dThreshold_l197;
        public double dThreshold_l198;
        public double dThreshold_l199;
        //2-Stream11
        public double dThreshold_u1A0;
        public double dThreshold_u1A1;
        public double dThreshold_u1A2;
        public double dThreshold_u1A3;
        public double dThreshold_u1A4;
        public double dThreshold_u1A5;
        public double dThreshold_u1A6;
        public double dThreshold_u1A7;
        public double dThreshold_u1A8;
        public double dThreshold_u1A9;

        public double dThreshold_l1A0;
        public double dThreshold_l1A1;
        public double dThreshold_l1A2;
        public double dThreshold_l1A3;
        public double dThreshold_l1A4;
        public double dThreshold_l1A5;
        public double dThreshold_l1A6;
        public double dThreshold_l1A7;
        public double dThreshold_l1A8;
        public double dThreshold_l1A9;

        //品種3の設定
        //3-Stream1
        public double dThreshold_u200;
        public double dThreshold_u201;
        public double dThreshold_u202;
        public double dThreshold_u203;
        public double dThreshold_u204;
        public double dThreshold_u205;
        public double dThreshold_u206;
        public double dThreshold_u207;
        public double dThreshold_u208;
        public double dThreshold_u209;

        public double dThreshold_l200;
        public double dThreshold_l201;
        public double dThreshold_l202;
        public double dThreshold_l203;
        public double dThreshold_l204;
        public double dThreshold_l205;
        public double dThreshold_l206;
        public double dThreshold_l207;
        public double dThreshold_l208;
        public double dThreshold_l209;
        //3-Stream2
        public double dThreshold_u210;
        public double dThreshold_u211;
        public double dThreshold_u212;
        public double dThreshold_u213;
        public double dThreshold_u214;
        public double dThreshold_u215;
        public double dThreshold_u216;
        public double dThreshold_u217;
        public double dThreshold_u218;
        public double dThreshold_u219;

        public double dThreshold_l210;
        public double dThreshold_l211;
        public double dThreshold_l212;
        public double dThreshold_l213;
        public double dThreshold_l214;
        public double dThreshold_l215;
        public double dThreshold_l216;
        public double dThreshold_l217;
        public double dThreshold_l218;
        public double dThreshold_l219;
        //3-Stream3
        public double dThreshold_u220;
        public double dThreshold_u221;
        public double dThreshold_u222;
        public double dThreshold_u223;
        public double dThreshold_u224;
        public double dThreshold_u225;
        public double dThreshold_u226;
        public double dThreshold_u227;
        public double dThreshold_u228;
        public double dThreshold_u229;

        public double dThreshold_l220;
        public double dThreshold_l221;
        public double dThreshold_l222;
        public double dThreshold_l223;
        public double dThreshold_l224;
        public double dThreshold_l225;
        public double dThreshold_l226;
        public double dThreshold_l227;
        public double dThreshold_l228;
        public double dThreshold_l229;
        //3-Stream4
        public double dThreshold_u230;
        public double dThreshold_u231;
        public double dThreshold_u232;
        public double dThreshold_u233;
        public double dThreshold_u234;
        public double dThreshold_u235;
        public double dThreshold_u236;
        public double dThreshold_u237;
        public double dThreshold_u238;
        public double dThreshold_u239;

        public double dThreshold_l230;
        public double dThreshold_l231;
        public double dThreshold_l232;
        public double dThreshold_l233;
        public double dThreshold_l234;
        public double dThreshold_l235;
        public double dThreshold_l236;
        public double dThreshold_l237;
        public double dThreshold_l238;
        public double dThreshold_l239;
        //3-Stream5
        public double dThreshold_u240;
        public double dThreshold_u241;
        public double dThreshold_u242;
        public double dThreshold_u243;
        public double dThreshold_u244;
        public double dThreshold_u245;
        public double dThreshold_u246;
        public double dThreshold_u247;
        public double dThreshold_u248;
        public double dThreshold_u249;

        public double dThreshold_l240;
        public double dThreshold_l241;
        public double dThreshold_l242;
        public double dThreshold_l243;
        public double dThreshold_l244;
        public double dThreshold_l245;
        public double dThreshold_l246;
        public double dThreshold_l247;
        public double dThreshold_l248;
        public double dThreshold_l249;
        //3-Stream6
        public double dThreshold_u250;
        public double dThreshold_u251;
        public double dThreshold_u252;
        public double dThreshold_u253;
        public double dThreshold_u254;
        public double dThreshold_u255;
        public double dThreshold_u256;
        public double dThreshold_u257;
        public double dThreshold_u258;
        public double dThreshold_u259;

        public double dThreshold_l250;
        public double dThreshold_l251;
        public double dThreshold_l252;
        public double dThreshold_l253;
        public double dThreshold_l254;
        public double dThreshold_l255;
        public double dThreshold_l256;
        public double dThreshold_l257;
        public double dThreshold_l258;
        public double dThreshold_l259;
        //3-Stream7
        public double dThreshold_u260;
        public double dThreshold_u261;
        public double dThreshold_u262;
        public double dThreshold_u263;
        public double dThreshold_u264;
        public double dThreshold_u265;
        public double dThreshold_u266;
        public double dThreshold_u267;
        public double dThreshold_u268;
        public double dThreshold_u269;

        public double dThreshold_l260;
        public double dThreshold_l261;
        public double dThreshold_l262;
        public double dThreshold_l263;
        public double dThreshold_l264;
        public double dThreshold_l265;
        public double dThreshold_l266;
        public double dThreshold_l267;
        public double dThreshold_l268;
        public double dThreshold_l269;
        //3-Stream8
        public double dThreshold_u270;
        public double dThreshold_u271;
        public double dThreshold_u272;
        public double dThreshold_u273;
        public double dThreshold_u274;
        public double dThreshold_u275;
        public double dThreshold_u276;
        public double dThreshold_u277;
        public double dThreshold_u278;
        public double dThreshold_u279;

        public double dThreshold_l270;
        public double dThreshold_l271;
        public double dThreshold_l272;
        public double dThreshold_l273;
        public double dThreshold_l274;
        public double dThreshold_l275;
        public double dThreshold_l276;
        public double dThreshold_l277;
        public double dThreshold_l278;
        public double dThreshold_l279;
        //3-Stream9
        public double dThreshold_u280;
        public double dThreshold_u281;
        public double dThreshold_u282;
        public double dThreshold_u283;
        public double dThreshold_u284;
        public double dThreshold_u285;
        public double dThreshold_u286;
        public double dThreshold_u287;
        public double dThreshold_u288;
        public double dThreshold_u289;

        public double dThreshold_l280;
        public double dThreshold_l281;
        public double dThreshold_l282;
        public double dThreshold_l283;
        public double dThreshold_l284;
        public double dThreshold_l285;
        public double dThreshold_l286;
        public double dThreshold_l287;
        public double dThreshold_l288;
        public double dThreshold_l289;
        //3-Stream10
        public double dThreshold_u290;
        public double dThreshold_u291;
        public double dThreshold_u292;
        public double dThreshold_u293;
        public double dThreshold_u294;
        public double dThreshold_u295;
        public double dThreshold_u296;
        public double dThreshold_u297;
        public double dThreshold_u298;
        public double dThreshold_u299;

        public double dThreshold_l290;
        public double dThreshold_l291;
        public double dThreshold_l292;
        public double dThreshold_l293;
        public double dThreshold_l294;
        public double dThreshold_l295;
        public double dThreshold_l296;
        public double dThreshold_l297;
        public double dThreshold_l298;
        public double dThreshold_l299;
        //3-Stream11
        public double dThreshold_u2A0;
        public double dThreshold_u2A1;
        public double dThreshold_u2A2;
        public double dThreshold_u2A3;
        public double dThreshold_u2A4;
        public double dThreshold_u2A5;
        public double dThreshold_u2A6;
        public double dThreshold_u2A7;
        public double dThreshold_u2A8;
        public double dThreshold_u2A9;

        public double dThreshold_l2A0;
        public double dThreshold_l2A1;
        public double dThreshold_l2A2;
        public double dThreshold_l2A3;
        public double dThreshold_l2A4;
        public double dThreshold_l2A5;
        public double dThreshold_l2A6;
        public double dThreshold_l2A7;
        public double dThreshold_l2A8;
        public double dThreshold_l2A9;

        //品種4
        //4-Stream1
        public double dThreshold_u300;
        public double dThreshold_u301;
        public double dThreshold_u302;
        public double dThreshold_u303;
        public double dThreshold_u304;
        public double dThreshold_u305;
        public double dThreshold_u306;
        public double dThreshold_u307;
        public double dThreshold_u308;
        public double dThreshold_u309;

        public double dThreshold_l300;
        public double dThreshold_l301;
        public double dThreshold_l302;
        public double dThreshold_l303;
        public double dThreshold_l304;
        public double dThreshold_l305;
        public double dThreshold_l306;
        public double dThreshold_l307;
        public double dThreshold_l308;
        public double dThreshold_l309;
        //4-Stream2
        public double dThreshold_u310;
        public double dThreshold_u311;
        public double dThreshold_u312;
        public double dThreshold_u313;
        public double dThreshold_u314;
        public double dThreshold_u315;
        public double dThreshold_u316;
        public double dThreshold_u317;
        public double dThreshold_u318;
        public double dThreshold_u319;

        public double dThreshold_l310;
        public double dThreshold_l311;
        public double dThreshold_l312;
        public double dThreshold_l313;
        public double dThreshold_l314;
        public double dThreshold_l315;
        public double dThreshold_l316;
        public double dThreshold_l317;
        public double dThreshold_l318;
        public double dThreshold_l319;
        //4-Stream3
        public double dThreshold_u320;
        public double dThreshold_u321;
        public double dThreshold_u322;
        public double dThreshold_u323;
        public double dThreshold_u324;
        public double dThreshold_u325;
        public double dThreshold_u326;
        public double dThreshold_u327;
        public double dThreshold_u328;
        public double dThreshold_u329;

        public double dThreshold_l320;
        public double dThreshold_l321;
        public double dThreshold_l322;
        public double dThreshold_l323;
        public double dThreshold_l324;
        public double dThreshold_l325;
        public double dThreshold_l326;
        public double dThreshold_l327;
        public double dThreshold_l328;
        public double dThreshold_l329;
        //4-Stream4
        public double dThreshold_u330;
        public double dThreshold_u331;
        public double dThreshold_u332;
        public double dThreshold_u333;
        public double dThreshold_u334;
        public double dThreshold_u335;
        public double dThreshold_u336;
        public double dThreshold_u337;
        public double dThreshold_u338;
        public double dThreshold_u339;

        public double dThreshold_l330;
        public double dThreshold_l331;
        public double dThreshold_l332;
        public double dThreshold_l333;
        public double dThreshold_l334;
        public double dThreshold_l335;
        public double dThreshold_l336;
        public double dThreshold_l337;
        public double dThreshold_l338;
        public double dThreshold_l339;
        //4-Stream5
        public double dThreshold_u340;
        public double dThreshold_u341;
        public double dThreshold_u342;
        public double dThreshold_u343;
        public double dThreshold_u344;
        public double dThreshold_u345;
        public double dThreshold_u346;
        public double dThreshold_u347;
        public double dThreshold_u348;
        public double dThreshold_u349;

        public double dThreshold_l340;
        public double dThreshold_l341;
        public double dThreshold_l342;
        public double dThreshold_l343;
        public double dThreshold_l344;
        public double dThreshold_l345;
        public double dThreshold_l346;
        public double dThreshold_l347;
        public double dThreshold_l348;
        public double dThreshold_l349;
        //4-Stream6
        public double dThreshold_u350;
        public double dThreshold_u351;
        public double dThreshold_u352;
        public double dThreshold_u353;
        public double dThreshold_u354;
        public double dThreshold_u355;
        public double dThreshold_u356;
        public double dThreshold_u357;
        public double dThreshold_u358;
        public double dThreshold_u359;

        public double dThreshold_l350;
        public double dThreshold_l351;
        public double dThreshold_l352;
        public double dThreshold_l353;
        public double dThreshold_l354;
        public double dThreshold_l355;
        public double dThreshold_l356;
        public double dThreshold_l357;
        public double dThreshold_l358;
        public double dThreshold_l359;
        //4-Stream7
        public double dThreshold_u360;
        public double dThreshold_u361;
        public double dThreshold_u362;
        public double dThreshold_u363;
        public double dThreshold_u364;
        public double dThreshold_u365;
        public double dThreshold_u366;
        public double dThreshold_u367;
        public double dThreshold_u368;
        public double dThreshold_u369;

        public double dThreshold_l360;
        public double dThreshold_l361;
        public double dThreshold_l362;
        public double dThreshold_l363;
        public double dThreshold_l364;
        public double dThreshold_l365;
        public double dThreshold_l366;
        public double dThreshold_l367;
        public double dThreshold_l368;
        public double dThreshold_l369;
        //4-Stream8
        public double dThreshold_u370;
        public double dThreshold_u371;
        public double dThreshold_u372;
        public double dThreshold_u373;
        public double dThreshold_u374;
        public double dThreshold_u375;
        public double dThreshold_u376;
        public double dThreshold_u377;
        public double dThreshold_u378;
        public double dThreshold_u379;

        public double dThreshold_l370;
        public double dThreshold_l371;
        public double dThreshold_l372;
        public double dThreshold_l373;
        public double dThreshold_l374;
        public double dThreshold_l375;
        public double dThreshold_l376;
        public double dThreshold_l377;
        public double dThreshold_l378;
        public double dThreshold_l379;
        //4-Stream9
        public double dThreshold_u380;
        public double dThreshold_u381;
        public double dThreshold_u382;
        public double dThreshold_u383;
        public double dThreshold_u384;
        public double dThreshold_u385;
        public double dThreshold_u386;
        public double dThreshold_u387;
        public double dThreshold_u388;
        public double dThreshold_u389;

        public double dThreshold_l380;
        public double dThreshold_l381;
        public double dThreshold_l382;
        public double dThreshold_l383;
        public double dThreshold_l384;
        public double dThreshold_l385;
        public double dThreshold_l386;
        public double dThreshold_l387;
        public double dThreshold_l388;
        public double dThreshold_l389;
        //4-Stream10
        public double dThreshold_u390;
        public double dThreshold_u391;
        public double dThreshold_u392;
        public double dThreshold_u393;
        public double dThreshold_u394;
        public double dThreshold_u395;
        public double dThreshold_u396;
        public double dThreshold_u397;
        public double dThreshold_u398;
        public double dThreshold_u399;

        public double dThreshold_l390;
        public double dThreshold_l391;
        public double dThreshold_l392;
        public double dThreshold_l393;
        public double dThreshold_l394;
        public double dThreshold_l395;
        public double dThreshold_l396;
        public double dThreshold_l397;
        public double dThreshold_l398;
        public double dThreshold_l399;
        //4-Stream11
        public double dThreshold_u3A0;
        public double dThreshold_u3A1;
        public double dThreshold_u3A2;
        public double dThreshold_u3A3;
        public double dThreshold_u3A4;
        public double dThreshold_u3A5;
        public double dThreshold_u3A6;
        public double dThreshold_u3A7;
        public double dThreshold_u3A8;
        public double dThreshold_u3A9;

        public double dThreshold_l3A0;
        public double dThreshold_l3A1;
        public double dThreshold_l3A2;
        public double dThreshold_l3A3;
        public double dThreshold_l3A4;
        public double dThreshold_l3A5;
        public double dThreshold_l3A6;
        public double dThreshold_l3A7;
        public double dThreshold_l3A8;
        public double dThreshold_l3A9;

        //品種5
        //5-Stream1
        public double dThreshold_u400;
        public double dThreshold_u401;
        public double dThreshold_u402;
        public double dThreshold_u403;
        public double dThreshold_u404;
        public double dThreshold_u405;
        public double dThreshold_u406;
        public double dThreshold_u407;
        public double dThreshold_u408;
        public double dThreshold_u409;

        public double dThreshold_l400;
        public double dThreshold_l401;
        public double dThreshold_l402;
        public double dThreshold_l403;
        public double dThreshold_l404;
        public double dThreshold_l405;
        public double dThreshold_l406;
        public double dThreshold_l407;
        public double dThreshold_l408;
        public double dThreshold_l409;
        //5-Stream2
        public double dThreshold_u410;
        public double dThreshold_u411;
        public double dThreshold_u412;
        public double dThreshold_u413;
        public double dThreshold_u414;
        public double dThreshold_u415;
        public double dThreshold_u416;
        public double dThreshold_u417;
        public double dThreshold_u418;
        public double dThreshold_u419;

        public double dThreshold_l410;
        public double dThreshold_l411;
        public double dThreshold_l412;
        public double dThreshold_l413;
        public double dThreshold_l414;
        public double dThreshold_l415;
        public double dThreshold_l416;
        public double dThreshold_l417;
        public double dThreshold_l418;
        public double dThreshold_l419;
        //5-Stream3
        public double dThreshold_u420;
        public double dThreshold_u421;
        public double dThreshold_u422;
        public double dThreshold_u423;
        public double dThreshold_u424;
        public double dThreshold_u425;
        public double dThreshold_u426;
        public double dThreshold_u427;
        public double dThreshold_u428;
        public double dThreshold_u429;

        public double dThreshold_l420;
        public double dThreshold_l421;
        public double dThreshold_l422;
        public double dThreshold_l423;
        public double dThreshold_l424;
        public double dThreshold_l425;
        public double dThreshold_l426;
        public double dThreshold_l427;
        public double dThreshold_l428;
        public double dThreshold_l429;
        //5-Stream4
        public double dThreshold_u430;
        public double dThreshold_u431;
        public double dThreshold_u432;
        public double dThreshold_u433;
        public double dThreshold_u434;
        public double dThreshold_u435;
        public double dThreshold_u436;
        public double dThreshold_u437;
        public double dThreshold_u438;
        public double dThreshold_u439;

        public double dThreshold_l430;
        public double dThreshold_l431;
        public double dThreshold_l432;
        public double dThreshold_l433;
        public double dThreshold_l434;
        public double dThreshold_l435;
        public double dThreshold_l436;
        public double dThreshold_l437;
        public double dThreshold_l438;
        public double dThreshold_l439;
        //5-Stream5
        public double dThreshold_u440;
        public double dThreshold_u441;
        public double dThreshold_u442;
        public double dThreshold_u443;
        public double dThreshold_u444;
        public double dThreshold_u445;
        public double dThreshold_u446;
        public double dThreshold_u447;
        public double dThreshold_u448;
        public double dThreshold_u449;

        public double dThreshold_l440;
        public double dThreshold_l441;
        public double dThreshold_l442;
        public double dThreshold_l443;
        public double dThreshold_l444;
        public double dThreshold_l445;
        public double dThreshold_l446;
        public double dThreshold_l447;
        public double dThreshold_l448;
        public double dThreshold_l449;
        //5-Stream6
        public double dThreshold_u450;
        public double dThreshold_u451;
        public double dThreshold_u452;
        public double dThreshold_u453;
        public double dThreshold_u454;
        public double dThreshold_u455;
        public double dThreshold_u456;
        public double dThreshold_u457;
        public double dThreshold_u458;
        public double dThreshold_u459;

        public double dThreshold_l450;
        public double dThreshold_l451;
        public double dThreshold_l452;
        public double dThreshold_l453;
        public double dThreshold_l454;
        public double dThreshold_l455;
        public double dThreshold_l456;
        public double dThreshold_l457;
        public double dThreshold_l458;
        public double dThreshold_l459;
        //5-Stream7
        public double dThreshold_u460;
        public double dThreshold_u461;
        public double dThreshold_u462;
        public double dThreshold_u463;
        public double dThreshold_u464;
        public double dThreshold_u465;
        public double dThreshold_u466;
        public double dThreshold_u467;
        public double dThreshold_u468;
        public double dThreshold_u469;

        public double dThreshold_l460;
        public double dThreshold_l461;
        public double dThreshold_l462;
        public double dThreshold_l463;
        public double dThreshold_l464;
        public double dThreshold_l465;
        public double dThreshold_l466;
        public double dThreshold_l467;
        public double dThreshold_l468;
        public double dThreshold_l469;
        //5-Stream8
        public double dThreshold_u470;
        public double dThreshold_u471;
        public double dThreshold_u472;
        public double dThreshold_u473;
        public double dThreshold_u474;
        public double dThreshold_u475;
        public double dThreshold_u476;
        public double dThreshold_u477;
        public double dThreshold_u478;
        public double dThreshold_u479;

        public double dThreshold_l470;
        public double dThreshold_l471;
        public double dThreshold_l472;
        public double dThreshold_l473;
        public double dThreshold_l474;
        public double dThreshold_l475;
        public double dThreshold_l476;
        public double dThreshold_l477;
        public double dThreshold_l478;
        public double dThreshold_l479;
        //5-Stream9
        public double dThreshold_u480;
        public double dThreshold_u481;
        public double dThreshold_u482;
        public double dThreshold_u483;
        public double dThreshold_u484;
        public double dThreshold_u485;
        public double dThreshold_u486;
        public double dThreshold_u487;
        public double dThreshold_u488;
        public double dThreshold_u489;

        public double dThreshold_l480;
        public double dThreshold_l481;
        public double dThreshold_l482;
        public double dThreshold_l483;
        public double dThreshold_l484;
        public double dThreshold_l485;
        public double dThreshold_l486;
        public double dThreshold_l487;
        public double dThreshold_l488;
        public double dThreshold_l489;
        //5-Stream10
        public double dThreshold_u490;
        public double dThreshold_u491;
        public double dThreshold_u492;
        public double dThreshold_u493;
        public double dThreshold_u494;
        public double dThreshold_u495;
        public double dThreshold_u496;
        public double dThreshold_u497;
        public double dThreshold_u498;
        public double dThreshold_u499;

        public double dThreshold_l490;
        public double dThreshold_l491;
        public double dThreshold_l492;
        public double dThreshold_l493;
        public double dThreshold_l494;
        public double dThreshold_l495;
        public double dThreshold_l496;
        public double dThreshold_l497;
        public double dThreshold_l498;
        public double dThreshold_l499;
        //5-Stream11
        public double dThreshold_u4A0;
        public double dThreshold_u4A1;
        public double dThreshold_u4A2;
        public double dThreshold_u4A3;
        public double dThreshold_u4A4;
        public double dThreshold_u4A5;
        public double dThreshold_u4A6;
        public double dThreshold_u4A7;
        public double dThreshold_u4A8;
        public double dThreshold_u4A9;

        public double dThreshold_l4A0;
        public double dThreshold_l4A1;
        public double dThreshold_l4A2;
        public double dThreshold_l4A3;
        public double dThreshold_l4A4;
        public double dThreshold_l4A5;
        public double dThreshold_l4A6;
        public double dThreshold_l4A7;
        public double dThreshold_l4A8;
        public double dThreshold_l4A9;

        //品種6
        //6-Stream1
        public double dThreshold_u500;
        public double dThreshold_u501;
        public double dThreshold_u502;
        public double dThreshold_u503;
        public double dThreshold_u504;
        public double dThreshold_u505;
        public double dThreshold_u506;
        public double dThreshold_u507;
        public double dThreshold_u508;
        public double dThreshold_u509;

        public double dThreshold_l500;
        public double dThreshold_l501;
        public double dThreshold_l502;
        public double dThreshold_l503;
        public double dThreshold_l504;
        public double dThreshold_l505;
        public double dThreshold_l506;
        public double dThreshold_l507;
        public double dThreshold_l508;
        public double dThreshold_l509;
        //6-Stream2
        public double dThreshold_u510;
        public double dThreshold_u511;
        public double dThreshold_u512;
        public double dThreshold_u513;
        public double dThreshold_u514;
        public double dThreshold_u515;
        public double dThreshold_u516;
        public double dThreshold_u517;
        public double dThreshold_u518;
        public double dThreshold_u519;

        public double dThreshold_l510;
        public double dThreshold_l511;
        public double dThreshold_l512;
        public double dThreshold_l513;
        public double dThreshold_l514;
        public double dThreshold_l515;
        public double dThreshold_l516;
        public double dThreshold_l517;
        public double dThreshold_l518;
        public double dThreshold_l519;
        //6-Stream3
        public double dThreshold_u520;
        public double dThreshold_u521;
        public double dThreshold_u522;
        public double dThreshold_u523;
        public double dThreshold_u524;
        public double dThreshold_u525;
        public double dThreshold_u526;
        public double dThreshold_u527;
        public double dThreshold_u528;
        public double dThreshold_u529;

        public double dThreshold_l520;
        public double dThreshold_l521;
        public double dThreshold_l522;
        public double dThreshold_l523;
        public double dThreshold_l524;
        public double dThreshold_l525;
        public double dThreshold_l526;
        public double dThreshold_l527;
        public double dThreshold_l528;
        public double dThreshold_l529;
        //6-Stream4
        public double dThreshold_u530;
        public double dThreshold_u531;
        public double dThreshold_u532;
        public double dThreshold_u533;
        public double dThreshold_u534;
        public double dThreshold_u535;
        public double dThreshold_u536;
        public double dThreshold_u537;
        public double dThreshold_u538;
        public double dThreshold_u539;

        public double dThreshold_l530;
        public double dThreshold_l531;
        public double dThreshold_l532;
        public double dThreshold_l533;
        public double dThreshold_l534;
        public double dThreshold_l535;
        public double dThreshold_l536;
        public double dThreshold_l537;
        public double dThreshold_l538;
        public double dThreshold_l539;
        //6-Stream5
        public double dThreshold_u540;
        public double dThreshold_u541;
        public double dThreshold_u542;
        public double dThreshold_u543;
        public double dThreshold_u544;
        public double dThreshold_u545;
        public double dThreshold_u546;
        public double dThreshold_u547;
        public double dThreshold_u548;
        public double dThreshold_u549;

        public double dThreshold_l540;
        public double dThreshold_l541;
        public double dThreshold_l542;
        public double dThreshold_l543;
        public double dThreshold_l544;
        public double dThreshold_l545;
        public double dThreshold_l546;
        public double dThreshold_l547;
        public double dThreshold_l548;
        public double dThreshold_l549;
        //6-Stream6
        public double dThreshold_u550;
        public double dThreshold_u551;
        public double dThreshold_u552;
        public double dThreshold_u553;
        public double dThreshold_u554;
        public double dThreshold_u555;
        public double dThreshold_u556;
        public double dThreshold_u557;
        public double dThreshold_u558;
        public double dThreshold_u559;

        public double dThreshold_l550;
        public double dThreshold_l551;
        public double dThreshold_l552;
        public double dThreshold_l553;
        public double dThreshold_l554;
        public double dThreshold_l555;
        public double dThreshold_l556;
        public double dThreshold_l557;
        public double dThreshold_l558;
        public double dThreshold_l559;
        //6-Stream7
        public double dThreshold_u560;
        public double dThreshold_u561;
        public double dThreshold_u562;
        public double dThreshold_u563;
        public double dThreshold_u564;
        public double dThreshold_u565;
        public double dThreshold_u566;
        public double dThreshold_u567;
        public double dThreshold_u568;
        public double dThreshold_u569;

        public double dThreshold_l560;
        public double dThreshold_l561;
        public double dThreshold_l562;
        public double dThreshold_l563;
        public double dThreshold_l564;
        public double dThreshold_l565;
        public double dThreshold_l566;
        public double dThreshold_l567;
        public double dThreshold_l568;
        public double dThreshold_l569;
        //6-Stream8
        public double dThreshold_u570;
        public double dThreshold_u571;
        public double dThreshold_u572;
        public double dThreshold_u573;
        public double dThreshold_u574;
        public double dThreshold_u575;
        public double dThreshold_u576;
        public double dThreshold_u577;
        public double dThreshold_u578;
        public double dThreshold_u579;

        public double dThreshold_l570;
        public double dThreshold_l571;
        public double dThreshold_l572;
        public double dThreshold_l573;
        public double dThreshold_l574;
        public double dThreshold_l575;
        public double dThreshold_l576;
        public double dThreshold_l577;
        public double dThreshold_l578;
        public double dThreshold_l579;
        //6-Stream9
        public double dThreshold_u580;
        public double dThreshold_u581;
        public double dThreshold_u582;
        public double dThreshold_u583;
        public double dThreshold_u584;
        public double dThreshold_u585;
        public double dThreshold_u586;
        public double dThreshold_u587;
        public double dThreshold_u588;
        public double dThreshold_u589;

        public double dThreshold_l580;
        public double dThreshold_l581;
        public double dThreshold_l582;
        public double dThreshold_l583;
        public double dThreshold_l584;
        public double dThreshold_l585;
        public double dThreshold_l586;
        public double dThreshold_l587;
        public double dThreshold_l588;
        public double dThreshold_l589;
        //6-Stream10
        public double dThreshold_u590;
        public double dThreshold_u591;
        public double dThreshold_u592;
        public double dThreshold_u593;
        public double dThreshold_u594;
        public double dThreshold_u595;
        public double dThreshold_u596;
        public double dThreshold_u597;
        public double dThreshold_u598;
        public double dThreshold_u599;

        public double dThreshold_l590;
        public double dThreshold_l591;
        public double dThreshold_l592;
        public double dThreshold_l593;
        public double dThreshold_l594;
        public double dThreshold_l595;
        public double dThreshold_l596;
        public double dThreshold_l597;
        public double dThreshold_l598;
        public double dThreshold_l599;
        //6-Stream11
        public double dThreshold_u5A0;
        public double dThreshold_u5A1;
        public double dThreshold_u5A2;
        public double dThreshold_u5A3;
        public double dThreshold_u5A4;
        public double dThreshold_u5A5;
        public double dThreshold_u5A6;
        public double dThreshold_u5A7;
        public double dThreshold_u5A8;
        public double dThreshold_u5A9;

        public double dThreshold_l5A0;
        public double dThreshold_l5A1;
        public double dThreshold_l5A2;
        public double dThreshold_l5A3;
        public double dThreshold_l5A4;
        public double dThreshold_l5A5;
        public double dThreshold_l5A6;
        public double dThreshold_l5A7;
        public double dThreshold_l5A8;
        public double dThreshold_l5A9;

        //品種7
        //7-Stream1
        public double dThreshold_u600;
        public double dThreshold_u601;
        public double dThreshold_u602;
        public double dThreshold_u603;
        public double dThreshold_u604;
        public double dThreshold_u605;
        public double dThreshold_u606;
        public double dThreshold_u607;
        public double dThreshold_u608;
        public double dThreshold_u609;

        public double dThreshold_l600;
        public double dThreshold_l601;
        public double dThreshold_l602;
        public double dThreshold_l603;
        public double dThreshold_l604;
        public double dThreshold_l605;
        public double dThreshold_l606;
        public double dThreshold_l607;
        public double dThreshold_l608;
        public double dThreshold_l609;
        //7-Stream2
        public double dThreshold_u610;
        public double dThreshold_u611;
        public double dThreshold_u612;
        public double dThreshold_u613;
        public double dThreshold_u614;
        public double dThreshold_u615;
        public double dThreshold_u616;
        public double dThreshold_u617;
        public double dThreshold_u618;
        public double dThreshold_u619;

        public double dThreshold_l610;
        public double dThreshold_l611;
        public double dThreshold_l612;
        public double dThreshold_l613;
        public double dThreshold_l614;
        public double dThreshold_l615;
        public double dThreshold_l616;
        public double dThreshold_l617;
        public double dThreshold_l618;
        public double dThreshold_l619;
        //7-Stream3
        public double dThreshold_u620;
        public double dThreshold_u621;
        public double dThreshold_u622;
        public double dThreshold_u623;
        public double dThreshold_u624;
        public double dThreshold_u625;
        public double dThreshold_u626;
        public double dThreshold_u627;
        public double dThreshold_u628;
        public double dThreshold_u629;

        public double dThreshold_l620;
        public double dThreshold_l621;
        public double dThreshold_l622;
        public double dThreshold_l623;
        public double dThreshold_l624;
        public double dThreshold_l625;
        public double dThreshold_l626;
        public double dThreshold_l627;
        public double dThreshold_l628;
        public double dThreshold_l629;
        //7-Stream4
        public double dThreshold_u630;
        public double dThreshold_u631;
        public double dThreshold_u632;
        public double dThreshold_u633;
        public double dThreshold_u634;
        public double dThreshold_u635;
        public double dThreshold_u636;
        public double dThreshold_u637;
        public double dThreshold_u638;
        public double dThreshold_u639;

        public double dThreshold_l630;
        public double dThreshold_l631;
        public double dThreshold_l632;
        public double dThreshold_l633;
        public double dThreshold_l634;
        public double dThreshold_l635;
        public double dThreshold_l636;
        public double dThreshold_l637;
        public double dThreshold_l638;
        public double dThreshold_l639;
        //7-Stream5
        public double dThreshold_u640;
        public double dThreshold_u641;
        public double dThreshold_u642;
        public double dThreshold_u643;
        public double dThreshold_u644;
        public double dThreshold_u645;
        public double dThreshold_u646;
        public double dThreshold_u647;
        public double dThreshold_u648;
        public double dThreshold_u649;

        public double dThreshold_l640;
        public double dThreshold_l641;
        public double dThreshold_l642;
        public double dThreshold_l643;
        public double dThreshold_l644;
        public double dThreshold_l645;
        public double dThreshold_l646;
        public double dThreshold_l647;
        public double dThreshold_l648;
        public double dThreshold_l649;
        //7-Stream6
        public double dThreshold_u650;
        public double dThreshold_u651;
        public double dThreshold_u652;
        public double dThreshold_u653;
        public double dThreshold_u654;
        public double dThreshold_u655;
        public double dThreshold_u656;
        public double dThreshold_u657;
        public double dThreshold_u658;
        public double dThreshold_u659;

        public double dThreshold_l650;
        public double dThreshold_l651;
        public double dThreshold_l652;
        public double dThreshold_l653;
        public double dThreshold_l654;
        public double dThreshold_l655;
        public double dThreshold_l656;
        public double dThreshold_l657;
        public double dThreshold_l658;
        public double dThreshold_l659;
        //7-Stream7
        public double dThreshold_u660;
        public double dThreshold_u661;
        public double dThreshold_u662;
        public double dThreshold_u663;
        public double dThreshold_u664;
        public double dThreshold_u665;
        public double dThreshold_u666;
        public double dThreshold_u667;
        public double dThreshold_u668;
        public double dThreshold_u669;

        public double dThreshold_l660;
        public double dThreshold_l661;
        public double dThreshold_l662;
        public double dThreshold_l663;
        public double dThreshold_l664;
        public double dThreshold_l665;
        public double dThreshold_l666;
        public double dThreshold_l667;
        public double dThreshold_l668;
        public double dThreshold_l669;
        //7-Stream8
        public double dThreshold_u670;
        public double dThreshold_u671;
        public double dThreshold_u672;
        public double dThreshold_u673;
        public double dThreshold_u674;
        public double dThreshold_u675;
        public double dThreshold_u676;
        public double dThreshold_u677;
        public double dThreshold_u678;
        public double dThreshold_u679;

        public double dThreshold_l670;
        public double dThreshold_l671;
        public double dThreshold_l672;
        public double dThreshold_l673;
        public double dThreshold_l674;
        public double dThreshold_l675;
        public double dThreshold_l676;
        public double dThreshold_l677;
        public double dThreshold_l678;
        public double dThreshold_l679;
        //7-Stream9
        public double dThreshold_u680;
        public double dThreshold_u681;
        public double dThreshold_u682;
        public double dThreshold_u683;
        public double dThreshold_u684;
        public double dThreshold_u685;
        public double dThreshold_u686;
        public double dThreshold_u687;
        public double dThreshold_u688;
        public double dThreshold_u689;

        public double dThreshold_l680;
        public double dThreshold_l681;
        public double dThreshold_l682;
        public double dThreshold_l683;
        public double dThreshold_l684;
        public double dThreshold_l685;
        public double dThreshold_l686;
        public double dThreshold_l687;
        public double dThreshold_l688;
        public double dThreshold_l689;
        //7-Stream10
        public double dThreshold_u690;
        public double dThreshold_u691;
        public double dThreshold_u692;
        public double dThreshold_u693;
        public double dThreshold_u694;
        public double dThreshold_u695;
        public double dThreshold_u696;
        public double dThreshold_u697;
        public double dThreshold_u698;
        public double dThreshold_u699;

        public double dThreshold_l690;
        public double dThreshold_l691;
        public double dThreshold_l692;
        public double dThreshold_l693;
        public double dThreshold_l694;
        public double dThreshold_l695;
        public double dThreshold_l696;
        public double dThreshold_l697;
        public double dThreshold_l698;
        public double dThreshold_l699;
        //7-Stream11
        public double dThreshold_u6A0;
        public double dThreshold_u6A1;
        public double dThreshold_u6A2;
        public double dThreshold_u6A3;
        public double dThreshold_u6A4;
        public double dThreshold_u6A5;
        public double dThreshold_u6A6;
        public double dThreshold_u6A7;
        public double dThreshold_u6A8;
        public double dThreshold_u6A9;

        public double dThreshold_l6A0;
        public double dThreshold_l6A1;
        public double dThreshold_l6A2;
        public double dThreshold_l6A3;
        public double dThreshold_l6A4;
        public double dThreshold_l6A5;
        public double dThreshold_l6A6;
        public double dThreshold_l6A7;
        public double dThreshold_l6A8;
        public double dThreshold_l6A9;

        //品種8
        //8-Stream1
        public double dThreshold_u700;
        public double dThreshold_u701;
        public double dThreshold_u702;
        public double dThreshold_u703;
        public double dThreshold_u704;
        public double dThreshold_u705;
        public double dThreshold_u706;
        public double dThreshold_u707;
        public double dThreshold_u708;
        public double dThreshold_u709;

        public double dThreshold_l700;
        public double dThreshold_l701;
        public double dThreshold_l702;
        public double dThreshold_l703;
        public double dThreshold_l704;
        public double dThreshold_l705;
        public double dThreshold_l706;
        public double dThreshold_l707;
        public double dThreshold_l708;
        public double dThreshold_l709;
        //8-Stream2
        public double dThreshold_u710;
        public double dThreshold_u711;
        public double dThreshold_u712;
        public double dThreshold_u713;
        public double dThreshold_u714;
        public double dThreshold_u715;
        public double dThreshold_u716;
        public double dThreshold_u717;
        public double dThreshold_u718;
        public double dThreshold_u719;

        public double dThreshold_l710;
        public double dThreshold_l711;
        public double dThreshold_l712;
        public double dThreshold_l713;
        public double dThreshold_l714;
        public double dThreshold_l715;
        public double dThreshold_l716;
        public double dThreshold_l717;
        public double dThreshold_l718;
        public double dThreshold_l719;
        //8-Stream3
        public double dThreshold_u720;
        public double dThreshold_u721;
        public double dThreshold_u722;
        public double dThreshold_u723;
        public double dThreshold_u724;
        public double dThreshold_u725;
        public double dThreshold_u726;
        public double dThreshold_u727;
        public double dThreshold_u728;
        public double dThreshold_u729;

        public double dThreshold_l720;
        public double dThreshold_l721;
        public double dThreshold_l722;
        public double dThreshold_l723;
        public double dThreshold_l724;
        public double dThreshold_l725;
        public double dThreshold_l726;
        public double dThreshold_l727;
        public double dThreshold_l728;
        public double dThreshold_l729;
        //8-Stream4
        public double dThreshold_u730;
        public double dThreshold_u731;
        public double dThreshold_u732;
        public double dThreshold_u733;
        public double dThreshold_u734;
        public double dThreshold_u735;
        public double dThreshold_u736;
        public double dThreshold_u737;
        public double dThreshold_u738;
        public double dThreshold_u739;

        public double dThreshold_l730;
        public double dThreshold_l731;
        public double dThreshold_l732;
        public double dThreshold_l733;
        public double dThreshold_l734;
        public double dThreshold_l735;
        public double dThreshold_l736;
        public double dThreshold_l737;
        public double dThreshold_l738;
        public double dThreshold_l739;
        //8-Stream5
        public double dThreshold_u740;
        public double dThreshold_u741;
        public double dThreshold_u742;
        public double dThreshold_u743;
        public double dThreshold_u744;
        public double dThreshold_u745;
        public double dThreshold_u746;
        public double dThreshold_u747;
        public double dThreshold_u748;
        public double dThreshold_u749;

        public double dThreshold_l740;
        public double dThreshold_l741;
        public double dThreshold_l742;
        public double dThreshold_l743;
        public double dThreshold_l744;
        public double dThreshold_l745;
        public double dThreshold_l746;
        public double dThreshold_l747;
        public double dThreshold_l748;
        public double dThreshold_l749;
        //8-Stream6
        public double dThreshold_u750;
        public double dThreshold_u751;
        public double dThreshold_u752;
        public double dThreshold_u753;
        public double dThreshold_u754;
        public double dThreshold_u755;
        public double dThreshold_u756;
        public double dThreshold_u757;
        public double dThreshold_u758;
        public double dThreshold_u759;

        public double dThreshold_l750;
        public double dThreshold_l751;
        public double dThreshold_l752;
        public double dThreshold_l753;
        public double dThreshold_l754;
        public double dThreshold_l755;
        public double dThreshold_l756;
        public double dThreshold_l757;
        public double dThreshold_l758;
        public double dThreshold_l759;
        //8-Stream7
        public double dThreshold_u760;
        public double dThreshold_u761;
        public double dThreshold_u762;
        public double dThreshold_u763;
        public double dThreshold_u764;
        public double dThreshold_u765;
        public double dThreshold_u766;
        public double dThreshold_u767;
        public double dThreshold_u768;
        public double dThreshold_u769;

        public double dThreshold_l760;
        public double dThreshold_l761;
        public double dThreshold_l762;
        public double dThreshold_l763;
        public double dThreshold_l764;
        public double dThreshold_l765;
        public double dThreshold_l766;
        public double dThreshold_l767;
        public double dThreshold_l768;
        public double dThreshold_l769;
        //8-Stream8
        public double dThreshold_u770;
        public double dThreshold_u771;
        public double dThreshold_u772;
        public double dThreshold_u773;
        public double dThreshold_u774;
        public double dThreshold_u775;
        public double dThreshold_u776;
        public double dThreshold_u777;
        public double dThreshold_u778;
        public double dThreshold_u779;

        public double dThreshold_l770;
        public double dThreshold_l771;
        public double dThreshold_l772;
        public double dThreshold_l773;
        public double dThreshold_l774;
        public double dThreshold_l775;
        public double dThreshold_l776;
        public double dThreshold_l777;
        public double dThreshold_l778;
        public double dThreshold_l779;
        //8-Stream9
        public double dThreshold_u780;
        public double dThreshold_u781;
        public double dThreshold_u782;
        public double dThreshold_u783;
        public double dThreshold_u784;
        public double dThreshold_u785;
        public double dThreshold_u786;
        public double dThreshold_u787;
        public double dThreshold_u788;
        public double dThreshold_u789;

        public double dThreshold_l780;
        public double dThreshold_l781;
        public double dThreshold_l782;
        public double dThreshold_l783;
        public double dThreshold_l784;
        public double dThreshold_l785;
        public double dThreshold_l786;
        public double dThreshold_l787;
        public double dThreshold_l788;
        public double dThreshold_l789;
        //8-Stream10
        public double dThreshold_u790;
        public double dThreshold_u791;
        public double dThreshold_u792;
        public double dThreshold_u793;
        public double dThreshold_u794;
        public double dThreshold_u795;
        public double dThreshold_u796;
        public double dThreshold_u797;
        public double dThreshold_u798;
        public double dThreshold_u799;

        public double dThreshold_l790;
        public double dThreshold_l791;
        public double dThreshold_l792;
        public double dThreshold_l793;
        public double dThreshold_l794;
        public double dThreshold_l795;
        public double dThreshold_l796;
        public double dThreshold_l797;
        public double dThreshold_l798;
        public double dThreshold_l799;
        //8-Stream11
        public double dThreshold_u7A0;
        public double dThreshold_u7A1;
        public double dThreshold_u7A2;
        public double dThreshold_u7A3;
        public double dThreshold_u7A4;
        public double dThreshold_u7A5;
        public double dThreshold_u7A6;
        public double dThreshold_u7A7;
        public double dThreshold_u7A8;
        public double dThreshold_u7A9;

        public double dThreshold_l7A0;
        public double dThreshold_l7A1;
        public double dThreshold_l7A2;
        public double dThreshold_l7A3;
        public double dThreshold_l7A4;
        public double dThreshold_l7A5;
        public double dThreshold_l7A6;
        public double dThreshold_l7A7;
        public double dThreshold_l7A8;
        public double dThreshold_l7A9;

        //品種9
        //9-Stream1
        public double dThreshold_u800;
        public double dThreshold_u801;
        public double dThreshold_u802;
        public double dThreshold_u803;
        public double dThreshold_u804;
        public double dThreshold_u805;
        public double dThreshold_u806;
        public double dThreshold_u807;
        public double dThreshold_u808;
        public double dThreshold_u809;

        public double dThreshold_l800;
        public double dThreshold_l801;
        public double dThreshold_l802;
        public double dThreshold_l803;
        public double dThreshold_l804;
        public double dThreshold_l805;
        public double dThreshold_l806;
        public double dThreshold_l807;
        public double dThreshold_l808;
        public double dThreshold_l809;
        //9-Stream2
        public double dThreshold_u810;
        public double dThreshold_u811;
        public double dThreshold_u812;
        public double dThreshold_u813;
        public double dThreshold_u814;
        public double dThreshold_u815;
        public double dThreshold_u816;
        public double dThreshold_u817;
        public double dThreshold_u818;
        public double dThreshold_u819;

        public double dThreshold_l810;
        public double dThreshold_l811;
        public double dThreshold_l812;
        public double dThreshold_l813;
        public double dThreshold_l814;
        public double dThreshold_l815;
        public double dThreshold_l816;
        public double dThreshold_l817;
        public double dThreshold_l818;
        public double dThreshold_l819;
        //9-Stream3
        public double dThreshold_u820;
        public double dThreshold_u821;
        public double dThreshold_u822;
        public double dThreshold_u823;
        public double dThreshold_u824;
        public double dThreshold_u825;
        public double dThreshold_u826;
        public double dThreshold_u827;
        public double dThreshold_u828;
        public double dThreshold_u829;

        public double dThreshold_l820;
        public double dThreshold_l821;
        public double dThreshold_l822;
        public double dThreshold_l823;
        public double dThreshold_l824;
        public double dThreshold_l825;
        public double dThreshold_l826;
        public double dThreshold_l827;
        public double dThreshold_l828;
        public double dThreshold_l829;
        //9-Stream4
        public double dThreshold_u830;
        public double dThreshold_u831;
        public double dThreshold_u832;
        public double dThreshold_u833;
        public double dThreshold_u834;
        public double dThreshold_u835;
        public double dThreshold_u836;
        public double dThreshold_u837;
        public double dThreshold_u838;
        public double dThreshold_u839;

        public double dThreshold_l830;
        public double dThreshold_l831;
        public double dThreshold_l832;
        public double dThreshold_l833;
        public double dThreshold_l834;
        public double dThreshold_l835;
        public double dThreshold_l836;
        public double dThreshold_l837;
        public double dThreshold_l838;
        public double dThreshold_l839;
        //9-Stream5
        public double dThreshold_u840;
        public double dThreshold_u841;
        public double dThreshold_u842;
        public double dThreshold_u843;
        public double dThreshold_u844;
        public double dThreshold_u845;
        public double dThreshold_u846;
        public double dThreshold_u847;
        public double dThreshold_u848;
        public double dThreshold_u849;

        public double dThreshold_l840;
        public double dThreshold_l841;
        public double dThreshold_l842;
        public double dThreshold_l843;
        public double dThreshold_l844;
        public double dThreshold_l845;
        public double dThreshold_l846;
        public double dThreshold_l847;
        public double dThreshold_l848;
        public double dThreshold_l849;
        //9-Stream6
        public double dThreshold_u850;
        public double dThreshold_u851;
        public double dThreshold_u852;
        public double dThreshold_u853;
        public double dThreshold_u854;
        public double dThreshold_u855;
        public double dThreshold_u856;
        public double dThreshold_u857;
        public double dThreshold_u858;
        public double dThreshold_u859;

        public double dThreshold_l850;
        public double dThreshold_l851;
        public double dThreshold_l852;
        public double dThreshold_l853;
        public double dThreshold_l854;
        public double dThreshold_l855;
        public double dThreshold_l856;
        public double dThreshold_l857;
        public double dThreshold_l858;
        public double dThreshold_l859;
        //9-Stream7
        public double dThreshold_u860;
        public double dThreshold_u861;
        public double dThreshold_u862;
        public double dThreshold_u863;
        public double dThreshold_u864;
        public double dThreshold_u865;
        public double dThreshold_u866;
        public double dThreshold_u867;
        public double dThreshold_u868;
        public double dThreshold_u869;

        public double dThreshold_l860;
        public double dThreshold_l861;
        public double dThreshold_l862;
        public double dThreshold_l863;
        public double dThreshold_l864;
        public double dThreshold_l865;
        public double dThreshold_l866;
        public double dThreshold_l867;
        public double dThreshold_l868;
        public double dThreshold_l869;
        //9-Stream8
        public double dThreshold_u870;
        public double dThreshold_u871;
        public double dThreshold_u872;
        public double dThreshold_u873;
        public double dThreshold_u874;
        public double dThreshold_u875;
        public double dThreshold_u876;
        public double dThreshold_u877;
        public double dThreshold_u878;
        public double dThreshold_u879;

        public double dThreshold_l870;
        public double dThreshold_l871;
        public double dThreshold_l872;
        public double dThreshold_l873;
        public double dThreshold_l874;
        public double dThreshold_l875;
        public double dThreshold_l876;
        public double dThreshold_l877;
        public double dThreshold_l878;
        public double dThreshold_l879;
        //9-Stream9
        public double dThreshold_u880;
        public double dThreshold_u881;
        public double dThreshold_u882;
        public double dThreshold_u883;
        public double dThreshold_u884;
        public double dThreshold_u885;
        public double dThreshold_u886;
        public double dThreshold_u887;
        public double dThreshold_u888;
        public double dThreshold_u889;

        public double dThreshold_l880;
        public double dThreshold_l881;
        public double dThreshold_l882;
        public double dThreshold_l883;
        public double dThreshold_l884;
        public double dThreshold_l885;
        public double dThreshold_l886;
        public double dThreshold_l887;
        public double dThreshold_l888;
        public double dThreshold_l889;
        //9-Stream10
        public double dThreshold_u890;
        public double dThreshold_u891;
        public double dThreshold_u892;
        public double dThreshold_u893;
        public double dThreshold_u894;
        public double dThreshold_u895;
        public double dThreshold_u896;
        public double dThreshold_u897;
        public double dThreshold_u898;
        public double dThreshold_u899;

        public double dThreshold_l890;
        public double dThreshold_l891;
        public double dThreshold_l892;
        public double dThreshold_l893;
        public double dThreshold_l894;
        public double dThreshold_l895;
        public double dThreshold_l896;
        public double dThreshold_l897;
        public double dThreshold_l898;
        public double dThreshold_l899;
        //9-Stream11
        public double dThreshold_u8A0;
        public double dThreshold_u8A1;
        public double dThreshold_u8A2;
        public double dThreshold_u8A3;
        public double dThreshold_u8A4;
        public double dThreshold_u8A5;
        public double dThreshold_u8A6;
        public double dThreshold_u8A7;
        public double dThreshold_u8A8;
        public double dThreshold_u8A9;

        public double dThreshold_l8A0;
        public double dThreshold_l8A1;
        public double dThreshold_l8A2;
        public double dThreshold_l8A3;
        public double dThreshold_l8A4;
        public double dThreshold_l8A5;
        public double dThreshold_l8A6;
        public double dThreshold_l8A7;
        public double dThreshold_l8A8;
        public double dThreshold_l8A9;

        //品種10
        //10-Stream1
        public double dThreshold_u900;
        public double dThreshold_u901;
        public double dThreshold_u902;
        public double dThreshold_u903;
        public double dThreshold_u904;
        public double dThreshold_u905;
        public double dThreshold_u906;
        public double dThreshold_u907;
        public double dThreshold_u908;
        public double dThreshold_u909;

        public double dThreshold_l900;
        public double dThreshold_l901;
        public double dThreshold_l902;
        public double dThreshold_l903;
        public double dThreshold_l904;
        public double dThreshold_l905;
        public double dThreshold_l906;
        public double dThreshold_l907;
        public double dThreshold_l908;
        public double dThreshold_l909;
        //10-Stream2
        public double dThreshold_u910;
        public double dThreshold_u911;
        public double dThreshold_u912;
        public double dThreshold_u913;
        public double dThreshold_u914;
        public double dThreshold_u915;
        public double dThreshold_u916;
        public double dThreshold_u917;
        public double dThreshold_u918;
        public double dThreshold_u919;

        public double dThreshold_l910;
        public double dThreshold_l911;
        public double dThreshold_l912;
        public double dThreshold_l913;
        public double dThreshold_l914;
        public double dThreshold_l915;
        public double dThreshold_l916;
        public double dThreshold_l917;
        public double dThreshold_l918;
        public double dThreshold_l919;
        //10-Stream3
        public double dThreshold_u920;
        public double dThreshold_u921;
        public double dThreshold_u922;
        public double dThreshold_u923;
        public double dThreshold_u924;
        public double dThreshold_u925;
        public double dThreshold_u926;
        public double dThreshold_u927;
        public double dThreshold_u928;
        public double dThreshold_u929;

        public double dThreshold_l920;
        public double dThreshold_l921;
        public double dThreshold_l922;
        public double dThreshold_l923;
        public double dThreshold_l924;
        public double dThreshold_l925;
        public double dThreshold_l926;
        public double dThreshold_l927;
        public double dThreshold_l928;
        public double dThreshold_l929;
        //10-Stream4
        public double dThreshold_u930;
        public double dThreshold_u931;
        public double dThreshold_u932;
        public double dThreshold_u933;
        public double dThreshold_u934;
        public double dThreshold_u935;
        public double dThreshold_u936;
        public double dThreshold_u937;
        public double dThreshold_u938;
        public double dThreshold_u939;

        public double dThreshold_l930;
        public double dThreshold_l931;
        public double dThreshold_l932;
        public double dThreshold_l933;
        public double dThreshold_l934;
        public double dThreshold_l935;
        public double dThreshold_l936;
        public double dThreshold_l937;
        public double dThreshold_l938;
        public double dThreshold_l939;
        //10-Stream5
        public double dThreshold_u940;
        public double dThreshold_u941;
        public double dThreshold_u942;
        public double dThreshold_u943;
        public double dThreshold_u944;
        public double dThreshold_u945;
        public double dThreshold_u946;
        public double dThreshold_u947;
        public double dThreshold_u948;
        public double dThreshold_u949;

        public double dThreshold_l940;
        public double dThreshold_l941;
        public double dThreshold_l942;
        public double dThreshold_l943;
        public double dThreshold_l944;
        public double dThreshold_l945;
        public double dThreshold_l946;
        public double dThreshold_l947;
        public double dThreshold_l948;
        public double dThreshold_l949;
        //10-Stream6
        public double dThreshold_u950;
        public double dThreshold_u951;
        public double dThreshold_u952;
        public double dThreshold_u953;
        public double dThreshold_u954;
        public double dThreshold_u955;
        public double dThreshold_u956;
        public double dThreshold_u957;
        public double dThreshold_u958;
        public double dThreshold_u959;

        public double dThreshold_l950;
        public double dThreshold_l951;
        public double dThreshold_l952;
        public double dThreshold_l953;
        public double dThreshold_l954;
        public double dThreshold_l955;
        public double dThreshold_l956;
        public double dThreshold_l957;
        public double dThreshold_l958;
        public double dThreshold_l959;
        //10-Stream7
        public double dThreshold_u960;
        public double dThreshold_u961;
        public double dThreshold_u962;
        public double dThreshold_u963;
        public double dThreshold_u964;
        public double dThreshold_u965;
        public double dThreshold_u966;
        public double dThreshold_u967;
        public double dThreshold_u968;
        public double dThreshold_u969;

        public double dThreshold_l960;
        public double dThreshold_l961;
        public double dThreshold_l962;
        public double dThreshold_l963;
        public double dThreshold_l964;
        public double dThreshold_l965;
        public double dThreshold_l966;
        public double dThreshold_l967;
        public double dThreshold_l968;
        public double dThreshold_l969;
        //10-Stream8
        public double dThreshold_u970;
        public double dThreshold_u971;
        public double dThreshold_u972;
        public double dThreshold_u973;
        public double dThreshold_u974;
        public double dThreshold_u975;
        public double dThreshold_u976;
        public double dThreshold_u977;
        public double dThreshold_u978;
        public double dThreshold_u979;

        public double dThreshold_l970;
        public double dThreshold_l971;
        public double dThreshold_l972;
        public double dThreshold_l973;
        public double dThreshold_l974;
        public double dThreshold_l975;
        public double dThreshold_l976;
        public double dThreshold_l977;
        public double dThreshold_l978;
        public double dThreshold_l979;
        //10-Stream9
        public double dThreshold_u980;
        public double dThreshold_u981;
        public double dThreshold_u982;
        public double dThreshold_u983;
        public double dThreshold_u984;
        public double dThreshold_u985;
        public double dThreshold_u986;
        public double dThreshold_u987;
        public double dThreshold_u988;
        public double dThreshold_u989;

        public double dThreshold_l980;
        public double dThreshold_l981;
        public double dThreshold_l982;
        public double dThreshold_l983;
        public double dThreshold_l984;
        public double dThreshold_l985;
        public double dThreshold_l986;
        public double dThreshold_l987;
        public double dThreshold_l988;
        public double dThreshold_l989;
        //10-Stream10
        public double dThreshold_u990;
        public double dThreshold_u991;
        public double dThreshold_u992;
        public double dThreshold_u993;
        public double dThreshold_u994;
        public double dThreshold_u995;
        public double dThreshold_u996;
        public double dThreshold_u997;
        public double dThreshold_u998;
        public double dThreshold_u999;

        public double dThreshold_l990;
        public double dThreshold_l991;
        public double dThreshold_l992;
        public double dThreshold_l993;
        public double dThreshold_l994;
        public double dThreshold_l995;
        public double dThreshold_l996;
        public double dThreshold_l997;
        public double dThreshold_l998;
        public double dThreshold_l999;
        //10-Stream11
        public double dThreshold_u9A0;
        public double dThreshold_u9A1;
        public double dThreshold_u9A2;
        public double dThreshold_u9A3;
        public double dThreshold_u9A4;
        public double dThreshold_u9A5;
        public double dThreshold_u9A6;
        public double dThreshold_u9A7;
        public double dThreshold_u9A8;
        public double dThreshold_u9A9;

        public double dThreshold_l9A0;
        public double dThreshold_l9A1;
        public double dThreshold_l9A2;
        public double dThreshold_l9A3;
        public double dThreshold_l9A4;
        public double dThreshold_l9A5;
        public double dThreshold_l9A6;
        public double dThreshold_l9A7;
        public double dThreshold_l9A8;
        public double dThreshold_l9A9;
        //ADD_END :2020/4/27 kitayama 理由：改造に合わせたしきい値を設定するため追加


    }
}
