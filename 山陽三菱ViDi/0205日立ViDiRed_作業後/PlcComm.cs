/*
 * ViDi画像処理システム用PLC通信
 * Version : 1.00.00.00
 * Date : 2025/01/29
 * Note : 伝文フォーマット： 3Eフレーム : データレジスタR/W
 * Copylight @有限会社ユキネカンパニー
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using log4net;

//using PLCCommLib;
using MITSUBISHI.Component;

namespace PlcComm
{

    #region 列挙型宣言

    // 伝文機能
    public enum MessFunc
    {
        VARIETY_NO_GET = 0,             // 品種No取得
        VARIETY_NO_SET,               // 品種No設定
        INSPECTION_START_STOP,          // 検査開始・停止
        INSPECTING_ON_OFF,              // 検査中ON/OFF
        JUDGI_RESULT,                   // 総合判定結果結果
        ONE_SHOT,                       // ワンショット
        SURVEY_CHECK,                   // 生存確認
    }

    /*
    // PLCからの指示
    enum PlcInstruction
    {
        VARIETY_SET = 0,                // 品種設定
        INSPECTION,                     // 本番検査
        ONE_SHOT,                       // ワンショット
    }
    */
    /*
    // 検査状態
    enum InspectionStatus
    {
        NO_ACTIVE = 0,                  //  
        INSPECTION_START,               // 検査開始
        INSPECTION_SOP,                 // 検査停止
        INSPECTING_ON,                  // 検査中ON
        INSPECTING_OFF,                 // 検査中OFF
    }
    */

    // コマンド機能
    enum CommandFunc
    {
        READ_BIT = 0,                    // 一括読出し：Bit
        READ_BYTE,                       // 一括読出し：Byte
        WRITE_BIT,                       // 一括書込み：Bit
        WRITE_BYTE,                      // 一括書込み：Byte
    }

    // 総合判定結果
    enum JudgeResult
    {
        NG = -1,
        OK = 1,
        ERROR = 3,
    }
    #endregion

    // 電文フォーマット用基本クラス
    public class PlcCommunication
    {
        // ログの初期化
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // MX ComponentのMCプロトコルライブラリ初期化
        DotUtlType dotUtlType = new DotUtlType()
        {
            ActLogicalStationNumber = 1
        };

        #region フィールド
        public string IpAdr = "192.168.1.1";
        public string Port = "0";
        // IP Address
        private IPAddress _ipAdr = new IPAddress(0);
        private int _port = 0;
        /// <summary>通信処理クラスのインスタンス</summary>
        //private PLCComm _PLC = null;
        //private PLCComm.VenderNames vnd = PLCComm.VenderNames.MITSUBISHI;
        //private PLCComm.ProtocolNames pro = PLCComm.ProtocolNames.MC3E;

        // デバイス名称 for MX ComponentのMCプロトコルライブラリ
        public String devJudgeResult            = "総合判定結果";
        public String devVarietyNo              = "機種No";
        public String devNowVarietyNo           = "現在機種No";
        public String devPcSurvivalConfirm      = "PC生存確認";
        public String devPlcSurvivalConfirm     = "PLC生存確認";
        public String devInspectionOnOff        = "検査ON_OFF";
        public String devInspectionStartStop    = "試験開始・停止";
        public String devOneshot                = "ワンショット";
        #endregion

        #region コンストラクタ
        public PlcCommunication()
        {

        }
        #endregion

        #region メンバ
        // 品種設定番号
        public int varietyNo = 0;
        // 検査開始・停止
        public int inspectionStartStop = 0;
        // 検査ON/OFF
        public int inspectionOnOff = 0;
        // 総合判定結果
        public int judgeResult = 0;
        // 生存確認フラグ
        public int survivalSutatus = 0;
        // ワンショット
        public int oneShot = 0;

        // Device
        public string deviceName = "";


        // 伝文作成の為に設定してもらうパラメータ
        // 多分、使わない
        //public UInt16 surveillanceTime = 0;                                                                   // 監視時間(Etherの場合)：'0'固定で運用する可能性が高い

        // 例外発生時の例外内容格納
        public Exception exceptionInfo;

        // 伝文固定値
        #region 先頭デバイス番号
        // 先頭デバイス番号:リトルエンディアン記述
        private static readonly byte[,] _TopDeviceNo = new byte[7, 3]{
                                                                            { 0x00, 0x05, 0x05 },               // 品種設定取得
                                                                            { 0x01, 0x00, 0x05 },               // 品種設定切り替え応答
                                                                            { 0x01, 0x05, 0x05 },               // 検査開始・停止
                                                                            { 0x01, 0x00, 0x05 },               // 検査中ON/OFF
                                                                            { 0x00, 0x00, 0x05 },               // 総合判定結果結果
                                                                            { 0x00, 0x00, 0x05 },               // ワンショット
                                                                            { 0x02, 0x05, 0x05 }                // 生存確認
                                                                       };
        #endregion

        /*
        // サブヘッダ
        private static readonly byte[] _SubHeaderReq = { 0x50, 0x00 };                                          // サブヘッダ:要求
        private static readonly byte[] _SubHeaderRes = { 0xD0, 0x00 };                                          // サブヘッダ:応答
        // アクセス経路
        private static readonly byte[] _AccessRoute = { 0x00, 0x00, 0xFF, 0xFF, 0x03, 0x00, 0x00 };             // アクセス経路：自局のみ
        */
        // 要求データ作成用
        // コマンド+サブコマンド
        private static readonly byte[,,] _Command = new byte[4, 2, 2]
                                                                {
                                                                { { 0x04, 0x01 }, { 0x00, 0x01 } },             // 一活読出しBit
                                                                { { 0x04, 0x01 }, { 0x00, 0x00 } },             // 一活読出しByte
                                                                { { 0x14, 0x01 }, { 0x00, 0x01 } },             // 一活書込みBit
                                                                { { 0x14, 0x01 }, { 0x00, 0x00 } }              // 一活書込みByte
                                                                };
        // デバイスコード
        private static readonly byte _DeviceCodeDataRegister =  0xA8;                                           // データレジスタ
        private static readonly byte _DeviceCodeRelay =         0x90;                                           // リレー

        // 終了コード
        //private static readonly short _EndCodeNormal = 0x0000;                                                  // 終了コード：正常終了
        //private static readonly short _EndCodeError  = 0x51C0;                                                  // 終了コード：異常終了


        // 伝文設定変数
        // 伝文
        private List<short> _listMessageRequest = new List<short>();                                            // 要求伝文
        private List<short> _listMessageReply = new List<short>();                                              // 応答伝文

        // デバイス点数：PLCへ書き込むするデータ数
        //private int _writeDeviceNum = 0;                                                                             // デバイス点数：PLCからR/Wするデータ数


        // 品種番号設定
        //public short varietySetting = 0;

        // 要求データ長
        //private short _reqestDataLen = 0;                                                                       // 要求データ長
        // 監視タイマー
        //private short _surveillanceTimer = 0;                                                                   // 監視タイマー
        // 終了コード格納
        //private short _endCode = 0;                                                                             // 終了コード

        // 伝文Data部
        private List<short> _listRreqestData = new List<short>();                                               // 要求データ
        // 要求伝文Data部 ：　書き込みデータ
        private List<short> _listWriteData = new List<short>();                                                 // 要求伝文Data部
        // 応答データ長                                                                                         // 応答データ長
        //private short _replyDataLen = 0;
        // 応答データ
        private List<short> _listReplyData = new List<short>();                                                 // 応答データ
        // エラー情報格納
        private List<short> _listErrorInfo = new List<short>();                                                 // エラー情報

        /*
        // 要求データ長
        private byte[] _reqestDataLen = new byte[2] { 0x00, 0x00 };                                             // 要求データ長
        // 監視タイマー
        private byte[] _surveillanceTimer = new byte[2] { 0x00, 0x00 };                                         // 監視タイマー
        // 終了コード格納
        private byte[] _endCode = new byte[2] { 0x00, 0x00 };                                                   // 終了コード

        // エラー情報格納
        private List<byte> _listErrorInfo = new List<byte>();                                                   // エラー情報

        // 伝文Data部
        private List<byte> _listRreqestData = new List<byte>();                                                 // 要求データ
        private List<byte> _listReplyData = new List<byte>();                                                   // 応答データ

        // 要求伝文Data部 ：　書き込みデータ
        private List<byte> _listWriteData = new List<byte>();                                                   // 書き込みデータ

        // 品種設定
        public List<byte> VarietySetting = new List<byte>();
        */
        // 生存確認フラグ
        //private bool _flgSurvival = false;
        #endregion

        #region メソッド
        // 通信回線Open
        // 通信設定チェック→通信クラスのインスタンス生成→オープン
        public void Open()
        {
            try
            {
                // IPアドレス
                if (!IPAddress.TryParse(IpAdr, out _ipAdr))
                {
                    logger.Error("PLC Comm: Open(): 失敗： IPアドレスが見つかりません");
                    return;
                }
                // 通信ポート
                if (!int.TryParse(Port, out _port))
                {
                    logger.Error("PLC Comm: Open(): 失敗： ポートが見つかりません");
                    return;
                }

                // 通信処理のインスタンスを生成
                //_PLC = new PLC_MC();

                // 設定
                /*
                _PLC.IsUdp = false;                                 // TCP/IP
                _PLC.IsAscii = false;                               // バイナリ
                _PLC.NetworkNumber = 0;
                _PLC.PCNumber = 0xFF;
                _PLC.ReqUnitIONumber = 0x3FF;
                _PLC.ReqUnitStnNumber = 0;
                _PLC.CPUCheckTime = 8;
                */

                // 回線オープン
                int ret = dotUtlType.Open();
                if (ret == 0)
                {
                    // 成功。
                    logger.Info("PLC Comm: Open(): 成功");
                }
                else
                {
                    // 失敗
                    logger.Error("PLC Comm: Open(): 失敗");
                }
                /*
                int ret = _PLC.Open();
                if (ret == PLCComm.RET_COMPLETED)
                {
                    // 成功。
                    logger.Info("PLC Comm: Open(): 成功");
                }
                else
                {
                    // 失敗
                    logger.Error("PLC Comm: Open(): 失敗");
                }
                */
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }

        // 通信回線Close
        private void Close()
        {
            try 
            {
                // 回線クローズ
                int ret = dotUtlType.Close();
                if (ret == 0)
                {
                    // 成功。
                    logger.Info("PLC Comm: Close(): 成功");
                }
                else
                {
                    // 失敗
                    logger.Error("PLC Comm: Close(): 失敗");
                }

                /*
                if (_PLC == null)
                {
                    // 失敗
                    logger.Error("PLC Comm: Close(): 成功");
                    return;
                }

                _PLC.Close();
                _PLC = null;
                */
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }

        // PLCとの通信：要求伝文を送信して応答伝文を受け取る
        public void Communication(MessFunc func)
        {
            try
            {
                //string dev = deviceName;
                int size = 0;
                int[] buffer = null;
                int[] data = null;
                int readBitData = 0;
                int writeBitData = 0;
                //short[] dat = null;
                int ret;

                /*
                // 通信クラスのインスタンス生成前は不可
                if (_PLC == null)
                {
                    logger.Error("PLC Comm: Communication(): インスタンス生成前");
                    return; 
                }

                // 通信回線オープンしないと通信は不可
                if (!_PLC.IsOpened())
                {
                    logger.Error("PLC Comm: Communication(): 通信回線オープン前");
                    return;
                }
                */

                // 応答メッセージのクリア
                //_listMessageReply.Clear();

                // 機能に応じて要求メッセージを送信・応答メッセージ受信
                switch (func)
                {
                    // 品種No取得 ReadByte
                    case MessFunc.VARIETY_NO_GET:
                        // 読み込み点数を設定
                        size = 1;
                        // 読み込みバッファ定義
                        buffer = new int[size];
                        // Commandを作成
                        //_setReqestDataReadByte(func, size);
                        // Messageに要求データをコピー
                        //dat = _listMessageRequest.ToArray();
                        // Read Byte
                        //ret = _PLC.ReadDeviceBlock(dev, size, ref dat);
                        ret = dotUtlType.ReadDeviceBlock(ref devVarietyNo, size, ref buffer);
                        // 品種Noを設定
                        varietyNo = (int)buffer[0];
                        if (ret == 0)
                        {
                            // 成功。
                            logger.Info("PLC Comm: Communication(): 品種No取得 ReadByte：成功");
                        }
                        else
                        {
                            // 失敗
                            logger.Error("PLC Comm: Communication(): 品種No取得 ReadByte：失敗");
                        }
                        // ログ
                        logger.Info("PLC Comm: 品種No取得 ReadByte要求送信・応答受信");
                        break;
                    // 現在品種No設定 WriteByte
                    case MessFunc.VARIETY_NO_SET:
                        //_setReqestDataWriteByte(func);
                        // 書き込むデータ数
                        //size = _listMessageRequest.Count;
                        size = 1;
                        // 書き込みバッファ定義
                        data = new int[size];
                        // 書き込みData
                        data[0] = varietyNo;

                        // Messageに要求データをコピー
                        //dat = _listMessageRequest.ToArray();
                        // Write Byte
                        //ret = _PLC.WriteDeviceBlock(dev, size, ref dat);
                        ret = dotUtlType.WriteDeviceBlock(ref devNowVarietyNo, size, data);
                        if (ret == 0)
                        {
                            // 成功。
                            logger.Info("PLC Comm: Communication(): 現在品種No設定 WriteByte：成功");
                        }
                        else
                        {
                            // 失敗
                            logger.Error("PLC Comm: Communication(): 現在品種No設定 WriteByte：失敗");
                        }
                        // ログ
                        logger.Info("PLC Comm: 現在品種No設定 WriteByte要求送信・応答受信");
                        break;
                    // 検査開始・停止 ReadBit
                    case MessFunc.INSPECTION_START_STOP:
                        // 読み込み点数を設定
                        //size = 1;
                        // 読み込みバッファ定義
                        //buffer = new int[size];
                        // Commandを作成
                        //_setReqestDataReadBit(func, size);
                        // Messageに要求データをコピー
                        //dat = _listMessageRequest.ToArray();
                        // Read Byte
                        //ret = _PLC.ReadDeviceBlock(dev, size, ref dat);
                        ret = dotUtlType.GetDevice(ref devInspectionStartStop, ref readBitData);
                        if (ret == 0)
                        {
                            // 成功。
                            logger.Info("PLC Comm: Communication(): 現在品種No設定 ReadBit：成功");
                        }
                        else
                        {
                            // 失敗
                            logger.Error("PLC Comm: Communication(): 現在品種No設定 ReadBit：失敗");
                        }
                        // 検査開始・停止取得
                        inspectionStartStop = readBitData;
                        // ログ
                        logger.Info("PLC Comm: 検査開始・停止 ReadBit要求送信・応答受信");
                        break;
                    // 検査中ON/OFF WriteBit
                    case MessFunc.INSPECTING_ON_OFF:
                        //_setReqestDataWriteBit(func);
                        // 書き込むデータ数
                        //size = _listMessageRequest.Count;
                        // Messageに要求データをコピー
                        //dat = _listMessageRequest.ToArray();
                        // 書き込むデータBit
                        writeBitData = inspectionOnOff;
                        // Write Byte
                        //ret = _PLC.WriteDeviceBlock(dev, size, ref dat);
                        ret = dotUtlType.SetDevice(ref devInspectionOnOff, writeBitData);
                        if (ret == 0)
                        {
                            // 成功。
                            logger.Info("PLC Comm: Communication(): 検査中ON/OFF WriteBit：成功");
                        }
                        else
                        {
                            // 失敗
                            logger.Error("PLC Comm: Communication(): 検査中ON/OFF WriteBit：失敗");
                        }
                        // ログ
                        logger.Info("PLC Comm: 検査中ON/OFF WriteBitt要求送信・応答受信");
                        break;
                    // 判定結果 WriteByte
                    case MessFunc.JUDGI_RESULT:
                        //_setReqestDataWriteByte(func);
                        // 書き込むデータ数
                        //size = _listMessageRequest.Count;
                        // Messageに要求データをコピー
                        //dat = _listMessageRequest.ToArray();
                        // Write Byte
                        //ret = _PLC.WriteDeviceBlock(dev, size, ref dat);
                        ret = dotUtlType.WriteDeviceBlock(ref devJudgeResult, size, data);
                        if (ret == 0)
                        {
                            // 成功。
                            logger.Info("PLC Comm: Communication(): 判定結果 WriteByte：成功");
                        }
                        else
                        {
                            // 失敗
                            logger.Error("PLC Comm: Communication(): 判定結果 WriteByte：失敗");
                        }
                        // ログ
                        logger.Info("PLC Comm: 判定結果 WriteByte要求送信・応答受信");
                        break;
                    // ワンショット ReadBit
                    case MessFunc.ONE_SHOT:
                        // 読み込み点数を設定
                        //size = 1;
                        // Commandを作成
                        //_setReqestDataReadBit(func, size);
                        // Messageに要求データをコピー
                        //dat = _listMessageRequest.ToArray();
                        // Read Byte
                        //ret = _PLC.ReadDeviceBlock(dev, size, ref dat);
                        ret = dotUtlType.GetDevice(ref devOneshot, ref readBitData);
                        if (ret == 0)
                        {
                            // 成功。
                            logger.Info("PLC Comm: Communication(): ワンショット ReadBit：成功");
                        }
                        else
                        {
                            // 失敗
                            logger.Error("PLC Comm: Communication(): ワンショット ReadBit：失敗");
                        }
                        // ワンショット設定
                        oneShot = readBitData;
                        // ログ
                        logger.Info("PLC Comm: ワンショット ReadBit要求送信・応答受信");
                        break;
                    // 生存確認 writeBit
                    case MessFunc.SURVEY_CHECK:
                        //_setReqestDataWriteBit(func);
                        // 書き込むデータ数
                        //size = _listMessageRequest.Count;
                        // Messageに要求データをコピー
                        //dat = _listMessageRequest.ToArray();
                        // Write Byte
                        //ret = _PLC.WriteDeviceBlock(dev, size, ref dat);
                        // 書き込むデータBit
                        writeBitData = survivalSutatus;
                        // Write Byte
                        //ret = _PLC.WriteDeviceBlock(dev, size, ref dat);
                        ret = dotUtlType.SetDevice(ref devPcSurvivalConfirm, writeBitData);
                        if (ret == 0)
                        {
                            // 成功。
                            logger.Info("PLC Comm: Communication(): 生存確認 WriteBit：成功");
                        }
                        else
                        {
                            // 失敗
                            logger.Error("PLC Comm: Communication(): 生存確認 WriteBit：失敗");
                        }
                        // ログ
                        logger.Info("PLC Comm: 生存確認 writeBit要求送信・応答受信");
                        break;
                    default:
                        return;
                }

                /*
                // 応答データの解析
                if (ret == PLCComm.RET_COMPLETED)
                {
                    // 要求伝文→応答伝文：成功。
                    logger.Error("PLC Comm: Communication(): 応答伝文：成功");

                    // 機能に応じて応答メッセージからパラメータ抽出
                    switch (func)
                    {
                        // 品種設定 ReadByte
                        case MessFunc.VARIETY_SET_GET:
                            // 品種Noを設定
                            varietyNo = (int)(dat[1]<<8 + dat[0]);
                            // ログ
                            logger.Info("PLC Comm: 品種設定 ReadByte応答: 品種No設定");
                            break;
                        // 検査開始・停止 ReadBit
                        case MessFunc.INSPECTION_START_STOP:
                            // 検査開始・停止を設定
                            inspectionStatus = (int)(dat[1] << 8 + dat[0]);
                            // ログ
                            logger.Info("PLC Comm: 検査開始・停止 ReadBit応答: 検査開始・停止設定");
                            break;
                        // ワンショット ReadBit
                        case MessFunc.ONE_SHOT:
                            // ワンショットを設定
                            oneShot = (int)(dat[1] << 8 + dat[0]);
                            // ログ
                            logger.Info("PLC Comm: ワンショット ReadBit応答: 検査開始・停止設定");
                            break;
                        default:
                            return;
                    }
                }
                else
                {
                    // 要求伝文→応答伝文：失敗
                    logger.Error("PLC Comm: Communication(): 応答伝文：失敗");
                }
                */
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }


        #region 要求Message作成
        /*
        // Read Byte 要求Message作成
        private void _setMesVarietySetting(CommandFunc rwFunc, int para)
        {
            try
            {
                // 要求データ作成
                _setReqestData(rwFunc, varietyNo, (int)MessFunc.VARIETY_SET_GET);
                // 要求データ長設定
                //_setReqestDataLen();

                // 伝文作成
                _setReqMessage();
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }


        // 品種設定 要求Message作成
        private void _setMesVarietySetting(CommandFunc rwFunc, int para)
        {
            try
            {
                // 要求データ作成
                _setReqestData(rwFunc, varietyNo, (int)MessFunc.VARIETY_SET_GET);
                // 要求データ長設定
                //_setReqestDataLen();

                // 伝文作成
                _setReqMessage();
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }

        // 品種切り替え応答 要求Message作成
        private void _setMesVarietyReply(CommandFunc rwFunc, int para)
        {
            try
            {
                // 書き込みデータ取得
                // 現状は暫定処理
                _listWriteData.Clear();
                for (int idx = 0; idx < 4; idx++)
                    _listWriteData.Add((byte)idx);

                _writeDeviceNum = _listWriteData.Count;

                // 要求データ作成
                _setReqestData(rwFunc, varietyNo, (int)MessFunc.VARIETY_SET_DONE);
                // 要求データ長設定
                //_setReqestDataLen();

                // 伝文作成
                _setReqMessage();
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }

        // 検査開始・停止 要求Message作成
        private void _setMesInstStartStop(CommandFunc rwFunc, int para)
        {
            try
            {
                // 要求データ作成
                _setReqestData(rwFunc, varietyNo, (int)MessFunc.INSPECTION_START_STOP);
                // 要求データ長設定
                //_setReqestDataLen();

                // 伝文作成
                _setReqMessage();
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }

        // 検査中ON/OFF 要求Message作成
        private void _setMesInstOnOff(CommandFunc rwFunc, int para)
        {
            try
            {
                // 書き込みデータ取得
                // 現状は暫定処理
                _listWriteData.Clear();
                for (int idx = 0; idx < 4; idx++)
                    _listWriteData.Add((byte)idx);

                // 要求データ作成
                _setReqestData(rwFunc, varietyNo, (int)MessFunc.INSPECTING_ON);
                // 要求データ長設定
                //_setReqestDataLen();

                // 伝文作成
                _setReqMessage();
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }

        // 総合判定結果 要求Message作成
        private void _setMesResult(CommandFunc rwFunc, int para)
        {
            try
            {
                // 書き込みデータ取得
                // 現状は暫定処理
                _listWriteData.Clear();
                for (int idx = 0; idx < 4; idx++)
                    _listWriteData.Add((byte)idx);

                // デバイス点数
                _deviceNum = 1;
                // 要求データ作成
                _setReqestData(rwFunc, varietyNo, (int)MessFunc.JUDGI_RESULT);
                // 要求データ長設定
                //_setReqestDataLen();

                // 伝文作成
                _setReqMessage();
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }

        // ワンショット 要求Message作成
        private void _setMesOneshot(CommandFunc rwFunc, int para)
        {
            try
            {
                // デバイス点数
                _deviceNum = 1;
                // 要求データ作成
                _setReqestData(rwFunc, varietyNo, (int)MessFunc.ONE_SHOT);
                // 要求データ長設定
                //_setReqestDataLen();

                // 伝文作成
                _setReqMessage();
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }

        // 生存確認 要求Message作成
        private void _setMesConfirmationSurvival(CommandFunc rwFunc, int para)
        {
            try
            {
                // フラグ反転
                _flgSurvival = !_flgSurvival;

                // 書き込みデータ取得
                // 現状は暫定処理
                _listWriteData.Clear();
                for (int idx = 0; idx < 4; idx++)
                    _listWriteData.Add((byte)idx);

                // 要求データ作成
                _setReqestData(rwFunc, varietyNo, (int)MessFunc.SURVEY_CHECK);
                // 要求データ長設定
                //_setReqestDataLen();

                // 伝文作成
                _setReqMessage();
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }


        // 要求伝文を作成する
        private void _setReqMessage()
        {
            try
            {
                // 伝文クリア
                _listMessageRequest.Clear();

                // 伝文作成
                
                // サブヘッダ
                //for (int idx = 0; idx < _SubHeaderReq.Length; idx++)
                //    _listMessageRequest.Add(_SubHeaderReq[idx]);
                // アクセス経路
                //for (int idx = 0; idx < _AccessRoute.Length; idx++)
                //    _listMessageRequest.Add(_AccessRoute[idx]);
                // 要求データ長
                //for (int idx = 0; idx < _reqestDataLen.Length; idx++)
                //    _listMessageRequest.Add(_reqestDataLen[idx]);
                

                // 監視タイマー
                _listMessageRequest.Add(_surveillanceTimer);
                // 要求データ
                for (int idx = 0; idx < _listRreqestData.Count; idx++)
                    _listMessageRequest.Add(_listRreqestData[idx]);
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }
        */

        // 要求伝文各部作成メソッド
        /*
        // 要求データ長生成
        private void _setReqestDataLen()
        {
            try
            {
                UInt16 _ulen = (UInt16)(_surveillanceTimer.Length + _listRreqestData.Count);

                _reqestDataLen[0] = (byte)(0x00FF & _ulen);
                _reqestDataLen[1] = (byte)((0xFF00 & _ulen) >> 8);
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }
        */

        /*
        // 要求データ読み込み
        private void _setReqestData(CommandFunc cf, int deviceNoId, int reqFuncId)
        {
            try
            {
                switch (cf)
                {
                    case CommandFunc.READ_BIT:
                        _setReqestDataRead(deviceNoId, reqFuncId);
                        break;
                    case CommandFunc.READ_BYTE:
                        _setReqestDataRead(deviceNoId, reqFuncId);
                        break;
                    case CommandFunc.WRITE_BIT:
                        _setReqestDataWrite(deviceNoId, reqFuncId);
                        break;
                    case CommandFunc.WRITE_BYTE:
                        _setReqestDataWrite(deviceNoId, reqFuncId);
                        break;
                }
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }
        */
        #endregion

        #region 要求Message作成
        /*
        // 読み出し
        // ReadByte
        private bool _setReqestDataReadByte(MessFunc reqFuncId, int num)
        {
            try
            {
                // クリア
                _listRreqestData.Clear();

                // コマンド＋サブコマンド
                int commId = (int)CommandFunc.READ_BYTE;
                _listRreqestData.Add(_Command[commId, 0, 0]);
                _listRreqestData.Add(_Command[commId, 0, 1]);
                _listRreqestData.Add(_Command[commId, 1, 0]);
                _listRreqestData.Add(_Command[commId, 1, 1]);

                // 先頭デバイス番号
                for (int idx = 0; idx < 3; idx++)
                    _listRreqestData.Add(_TopDeviceNo[(int)reqFuncId, idx]);

                // デバイスコード
                // データレジスタ
                _listRreqestData.Add(_DeviceCodeDataRegister);

                // デバイス点数
                UInt16 uiNum = (UInt16)num;
                _listRreqestData.Add((byte)(0x00FF & uiNum));
                _listRreqestData.Add((byte)((0xFF00 & uiNum) >> 8));

                return true;
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
                return false;
            }
            finally
            {

            }
        }
        // ReadByte
        private bool _setReqestDataReadBit(MessFunc reqFuncId, int num)
        {
            try
            {
                // クリア
                _listRreqestData.Clear();

                // コマンド＋サブコマンド
                int commId = (int)CommandFunc.READ_BIT;
                _listRreqestData.Add(_Command[commId, 0, 0]);
                _listRreqestData.Add(_Command[commId, 0, 1]);
                _listRreqestData.Add(_Command[commId, 1, 0]);
                _listRreqestData.Add(_Command[commId, 1, 1]);

                // 先頭デバイス番号
                for (int idx = 0; idx < 3; idx++)
                    _listRreqestData.Add(_TopDeviceNo[(int)reqFuncId, idx]);

                // デバイスコード
                // リレー
                _listRreqestData.Add(_DeviceCodeRelay);

                // デバイス点数
                UInt16 uiNum = (UInt16)num; ;
                _listRreqestData.Add((byte)(0x00FF & uiNum));
                _listRreqestData.Add((byte)((0xFF00 & uiNum) >> 8));

                return true;
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
                return false;
            }
            finally
            {

            }
        }
        */
        /*
        // 書き込み
        // Write Byte
        private bool _setReqestDataWriteByte(MessFunc mesFunc)
        {
            bool ret = false;
            try
            {
                // クリア
                _listRreqestData.Clear();

                // 書き込みデータのクリア
                _listWriteData.Clear();
                // 書き込みデータの作成
                byte _byte = 0;
                switch (mesFunc)
                {
                    // 品種設定切り替え応答
                    case MessFunc.VARIETY_SET_GET:
                        _byte = (byte)(0x000000FF & varietyNo);
                        _listWriteData.Add(_byte);
                        _byte = (byte)((0x0000FF00 & varietyNo) >> 8);
                        _listWriteData.Add(_byte);
                        break;
                    // 総合判定結果結果
                    case MessFunc.JUDGI_RESULT:
                        _byte = (byte)(0x000000FF & judgeResult);
                        _listWriteData.Add(_byte);
                        _byte = (byte)((0x0000FF00 & judgeResult) >> 8);
                        _listWriteData.Add(_byte);
                        break;
                    default:
                        return false;
                }

                // コマンド＋サブコマンド
                int commId = (int)CommandFunc.WRITE_BYTE;
                _listRreqestData.Add(_Command[commId, 0, 0]);
                _listRreqestData.Add(_Command[commId, 0, 1]);
                _listRreqestData.Add(_Command[commId, 1, 0]);
                _listRreqestData.Add(_Command[commId, 1, 1]);


                // 先頭デバイス番号
                for (int idx = 0; idx < 3; idx++)
                    _listRreqestData.Add(_TopDeviceNo[(int)mesFunc, idx]);

                // デバイスコード
                // データレジスタ
                _listRreqestData.Add(_DeviceCodeDataRegister);

                // デバイス点数
                UInt16 uiNum = (UInt16)_listWriteData.Count;
                _listRreqestData.Add((byte)(0x00FF & uiNum));
                _listRreqestData.Add((byte)((0xFF00 & uiNum) >> 8));

                // 書き込みデータ
                _listRreqestData.AddRange(_listWriteData);

                ret = true;
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
                return ret;
            }
            finally
            {
            }

            return ret;
        }
        // Write Bit
        private bool _setReqestDataWriteBit(MessFunc mesFunc)
        {
            bool ret = false;
            try
            {
                // クリア
                _listRreqestData.Clear();
                // 書き込みデータのクリア
                _listWriteData.Clear();
                // 書き込みデータの作成
                switch (mesFunc)
                {
                    // 検査ON/OFF
                    case MessFunc.INSPECTING_ON_OFF:
                        if (inspectionStatus <= 0)
                        {
                            _listWriteData.Add(0x00);
                            _listWriteData.Add(0x00);
                        }
                        else
                        {
                            _listWriteData.Add(0x00);
                            _listWriteData.Add(0x01);
                        }
                        break;
                    // 生存確認
                    case MessFunc.JUDGI_RESULT:
                        if (survivalSutatus <= 0)
                        {
                            _listWriteData.Add(0x00);
                            _listWriteData.Add(0x00);
                        }
                        else
                        {
                            _listWriteData.Add(0x00);
                            _listWriteData.Add(0x01);
                        }
                        break;
                    default:
                        return false;
                }

                // コマンド＋サブコマンド
                int commId = (int)CommandFunc.WRITE_BYTE;
                _listRreqestData.Add(_Command[commId, 0, 0]);
                _listRreqestData.Add(_Command[commId, 0, 1]);
                _listRreqestData.Add(_Command[commId, 1, 0]);
                _listRreqestData.Add(_Command[commId, 1, 1]);

                // 先頭デバイス番号
                for (int idx = 0; idx < 3; idx++)
                    _listRreqestData.Add(_TopDeviceNo[(int)mesFunc, idx]);

                // デバイスコード
                // リレー
                _listRreqestData.Add(_DeviceCodeRelay);

                // デバイス点数
                UInt16 uiNum = (UInt16)_listWriteData.Count;
                _listRreqestData.Add((byte)(0x00FF & uiNum));
                _listRreqestData.Add((byte)((0xFF00 & uiNum) >> 8));

                // 書き込みデータ
                _listRreqestData.AddRange(_listWriteData);
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
                return ret;
            }
            finally
            {

            }
            return ret;
        }
        */
        #endregion

        /*
        // QnUDVでは、無効
        // 監視タイマー生成
        private void _setSurveillanceTimer()
        {
            try
            {
                _surveillanceTimer[0] = (byte)(0x00FF & surveillanceTime);
                _surveillanceTimer[1] = (byte)((0xFF00 & surveillanceTime) >> 8);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        */

        #region 応答伝文解析
        // 応答伝文から各部の抽出
        private void _analyResMess()
        {
            try
            {
                // 終了コードのクリア
                //_endCode = 0x0000;
                // 応答コードのクリア
                _listReplyData.Clear();
                // エラー情報のクリア
                _listErrorInfo.Clear();

                /*
                // 終了コードの取得
                _endCode = _listMessageReply[0];
                if (_endCode == _EndCodeNormal)
                {
                    // 正常終了の場合
                    // 応答データの取得
                    if (1 < _replyDataLen)
                        _listMessageReply.AddRange(_listMessageReply.Skip(1).Take(_replyDataLen - 1));
                }
                else if (_endCode == _EndCodeError)
                {
                    // 異常終了の場合
                    // エラー情報の取得
                    if (1 < _replyDataLen)
                        _listErrorInfo.AddRange(_listMessageReply.Skip(1).Take(_replyDataLen - 1));
                }
                else
                {

                }
                */

                /*
                // サブヘッダを比較して先頭のインデックスを取得
                int firstIndex = -1;
                int replyMesLeng = _listMessageReply.Count;
                for (int idx = 0; idx < replyMesLeng - 1; idx++)
                {
                    if (_listMessageReply[idx] == _SubHeaderRes[0] && _listMessageReply[idx+1] == _SubHeaderRes[1])
                    {
                        firstIndex = idx;
                        break;
                    }
                }
                if (0 <= firstIndex)
                {
                    // 応答データ長の取得
                    int dataLen = (int)_listMessageReply[firstIndex] + (int)(_listMessageReply[firstIndex + 1] << 8);
                    // 終了コードの先頭を産出
                    int offset = firstIndex + _SubHeaderRes.Length + _AccessRoute.Length + 2;
                    // 終了コードの取得
                    if (2 <= replyMesLeng - offset)
                    {
                        _endCode[0] = _listMessageReply[offset];
                        _endCode[0 + 1] = _listMessageReply[offset + 1];

                        if (_endCode[0] == _EndCodeNormal[0]&& _endCode[1] == _EndCodeNormal[1])
                        {
                            // 正常終了の場合
                            // 応答データの取得
                            if (dataLen == replyMesLeng - offset)
                            {
                                _listReplyData.AddRange(_listMessageReply.Skip(offset + 2).Take(dataLen - 2));
                            }
                            else
                            {
                                // 取得値がおかしい
                            }
                        }
                        else if(_endCode[0] == _EndCodeError[0] && _endCode[1] == _EndCodeError[1])
                        {
                            // 異常終了の場合
                            // エラー情報の取得
                            if (dataLen == replyMesLeng - offset)
                            {
                                _listErrorInfo.AddRange(_listMessageReply.Skip(offset + 2).Take(dataLen - 2));
                            }
                            else
                            {
                                // 取得値がおかしい
                            }
                        }
                        else
                        {

                        }
                    }
                }
                */
            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }


        // 応答データの抽出
        private void _readReplyData()
        {
            try
            {

            }
            catch (Exception ex)
            {
                exceptionInfo = ex;
            }
            finally
            {

            }
        }
        #endregion
        #endregion
    }
}